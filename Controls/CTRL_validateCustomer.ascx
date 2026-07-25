<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_validateCustomer.ascx.cs" Inherits="NBE.Controls.CTRL_validateCustomer" %>


<p>
    &nbsp;</p>
<p>
    <asp:Literal ID="lit_err" runat="server"></asp:Literal>
</p>



<asp:GridView ID="gv_CustomerRequests" runat="server" AutoGenerateColumns="false" OnRowEditing="onGridEdit" OnRowUpdating ="RowUpdating" OnRowCancelingEdit="cancelEdit" OnRowCommand ="gvRowCommand"  DataKeyNames="custID">
    <Columns>
        <asp:BoundField DataField="custID" HeaderText="Request ID" ReadOnly="true" />
        <asp:BoundField DataField ="Name" HeaderText="Name" ReadOnly ="true"/>
        <asp:BoundField DataField ="age" HeaderText="Age" ReadOnly="true" />
        <asp:BoundField DataField ="address" HeaderText="Address" ReadOnly="true" />
        <asp:BoundField DataField ="nationalID" HeaderText="National ID" ReadOnly="true" />
        <asp:BoundField DataField="makerName" HeaderText="Requesting Maker" ReadOnly ="true" />

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

<asp:TemplateField HeaderText ="Comment">
    <ItemTemplate>
        <asp:TextBox ID="txt_comment" runat="server" CssClass="form-control"></asp:TextBox>
    </ItemTemplate>
</asp:TemplateField>


    </Columns>
</asp:GridView>






