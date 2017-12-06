<%@ Page Language="C#" AutoEventWireup="true" Codebehind="NbEmail_sj_show.aspx.cs"
    Inherits="xyoa.InfoManage.nbemail.NbEmail_sj_show" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script>
    function zx()
    {
        if (!confirm("是否确定要删除？"))
        return false;
    }
    </script>

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
                                                                <font class="shadow_but">内部邮件</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            <asp:Button ID="Button9" runat="server" CssClass="button_css" OnClick="Button9_Click"
                                                                Text="删 除" />
                                                            <asp:Button ID="Button8" runat="server" CssClass="button_css" Text="上一封" OnClick="Button8_Click" />
                                                            <asp:Button ID="Button7" runat="server" CssClass="button_css" Text="下一封" OnClick="Button7_Click" />
                                                            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="导 出" CssClass="button_css" />
                                                            <input id="Button4" type="button" value="打 印" onclick="printnewpage()" class="button_css" /></td>
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
                                            <div id="tablename" runat="server">
                                                <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage"
                                                    id="tableprint">
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            邮件主题：</td>
                                                        <td class="newtd2" height="17" colspan="3" width="83%">
                                                            <asp:Label ID="Titles" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            收件人：</td>
                                                        <td class="newtd2" colspan="3" height="17">
                                                            <asp:Label ID="JsRealname" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            发件人：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:Label ID="FsRealname" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            发送时间：</td>
                                                        <td class="newtd2" colspan="3" height="17">
                                                            <asp:Label ID="FsTime" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                                                    </tr>
                                                    <tr class="" id="nextrs22">
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            附件：</td>
                                                        <td class="newtd2" height="17" width="33%" colspan="3">
                                                            <asp:Label ID="fujian" runat="server" Width="90%"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            邮件正文：</td>
                                                        <td class="newtd2" height="17" colspan="3" width="83%">
                                                            <asp:Label ID="Content" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                                                    </tr>
                                                    <asp:Panel ID="Panel1" runat="server">
                                                        <tr id="printshow4">
                                                            <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                                <div align="center">
                                                                    <font face="宋体">
                                                                        <asp:Button ID="Button5" runat="server" CssClass="button_css" OnClick="Button5_Click"
                                                                            Text="同 意" />
                                                                        <asp:Button ID="Button6" runat="server" CssClass="button_css" OnClick="Button6_Click"
                                                                            Text="不同意" />
                                                                        <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="回 复" OnClick="Button2_Click" />
                                                                        <asp:Button ID="Button3" runat="server" CssClass="button_css" Text="转 发" OnClick="Button3_Click" />
                                                                        <input id="Button1" class="button_css" onclick="<%=pageurl %>" type="button" value="返 回" /></font>&nbsp;</div>
                                                            </td>
                                                        </tr>
                                                    </asp:Panel>
                                                </table>
                                            </div>
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
        <asp:Label ID="FsUsername" runat="server" Visible="false"></asp:Label>

        <script>
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
