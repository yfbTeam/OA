<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PublicWorkMenu.aspx.cs"
    Inherits="xyoa.PublicWork.Menu" %>

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
                    <img src="/oaimg/menu/Choose55.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="PublicWorkMenu.aspx"><font class="lefttd">公共事务</font></a></td>
            </tr>
        </table>
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="通知公告" Value="jjjj3" ImageUrl="~/oaimg/menu/Menu46.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="&lt;a href='/PublicWork/BumenNewsMg/BumenNewsMgList.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;通知浏览&lt;/a&gt;"
                        Value="jjjj3a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="&lt;a href='/PublicWork/BumenNewsMg/BumenNewsMg.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;通知管理&lt;/a&gt;"
                        Value="jjjj3b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="&lt;a href='/PublicWork/BumenNewsMg/BumenNewsSc.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我的收藏&lt;/a&gt;"
                        Value="jjjj3c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="新闻管理" Value="jjjj1" ImageUrl="~/oaimg/menu/Menu55.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu55.gif" SelectAction="None" Text="&lt;a href='/PublicWork/NewsMg/NewsMgList.aspx' target='rform' onclick='parent.UploadComplete();' &gt;新闻浏览&lt;/a&gt;"
                        Value="jjjj1a"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu55.gif" SelectAction="None" Text="&lt;a href='/PublicWork/NewsMg/NewsMg.aspx' target='rform' onclick='parent.UploadComplete();' &gt;新闻管理&lt;/a&gt;"
                        Value="jjjj1b"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu55.gif" Text="&lt;a href='/PublicWork/NewsMg/NewsMgListSc.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我的收藏&lt;/a&gt;"
                        Value="jjjj1c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="图片新闻" Value="jjjja3" ImageUrl="~/oaimg/menu/Choose55.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/PublicWork/TupianNew/TupianNewList.aspx' target='rform' onclick='parent.UploadComplete();'&gt;图片新闻&lt;/a&gt;"
                        Value="jjjja3a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/PublicWork/TupianNew/TupianNewMg.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;新闻管理&lt;/a&gt;"
                        Value="jjjja3b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/PublicWork/TupianNew/TupianNewSc.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我的收藏&lt;/a&gt;"
                        Value="jjjja3c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="部门主页" Value="jjjja2" ImageUrl="~/oaimg/menu/Menu45.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" SelectAction="None" Text="&lt;a href='/PublicWork/BumenPage/Zhuye.aspx' target='rform' onclick='parent.UploadComplete();' &gt;部门主页浏览&lt;/a&gt;"
                        Value="jjjja2a"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" SelectAction="None" Text="&lt;a href='/PublicWork/BumenPage/BumenWh.aspx' target='rform' onclick='parent.UploadComplete();' &gt;部门主页维护&lt;/a&gt;"
                        Value="jjjja2b"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" Text="&lt;a href='/PublicWork/BumenPage/BumenSz.aspx' target='rform' onclick='parent.UploadComplete();'&gt;主页基础设置&lt;/a&gt;"
                        Value="jjjja2d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" Text="&lt;a href='/PublicWork/BumenPage/BumenZyLb.aspx' target='rform' onclick='parent.UploadComplete();'&gt;部门主页类别&lt;/a&gt;"
                        Value="jjjja2c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" Text="&lt;a href='/PublicWork/BumenPage/BumenSc.aspx' target='rform' onclick='parent.UploadComplete();'&gt;我的收藏&lt;/a&gt;"
                        Value="jjjja2e" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="大事记" Value="jjjj2" ImageUrl="~/oaimg/menu/Menu31.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="&lt;a href='/PublicWork/ComThingMg/ComThingMgList.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;大事记浏览 &lt;/a&gt; "
                        Value="jjjj2a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="&lt;a href='/PublicWork/ComThingMg/ComThingMg.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;大事记管理&lt;/a&gt;"
                        Value="jjjj2b" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="电子期刊" Value="jjjj5" ImageUrl="~/oaimg/menu/Choose32.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="&lt;a href='/PublicWork/Qikan/QikanLxList.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;期刊浏览&lt;/a&gt;"
                        Value="jjjj5a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="&lt;a href='/PublicWork/Qikan/Qikan.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;期刊管理&lt;/a&gt;"
                        Value="jjjj5b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="&lt;a href='/PublicWork/Qikan/QikanLx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;期刊目录&lt;/a&gt;"
                        Value="jjjj5c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="规章制度" Value="jjjj6" ImageUrl="~/oaimg/menu/Choose55.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/PublicWork/Zhidu/ZhiduLxList.aspx' target='rform' onclick='parent.UploadComplete();'&gt;制度浏览&lt;/a&gt;"
                        Value="jjjj6a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/PublicWork/Zhidu/Zhidu.aspx' target='rform' onclick='parent.UploadComplete();'&gt;制度管理&lt;/a&gt;"
                        Value="jjjj6b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/PublicWork/Zhidu/ZhiduLx.aspx' target='rform' onclick='parent.UploadComplete();'&gt;制度目录&lt;/a&gt;"
                        Value="jjjj6c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="图片管理" Value="jjjj7" ImageUrl="~/oaimg/menu/Menu49.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="&lt;a href='/PublicWork/Tupian/TupianLxList.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;图片浏览&lt;/a&gt;"
                        Value="jjjj7a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="&lt;a href='/PublicWork/Tupian/Tupian.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;图片管理&lt;/a&gt;"
                        Value="jjjj7b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="&lt;a href='/PublicWork/Tupian/TupianLx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;图片目录&lt;/a&gt;"
                        Value="jjjj7c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="视频赏识" Value="jjjj9" ImageUrl="~/oaimg/menu/knowledge.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/PublicWork/Shipin/ShipinList.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;视频赏识&lt;/a&gt;"
                        Value="jjjj9a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/PublicWork/Shipin/Shipin.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;视频管理&lt;/a&gt;"
                        Value="jjjj9b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/PublicWork/Shipin/ShipinLx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;视频目录&lt;/a&gt;"
                        Value="jjjj9c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="合同管理" Value="jjjj8" ImageUrl="~/oaimg/menu/Menu58.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='/PublicWork/Hetong/MyHetong.aspx' target='rform' onclick='parent.UploadComplete();' &gt;我的合同&lt;/a&gt;"
                        Value="jjjj8a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='/PublicWork/Hetong/HetongSp.aspx' target='rform' onclick='parent.UploadComplete();' &gt;合同审批&lt;/a&gt;"
                        Value="jjjj8b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='/PublicWork/Hetong/HetongCx.aspx' target='rform' onclick='parent.UploadComplete();' &gt;合同查询统计&lt;/a&gt;"
                        Value="jjjj8c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='/PublicWork/Hetong/HetongJk.aspx' target='rform' onclick='parent.UploadComplete();' &gt;合同监控&lt;/a&gt;"
                        Value="jjjj8e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='/PublicWork/Hetong/HetongSz.aspx' target='rform' onclick='parent.UploadComplete();' &gt;监控设置&lt;/a&gt;"
                        Value="jjjj8f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='/PublicWork/Hetong/HetongLb.aspx' target='rform' onclick='parent.UploadComplete();' &gt;合同类别&lt;/a&gt;"
                        Value="jjjj8g" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="网络硬盘" Value="jjjja1" ImageUrl="~/oaimg/menu/Menu20.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu20.gif" Text="&lt;a href='/PublicWork/WebDisk/MyWebDisk.aspx' target='rform' onclick='parent.UploadComplete();' &gt;硬盘浏览&lt;/a&gt;"
                        Value="jjjja1b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu20.gif" Text="&lt;a href='/PublicWork/WebDisk/WebDiskLx.aspx' target='rform' onclick='parent.UploadComplete();' &gt;硬盘目录&lt;/a&gt;"
                        Value="jjjja1c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>

        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
