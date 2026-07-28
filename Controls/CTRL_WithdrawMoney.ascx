<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_WithdrawMoney.ascx.cs" Inherits="NBE.Controls.CTRL_WithdrawMoney" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 468px;
    }
    .auto-style3 {
        width: 468px;
        height: 31px;
    }
    .auto-style4 {
        height: 31px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style3">
            <asp:Label ID="lbl_nationalID" runat="server" Text="National ID  "></asp:Label>
            <asp:TextBox ID="txt_nationalID" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style4">
            <asp:Label ID="lbl_accountNumber" runat="server" Text="Account Number  "></asp:Label>
            <asp:TextBox ID="txt_AccountNumber" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Label ID="lbl_amount" runat="server" Text="amount  "></asp:Label>
            <asp:TextBox ID="txt_amount" runat="server"></asp:TextBox>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Button ID="btn_submit" runat="server" Text="Withdraw" OnClick="btn_submit_Click" />
        </td>
        <td>
            <asp:Literal ID="lit_status" runat="server"></asp:Literal>
        </td>
    </tr>
</table>

