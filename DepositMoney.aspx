<%@ Page Title="" Language="C#" MasterPageFile="~/mainSite.Master" AutoEventWireup="true" CodeBehind="DepositMoney.aspx.cs" Inherits="NBE.DepositMoney" %>
<%@ Register src="Controls/CTRL_DepositeMoney.ascx" tagname="CTRL_DepositeMoney" tagprefix="uc1" %>
<%@ Register src="Controls/MakerMenu.ascx" tagname="MakerMenu" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_menu" runat="server">
    <uc2:MakerMenu ID="MakerMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH_content" runat="server">
    <uc1:CTRL_DepositeMoney ID="CTRL_DepositeMoney1" runat="server" />
</asp:Content>
