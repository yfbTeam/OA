<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddWorkFlow_show_lc.aspx.cs" Inherits="xyoa.WorkFlowSysMag.AddWorkFlow_show_lc" %>
<html>
<head id="Head1" runat="server">
     <title>工作流设置</title>
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script language="JavaScript">
function copy_main()
{
  set_main.document.execCommand('selectall');
  set_main.document.execCommand('copy');
  alert("流程图已复制到剪贴板！");
}
    </script>

</head>
<body class="newbody" onload="select_type()">
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
                                                        <td width="97%" valign="bottom" >
                                                            流程预览&nbsp;&nbsp;-->&nbsp;&nbsp;<strong><font color=red>当前步骤：<%=Request.QueryString["DqNodeName"]%></font></strong></td>
                                                     
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td width="33%">
                                                                    <strong>流程预览：</strong>
                                                                    <input id="txst" type="button" value="图形视图" class="button_css" onclick="set_main.location='AddWorkFlow_show_lc_tx.aspx?FormId=<%=Request.QueryString["FormId"] %>&DqNodeId=<%=Request.QueryString["DqNodeId"] %>'" />
                                                                    <input id="Button1" type="button" value="列表视图" class="button_css" onclick="set_main.location='AddWorkFlow_show_lc_lb.aspx?FormId=<%=Request.QueryString["FormId"] %>&DqNodeId=<%=Request.QueryString["DqNodeId"] %>'" />
                                                                </td>
                                                                <td width="67%" align="right">
                                                                    <input id="Button2" type="button" value="刷  新" class="button_css" onclick="set_main.location.reload();" />
                                                                    <input id="Button4" type="button" value="打  印" class="button_css" onclick="set_main.document.execCommand('Print');"
                                                                        title="直接打印流程页面" />
                                                                    <input id="Button5" type="button" value="复  制" class="button_css" onclick="copy_main();" />
                                                                    <input id="Button6" type="button" value="关  闭" class="button_css" onclick="window.close();" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="24">
                                                        <iframe border="0" name="set_main" marginwidth="1" marginheight="1" src="AddWorkFlow_show_lc_tx.aspx?FormId=<%=Request.QueryString["FormId"] %>&DqNodeId=<%=Request.QueryString["DqNodeId"] %>"
                                                            frameborder="0" width="100%" height="500" bordercolor="#EDEDED"></iframe>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <input id="Button3" class="button_css" onclick="javascript:window.close()" type="button"
                                                                    value="关闭窗口" /></font>&nbsp;</div>
                                                    </td>
                                                </tr>
                                                <tr id="Tr1">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    &nbsp;开始步骤&nbsp;
                                                                </td>
                                                                <td width="20" bgcolor="#00EE00">
                                                                    &nbsp;
                                                                </td>
                                                                  <td>
                                                                    &nbsp; &nbsp; &nbsp;
                                                                </td>
                                                                <td>
                                                                    &nbsp;当前步骤&nbsp;
                                                                </td>
                                                                <td width="20" bgcolor="#FFFF00">
                                                                    &nbsp;
                                                                </td>
                                                                  <td>
                                                                    &nbsp; &nbsp; &nbsp;
                                                                </td>
                                                                <td>
                                                                    &nbsp;结束步骤&nbsp;
                                                                </td>
                                                                <td width="20" bgcolor="#F4A8BD">
                                                                    &nbsp;
                                                                </td>
                                                                  <td>
                                                                    &nbsp; &nbsp; &nbsp;
                                                                </td>
                                                                <td>
                                                                    &nbsp;其他步骤&nbsp;
                                                                </td>
                                                                <td width="20" bgcolor="#EEEEEE">
                                                                    &nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
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