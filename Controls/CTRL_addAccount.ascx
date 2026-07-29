<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_addAccount.ascx.cs" Inherits="NBE.Controls.CTRL_addAccount" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style3 {
        width: 302px;
    }
    .auto-style4 {
        width: 319px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style4">National ID
            <asp:TextBox ID="txt_NationalID" runat="server" style="margin-left: 0px"></asp:TextBox>
        </td>
        <td class="auto-style3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2_nationalID" runat="server" ControlToValidate="txt_NationalID" ErrorMessage="Enter the National ID of the customer" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
        <td>Branch:
            <asp:DropDownList ID="DDL_Branch" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_branch" runat="server" ErrorMessage="please select the branch" ControlToValidate="DDL_Branch" InitialValue="" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">Class:
            <asp:DropDownList ID="DDL_Class" runat="server">
            </asp:DropDownList>
        </td>
        <td class="auto-style3">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_class" runat="server" ControlToValidate="DDL_Class" Display="Dynamic" ErrorMessage="please enter the class" InitialValue=""></asp:RequiredFieldValidator>
        </td>
        <td>Currency:
            <asp:DropDownList ID="DDL_currency" runat="server">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator_currency" runat="server" ErrorMessage="please ente the currency of the account" ControlToValidate="DDL_currency" InitialValue=""></asp:RequiredFieldValidator>
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

