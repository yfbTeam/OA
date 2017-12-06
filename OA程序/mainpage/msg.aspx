<%@ Page Language="C#" AutoEventWireup="true" Codebehind="msg.aspx.cs" Inherits="xyoa.mainpage.msg" %>

<html>
<head id="Head1" runat="server">
    <title>聊天记录管理</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" align="center" cellpadding="0" cellspacing="1">
            <tr>
                <td background="/oaimg/lt1.jpg" height="15">
                </td>
            </tr>
            <tr>
                <td valign="top" bgcolor="#A2DEFF">
                    <table width="100%" height="7" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="3">
                            </td>
                            <td width="197" valign="top" bgcolor="#FFFFFF">
                                <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#003B81">
                                    <tr>
                                        <td valign="top" bgcolor="#FFFFFF" align="center">
                                            <table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td background="/oaimg/lt2.jpg">
                                                        <b>&nbsp;<font color="#1A3761">组织人员</font></b></td>
                                                </tr>
                                            </table>
                                            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td valign="top" style="line-height: 215%">
                                                        <iframe name="lform" marginwidth="1" marginheight="1" src="msg_left.aspx" frameborder="0"
                                                            width="100%" height="100%" bordercolor="#EDEDED"></iframe>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="4">
                            </td>
                            <td valign="top" bgcolor="#FFFFFF">
                                <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#003B81">
                                    <tr>
                                        <td valign="top" bgcolor="#FFFFFF">
                                            <iframe name="rform" marginwidth="1" marginheight="1" src="msglog.aspx?user=<%=Request.QueryString["user"]%>"
                                                frameborder="0" width="100%" height="100%" bordercolor="#EDEDED" scrolling=auto></iframe>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td background="/oaimg/lt1.jpg" height="29">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
