<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Xueqi_add.aspx.cs" Inherits="xyoa.SchTable.SysMag.Xueqi.Xueqi_add" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Mingcheng').value=='')
    {
        alert('学期名称不能为空');
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

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body class="newbody">
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
                                            </td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="Xueqi.aspx">学期设置</a> >> 新增学期设置</td>
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
                                <div id="printshow2">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                            </td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">学期设置</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17" style="height: 441px">
                                        </td>
                                        <td valign="top" style="height: 441px">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>学期名称：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:DropDownList ID="Mingcheng" runat="server">
                                                            <asp:ListItem>2013-2014</asp:ListItem>
                                                            <asp:ListItem>2014-2015</asp:ListItem>
                                                            <asp:ListItem>2015-2016</asp:ListItem>
                                                            <asp:ListItem>2016-2017</asp:ListItem>
                                                            <asp:ListItem>2017-2018</asp:ListItem>
                                                            <asp:ListItem>2018-2019</asp:ListItem>
                                                            <asp:ListItem>2019-2020</asp:ListItem>
                                                            <asp:ListItem>2020-2021</asp:ListItem>
                                                            <asp:ListItem>2021-2022</asp:ListItem>
                                                            <asp:ListItem>2022-2023</asp:ListItem>
                                                            <asp:ListItem>2023-2024</asp:ListItem>
                                                            <asp:ListItem>2024-2025</asp:ListItem>
                                                            <asp:ListItem>2025-2026</asp:ListItem>
                                                            <asp:ListItem>2026-2027</asp:ListItem>
                                                            <asp:ListItem>2027-2028</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>启用的学段：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:CheckBoxList ID="QiyongXueduan" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True">小学</asp:ListItem>
                                                            <asp:ListItem Selected="True">初中</asp:ListItem>
                                                            <asp:ListItem Selected="True">高中</asp:ListItem>
                                                        </asp:CheckBoxList></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css"
                                                                    OnClick="Button2_Click" />
                                                            </font>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17" style="height: 441px">
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
