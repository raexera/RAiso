<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="RAiso.Views.Guest.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <h1 class="formTitle">Login</h1>
        <div class="inputGroup">
            <asp:Label ID="nameLbl" CssClass="inputLbl" runat="server" Text="Name" AssociatedControlID="nameTxt"></asp:Label>
            <asp:TextBox ID="nameTxt" CssClass="inputTxt" runat="server"></asp:TextBox>
        </div>
        <div class="inputGroup">
            <asp:Label ID="passwordLbl" CssClass="inputLbl" runat="server" Text="Password" AssociatedControlID="passwordTxt"></asp:Label>
            <asp:TextBox ID="passwordTxt" CssClass="inputTxt" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="inputCB">
            <asp:CheckBox ID="rememberCB" CssClass="inputTxt" runat="server" />
            <asp:Label ID="rememberLbl" CssClass="inputLbl" runat="server" Text="Remember Me" AssociatedControlID="rememberCB"></asp:Label>
        </div>
        <asp:Label ID="loginError" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Button ID="loginBtn" CssClass="authBtn" runat="server" Text="Login" OnClick="loginBtn_Click" />
    </div>
</asp:Content>
