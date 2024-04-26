<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Navjotsingh_BookStore.WebForm3" %>

<asp:Content ID="ContentMain" ContentPlaceHolderID="Maincontent" runat="server">
    

     <section class="jumbotron text-center">
    <div class="container">
        <h1 class="jumbotron-heading">Introducing Navjot Bookstore</h1>
        <p class="lead text-muted">Discover a world of knowledge and imagination in our extensive collection. Explore our curated selection and find the perfect book for every reader.</p>
        <p>
            <a href="Products.aspx" class="btn btn-primary my-2">Explore Now</a>
            <a href="Cart.aspx" class="btn btn-secondary my-2">Find Cart</a>
        </p>
    </div>
</section>

  
</asp:Content>
