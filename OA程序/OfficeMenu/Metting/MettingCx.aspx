<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MettingCx.aspx.cs" Inherits="xyoa.OfficeMenu.Metting.MettingCx" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script>
function check_form()
{
    showwait();	
}
    </script>

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
                                                            会议查询
                                                        </td>
                                                        <td width="16%">
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17" style="height: 40px">
                                            </td>
                                        <td valign="top" style="height: 40px">
                                            <div id="printshow2">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="height: 26px;">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">会议查询</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td width="17" style="height: 40px">
                                            </td>
                                    </tr>
                                </table>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <div>
                                                <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                    <tr>
                                                        <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                            <b>查询信息</b></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            会议名称：</td>
                                                        <td class="newtd2" height="17" width="83%" colspan="3">
                                                            <asp:TextBox ID="Name" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            描述：</td>
                                                        <td class="newtd2" height="17" width="83%" colspan="3">
                                                            <asp:TextBox ID="Introduction" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            出席人员：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:TextBox ID="NbPeopleName" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            会议室：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:DropDownList ID="MettingName" runat="server" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            已确认参加人员：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:TextBox ID="CjRealname" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            会议开始时间：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:TextBox ID="Starttime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                            至<asp:TextBox ID="Endtime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            会议状态：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:DropDownList ID="State" runat="server" Width="100%">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem Value="1">正在审批</asp:ListItem>
                                                                <asp:ListItem Value="2">已发起</asp:ListItem>
                                                                <asp:ListItem Value="3">进行中</asp:ListItem>
                                                                <asp:ListItem Value="4">结束</asp:ListItem>
                                                                <asp:ListItem Value="5">终止</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            流程状态：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:DropDownList ID="LcZhuangtai" runat="server" Width="100%">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem Value="1">等待办理</asp:ListItem>
                                                                <asp:ListItem Value="2">正在办理</asp:ListItem>
                                                                <asp:ListItem Value="3">通过审批</asp:ListItem>
                                                                <asp:ListItem Value="4">终止审批</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="newtd2" width="33%" style="height: 17px" colspan="4" align="center">
                                                            <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="查询结果" OnClick="Button2_Click" /></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            &nbsp;
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
        <asp:TextBox ID="Username" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	
          
            
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
