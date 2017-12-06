<%@ Page Language="C#" AutoEventWireup="true" Codebehind="username_update.aspx.cs"
    Inherits="xyoa.SystemManage.User.username_update" %>

<html>

<script>
function chknull()
{


    if(document.getElementById('Realname').value=='')
    {
    alert('用户姓名不能为空');
    form1.Realname.focus();
    return false;
    }	

    if(document.getElementById('BuMenId').value=='')
    {
    alert('部门不能为空');
    form1.BuMenId.focus();
    return false;
    }	


    if(document.getElementById('JueseId').value=='')
    {
    alert('角色不能为空');
    form1.JueseId.focus();
    return false;
    }	


    if(document.getElementById('Zhiweiid').value=='')
    {
    alert('职位不能为空');
    form1.Zhiweiid.focus();
    return false;
    }	

    if(document.getElementById('paixu').value=='')
    {
        alert('排序号不能为空，没有请填写为0');
        form1.paixu.focus();
        return false;
    }	
 
    if(document.getElementById('paixu').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('paixu').value))
        {
            alert("排序号只能为数字");
            form1.paixu.focus();
            return false;
        }
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
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="username.aspx">用户管理</a> >> 修改用户信息</td>
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
                                <div id="printshow2">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4on" onclick="javascript:window.location='username_update.aspx?id=<%=Request.QueryString["id"]%>';showwait();"
                                                                type="button">
                                                                <font class="shadow_but">用户信息</font></button>
                                                            <button class="btn4off" onclick="javascript:window.location='username_updateps.aspx?id=<%=Request.QueryString["id"]%>';showwait();"
                                                                type="button">
                                                                <font class="shadow_but">密码修改</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>用户信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>真实姓名：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Realname" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        用户名：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Username" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>所属部门：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:DropDownList ID="BuMenId" runat="server" Width="100%">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        <font color="red">※</font>知识堂积分：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="jifen" runat="server" Width="100%" MaxLength="2000"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>所属角色：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="JueseId" runat="server" Width="100%">
                                                        </asp:DropDownList></td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>所属职位：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Zhiweiid" runat="server" Width="100%">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        <font color="red">※</font>排序号：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="paixu" runat="server" Width="100%" MaxLength="2000"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        生日：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:TextBox ID="Bothday" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                       
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        Email：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Email" runat="server" Width="100%"></asp:TextBox></td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        手机号：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="MoveTel" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        性别：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:RadioButtonList ID="Sex" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="男" Selected="True">男</asp:ListItem>
                                                            <asp:ListItem Value="女">女</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        允许登陆：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:RadioButtonList ID="Iflogin" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                                                            <asp:ListItem Value="0">否</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr class="" id="nextrs23">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        用户相片：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:Image ID="Xiangpian" runat="server" Height="119px" Width="104px" />
                                                        <input id="uploadFile" runat="server" style="width: 300px" type="file" name="uploadFile" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        备注：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="Remark" runat="server" Width="100%" MaxLength="2000"></asp:TextBox>
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
        <asp:DropDownList ID="IfResponUpdate" runat="server" Width="100%" Visible="false">
            <asp:ListItem Value="1">是</asp:ListItem>
            <asp:ListItem Value="0">否</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="StardType" runat="server" Width="100%" Visible="false">
            <asp:ListItem Value="1">是</asp:ListItem>
            <asp:ListItem Value="0">否</asp:ListItem>
        </asp:DropDownList>
    </form>
</body>
</html>
