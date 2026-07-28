<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="NBE.WebForm1" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href ="bootstrap-5.3.8-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src ="bootstrap-5.3.8-dist/js/bootsrap.bundle.min.js"></script>
    <style type="text/css">
        html,
body{
    margin:0;
    padding:0;
    height:100%;
    font-family:"Segoe UI",Tahoma,sans-serif;

    background:
        linear-gradient(
            135deg,
            #0b3d2e 0%,
            #14513d 60%,
            #0b3d2e 100%);

    display:flex;
    justify-content:center;
    align-items:center;
}

form{
    width:100%;
}

.login-card{

    width:650px;

    background:white;

    border-radius:18px;

    padding:45px;

    box-shadow:
        0 18px 45px rgba(0,0,0,.18);

    border-top:6px solid #c9a227;

    border-collapse:separate;
    border-spacing:0 18px;
}

.login-card td{

    padding:8px 12px;
    vertical-align:middle;
}

.login-card td:nth-child(2){

    font-weight:600;

    color:#0f3d2e;

    width:150px;

    font-size:16px;
}

#txt_username,
#txt_pwd{

    width:100%;

    padding:12px 16px;

    border:1px solid #d8d8d8;

    border-radius:8px;

    transition:.25s;

    font-size:15px;

    box-sizing:border-box;
}

#txt_username:focus,
#txt_pwd:focus{

    outline:none;

    border-color:#c9a227;

    box-shadow:
        0 0 0 3px rgba(201,162,39,.18);
}

.login-btn{

    width:100%;

    background:#0f3d2e;

    color:white;

    border:none;

    border-radius:8px;

    padding:13px;

    font-size:16px;

    font-weight:600;

    transition:.25s;

    cursor:pointer;
}

.login-btn:hover{

    background:#166047;
}

.login-btn:active{

    transform:scale(.98);
}

span[id*=rfv]{

    color:#c62828;

    font-size:13px;

    font-weight:600;
}

#DBliteral{

    display:block;

    margin-top:10px;

    color:#0f3d2e;

    font-weight:600;
}
.login-header{
    text-align:center;
    margin-bottom:30px;
}

.login-logo{
    width:90px;
    height:90px;
    border-radius:16px;
    background:white;
    padding:8px;
    box-shadow:0 8px 20px rgba(0,0,0,.15);
}

.login-header h1{
    margin:18px 0 6px;
    color:white;
    font-size:34px;
    font-weight:700;
}

.login-header p{
    margin:0;
    color:#d4af37;
    font-size:18px;
}
form{
    width:100%;
    max-width:700px;
}
.login-card{
    animation:fadeIn .6s ease;
}

@keyframes fadeIn{

    from{
        opacity:0;
        transform:translateY(25px);
    }

    to{
        opacity:1;
        transform:translateY(0);
    }
}
    </style>
</head>
<body>
    <div>
    <form id="form1" runat="server" class="form-group">
        <div>
        </div>
        <div class="login-header">
    <img src="src/images/NBELogo.jpeg" class="login-logo" />
    <h1>National Bank of Egypt</h1>
    <p>Secure Banking Portal</p>
</div>
        <table class="login-card">
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
                    <asp:TextBox ID="txt_username" runat="server" OnTextChanged="txt_username_TextChanged" EnableViewState="False" ViewStateMode="Disabled" ></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID ="rfvUsername" runat ="server" ControlToValidate ="txt_username" ErrorMessage ="username is required" Display ="Dynamic"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">password</td>
                <td class="auto-style2">
                    <asp:TextBox ID="txt_pwd" runat="server" ViewStateMode="Disabled" TextMode="Password" ></asp:TextBox>
                    
                </td>
                <td>
                    <asp:RequiredFieldValidator ID ="rfvPassword" runat ="server" ControlToValidate ="txt_pwd" ErrorMessage ="please enter your password to login" Display ="Dynamic"/>
                    
                </td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style3">&nbsp;</td>
                <td class="auto-style2">
                    <asp:Button ID="btn_submit" CssClass="login-btn" runat="server" OnClick="btn_submit_Click" Text="login"  />
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
