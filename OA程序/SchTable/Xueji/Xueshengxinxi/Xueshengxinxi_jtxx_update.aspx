﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Xueshengxinxi_jtxx_update.aspx.cs"
    Inherits="xyoa.SchTable.Xueji.Xueshengxinxi.Xueshengxinxi_jtxx_update" %>

<html>

<script>
function chknull()
{

   if(document.getElementById('Xingming').value=='')
    {
    alert('成员姓名不能为空');
    form1.Xingming.focus();
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
                            <td valign="top" style="height: 40px">
                                <div id="printshow2">
                                    <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                        cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="height: 26px;">
                                                <button class="btn4off" type="button">
                                                    <font class="shadow_but">家庭信息</font></button>
                                            </td>
                                            <td style="height: 26px" align="right">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            <font color="red">※</font>学生姓名：</td>
                                        <td class="newtd2" height="17" width="45%" colspan="3">
                                            <asp:Label ID="XsId" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            <font color="red">※</font>成员姓名：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Xingming" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            关系：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Guanxi" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            联系电话：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Dianhua" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            邮政编码：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Youzheng" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            电子信箱：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Xinxiang" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            联系地址：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Dizhi" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            工作单位：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Danwei" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            单位地址：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="DwDizhi" runat="server" Width="100px"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            职务：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Zhiwu" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            休息日：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Xiuxiri" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            特长：</td>
                                        <td class="newtd2" height="17" width="95%" colspan="7">
                                            <asp:TextBox ID="Techang" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            志愿服务意向：</td>
                                        <td class="newtd2" height="17" width="95%" colspan="7">
                                            <asp:TextBox ID="Yixiang" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            志愿服务记录：</td>
                                        <td class="newtd2" height="17" width="95%" colspan="7">
                                            <asp:TextBox ID="Jilu" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="printshow3">
                                        <td align="center" class="newtd2" colspan="8" height="26" width="33%">
                                            <div align="center">
                                                <font face="宋体">
                                                    <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                    <input id="Button3" type="button" value="返 回" class="button_css" onclick="history.go(-1)" />
                                                </font>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
