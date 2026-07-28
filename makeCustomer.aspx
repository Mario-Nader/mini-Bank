<%@ Page Title="" Language="C#" MasterPageFile="~/mainSite.Master" AutoEventWireup="true" CodeBehind="makeCustomer.aspx.cs" Inherits="NBE.customer" %>
<%@ Register src="Controls/CTRL_CreateCustomer.ascx" tagname="CTRL_CreateCustomer" tagprefix="uc1" %>
<%@ Register src="Controls/MakerMenu.ascx" tagname="MakerMenu" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_content" runat="server">
    <uc1:CTRL_CreateCustomer ID="CTRL_CreateCustomer1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="CPH_menu">
    <uc2:MakerMenu ID="MakerMenu1" runat="server" />
</asp:Content>

