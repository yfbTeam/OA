﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Naozhong_update.aspx.cs" Inherits="xyoa.MyWork.Naozhong.Naozhong_update" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('titles').value=='')
    {
    alert('内容不能为空');
    form1.titles.focus();
    return false;
    }	
    
    if(document.getElementById('txtime').value=='')
    {
    alert('提醒时间不能为空');
    form1.txtime.focus();
    return false;
    }	
    
    
    showwait();	
}  

</script>

<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
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
                                <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox></td>
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
                                                            <a href="Naozhong.aspx">电子闹钟</a>
                                                            >> 修改闹钟</td>
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
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">电子闹钟</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            </td>
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
                                                        <b>电子闹钟</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>提醒内容：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="titles" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>提醒类型：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Types" runat="server" Width="100%">
                                                            <asp:ListItem Value="1">每天循环</asp:ListItem>
                                                            <asp:ListItem Value="2">仅一次</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>提醒时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="txtime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                     说明：选择"每天循环"，提醒时间为“小时+分钟”，具体的日期对期没有影响；"仅一次"，系统只根据实际提醒时间提醒一次，既“日期+小时+分钟”</td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <img src="/oaimg/menu/chatroom.gif" />
                                                        <asp:CheckBox ID="NbSms" runat="server" Text="内部消息" Checked="True" />
                                                        <img src="/oaimg/menu/Menu30.gif" id="IMG1" runat="server" />
                                                        <asp:CheckBox ID="SjSms" runat="server" Text="手机短信" />
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css"
                                                                    OnClick="Button2_Click" />
                                                            </font>
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
    </form>
</body>
</html>
