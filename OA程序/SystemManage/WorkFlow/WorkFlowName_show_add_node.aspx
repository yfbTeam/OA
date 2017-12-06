<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_add_node.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.WorkFlowName_show_add_node" %>

<html>
<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>
<script language="JavaScript">
function copy_main()
{
  parent.set_main.document.execCommand('selectall');
  parent.set_main.document.execCommand('copy');
  alert("流程图已复制到剪贴板！");
}

function  setyz()  
{
    var num = Math.random();
    window.showModalDialog("WorkFlowName_show_add_yz.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"] %>&tmp=" + num + "", "window", "dialogWidth:600px;DialogHeight=460px;status:no;scroll=yes;help:no");
    set_main.location.href = set_main.location.href;
    
    //window.open ("WorkFlowName_show_add_yz.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"] %>", "_blank", "height=460, width=600,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}

function  openwwfadd()  
{
    var num = Math.random();
    window.showModalDialog("WorkFlowName_show_add_node_add.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"] %>&tmp=" + num + "", "window", "dialogWidth:820px;DialogHeight=670px;status:no;scroll=yes;help:no");
    set_main.location.href = set_main.location.href;
    
    //window.open ("WorkFlowName_show_add_node_add.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"] %>", "_blank", "height=670, width=820,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
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
                                                        <td width="81%" valign="bottom">
                                                            设置工作流</td>
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
                                                                    <strong>设计视图：</strong>
                                                                    <input id="txst" type="button" value="图形视图" class="button_css" onclick="set_main.location='WorkFlowName_show_add_node_show.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"] %>'" />
                                                                    <input id="Button1" type="button" value="列表视图" class="button_css" onclick="set_main.location='WorkFlowName_show_add_node_lb.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"] %>'" />
                                                                </td>
                                                                <td width="67%" align="right">
                                                                <input id="Button8" type="button" value="新增步骤" onclick="openwwfadd();" class="button_css"/>
                                                                <input id="Button7" type="button" value="电子印章" onclick="setyz();" class="button_css"/>
                                                                    <input id="Button2" type="button" value="刷  新" class="button_css" onclick="set_main.location.reload();" />
                                                                    <input id="Button4" type="button" value="打  印" class="button_css" onclick="set_main.document.execCommand('Print');"
                                                                        title="直接打印流程页面" />
                                                                    <input id="Button5" type="button" value="复  制" class="button_css" onclick="copy_main();" />
                                                                  <asp:Button ID="Button6" runat="server" Text="返  回" CssClass="button_css" OnClick="Button5_Click" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="24">
                                                        <iframe border="0" name="set_main" marginwidth="1" marginheight="1" src="WorkFlowName_show_add_node_show.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"] %>"
                                                            frameborder="0" width="100%" height="500" bordercolor="#EDEDED"></iframe>
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
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>
