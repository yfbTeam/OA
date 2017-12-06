<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ResourcesMenu.aspx.cs"
    Inherits="xyoa.menu.ResourcesMenu" %>

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
                    <img src="/oaimg/menu/zhu.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="ResourcesMenu.aspx"><font class="lefttd">物品管理</font></a></td>
            </tr>
        </table>
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="我的物品" Value="bbbb1" ImageUrl="~/oaimg/menu/Menu4.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="&lt;a href='/Resources/MyRes/MyResData.aspx ' target='rform' onclick='parent.UploadComplete();' &gt;我拥有的物品&lt;/a&gt;"
                        Value="bbbb1a"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="&lt;a href='/Resources/MyRes/MyResJy.aspx ' target='rform' onclick='parent.UploadComplete();' &gt;物品借用记录&lt;/a&gt;"
                        Value="bbbb1b"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="&lt;a href='/Resources/MyRes/MyResSy.aspx ' target='rform' onclick='parent.UploadComplete();' &gt;物品使用记录&lt;/a&gt;"
                        Value="bbbb1c"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="&lt;a href='/Resources/MyRes/MyResApply.aspx ' target='rform' onclick='parent.UploadComplete();' &gt;物品申请&lt;/a&gt;"
                        Value="bbbb1d"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="&lt;a href='/Resources/MyRes/MyResGmApply.aspx ' target='rform' onclick='parent.UploadComplete();' &gt;物品购买申请&lt;/a&gt;"
                        Value="bbbb1e"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="&lt;a href='/Resources/MyRes/MyResBfApply.aspx ' target='rform' onclick='parent.UploadComplete();' &gt;物品报废申请&lt;/a&gt;"
                        Value="bbbb1f"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu4.gif" SelectAction="None" Text="&lt;a href='/Resources/MyRes/MyResWxApply.aspx ' target='rform' onclick='parent.UploadComplete();' &gt;物品维修申请&lt;/a&gt;"
                        Value="bbbb1g"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="物品管理" Value="bbbb2" ImageUrl="~/oaimg/menu/knowledge2.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="&lt;a href='/Resources/ResMg/ResMap.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品分布列表&lt;/a&gt; "
                        Value="bbbb2a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="&lt;a href='/Resources/ResMg/ResFp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品分配&lt;/a&gt;"
                        Value="bbbb2b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="&lt;a href='/Resources/ResMg/MyResGmApply.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品购买审批&lt;/a&gt;"
                        Value="bbbb2c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="&lt;a href='/Resources/ResMg/MyResBfApply.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品报废审批&lt;/a&gt;"
                        Value="bbbb2d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="&lt;a href='/Resources/ResMg/MyResJyApply.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品借用审批&lt;/a&gt;"
                        Value="bbbb2e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="&lt;a href='/Resources/ResMg/MyResSyApply.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品使用审批&lt;/a&gt;"
                        Value="bbbb2f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge2.gif" Text="&lt;a href='/Resources/ResMg/MyResWxApply.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品维修审批&lt;/a&gt;"
                        Value="bbbb2g" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="统计报表" Value="bbbb3" ImageUrl="~/oaimg/menu/workflow_query.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="&lt;a href='/Resources/ResReport/ResFpR.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品分配报表&lt;/a&gt;"
                        Value="bbbb3a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="&lt;a href='/Resources/ResReport/ResGMR.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品购买报表&lt;/a&gt;"
                        Value="bbbb3b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="&lt;a href='/Resources/ResReport/ResBfR.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品报废报表&lt;/a&gt;"
                        Value="bbbb3c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="&lt;a href='/Resources/ResReport/ResJyR.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品借用报表&lt;/a&gt;"
                        Value="bbbb3d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="&lt;a href='/Resources/ResReport/ResSyR.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品使用报表&lt;/a&gt;"
                        Value="bbbb3e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="&lt;a href='/Resources/ResReport/ResWxR.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品维修报表&lt;/a&gt;"
                        Value="bbbb3f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="&lt;a href='/Resources/ResReport/ResCkFx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;按所属仓库分析&lt;/a&gt;"
                        Value="bbbb3g" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="&lt;a href='/Resources/ResReport/ResZcLb.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;按物品类别分析&lt;/a&gt;"
                        Value="bbbb3h" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="&lt;a href='/Resources/ResReport/ResQyFx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;按所在区域分析&lt;/a&gt;"
                        Value="bbbb3i" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="&lt;a href='/Resources/ResReport/ResZxZt.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;按物品状态分析&lt;/a&gt;"
                        Value="bbbb3j" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/workflow_query.gif" Text="&lt;a href='/Resources/ResReport/ResZhCx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;物品列表&lt;/a&gt;"
                        Value="bbbb3k" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="物品设置" Value="bbbb4" ImageUrl="~/oaimg/menu/Choose55.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/Resources/ResSet/ResourcesAdd.aspx' target='rform' onclick='parent.UploadComplete();'&gt;物品登记&lt;/a&gt;"
                        Value="bbbb4a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/Resources/ResSet/ResourcesType.aspx' target='rform' onclick='parent.UploadComplete();'&gt;物品类别&lt;/a&gt;"
                        Value="bbbb4b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/Resources/ResSet/ResourcesQuyu.aspx' target='rform' onclick='parent.UploadComplete();'&gt;所属区域&lt;/a&gt;"
                        Value="bbbb4e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/Resources/ResSet/ResourcesCangKu.aspx' target='rform' onclick='parent.UploadComplete();'&gt;仓库设置&lt;/a&gt;"
                        Value="bbbb4c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>

        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
