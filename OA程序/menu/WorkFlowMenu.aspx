<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowMenu.aspx.cs" Inherits="xyoa.menu.WorkFlowMenu" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="../<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
</head>
<body style="overflow: auto" bgcolor="white">
    <form id="form1" runat="server">
        <table width="100%" height="20" border="0" cellpadding="0" cellspacing="0" class="blueleft">
            <tr>
                <td width="30%" align="right" valign="top">
                    <img src="../oaimg/menu/workflow_list.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="WorkFlowMenu.aspx"><font class="lefttd">工作流程</font></a></td>
            </tr>
        </table>
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='/WorkFlow/AddWorkFlow.aspx?id=0' target='rform' onclick='parent.UploadComplete();'&gt;新建工作&lt;/a&gt;"
                    Value="mmmm1" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode Text="&lt;a href='/WorkFlow/WorkFlowListAll.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;待办工作&lt;/a&gt;"
                    Value="mmmm3" ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='/WorkFlow/MyAddWorkFlow.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我发起的工作&lt;/a&gt;"
                    Value="mmmm2" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='/WorkFlow/MyAddWorkFlowJb.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我经办过的工作&lt;/a&gt;"
                    Value="mmmma" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="&lt;a href='/WorkFlow/WorkFlowSearch.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;工作查询&lt;/a&gt;"
                    Value="mmmm4"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="&lt;a href='/WorkFlow/WorkFlowJk.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;工作监控&lt;/a&gt;"
                    Value="mmmm5"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="&lt;a href='/WorkFlow/WorkFlowListXlSearch.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;效率值分析&lt;/a&gt;"
                    Value="mmmm8"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="&lt;a href='/WorkFlow/WorkFlowDel.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;工作销毁&lt;/a&gt;"
                    Value="mmmm6"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="&lt;a href='/WorkFlow/WorkFlowNodeFF.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;工作流传阅&lt;/a&gt;"
                    Value="mmmmb"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="&lt;a href='/WorkFlow/WorkFlowNodeGD.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;归档工作&lt;/a&gt;"
                    Value="mmmm7"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="&lt;a href='/WorkFlow/Baobiao.aspx' target='rform' onclick='parent.UploadComplete();'&gt;报表中心&lt;/a&gt;"
                    Value="mmmm9"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>

        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
