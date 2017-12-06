<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowNodeFF_show.aspx.cs" Inherits="xyoa.WorkFlow.WorkFlowNodeFF_show" %>
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
function geturl()
{
<%=ViewState["url"] %>
}
</script>
</head>
<body class="newbody" onload="geturl();">
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
                                                                <font class="shadow_but">工作流传阅</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                          
                                                            <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" Text="导 出" CssClass="button_css" />
                                                            <input id="Button4" type="button" value="打 印" onclick="printpage8()" class="button_css" /></td>
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
                                                            文件主题：</td>
                                                        <td class="newtd2" height="17" colspan="3" width="83%">
                                                            <asp:Label ID="Titles" runat="server" Width="100%"></asp:Label>&nbsp;</td>
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

                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            文件正文：</td>
                                                        <td class="newtd2" height="17" colspan="3" width="83%">
                                                            <asp:Label ID="Content" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                                                    </tr>
                                                    <asp:Panel ID="Panel1" runat="server">
                                                        <tr id="printshow4">
                                                            <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                                <div align="center">
                                                                    <font face="宋体">
                                                                        <input id="Button2" type="button" value="返 回" onclick="history.go(-1)" class="button_css"/>
                                                                      </font>&nbsp;</div>
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