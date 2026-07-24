<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CTRL_CreateCustomer.ascx.cs" Inherits="NBE.Controls.CreateCustomer" %>
    <link href ="bootstrap-5.3.8-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src ="bootstrap-5.3.8-dist/js/bootsrap.bundle.min.js"></script>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 247px;
    }
    .auto-style3 {
        width: 513px;
    }
    .auto-style4 {
        width: 247px;
        height: 29px;
    }
    .auto-style5 {
        width: 513px;
        height: 29px;
    }
    .auto-style6 {
        height: 29px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td style="direction: ltr" class="auto-style3">Register a new customer<br />
        </td>
        <td style="direction: ltr">&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">Full name</td>
        <td class="auto-style5">
            <asp:TextBox ID="txt_name" runat="server"></asp:TextBox>
        </td>
        <td class="auto-style6">
            <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="please enter the full name" ControlToValidate="txt_name" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Address</td>
        <td class="auto-style3">
            <asp:TextBox ID="txt_address" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfv3" runat="server" ControlToValidate="txt_address" ErrorMessage="please enter an Address"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">E-mail</td>
        <td class="auto-style3">
            <asp:TextBox ID="txt_email" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfv4" runat="server" ControlToValidate="txt_email" Display="Dynamic" ErrorMessage="please provide an email"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ErrorMessage="please enter a valid email" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ControlToValidate="txt_email"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Phone number</td>
        <td class="auto-style3">
            <asp:TextBox ID="txt_phone" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfv5" runat="server" ControlToValidate="txt_phone" ErrorMessage="please provid the phone number" Display="Dynamic"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Age</td>
        <td class="auto-style3">
            <asp:TextBox ID="txt_age" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfv6" runat="server" ControlToValidate="txt_age" ErrorMessage="please enter the age" Display="Dynamic"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_age" ErrorMessage="please enter a valid age" MaximumValue="100" MinimumValue="15" Display="Dynamic" Type="Integer"></asp:RangeValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">NationalID</td>
        <td class="auto-style3">
            <asp:TextBox ID="txt_nationalD" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_nationalD" Display="Dynamic" ErrorMessage="please enter your national ID"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Gender</td>
        <td class="auto-style3">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="297px">
                <asp:ListItem Value="m">Male</asp:ListItem>
                <asp:ListItem Value="f">Female</asp:ListItem>
            </asp:RadioButtonList>

        </td>
        <td>
            <asp:RequiredFieldValidator ID="rfv7" runat="server" ControlToValidate="RadioButtonList1" ErrorMessage="please select a gender" Display="Dynamic"></asp:RequiredFieldValidator>

        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style3">
            <asp:Button ID="Submit" runat="server" OnClick="submit_button_clicked" Text="Submit" CssClass="btn btn-primary" />
            <asp:Button ID="clear" runat="server" CausesValidation="False" CssClass="btn btn-secondary" OnClick="clear_button_clicked" Text="Clear" UseSubmitBehavior="False" />
        </td>
        <td>
            <asp:Literal ID="lit_status" runat="server"></asp:Literal>
        </td>
    </tr>
</table>

