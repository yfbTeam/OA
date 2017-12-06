<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Luru_PlSdlt_update.aspx.cs"
    Inherits="xyoa.SchTable.Chengji.Luru.Luru_PlSdlt_update" %>

<html>

<script>
function chknull()
{


    
    if(document.getElementById('Riqi').value=='')
    {
        alert('考试日期不能为空');
        form1.Riqi.focus();
        return false;
    }	

    if(document.getElementById('Leixing').value=='')
    {
        alert('考试类型不能为空');
        form1.Leixing.focus();
        return false;
    }	

    if(document.getElementById('Kemu').value=='')
    {
        alert('考试科目不能为空');
        form1.Kemu.focus();
        return false;
    }	

    if(document.getElementById('Chengji').value=='')
    {
        alert('成绩不能为空');
        form1.Chengji.focus();
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

    <base target="_self" />
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
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                            学生姓名：</td>
                                        <td class="newtd2" height="17" width="35%">
                                            <asp:Label ID="XsId" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                            学期：</td>
                                        <td class="newtd2" height="17" width="35%">
                                            <asp:DropDownList ID="Xueqi" runat="server" Enabled="false">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                            学期段：</td>
                                        <td class="newtd2" height="17" width="35%">
                                            <asp:DropDownList ID="Xueduan" runat="server" Enabled="false">
                                                <asp:ListItem>上学期</asp:ListItem>
                                                <asp:ListItem>下学期</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                            <font color="red">※</font>考试日期：</td>
                                        <td class="newtd2" height="17" width="35%">
                                            <asp:TextBox ID="Riqi" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            <font color="red">※</font>考试类型：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:DropDownList ID="Leixing" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            <font color="red">※</font>考试科目：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:DropDownList ID="Kemu" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            <font color="red">※</font>成绩：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="Chengji" runat="server" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='60';};"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            是否免考：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:DropDownList ID="Miankao" runat="server">
                                                <asp:ListItem Selected="True">否</asp:ListItem>
                                                <asp:ListItem>是</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            是否缺考：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:DropDownList ID="Quekao" runat="server">
                                                <asp:ListItem Selected="True">否</asp:ListItem>
                                                <asp:ListItem>是</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            是否补考：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:DropDownList ID="Bukao" runat="server">
                                                <asp:ListItem Selected="True">否</asp:ListItem>
                                                <asp:ListItem>是</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            补考成绩：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:TextBox ID="BukaoCj" runat="server"></asp:TextBox>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            态度：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:DropDownList ID="Taidu" runat="server">
                                                <asp:ListItem Selected="True">认真</asp:ListItem>
                                                <asp:ListItem>较认真</asp:ListItem>
                                                <asp:ListItem>一般</asp:ListItem>
                                                <asp:ListItem>差</asp:ListItem>
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
