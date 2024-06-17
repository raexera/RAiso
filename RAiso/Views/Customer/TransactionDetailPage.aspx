<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="RAiso.Views.Customer.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="gridView">
            <asp:GridView ID="detailGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="StationeryName" HeaderText="StationeryName" SortExpression="StationeryName" />
                    <asp:BoundField DataField="StationeryPrice" HeaderText="StationeryPrice" SortExpression="StationeryPrice" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
