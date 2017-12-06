<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Taolunzu.aspx.cs" Inherits="xyoa.Client.Taolunzu" %>

<html>
<script>

function killErrors() {
return true;
}
window.onerror = killErrors;

function openwindows(urlstr)
{
    //控件宽
    var aw = screen.width-500;
    //控件高
    var ah = screen.height-400;
    //计算控件水平位置
    var al = 10;
    //计算控件垂直位置
    var at = 10;
    window.open("/Client/urlcheck.aspx?url="+urlstr+"&user=<%=Request.QueryString["user"].ToString() %>&pwd=<%=Request.QueryString["pwd"].ToString() %>","_blank","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
}
</script>
<head id="Head1" runat="server">
    <title>讨论组 </title>
        <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
</head>
<body background="../oaimg/menuBG.gif" style="overflow: auto" oncontextmenu="return false">
    <form id="form1" runat="server">
        <table width="100%" height="20" border="0" cellpadding="0" cellspacing="0" class="blueleft">
            <tr>
                <td width="100%" align=right>
                     <a href="javascript:void(0)" title="创建讨论组" onclick="openwindows('/InfoManage/Taolunzu/TaolunzuMy.aspx')"><font class="lefttd"><img src="/oaimg/r/ht_2.gif" border=0 hspace=3>创建</font></a>&nbsp;
                </td>
            </tr>
        </table>
    	<asp:TreeView ID="ListTreeView" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
        </asp:TreeView>
    </form>
</body>
</html>
