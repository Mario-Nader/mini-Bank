<%@ Page Title="" Language="C#" MasterPageFile="~/mainSite.Master" AutoEventWireup="true" CodeBehind="createAccount.aspx.cs" Inherits="NBE.createAccount" %>
<%@ Register src="Controls/CTRL_addAccount.ascx" tagname="CTRL_addAccount" tagprefix="uc1" %>
<%@ Register src="Controls/MakerMenu.ascx" tagname="MakerMenu" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_menu" runat="server">
    <uc2:MakerMenu ID="MakerMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH_content" runat="server">
    <uc1:CTRL_addAccount ID="CTRL_addAccount1" runat="server" />
</asp:Content>
