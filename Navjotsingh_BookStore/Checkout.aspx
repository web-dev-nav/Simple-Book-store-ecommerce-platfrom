<%@ Page Language="C#"   MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Navjotsingh_BookStore.Checkout" %>
<asp:Content ID="includecss" ContentPlaceHolderID="head" runat="server">
     <style>
     .error-message {
         color: #721c24;
         background-color: #f8d7da;
         border: 1px solid #f5c6cb;
         padding: 8px;
         border-radius: 4px;
         display:block;
         margin-bottom: 10px;
     }

     .error-container {
        color: #721c24;
         display:block;
        margin-top:10px;
         background-color: #f8d7da;
         border-color: #f5c6cb;
         position: relative;
         padding: .75rem 1.25rem;
         margin-bottom: 1rem;
         border: 1px solid transparent;
         border-radius: .25rem;
     }
   
 
 </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="Maincontent" runat="server">
       <form id="checkoutForm" runat="server">
    <div class="container">
        <h2>Checkout</h2>
        <div class="error-container" id="lblErrorMessageContainer" runat="server" Visible="false">
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="error-message-all" Visible="false"></asp:Label>
        </div>

        <h2>Contact Information</h2>
        <div class="form-group">
            <label for="txtEmail">Email Address:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblEmailError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        </div>

        <div class="form-group">
            <label for="txtEmailReentry">Email Re-entry:</label>
            <asp:TextBox ID="txtEmailReentry" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblEmailReentryError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        </div>

        <div class="form-group">
            <label for="txtFirstName">First Name:</label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblFirstNameError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        </div>

        <div class="form-group">
            <label for="txtLastName">Last Name:</label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblLastNameError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        </div>

        <div class="form-group">
            <label for="txtPhoneNumber">Phone Number:</label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" placeholder="xxx-xxx-xxxx"></asp:TextBox>
            <asp:Label ID="lblPhoneNumberError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        </div>

        <h2>Billing Address</h2>
        <div class="form-group">
            <label for="txtAddress">Address:</label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblAddressError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        </div>

        <div class="form-group">
            <label for="txtCity">City:</label>
            <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="lblCityError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        </div>

        <div class="form-group">
            <label for="ddlState">State:</label>
            <asp:DropDownList ID="ddlState" runat="server" CssClass="form-control">
            </asp:DropDownList>
            <asp:Label ID="lblStateError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        </div>

        <div class="form-group">
            <label for="txtZipCode">Zip Code:</label>
            <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control" placeholder="A1A 1A1"></asp:TextBox>
            <asp:Label ID="lblZipCodeError" runat="server" CssClass="error-message" Visible="false"></asp:Label>
        </div>

        <div class="form-group">
            <h2>Optional data</h2>

            <div class="form-check">
                <asp:CheckBox ID="chkNewProducts" runat="server" CssClass="form-check-input" />
                <label class="form-check-label" for="chkNewProducts">New products</label>
            </div>

            <div class="form-check">
                <asp:CheckBox ID="chkNewEditions" runat="server" CssClass="form-check-input" />
                <label class="form-check-label" for="chkNewEditions">New editions</label>
            </div>

            <div class="form-check">
                <asp:CheckBox ID="chkSpecialOffers" runat="server" CssClass="form-check-input" />
                <label class="form-check-label" for="chkSpecialOffers">Special offers</label>
            </div>

            <div class="form-check">
                <asp:CheckBox ID="chkLocalEvents" runat="server" CssClass="form-check-input" />
                <label class="form-check-label" for="chkLocalEvents">Local events</label>
            </div>
        </div>

        <div class="form-group">
            <h4>Please contact me via</h4>

            <div class="form-check">
                <asp:RadioButton ID="radTwitter" runat="server" GroupName="contactMethod" CssClass="form-check-input" />
                <label class="form-check-label" for="radTwitter">Twitter</label>
            </div>

            <div class="form-check">
                <asp:RadioButton ID="radFacebook" runat="server" GroupName="contactMethod" CssClass="form-check-input" />
                <label class="form-check-label" for="radFacebook">Facebook</label>
            </div>

            <div class="form-check">
                <asp:RadioButton ID="radTextMessage" runat="server" GroupName="contactMethod" CssClass="form-check-input" />
                <label class="form-check-label" for="radTextMessage">Text message</label>
            </div>

            <div class="form-check">
                <asp:RadioButton ID="radEmail" runat="server" GroupName="contactMethod" CssClass="form-check-input" />
                <label class="form-check-label" for="radEmail">Email</label>
            </div>
        </div>

        <asp:Button ID="btnGoToCart" runat="server" Text="Go back to Cart" CssClass="btn btn-secondary" OnClick="btnGoToCart_Click" />
        <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" CssClass="btn btn-primary" OnClick="btnPlaceOrder_Click" />
    </div>
</form>
    </asp:Content>


