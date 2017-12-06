<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Emailprv_add.aspx.cs" Inherits="xyoa.MyWork.MySet.Emailprv_add" %>

<html>

<script>
function chknull()
{


if(document.getElementById('EmailName').value=='')
{
alert('邮箱名称不能为空');
form1.EmailName.focus();
return false;
}	

if(document.getElementById('EmailAdd').value=='')
{
alert('邮件地址不能为空');
form1.EmailAdd.focus();
return false;
}	

if(document.getElementById('EmailAdd').value!='')
{
var objRe = /\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
if(!objRe.test(document.getElementById('EmailAdd').value))
{
alert('邮件地址格式不正确');
form1.EmailAdd.focus();
return false;
}

}  



if(document.getElementById('EmailUserName').value=='')
{
alert('邮件用户名不能为空');
form1.EmailUserName.focus();
return false;
}	

if(document.getElementById('EmailPassword').value=='')
{
alert('邮件密码不能为空');
form1.EmailPassword.focus();
return false;
}	

if(document.getElementById('Pop3').value=='')
{
alert('POP3服务器不能为空');
form1.Pop3.focus();
return false;
}	

if(document.getElementById('Smtp').value=='')
{
alert('SMTP服务器不能为空');
form1.Smtp.focus();
return false;
}		
	
if(document.getElementById('MainNet').value=='')
{
alert('邮件主页不能为空');
form1.MainNet.focus();
return false;
}	
		
			
			
if(document.getElementById('MainNet').value!='')
{
var objRe =/http:\/\/([\w-]+\.)+[\w-]+(\/[\w- ./?%&=]*)?/
if(!objRe.test(document.getElementById('MainNet').value))
{
alert('邮件主页格式不正确');
form1.MainNet.focus();
return false;
}

}  





    showwait();					
}


</script>

<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="23" border="0" cellpadding="0" cellspacing="0">
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
                                                            <a href="/main_d.aspx" class="line_b">工作台</a> >> <a href="Emailprv.aspx">邮件参数设置</a>
                                                            >> 新增邮件参数</td>
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
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">邮件参数</font></button></td>
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
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        <font color="red">※</font>邮箱名称：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:TextBox ID="EmailName" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                       <font color="red">※</font>邮件地址：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:TextBox ID="EmailAdd" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>邮件用户名：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:TextBox ID="EmailUserName" runat="server" Width="100%"></asp:TextBox></td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>邮件密码：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:TextBox ID="EmailPassword" runat="server" TextMode="Password" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>POP3服务器：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:TextBox ID="Pop3" runat="server" Width="100%"></asp:TextBox></td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>SMTP服务器：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:TextBox ID="Smtp" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="返 回" OnClick="Button2_Click" /></font></div>
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
