<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GongZuoLiu.aspx.cs" Inherits="xyoa.WorkFlowSysMag.GongZuoLiu" %>

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

function  openwwfadd()  
{
    //window.open ("WorkFlowName_show_add_node_add.aspx?FormId=<%=Request.QueryString["FormId"] %>", "_blank", "height=670, width=820,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")

  var num = Math.random();
    window.showModalDialog("WorkFlowName_show_add_node_add.aspx?FormId=<%=Request.QueryString["FormId"] %>&tmp=" + num + "", "window", "dialogWidth:820px;DialogHeight=670px;status:no;scroll=yes;help:no");
    set_main.location.href = set_main.location.href;
}

    </script>

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
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            设置<font color="red"><%=ViewState["LeixingName"] %></font>工作流</td>
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tr>
                                                                <td width="33%">
                                                                    <strong>设计视图：</strong>
                                                                    <input id="txst" type="button" value="图形视图" class="button_css" onclick="set_main.location='WorkFlowName_show_add_node_show.aspx?FormId=<%=Request.QueryString["FormId"] %>'" />
                                                                    <input id="Button1" type="button" value="列表视图" class="button_css" onclick="set_main.location='WorkFlowName_show_add_node_lb.aspx?FormId=<%=Request.QueryString["FormId"] %>'" />
                                                                </td>
                                                                <td width="67%" align="right">
                                                                    <input id="Button8" type="button" value="新增步骤" onclick="openwwfadd();" class="button_css" />
                                                                    <input id="Button2" type="button" value="刷  新" class="button_css" onclick="set_main.location.reload();" />
                                                                    <input id="Button4" type="button" value="打  印" class="button_css" onclick="set_main.document.execCommand('Print');"
                                                                        title="直接打印流程页面" />
                                                                    <input id="Button5" type="button" value="复  制" class="button_css" onclick="copy_main();" />
                                                                     <asp:Button ID="Button3" runat="server" Text="返 回"  CssClass="button_css" OnClick="Button3_Click"/>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="24">
                                                        <iframe border="0" name="set_main" marginwidth="1" marginheight="1" src="WorkFlowName_show_add_node_show.aspx?FormId=<%=Request.QueryString["FormId"] %>"
                                                            frameborder="0" width="100%" height="500" bordercolor="#EDEDED"></iframe>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                               </font>&nbsp;</div>
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
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
         <script language="javascript">	

            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>
    </form>
</body>
</html>