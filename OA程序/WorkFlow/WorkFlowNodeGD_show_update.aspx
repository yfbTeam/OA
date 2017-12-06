<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowNodeGD_show_update.aspx.cs"
    Inherits="xyoa.WorkFlow.WorkFlowNodeGD_show_update" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
    <base target="_self" />

    <script src="/js/public.js" type="text/javascript"></script>
<script>
	window.resizeTo(screen.availWidth, screen.availHeight);
	window.moveTo(0, 0);
function closefrom()
{
    msg='确定要修改表单内容？';
    if(window.confirm(msg))
    {
      
    }
    else
    {
        return false;
    }
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
                                                </td>
                                            <td valign="top">
                                                     <FCKeditorV2:FCKeditor ID="d_content" runat="server" Height="500px" ToolbarSet="Qiupeng">
                                                        </FCKeditorV2:FCKeditor>
                                            </td>
                                            <td width="17">
                                                </td>
                                        </tr>
                                        .
                                        <tr>
                                            <td width="17">
                                                </td>
                                            <td valign="top" align=center><br>
                                                <asp:Button ID="Button1" runat="server" Text="修 改" OnClick="Button1_Click" />
                                                <input id="Button2" type="button" value="关 闭" onclick="window.close()"/>
                                            </td>
                                            <td width="17">
                                                </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
