<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="NBE.WebForm1" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href ="bootstrap-5.3.8-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src ="bootstrap-5.3.8-dist/js/bootsrap.bundle.min.js"></script>
    <style type="text/css">
        .auto-style2 {
            width: 439px;
        }
        .auto-style3 {
            width: 153px;
        }
        .auto-style4 {
            width: 98px;
        }
        .auto-style5 {
            width: 98px;
            height: 46px;
        }
        .auto-style6 {
            width: 153px;
            height: 46px;
        }
        .auto-style7 {
            width: 439px;
            height: 46px;
        }
        .auto-style8 {
            height: 46px;
        }
    </style>
</head>
<body>
    <div class ="pl-5">
    <form id="form1" runat="server" class="form-group">
        <div>
        </div>
        <table >
            <tr>
                <td class="auto-style5"></td>
                <td class="auto-style6"></td>
                <td class="auto-style7">
                </td>
                <td class="auto-style8">
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">username</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_username" runat="server" OnTextChanged="txt_username_TextChanged" EnableViewState="False" ViewStateMode="Disabled" CssClass="form-control"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID ="rfvUsername" runat ="server" ControlToValidate ="txt_username" ErrorMessage ="username is required" Display ="Dynamic"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">password</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_pwd" runat="server" ViewStateMode="Disabled" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    
                </td>
                <td>
                    <asp:RequiredFieldValidator ID ="rfvPassword" runat ="server" ControlToValidate ="txt_pwd" ErrorMessage ="please enter your password to login" Display ="Dynamic"/>
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btn_submit" runat="server" OnClick="btn_submit_Click" Text="login" CssClass="btn btn-primary" />
                </td>
                <td>
                    <asp:Literal ID="DBliteral" runat="server"></asp:Literal>
                </td>
            </tr>
        </table>
    </form>
</div>
    <p>
        &nbsp;</p>
</body>
</html>
