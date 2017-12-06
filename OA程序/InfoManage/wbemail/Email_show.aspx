<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Email_show.aspx.cs" Inherits="xyoa.InfoManage.wbemail.Email_show" %>

<html>
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
                    <table width="100%" height="5" border="0" cellpadding="0" cellspacing="0" id="printshow1">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow3">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">外部邮件</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            <input id="Button3" type="button" value="打 印" onclick="printnewpage()" class="button_css" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage"
                                                id="tableprint">
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%">
                                                        邮件主题：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="83%">
                                                        <asp:Label ID="Title" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%">
                                                        收件人邮箱：</td>
                                                    <td class="newtd2" colspan="3" height="17">
                                                        <asp:Label ID="toemail" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%">
                                                        发送时间：</td>
                                                    <td class="newtd2" colspan="3" height="17">
                                                        <asp:Label ID="Settimes" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%">
                                                        邮件正文：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="83%">
                                                        <asp:Label ID="Content" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr id="printshow4">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <input id="Button1" class="button_css" onclick="history.back()" type="button" value="返 回" /></font>&nbsp;</div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:Label ID="Number" runat="server" Visible="false"></asp:Label>
    </form>
</body>
</html>
