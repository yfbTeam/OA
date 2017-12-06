<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CarApply_zt.aspx.cs" Inherits="xyoa.OfficeMenu.Car.CarApply_zt" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script>
function chknull()
{
    if(document.getElementById('State').value=='5')
    {
        if(document.getElementById('Miles').value=='')
        {
            alert('行驶里程不能为空，没有请填写“0”');
            form1.Miles.focus();
            return false;
        }	
        
        if(document.getElementById('Miles').value!='')
        {    
            var objRe = /^[-+]?\d+(\.\d+)?$/;
            if(!objRe.test(document.getElementById('Miles').value))
            {
                alert("行驶里程只能为数字");
                form1.Miles.focus();
                return false;
            }
        }  
    }
   showwait();
}

</script>

<head id="Head1" runat="server">
    <title>修改用车申请状态</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

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
                                                                <font class="shadow_but">用车申请</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            <a href="javascript:void(0)"></a>
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
                                            <table align="center" class="nextpage" border="0" cellpadding="4" cellspacing="1"
                                                width="100%" id="tableprint">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        车辆名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="83%">
                                                        <asp:Label ID="CarId" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        开始时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Starttime" runat="server"></asp:Label></td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        结束时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Endtime" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        车辆状态：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="83%">
                                                        <asp:DropDownList ID="State" runat="server" Width="95%" onchange="aaa()">
                                                            <asp:ListItem Value="2">已通过</asp:ListItem>
                                                            <asp:ListItem Value="4">使用中</asp:ListItem>
                                                            <asp:ListItem Value="5">已结束</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="nextrs1" style="display: none">
                                                    <td class="newtd2" colspan="4" height="17" align="center">
                                                        <b>归还信息</b></td>
                                                </tr>
                                                <tr id="nextrs2" style="display: none">
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 24px">
                                                        行驶里程（公里）：</td>
                                                    <td class="newtd2" width="83%" style="height: 24px" colspan="3">
                                                        <asp:TextBox ID="Miles" runat="server" Width="99%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="nextrs3" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        备注：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="GhBeizhu" runat="server" Width="99%" Height="65px" TextMode="MultiLine"></asp:TextBox></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <asp:Button ID="Button2" runat="server" CssClass="button_css" OnClick="Button1_Click"
                                                            Text="确 定" />
                                                        <input id="Button1" type="button" value="关 闭" onclick="window.close()" class="button_css" />
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
        <script>
function aaa()
{   
    if(document.getElementById('State').value=='5')
    {
       document.getElementById('nextrs1').style.display="";
       document.getElementById('nextrs2').style.display="";
       document.getElementById('nextrs3').style.display="";
    }
    else
    {
       document.getElementById('nextrs1').style.display="none";
       document.getElementById('nextrs2').style.display="none";
       document.getElementById('nextrs3').style.display="none";
    }
}
        </script>
    </form>
</body>
</html>
