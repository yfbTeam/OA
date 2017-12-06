<%@ Page Language="C#" AutoEventWireup="true" Codebehind="XxMeun.aspx.cs" Inherits="xyoa.menu.XxMeun" %>

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
                    <img src="/oaimg/menu/knowledge2.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="XxMeun.aspx"><font class="lefttd">教务系统</font></a></td>
            </tr>
        </table>
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

        <asp:TreeView ID="TreeView6" runat="server" CollapseImageUrl="~/oaimg/2.gif" ExpandImageUrl="~/oaimg/1.gif"
            NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Text="教师工作" Value="pppp1" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/Menu58.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='../SchTable/JiaoShi/Kecheng.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;我的课程信息&lt;/a&gt;"
                        Value="pppp1a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='../SchTable/JiaoShi/Banji.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;我的班级信息&lt;/a&gt;"
                        Value="pppp1b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu58.gif" Text="&lt;a href='../SchTable/JiaoShi/Beike.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;我的备课&lt;/a&gt;"
                        Value="pppp1c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="学籍管理" Value="pppp2" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/Menu285.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SchTable/Xueji/ZaijiSheng/ZaijiSheng.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;在籍生&lt;/a&gt;"
                        Value="pppp2a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SchTable/Xueji/Xueshengxinxi/Xueshengxinxi.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;学生基本信息&lt;/a&gt;"
                        Value="pppp2b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SchTable/Xueji/Biangeng/Biangeng.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;学籍变更&lt;/a&gt;"
                        Value="pppp2c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SchTable/Xueji/Richang/Richang.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;学生日常管理&lt;/a&gt;"
                        Value="pppp2f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SchTable/Xueji/Chaxun/Chaxun.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;学生查询&lt;/a&gt;"
                        Value="pppp2d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SchTable/Xueji/Tongji/Tongji.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;学生统计&lt;/a&gt;"
                        Value="pppp2e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu285.gif" Text="&lt;a href='../SchTable/Xueji/Xuejika/Xuejika.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;学生学籍卡&lt;/a&gt;"
                        Value="pppp2f" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="成绩管理" Value="pppp3" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/crm.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/crm.gif" Text="&lt;a href='../SchTable/Chengji/Luru/Luru.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;成绩录入&lt;/a&gt;"
                        Value="pppp3a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/crm.gif" Text="&lt;a href='../SchTable/Chengji/Chaxun/Chaxun.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;成绩查询&lt;/a&gt;"
                        Value="pppp3b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/crm.gif" Text="&lt;a href='../SchTable/Chengji/Henxiang/Henxiang.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;成绩横向分析&lt;/a&gt;"
                        Value="pppp3c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/crm.gif" Text="&lt;a href='../SchTable/Chengji/Zongxiang/Zongxiang.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;成绩纵向分析&lt;/a&gt;"
                        Value="pppp3d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/crm.gif" Text="&lt;a href='../SchTable/Chengji/Pinggu/Pinggu.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;实力评估&lt;/a&gt;"
                        Value="pppp3e" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="排课管理" Value="pppp4" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/outbox.gif">
                   <%-- <asp:TreeNode ImageUrl="~/oaimg/menu/outbox.gif" Text="&lt;a href='../SchTable/Paike/Zidong.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;自动排课&lt;/a&gt;"
                        Value="pppp4a" SelectAction="None"></asp:TreeNode>--%>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/outbox.gif" Text="&lt;a href='../SchTable/Paike/Shoudong.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;教师排课&lt;/a&gt;"
                        Value="pppp4b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/outbox.gif" Text="&lt;a href='../SchTable/Paike/Chaxun.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;课程表查询&lt;/a&gt;"
                        Value="pppp4c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="宿舍管理" Value="pppp5" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/organise.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="&lt;a href='../SchTable/Sushe/Gongyu/Gongyu.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;公寓信息&lt;/a&gt;"
                        Value="pppp5a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="&lt;a href='../SchTable/Sushe/Sushe/Sushe.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;宿舍管理&lt;/a&gt;"
                        Value="pppp5b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="&lt;a href='../SchTable/Sushe/Fenpei/Fenpei.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;宿舍分配&lt;/a&gt;"
                        Value="pppp5c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="&lt;a href='../SchTable/Sushe/Chaxun/Chaxun.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;住宿查询&lt;/a&gt;"
                        Value="pppp5d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="&lt;a href='../SchTable/Sushe/Guanliren/Guanliren.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;管理人员&lt;/a&gt;"
                        Value="pppp5e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=13'  target='rform' onclick='parent.UploadComplete();' &gt;信息设置&lt;/a&gt;"
                        Value="pppp5f" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/organise.gif" Text="&lt;a href='../SchTable/Sushe/Dengji/Dengji.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;信息登记&lt;/a&gt;"
                        Value="pppp5g" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="后勤服务" Value="pppp6" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/Menu56.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu56.gif" Text="&lt;a href='../SchTable/Houqin/Jiaofei/Jiaofei.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;缴费管理&lt;/a&gt;"
                        Value="pppp6a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu56.gif" Text="&lt;a href='../SchTable/Houqin/Yinhuan/Yinhuan.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;隐患整改记录&lt;/a&gt;"
                        Value="pppp6b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu56.gif" Text="&lt;a href='../SchTable/Houqin/Sifang/Sifang.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;四防安全检查&lt;/a&gt;"
                        Value="pppp6c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu56.gif" Text="&lt;a href='../SchTable/Houqin/Xiaofang/Xiaofang.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;消防器材登记&lt;/a&gt;"
                        Value="pppp6d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu56.gif" Text="&lt;a href='../SchTable/Houqin/Anquan/Anquan.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;学生安全教育&lt;/a&gt;"
                        Value="pppp6e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu56.gif" Text="&lt;a href='../SchTable/Houqin/Weixiu/Weixiu.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;维修记录&lt;/a&gt;"
                        Value="pppp6f" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="基础信息管理" Value="pppp7"
                    ImageUrl="~/oaimg/menu/Menu40.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/Xueqi/Xueqi.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;学期设置&lt;/a&gt;"
                        Value="pppp7a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/Nianji/Nianji.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;年级设置&lt;/a&gt;"
                        Value="pppp7b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/Banji/Banji.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;班级设置&lt;/a&gt;"
                        Value="pppp7c" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/Kecheng/Kecheng.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;课程设置&lt;/a&gt;"
                        Value="pppp7d" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/Chushihua/Chushihua.aspx'  target='rform' onclick='parent.UploadComplete();' &gt;当前学期设置&lt;/a&gt;"
                        Value="pppp7e" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode Text="数据字典" Value="pppp7f" Expanded="False" SelectAction="Expand" ImageUrl="~/oaimg/menu/Menu40.gif">
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=20'  target='rform' onclick='parent.UploadComplete();' &gt;学籍状态&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=22'  target='rform' onclick='parent.UploadComplete();' &gt;缴费类型&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=19'  target='rform' onclick='parent.UploadComplete();' &gt;考试类型&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=1'  target='rform' onclick='parent.UploadComplete();' &gt;学生职务&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=2'  target='rform' onclick='parent.UploadComplete();' &gt;处罚类别&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=3'  target='rform' onclick='parent.UploadComplete();' &gt;获奖类别&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=4'  target='rform' onclick='parent.UploadComplete();' &gt;评语词库&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=5'  target='rform' onclick='parent.UploadComplete();' &gt;日常学习&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=6'  target='rform' onclick='parent.UploadComplete();' &gt;生源类别(小学)&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=7'  target='rform' onclick='parent.UploadComplete();' &gt;生源类别(初中)&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=8'  target='rform' onclick='parent.UploadComplete();' &gt;生源类别(高中)&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=14'  target='rform' onclick='parent.UploadComplete();' &gt;健康状况&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=15'  target='rform' onclick='parent.UploadComplete();' &gt;学生户口类型&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=16'  target='rform' onclick='parent.UploadComplete();' &gt;学生户口性质&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=17'  target='rform' onclick='parent.UploadComplete();' &gt;民族设置&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=18'  target='rform' onclick='parent.UploadComplete();' &gt;政治面貌&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=21'  target='rform' onclick='parent.UploadComplete();' &gt;品德总评等第&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=9'  target='rform' onclick='parent.UploadComplete();' &gt;建筑类型&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=10'  target='rform' onclick='parent.UploadComplete();' &gt;建筑用途&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=11'  target='rform' onclick='parent.UploadComplete();' &gt;房屋状态&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                        <asp:TreeNode ImageUrl="~/oaimg/menu/Menu40.gif" Text="&lt;a href='../SchTable/SysMag/DataFile/DataFile.aspx?type=12'  target='rform' onclick='parent.UploadComplete();' &gt;房屋结构&lt;/a&gt;"
                            Value="pppp7f" SelectAction="None"></asp:TreeNode>
                    </asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
        </asp:TreeView>

        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
