<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Navjotsingh_BookStore.Login" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="Maincontent" runat="server">
   <div class="d-flex align-items-center justify-content-center vh-100">
      
    <form id="form1" runat="server" class="login-card">
        <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
        <div class="mb-3">
            <label for="txtFirstName" class="form-label">First Name:</label>
            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label for="txtLastName" class="form-label">Last Name:</label>
            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-secondary btn-block" />
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" CssClass="btn btn-primary btn-block" />
            </div>

       
    </form>
       </div>
</asp:Content>