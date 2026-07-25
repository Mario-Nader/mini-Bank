<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.ascx.cs" Inherits="NBE.Controls.ChangePassword" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 173px;
    }
    .auto-style3 {
        width: 268px;
    }
    .auto-style4 {
        width: 173px;
        height: 29px;
    }
    .auto-style5 {
        width: 268px;
        height: 29px;
    }
    .auto-style6 {
        height: 29px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style4">your new Password :</td>
        <td class="auto-style5">
            <asp:TextBox ID="txt_NewPassword" runat="server" TextMode="Password"></asp:TextBox>
        </td>
        <td class="auto-style6"></td>
    </tr>
    <tr>
        <td class="auto-style2">Retype :</td>
        <td class="auto-style3">
            <asp:TextBox ID="txt_passwordConfirmation" runat="server" TextMode ="Password"></asp:TextBox>
        </td>
        <td>
            <asp:CompareValidator ID="CP_passwordConfirmation"  runat="server" ControlToCompare="txt_NewPassword" ControlToValidate="txt_passwordConfirmation" Display="Dynamic" ErrorMessage="Password conirmation doesn't match"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">
            <asp:Button ID="btn_submitPWD" runat="server" OnClick="btn_submitPWD_Click" Text="Submit" />
        </td>
        <td>
            <asp:Literal ID="lit_err" runat="server"></asp:Literal>
        </td>
    </tr>
</table>

