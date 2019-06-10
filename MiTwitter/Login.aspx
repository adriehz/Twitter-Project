<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style3 {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Image ID="Image1" runat="server" ImageUrl="~/fotos/banner.png" />
    
    </div>
        <p class="auto-style3">
            Login:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p class="auto-style3">
            Password:
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <p class="auto-style3">
            &nbsp;&nbsp;
&nbsp;&nbsp;
            <asp:ImageButton ID="ImageButton1" runat="server" Height="62px" ImageUrl="~/fotos/login.jpg" OnClick="ImageButton1_Click" Width="151px" />
            <asp:ImageButton ID="ImageButton2" runat="server" Height="63px" ImageUrl="~/fotos/register.png" OnClick="ImageButton2_Click" Width="165px" />
        </p>
        <p>
            &nbsp;</p>
        <p>
&nbsp;(Robamos descaradamente las imagenes de Twitter pero se ve bonito.)</p>
        <asp:Image ID="Image2" runat="server" Height="181px" ImageUrl="~/fotos/TwitterFake.php" Width="326px" />
    </form>
</body>
</html>
