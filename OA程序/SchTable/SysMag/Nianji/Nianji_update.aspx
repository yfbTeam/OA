<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Nianji_update.aspx.cs" Inherits="xyoa.SchTable.SysMag.Nianji.Nianji_update" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Xueqi').value=='')
    {
        alert('学期名称不能为空');
        form1.Xueqi.focus();
        return false;
    }	


    if(document.getElementById('NianjiMc').value=='')
    {
        alert('年级名称不能为空');
        form1.NianjiMc.focus();
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
                                                            <a href="Nianji.aspx">年级设置</a> >> 修改年级设置</td>
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
                                                                <font class="shadow_but">年级设置</font></button></td>
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
                                                        <asp:DropDownList ID="Xueqi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Xueqi_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        <font color="red">※</font>年级名称：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:DropDownList ID="NianjiMc" runat="server">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="NianjiMcC" runat="server" Visible=false></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        <font color="red">※</font>入学/毕业年级：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:RadioButtonList ID="RuxueBiye" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="入学">入学</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="中间段">中间段</asp:ListItem>
                                                            <asp:ListItem Value="毕业">毕业</asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>上学期课程：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:CheckBoxList ID="Kecheng" runat="server" RepeatDirection="Horizontal" RepeatColumns="7">
                                                        </asp:CheckBoxList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>下学期课程：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:CheckBoxList ID="KechengX" runat="server" RepeatDirection="Horizontal" RepeatColumns="7">
                                                        </asp:CheckBoxList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>考试类型：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:CheckBoxList ID="Kaoshilx" runat="server" RepeatDirection="Horizontal" RepeatColumns="7">
                                                        </asp:CheckBoxList></td>
                                                </tr>
                                                 <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>行课日程：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                     每周：<asp:DropDownList ID="Tianshu" runat="server">
                                                            <asp:ListItem Value="1">1天</asp:ListItem>
                                                            <asp:ListItem Value="2">2天</asp:ListItem>
                                                            <asp:ListItem Value="3">3天</asp:ListItem>
                                                            <asp:ListItem Value="4">4天</asp:ListItem>
                                                            <asp:ListItem Value="5" Selected="True">5天</asp:ListItem>
                                                            <asp:ListItem Value="6">6天</asp:ListItem>
                                                        </asp:DropDownList>
                                                        上午：<asp:DropDownList ID="Richeng1" runat="server">
                                                            <asp:ListItem Value="1">1节</asp:ListItem>
                                                            <asp:ListItem Value="2">2节</asp:ListItem>
                                                            <asp:ListItem Value="3">3节</asp:ListItem>
                                                            <asp:ListItem Value="4">4节</asp:ListItem>
                                                        </asp:DropDownList>下午：<asp:DropDownList ID="Richeng2" runat="server">
                                                            <asp:ListItem Value="1">1节</asp:ListItem>
                                                            <asp:ListItem Value="2">2节</asp:ListItem>
                                                            <asp:ListItem Value="3">3节</asp:ListItem>
                                                            <asp:ListItem Value="4">4节</asp:ListItem>
                                                        </asp:DropDownList>晚上：<asp:DropDownList ID="Richeng3" runat="server">
                                                            <asp:ListItem Value="0">0节</asp:ListItem>
                                                            <asp:ListItem Value="1">1节</asp:ListItem>
                                                            <asp:ListItem Value="2">2节</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;
                                                                <input id="Button3" type="button" value="返 回" class="button_css"  onclick="history.go(-1)"/>
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