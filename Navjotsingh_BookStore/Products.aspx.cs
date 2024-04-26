using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;
namespace Navjotsingh_BookStore
{
    public partial class Products : System.Web.UI.Page
    {
        protected TextBox quantityTextBox;
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "Product Page";
            if (!IsPostBack)
            {
                // Load data into the DropDownList on the first page load
                DisplayList();
                // Load the default data when drop down not selected
                DisplayDefault();


            }
          
        }

     
        private void DisplayList()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("SELECT id, product_name FROM books", connection))
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                // Clear existing items in case of a postback
                productSelections.Items.Clear();

                while (reader.Read())
                {
                  
                    // Retrieve values from the database
                    string productId = reader["id"].ToString();
                    string productName = reader["product_name"].ToString();

                    // Create a ListItem with the product_name as the displayed text and id as the value
                    ListItem item = new ListItem(productName, productId);

                    // Add the ListItem to the DropDownList
                    productSelections.Items.Add(item);


                }

                reader.Close();
            }
        }


        protected void DisplayDefault()
        {
                string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("SELECT * FROM books WHERE id = 1", connection))
                {
                    command.Parameters.AddWithValue("@id", 1);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            UpdateProductDetails(reader);
                        }
                        else
                        {
                            HandleProductNotFound();
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        LogError(ex);
                    }
                }
           
        }


        protected void productSelections_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Use SelectedValue instead of SelectedItem.Text to get the selected value
            string selectedProduct = productSelections.SelectedValue;

            // Try to parse the selected value as an integer
            if (int.TryParse(selectedProduct, out int selectedProductId))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["connect"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("SELECT * FROM books WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", selectedProductId);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            UpdateProductDetails(reader);
                        }
                        else
                        {
                            HandleProductNotFound();
                        }

                        reader.Close();
                    }
                    catch (Exception ex)
                    {
                        LogError(ex);
                    }
                }
            }
            else
            {
                errorMessageLabel.Text = "Invalid selected value.";
                errorMessageLabel.Visible = true;
            }
        }



        

        private void UpdateProductDetails(SqlDataReader reader)
        {
            productID.Text = reader["id"].ToString();
            productNameLabel.Text = reader["product_name"].ToString();
            descriptionLabel.Text = reader["description"].ToString();  
            priceLabel.Text = reader["price"].ToString();

            // Display the product image
            string imageUrl = reader["img"].ToString().Trim();
            productIMG.ImageUrl = imageUrl;
        }

        private void HandleProductNotFound()
        {
            productNameLabel.Text = "Product not found";
            descriptionLabel.Text = string.Empty;
            priceLabel.Text = string.Empty;
        }

        private void LogError(Exception ex)
        {
            // Log the exception to a file or a logging service
            // For example: Logger.LogError($"Error: {ex.Message}");
            Response.Write($"Error: {ex.Message}");
        }

        protected void addToCartButton_Click(object sender, EventArgs e)
        {
            // Your logic to add the selected product to the cart
            AddToCart();
        }


        private void AddToCart()
        {
            // Retrieve the selected product details
            int productId;
            if (!int.TryParse(productID.Text, out productId))
            {
                // Handle the case where the product ID is not a valid integer
                errorMessageLabel.Text = "Invalid Product ID.";
                errorMessageLabel.Visible = true;
                successMessageLabel.Visible = false; // Hide success message if an error occurs
                return; // Stop processing further
            }

            // Validate and convert the quantity
            int selectedQuantity;
            if (!int.TryParse(quantityTextBox.Text, out selectedQuantity) || selectedQuantity <= 0)
            {
                // Handle the case where the quantity is not a valid positive integer
                // Set a default quantity or display an error message
                selectedQuantity = 1;
                errorMessageLabel.Text = "Please enter a valid quantity.";
                errorMessageLabel.Visible = true;
                successMessageLabel.Visible = false; // Hide success message if an error occurs
                return; // Stop processing further
            }

            double price;
            if (!double.TryParse(priceLabel.Text, out price))
            {
                // Handle the case where the price is not a valid double
                // Set a default price or display an error message
                price = 0.0;
                errorMessageLabel.Text = "Invalid price format.";
                errorMessageLabel.Visible = true;
                successMessageLabel.Visible = false; // Hide success message if an error occurs
                return; // Stop processing further
            }

            // Retrieve existing cart items from the session
            List<Book> cartItems = Session["CartItems"] as List<Book> ?? new List<Book>();


            // Check if the product is already in the cart
            Book existingItem = cartItems.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem != null)
            {
                // If the product is already in the cart, update the quantity
                existingItem.Quantity += selectedQuantity;
            }
            else
            {
                // If the product is not in the cart, add a new item
                Book newItem = new Book { ProductId = productId, ProductName = productNameLabel.Text, Description = descriptionLabel.Text, Price = price, Quantity = selectedQuantity };
                cartItems.Add(newItem);
            }

            
            // Update the session with the modified cart items
            Session["CartItems"] = cartItems;

            // Show success message
            successMessageLabel.Text = "Item successfully added to the cart!";
            successMessageLabel.Visible = true;
            errorMessageLabel.Visible = false; // Hide error message if no error occurs
        }


        protected void proceedToCart_Click(object sender, EventArgs e)
        {
            // Redirect to Checkout page
            Response.Redirect("Cart.aspx");
        }

    }
}
