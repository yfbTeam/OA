<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ZaijiSheng_lb_show_jiben.aspx.cs"
    Inherits="xyoa.SchTable.Xueji.ZaijiSheng.ZaijiSheng_lb_show_jiben" %>

<html>

<script>
function chknull()
{
   if(document.getElementById('Xingming').value=='')
    {
    alert('姓名不能为空');
    form1.Xingming.focus();
    return false;
    }	

   if(document.getElementById('XuejiZhuangtai').value=='')
    {
    alert('学籍状态不能为空');
    form1.XuejiZhuangtai.focus();
    return false;
    }	

    showwait();	
 
}  

</script>

<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                    <tr>
                                        <td align="center" class="newtd2" colspan="8" style="height: 26px">
                                            <b>基本信息</b></td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="8%">
                                            班级：</td>
                                        <td class="newtd2" colspan="7" height="17">
                                            <asp:Label ID="BanJi" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            学生姓名：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Xingming" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            学籍号：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Xuejihao" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            学号：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Xuehao" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            考号：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Kaohao" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            性别：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Xingbie" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            出生日期：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Chusheng" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            民族：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Mingzhu" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            籍贯：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Jiguan" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            出生地：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Chushengdi" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            入校时间：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="RuxiaoShijian" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            入学成绩：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="RuxiaoChengji" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            照片：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Image ID="Zhaopian" runat="server" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            政治面貌：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Zhengzhimianmhao" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            来源校(园)：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Laiyuanxiao" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            学籍状态：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="XuejiZhuangtai" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            职务：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Zhiwu" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            身份证号：</td>
                                        <td class="newtd2" height="17" width="45%" colspan="3">
                                            <asp:Label ID="Shengfenzheng" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            健康状况：</td>
                                        <td class="newtd2" height="17" width="45%" colspan="3">
                                            <asp:Label ID="Jiangkan" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" nowrap="nowrap" rowspan="3" width="5%">
                                            生源类别：</td>
                                        <td class="newtd2" height="17" width="95%" colspan="7">
                                            小学：
                                            <asp:Label ID="Shengyuan1" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="newtd2" height="17" width="95%" colspan="7">
                                            初中：
                                            <asp:Label ID="Shengyuan2" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="newtd2" height="17" width="95%" colspan="7">
                                            高中：
                                            <asp:Label ID="Shengyuan3" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="newtd2" colspan="8" style="height: 26px">
                                            <b>家庭信息</b></td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            联系电话：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Dianhua" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            家庭住址：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Dizhi" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            邮编：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Youbian" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            通信地址：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Tongxin" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            电子邮箱：</td>
                                        <td class="newtd2" height="17" width="95%" colspan="7">
                                            <asp:Label ID="Youxiang" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" class="newtd2" colspan="8" style="height: 26px">
                                            <b>其他</b></td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            户口类型：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="HukouLeixing" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            户口性质：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="HukouXingzhi" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            三残：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Sancan" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            留守儿童：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="LiushouErtong" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            农民工子女：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Nongminggao" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            军人子女：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Junrenzinv" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            教师子女：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Jiaoshizinv" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            单亲家庭：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Danqinjiating" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            独生子女：</td>
                                       <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Dushengzinv" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            贫困生：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Pingkunsheng" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            是否住校：</td>
                                        <td class="newtd2" height="17" width="45%" colspan="3">
                                            <asp:Label ID="Zhuxiao" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <asp:TextBox ID="NianjiName" runat="server" Visible="false"></asp:TextBox>
        </table>
    </form>
</body>
</html>
