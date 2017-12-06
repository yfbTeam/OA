<%@ Page Language="C#" AutoEventWireup="true" Codebehind="helpsp.aspx.cs" Inherits="xyoa.help.helpsp" %>

<html>
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
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
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
                                        <td height="35">
                                            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="17">
                                                        &nbsp;</td>
                                                    <td valign="top">
                                                        <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                            cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td style="height: 26px; width: 51%;">
                                                                    <button class="btn4off" type="button" onclick="javascript:window.location='help.aspx';">
                                                                        <font class="shadow_but">文档帮助</font></button>
                                                                    <button class="btn4on" type="button" onclick="javascript:window.location='helpsp.aspx';">
                                                                        <font class="shadow_but">视频演示</font></button>
                                                                </td>
                                                                <td style="height: 26px" align="right">
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="5" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td class="newtd2" height="17" width="100%">
                                                        <img src="../oaimg/menu/arrow_down.gif" border="0" hspace="4"><a href="OA助手安装、使用、卸载.exe"
                                                            target="_blank">OA助手安装、使用、卸载</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" width="100%">
                                                        <img src="../oaimg/menu/arrow_down.gif" border="0" hspace="4"><a href="个性风格工作台.exe"
                                                            target="_blank">个性风格工作台</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" width="100%">
                                                        <img src="../oaimg/menu/arrow_down.gif" border="0" hspace="4"><a href="工作流设计和表单设计.exe"
                                                            target="_blank">工作流设计和表单设计</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" width="100%">
                                                        <img src="../oaimg/menu/arrow_down.gif" border="0" hspace="4"><a href="工作流程.exe" target="_blank">工作流程</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" width="100%">
                                                        <img src="../oaimg/menu/arrow_down.gif" border="0" hspace="4"><a href="个人事务.exe" target="_blank">个人事务</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" width="100%">
                                                        <img src="../oaimg/menu/arrow_down.gif" border="0" hspace="4"><a href="公共事务.exe" target="_blank">公共事务</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" width="100%">
                                                        <img src="../oaimg/menu/arrow_down.gif" border="0" hspace="4"><a href="信息交流.exe" target="_blank">信息交流</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" width="100%">
                                                        <img src="../oaimg/menu/arrow_down.gif" border="0" hspace="4"><a href="行政办公.exe" target="_blank">行政办公</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" width="100%">
                                                        <img src="../oaimg/menu/arrow_down.gif" border="0" hspace="4"><a href="物品管理.exe" target="_blank">物品管理</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" width="100%">
                                                        <img src="../oaimg/menu/arrow_down.gif" border="0" hspace="4"><a href="人力资源.exe" target="_blank">人力资源</a>
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
