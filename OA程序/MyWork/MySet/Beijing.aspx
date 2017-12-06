<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Beijing.aspx.cs" Inherits="xyoa.MyWork.MySet.Beijing" %>

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

</head>
<body class="newbody" oncontextmenu="return false">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
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
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            自定义背景</td>
                                                        <td width="81%">
                                                            &nbsp;</td>
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
                                                &nbsp;</td>
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
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td  style="height: 26px">
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='BeijingXt.aspx';showwait();">
                                                                <font class="shadow_but">系统背景</font></button>
                                                            <button class="btn4on" type="button" onclick="javascript:window.location='Beijing.aspx';showwait();">
                                                                <font class="shadow_but">自定义背景</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='BeijingBt.aspx';showwait();">
                                                                <font class="shadow_but">标题栏样式</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='BeijingNy.aspx';showwait();">
                                                                <font class="shadow_but">内页样式</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                            &nbsp;</td>
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
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        桌面背景：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Image ID="JmBg" runat="server" Height="87px" Width="123px" />任意象素
                                                    </td>
                                                </tr>
                                                <tr id="nextrs1">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        浏览图片：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <input id="uploadFile" runat="server" style="width: 404px" type="file" name="uploadFile" />
                                                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="更 新" />
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
    </form>
</body>
</html>
