<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm7.aspx.cs" Inherits="WebApplication1.WebForm7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        幾歲：
        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
        <asp:DropDownList ID="ddlYearFormat" runat="server">
            <asp:ListItem Value="W">西元年</asp:ListItem>
            <asp:ListItem Value="C">民國元</asp:ListItem>
        </asp:DropDownList>
       
        <asp:Button ID="btnCal" runat="server" Text="計算" OnClick="btnCal_Click" />

         取得：
        <asp:Label ID="lblYear" runat="server" Text=""></asp:Label>年生
    </div>
    </form>
</body>
</html>
