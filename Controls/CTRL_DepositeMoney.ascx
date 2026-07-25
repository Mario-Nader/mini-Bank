<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_DepositeMoney.ascx.cs" Inherits="NBE.Controls.depositeMoney" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 336px;
    }
    .auto-style3 {
        width: 336px;
        height: 32px;
    }
    .auto-style4 {
        height: 32px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style3">Account Number:
            <asp:TextBox ID="txt_AccountNumber" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style4">Amount :
            <input id="txt_Amount" type="text" /></td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Button ID="Button1" runat="server" Text="Deposite" />
        </td>
        <td>&nbsp;</td>
    </tr>
</table>

