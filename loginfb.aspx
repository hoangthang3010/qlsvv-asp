<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginfb.aspx.cs" Inherits="Doanbaove.loginfb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align:center; margin-top:50px;">
            <asp:Button ID="Button1" runat="server" Text="Xác nhận chuyển trang" OnClick="Button1_Click" PostBackUrl="~/home.aspx" />
        </div>
    </form>
</body>
</html>
