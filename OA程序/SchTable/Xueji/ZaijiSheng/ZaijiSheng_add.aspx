<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ZaijiSheng_add.aspx.cs"
    Inherits="xyoa.SchTable.Xueji.ZaijiSheng.ZaijiSheng_add" %>

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
                                <asp:Panel ID="Panel1" runat="server">
                                    <div align="center">
                                        <asp:Label ID="Label1" runat="server" Text="请先选择班级" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server">
                                    <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                        <tr>
                                            <td align="center" class="newtd2" colspan="8" style="height: 26px">
                                                <b>基本信息</b></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="8%">
                                                <font color="red">※</font>班级：</td>
                                            <td class="newtd2" colspan="7" height="17">
                                                <asp:Label ID="BanJi" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>学生姓名：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Xingming" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                学籍号：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Xuejihao" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                学号：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Xuehao" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                考号：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Kaohao" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>性别：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:RadioButtonList ID="Xingbie" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True">男</asp:ListItem>
                                                    <asp:ListItem>女</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>出生日期：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Chusheng" runat="server" Width="100px" onClick="WdatePicker()"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                民族：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Mingzhu" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                籍贯：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Jiguan" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                出生地：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Chushengdi" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                入校时间：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="RuxiaoShijian" runat="server" Width="100px" onClick="WdatePicker()"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                入学成绩：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="RuxiaoChengji" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                照片：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <input id="uploadFile" runat="server" style="width: 100px" type="file" name="uploadFile" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                政治面貌：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Zhengzhimianmhao" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                来源校(园)：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Laiyuanxiao" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>学籍状态：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="XuejiZhuangtai" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                职务：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Zhiwu" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                身份证号：</td>
                                            <td class="newtd2" height="17" width="45%" colspan="3">
                                                <asp:TextBox ID="Shengfenzheng" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                健康状况：</td>
                                            <td class="newtd2" height="17" width="45%" colspan="3">
                                                <asp:DropDownList ID="Jiangkan" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" nowrap="nowrap" rowspan="3" width="5%">
                                                生源类别：</td>
                                            <td class="newtd2" height="17" width="95%" colspan="7">
                                                小学：<asp:DropDownList ID="Shengyuan1" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="newtd2" height="17" width="95%" colspan="7">
                                                初中：<asp:DropDownList ID="Shengyuan2" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="newtd2" height="17" width="95%" colspan="7">
                                                高中：<asp:DropDownList ID="Shengyuan3" runat="server">
                                                </asp:DropDownList>
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
                                                <asp:TextBox ID="Dianhua" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                家庭住址：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Dizhi" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                邮编：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Youbian" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                通信地址：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Tongxin" runat="server" Width="100%"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                电子邮箱：</td>
                                            <td class="newtd2" height="17" width="95%" colspan="7">
                                                <asp:TextBox ID="Youxiang" runat="server" Width="100%"></asp:TextBox>
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
                                                <asp:DropDownList ID="HukouLeixing" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                户口性质：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="HukouXingzhi" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                三残：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:CheckBoxList ID="Sancan" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                                                    <asp:ListItem>智力残疾</asp:ListItem>
                                                    <asp:ListItem>视力残疾</asp:ListItem>
                                                    <asp:ListItem>听力残疾</asp:ListItem>
                                                </asp:CheckBoxList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                留守儿童：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:RadioButtonList ID="LiushouErtong" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem>是</asp:ListItem>
                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                农民工子女：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:RadioButtonList ID="Nongminggao" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem>是</asp:ListItem>
                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                军人子女：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:RadioButtonList ID="Junrenzinv" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem>是</asp:ListItem>
                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                教师子女：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:RadioButtonList ID="Jiaoshizinv" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem>是</asp:ListItem>
                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                单亲家庭：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:RadioButtonList ID="Danqinjiating" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem>是</asp:ListItem>
                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                独生子女：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:RadioButtonList ID="Dushengzinv" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True">是</asp:ListItem>
                                                    <asp:ListItem>否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                贫困生：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:RadioButtonList ID="Pingkunsheng" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem>是</asp:ListItem>
                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>是否住校：</td>
                                            <td class="newtd2" height="17" width="45%" colspan="3">
                                                <asp:RadioButtonList ID="Zhuxiao" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Selected="True">是</asp:ListItem>
                                                    <asp:ListItem>否</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr id="printshow3">
                                            <td align="center" class="newtd2" colspan="8" height="26" width="33%">
                                                <div align="center">
                                                    <font face="宋体">
                                                        <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                    </font>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
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
