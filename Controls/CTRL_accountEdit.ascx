<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_accountEdit.ascx.cs" Inherits="NBE.Controls.CTRL_accountEdit" %>
<asp:GridView ID="gv_AccountRequests" runat="server" AutoGenerateColumns="false" OnRowEditing="gvCustomerRequests_RowEditing" OnRowUpdating ="gvCustomerRequests_RowUpdating" OnRowCancelingEdit="gvCustomerRequests_RowCancelineEdit"   DataKeyNames="AccID" Width="1530px">
    <Columns>
        <asp:BoundField DataField="AccID" HeaderText="Request ID" ReadOnly="true" />

        <asp:TemplateField HeaderText ="Customer Name">
            <ItemTemplate>
                <asp:Label ID="lbl_Name" runat="server" Text='<%# Eval("CustomerName") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txt_name" runat="server" Text='<%#Bind("CustomerName")%>' cssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText ="class">
            <ItemTemplate>
                <asp:Label ID="lbl_class" runat="server" Text='<%# Eval("class") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txt_class" runat="server" Text='<%#Bind("class")%>' cssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText ="class">
            <ItemTemplate>
                <asp:Label ID="lbl_class" runat="server" Text='<%# Eval("class") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddl_class" runat="server" Text='<%#Bind("class")%>'></asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>

         <asp:TemplateField HeaderText ="currency">
            <ItemTemplate>
                <asp:Label ID="lbl_currency" runat="server" Text='<%# Eval("currency") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:DropDownList ID="ddl_currency" runat="server" Text='<%#Bind("currency")%>'></asp:DropDownList>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText ="currency">
            <ItemTemplate>
                <asp:Label ID="lbl_currency" runat="server" Text='<%# Eval("currency") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txt_currency" runat="server" Text='<%#Bind("currency")%>' cssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText ="Initial Amount">
            <ItemTemplate>
                <asp:Label ID="lbl_amount" runat="server" Text='<%# Eval("amount") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txt_amount" runat="server" Text='<%#Bind("amount")%>' cssClass="form-control"></asp:TextBox>
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText ="Comment">
            <ItemTemplate>
                <asp:Label ID="lbl_comment" runat="server" Text='<%# Eval("Comment") %>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txt_comment" runat="server" Text='<%#Bind("Comment")%>' cssClass="form-control"></asp:TextBox>
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
