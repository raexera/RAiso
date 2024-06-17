<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="InsertStationeryPage.aspx.cs" Inherits="RAiso.Views.Admin.InsertStationeryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <div class="inputGroup">
            <asp:Label ID="nameLbl" CssClass="inputLbl" runat="server" Text="Name" AssociatedControlID="nameTxt"></asp:Label>
            <asp:TextBox ID="nameTxt" CssClass="inputTxt" runat="server"></asp:TextBox>
        </div>
        <div class="inputGroup">
            <asp:Label ID="priceLbl" CssClass="inputLbl" runat="server" Text="Price" AssociatedControlID="priceTxt"></asp:Label>
            <asp:TextBox ID="priceTxt" CssClass="inputTxt" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <asp:Label ID="errorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Label ID="successMsg" runat="server" Text="Success" ForeColor="Green" Visible="false"></asp:Label>
        <asp:Button ID="insertBtn" CssClass="authBtn" runat="server" Text="Insert" OnClick="insertBtn_Click" />
    </div>
</asp:Content>
