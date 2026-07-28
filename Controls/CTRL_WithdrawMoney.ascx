<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_WithdrawMoney.ascx.cs" Inherits="NBE.Controls.CTRL_WithdrawMoney" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style5 {
        width: 304px;
    }
    .auto-style6 {
        width: 217px;
    }
    .auto-style7 {
        width: 217px;
        height: 16px;
    }
    .auto-style8 {
        width: 304px;
        height: 16px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style7">
            <asp:Label ID="lbl_nationalID" runat="server" Text="National ID  "></asp:Label>
            <asp:TextBox ID="txt_nationalID" runat="server" ></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:RequiredFieldValidator ID="rfv_NationalID" runat="server" ControlToValidate="txt_nationalID" ErrorMessage="please enter a national field to get the accounts"></asp:RequiredFieldValidator>
        </td>
        <td class="auto-style8">
            <asp:Label ID="lbl_accountNumber" runat="server" Text="Account Number  "></asp:Label>
            <asp:DropDownList ID="ddl_AccountNumbers" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">
            <asp:Label ID="lbl_amount" runat="server" Text="amount  "></asp:Label>
            <asp:TextBox ID="txt_amount" runat="server"></asp:TextBox>
            <br />
        </td>
        <td class="auto-style5">
            <asp:RequiredFieldValidator ID="rfv_AccountNumber" runat="server" ControlToValidate="ddl_AccountNumbers" Display="Dynamic" ErrorMessage="please select an Account number" InitialValue=""></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">
            <asp:Button ID="btn_submit" runat="server" Text="Withdraw" OnClick="btn_submit_Click" />
        </td>
        <td class="auto-style5">
            <asp:Button ID="get_Accounts" runat="server" OnClick="get_Accounts_Click" style="margin-left: 0px" Text="Get Accounts" />
        </td>
    </tr>
</table>

<p>
            <asp:Literal ID="lit_status" runat="server"></asp:Literal>
        </p>


