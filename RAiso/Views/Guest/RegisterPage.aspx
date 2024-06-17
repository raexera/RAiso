<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="RAiso.Views.Guest.RegisterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form">
        <h1 class="formTitle">Register</h1>
        <div class="inputGroup">
            <asp:Label ID="nameLbl" CssClass="inputLbl" runat="server" Text="Name" AssociatedControlID="nameTxt"></asp:Label>
            <asp:TextBox ID="nameTxt" CssClass="inputTxt" runat="server"></asp:TextBox>
        </div>
        <div class="inputGroup">
            <asp:Label ID="dobLbl" CssClass="inputLbl" runat="server" Text="Date of Birth"></asp:Label>
            <asp:TextBox ID="dobTxt" CssClass="inputTxt" runat="server" TextMode="date"></asp:TextBox>
        </div>
        <div class="inputGroup">
            <asp:Label ID="gender" CssClass="inputLbl" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButton ID="male" CssClass="maleBtn" runat="server" Text="Male" GroupName="gender" />
            <asp:RadioButton ID="female" CssClass="femaleBtn" runat="server" Text="Female" GroupName="gender" />
        </div>
        <div class="inputGroup">
            <asp:Label ID="addressLbl" CssClass="inputLbl" runat="server" Text="Address" AssociatedControlID="addressTxt"></asp:Label>
            <asp:TextBox ID="addressTxt" CssClass="inputTxt" runat="server"></asp:TextBox>
        </div>
        <div class="inputGroup">
            <asp:Label ID="passwordLbl" CssClass="inputLbl" runat="server" Text="Password" AssociatedControlID="passwordTxt"></asp:Label>
            <asp:TextBox ID="passwordTxt" CssClass="inputTxt" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div class="inputGroup">
            <asp:Label ID="phoneLbl" CssClass="inputLbl" runat="server" Text="Phone" AssociatedControlID="phoneTxt"></asp:Label>
            <asp:TextBox ID="phoneTxt" CssClass="inputTxt" runat="server"></asp:TextBox>
        </div>
        <asp:Label ID="registerError" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Button ID="registerBtn" CssClass="authBtn" runat="server" Text="Register" OnClick="registerBtn_Click" />
    </div>
</asp:Content>
