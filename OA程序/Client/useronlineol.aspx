<%@ Page Language="C#" AutoEventWireup="true" Codebehind="useronlineol.aspx.cs" Inherits="xyoa.Client.useronlineol" %>

<html>
<head id="Head1" runat="server">
    <title>组织信息 </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">

    <script>
function killErrors() {
return true;
}
window.onerror = killErrors;

function openwindows(urlstr)
{
    //控件宽
    var aw = 695;
    //控件高
    var ah = 530;
    //计算控件水平位置
    var al = (screen.width - aw)/2-100;
    //计算控件垂直位置
    var at = (screen.height - ah)/5;
    window.open("/Client/urlcheck.aspx?url="+urlstr+"&user=<%=Request.QueryString["user"].ToString() %>&pwd=<%=Request.QueryString["pwd"].ToString() %>","openuser","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
}


function openwindowsemail(urlstr)
{
    //控件宽
    var aw = 830;
    //控件高
    var ah = 600;
    //计算控件水平位置
    var al = (screen.width - aw)/2-100;
    //计算控件垂直位置
    var at = (screen.height - ah)/5;
    window.open("/Client/urlcheck.aspx?url="+urlstr+"&user=<%=Request.QueryString["user"].ToString() %>&pwd=<%=Request.QueryString["pwd"].ToString() %>","openuser","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
}
    </script>

</head>
<body background="../oaimg/menuBG.gif" style="overflow: auto" oncontextmenu="return false">
    <form id="form1" runat="server">
        <table width="100%" height="20" border="0" cellpadding="0" cellspacing="0" class="blueleft">
            <tr>
                <td width="100%"  align=center>
                    <a href="useronline.aspx?user=<%=Request.QueryString["user"].ToString() %>&pwd=<%=Request.QueryString["pwd"].ToString() %>"
                        title="点击刷新"><font class="lefttd">【全部人员】</font></a> <a href="useronlineol.aspx?user=<%=Request.QueryString["user"].ToString() %>&pwd=<%=Request.QueryString["pwd"].ToString() %>"
                            title="点击刷新"><font class="lefttd">【在线人员】</font></a>
                </td>
            </tr>
        </table>
        <div>
            <asp:Label ID="showtitle" runat="server"></asp:Label>
            <asp:TreeView ID="ListTreeView" runat="server" CollapseImageUrl="~/images/2.gif"
                ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            </asp:TreeView>
        </div>
    </form>
</body>
</html>
