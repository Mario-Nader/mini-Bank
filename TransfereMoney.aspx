<%@ Page Title="" Language="C#" MasterPageFile="~/mainSite.Master" AutoEventWireup="true" CodeBehind="TransfereMoney.aspx.cs" Inherits="NBE.TransfereMoney" %>
<%@ Register src="Controls/CTRL_transfereMoney.ascx" tagname="CTRL_transfereMoney" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="CPH_head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPH_menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPH_content" runat="server">
    <uc1:CTRL_transfereMoney ID="CTRL_transfereMoney1" runat="server" />
</asp:Content>
