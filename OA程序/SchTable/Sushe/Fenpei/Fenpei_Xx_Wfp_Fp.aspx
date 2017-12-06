<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Fenpei_Xx_Wfp_Fp.aspx.cs"
    Inherits="xyoa.SchTable.Sushe.Fenpei.Fenpei_Xx_Wfp_Fp" %>

<html>

<script>
function chknull()
{
   if(document.getElementById('Sushe').value=='')
    {
    alert('宿舍信息不能为空');
    form1.Sushe.focus();
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
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                            <font color="red">※</font>学生姓名：</td>
                                        <td class="newtd2" colspan="3" height="17" width="85%">
                                            <asp:Label ID="FbName" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                            公寓信息：</td>
                                        <td class="newtd2" height="17" width="35%">
                                            <asp:DropDownList ID="Gongyu" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Gongyu_SelectedIndexChanged" Width="100%">
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                            <font color="red">※</font>分配宿舍：</td>
                                        <td class="newtd2" height="17" width="35%">
                                            <asp:DropDownList ID="Sushe" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="Sushe_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr >
                                        <td  class="newtd2" colspan="4" height="26">
                                            <asp:Label ID="Label1" runat="server"  ForeColor=red></asp:Label>
                                        </td>
                                    </tr>
                                    
                                    <tr id="printshow3">
                                        <td align="center" class="newtd2" colspan="4" height="26">
                                            <div align="center">
                                                <font face="宋体">
                                                    <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                    
                                                      <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css" OnClick="Button2_Click" />
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
            <asp:TextBox ID="Geshu" runat="server" Visible=false></asp:TextBox>
            <asp:TextBox ID="Shenyu" runat="server" Visible=false></asp:TextBox>
            </table>
    </form>
</body>
</html>
