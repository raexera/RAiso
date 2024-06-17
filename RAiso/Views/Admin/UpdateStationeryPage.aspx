<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateStationeryPage.aspx.cs" Inherits="RAiso.Views.Admin.UpdateStationeryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <div class="inputGroup">
            <asp:Label ID="nameLbl" CssClass="inputLbl" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="nameTxt" CssClass="inputTxt" runat="server"></asp:TextBox>
        </div>
        <div class="inputGroup">
            <asp:Label ID="priceLbl" CssClass="inputLbl" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="priceTxt" CssClass="inputTxt" runat="server" TextMode="Number"></asp:TextBox>
        </div>
        <asp:Label ID="errorMsg" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Button ID="updateBtn" CssClass="authBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />
    </div>
</asp:Content>
