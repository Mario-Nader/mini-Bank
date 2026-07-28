<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_ValidateAccounts.ascx.cs" Inherits="NBE.Controls.CTRL_ValidateAccounts" %>
<asp:GridView ID="gv_accounts" runat="server"  DataKeyNames="accountID" OnRowCommand ="gvRowCommand">
        <Columns>


<asp:TemplateField HeaderText ="Comment">
    <ItemTemplate>
        <asp:TextBox ID="txt_comment" runat="server" Text='<%#Bind("Comment") %>' CssClass="form-control"></asp:TextBox>
    </ItemTemplate>
</asp:TemplateField>

            <asp:TemplateField>
   <ItemTemplate>
        <asp:Button
            ID="btnApprove"
            runat="server"
            Text="Approve"
            CssClass="btn btn-success"
            CommandName="approveRow"
            CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
    </ItemTemplate>


</asp:TemplateField>

<asp:TemplateField>
   <ItemTemplate>
        <asp:Button
            ID="btnReject"
            runat="server"
            Text="Reject"
            CssClass="btn btn-danger"
            CommandName="rejectRow"
            CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField>
   <ItemTemplate>
        <asp:Button
            ID="btnRequestEdit"
            runat="server"
            Text="Request Edit"
            CssClass="btn btn-warning"
            CommandName="requestEditRow"
            CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" />
    </ItemTemplate>
</asp:TemplateField>

    </Columns>
</asp:GridView>

<asp:Literal ID="lit_status" runat="server"></asp:Literal>


