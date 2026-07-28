<%@ Page Title="" Language="C#" MasterPageFile="~/mainSite.Master" AutoEventWireup="true" CodeBehind="validateCustomer.aspx.cs" Inherits="NBE.validateCustomer" %>
<%@ Register src="Controls/CTRL_validateCustomer.ascx" tagname="CTRL_validateCustomer" tagprefix="uc1" %>
<%@ Register src="Controls/CTRL_CheckerMenu.ascx" tagname="CTRL_CheckerMenu" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_menu" runat="server">
    <uc2:CTRL_CheckerMenu ID="CTRL_CheckerMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH_content" runat="server">
    <uc1:CTRL_validateCustomer ID="CTRL_validateCustomer1" runat="server" />
</asp:Content>
