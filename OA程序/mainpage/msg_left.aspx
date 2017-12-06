<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="msg_left.aspx.cs" Inherits="xyoa.mainpage.msg_left" %>

<html>
<head id="Head1" runat="server">
    <title>组织信息</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script>
function openwindows(urlstr)
{
    //控件宽
    var aw = 695;
    //控件高
    var ah = 466;
    //计算控件水平位置
    var al = (screen.width - aw)/2-100;
    //计算控件垂直位置
    var at = (screen.height - ah)/5;
    window.open("/InfoManage/messages/talk.aspx?user="+urlstr+"","_blank","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
}

function openemail(user)
{
    var num=Math.random();
    window.showModalDialog("/InfoManage/nbemail/SeadToUser.aspx?user="+user+"&tmp="+num+"",window,"dialogWidth:780px;DialogHeight=620px;status:no;scroll=yes;help:no")
}

    </script>

</head>
<body background="../oaimg/menuBG.gif" style="overflow: auto">
    <form id="form1" runat="server">
        <div>
            <%=showtitle %>
                              <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>
            <asp:TreeView ID="ListTreeView" runat="server" CollapseImageUrl="~/images/2.gif"
                ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            </asp:TreeView>
                            <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>
        </div>
    </form>
</body>
</html>
