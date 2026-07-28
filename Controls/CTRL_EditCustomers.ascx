<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_EditCustomers.ascx.cs" Inherits="NBE.Controls.CTRL_EditCustomers" %>
<asp:GridView ID="gv_CustomerRequests" runat="server" AutoGenerateColumns="false" OnRowEditing="gvCustomerRequests_RowEditing" OnRowUpdating ="gvCustomerRequests_RowUpdating" OnRowCancelingEdit="gvCustomerRequests_RowCancelineEdit"   DataKeyNames="custID">
    <Columns>
        <asp:BoundField DataField="custID" HeaderText="Request ID" ReadOnly="true" />

        <asp:TemplateField HeaderText ="Name">
            <ItemTemplate>
                <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txt_name" runat="server" Text='<%#Bind("Name")%>' cssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText ="Age">
            <ItemTemplate>
                <asp:Label ID="lbl_age" runat="server" Text='<%# Eval("age") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txt_age" runat="server" Text='<%#Bind("age")%>' cssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText ="Address">
            <ItemTemplate>
                <asp:Label ID="lbl_address" runat="server" Text='<%# Eval("address") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txt_address" runat="server" Text='<%#Bind("address")%>' cssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText ="National ID">
            <ItemTemplate>
                <asp:Label ID="lbl_nationalID" runat="server" Text='<%# Eval("nationalID") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txt_nationalID" runat="server" Text='<%#Bind("nationalID")%>' cssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText ="Comment">
            <ItemTemplate>
                <asp:Label ID="lbl_comment" runat="server" Text='<%# Eval("comments") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txt_comment" runat="server" Text='<%#Bind("comments")%>' cssClass="form-control"></asp:TextBox>
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
<asp:Literal ID="lit_status" runat="server"></asp:Literal>
