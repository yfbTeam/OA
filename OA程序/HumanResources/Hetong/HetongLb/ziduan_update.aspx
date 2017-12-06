<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ziduan_update.aspx.cs"
    Inherits="xyoa.HumanResources.Hetong.HetongLb.ziduan_update" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Mingcheng').value=='')
    {
        alert('字段名称不能为空');
        form1.Mingcheng.focus();
        return false;
    }	
    
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

    <base target="_self" />
</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="Bianhao" runat="server" Style="display: none"></asp:TextBox></td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>字段名称：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:TextBox ID="Mingcheng" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>字段类型：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:RadioButtonList ID="Leixing" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1">单行输入框</asp:ListItem>
                                                            <asp:ListItem Value="2">多行输入框</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp;
                                                                <input id="Button2" type="button" value="关 闭" onclick="window.close()" class="button_css" />
                                                                <asp:RadioButtonList ID="Xianshi" runat="server" RepeatDirection="Horizontal" Visible="false">
                                                                    <asp:ListItem Selected="True" Value="1">显示</asp:ListItem>
                                                                    <asp:ListItem Value="2">不显示</asp:ListItem>
                                                                </asp:RadioButtonList>
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
