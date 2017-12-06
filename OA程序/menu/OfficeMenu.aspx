<%@ Page Language="C#" AutoEventWireup="true" Codebehind="OfficeMenu.aspx.cs" Inherits="xyoa.menu.OfficeMenu" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
</head>
<body style="overflow: auto" bgcolor=white>
    <form id="form1" runat="server">
        <table width="100%" height="20" border="0" cellpadding="0" cellspacing="0" class="blueleft">
            <tr>
                <td width="30%" align="right" valign="top">
                    <img src="/oaimg/menu/Menu4.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="OfficeMenu.aspx"><font class="lefttd">行政办公</font></a></td>
            </tr>
        </table>
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="会议管理" Value="kkkk2" ImageUrl="~/oaimg/menu/Menu43.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu43.gif" Text="&lt;a href='/OfficeMenu/Metting/Faqi.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;会议申请&lt;/a&gt;"
                        Value="kkkk2a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu43.gif" Text="&lt;a href='/OfficeMenu/Metting/MettingApply_sp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;会议审批&lt;/a&gt;"
                        Value="kkkk2b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu43.gif" Text="&lt;a href='/OfficeMenu/Metting/MettingCx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;会议查询&lt;/a&gt;"
                        Value="kkkk2c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu43.gif" Text="&lt;a href='/OfficeMenu/Metting/ZyMetting.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;会议室占用情况&lt;/a&gt;"
                        Value="kkkk2d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu43.gif" Text="&lt;a href='/OfficeMenu/Metting/MettingHouse.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;会议室管理&lt;/a&gt;"
                        Value="kkkk2f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow.gif" Text="&lt;a href='/OfficeMenu/Metting/NetMetting.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;网络会议&lt;/a&gt;"
                        Value="kkkk2g" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="车辆管理" Value="kkkk3" ImageUrl="~/oaimg/menu/@vehicle.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="&lt;a href='/OfficeMenu/Car/ZyCar.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;车辆占用情况&lt;/a&gt;"
                        Value="kkkk3a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="&lt;a href='/OfficeMenu/Car/CarApply.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;用车申请&lt;/a&gt;"
                        Value="kkkk3b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="&lt;a href='/OfficeMenu/Car/CarApply_sp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;用车审批&lt;/a&gt;"
                        Value="kkkk3c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="&lt;a href='/OfficeMenu/Car/CarApplyTj.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;车辆使用统计&lt;/a&gt;"
                        Value="kkkk3d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="&lt;a href='/OfficeMenu/Car/CarReques.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;事故管理&lt;/a&gt;"
                        Value="kkkk3e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="&lt;a href='/OfficeMenu/Car/CarCosts.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;费用管理&lt;/a&gt;"
                        Value="kkkk3f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="&lt;a href='/OfficeMenu/Car/CarCostsTj.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;车辆费用统计&lt;/a&gt;"
                        Value="kkkk3g" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="&lt;a href='/OfficeMenu/Car/DriverManager.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;驾驶员管理&lt;/a&gt;"
                        Value="kkkk3h" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="&lt;a href='/OfficeMenu/Car/CarInfo.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;车辆信息管理&lt;/a&gt;"
                        Value="kkkk3i" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="&lt;a href='/OfficeMenu/Car/CarType.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;车辆类型&lt;/a&gt;"
                        Value="kkkk3j" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/@vehicle.gif" Text="&lt;a href='/OfficeMenu/Car/CarFyType.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;费用类型&lt;/a&gt;"
                        Value="kkkk3k" SelectAction="None"></asp:TreeNode>
                 
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="工作计划" Value="kkkk5" ImageUrl="~/oaimg/menu/knowledge.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/OfficeMenu/WorkPlan/MyPlan.aspx' target='rform' onclick='parent.UploadComplete();'&gt;我的计划&lt;/a&gt;"
                        Value="kkkk5a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/OfficeMenu/WorkPlan/MyPlanGx.aspx' target='rform' onclick='parent.UploadComplete();'&gt;共享计划&lt;/a&gt;"
                        Value="kkkk5b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/OfficeMenu/WorkPlan/MyPlanJk.aspx' target='rform' onclick='parent.UploadComplete();'&gt;计划监控&lt;/a&gt;"
                        Value="kkkk5c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/OfficeMenu/WorkPlan/MyPlanLx.aspx' target='rform' onclick='parent.UploadComplete();'&gt;计划类型&lt;/a&gt;"
                        Value="kkkk5d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/OfficeMenu/WorkPlan/MyPlanSz.aspx' target='rform' onclick='parent.UploadComplete();'&gt;监控设置&lt;/a&gt;"
                        Value="kkkk5e" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="工作日志" Value="kkkk6" ImageUrl="~/oaimg/menu/Menu14.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu14.gif" Text="&lt;a href='/OfficeMenu/Rizhi/MyRizhi.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我的日志&lt;/a&gt;"
                        Value="kkkk6a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu14.gif" Text="&lt;a href='/OfficeMenu/Rizhi/MyRizhipz.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;日志批注&lt;/a&gt;"
                        Value="kkkk6b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu14.gif" Text="&lt;a href='/OfficeMenu/Rizhi/Rizhisz.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;日志设置&lt;/a&gt;"
                        Value="kkkk6c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu14.gif" Text="&lt;a href='/OfficeMenu/Rizhi/RizhiLx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;日志类型&lt;/a&gt;"
                        Value="kkkk6d" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="任务管理" Value="kkkk7" ImageUrl="~/oaimg/menu/Menu62.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="&lt;a href='/OfficeMenu/Renwu/MyRenwu.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我的任务&lt;/a&gt;"
                        Value="kkkk7a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="&lt;a href='/OfficeMenu/Renwu/RenwuFp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;任务分配&lt;/a&gt;"
                        Value="kkkk7b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="&lt;a href='/OfficeMenu/Renwu/RenwuJk.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;领导监控&lt;/a&gt;"
                        Value="kkkk7c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="&lt;a href='/OfficeMenu/Renwu/RenwuJx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;任务绩效&lt;/a&gt;"
                        Value="kkkk7d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="&lt;a href='/OfficeMenu/Renwu/Renwusz.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;领导设置&lt;/a&gt;"
                        Value="kkkk7e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="&lt;a href='/OfficeMenu/Renwu/RenwuLx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;任务类型&lt;/a&gt;"
                        Value="kkkk7f" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>

        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
