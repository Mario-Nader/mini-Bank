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
        <td class="auto-style2">source Account Data</td>
        <td>Distenation Account Data</td>
    </tr>
    <tr>
        <td class="auto-style2">Source Account Number&nbsp;
            <asp:DropDownList AutoPostBack="true" ID="ddl_srcAccount" runat="server" OnSelectedIndexChanged="ddl_srcAccount_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="rfv_srcAccNumber" InitialValue="" runat="server" ControlToValidate="ddl_srcAccount" ErrorMessage="please select an account"></asp:RequiredFieldValidator>
        </td>
        <td>&nbsp;Account Number&nbsp;
            <asp:TextBox ID="txt_DistAccount" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfv_distAccNumber" runat="server" ControlToValidate="txt_DistAccount" ErrorMessage="please enter the Distenation account number"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Balance <asp:TextBox ID="txt_balance" runat="server" ReadOnly="true"></asp:TextBox>
        </td>
        <td>Owner Name <asp:TextBox ID="txt_ownerName" runat="server" ReadOnly ="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            Amount <asp:TextBox ID="txt_amount" runat="server"></asp:TextBox>
        </td>
        <td>
            Currency
            <asp:TextBox ID="txt_distCurr" runat="server" ReadOnly="true"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            Currency&nbsp; <asp:TextBox ID="txt_srcCurr" runat="server" ReadOnly="true"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Button ID="btn_submit" runat="server" Text="Transfere" OnClick="btn_submit_Click" />
        </td>
        <td>
            <asp:Button ID="check_distAcc" runat="server" Text="Check Distenation Account" OnClick="check_distAcc_Click" CausesValidation="False" />
        </td>
    </tr>
    <tr>
        <td class="auto-style2">
            <asp:Literal ID="lit_state" runat="server"></asp:Literal>
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>

