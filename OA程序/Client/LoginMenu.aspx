<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginMenu.aspx.cs" Inherits="xyoa.Client.LoginMenu" %>
<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/Css/oa.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body background="/oaimg/menuBG.gif">
    <form id="form1" runat="server">
        <table width="200" border="0" cellspacing="0" cellpadding="6" align="center">
            <tr>
                <td align="center">
                    用户名：
                    <asp:TextBox ID="Username" runat="server" CssClass="TextBox" Width="96px"></asp:TextBox><br>
                </td>
            </tr>
            <tr>
                <td align="center">
                    密&nbsp;&nbsp;码：
                    <asp:TextBox ID="Password" runat="server" CssClass="TextBox" Width="96px" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button ID="Button1" runat="server" Text="登 陆" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
