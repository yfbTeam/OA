<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyPage_left.aspx.cs" Inherits="xyoa.InfoManage.zhiao.MyPage_left" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
</head>
<body background="/oaimg/menuBG.gif" style="overflow: auto">
    <form id="form1" runat="server">
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='MyPage_wt.aspx ' target='nextrform' &gt;我提交的问题&lt;/a&gt;"
                    SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='MyPage_hd.aspx ' target='nextrform' &gt;我回答的问题&lt;/a&gt;"
                    SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='MyPage_zl.aspx' target='nextrform' &gt;我上传的资料&lt;/a&gt;"
                    SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='MyPage_yxz.aspx' target='nextrform' &gt;已下载资料&lt;/a&gt;"
                    SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='MyPage_ph.aspx' target='nextrform' &gt;积分排行榜&lt;/a&gt;"
                    SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='MyPage_jf.aspx' target='nextrform' &gt;积分规则&lt;/a&gt;"
                    SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='MyPage_dj.aspx' target='nextrform' &gt;积分等级&lt;/a&gt;"
                    SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='zhishitang.aspx'  target='_parent' &gt;知识堂首页&lt;/a&gt;"
                    SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='wenti_all.aspx'  target='_parent' &gt;全部问题&lt;/a&gt;"
                    SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='ziliao_all.aspx'  target='_parent' &gt;全部资料&lt;/a&gt;"
                    SelectAction="None"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>

        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
