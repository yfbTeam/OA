﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WenDaTi_update.aspx.cs" Inherits="xyoa.HumanResources.PeiXun.TiKu.WenDaTi.WenDaTi_update" %>
<html>

<script>
function chknull()
{
    if(document.getElementById('MingchengID').value=='')
    {
        alert('请选择题库类别');
        form1.MingchengID.focus();
        return false;
    }	
    if(document.getElementById('Titles').value=='')
    {
        alert('问题不能为空');
        form1.Titles.focus();
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
                                                            <a href="WenDaTi.aspx">问答题</a>
                                                            >> 修改问答题</td>
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
                                                                <font class="shadow_but">问答题</font></button></td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>题库类别：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="MingchengID" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr class="" id="Tr1">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>问题：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:TextBox ID="Titles" runat="server" Width="100%" Height="61px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="" id="Tr5">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>答案：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:TextBox ID="Answer" runat="server" Width="100%" Height="61px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp;
                                                                <input id="Button2" type="button" value="返 回" onclick="history.go(-1)" class="button_css" /></font></div>
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