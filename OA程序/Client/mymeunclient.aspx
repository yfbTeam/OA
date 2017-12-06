<%@ Page Language="C#" AutoEventWireup="true" Codebehind="mymeunclient.aspx.cs" Inherits="xyoa.Client.mymeunclient" %>

<html>
<script>

function killErrors() {
return true;
}
window.onerror = killErrors;

function openwindows(urlstr)
{
//    //控件宽
//    var aw = 990;
//    //控件高
//    var ah = 680;
    //控件宽
    var aw = screen.width-100;
    //控件高
    var ah = screen.height-100;
    //计算控件水平位置
    var al = 10;
    //计算控件垂直位置
    var at = 10;
    window.open("/Client/urlcheck.aspx?url="+urlstr+"&user=<%=Request.QueryString["user"].ToString() %>&pwd=<%=Request.QueryString["pwd"].ToString() %>","clientopen","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes,scrollbars=yes");
}
</script>
<head id="Head1" runat="server">
    <title>我的快捷菜单 </title>
        <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
</head>
<body background="../oaimg/menuBG.gif" style="overflow: auto" oncontextmenu="return false">
    <form id="form1" runat="server">
        <table width="100%" height="20" border="0" cellpadding="0" cellspacing="0" class="blueleft">
            <tr>
                <td width="30%" align="right" valign="top">
                    <img src="/oaimg/menu/Choose32.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="mymeunclient.aspx?user=<%=Request.QueryString["user"].ToString() %>&pwd=<%=Request.QueryString["pwd"].ToString() %>"
                        title="点击刷新"><font class="lefttd">我的快捷菜单</font></a></td>
            </tr>
        </table>
        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
        </asp:TreeView>
    </form>
</body>
</html>
