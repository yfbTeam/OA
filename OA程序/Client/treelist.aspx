<%@ Page Language="C#" AutoEventWireup="true" Codebehind="treelist.aspx.cs" Inherits="xyoa.Client.treelist" %>

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

function openwindowshelp()
{
   var num=Math.random();
   window.showModalDialog("../help/help.aspx?tmp="+num+"","window","dialogWidth:600px;DialogHeight=490px;status:no;scroll=no;help:no");  
}

</script>

<head id="Head1" runat="server">
    <title>功能菜单</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
</head>
<body background="../oaimg/menuBG.gif" style="overflow: auto" oncontextmenu="return false">
    <form id="form1" runat="server">
        <table width="100%" height="20" border="0" cellpadding="0" cellspacing="0" class="blueleft">
            <tr>
                <td width="30%" align="right" valign="top">
                    <img src="/oaimg/menu/Choose32.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="treelist.aspx?user=<%=Request.QueryString["user"].ToString() %>&pwd=<%=Request.QueryString["pwd"].ToString() %>"
                        title="点击刷新"><font class="lefttd">功能菜单</font></a></td>
            </tr>
        </table>
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

        <asp:Label ID="Label1" runat="server"></asp:Label>
        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode ImageUrl="~/oaimg/menu/zhu.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/index.aspx')>工作台</a>"
                    Value="hhhh1"></asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个人事务" Value="hhhh" ImageUrl="~/oaimg/menu/Menu31.gif">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="电子闹钟" Value="hhhh1" ImageUrl="~/oaimg/menu/Menu39.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu39.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/Naozhong/Naozhong.aspx')>电子闹钟</a>"
                            Value="hhhh1"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="记事便签" Value="hhhh2" ImageUrl="~/oaimg/menu/MenuTE.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MakeTing/MakeTing.aspx')>我的便签  </a> "
                            Value="hhhh2a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="<a href='javascript:void(0)' onclick=openwindows('/MyWork/MakeTing/MakeListTing.aspx')>便签管理</a>"
                            Value="hhhh2b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个人考勤" Value="hhhh4" ImageUrl="~/oaimg/menu/Menu8.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu8.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/WorkTime/WorkTime.aspx')>上下班登记</a>"
                            Value="hhhh4" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu8.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('../MyWork/WorkTime/MyAttendance.aspx?type=1')>出差登记</a>"
                            Value="hhhh4" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu8.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('../MyWork/WorkTime/MyAttendance.aspx?type=2')>休假登记</a>"
                            Value="hhhh4" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu8.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('../MyWork/WorkTime/MyAttendance.aspx?type=3')>加班登记</a>"
                            Value="hhhh4" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu8.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/WorkTime/WorkTimeMG.aspx')>考勤管理</a>"
                            Value="hhhh4" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="通讯录管理" Value="hhhh5" ImageUrl="~/oaimg/menu/Menu31.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/txl/CompanyGroup.aspx')>单位通讯录</a>"
                            Value="hhhh5a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('../MyWork/txl/WBGroup.aspx')>外部通讯录</a>"
                            Value="hhhh5c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/txl/MyGroup.aspx')>个人通讯录</a>"
                            Value="hhhh5b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/txl/GroupType.aspx')>通讯录类别</a>"
                            Value="hhhh5d" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个人文件柜" Value="hhhh6" ImageUrl="~/oaimg/menu/Menu7.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu7.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/wjk/Folders.aspx') >个人文件柜</a>"
                            Value="hhhh6a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu7.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/wjk/Foldersgx.aspx') >共享文件柜</a>"
                            Value="hhhh6b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="我的会议" Value="hhhh7" ImageUrl="~/oaimg/menu/Menu285.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/Metting/MyMetting.aspx') >我的会议</a>"
                            Value="hhhh7a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/Metting/MynetMetting.aspx') >网络会议</a>"
                            Value="hhhh7b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="员工动态" Value="hhhhc" ImageUrl="~/oaimg/menu/MenuTE.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/Quxiang/MyQuxiang.aspx') >员工动态</a>"
                            Value="hhhhc1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/Quxiang/JiankongRy.aspx') >动态监控</a>"
                            Value="hhhhc2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/Quxiang/QuxianSz.aspx') >监控设置</a>"
                            Value="hhhhc3" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/Quxiang/QuxianQj.aspx') >全局设置</a>"
                            Value="hhhhc4" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="日程安排" Value="hhhh8" ImageUrl="~/oaimg/menu/work_plan.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/Richeng/Richengmy.aspx') >我的日程</a>"
                            Value="hhhh8aa" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/work_plan.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/Richeng/Richenggk.aspx') >公开日程</a>"
                            Value="hhhh8d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/Richeng/Richengjk.aspx') >日程监控</a>"
                            Value="hhhh8e1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/Richeng/Richengsz.aspx') >监控设置</a>"
                            Value="hhhh8e2" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="印章管理" Value="hhhhb" ImageUrl="~/oaimg/menu/knowledge.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/YinZhang/MyYinZhang.aspx') >我的印章</a>"
                            Value="hhhhb1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/YinZhang/MyYinZhangLog.aspx') >印章使用记录</a>"
                            Value="hhhhb2" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个性设置" Value="hhhh9" ImageUrl="~/oaimg/menu/sys.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/PageSet.aspx') >界面主题</a>"
                            Value="hhhh9a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/TxSet.aspx') >消息提醒设置</a>"
                            Value="hhhh9b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/OpenMenu.aspx') >默认展开菜单</a>"
                            Value="hhhh9c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/SysLog.aspx') >个人操作日志</a>"
                            Value="hhhh9l" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/MyDataUpdate.aspx') >个人资料设置</a>"
                            Value="hhhh9d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/MyUserList.aspx') >自定义用户组</a>"
                            Value="hhhh9e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/SpBeiZhu.aspx') >常用评语</a>"
                            Value="hhhh9g" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Expanded="False" Text="常用模版设置" Value="hhhh9h"
                            SelectAction="Expand">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/OftenModle.aspx') >常用模版设置</a>"
                                Value="hhhh9h" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/OftenModleType.aspx') >常用模版类别</a>"
                                Value="hhhh9h" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/DeskMould.aspx') >标准版工作台</a>"
                            Value="1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/MyWeituo.aspx') >工作委托</a>"
                            Value="hhhh9i" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/MyMenu.aspx') >我的快捷菜单</a>"
                            Value="hhhh9k" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/DeskMould.aspx') >工作台设置</a>"
                            Value="hhhh9m" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/MyWebsite.aspx') >常用网址</a>"
                            Value="hhhh9n" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/fenye.aspx') >列表分页设置</a>"
                            Value="hhhh9p" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/MyWork/MySet/Syspassword.aspx') >修改密码</a>"
                            Value="hhhh9o" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="公共信息" Value="jjjj" ImageUrl="~/oaimg/menu/Menu55.gif">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="通知公告" Value="jjjj3" ImageUrl="~/oaimg/menu/Menu46.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/BumenNewsMg/BumenNewsMgList.aspx')>通知浏览</a>"
                            Value="jjjj3a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/BumenNewsMg/BumenNewsMg.aspx')>通知管理</a>"
                            Value="jjjj3b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/BumenNewsMg/BumenNewsSc.aspx')>我的收藏</a>"
                            Value="jjjj3c" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="新闻管理" Value="jjjj1" ImageUrl="~/oaimg/menu/Menu55.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu55.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/NewsMg/NewsMgList.aspx')>新闻浏览</a>"
                            Value="jjjj1a"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu55.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/NewsMg/NewsMg.aspx')>新闻管理</a>"
                            Value="jjjj1b"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu55.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/NewsMg/NewsMgListSc.aspx')>我的收藏</a>"
                            Value="jjjj1c" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="部门主页" Value="jjjja2" ImageUrl="~/oaimg/menu/Menu45.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/BumenPage/Zhuye.aspx')>部门主页浏览</a>"
                            Value="jjjja2a"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/BumenPage/BumenWh.aspx')>部门主页维护</a>"
                            Value="jjjja2b"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/BumenPage/BumenSz.aspx')>主页基础设置</a>"
                            Value="jjjja2d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/BumenPage/BumenZyLb.aspx')>部门主页类别</a>"
                            Value="jjjja2c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/BumenPage/BumenSc.aspx')>我的收藏</a>"
                            Value="jjjja2e" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="大事记" Value="jjjj2" ImageUrl="~/oaimg/menu/Menu31.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/ComThingMg/ComThingMgList.aspx')>大事记浏览 </a> "
                            Value="jjjj2a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/ComThingMg/ComThingMg.aspx')>大事记管理</a>"
                            Value="jjjj2b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="电子期刊" Value="jjjj5" ImageUrl="~/oaimg/menu/Choose32.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Qikan/QikanLxList.aspx')>期刊浏览</a>"
                            Value="jjjj5a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Qikan/Qikan.aspx')>期刊管理</a>"
                            Value="jjjj5b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Qikan/QikanLx.aspx')>期刊目录</a>"
                            Value="jjjj5c" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="规章制度" Value="jjjj6" ImageUrl="~/oaimg/menu/Choose55.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Zhidu/ZhiduLxList.aspx')>制度浏览</a>"
                            Value="jjjj6a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Zhidu/Zhidu.aspx')>制度管理</a>"
                            Value="jjjj6b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Zhidu/ZhiduLx.aspx')>制度目录</a>"
                            Value="jjjj6c" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="图片管理" Value="jjjj7" ImageUrl="~/oaimg/menu/Menu49.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Tupian/TupianLxList.aspx')>图片浏览</a>"
                            Value="jjjj7a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Tupian/Tupian.aspx')>图片管理</a>"
                            Value="jjjj7b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Tupian/TupianLx.aspx')>图片目录</a>"
                            Value="jjjj7c" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="视频赏识" Value="jjjj9" ImageUrl="~/oaimg/menu/Menu49.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Shipin/ShipinList.aspx')>视频赏识</a>"
                            Value="jjjj9a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Shipin/Shipin.aspx')>视频管理</a>"
                            Value="jjjj9b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Shipin/ShipinLx.aspx')>视频目录</a>"
                            Value="jjjj9c" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="合同管理" Value="jjjj8" ImageUrl="~/oaimg/menu/Menu58.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Hetong/MyHetong.aspx')>我的合同</a>"
                            Value="jjjj8a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Hetong/HetongSp.aspx')>合同审批</a>"
                            Value="jjjj8b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Hetong/HetongCx.aspx')>合同查询统计</a>"
                            Value="jjjj8c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Hetong/HetongJk.aspx')>合同监控</a>"
                            Value="jjjj8e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Hetong/HetongSz.aspx')>监控设置</a>"
                            Value="jjjj8f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/Hetong/HetongLb.aspx')>合同类别</a>"
                            Value="jjjj8g" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="网络硬盘" Value="jjjja1" ImageUrl="~/oaimg/menu/Menu20.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu20.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/WebDisk/MyWebDisk.aspx') >硬盘浏览</a>"
                            Value="jjjja1b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu20.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/PublicWork/WebDisk/WebDiskLx.aspx') >硬盘目录</a>"
                            Value="jjjja1c" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="行政办公" Value="kkkk" ImageUrl="~/oaimg/menu/Menu4.gif">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="会议管理" Value="kkkk2" ImageUrl="~/oaimg/menu/Menu43.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu43.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Metting/Faqi.aspx')>会议申请</a>"
                            Value="kkkk2a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu43.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Metting/MettingApply_sp.aspx')>会议审批</a>"
                            Value="kkkk2b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu43.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Metting/MettingCx.aspx')>会议查询</a>"
                            Value="kkkk2c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu43.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Metting/ZyMetting.aspx')>会议室占用情况</a>"
                            Value="kkkk2d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu43.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Metting/MettingHouse.aspx')>会议室管理</a>"
                            Value="kkkk2f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Metting/NetMetting.aspx')>网络会议</a>"
                            Value="kkkk2g" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="车辆管理" Value="kkkk3" ImageUrl="~/oaimg/menu/@vehicle.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Car/ZyCar.aspx')>车辆占用情况</a>"
                            Value="kkkk3a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Car/CarApply.aspx')>用车申请</a>"
                            Value="kkkk3b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Car/CarApply_sp.aspx')>用车审批</a>"
                            Value="kkkk3c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Car/CarApplyTj.aspx')>车辆使用统计</a>"
                            Value="kkkk3d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Car/CarReques.aspx')>事故管理</a>"
                            Value="kkkk3e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Car/CarCosts.aspx')>费用管理</a>"
                            Value="kkkk3f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Car/CarCostsTj.aspx')>车辆费用统计</a>"
                            Value="kkkk3g" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Car/DriverManager.aspx')>驾驶员管理</a>"
                            Value="kkkk3h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Car/CarInfo.aspx')>车辆信息管理</a>"
                            Value="kkkk3i" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Car/CarType.aspx')>车辆类型</a>"
                            Value="kkkk3j" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Car/CarFyType.aspx')>费用类型</a>"
                            Value="kkkk3k" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="工作计划" Value="kkkk5" ImageUrl="~/oaimg/menu/knowledge.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/WorkPlan/MyPlan.aspx')>我的计划</a>"
                            Value="kkkk5a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/WorkPlan/MyPlanGx.aspx')>共享计划</a>"
                            Value="kkkk5b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/WorkPlan/MyPlanJk.aspx')>计划监控</a>"
                            Value="kkkk5c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/WorkPlan/MyPlanLx.aspx')>计划类型</a>"
                            Value="kkkk5d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/WorkPlan/MyPlanSz.aspx')>监控设置</a>"
                            Value="kkkk5e" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="工作日志" Value="kkkk6" ImageUrl="~/oaimg/menu/Menu14.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu14.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Rizhi/MyRizhi.aspx')>我的日志</a>"
                            Value="kkkk6a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu14.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Rizhi/MyRizhipz.aspx')>日志批注</a>"
                            Value="kkkk6b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu14.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Rizhi/Rizhisz.aspx')>日志设置</a>"
                            Value="kkkk6c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu14.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Rizhi/RizhiLx.aspx')>日志类型</a>"
                            Value="kkkk6d" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="任务管理" Value="kkkk7" ImageUrl="~/oaimg/menu/Menu62.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Renwu/MyRenwu.aspx')>我的任务</a>"
                            Value="kkkk7a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Renwu/RenwuFp.aspx')>任务分配</a>"
                            Value="kkkk7b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Renwu/RenwuJk.aspx')>领导监控</a>"
                            Value="kkkk7c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Renwu/RenwuJx.aspx')>任务绩效</a>"
                            Value="kkkk7d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Renwu/Renwusz.aspx')>领导设置</a>"
                            Value="kkkk7e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/OfficeMenu/Renwu/RenwuLx.aspx')>任务类型</a>"
                            Value="kkkk7f" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="互动信息" Value="aaaa" ImageUrl="~/oaimg/menu/Menu285.gif">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="内部消息" Value="aaaa1" ImageUrl="~/oaimg/menu/chatroom.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/chatroom.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/messages/Messages_add.aspx') >发送消息</a>"
                            Value="aaaa1"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/chatroom.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/messages/Messages.aspx') >未读消息</a>"
                            Value="aaaa1"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/chatroom.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/messages/Messages_yd.aspx') >已读消息</a>"
                            Value="aaaa1"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/chatroom.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/messages/Messages_yf.aspx') >已发消息</a>"
                            Value="aaaa1"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="内部邮件" Value="aaaa2" ImageUrl="~/oaimg/menu/Choose32.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/nbemail/NbEmail_add.aspx')>写邮件</a> "
                            Value="aaaa2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/nbemail/NbEmail_sj.aspx')>收件箱</a> "
                            Value="aaaa2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/nbemail/NbEmail_cg.aspx')>草稿箱</a>"
                            Value="aaaa2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/nbemail/NbEmail_fj.aspx')>已发送</a> "
                            Value="aaaa2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/nbemail/NbEmail_sjdel.aspx')>已删除</a>"
                            Value="aaaa2" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="外部邮件" Value="aaaab1" ImageUrl="~/oaimg/menu/Menu32.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/wbemail/SendEmail.aspx')>发送外部邮件</a>"
                            Value="aaaab1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/wbemail/EndEmail.aspx')>已发外部邮件</a>"
                            Value="aaaab1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/wbemail/OutEmail.aspx')>待发外部邮件</a>"
                            Value="aaaab1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/wbemail/BadEmail.aspx')>发送失败邮件</a>"
                            Value="aaaab1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu32.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/wbemail/Emailprv.aspx')>外部邮箱设置</a>"
                            Value="aaaab1" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="文件传阅" Value="aaaa9" ImageUrl="~/oaimg/menu/MenuTE.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/filesend/JsInfoSend.aspx')>接收文件</a>"
                            Value="aaaa9a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/filesend/InfoSend.aspx')>传阅文件</a>"
                            Value="aaaa9b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="知识堂" Value="aaaa1a" ImageUrl="~/oaimg/menu/knowledge.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/zhiao/zhishitang.aspx')>知识堂</a>"
                            Value="aaaa1a1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/zhiao/leibie_wt.aspx')>问题分类设置</a>"
                            Value="aaaa1a2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/zhiao/leibie_zl.aspx')>资料分类设置</a>"
                            Value="aaaa1a3" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/zhiao/jifen.aspx')>积分规则设置</a>"
                            Value="aaaa1a4" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/zhiao/dengji.aspx')>积分等级设置</a>"
                            Value="aaaa1a5" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="我的手机短信" Value="aaaa4"
                        ImageUrl="~/oaimg/menu/Menu30.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/sms/MySms_Shenqing.aspx')>发送短信申请</a>"
                            Value="aaaa4a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/sms/MySms_Shenpi.aspx')>发送短信审批</a>"
                            Value="aaaa4b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/sms/MySms_SeadedOut.aspx')>已发手机短信</a>"
                            Value="aaaa4c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/sms/MySms_Out.aspx')>等待发送短信</a>"
                            Value="aaaa4d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/sms/MySms_BadOut.aspx')>发送失败短信</a>"
                            Value="aaaa4e" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="意见反馈" Value="aaaa5" ImageUrl="~/oaimg/menu/inbox.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/inbox.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/YjBox/MyYjBox.aspx')>我的意见</a>"
                            Value="aaaa5a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/inbox.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/YjBox/YjBoxMg.aspx')>意见管理</a>"
                            Value="aaaa5b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/inbox.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/YjBox/YjBoxSz.aspx')>意见箱维护</a>"
                            Value="aaaa5c" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="投票管理" Value="aaaa6" ImageUrl="~/oaimg/menu/Menu33.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu33.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/toupiao/toupiao.aspx')>投票浏览</a>"
                            Value="aaaa6a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu33.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/toupiao/toupiaobt.aspx')>投票管理</a>"
                            Value="aaaa6b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="论坛BBS" Value="aaaa7" ImageUrl="~/oaimg/menu/K1.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/K1.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/bbs/InsideBBS.aspx')>论坛BBS</a>"
                            Value="aaaa7a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/K1.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/bbs/InsideBBSBig.aspx')>版块管理</a>"
                            Value="aaaa7b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="请示报告" Value="aaaa8" ImageUrl="~/oaimg/menu/Menu285.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/QingShi/MyQingShi.aspx')>报告填写</a>"
                            Value="aaaa8a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/InfoManage/QingShi/QingShiList.aspx')>报告批阅</a>"
                            Value="aaaa8b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="物品管理" Value="bbbb" ImageUrl="~/oaimg/menu/zhu.gif">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="我的物品" Value="bbbb1" ImageUrl="~/oaimg/menu/Menu4.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/MyRes/MyResData.aspx')>我拥有的物品</a>"
                            Value="bbbb1a"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/MyRes/MyResJy.aspx')>物品借用记录</a>"
                            Value="bbbb1b"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/MyRes/MyResSy.aspx')>物品使用记录</a>"
                            Value="bbbb1c"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/MyRes/MyResApply.aspx')>物品申请</a>"
                            Value="bbbb1d"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/MyRes/MyResGmApply.aspx')>物品购买申请</a>"
                            Value="bbbb1e"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/MyRes/MyResBfApply.aspx')>物品报废申请</a>"
                            Value="bbbb1f"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/MyRes/MyResWxApply.aspx')>物品维修申请</a>"
                            Value="bbbb1g"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="物品管理" Value="bbbb2" ImageUrl="~/oaimg/menu/knowledge2.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResMg/ResMap.aspx')>物品分布列表</a> "
                            Value="bbbb2a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResMg/ResFp.aspx')>物品分配</a>"
                            Value="bbbb2b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResMg/MyResGmApply.aspx')>物品购买审批</a>"
                            Value="bbbb2c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResMg/MyResBfApply.aspx')>物品报废审批</a>"
                            Value="bbbb2d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResMg/MyResJyApply.aspx')>物品借用审批</a>"
                            Value="bbbb2e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResMg/MyResSyApply.aspx')>物品使用审批</a>"
                            Value="bbbb2f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResMg/MyResWxApply.aspx')>物品维修审批</a>"
                            Value="bbbb2g" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="统计报表" Value="bbbb3" ImageUrl="~/oaimg/menu/workflow_query.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResReport/ResFpR.aspx')>物品分配报表</a>"
                            Value="bbbb3a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResReport/ResGMR.aspx')>物品购买报表</a>"
                            Value="bbbb3b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResReport/ResBfR.aspx')>物品报废报表</a>"
                            Value="bbbb3c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResReport/ResJyR.aspx')>物品借用报表</a>"
                            Value="bbbb3d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResReport/ResSyR.aspx')>物品使用报表</a>"
                            Value="bbbb3e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResReport/ResWxR.aspx')>物品维修报表</a>"
                            Value="bbbb3f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResReport/ResCkFx.aspx')>按所属仓库分析</a>"
                            Value="bbbb3g" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResReport/ResZcLb.aspx')>按物品类别分析</a>"
                            Value="bbbb3h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResReport/ResQyFx.aspx')>按所在区域分析</a>"
                            Value="bbbb3i" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResReport/ResZxZt.aspx')>按物品状态分析</a>"
                            Value="bbbb3j" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResReport/ResZhCx.aspx')>物品列表</a>"
                            Value="bbbb3k" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="物品设置" Value="bbbb4" ImageUrl="~/oaimg/menu/Choose55.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResSet/ResourcesAdd.aspx')>物品登记</a>"
                            Value="bbbb4a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResSet/ResourcesType.aspx')>物品类别</a>"
                            Value="bbbb4b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResSet/ResourcesQuyu.aspx')>所属区域</a>"
                            Value="bbbb4e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/Resources/ResSet/ResourcesCangKu.aspx')>仓库设置</a>"
                            Value="bbbb4c" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="工作流程" Value="mmmm" ImageUrl="~/oaimg/menu/workflow_list.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlow/AddWorkFlow.aspx?id=0')>新建工作</a>"
                        Value="mmmm1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlow/WorkFlowList.aspx')>待办工作</a>"
                        Value="mmmm3" ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlow/MyAddWorkFlow.aspx')>我发起的工作</a>"
                        Value="mmmm2" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlow/MyAddWorkFlowJb.aspx')>我经办过的工作</a>"
                        Value="mmmma" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlow/WorkFlowSearch.aspx')>工作查询</a>"
                        Value="mmmm4"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlow/WorkFlowJk.aspx')>工作监控</a>"
                        Value="mmmm5"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlow/WorkFlowListXlSearch.aspx')>效率值分析</a>"
                        Value="mmmm8"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlow/WorkFlowDel.aspx')>工作销毁</a>"
                        Value="mmmm6"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlow/WorkFlowNodeGD.aspx')>归档工作</a>"
                        Value="mmmm7"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlow/Baobiao.aspx')>报表中心</a>"
                        Value="mmmm9"></asp:TreeNode>
                </asp:TreeNode>
       
       <asp:TreeNode Expanded="False" SelectAction="Expand" Text="教务系统" Value="pppp" ImageUrl="~/oaimg/menu/knowledge2.gif">
                
                 <asp:TreeNode Text="教师工作" Value="pppp1" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/Menu58.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/JiaoShi/Kecheng.aspx')>我的课程信息</a>"
                        Value="pppp1a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/JiaoShi/Banji.aspx')>我的班级信息</a>"
                        Value="pppp1b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/JiaoShi/Beike.aspx')>我的备课</a>"
                        Value="pppp1c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="学籍管理" Value="pppp2" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/Menu285.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Xueji/ZaijiSheng/ZaijiSheng.aspx')>在籍生</a>"
                        Value="pppp2a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Xueji/Xueshengxinxi/Xueshengxinxi.aspx')>学生基本信息</a>"
                        Value="pppp2b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Xueji/Biangeng/Biangeng.aspx')>学籍变更</a>"
                        Value="pppp2c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Xueji/Richang/Richang.aspx')>学生日常管理</a>"
                        Value="pppp2f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Xueji/Chaxun/Chaxun.aspx')>学生查询</a>"
                        Value="pppp2d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Xueji/Tongji/Tongji.aspx')>学生统计</a>"
                        Value="pppp2e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Xueji/Xuejika/Xuejika.aspx')>学生学籍卡</a>"
                        Value="pppp2f" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="成绩管理" Value="pppp3" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/crm.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/crm.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Chengji/Luru/Luru.aspx')>成绩录入</a>"
                        Value="pppp3a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/crm.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Chengji/Chaxun/Chaxun.aspx')>成绩查询</a>"
                        Value="pppp3b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/crm.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Chengji/Henxiang/Henxiang.aspx')>成绩横向分析</a>"
                        Value="pppp3c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/crm.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Chengji/Zongxiang/Zongxiang.aspx')>成绩纵向分析</a>"
                        Value="pppp3d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/crm.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Chengji/Pinggu/Pinggu.aspx')>实力评估</a>"
                        Value="pppp3e" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="排课管理" Value="pppp4" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/outbox.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/outbox.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Paike/Shoudong.aspx')>教师排课</a>"
                        Value="pppp4b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/outbox.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Paike/Chaxun.aspx')>课程表查询</a>"
                        Value="pppp4c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="宿舍管理" Value="pppp5" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/organise.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Sushe/Gongyu/Gongyu.aspx')>公寓信息</a>"
                        Value="pppp5a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Sushe/Sushe/Sushe.aspx')>宿舍管理</a>"
                        Value="pppp5b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Sushe/Fenpei/Fenpei.aspx')>宿舍分配</a>"
                        Value="pppp5c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Sushe/Chaxun/Chaxun.aspx')>住宿查询</a>"
                        Value="pppp5d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Sushe/Guanliren/Guanliren.aspx')>管理人员</a>"
                        Value="pppp5e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=13')>信息设置</a>"
                        Value="pppp5f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Sushe/Dengji/Dengji.aspx')>信息登记</a>"
                        Value="pppp5g" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="后勤服务" Value="pppp6" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/Menu56.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu56.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Houqin/Jiaofei/Jiaofei.aspx')>缴费管理</a>"
                        Value="pppp6a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu56.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Houqin/Yinhuan/Yinhuan.aspx')>隐患整改记录</a>"
                        Value="pppp6b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu56.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Houqin/Sifang/Sifang.aspx')>四防安全检查</a>"
                        Value="pppp6c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu56.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Houqin/Xiaofang/Xiaofang.aspx')>消防器材登记</a>"
                        Value="pppp6d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu56.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Houqin/Anquan/Anquan.aspx')>学生安全教育</a>"
                        Value="pppp6e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu56.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/Houqin/Weixiu/Weixiu.aspx')>维修记录</a>"
                        Value="pppp6f" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="基础信息管理" Value="pppp7"
                    ImageUrl="~/oaimg/menu/Menu40.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/Xueqi/Xueqi.aspx')>学期设置</a>"
                        Value="pppp7a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/Nianji/Nianji.aspx')>年级设置</a>"
                        Value="pppp7b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/Banji/Banji.aspx')>班级设置</a>"
                        Value="pppp7c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/Kecheng/Kecheng.aspx')>课程设置</a>"
                        Value="pppp7d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/Chushihua/Chushihua.aspx')>当前学期设置</a>"
                        Value="pppp7e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode Text="数据字典" Value="pppp7f" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/Menu40.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=20')>学籍状态</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=22')>缴费类型</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=19')>考试类型</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=1')>学生职务</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=2')>处罚类别</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=3')>获奖类别</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=4')>评语词库</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=5')>日常学习</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=6')>生源类别(小学)</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=7')>生源类别(初中)</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=8')>生源类别(高中)</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=14')>健康状况</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=15')>学生户口类型</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=16')>学生户口性质</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=17')>民族设置</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=18')>政治面貌</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=21')>品德总评等第</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=9')>建筑类型</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=10')>建筑用途</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=11')>房屋状态</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SchTable/SysMag/DataFile/DataFile.aspx?type=12')>房屋结构</a>"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                
                
                </asp:TreeNode>
                
                
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="人力资源" Value="eeee" ImageUrl="~/oaimg/menu/linkman.gif">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="招聘系统" Value="eeee1" ImageUrl="~/oaimg/menu/score.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/ZhaoPin/ZhaopinJh/ZhaopinJh.aspx?Zhuangtai=4')>用人申请</a>"
                            Value="eeee1a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/ZhaoPin/MianShi/MianShi.aspx?Hege=3')>预约面试</a>"
                            Value="eeee1j" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/ZhaoPin/ZhaopinJhMG/ZhaopinJhMG.aspx?Zhuangtai=1')>用人申请管理</a>"
                            Value="eeee1i" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/ZhaoPin/JianLi/JianLi.aspx?Zhuangtai=1')>简历管理</a>"
                            Value="eeee1c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/ZhaoPin/LuYong/LuYong.aspx')>正式录用</a>"
                            Value="eeee1e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/ZhaoPin/QuDao/QuDao.aspx')>招聘渠道列表</a>"
                            Value="eeee1g" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="模版管理" Value="eeee1h" Expanded="False"
                            SelectAction="Expand">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/ZhaoPin/MoBanZp/MoBanZp.aspx?Types=1')>用人申请</a>"
                                Value="eeee1h" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/ZhaoPin/MoBanZp/MoBanZp.aspx?Types=2')>简历管理</a>"
                                Value="eeee1h" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/ZhaoPin/MoBanZp/MoBanZp.aspx?Types=3')>正式录用</a>"
                                Value="eeee1h" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="培训系统" Value="eeee2" ImageUrl="~/oaimg/menu/Menu17.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/MyPage/PeiXun.aspx')>我的培训计划</a>"
                            Value="eeee2a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/MyPage/KaoShi.aspx?Zhuangtai=1')>我的在线考试</a>"
                            Value="eeee2b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/Peixun/Peixun.aspx')>培训管理</a>"
                            Value="eeee2c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/KaoShi/KaoShi.aspx')>网上考试管理</a>"
                            Value="eeee2d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/Pingfen/Pingfen.aspx')>考试评分</a>"
                            Value="eeee2e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/ShiJuan/ShiJuan.aspx')>试卷管理</a>"
                            Value="eeee2g" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/PeixunZl/PeixunZl.aspx')>培训资料</a>"
                            Value="eeee2h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/PeixunLb/PeixunLb.aspx')>培训类别</a>"
                            Value="eeee2k" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/TikuLb/TikuLb.aspx')>题库类别</a>"
                            Value="eeee2l" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="题库管理" Value="eeee2j" Expanded="False"
                            SelectAction="Expand">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/TiKu/DanXuanTi/DanXuanTi.aspx')>单选题</a>"
                                Value="eeee2j" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/TiKu/DuoXuanTi/DuoXuanTi.aspx')>多选题</a>"
                                Value="eeee2j" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/TiKu/PanDuanTi/PanDuanTi.aspx')>判断题</a>"
                                Value="eeee2j" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/TiKu/TianKongTi/TianKongTi.aspx')>填空题</a>"
                                Value="eeee2j" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/PeiXun/TiKu/WenDaTi/WenDaTi.aspx')>问答题</a>"
                                Value="eeee2j" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="合同系统" Value="eeee3" ImageUrl="~/oaimg/menu/Menu58.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Hetong/HetongMy/HetongMy.aspx')>我的合同</a>"
                            Value="eeee3a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Hetong/HetongAdd/HetongAdd.aspx')>合同新签</a>"
                            Value="eeee3b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Hetong/HetongCZ/HetongCZ.aspx')>合同操作</a>"
                            Value="eeee1a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Hetong/HetongMg/HetongMg.aspx')>合同管理</a>"
                            Value="eeee3d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Hetong/Hetongls/Hetongls.aspx')>合同流水日志</a>"
                            Value="eeee3e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Hetong/HetongMB/HetongMB.aspx')>合同模版</a>"
                            Value="eeee3f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Hetong/HetongCX/HetongCX.aspx')>合同查询</a>"
                            Value="eeee3j" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Hetong/HetongLb/HetongLb.aspx')>合同类别</a>"
                            Value="eeee3h" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="人事管理" Value="eeee4" ImageUrl="~/oaimg/menu/hrms.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/Yuangong/Yuangong.aspx')>员工档案</a>"
                            Value="eeee4a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongLL/YuangongLL.aspx')>档案浏览</a>"
                            Value="eeee4g" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongCX/YuangongCX.aspx')>档案查询</a>"
                            Value="eeee4b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongGH/YuangongGH.aspx')>员工生日</a>"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongDD/YuangongDD.aspx')>员工调动</a>"
                            Value="eeee4e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongLZ/YuangongLZ.aspx')>员工离职</a>"
                            Value="eeee4f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongFZ/YuangongFZ.aspx')>员工复职</a>"
                            Value="eeee4g" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="数据字典" Value="eeee4h" Expanded="False"
                            SelectAction="Expand">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=1')>民族</a>"
                                Value="eeee4g" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=2')>籍贯</a>"
                                Value="eeee4g" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=3')>政治面貌</a>"
                                Value="eeee4g" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=4')>学历</a>"
                                Value="eeee4g" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=5')>专业</a>"
                                Value="eeee4g" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=6')>职称</a>"
                                Value="eeee4g" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=7')>员工类型</a>"
                                Value="eeee4g" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=8')>调动类型</a>"
                                Value="eeee4g" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=9')>离职类型</a>"
                                Value="eeee4g" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=10')>复职类型</a>"
                                Value="eeee4g" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="考勤系统" Value="eeee5" ImageUrl="~/oaimg/menu/Menu62.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/WorkTime/MyAttendance.aspx?type=1&Zhuangtai=1')>出差管理</a>"
                            Value="eeee5b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/WorkTime/MyAttendance.aspx?type=2&Zhuangtai=1')>休假管理</a>"
                            Value="eeee5c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/WorkTime/MyAttendance.aspx?type=3&Zhuangtai=1')>加班管理</a>"
                            Value="eeee5d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/WorkTime/WorkTimeMG.aspx')>考勤管理</a>"
                            Value="eeee5e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="考勤设置" Value="eeee5g" Expanded="False"
                            SelectAction="Expand">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/WorkTime.aspx')>上下班时间</a>"
                                Value="eeee5g"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/WorkTimeJx.aspx')>登记间歇时间</a>"
                                Value="eeee5g"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/WorkTimeQy.aspx')>是否启用考勤</a>"
                                Value="eeee5g"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="绩效系统" Value="eeee6" ImageUrl="~/oaimg/menu/Menu40.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/KaoPing/MyPage/KaoPingMgMx.aspx?KpZhuangtaiMy=1')>自我考评</a>"
                            Value="eeee6a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/KaoPing/KaoPingSJ/KaoPingSJ.aspx')>上级考评</a>"
                            Value="eeee6b" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/KaoPing/KaoPingQZ/KaoPingQZ.aspx')>员工签字</a>"
                            Value="eeee6c" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/KaoPing/YuangongBX/YuangongBX.aspx')>员工表现</a>"
                            Value="eeee6d" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/KaoPing/KaoPingCx/KaoPingCx.aspx')>考评查询</a>"
                            Value="eeee6e" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/KaoPing/KaoPingMg/KaoPingMg.aspx')>考评管理</a>"
                            Value="eeee6f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/KaoPing/KaoPingSz/KaoPingSz.aspx')>考评设置</a>"
                            Value="eeee6g" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="薪资管理" Value="eeee7" ImageUrl="~/oaimg/menu/pro.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/pro.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Gongzi/GongziSB/GongziSB.aspx?Zhuangtai=4')>薪资上报</a>"
                            Value="eeee7b"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/pro.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Gongzi/GongziMG/GongziMG.aspx?Zhuangtai=1')>薪资管理</a>"
                            Value="eeee7c"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/pro.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Gongzi/GongziSZ/GongziSZ.aspx')>薪资设置</a>"
                            Value="eeee7d"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="监控分析" Value="eeee8" ImageUrl="~/oaimg/menu/Menu35.gif">
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="招聘系统" Value="eeee8" ImageUrl="~/oaimg/menu/Menu35.gif">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/ZhaoPin/Fenxi1.aspx')>用人申请监控</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/ZhaoPin/Fenxi2.aspx')>预约面试监控</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="培训系统" Value="eeee8" ImageUrl="~/oaimg/menu/Menu35.gif">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/Peixun/Fenxi1.aspx')>培训计划监控</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/Peixun/Fenxi2.aspx')>考试分数/试卷</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/Peixun/Fenxi3.aspx')>考试查询</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="合同系统" Value="eeee8" ImageUrl="~/oaimg/menu/Menu35.gif">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/Hetong/Fenxi1.aspx')>合同状态分布</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/Hetong/Fenxi2.aspx')>合同到期月度分布</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/Hetong/HetongCX.aspx')>合同查询</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="人事管理" Value="eeee8" ImageUrl="~/oaimg/menu/Menu35.gif">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi2.aspx')>性别比例分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi3.aspx')>年龄分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi4.aspx')>民族分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi5.aspx')>籍贯分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi6.aspx')>政治面貌分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi7.aspx')>婚姻状况分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi9.aspx')>学历分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi10.aspx')>专业分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi11.aspx')>部门编制分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi12.aspx')>员工类型分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi13.aspx')>职位分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi14.aspx')>职称分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi15.aspx')>总工龄分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi16.aspx')>本单位工龄分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi18.aspx')>员工调动/月度分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi22.aspx')>员工调动/类型分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi19.aspx')>员工离职/月度分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi23.aspx')>员工离职/类型分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi20.aspx')>员工复职/月度分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/RenShi/Fenxi24.aspx')>员工复职/类型分析</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="考勤系统" Value="eeee8" ImageUrl="~/oaimg/menu/Menu35.gif">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/Kaoqin/WorkTimeMG.aspx')>考勤统计</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode Expanded="False" SelectAction="Expand" Text="绩效系统" Value="eeee8" ImageUrl="~/oaimg/menu/Menu35.gif">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/HumanResources/Fenxi/Kaoping/KaoPingCx.aspx')>考评查询</a>"
                                Value="eeee8" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="系统设置" Value="iiii" ImageUrl="~/oaimg/menu/Menu10.gif">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="表单设计" Value="iiii1" ImageUrl="~/oaimg/menu/Menu55.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/bbs.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/WorkFlow/DIYForm.aspx')>表单设计</a>"
                            Value="iiii1a"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/bbs.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/WorkFlow/FormType.aspx')>表单类别</a>"
                            Value="iiii1b"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Expanded="False" SelectAction="Expand"
                        Text="工作流管理" Value="iiii2">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/WorkFlow/FlowMg.aspx')>工作流设置</a>"
                            Value="iiii2"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/WorkFlow/WorkFlowNodeGD.aspx')>归档目录</a>"
                            Value="iiii2"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/WorkFlow/Baobiao.aspx')>报表设计</a>"
                            Value="iiii2"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Expanded="False" SelectAction="Expand"
                            Text="表单工作流" Value="iiii2">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=8')>会议申请流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=9')>车辆申请流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=10')>短信审批流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=7')>合同流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=11')>物品购买申请流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=12')>物品报废申请流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=13')>物品借用申请流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=14')>物品使用申请流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=15')>物品维修申请流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=1')>合同订单流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=2')>销售出库流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=6')>采购订单流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=3')>采购入库流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=4')>库存盘点流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=5')>销售费用流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=16')>出差管理流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=17')>休假管理流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/WorkFlowSysMag/WorkFlow.aspx?FormId=18')>加班管理流程</a>"
                                Value="iiii2" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="印章管理" Value="iiii3" ImageUrl="~/oaimg/menu/Menu23.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu23.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/Seal/SealSp.aspx')>印章审批</a>"
                            Value="iiii3a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu23.gif" Text="印章维护" Value="iiii3b" Expanded="False"
                            SelectAction="Expand">
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu23.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/Seal/SealManage.aspx')>私章维护</a>"
                                Value="iiii3b" SelectAction="None"></asp:TreeNode>
                            <asp:TreeNode ImageUrl="~/oaimg/menu/Menu23.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/Seal/SealManagePb.aspx')>公章维护</a>"
                                Value="iiii3b" SelectAction="None"></asp:TreeNode>
                        </asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu23.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/Seal/SealUseLog.aspx')>印章使用日志</a>"
                            Value="iiii3c" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/file_folder.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/DocumentModle/DocumentModle.aspx')>红头文件管理</a>"
                        Value="iiii4" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/User/username.aspx')>用户管理</a>"
                        Value="iiii5" ImageUrl="~/oaimg/menu/Menu41.gif" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/Juese/Juese.aspx')>角色管理</a>"
                        Value="iiii6" ImageUrl="~/oaimg/menu/Menu37.gif" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/Bumen/Bumen.aspx')>部门管理</a>"
                        Value="iiii7"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/Zhiwei/Zhiwei.aspx')>职位管理</a>"
                        Value="iiii8"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu68.gif" SelectAction="None" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/SystemLog/SystemLog.aspx')>系统日志</a>"
                        Value="iiii9"></asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="手机短信管理" Value="iiiia1"
                        ImageUrl="~/oaimg/menu/Menu30.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/sms/Sms_Update.aspx')>手机短信模块</a>"
                            Value="iiiia1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/sms/Sms_SeadedOut.aspx')>已发送短信</a>"
                            Value="iiiia1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/sms/Sms_Out.aspx')>等待发送短信</a>"
                            Value="iiiia1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/sms/Sms_BadOut.aspx')>发送失败短信</a>"
                            Value="iiiia1" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/sms/Sms_In.aspx')>接收短信</a>"
                            Value="iiiia1" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="系统安全" Value="iiiia2" ImageUrl="~/oaimg/menu/Menu10.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu10.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/anquan/FjKey.aspx')>附件类型</a>"
                            Value="iiiia2a" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu10.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/anquan/ipmanage.aspx')>登陆IP控制</a>"
                            Value="iiiia2b" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu10.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/login/login.aspx')>登陆设置</a>"
                        Value="iiiia4" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu10.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/login/face.aspx')>界面设置</a>"
                        Value="iiiia5" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu8.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/OtherMenu/OtherMenu.aspx')>扩展应用设置</a>"
                        Value="iiiia6" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu10.gif" Text="<a href='javascript:void(0)'  onclick=openwindows('/SystemManage/chushi/chushi.aspx')>用户初始化</a>"
                        Value="iiiib2" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>

        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
