<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="RAiso.Views.HomePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <asp:Button ID="insertBtn" runat="server" Text="Insert Stationery" CssClass="authBtn" OnClick="insertBtn_Click" Visible="false" />
        <div class="gridView">
            <asp:GridView ID="stationeryGV" runat="server" AutoGenerateColumns="False" OnRowDeleting="stationeryGV_RowDeleting" OnRowEditing="stationeryGV_RowEditing" OnSelectedIndexChanged="stationeryGV_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="StationeryName" HeaderText="Name" SortExpression="StationeryName" />
                    <asp:BoundField DataField="StationeryPrice" HeaderText="Price" SortExpression="StationeryPrice" />
                    <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    <asp:CommandField ButtonType="Button" HeaderText="Action" ShowCancelButton="False" ShowDeleteButton="True" ShowEditButton="True" ShowHeader="True" Visible="false" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
