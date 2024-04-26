<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Navjotsingh_BookStore.Cart" EnableViewState="true"%>
<asp:Content ID="includecss" ContentPlaceHolderID="head" runat="server">
     <link rel="stylesheet" href="css/style.css" />
</asp:Content>

<asp:Content ID="ContentMain" ContentPlaceHolderID="Maincontent" runat="server">
     <div class="container">
<form id="form1" runat="server">
    <div>
        <h1>Shopping Cart</h1>

             <asp:Label ID="errorMessageLabel" runat="server" ForeColor="red" Visible="false"></asp:Label>

        <div id="cartTable" class="cart-table">
           <!-- Table Header -->
    <div class="table-header">
        <div class="cell">Product ID</div>
        <div class="cell">Product Name</div>
        <div class="cell">Quantity</div>
        <div class="cell">Price</div>
        <div class="cell">Total</div>
        <div class="cell"></div> <!-- for Remove button -->
    </div>

    <!-- Cart Items -->
    <asp:Repeater ID="cartRepeater" runat="server">
        <ItemTemplate>
            <div class="table-row">
                <div class="cell"><%# Eval("ProductId") %></div>
                <div class="cell"><%# Eval("ProductName") %></div>
                <div class="cell"><%# Eval("Quantity") %></div>
                <div class="cell"><%# string.Format("{0:C}", Eval("Price")) %></div>
                <div class="cell"><%# string.Format("{0:C}", Convert.ToDouble(Eval("Quantity")) * Convert.ToDouble(Eval("Price"))) %></div>
                <div class="cell">
                    <asp:Button runat="server" CssClass="btn btn-small btn-danger" Text="Remove" OnClick="RemoveItem_Click" CommandArgument='<%# Eval("ProductId") %>' />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

            <!-- Total Amount -->
            <div id="totalAmount" runat="server"></div>
            <hr />
            <!-- Buttons -->
                        <asp:Button ID="backto" runat="server" CssClass="btn btn-secondary" Text="Continue Shopping" OnClick="backto_Click" />
            <asp:Button ID="destroySessionButton" CssClass="btn btn-secondary" runat="server" Text="Empty Cart" OnClick="DestroySessionButton_Click" />
            <asp:Button ID="proceedToCheckoutButton" CssClass="btn btn-success" runat="server" Text="Proceed to Checkout"  OnClick="proceedToCheckoutButton_Click" />
          
        </div>
    </div>
</form>
    </div>
</asp:Content>
