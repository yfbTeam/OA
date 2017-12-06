<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SystemMenu.aspx.cs" Inherits="xyoa.SystemManage.menu" %>

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
                    <img src="../oaimg/menu/Menu10.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="SystemMenu.aspx"><font class="lefttd">ϵͳ��������</font></a></td>
            </tr>
        </table>
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">�˵�������...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="�Ż���վ����" Value="iiiic"
                    ImageUrl="~/oaimg/menu/Choose55.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/SystemManage/Web/Tupian.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;ͼƬ����&lt;/a&gt;"
                        Value="iiiic1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/SystemManage/Web/Xinwen.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��λ����&lt;/a&gt;"
                        Value="iiiic2" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/SystemManage/Web/Zhuanti.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;ר�ⱨ��&lt;/a&gt;"
                        Value="iiiic3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/SystemManage/Web/Yuandi.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;ѧϰԭ��&lt;/a&gt;"
                        Value="iiiic4" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/SystemManage/Web/Dingbu.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;Ĭ�϶���ͼƬ&lt;/a&gt;"
                        Value="iiiic5" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/SystemManage/Web/Dibu.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�ײ�����&lt;/a&gt;"
                        Value="iiiic6" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/SystemManage/Web/Jiejiari.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�ڼ�������&lt;/a&gt;"
                        Value="iiiic7" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/SystemManage/Web/Lanmu.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�Զ�����Ŀ&lt;/a&gt;"
                        Value="iiiic8" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/SystemManage/Web/Biaoti.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��վ����&lt;/a&gt;"
                        Value="iiiic9" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Choose55.gif" Text="&lt;a href='/SystemManage/Web/Zhuangtai.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�Ż���վ״̬&lt;/a&gt;"
                        Value="iiiica" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="�����" Value="iiii1" ImageUrl="~/oaimg/menu/Menu55.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/bbs.gif" SelectAction="None" Text="&lt;a href='/SystemManage/WorkFlow/DIYForm.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�����&lt;/a&gt;"
                        Value="iiii1a"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/bbs.gif" SelectAction="None" Text="&lt;a href='/SystemManage/WorkFlow/FormType.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�����&lt;/a&gt;"
                        Value="iiii1a"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Expanded="False" SelectAction="Expand"
                    Text="����������" Value="iiii2">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" SelectAction="None" Text="&lt;a href='/SystemManage/WorkFlow/FlowMg.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;����������&lt;/a&gt;"
                        Value="iiii2"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" SelectAction="None" Text="&lt;a href='/SystemManage/WorkFlow/WorkFlowNodeGD.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�鵵Ŀ¼&lt;/a&gt;"
                        Value="iiii2"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" SelectAction="None" Text="&lt;a href='/SystemManage/WorkFlow/Baobiao.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�������&lt;/a&gt;"
                        Value="iiii2"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Expanded="False" SelectAction="Expand"
                        Text="��������" Value="iiii2">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=8' target='rform' onclick='parent.UploadComplete();'&gt;������������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=9' target='rform' onclick='parent.UploadComplete();'&gt;������������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=10'  target='rform' onclick='parent.UploadComplete();' &gt;������������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=7'  target='rform' onclick='parent.UploadComplete();' &gt;��ͬ����&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=11' target='rform' onclick='parent.UploadComplete();'&gt;��Ʒ������������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=12' target='rform' onclick='parent.UploadComplete();'&gt;��Ʒ������������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=13' target='rform' onclick='parent.UploadComplete();'&gt;��Ʒ������������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=14' target='rform' onclick='parent.UploadComplete();'&gt;��Ʒʹ����������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=15' target='rform' onclick='parent.UploadComplete();'&gt;��Ʒά����������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=19'  target='rform' onclick='parent.UploadComplete();' &gt;������������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=1'  target='rform' onclick='parent.UploadComplete();' &gt;��ͬ��������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=2'  target='rform' onclick='parent.UploadComplete();' &gt;���۳�������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=23'  target='rform' onclick='parent.UploadComplete();' &gt;������������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=24'  target='rform' onclick='parent.UploadComplete();' &gt;������������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=25'  target='rform' onclick='parent.UploadComplete();' &gt;�����깤����&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=27'  target='rform' onclick='parent.UploadComplete();' &gt;�깤�������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=26'  target='rform' onclick='parent.UploadComplete();' &gt;�ɹ��ƻ�����&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=6'  target='rform' onclick='parent.UploadComplete();' &gt;�ɹ���������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=3'  target='rform' onclick='parent.UploadComplete();' &gt;�ɹ��������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=4'  target='rform' onclick='parent.UploadComplete();' &gt;����̵�����&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=5'  target='rform' onclick='parent.UploadComplete();' &gt;���۷�������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=16'  target='rform' onclick='parent.UploadComplete();' &gt;�����������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=20'  target='rform' onclick='parent.UploadComplete();' &gt;Ͷ�߰�������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=21'  target='rform' onclick='parent.UploadComplete();' &gt;�ͷ���������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=22'  target='rform' onclick='parent.UploadComplete();' &gt;ά�޹���&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=17'  target='rform' onclick='parent.UploadComplete();' &gt;�ݼٹ�������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu53.gif" Text="&lt;a href='/WorkFlowSysMag/WorkFlow.aspx?FormId=18'  target='rform' onclick='parent.UploadComplete();' &gt;�Ӱ��������&lt;/a&gt;"
                            Value="iiii2" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="ӡ�¹���" Value="iiii3" ImageUrl="~/oaimg/menu/Menu23.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu23.gif" Text="&lt;a href='/SystemManage/Seal/SealSp.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;ӡ������&lt;/a&gt;"
                        Value="iiii3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu23.gif" Text="&lt;a href='/SystemManage/Seal/SealManage.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;˽��ά��&lt;/a&gt;"
                        Value="iiii3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu23.gif" Text="&lt;a href='/SystemManage/Seal/SealManagePb.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;����ά��&lt;/a&gt;"
                        Value="iiii3" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu23.gif" Text="&lt;a href='/SystemManage/Seal/SealUseLog.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;ӡ��ʹ����־&lt;/a&gt;"
                        Value="iiii3" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/file_folder.gif" Text="&lt;a href='/SystemManage/DocumentModle/DocumentModle.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��ͷ�ļ�����&lt;/a&gt;"
                    Value="iiii4" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode Text="&lt;a href='../SystemManage/User/username.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�û�����&lt;/a&gt;"
                    Value="iiii5" ImageUrl="~/oaimg/menu/Menu41.gif" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode Text="&lt;a href='../SystemManage/Juese/Juese.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��ɫ����&lt;/a&gt;"
                    Value="iiii6" ImageUrl="~/oaimg/menu/Menu37.gif" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" SelectAction="None" Text="&lt;a href='/SystemManage/Bumen/Bumen.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;���Ź���&lt;/a&gt;"
                    Value="iiii7"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" SelectAction="None" Text="&lt;a href='/SystemManage/Zhiwei/Zhiwei.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;ְλ����&lt;/a&gt;"
                    Value="iiii8"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu68.gif" SelectAction="None" Text="&lt;a href='/SystemManage/SystemLog/SystemLog.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;ϵͳ��־&lt;/a&gt;"
                    Value="iiii9"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu49.gif" Text="&lt;a href='/SystemManage/Pda/SysMk.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�ֻ�ƽ̨ģ��&lt;/a&gt;"
                        Value="iiiib5" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="�ֻ����Ź���" Value="iiiia1"
                    ImageUrl="~/oaimg/menu/Menu30.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="&lt;a href='/SystemManage/sms/Sms_Update.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�ֻ�����ģ��&lt;/a&gt;"
                        Value="iiiia1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="&lt;a href='/SystemManage/sms/Sms_SeadedOut.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�ѷ��Ͷ���&lt;/a&gt;"
                        Value="iiiia1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="&lt;a href='/SystemManage/sms/Sms_Out.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�ȴ����Ͷ���&lt;/a&gt;"
                        Value="iiiia1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="&lt;a href='/SystemManage/sms/Sms_BadOut.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;����ʧ�ܶ���&lt;/a&gt;"
                        Value="iiiia1" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu30.gif" Text="&lt;a href='/SystemManage/sms/Sms_In.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;���ն���&lt;/a&gt;"
                        Value="iiiia1" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="ϵͳ��ȫ" Value="iiiia2" ImageUrl="~/oaimg/menu/Menu10.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu10.gif" Text="&lt;a href='/SystemManage/anquan/FjKey.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��������&lt;/a&gt;"
                        Value="iiiia2a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu10.gif" Text="&lt;a href='/SystemManage/anquan/ipmanage.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��½IP����&lt;/a&gt;"
                        Value="iiiia2b" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu10.gif" Text="&lt;a href='/SystemManage/login/login.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��½����&lt;/a&gt;"
                    Value="iiiia4" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu10.gif" Text="&lt;a href='/SystemManage/login/face.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��������&lt;/a&gt;"
                    Value="iiiia5" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu8.gif" Text="&lt;a href='/SystemManage/OtherMenu/OtherMenu.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��չӦ������&lt;/a&gt;"
                    Value="iiiia6" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/knowledge.gif" Text="&lt;a href='/SystemManage/Menhu/Menhu.aspx' target='rform' onclick='parent.UploadComplete();'&gt;�Ż���������&lt;/a&gt;"
                    Value="iiiib4" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu10.gif" Text="&lt;a href='/SystemManage/chushi/chushi.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;�û���ʼ��&lt;/a&gt;"
                    Value="iiiib2" SelectAction="None"></asp:TreeNode>
                <asp:TreeNode ImageUrl="~/oaimg/menu/Menu10.gif" Text="&lt;a href='/SystemManage/geyan/geyan.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;��ҵ����&lt;/a&gt;"
                    Value="iiiib3" SelectAction="None"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>

        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
