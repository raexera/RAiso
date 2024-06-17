<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="StationeryDetailPage.aspx.cs" Inherits="RAiso.Views.StationeryDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <div class="cardData">
            <asp:Label ID="nameLbl" runat="server" Text="Product Name: "></asp:Label>
            <asp:Label ID="nameTxt" CssClass="cardTxt" runat="server" Text=""></asp:Label>
        </div>
        <div class="cardData">
            <asp:Label ID="priceLbl" runat="server" Text="Product Price: "></asp:Label>
            <asp:Label ID="priceTxt" CssClass="cardTxt" runat="server" Text=""></asp:Label>
        </div>
        <asp:Label ID="errorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Label ID="successMsg" runat="server" Text="Success" ForeColor="Green" Visible="false"></asp:Label>
        <asp:TextBox ID="quantityTxt" CssClass="inputTxt" runat="server" TextMode="Number"></asp:TextBox>
        <asp:Button ID="addToCartBtn" runat="server" Text="Add To Cart" CssClass="authBtn" OnClick="addToCartBtn_Click" />
    </div>
</asp:Content>
