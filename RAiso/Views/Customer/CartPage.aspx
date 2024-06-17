<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="RAiso.Views.Customer.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="gridView">
            <asp:GridView ID="cartGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="StationeryName" HeaderText="Name" SortExpression="StationeryName" />
                    <asp:BoundField DataField="StationeryPrice" HeaderText="Price" SortExpression="StationeryPrice" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="updateBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />
                            <asp:Button ID="removeBtn" runat="server" Text="Remove" OnClick="removeBtn_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="checkoutBtn" runat="server" Text="Checkout" CssClass="authBtn" OnClick="checkoutBtn_Click" />
    </div>
</asp:Content>
