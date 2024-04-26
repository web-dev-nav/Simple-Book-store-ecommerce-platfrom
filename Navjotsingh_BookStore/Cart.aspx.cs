using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navjotsingh_BookStore
{
    public partial class Cart : System.Web.UI.Page
    {
       

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Load data into the DropDownList on the first page load
                DisplayCartItems();
                //DisplaySessionContents();

            }
        }

        private void DisplaySessionContents()
        {
            List<Book> cartItems = Session["CartItems"] as List<Book>;

            if (cartItems != null)
            {
                // Only display information in Response.Write when explicitly called
                if (!IsPostBack)
                {
                    Response.Write("Cart Items in Session:<br />");
                    foreach (var item in cartItems)
                    {
                        Response.Write($"Product ID: {item.ProductId}, Product Name: {item.ProductName}, Quantity: {item.Quantity}, Price: {item.Price:C}<br />");
                    }
                }
            }

           
        }


        protected void DestroySessionButton_Click(object sender, EventArgs e)
        {
            DestroySession();

            // Optionally, you can redirect to another page after destroying the session
            Response.Redirect("~/Cart.aspx");
        }

        protected void DestroySession()
        {
            // Clear all keys in the session
            Session.Clear();

            // Abandon the session, which removes all session data
            Session.Abandon();
        }

        private void DisplayCartItems()
        {
            // Retrieve cart items from the session
            List<Book> cartItems = Session["CartItems"] as List<Book> ?? new List<Book>();

            // Bind the cart items to the repeater
            cartRepeater.DataSource = cartItems;
            cartRepeater.DataBind();

            // Calculate and display the total price
            double totalPrice = CalculateTotalPrice(cartItems);
            totalAmount.InnerText = $"Total: {totalPrice.ToString("C")}";
        }


        protected void RemoveItem_Click(object sender, EventArgs e)
        {
            // Retrieve the ProductId from the CommandArgument
            int productIdToRemove = Convert.ToInt32((sender as Button).CommandArgument);

            // Retrieve cart items from the session
            List<Book> cartItems = Session["CartItems"] as List<Book> ?? new List<Book>();

            // Remove the item with the specified ProductId
            cartItems.RemoveAll(item => item.ProductId == productIdToRemove);

            // Save the updated cart items back to the session
            Session["CartItems"] = cartItems;

            // Rebind the repeater to update the cart display
            cartRepeater.DataSource = cartItems;
            cartRepeater.DataBind();

            // Recalculate and display the total price
            double totalPrice = CalculateTotalPrice(cartItems);
            totalAmount.InnerText = $"Total: {totalPrice.ToString("C")}";
        }



        private double CalculateTotalPrice(List<Book> cartItems)
        {
            double totalPrice = 0.0;

            foreach (var item in cartItems)
            {
                totalPrice += item.Quantity * item.Price;
            }

            return totalPrice;
        }

        protected void checkoutButton_Click(object sender, EventArgs e)
        {
            // Handle checkout logic (redirect to payment, process order, etc.)
            // For now, let's redirect to a placeholder page
            Response.Redirect("~/Checkout.aspx");
        }

        protected void backto_Click(object sender, EventArgs e)
        {
            // Handle checkout logic (redirect to payment, process order, etc.)
            // For now, let's redirect to a placeholder page
            Response.Redirect("~/Products.aspx");
        }
        protected void proceedToCheckoutButton_Click(object sender, EventArgs e)
        {
            // Check if the cart is empty
            if (Session["CartItems"] == null || ((List<Book>)Session["CartItems"]).Count == 0)
            {
                // Cart is empty, display a message or perform any other action
                errorMessageLabel.Text = "Your cart is empty. Add items before proceeding to checkout.";
                errorMessageLabel.Visible = true;
            }
            else
            {
                // Cart is not empty, redirect to Checkout page
                Response.Redirect("Checkout.aspx");
            }
        }


    }
}
