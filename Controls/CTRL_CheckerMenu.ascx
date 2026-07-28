<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_CheckerMenu.ascx.cs" Inherits="NBE.Controls.CTRL_CheckerMenu" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 304px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">
            <asp:HyperLink ID="link_AccReq" runat="server" NavigateUrl="~/ValidateAccounts.aspx">Account Requests</asp:HyperLink>
            <br />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:HyperLink ID="link_CustReq" runat="server" NavigateUrl="~/validateCustomer.aspx">New Customer Requests</asp:HyperLink>
        </td>
    </tr>
</table>

