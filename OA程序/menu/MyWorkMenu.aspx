<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyWorkMenu.aspx.cs" Inherits="xyoa.menu.MyWorkMenu" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
</head>
<body style="overflow: auto" bgcolor="white">
    <form id="form1" runat="server">
        <table width="100%" height="20" border="0" cellpadding="0" cellspacing="0" class="blueleft">
            <tr>
                <td width="30%" align="right" valign="top">
                    <img src="../oaimg/menu/Menu31.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="MyWorkMenu.aspx"><font class="lefttd">个人事务</font></a></td>
            </tr>
        </table>
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="电子闹钟" Value="hhhh1" ImageUrl="~/oaimg/menu/Menu39.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu39.gif" SelectAction="None" Text="&lt;a href='../MyWork/Naozhong/Naozhong.aspx ' target='rform' onclick='parent.UploadComplete();' &gt;电子闹钟&lt;/a&gt;"
                        Value="hhhh1"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="记事便签" Value="hhhh2" ImageUrl="~/oaimg/menu/MenuTE.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="&lt;a href='../MyWork/MakeTing/MakeTing.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我的便签  &lt;/a&gt; "
                        Value="hhhh2a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="&lt;a href='../MyWork/MakeTing/MakeListTing.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;便签管理&lt;/a&gt;"
                        Value="hhhh2b" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个人考勤" Value="hhhh4" ImageUrl="~/oaimg/menu/Menu8.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu8.gif" Text="&lt;a href='../MyWork/WorkTime/WorkTime.aspx' target='rform' onclick='parent.UploadComplete();'&gt;上下班登记&lt;/a&gt;"
                        Value="hhhh4" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu8.gif" Text="&lt;a href='../MyWork/WorkTime/MyAttendance.aspx?type=1' target='rform' onclick='parent.UploadComplete();'&gt;出差登记&lt;/a&gt;"
                        Value="hhhh4" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu8.gif" Text="&lt;a href='../MyWork/WorkTime/MyAttendance.aspx?type=2' target='rform' onclick='parent.UploadComplete();'&gt;休假登记&lt;/a&gt;"
                        Value="hhhh4" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu8.gif" Text="&lt;a href='../MyWork/WorkTime/MyAttendance.aspx?type=3' target='rform' onclick='parent.UploadComplete();'&gt;加班登记&lt;/a&gt;"
                        Value="hhhh4" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu8.gif" Text="&lt;a href='../MyWork/WorkTime/WorkTimeMG.aspx' target='rform' onclick='parent.UploadComplete();'&gt;我的考勤&lt;/a&gt;"
                        Value="hhhh4" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="通讯录管理" Value="hhhh5" ImageUrl="~/oaimg/menu/Menu31.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="&lt;a href='../MyWork/txl/CompanyGroup.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;单位通讯录&lt;/a&gt;"
                        Value="hhhh5a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="&lt;a href='../MyWork/txl/WBGroup.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;外部通讯录&lt;/a&gt;"
                        Value="hhhh5c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="&lt;a href='../MyWork/txl/MyGroup.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;个人通讯录&lt;/a&gt;"
                        Value="hhhh5b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="&lt;a href='../MyWork/txl/GroupType.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;通讯录类别&lt;/a&gt;"
                        Value="hhhh5d" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个人文件柜" Value="hhhh6" ImageUrl="~/oaimg/menu/Menu7.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu7.gif" Text="&lt;a href='/MyWork/wjk/Folders.aspx' target='rform' onclick='parent.UploadComplete();' &gt;个人文件柜&lt;/a&gt;"
                        Value="hhhh6a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu7.gif" Text="&lt;a href='/MyWork/wjk/Foldersgx.aspx' target='rform' onclick='parent.UploadComplete();' &gt;共享文件柜&lt;/a&gt;"
                        Value="hhhh6b" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="我的会议" Value="hhhh7" ImageUrl="~/oaimg/menu/Menu285.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='/MyWork/Metting/MyMetting.aspx' target='rform' onclick='parent.UploadComplete();' &gt;我的会议&lt;/a&gt;"
                        Value="hhhh7a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow.gif" Text="&lt;a href='/MyWork/Metting/MynetMetting.aspx' target='rform' onclick='parent.UploadComplete();' &gt;网络会议&lt;/a&gt;"
                        Value="hhhh7b" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="员工动态" Value="hhhhc" ImageUrl="~/oaimg/menu/MenuTE.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="&lt;a href='/MyWork/Quxiang/MyQuxiang.aspx' target='rform' onclick='parent.UploadComplete();' &gt;员工动态&lt;/a&gt;"
                        Value="hhhhc1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="&lt;a href='/MyWork/Quxiang/Jiankong.aspx' target='rform' onclick='parent.UploadComplete();' &gt;动态监控&lt;/a&gt;"
                        Value="hhhhc2" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="&lt;a href='/MyWork/Quxiang/QuxianSz.aspx' target='rform' onclick='parent.UploadComplete();' &gt;监控设置&lt;/a&gt;"
                        Value="hhhhc3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="&lt;a href='/MyWork/Quxiang/QuxianQj.aspx' target='rform' onclick='parent.UploadComplete();' &gt;全局设置&lt;/a&gt;"
                        Value="hhhhc4" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="日程安排" Value="hhhh8" ImageUrl="~/oaimg/menu/work_plan.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/work_plan.gif" Text="&lt;a href='/MyWork/Richeng/RichengRi.aspx' target='rform' onclick='parent.UploadComplete();' &gt;我的日程&lt;/a&gt;"
                        Value="hhhh8aa" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/work_plan.gif" Text="&lt;a href='/MyWork/Richeng/RichengXb.aspx' target='rform' onclick='parent.UploadComplete();' &gt;协办日程&lt;/a&gt;"
                        Value="hhhh8ab" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/work_plan.gif" Text="&lt;a href='/MyWork/Richeng/RichenggkRi.aspx' target='rform' onclick='parent.UploadComplete();' &gt;公开日程&lt;/a&gt;"
                        Value="hhhh8d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/work_plan.gif" Text="&lt;a href='/MyWork/Richeng/RichengjkRi.aspx' target='rform' onclick='parent.UploadComplete();' &gt;日程监控&lt;/a&gt;"
                        Value="hhhh8e1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/work_plan.gif" Text="&lt;a href='/MyWork/Richeng/Richengsz.aspx' target='rform' onclick='parent.UploadComplete();' &gt;监控设置&lt;/a&gt;"
                        Value="hhhh8e2" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="印章管理" Value="hhhhb" ImageUrl="~/oaimg/menu/knowledge.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/MyWork/YinZhang/MyYinZhang.aspx' target='rform' onclick='parent.UploadComplete();' &gt;我的印章&lt;/a&gt;"
                        Value="hhhhb1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/MyWork/YinZhang/MyYinZhangLog.aspx' target='rform' onclick='parent.UploadComplete();' &gt;印章使用记录&lt;/a&gt;"
                        Value="hhhhb2" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="个性设置" Value="hhhh9" ImageUrl="~/oaimg/menu/sys.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/PageSet.aspx' target='rform' onclick='parent.UploadComplete();' &gt;界面主题&lt;/a&gt;"
                        Value="hhhh9a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/TxSet.aspx' target='rform' onclick='parent.UploadComplete();' &gt;消息提醒设置&lt;/a&gt;"
                        Value="hhhh9b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/OpenMenu.aspx' target='rform' onclick='parent.UploadComplete();' &gt;默认展开菜单&lt;/a&gt;"
                        Value="hhhh9c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/SysLog.aspx' target='rform' onclick='parent.UploadComplete();' &gt;个人操作日志&lt;/a&gt;"
                        Value="hhhh9l" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/MyDataUpdate.aspx' target='rform' onclick='parent.UploadComplete();' &gt;个人资料设置&lt;/a&gt;"
                        Value="hhhh9d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/MyUserList.aspx' target='rform' onclick='parent.UploadComplete();' &gt;自定义用户组&lt;/a&gt;"
                        Value="hhhh9e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/SpBeiZhu.aspx' target='rform' onclick='parent.UploadComplete();' &gt;常用评语&lt;/a&gt;"
                        Value="hhhh9g" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Expanded="False" Text="常用模版设置" Value="hhhh9h"
                        SelectAction="Expand">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/OftenModle.aspx' target='rform' onclick='parent.UploadComplete();' &gt;常用模版设置&lt;/a&gt;"
                            Value="hhhh9h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/OftenModleType.aspx' target='rform' onclick='parent.UploadComplete();' &gt;常用模版类别&lt;/a&gt;"
                            Value="hhhh9h" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/DeskMould.aspx' target='rform' onclick='parent.UploadComplete();' &gt;标准版工作台&lt;/a&gt;"
                        Value="1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/MyWeituo.aspx' target='rform' onclick='parent.UploadComplete();' &gt;工作委托&lt;/a&gt;"
                        Value="hhhh9i" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/fenye.aspx' target='rform' onclick='parent.UploadComplete();' &gt;列表分页设置&lt;/a&gt;"
                        Value="hhhh9p" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/sys.gif" Text="&lt;a href='/MyWork/MySet/Syspassword.aspx' target='rform' onclick='parent.UploadComplete();' &gt;修改密码&lt;/a&gt;"
                        Value="hhhh9o" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>

        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
