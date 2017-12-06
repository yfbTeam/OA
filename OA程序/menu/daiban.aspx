<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="daiban.aspx.cs" Inherits="xyoa.menu.daiban" %>
<html>
<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
</head>
<body background="../oaimg/menuBG.gif" style="overflow:auto">
    <form id="form1" runat="server">
        <table width="100%" height="20" border="0" cellpadding="0" cellspacing="0" class="blueleft">
            <tr>
                <td width="30%" align="right" valign="top">
                    <img src="../oaimg/menu/Menu8.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="daiban.aspx"><font class="lefttd">待办事宜</font></a></td>
            </tr>
        </table>
               <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>
        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
        </asp:TreeView>
                <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
