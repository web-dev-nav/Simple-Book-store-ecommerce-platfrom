<%@ Page Title="Product page" MasterPageFile="~/Site.Master" Language="C#" AutoEventWireup="True" CodeBehind="Products.aspx.cs" Inherits="Navjotsingh_BookStore.Products" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="Maincontent" runat="server">
  <div class="container">
    <h2>Product Page</h2>
    <% if (Session["FirstName"] != null) { %>
        <h1 class="text-success">Welcome, <%: Session["FirstName"] %></h1>
    <% } %>
    
    <!-- Success message label -->
    <asp:Label ID="successMessageLabel" class="alert alert-success mb-2" style="display:block" runat="server" ForeColor="Green" Visible="false"></asp:Label>

    <!-- Error message label -->
    <asp:Label ID="errorMessageLabel" class="alert alert-danger  mb-2" style="display:block" runat="server" ForeColor="Red" Visible="false"></asp:Label>

    <form id="myForm" runat="server">
        <div class="card">
            <div class="card-header">
                <asp:DropDownList ID="productSelections" runat="server" AutoPostBack="true" OnSelectedIndexChanged="productSelections_SelectedIndexChanged" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="card-body">
                <div class="center-image-container">
                    <asp:Image ID="productIMG" runat="server" AlternateText="Product Image" CssClass="product-image" />
                </div>
                <div class="card-content">
                    <h1><asp:Label ID="productNameLabel" runat="server" /></h1>
                    <p>#<asp:Label ID="productID" runat="server" /></p>
                    <p class="price">$<asp:Label ID="priceLabel" runat="server" /></p>
                    <p><asp:Label ID="descriptionLabel" runat="server" /></p>
                    <div class="quantity-container">
                        <asp:TextBox runat="server" ID="quantityTextBox" Text="1" Min="1" CssClass="form-control quantity-input" />
                    </div>
                    <div class="vertical-buttons mt-2">
                        <asp:Button ID="addToCartButton" runat="server" OnClick="addToCartButton_Click" Text="Add to Cart" CssClass="btn btn-primary go-to-cart-button"/>
                        <asp:Button ID="proceedToCart" runat="server" CssClass="btn btn-secondary go-to-cart-button" OnClick="proceedToCart_Click" Text="Go to Cart"/>
                    </div>
                </div>
            </div>
        </div>
    </form>
  </div>
</asp:Content>


    

