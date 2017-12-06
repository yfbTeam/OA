<%@ Page Language="C#" AutoEventWireup="true" Codebehind="DIYForm_add_update.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.DIYForm_add_update" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
        alert('控件名称不能为空');
        form1.Name.focus();
        return false;
    }	
    showwait();	
}  
</script>

<head id="Head1" runat="server">
    <title>字段修改</title>
    <base target="_self" />
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
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        控件名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Name" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        字段类型：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="Type" runat="server" Width="100%">
                                                            <asp:ListItem>[常规型]</asp:ListItem>
                                                            <asp:ListItem>[数字型]</asp:ListItem>
                                                            <asp:ListItem>[印章域]</asp:ListItem>
                                                            <asp:ListItem>[列表]</asp:ListItem>
                                                            <asp:ListItem>[单选框列表]</asp:ListItem>
                                                            <asp:ListItem>[复选框列表]</asp:ListItem>
                                                            <asp:ListItem>[表单域]</asp:ListItem>
                                                            <asp:ListItem>[关联办理意见]</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="Panel1" runat="server">
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                            <asp:Label ID="Label1" runat="server"></asp:Label></td>
                                                        <td class="newtd2" height="17" colspan="3" width="85%">
                                                            <asp:TextBox ID="sqlstr" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <asp:Panel ID="Panel2" runat="server">
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                            规则：</td>
                                                        <td class="newtd2" height="17" colspan="3" width="85%">
                                                            可以使用“+、-、*、/”运算，也可以用“(”、“)”，例如“(字段名称+字段名称)*字段名称/100”
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <input id="Button3" type="button" value="关 闭" class="button_css" onclick="window.close()" /></font></div>
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
