<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyYinZhang_update.aspx.cs"
    Inherits="xyoa.MyWork.YinZhang.MyYinZhang_update" %>

<html>

<script language="javascript" type="text/javascript">

function checkForm()
{

    if(document.getElementById('Password').value=='')
    {
        alert('旧密码不能为空');
        return false;
    }
    			
    if(document.getElementById('NewPassword').value=='')
    {
        alert('新密码不能为空');
        return false;
    }



    if(document.getElementById('NewPassword').value!=document.getElementById('NewPassword_c').value)
    {
        alert('确认密码和新密码不一样');
        return false;
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
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
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
                                                            <a href="MyYinZhang.aspx">我的印章</a>
                                                            >> 修改印章</td>
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
                                                                <font class="shadow_but">我的印章</font></button></td>
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
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="left" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        印章只允许修改密码，如果需要修改其他资料请删除原印章重新提交。如果忘记密码请联系管理员重新设置。</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                      印章：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:Image ID="Newname" runat="server" /></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                       印章名称：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:Label ID="Name" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        <font color="red">※</font>旧密码：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:TextBox ID="Password" runat="server" Width="100%" TextMode="Password"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>新密码：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:TextBox ID="NewPassword" runat="server" Width="100%" TextMode="Password"></asp:TextBox></td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>确认新密码：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:TextBox ID="NewPassword_c" runat="server" TextMode="Password" Width="100%"></asp:TextBox></td>
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
