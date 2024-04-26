using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;

namespace Navjotsingh_BookStore
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate the state dropdownlist
                ddlState.Items.Add(new ListItem("Select State", ""));
                ddlState.Items.Add(new ListItem("Canada", "Canada"));
                ddlState.Items.Add(new ListItem("USA", "USA"));
                
            }
        }

        protected void btnGoToCart_Click(object sender, EventArgs e)
        {
            // Redirect to Cart.aspx when "Go back to Cart" button is clicked
            Response.Redirect("Cart.aspx");
        }

        protected void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            // Validate and process the form data
            if (ValidateForm())
            {
                // Clear all keys in the session
                Session.Clear();

                // Abandon the session, which removes all session data
                Session.Abandon();

                Response.Redirect("./confirm.aspx");
            }
        }

        private bool ValidateForm()
        {
            // Reset error labels
            ResetErrorLabels();

                bool isValid = true;
                List<string> errorMessages = new List<string>();
            // Validate email
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text))
                {
                errorMessages.Add("Email");
                lblEmailError.Text = "Invalid email format";
                    lblEmailError.Visible = true;
                    isValid = false;
                }

                // Validate email re-entry
                if (string.IsNullOrWhiteSpace(txtEmailReentry.Text) || txtEmail.Text != txtEmailReentry.Text)
                {
                errorMessages.Add("Email-retry");
                lblEmailReentryError.Text = "Emails do not match";
                    lblEmailReentryError.Visible = true;
                    isValid = false;
                }

                // Validate first name
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) || !IsValidFirstName(txtFirstName.Text))
                {
                errorMessages.Add("Firstname");
                lblFirstNameError.Text = "First Name is required and should contain only letters";
                    lblFirstNameError.Visible = true;
                    isValid = false;
                }

                // Validate last name
                if (string.IsNullOrWhiteSpace(txtLastName.Text) || !IsValidLastName(txtLastName.Text))
                {
                errorMessages.Add("LastName");
                lblLastNameError.Text = "Last Name is required and should contain only letters";
                    lblLastNameError.Visible = true;
                    isValid = false;
                }

                // Validate phone number
                if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text) || !IsValidPhoneNumber(txtPhoneNumber.Text))
                {
                errorMessages.Add("Phone");
                lblPhoneNumberError.Text = "Phone Number is required and should be in the format xxx-xxx-xxxx";
                    lblPhoneNumberError.Visible = true;
                    isValid = false;
                }

            // Validate address
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
                {
                errorMessages.Add("Address");
                lblAddressError.Text = "Address is required";
                    lblAddressError.Visible = true;
                    isValid = false;
                }

                // Validate city
                if (string.IsNullOrWhiteSpace(txtCity.Text))
                {

                errorMessages.Add("City");
                lblCityError.Text = "City is required";
                    lblCityError.Visible = true;
                    isValid = false;
                }

                // Validate state
                if (ddlState.SelectedIndex == 0) // Assuming "Select State" is the first item
                {
                errorMessages.Add("State");
                lblStateError.Text = "Please select a State";
                    lblStateError.Visible = true;
                    isValid = false;
                }

            // Validate zip code
            if (string.IsNullOrWhiteSpace(txtZipCode.Text) || (!IsValidCanadianPostalCode(txtZipCode.Text) && !IsValidCanadianPostalCode(txtZipCode.Text)))
            {
                errorMessages.Add("Zip Code");
                lblZipCodeError.Text = "Invalid ZIP Code. Please enter a valid US or Canadian ZIP Code. ex: A1A 1A1";
                lblZipCodeError.Visible = true;
                isValid = false;
            }

            // Display error messages
            if (!isValid)
            {
                lblErrorMessage.Text = "Please correct these entries:<br />";
                lblErrorMessage.Text += string.Join("<br />", errorMessages);
                lblErrorMessage.Visible = true;
                lblErrorMessageContainer.Visible = true;
            }

            return isValid;
           
        }



        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidFirstName(string firstName)
        {
            // Allow only alphabetical characters and spaces
            return !string.IsNullOrWhiteSpace(firstName) && firstName.All(char.IsLetter);
        }

        private bool IsValidLastName(string lastName)
        {
            // Allow only alphabetical characters and spaces
            return !string.IsNullOrWhiteSpace(lastName) && lastName.All(char.IsLetter);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Check if the phone number is in the format xxx-xxx-xxxx
            return Regex.IsMatch(phoneNumber, @"^\d{3}-\d{3}-\d{4}$");
        }

        private bool IsValidCanadianPostalCode(string postalCode)
        {
            // Check if the postal code is in the format "A1A 1A1"
            return Regex.IsMatch(postalCode, @"^[A-Za-z]\d[A-Za-z] \d[A-Za-z]\d$");
        }

        private void ResetErrorLabels()
        {
            lblEmailError.Visible = false;
            lblEmailReentryError.Visible = false;
            lblFirstNameError.Visible = false;
            lblLastNameError.Visible = false;
            lblPhoneNumberError.Visible = false;
            lblAddressError.Visible = false;
            lblCityError.Visible = false;
            lblStateError.Visible = false;
            lblZipCodeError.Visible = false;
        }
    }
}
