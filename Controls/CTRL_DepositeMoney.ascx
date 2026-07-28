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
            <asp:TextBox ID="txt_amount" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_AccountNumber" ErrorMessage="please enter the account number"></asp:RequiredFieldValidator>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_amount" ErrorMessage="please enter the amount"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Button ID="Button1" runat="server" Text="Deposite" OnClick="Button1_Click" />
        </td>
        <td>
            <asp:Literal ID="lit_status" runat="server"></asp:Literal>
        </td>
    </tr>
</table>

