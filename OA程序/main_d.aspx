<%@ Page Language="C#" AutoEventWireup="true" Codebehind="main_d.aspx.cs" Inherits="xyoa.main_d" %>

<html>

<script>
function _del(a)
{
    msg="确认在工作台不显示此模块吗?";
    if(window.confirm(msg))
    {
    
      window.open ("main_d_del.aspx?id="+a+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
    }
}

function _update(a)
{           
     var aw = 380;
     var ah = 130;
     var al = (screen.width - aw)/2-100;
     var at = (screen.height - ah)/5+200;
     window.open ("main_d_update.aspx?id="+a+"", "_blank", "height=130, width=380,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no,top="+at+",left="+al+"")
}



function opendr()
{
    var num=Math.random();
    window.showModalDialog("Client/UserInfo_pm.aspx?tmp="+num+"",window,"dialogWidth:680px;DialogHeight=520px;status:no;scroll=yes;help:no")
}
function showfrom1(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/HumanResources/Employee/YuangongLL/YuangongLL_show.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function showfrom2(str)
{
    var num=Math.random();
    var k=window.showModalDialog("/HumanResources/Employee/YuangongGH/YuangongGH_show1.aspx?tmp="+num+"&id="+str+"",window,"dialogWidth:850px;DialogHeight=650px;status:no;scroll=yes;help:no")
}
</script>

<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
    <link href="/flowcss/oa.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/js/main.js" type="text/javascript"></script>

    <style type="text/css">   
       
        .rollBox
        {
            width: 100%;
            margin-left: 2px;
            margin-right: 2px;
            overflow: hidden;
        }

        .rollBox .Cont
        {
            position: relative;
            width: 99%;
            float: left;
            overflow: hidden;
            margin-left: 5px;
            margin-right: 100px;
        }
        .rollBox .ScrCont
        {
            width: 10000000px;
        }
        .rollBox .Cont .pic
        {
            width: 100px;
            float:left;
            text-align: center;
        }
        .rollBox .Cont .pic img
        {
            background: #fff;
            border: 0px solid #ccc;
            display: block;
            margin: 5px 10px;
            height: 65px;
            width: 65px;
        }
        .rollBox .Cont a:link, .rollBox .Cont a:visited
        {
            color: #626466;
            text-decoration: none;
        }
        .rollBox .Cont a:hover
        {
            color: #f00;
            text-decoration: underline;
        }
        .rollBox #List1, .rollBox #List2
        {
            float: left;
        }
    
    </style>
</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <asp:TextBox ID="Tupian" runat="server" Style="display: none"></asp:TextBox>
                    <asp:Label ID="Label" runat="server"></asp:Label>
                </td>
                <td width="258" align="right" valign="top">
                    <table width="100%" height="13" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="247" height="300" border="0" cellpadding="0" cellspacing="1" class="maincss">
                        <tr>
                            <td height="100%" align="center" valign="top" bgcolor="#FFFFFF">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="25" class="mainbody1" height="25" align="center">
                                            <img src="oaimg/menu/K5.gif" /></td>
                                        <td width="200" class="mainbody1" height="25">
                                            <a href="/Client/UserInfo.aspx?user=<%=Session["username"] %>" target='rform' class="MainLine">
                                                <strong>用户信息</strong></a></td>
                                    </tr>
                                </table>
                                <table width="90%" border="0" cellspacing="0" cellpadding="4">
                                    <tr>
                                        <td>
                                            欢迎您：<a href="/Client/UserInfo.aspx?user=<%=Session["username"] %>"><%=Session["realname"] %></a>&nbsp;&nbsp;&nbsp;部门：<%=ViewState["BuMen"] %></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            知识堂：<a href="InfoManage/zhiao/zhishitang.aspx"><%=ViewState["zhishitang"] %></a></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            在线排名：<%=ViewState["count"] %>，【<a href="javascript:void(0)" onclick="opendr();">全部排名</a>】</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            最后活动时间：<%=ViewState["lasttime"] %></td>
                                    </tr>
                                </table>
                                <table width="100%" height="1" border="0" cellpadding="0" cellspacing="0" class="maincss">
                                    <tr>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="25" class="mainbody1" height="25" align="center">
                                            <img src="oaimg/menu/Menu4.gif" /></td>
                                        <td width="200" class="mainbody1" height="25">
                                            <a href="menu/daiban.aspx" target='lhead' class="MainLine"><strong>待办事宜</strong></a></td>
                                    </tr>
                                </table>
                                <asp:Label ID="daibanshiyi" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <script>

function showfrom(str)
{
    var num=Math.random();
    window.open ("/ProManage/wtgz_show.aspx?tmp="+num+"&id="+str+"", "_blank", "height=670, width=880,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=40")
}

function xmzt(str,type)
{
var num=Math.random();
window.open ("/ProManage/MyPro_xmsp.aspx?tmp="+num+"&id="+str+"", "_blank", "height=250, width=580,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=200,left=40")
}

function updatefrom(str)
{
var num=Math.random();
window.open ("/ProManage/MyPro_update.aspx?tmp="+num+"&id="+str+"", "_blank", "height=880, width=880,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=40")
}

function updatebq()
{
    var aaa=document.getElementById('bianqian').value
    AjaxMethod.UpdateBianqian(aaa);
}
        </script>

        <script type="text/javascript">
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
