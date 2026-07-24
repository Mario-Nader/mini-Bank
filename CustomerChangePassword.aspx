<%@ Page Title="" Language="C#" MasterPageFile="~/mainSite.Master" AutoEventWireup="true" CodeBehind="CustomerChangePassword.aspx.cs" Inherits="NBE.CustomerChangePassword" %>
<%@ Register src="Controls/ChangePassword.ascx" tagname="ChangePassword" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH_content" runat="server">
    <uc1:ChangePassword ID="ChangePassword1" runat="server" />
</asp:Content>
