using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Navjotsingh_BookStore
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Perform simple login validation
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();

            if (IsValidUser(firstName, lastName))
            {
                // Store user information in Session
                Session["FirstName"] = firstName;

                // Successful login
                Response.Redirect("Products.aspx");
            }
            else
            {
                // Display an error message or perform other actions for unsuccessful login
                // For simplicity, just displaying an alert in this example
                lblErrorMessage.Text = "Invalid login credentials when Null";
            }
        }

        private bool IsValidUser(string firstName, string lastName)
        {
          
            // For simplicity, this example assumes valid login if both fields are non-empty
            return !string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName);
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
           
            // For simplicity, redirecting to the Default.aspx page
            Response.Redirect("Default.aspx");
        }
    }
}