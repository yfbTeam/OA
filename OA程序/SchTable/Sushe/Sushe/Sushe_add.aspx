<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sushe_add.aspx.cs" Inherits="xyoa.SchTable.Sushe.Sushe.Sushe_add" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('JianzhuId').value=='')
    {
        alert('建筑名称不能为空');
        form1.JianzhuId.focus();
        return false;
    }	

    if(document.getElementById('Louceng').value=='')
    {
        alert('楼层不能为空');
        form1.Louceng.focus();
        return false;
    }	
    
    if(document.getElementById('Zuowei').value=='')
    {
        alert('座位数不能为空');
        form1.Zuowei.focus();
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
                                                            <a href="Sushe.aspx">宿舍管理</a> >> 新增宿舍管理</td>
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
                                                                <font class="shadow_but">宿舍管理</font></button></td>
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
                                                        <font color="red">※</font>建筑名称：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan=3>
                                                        <asp:DropDownList ID="JianzhuId" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="JianzhuId_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                  <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>楼层：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan=3>
                                                        <asp:DropDownList ID="Louceng" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="Louceng_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        房间编号：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="Bianhao" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                      <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        面积：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="Mianji" runat="server" Width="100%" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='1';};"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                      <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>座位数：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="Zuowei" runat="server" Width="100%" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='4';};">4</asp:TextBox>
                                                    </td>
                                                </tr>
                                                      <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        是否在用：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:RadioButtonList ID="Zaiyong" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True">在用</asp:ListItem>
                                                            <asp:ListItem>停用</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
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
