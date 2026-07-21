<%@ Page Title="" Language="C#" MasterPageFile="~/mainSite.Master" AutoEventWireup="true" CodeBehind="makeCustomer.aspx.cs" Inherits="NBE.customer" %>
<%@ Register src="Controls/CreateCustomer.ascx" tagname="CreateCustomer" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_content" runat="server">
    <uc1:CreateCustomer ID="CreateCustomer1" runat="server" />
</asp:Content>
