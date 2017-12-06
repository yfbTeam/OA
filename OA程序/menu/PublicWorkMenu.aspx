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
                    <a href="PublicWorkMenu.aspx"><font class="lefttd">��������</font></a></td>
            </tr>
        </table>
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">�˵�������...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="֪ͨ����" Value="jjjj3" ImageUrl="~/oaimg/menu/Menu46.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="&lt;a href='/PublicWork/BumenNewsMg/BumenNewsMgList.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;֪ͨ���&lt;/a&gt;"
                        Value="jjjj3a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="&lt;a href='/PublicWork/BumenNewsMg/BumenNewsMg.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;֪ͨ����&lt;/a&gt;"
                        Value="jjjj3b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="&lt;a href='/PublicWork/BumenNewsMg/BumenNewsSc.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�ҵ��ղ�&lt;/a&gt;"
                        Value="jjjj3c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="���Ź���" Value="jjjj1" ImageUrl="~/oaimg/menu/Menu55.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu55.gif" SelectAction="None" Text="&lt;a href='/PublicWork/NewsMg/NewsMgList.aspx' target='rform' onclick='parent.UploadComplete();' &gt;�������&lt;/a&gt;"
                        Value="jjjj1a"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu55.gif" SelectAction="None" Text="&lt;a href='/PublicWork/NewsMg/NewsMg.aspx' target='rform' onclick='parent.UploadComplete();' &gt;���Ź���&lt;/a&gt;"
                        Value="jjjj1b"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu55.gif" Text="&lt;a href='/PublicWork/NewsMg/NewsMgListSc.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�ҵ��ղ�&lt;/a&gt;"
                        Value="jjjj1c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="ͼƬ����" Value="jjjja3" ImageUrl="~/oaimg/menu/Choose55.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/PublicWork/TupianNew/TupianNewList.aspx' target='rform' onclick='parent.UploadComplete();'&gt;ͼƬ����&lt;/a&gt;"
                        Value="jjjja3a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/PublicWork/TupianNew/TupianNewMg.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;���Ź���&lt;/a&gt;"
                        Value="jjjja3b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/PublicWork/TupianNew/TupianNewSc.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�ҵ��ղ�&lt;/a&gt;"
                        Value="jjjja3c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="������ҳ" Value="jjjja2" ImageUrl="~/oaimg/menu/Menu45.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" SelectAction="None" Text="&lt;a href='/PublicWork/BumenPage/Zhuye.aspx' target='rform' onclick='parent.UploadComplete();' &gt;������ҳ���&lt;/a&gt;"
                        Value="jjjja2a"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" SelectAction="None" Text="&lt;a href='/PublicWork/BumenPage/BumenWh.aspx' target='rform' onclick='parent.UploadComplete();' &gt;������ҳά��&lt;/a&gt;"
                        Value="jjjja2b"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" Text="&lt;a href='/PublicWork/BumenPage/BumenSz.aspx' target='rform' onclick='parent.UploadComplete();'&gt;��ҳ��������&lt;/a&gt;"
                        Value="jjjja2d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" Text="&lt;a href='/PublicWork/BumenPage/BumenZyLb.aspx' target='rform' onclick='parent.UploadComplete();'&gt;������ҳ���&lt;/a&gt;"
                        Value="jjjja2c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu45.gif" Text="&lt;a href='/PublicWork/BumenPage/BumenSc.aspx' target='rform' onclick='parent.UploadComplete();'&gt;�ҵ��ղ�&lt;/a&gt;"
                        Value="jjjja2e" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="���¼�" Value="jjjj2" ImageUrl="~/oaimg/menu/Menu31.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="&lt;a href='/PublicWork/ComThingMg/ComThingMgList.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;���¼���� &lt;/a&gt; "
                        Value="jjjj2a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu31.gif" Text="&lt;a href='/PublicWork/ComThingMg/ComThingMg.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;���¼ǹ���&lt;/a&gt;"
                        Value="jjjj2b" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="�����ڿ�" Value="jjjj5" ImageUrl="~/oaimg/menu/Choose32.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="&lt;a href='/PublicWork/Qikan/QikanLxList.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�ڿ����&lt;/a&gt;"
                        Value="jjjj5a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="&lt;a href='/PublicWork/Qikan/Qikan.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�ڿ�����&lt;/a&gt;"
                        Value="jjjj5b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="&lt;a href='/PublicWork/Qikan/QikanLx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�ڿ�Ŀ¼&lt;/a&gt;"
                        Value="jjjj5c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="�����ƶ�" Value="jjjj6" ImageUrl="~/oaimg/menu/Choose55.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/PublicWork/Zhidu/ZhiduLxList.aspx' target='rform' onclick='parent.UploadComplete();'&gt;�ƶ����&lt;/a&gt;"
                        Value="jjjj6a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/PublicWork/Zhidu/Zhidu.aspx' target='rform' onclick='parent.UploadComplete();'&gt;�ƶȹ���&lt;/a&gt;"
                        Value="jjjj6b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/PublicWork/Zhidu/ZhiduLx.aspx' target='rform' onclick='parent.UploadComplete();'&gt;�ƶ�Ŀ¼&lt;/a&gt;"
                        Value="jjjj6c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="ͼƬ����" Value="jjjj7" ImageUrl="~/oaimg/menu/Menu49.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="&lt;a href='/PublicWork/Tupian/TupianLxList.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;ͼƬ���&lt;/a&gt;"
                        Value="jjjj7a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="&lt;a href='/PublicWork/Tupian/Tupian.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;ͼƬ����&lt;/a&gt;"
                        Value="jjjj7b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="&lt;a href='/PublicWork/Tupian/TupianLx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;ͼƬĿ¼&lt;/a&gt;"
                        Value="jjjj7c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="��Ƶ��ʶ" Value="jjjj9" ImageUrl="~/oaimg/menu/knowledge.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/PublicWork/Shipin/ShipinList.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��Ƶ��ʶ&lt;/a&gt;"
                        Value="jjjj9a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/PublicWork/Shipin/Shipin.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��Ƶ����&lt;/a&gt;"
                        Value="jjjj9b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/PublicWork/Shipin/ShipinLx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��ƵĿ¼&lt;/a&gt;"
                        Value="jjjj9c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="��ͬ����" Value="jjjj8" ImageUrl="~/oaimg/menu/Menu58.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='/PublicWork/Hetong/MyHetong.aspx' target='rform' onclick='parent.UploadComplete();' &gt;�ҵĺ�ͬ&lt;/a&gt;"
                        Value="jjjj8a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='/PublicWork/Hetong/HetongSp.aspx' target='rform' onclick='parent.UploadComplete();' &gt;��ͬ����&lt;/a&gt;"
                        Value="jjjj8b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='/PublicWork/Hetong/HetongCx.aspx' target='rform' onclick='parent.UploadComplete();' &gt;��ͬ��ѯͳ��&lt;/a&gt;"
                        Value="jjjj8c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='/PublicWork/Hetong/HetongJk.aspx' target='rform' onclick='parent.UploadComplete();' &gt;��ͬ���&lt;/a&gt;"
                        Value="jjjj8e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='/PublicWork/Hetong/HetongSz.aspx' target='rform' onclick='parent.UploadComplete();' &gt;�������&lt;/a&gt;"
                        Value="jjjj8f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='/PublicWork/Hetong/HetongLb.aspx' target='rform' onclick='parent.UploadComplete();' &gt;��ͬ���&lt;/a&gt;"
                        Value="jjjj8g" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="����Ӳ��" Value="jjjja1" ImageUrl="~/oaimg/menu/Menu20.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu20.gif" Text="&lt;a href='/PublicWork/WebDisk/MyWebDisk.aspx' target='rform' onclick='parent.UploadComplete();' &gt;Ӳ�����&lt;/a&gt;"
                        Value="jjjja1b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu20.gif" Text="&lt;a href='/PublicWork/WebDisk/WebDiskLx.aspx' target='rform' onclick='parent.UploadComplete();' &gt;Ӳ��Ŀ¼&lt;/a&gt;"
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
