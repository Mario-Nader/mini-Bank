<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MakerMenu.ascx.cs" Inherits="NBE.Controls.MakerMenu" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
</style>

<table class="auto-style1">
    <tr>
        <td>
            <asp:HyperLink ID="link_createAccount" runat="server" NavigateUrl="~/createAccount.aspx" Target="_self">Create Accounts</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="link_createCustomer" runat="server" NavigateUrl="~/makeCustomer.aspx">Create customer</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="link_withdraw" runat="server" NavigateUrl="~/WithdrawMoney.aspx">withdraw money</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="link_deposite" runat="server" NavigateUrl="~/DepositMoney.aspx">Deposit money</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="link_EditedAccounts" runat="server" NavigateUrl="~/EditAccounts.aspx">Accounts Edit Requests</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td>
            <asp:HyperLink ID="link_CustEdit" runat="server" NavigateUrl="~/EditCustomers.aspx">Customer Edit Requests</asp:HyperLink>
        </td>
    </tr>
</table>

