<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_addAccount.ascx.cs" Inherits="NBE.Controls.CTRL_addAccount" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style3 {
        width: 265px;
    }
    .auto-style4 {
        width: 264px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style4">&nbsp; CIF :
            <asp:TextBox ID="txt_CIF" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_CIF" ErrorMessage="Enter the CIF of the customer"></asp:RequiredFieldValidator>
        </td>
        <td>Branch:
            <asp:DropDownList ID="DDL_Branch" runat="server">
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">Class:
            <asp:DropDownList ID="DDL_Class" runat="server">
            </asp:DropDownList>
        </td>
        <td class="auto-style3">&nbsp;</td>
        <td>Currency:
            <asp:DropDownList ID="DDL_currency" runat="server">
            </asp:DropDownList>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">Amount :
            <asp:TextBox ID="txt_Amount" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_Amount" ErrorMessage="the inital amount must be entered"></asp:RequiredFieldValidator>
        </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">
            <asp:Button ID="btn_submit" runat="server" Text="Create Account" OnClick="btn_submit_Click" />
        </td>
        <td class="auto-style3">
            &nbsp;</td>
        <td>
            <asp:Literal ID="lit_test" runat="server"></asp:Literal>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>

