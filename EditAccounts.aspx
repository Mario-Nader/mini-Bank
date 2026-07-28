<%@ Page Title="" Language="C#" MasterPageFile="~/mainSite.Master" AutoEventWireup="true" CodeBehind="EditAccounts.aspx.cs" Inherits="NBE.EditAccounts" %>
<%@ Register src="Controls/MakerMenu.ascx" tagname="MakerMenu" tagprefix="uc1" %>
<%@ Register src="Controls/CTRL_EditAccounts.ascx" tagname="CTRL_EditAccounts" tagprefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_menu" runat="server">
    <uc1:MakerMenu ID="MakerMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH_content" runat="server">
    <uc2:CTRL_EditAccounts ID="CTRL_EditAccounts1" runat="server" />
</asp:Content>
