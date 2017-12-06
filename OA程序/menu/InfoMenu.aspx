<%@ Page Language="C#" AutoEventWireup="true" Codebehind="InfoMenu.aspx.cs" Inherits="xyoa.menu.InfoMenu" %>

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
                    <img src="/oaimg/menu/Menu285.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="InfoMenu.aspx"><font class="lefttd">互动交流</font></a></td>
            </tr>
        </table>
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="内部消息" Value="aaaa1" ImageUrl="~/oaimg/menu/chatroom.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/chatroom.gif" SelectAction="None" Text="&lt;a href='/InfoManage/messages/Messages_add.aspx' target='rform' onclick='parent.UploadComplete();' &gt;发送消息&lt;/a&gt;"
                        Value="aaaa1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/chatroom.gif" SelectAction="None" Text="&lt;a href='/InfoManage/messages/Messages.aspx ' target='rform' onclick='parent.UploadComplete();' &gt;未读消息&lt;/a&gt;"
                        Value="aaaa1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/chatroom.gif" SelectAction="None" Text="&lt;a href='/InfoManage/messages/Messages_yd.aspx ' target='rform' onclick='parent.UploadComplete();' &gt;已读消息&lt;/a&gt;"
                        Value="aaaa1"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/chatroom.gif" SelectAction="None" Text="&lt;a href='/InfoManage/messages/Messages_yf.aspx ' target='rform' onclick='parent.UploadComplete();' &gt;已发消息&lt;/a&gt;"
                        Value="aaaa1"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="内部邮件" Value="aaaa2" ImageUrl="~/oaimg/menu/Choose32.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="&lt;a href='/InfoManage/nbemail/NbEmail_add.aspx' target='rform' onclick='parent.UploadComplete();'&gt;写邮件  &lt;/a&gt; "
                        Value="aaaa2" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="&lt;a href='/InfoManage/nbemail/NbEmail_sj.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;收件箱  &lt;/a&gt; "
                        Value="aaaa2" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="&lt;a href='/InfoManage/nbemail/NbEmail_cg.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;草稿箱&lt;/a&gt;"
                        Value="aaaa2" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="&lt;a href='/InfoManage/nbemail/NbEmail_fj.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;已发送  &lt;/a&gt; "
                        Value="aaaa2" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose32.gif" Text="&lt;a href='/InfoManage/nbemail/NbEmail_sjdel.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;已删除&lt;/a&gt;"
                        Value="aaaa2" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="外部邮件" Value="aaaab1" ImageUrl="~/oaimg/menu/Menu32.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu32.gif" Text="&lt;a href='/InfoManage/wbemail/SendEmail.aspx' target='rform' onclick='parent.UploadComplete();'&gt;发送外部邮件  &lt;/a&gt; "
                        Value="aaaab1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu32.gif" Text="&lt;a href='/InfoManage/wbemail/EndEmail.aspx' target='rform' onclick='parent.UploadComplete();'&gt;已发外部邮件  &lt;/a&gt; "
                        Value="aaaab1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu32.gif" Text="&lt;a href='/InfoManage/wbemail/OutEmail.aspx' target='rform' onclick='parent.UploadComplete();'&gt;待发外部邮件&lt;/a&gt;"
                        Value="aaaab1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu32.gif" Text="&lt;a href='/InfoManage/wbemail/BadEmail.aspx' target='rform' onclick='parent.UploadComplete();'&gt;发送失败邮件  &lt;/a&gt; "
                        Value="aaaab1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu32.gif" Text="&lt;a href='/InfoManage/wbemail/Emailprv.aspx' target='rform' onclick='parent.UploadComplete();'&gt;外部邮箱设置  &lt;/a&gt; "
                        Value="aaaab1" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="文件传阅" Value="aaaa9" ImageUrl="~/oaimg/menu/MenuTE.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="&lt;a href='/InfoManage/filesend/JsInfoSend.aspx' target='rform' onclick='parent.UploadComplete();' &gt;接收文件&lt;/a&gt;"
                        Value="aaaa9a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/MenuTE.gif" Text="&lt;a href='/InfoManage/filesend/InfoSend.aspx' target='rform' onclick='parent.UploadComplete();' &gt;传阅文件&lt;/a&gt;"
                        Value="aaaa9b" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="知识堂" Value="aaaa1a" ImageUrl="~/oaimg/menu/knowledge.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/InfoManage/zhiao/zhishitang.aspx' target='rform' onclick='parent.UploadComplete();' &gt;知识堂&lt;/a&gt;"
                        Value="aaaa1a1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/InfoManage/zhiao/leibie_wt.aspx' target='rform' onclick='parent.UploadComplete();' &gt;问题分类设置&lt;/a&gt;"
                        Value="aaaa1a2" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/InfoManage/zhiao/leibie_zl.aspx' target='rform' onclick='parent.UploadComplete();' &gt;资料分类设置&lt;/a&gt;"
                        Value="aaaa1a3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/InfoManage/zhiao/jifen.aspx' target='rform' onclick='parent.UploadComplete();' &gt;积分规则设置&lt;/a&gt;"
                        Value="aaaa1a4" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/InfoManage/zhiao/dengji.aspx' target='rform' onclick='parent.UploadComplete();' &gt;积分等级设置&lt;/a&gt;"
                        Value="aaaa1a5" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="我的手机短信" Value="aaaa4"
                    ImageUrl="~/oaimg/menu/Menu30.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="&lt;a href='/InfoManage/sms/MySms_Shenqing.aspx' target='rform' onclick='parent.UploadComplete();'&gt;发送短信申请&lt;/a&gt;"
                        Value="aaaa4a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="&lt;a href='/InfoManage/sms/MySms_Shenpi.aspx' target='rform' onclick='parent.UploadComplete();'&gt;发送短信审批&lt;/a&gt;"
                        Value="aaaa4b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="&lt;a href='/InfoManage/sms/MySms_SeadedOut.aspx' target='rform' onclick='parent.UploadComplete();'&gt;已发手机短信&lt;/a&gt;"
                        Value="aaaa4c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="&lt;a href='/InfoManage/sms/MySms_Out.aspx' target='rform' onclick='parent.UploadComplete();'&gt;等待发送短信&lt;/a&gt;"
                        Value="aaaa4d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="&lt;a href='/InfoManage/sms/MySms_BadOut.aspx' target='rform' onclick='parent.UploadComplete();'&gt;发送失败短信&lt;/a&gt;"
                        Value="aaaa4e" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="意见反馈" Value="aaaa5" ImageUrl="~/oaimg/menu/inbox.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/inbox.gif" Text="&lt;a href='/InfoManage/YjBox/MyYjBox.aspx' target='rform' onclick='parent.UploadComplete();' &gt;我的意见&lt;/a&gt;"
                        Value="aaaa5a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/inbox.gif" Text="&lt;a href='/InfoManage/YjBox/YjBoxMg.aspx' target='rform' onclick='parent.UploadComplete();' &gt;意见管理&lt;/a&gt;"
                        Value="aaaa5b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/inbox.gif" Text="&lt;a href='/InfoManage/YjBox/YjBoxSz.aspx' target='rform' onclick='parent.UploadComplete();' &gt;意见箱维护&lt;/a&gt;"
                        Value="aaaa5c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="投票管理" Value="aaaa6" ImageUrl="~/oaimg/menu/Menu33.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu33.gif" Text="&lt;a href='/InfoManage/toupiao/toupiao.aspx' target='rform' onclick='parent.UploadComplete();' &gt;投票浏览&lt;/a&gt;"
                        Value="aaaa6a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu33.gif" Text="&lt;a href='/InfoManage/toupiao/toupiaobt.aspx' target='rform' onclick='parent.UploadComplete();' &gt;投票管理&lt;/a&gt;"
                        Value="aaaa6b" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="论坛BBS" Value="aaaa7" ImageUrl="~/oaimg/menu/K1.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/K1.gif" Text="&lt;a href='/InfoManage/bbs/InsideBBS.aspx' target='rform' onclick='parent.UploadComplete();' &gt;论坛BBS&lt;/a&gt;"
                        Value="aaaa7a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/K1.gif" Text="&lt;a href='/InfoManage/bbs/InsideBBSBig.aspx' target='rform' onclick='parent.UploadComplete();' &gt;版块管理&lt;/a&gt;"
                        Value="aaaa7b" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="请示报告" Value="aaaa8" ImageUrl="~/oaimg/menu/Menu285.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='/InfoManage/QingShi/MyQingShi.aspx' target='rform' onclick='parent.UploadComplete();' &gt;报告填写&lt;/a&gt;"
                        Value="aaaa8a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='/InfoManage/QingShi/QingShiList.aspx' target='rform' onclick='parent.UploadComplete();' &gt;报告批阅&lt;/a&gt;"
                        Value="aaaa8b" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                       <asp:TreeNode Expanded="False" SelectAction="Expand" Text="讨论组" Value="aaaac" ImageUrl="~/oaimg/menu/K1.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/K1.gif" Text="&lt;a href='/InfoManage/Taolunzu/Taolunzu.aspx' target='rform' onclick='parent.UploadComplete();' &gt;讨论组&lt;/a&gt;"
                        Value="aaaac1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/K1.gif" Text="&lt;a href='/InfoManage/Taolunzu/TaolunzuMy.aspx' target='rform' onclick='parent.UploadComplete();' &gt;讨论组管理&lt;/a&gt;"
                        Value="aaaac2" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>

        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
