<%@ Page Language="C#" AutoEventWireup="true" Codebehind="toupiaobtmanage_add.aspx.cs"
    Inherits="xyoa.InfoManage.toupiao.toupiaobtmanage_add" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('title').value=='')
    {
        alert('选项不能为空');
        form1.title.focus();
        return false;
    }	


    if(document.getElementById('color').value=='')
    {
        alert('请选择颜色');
        form1.color.focus();
        return false;
    }	
    showwait();					

}

function zxx()
{
var  wName_1;  

var num=Math.random();
wName_1=window.showModalDialog("selcolor.htm?tmp="+num+"","window", "dialogWidth:500px;DialogHeight=300px;status:no;scroll=yes;help:no");               

document.getElementById("color").value=wName_1; 
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
                                                                <font class="shadow_but">投票选项</font></button></td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>选项：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="83%">
                                                        <asp:TextBox ID="title" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>选项颜色：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="83%">
                                                        <asp:TextBox ID="color" runat="server" Width="120px"></asp:TextBox><input onclick="zxx()"
                                                            type="button" value="选择颜色"></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>所属主题：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="83%">
                                                        <asp:DropDownList ID="bigtitle" runat="server" Width="100%">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <input id="Button2" class="button_css" onclick="window.close()" type="button" value="关 闭" /></font></div>
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
