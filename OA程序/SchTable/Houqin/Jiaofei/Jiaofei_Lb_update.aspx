<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Jiaofei_Lb_update.aspx.cs"
    Inherits="xyoa.SchTable.Houqin.Jiaofei.Jiaofei_Lb_update" %>

<html>

<script>
function chknull()
{

   if(document.getElementById('Jine').value=='')
    {
    alert('缴费金额不能为空');
    form1.Jine.focus();
    return false;
    }	
    
    
   if(document.getElementById('Leixing').value=='')
    {
    alert('缴费类型不能为空');
    form1.Leixing.focus();
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
<base target=_self />	
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
                            <td height="35">
                                <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                    <tr>
                                        <td align="center" class="newtd2" colspan="4" style="height: 26px">
                                            <b>学生信息</b></td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                            <font color="red">※</font>学生姓名：</td>
                                        <td class="newtd2" colspan="3" height="17" width="85%">
                                            <asp:Label ID="XsId" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                            <font color="red">※</font>学期：</td>
                                        <td class="newtd2" height="17" width="35%">
                                            <asp:Label ID="Xueqi" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                            <font color="red">※</font>学期段：</td>
                                        <td class="newtd2" height="17" width="35%">
                                            <asp:Label ID="Xueduan" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                            <font color="red">※</font>缴费金额：</td>
                                        <td class="newtd2" height="17" width="35%">
                                            <asp:TextBox ID="Jine" runat="server" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='1';};"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                            <font color="red">※</font>缴费类型：</td>
                                        <td class="newtd2" height="17" width="35%">
                                            <asp:DropDownList ID="Leixing" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="printshow3">
                                        <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                            <div align="center">
                                                <font face="宋体">
                                                    <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                    <input id="Button2" type="button" value="关 闭" onclick="window.close();" class="button_css" />
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
