<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_EditAccounts.ascx.cs" Inherits="NBE.Controls.CTRL_EditAccounts" %>
<asp:GridView ID="gvAccountRequests" runat="server"  DataKeyNames="AccID" OnRowDataBound="gvRowDataBound" AutoGenerateColumns="false" OnRowEditing="gvAccountRequests_RowEditing" OnRowCancelingEdit="gvAccountRequests_RowCancelineEdit" OnRowUpdating="gvAccountRequests_RowUpdating">
        <Columns>

<asp:BoundField DataField="AccID" HeaderText="Request ID" ReadOnly="true" />

<%-- customer name --%>
<asp:TemplateField HeaderText ="Customer Name">
    <ItemTemplate>
        <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("CustomerName") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txt_name" runat="server" Text='<%#Bind("CustomerName")%>' cssClass="form-control"></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>

<%-- currency --%>
<asp:TemplateField  HeaderText ="Currency">
    <ItemTemplate>
        <asp:Label ID="lbl_Currency" runat="server" Text='<%# Eval("currency") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
       <%--  <asp:TextBox ID="txt_Currency" runat="server" Text='<%#Bind("currency")%>' cssClass="form-control"></asp:TextBox>--%>
        <asp:DropDownList ID="ddl_currency" runat="server"></asp:DropDownList>
    </EditItemTemplate>
</asp:TemplateField>

<%-- initial amount --%>
<asp:TemplateField  HeaderText ="initial Amount">
    <ItemTemplate>
        <asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("initialAmount") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:TextBox ID="txt_amount" runat="server" Text='<%#Bind("initialAmount")%>' cssClass="form-control"></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>

<%-- branch --%>
<asp:TemplateField  HeaderText ="Branch">
    <ItemTemplate>
        <asp:Label ID="lbl_branch" runat="server" Text='<%#Eval("branch") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:DropDownList ID="ddl_branch" runat="server"></asp:DropDownList>
    </EditItemTemplate>
</asp:TemplateField>

<%-- Account class --%>
<asp:TemplateField  HeaderText ="Account Class">
    <ItemTemplate>
        <asp:Label ID="lbl_class" runat="server" Text='<%# Eval("AccountClass") %>'></asp:Label>
    </ItemTemplate>
    <EditItemTemplate>
        <asp:DropDownList ID="ddl_class" runat="server"></asp:DropDownList>
    </EditItemTemplate>
</asp:TemplateField>

<%-- comment --%>
<asp:TemplateField HeaderText ="Comment">
    <ItemTemplate>
        <asp:TextBox ID="txt_comment" ReadOnly="true" runat="server" Text='<%#Eval("Comment") %>' CssClass="form-control"></asp:TextBox>
    </ItemTemplate>
    <EditItemTemplate>
         <asp:TextBox ID="txt_commentEdited" runat="server" Text='<%#Bind("Comment") %>' CssClass="form-control"></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>

<asp:TemplateField>

    <ItemTemplate>
        <%-- The CommandName must be exactly "Edit" --%>
        <asp:Button ID="btn_edit" runat="server" CommandName="Edit" Text="Edit" CssClass="btn btn-primary" />
    </ItemTemplate>

    <EditItemTemplate>
        <%-- The CommandNames must be exactly "Update" and "Cancel" --%>
        <asp:Button ID="btn_Update" runat="server" CommandName="Update" Text="Send to check" CssClass="btn btn-success" />
        <asp:Button ID="btnCancel" runat="server" CommandName="Cancel" Text="Cancel" CssClass="btn btn-secondary" />
    </EditItemTemplate>

</asp:TemplateField>

    </Columns>
</asp:GridView>
<asp:Literal ID="lit_err" runat="server"></asp:Literal>

