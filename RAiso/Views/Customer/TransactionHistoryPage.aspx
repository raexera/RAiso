<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="RAiso.Views.Customer.TransactionHistoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="content">
        <div class="gridView">
            <asp:GridView ID="transactionGV" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" SortExpression="TransactionID" />
                    <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" SortExpression="TransactionDate" />
                    <asp:BoundField DataField="UserName" HeaderText="Name" SortExpression="UserName" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="viewDetailBtn" runat="server" Text="View Detail" OnClick="viewDetailBtn_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
