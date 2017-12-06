<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shipin_play.aspx.cs" Inherits="xyoa.PublicWork.Shipin.Shipin_play" %>

<html>
<head id="Head1" runat="server">
    <title>
      正在播放视频【<%=ViewState["Titles"] %>】
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="center" class="newtd2" >
                                                      正在播放视频【<%=ViewState["Titles"] %>】</td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" >
                                                      <div id="container">
                                                                <a href="http://www.macromedia.com/go/getflashplayer">安装FLASH播放器</a></div>

                                                            <script type="text/javascript" src="/js/swfobject.js"></script>

                                                            <script type="text/javascript">
                                                    var s1 = new SWFObject("player.swf","ply","406","356","9","#FFFFFF");
                                                    s1.addParam("allowfullscreen","true");
                                                    s1.addParam("allowscriptaccess","always");
                                                    s1.addParam("flashvars","file=/<%=ViewState["Content"] %>&image=play.jpg");
                                                    s1.write("container");
                                                            </script>
                                                       </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <input id="Button1" type="button" value="返 回" onclick="history.go(-1)"/>
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