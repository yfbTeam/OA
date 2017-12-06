<%@ Page Language="C#" AutoEventWireup="true" Codebehind="HumanResourcestable.aspx.cs"
    Inherits="xyoa.menu.HumanResourcestable" %>

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
                    <img src="/oaimg/menu/linkman.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="HumanResourcestable.aspx"><font class="lefttd">人力资源</font></a></td>
            </tr>
        </table>
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="招聘系统" Value="eeee1" ImageUrl="~/oaimg/menu/score.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="&lt;a href='../HumanResources/ZhaoPin/ZhaopinJh/ZhaopinJh.aspx?Zhuangtai=4' target='rform' onclick='parent.UploadComplete();'&gt;用人申请&lt;/a&gt;"
                        Value="eeee1a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="&lt;a href='../HumanResources/ZhaoPin/MianShi/MianShi.aspx?Hege=3' target='rform' onclick='parent.UploadComplete();'&gt;预约面试&lt;/a&gt;"
                        Value="eeee1j" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="&lt;a href='../HumanResources/ZhaoPin/ZhaopinJhMG/ZhaopinJhMG.aspx?Zhuangtai=1' target='rform' onclick='parent.UploadComplete();'&gt;用人申请管理&lt;/a&gt;"
                        Value="eeee1i" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="&lt;a href='../HumanResources/ZhaoPin/JianLi/JianLi.aspx?Zhuangtai=1' target='rform' onclick='parent.UploadComplete();'&gt;简历管理&lt;/a&gt;"
                        Value="eeee1c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="&lt;a href='../HumanResources/ZhaoPin/LuYong/LuYong.aspx' target='rform' onclick='parent.UploadComplete();'&gt;正式录用&lt;/a&gt;"
                        Value="eeee1e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="&lt;a href='../HumanResources/ZhaoPin/QuDao/QuDao.aspx' target='rform' onclick='parent.UploadComplete();'&gt;招聘渠道列表&lt;/a&gt;"
                        Value="eeee1g" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="模版管理" Value="eeee1h" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="&lt;a href='../HumanResources/ZhaoPin/MoBanZp/MoBanZp.aspx?Types=1' target='rform' onclick='parent.UploadComplete();'&gt;用人申请&lt;/a&gt;"
                            Value="eeee1h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="&lt;a href='../HumanResources/ZhaoPin/MoBanZp/MoBanZp.aspx?Types=2' target='rform' onclick='parent.UploadComplete();'&gt;简历管理&lt;/a&gt;"
                            Value="eeee1h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/score.gif" Text="&lt;a href='../HumanResources/ZhaoPin/MoBanZp/MoBanZp.aspx?Types=3' target='rform' onclick='parent.UploadComplete();'&gt;正式录用&lt;/a&gt;"
                            Value="eeee1h" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="培训系统" Value="eeee2" ImageUrl="~/oaimg/menu/Menu17.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/MyPage/PeiXun.aspx' target='rform' onclick='parent.UploadComplete();'&gt;我的培训计划&lt;/a&gt;"
                        Value="eeee2a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/MyPage/KaoShi.aspx?Zhuangtai=1' target='rform' onclick='parent.UploadComplete();'&gt;我的在线考试&lt;/a&gt;"
                        Value="eeee2b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/Peixun/Peixun.aspx' target='rform' onclick='parent.UploadComplete();'&gt;培训管理&lt;/a&gt;"
                        Value="eeee2c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/KaoShi/KaoShi.aspx' target='rform' onclick='parent.UploadComplete();'&gt;网上考试管理&lt;/a&gt;"
                        Value="eeee2d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/Pingfen/Pingfen.aspx' target='rform' onclick='parent.UploadComplete();'&gt;考试评分&lt;/a&gt;"
                        Value="eeee2e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/ShiJuan/ShiJuan.aspx' target='rform' onclick='parent.UploadComplete();'&gt;试卷管理&lt;/a&gt;"
                        Value="eeee2g" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/PeixunZl/PeixunZl.aspx' target='rform' onclick='parent.UploadComplete();'&gt;培训资料&lt;/a&gt;"
                        Value="eeee2h" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/PeixunLb/PeixunLb.aspx' target='rform' onclick='parent.UploadComplete();'&gt;培训类别&lt;/a&gt;"
                        Value="eeee2k" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/TikuLb/TikuLb.aspx' target='rform' onclick='parent.UploadComplete();'&gt;题库类别&lt;/a&gt;"
                        Value="eeee2l" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="题库管理" Value="eeee2j" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/TiKu/DanXuanTi/DanXuanTi.aspx' target='rform' onclick='parent.UploadComplete();'&gt;单选题&lt;/a&gt;"
                            Value="eeee2j" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/TiKu/DuoXuanTi/DuoXuanTi.aspx' target='rform' onclick='parent.UploadComplete();'&gt;多选题&lt;/a&gt;"
                            Value="eeee2j" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/TiKu/PanDuanTi/PanDuanTi.aspx' target='rform' onclick='parent.UploadComplete();'&gt;判断题&lt;/a&gt;"
                            Value="eeee2j" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/TiKu/TianKongTi/TianKongTi.aspx' target='rform' onclick='parent.UploadComplete();'&gt;填空题&lt;/a&gt;"
                            Value="eeee2j" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu17.gif" Text="&lt;a href='../HumanResources/PeiXun/TiKu/WenDaTi/WenDaTi.aspx' target='rform' onclick='parent.UploadComplete();'&gt;问答题&lt;/a&gt;"
                            Value="eeee2j" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="合同系统" Value="eeee3" ImageUrl="~/oaimg/menu/Menu58.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='../HumanResources/Hetong/HetongMy/HetongMy.aspx' target='rform' onclick='parent.UploadComplete();'&gt;我的合同&lt;/a&gt;"
                        Value="eeee3a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='../HumanResources/Hetong/HetongAdd/HetongAdd.aspx' target='rform' onclick='parent.UploadComplete();'&gt;合同新签&lt;/a&gt;"
                        Value="eeee3b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='../HumanResources/Hetong/HetongCZ/HetongCZ.aspx' target='rform' onclick='parent.UploadComplete();'&gt;合同操作&lt;/a&gt;"
                        Value="eeee3c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='../HumanResources/Hetong/HetongMg/HetongMg.aspx' target='rform' onclick='parent.UploadComplete();'&gt;合同管理&lt;/a&gt;"
                        Value="eeee3d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='../HumanResources/Hetong/Hetongls/Hetongls.aspx' target='rform' onclick='parent.UploadComplete();'&gt;合同流水日志&lt;/a&gt;"
                        Value="eeee3e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='../HumanResources/Hetong/HetongMB/HetongMB.aspx' target='rform' onclick='parent.UploadComplete();'&gt;合同模版&lt;/a&gt;"
                        Value="eeee3f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='../HumanResources/Hetong/HetongCX/HetongCX.aspx' target='rform' onclick='parent.UploadComplete();'&gt;合同查询&lt;/a&gt;"
                        Value="eeee3j" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='../HumanResources/Hetong/HetongLb/HetongLb.aspx' target='rform' onclick='parent.UploadComplete();'&gt;合同类别&lt;/a&gt;"
                        Value="eeee3h" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="人事管理" Value="eeee4" ImageUrl="~/oaimg/menu/hrms.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="&lt;a href='../HumanResources/Employee/Yuangong/Yuangong.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工档案&lt;/a&gt;"
                        Value="eeee4a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLL/YuangongLL.aspx' target='rform' onclick='parent.UploadComplete();'&gt;档案浏览&lt;/a&gt;"
                        Value="eeee4g" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="&lt;a href='../HumanResources/Employee/YuangongCX/YuangongCX.aspx' target='rform' onclick='parent.UploadComplete();'&gt;档案查询&lt;/a&gt;"
                        Value="eeee4b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="&lt;a href='../HumanResources/Employee/YuangongGH/YuangongGH.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工生日&lt;/a&gt;"
                        Value="eeee4h" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="&lt;a href='../HumanResources/Employee/YuangongDD/YuangongDD.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工调动&lt;/a&gt;"
                        Value="eeee4e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLZ/YuangongLZ.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工离职&lt;/a&gt;"
                        Value="eeee4f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="&lt;a href='../HumanResources/Employee/YuangongFZ/YuangongFZ.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工复职&lt;/a&gt;"
                        Value="eeee4g" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="奖惩记录" Value="eeee4i" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="&lt;a href='../HumanResources/Employee/YuangongJC/YuangongJC.aspx?Jiangcheng=1' target='rform' onclick='parent.UploadComplete();'&gt;奖励记录&lt;/a&gt;"
                            Value="eeee4i" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="&lt;a href='../HumanResources/Employee/YuangongJC/YuangongJC.aspx?Jiangcheng=2' target='rform' onclick='parent.UploadComplete();'&gt;惩罚记录&lt;/a&gt;"
                            Value="eeee4i" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="&lt;a href='../HumanResources/Employee/YuangongJN/YuangongJN.aspx' target='rform' onclick='parent.UploadComplete();'&gt;技能信息&lt;/a&gt;"
                        Value="eeee4j" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="&lt;a href='../HumanResources/Employee/YuangongTJ/YuangongTJ.aspx' target='rform' onclick='parent.UploadComplete();'&gt;体检记录&lt;/a&gt;"
                        Value="eeee4k" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/hrms.gif" Text="数据字典" Value="eeee4h" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=1' target='rform' onclick='parent.UploadComplete();'&gt;民族&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=2' target='rform' onclick='parent.UploadComplete();'&gt;籍贯&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=3' target='rform' onclick='parent.UploadComplete();'&gt;政治面貌&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=4' target='rform' onclick='parent.UploadComplete();'&gt;学历&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=5' target='rform' onclick='parent.UploadComplete();'&gt;专业&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=6' target='rform' onclick='parent.UploadComplete();'&gt;职称&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=7' target='rform' onclick='parent.UploadComplete();'&gt;员工类型&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=8' target='rform' onclick='parent.UploadComplete();'&gt;调动类型&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=9' target='rform' onclick='parent.UploadComplete();'&gt;离职类型&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=10' target='rform' onclick='parent.UploadComplete();'&gt;复职类型&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=11' target='rform' onclick='parent.UploadComplete();'&gt;奖励类型&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=12' target='rform' onclick='parent.UploadComplete();'&gt;惩罚类型&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=13' target='rform' onclick='parent.UploadComplete();'&gt;技能分类&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/Employee/YuangongLx/YuangongLx.aspx?type=14' target='rform' onclick='parent.UploadComplete();'&gt;体检结果&lt;/a&gt;"
                            Value="eeee4h" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="考勤系统" Value="eeee5" ImageUrl="~/oaimg/menu/Menu62.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="&lt;a href='../HumanResources/WorkTime/MyAttendance.aspx?type=1' target='rform' onclick='parent.UploadComplete();'&gt;出差审批&lt;/a&gt;"
                        Value="eeee5b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="&lt;a href='../HumanResources/WorkTime/MyAttendance.aspx?type=2' target='rform' onclick='parent.UploadComplete();'&gt;休假审批&lt;/a&gt;"
                        Value="eeee5c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="&lt;a href='../HumanResources/WorkTime/MyAttendance.aspx?type=3' target='rform' onclick='parent.UploadComplete();'&gt;加班审批&lt;/a&gt;"
                        Value="eeee5d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="&lt;a href='../HumanResources/WorkTime/WorkTimeMG.aspx' target='rform' onclick='parent.UploadComplete();'&gt;考勤管理&lt;/a&gt;"
                        Value="eeee5e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu62.gif" Text="考勤设置" Value="eeee5g" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/WorkTime.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;上下班时间&lt;/a&gt;"
                            Value="eeee5g"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/WorkTimeJx.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;登记间歇时间&lt;/a&gt;"
                            Value="eeee5g"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/winexe.gif" Text="&lt;a href='../HumanResources/WorkTimeQy.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;是否启用考勤&lt;/a&gt;"
                            Value="eeee5g"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="绩效系统" Value="eeee6" ImageUrl="~/oaimg/menu/Menu40.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../HumanResources/KaoPing/MyPage/KaoPingMgMx.aspx?KpZhuangtaiMy=1' target='rform' onclick='parent.UploadComplete();'&gt;自我考评&lt;/a&gt;"
                        Value="eeee6a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../HumanResources/KaoPing/KaoPingSJ/KaoPingSJ.aspx' target='rform' onclick='parent.UploadComplete();'&gt;上级考评&lt;/a&gt;"
                        Value="eeee6b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../HumanResources/KaoPing/KaoPingQZ/KaoPingQZ.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工签字&lt;/a&gt;"
                        Value="eeee6c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../HumanResources/KaoPing/YuangongBX/YuangongBX.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工表现&lt;/a&gt;"
                        Value="eeee6d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../HumanResources/KaoPing/KaoPingCx/KaoPingCx.aspx' target='rform' onclick='parent.UploadComplete();'&gt;考评查询&lt;/a&gt;"
                        Value="eeee6e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../HumanResources/KaoPing/KaoPingMg/KaoPingMg.aspx' target='rform' onclick='parent.UploadComplete();'&gt;考评管理&lt;/a&gt;"
                        Value="eeee6f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../HumanResources/KaoPing/KaoPingSz/KaoPingSz.aspx' target='rform' onclick='parent.UploadComplete();'&gt;考评设置&lt;/a&gt;"
                        Value="eeee6g" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="薪资管理" Value="eeee7" ImageUrl="~/oaimg/menu/pro.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/pro.gif" Text="&lt;a href='../HumanResources/Gongzi/GongziSB/GongziSB.aspx?Zhuangtai=4' target='rform' onclick='parent.UploadComplete();'&gt;薪资上报&lt;/a&gt;"
                        Value="eeee7b"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/pro.gif" Text="&lt;a href='../HumanResources/Gongzi/GongziMG/GongziMG.aspx?Zhuangtai=1' target='rform' onclick='parent.UploadComplete();'&gt;薪资管理&lt;/a&gt;"
                        Value="eeee7c"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/pro.gif" Text="&lt;a href='../HumanResources/Gongzi/GongziSZ/GongziSZ.aspx' target='rform' onclick='parent.UploadComplete();'&gt;薪资设置&lt;/a&gt;"
                        Value="eeee7d"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="监控分析" Value="eeee8" ImageUrl="~/oaimg/menu/Menu35.gif">
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="招聘系统" Value="eeee8" ImageUrl="~/oaimg/menu/Menu35.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/ZhaoPin/Fenxi1.aspx' target='rform' onclick='parent.UploadComplete();'&gt;用人申请监控&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/ZhaoPin/Fenxi2.aspx' target='rform' onclick='parent.UploadComplete();'&gt;预约面试监控&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="培训系统" Value="eeee8" ImageUrl="~/oaimg/menu/Menu35.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/Peixun/Fenxi1.aspx' target='rform' onclick='parent.UploadComplete();'&gt;培训计划监控&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/Peixun/Fenxi2.aspx' target='rform' onclick='parent.UploadComplete();'&gt;考试分数/试卷&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/Peixun/Fenxi3.aspx' target='rform' onclick='parent.UploadComplete();'&gt;考试查询&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="合同系统" Value="eeee8" ImageUrl="~/oaimg/menu/Menu35.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/Hetong/Fenxi1.aspx' target='rform' onclick='parent.UploadComplete();'&gt;合同状态分布&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/Hetong/Fenxi2.aspx' target='rform' onclick='parent.UploadComplete();'&gt;合同到期月度分布&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/Hetong/HetongCX.aspx' target='rform' onclick='parent.UploadComplete();'&gt;合同查询&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Expanded="False" SelectAction="Expand" Text="人事管理" Value="eeee8" ImageUrl="~/oaimg/menu/Menu35.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi2.aspx' target='rform' onclick='parent.UploadComplete();'&gt;性别比例分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi3.aspx' target='rform' onclick='parent.UploadComplete();'&gt;年龄分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi4.aspx' target='rform' onclick='parent.UploadComplete();'&gt;民族分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi5.aspx' target='rform' onclick='parent.UploadComplete();'&gt;籍贯分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi6.aspx' target='rform' onclick='parent.UploadComplete();'&gt;政治面貌分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi7.aspx' target='rform' onclick='parent.UploadComplete();'&gt;婚姻状况分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi9.aspx' target='rform' onclick='parent.UploadComplete();'&gt;学历分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi10.aspx' target='rform' onclick='parent.UploadComplete();'&gt;专业分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi11.aspx' target='rform' onclick='parent.UploadComplete();'&gt;部门编制分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi12.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工类型分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi13.aspx' target='rform' onclick='parent.UploadComplete();'&gt;职位分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi14.aspx' target='rform' onclick='parent.UploadComplete();'&gt;职称分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi15.aspx' target='rform' onclick='parent.UploadComplete();'&gt;总工龄分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi16.aspx' target='rform' onclick='parent.UploadComplete();'&gt;本单位工龄分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi18.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工调动/月度分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi22.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工调动/类型分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi19.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工离职/月度分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi23.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工离职/类型分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi20.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工复职/月度分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi24.aspx' target='rform' onclick='parent.UploadComplete();'&gt;员工复职/类型分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi25.aspx' target='rform' onclick='parent.UploadComplete();'&gt;奖励类型分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi26.aspx' target='rform' onclick='parent.UploadComplete();'&gt;惩罚类型分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi27.aspx' target='rform' onclick='parent.UploadComplete();'&gt;技能分类分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/RenShi/Fenxi28.aspx' target='rform' onclick='parent.UploadComplete();'&gt;体检结果分析&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                      <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/Kaoqin/WorkTimeMG.aspx' target='rform' onclick='parent.UploadComplete();'&gt;考勤统计&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu35.gif" Text="&lt;a href='../HumanResources/Fenxi/Kaoping/KaoPingCx.aspx' target='rform' onclick='parent.UploadComplete();'&gt;考评查询&lt;/a&gt;"
                            Value="eeee8" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>

        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
