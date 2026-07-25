<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_transfereMoney.ascx.cs" Inherits="NBE.Controls.CTRL_transfereMoney" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 551px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">Source Account Number
            <asp:TextBox ID="txt_srcAccount" runat="server"></asp:TextBox>
        </td>
        <td>Distnation Account Number&nbsp;
            <asp:TextBox ID="txt_DistAccount" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Amount <asp:TextBox ID="txt_amount" runat="server"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Button ID="btn_submit" runat="server" Text="Transfere" />
        </td>
        <td>
            <asp:Literal ID="lit_state" runat="server"></asp:Literal>
        </td>
    </tr>
</table>

