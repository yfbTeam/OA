﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyDataUpdate.aspx.cs" Inherits="xyoa.MyWork.MySet.MyDataUpdate" %>

<html>

<script>
function chknull()
{
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
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow1">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                </td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            个人资料设置
                                                        </td>
                                                        <td width="81%">
                                                            </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" class="nexttop">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
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
                                <div id="printshow2">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                </td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="20%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">个人资料</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            提醒：“姓名、部门、职位”在系统中将会用作标示，如需修改请联系管理员在“系统管理－用户管理”中进行修改。</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                </td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>基本信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        用户姓名：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Realname" runat="server" Text="Label"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        工号：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Worknum" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        部门名称：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Unit" runat="server"></asp:Label></td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        职位：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Post" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        性别：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:DropDownList ID="Sex" runat="server" Width="100%">
                                                            <asp:ListItem>男</asp:ListItem>
                                                            <asp:ListItem>女</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        生日：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:TextBox ID="Bothday" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                      
                                                    </td>
                                                </tr>
                                                <tr class="" id="nextrs1">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <strong>联系信息</strong>&nbsp;</div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        单位电话：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:TextBox ID="Tel" runat="server" Width="100%"></asp:TextBox></td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        单位传真：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:TextBox ID="Fax" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        手机：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:TextBox ID="MoveTel" runat="server" Width="100%"></asp:TextBox></td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        小灵通：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:TextBox ID="LittleTel" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        电子邮件：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:TextBox ID="Email" runat="server" Width="100%"></asp:TextBox></td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        QQ号码：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:TextBox ID="QQNum" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        MSN：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:TextBox ID="Msn" runat="server" Width="100%"></asp:TextBox></td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        ICQ号码：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:TextBox ID="ICQ" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr class="" id="Tr1">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <strong>家庭信息</strong>&nbsp;</div>
                                                    </td>
                                                </tr>
                                                <tr class="" id="Tr2">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        家庭住址：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:TextBox ID="Address" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        家庭邮编：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:TextBox ID="ZipCode" runat="server" Width="100%"></asp:TextBox></td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        家庭电话：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:TextBox ID="HomeTel" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <script type="text/javascript">
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
