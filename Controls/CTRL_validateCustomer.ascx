<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_validateCustomer.ascx.cs" Inherits="NBE.Controls.CTRL_validateCustomer" %>


<p>
    &nbsp;</p>
<p>
    <asp:Literal ID="lit_err" runat="server"></asp:Literal>
</p>



<asp:GridView ID="gv_CustomerRequests" runat="server" OnRowEditing="onGridEdit" OnRowUpdating ="RowUpdating" OnRowCancelingEdit="cancelEdit" OnRowCommand ="gvRowCommand">
    <Columns>
        <asp:BoundField DataField="custID" HeaderText="Request ID" ReadOnly="true" />
        <asp:BoundField DataField ="Name" HeaderText="Name" ReadOnly ="true"/>
        <asp:BoundField DataField ="age" HeaderText="Age" ReadOnly="true" />
        <asp:BoundField DataField ="address" HeaderText="Address" ReadOnly="true" />
        <asp:BoundField DataField ="nationalID" HeaderText="National ID" ReadOnly="true" />
        <asp:BoundField DataField="makerName" HeaderText="Requesting Maker" ReadOnly ="true" />
        <asp:ButtonField HeaderText="" Text="Approve" ButtonType="Button" ControlStyle-CssClass="btn btn-check" CommandName="approveRow" />
        <asp:ButtonField HeaderText="" Text="Reject" ButtonType="Button" ControlStyle-CssClass="btn btn-danger" CommandName="rejectRow" />
        <asp:ButtonField HeaderText="" Text="request Edit" ButtonType="Button" ControlStyle-CssClass="btn btn-warning" CommandName="requestEditRow" />
        <asp:BoundField DataField="comments" HeaderText="Comments" ReadOnly ="false"/>
        <asp:CommandField ShowEditButton="true" EditText="Add Comment"/>


    </Columns>
</asp:GridView>






