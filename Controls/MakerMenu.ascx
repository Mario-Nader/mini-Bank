<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MakerMenu.ascx.cs" Inherits="NBE.Controls.MakerMenu" %>
<style type="text/css">
/*==============================
        MAKER MENU
==============================*/

.maker-menu{

    display:flex;

    flex-direction:column;

    gap:10px;
}

.maker-menu a{

    display:block;

    text-decoration:none;

    color:var(--green);

    padding:12px 16px;

    border-radius:10px;

    font-weight:600;

    transition:.25s;

    border-left:4px solid transparent;
}

.maker-menu a:hover{

    background:#EEF4F1;

    border-left:4px solid var(--gold);

    color:var(--green-light);

    transform:translateX(4px);
}

.maker-menu a.active{

    background:var(--green);

    color:white;

    border-left:4px solid var(--gold);
}
</style>

<div class="maker-menu">

    <asp:HyperLink ID="link_createAccount"
        runat="server"
        NavigateUrl="~/createAccount.aspx">
        Create Accounts
    </asp:HyperLink>

    <asp:HyperLink ID="link_createCustomer"
        runat="server"
        NavigateUrl="~/makeCustomer.aspx">
        Create Customer
    </asp:HyperLink>

    <asp:HyperLink ID="link_withdraw"
        runat="server"
        NavigateUrl="~/WithdrawMoney.aspx">
        Withdraw Money
    </asp:HyperLink>

    <asp:HyperLink ID="link_deposite"
        runat="server"
        NavigateUrl="~/DepositMoney.aspx">
        Deposit Money
    </asp:HyperLink>

    <asp:HyperLink ID="link_EditedAccounts"
        runat="server"
        NavigateUrl="~/EditAccounts.aspx">
        Account Requests
    </asp:HyperLink>

    <asp:HyperLink ID="link_CustEdit"
        runat="server"
        NavigateUrl="~/EditCustomers.aspx">
        Customer Requests
    </asp:HyperLink>

</div>

