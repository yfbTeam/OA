<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Xueshengxinxi_qtxx_update.aspx.cs" Inherits="xyoa.SchTable.Xueji.Xueshengxinxi.Xueshengxinxi_qtxx_update" %>

<html>

<script>
function chknull()
{
   if(document.getElementById('XsId').value=='')
    {
    alert('学生姓名不能为空');
    form1.XsId.focus();
    return false;
    }	

    showwait();	
 
}  

function _change()
{
   var text=form1.PingyuS.value;
   if (text !="")
   {
       document.getElementById('Pingyu').value +="\r\n"+text;
   }
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
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top" style="height: 40px">
                                <div id="printshow2">
                                    <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                        cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="height: 26px;">
                                                <button class="btn4off" type="button">
                                                    <font class="shadow_but">其他信息</font></button>
                                            </td>
                                            <td style="height: 26px" align="right">
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
                                <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                        <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            <font color="red">※</font>学期：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:DropDownList ID="Xueqi" runat="server" Enabled=false>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            学段：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:DropDownList ID="Xueduan" runat="server">
                                                <asp:ListItem>上学期</asp:ListItem>
                                                <asp:ListItem>下学期</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                             <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            <font color="red">※</font>学生姓名：</td>
                                        <td class="newtd2" height="17" width="45%" colspan="3">
                                            <asp:Label ID="XsId" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            校车号：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Xiaochehao" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            延长班：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Yanchangban" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            提高班：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Tigaoban" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            体锻达标：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Dabiao" runat="server" Width="100%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            艺校：</td>
                                        <td class="newtd2" height="17" width="95%" colspan="7">
                                            <asp:TextBox ID="Yixiao" runat="server" Width="100%"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            兴趣乐园：</td>
                                        <td class="newtd2" height="17" width="95%" colspan="7">
                                            <asp:TextBox ID="Leyuan" runat="server" Width="100%"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            其它：</td>
                                        <td class="newtd2" height="17" width="95%" colspan="7">
                                            <asp:TextBox ID="Qita" runat="server" Width="100%"></asp:TextBox></td>
                                    </tr>
                                    <tr id="printshow3">
                                        <td align="center" class="newtd2" colspan="8" height="26" width="33%">
                                            <div align="center">
                                                <font face="宋体">
                                                    <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                    <input id="Button3" type="button" value="返 回" class="button_css" onclick="history.go(-1)" />
                                                </font>
                                            </div>
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
