<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkTime.aspx.cs" Inherits="xyoa.MyWork.WorkTime.WorkTime" %>

<html>

<script>
function dj()
{
    if (!confirm("是否确定要登记？"))
    return false;
}
</script>

<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/DateSelect.js" type="text/javascript"></script>

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
                                                            上下班登记</td>
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
                                                                <font class="shadow_but">上下班登记</font></button></td>
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
                                            <table align="center" class="nextpage" border="0" cellpadding="4" cellspacing="1"
                                                width="100%">
                                                <tr style="<%=ViewState["css1"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="25%">
                                                        第一次<font color="#ff0000"><asp:Label ID="DjType_1" runat="server"></asp:Label></font>登记时间：</td>
                                                    <td class="newtd2" height="17" width="75%">
                                                        <asp:TextBox ID="DjTime_1" runat="server" ReadOnly="True" Width="75%"></asp:TextBox><asp:Button
                                                            ID="Button2" runat="server" Text="登  记" OnClick="Button2_Click"></asp:Button></td>
                                                </tr>
                                                <tr style="<%=ViewState["css2"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="25%">
                                                        第二次<font color="#ff0000"><asp:Label ID="DjType_2" runat="server"></asp:Label></font>登记时间：</td>
                                                    <td class="newtd2" height="17" width="75%">
                                                        <asp:TextBox ID="DjTime_2" runat="server" ReadOnly="True" Width="75%"></asp:TextBox><asp:Button
                                                            ID="Button3" runat="server" Text="登  记" OnClick="Button3_Click"></asp:Button></td>
                                                </tr>
                                                <tr style="<%=ViewState["css3"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="25%">
                                                        第三次<font color="#ff0000"><asp:Label ID="DjType_3" runat="server"></asp:Label></font>登记时间：</td>
                                                    <td class="newtd2" height="17" width="75%">
                                                        <asp:TextBox ID="DjTime_3" runat="server" ReadOnly="True" Width="75%"></asp:TextBox><asp:Button
                                                            ID="Button4" runat="server" Text="登  记" OnClick="Button4_Click"></asp:Button></td>
                                                </tr>
                                                <tr style="<%=ViewState["css4"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="25%">
                                                        第四次<font color="#ff0000"><asp:Label ID="DjType_4" runat="server"></asp:Label></font>登记时间：</td>
                                                    <td class="newtd2" height="17" width="75%">
                                                        <asp:TextBox ID="DjTime_4" runat="server" ReadOnly="True" Width="75%"></asp:TextBox><asp:Button
                                                            ID="Button5" runat="server" Text="登  记" OnClick="Button5_Click"></asp:Button></td>
                                                </tr>
                                                <tr style="<%=ViewState["css5"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="25%">
                                                        第五次<font color="#ff0000"><asp:Label ID="DjType_5" runat="server"></asp:Label></font>登记时间：</td>
                                                    <td class="newtd2" height="17" width="75%">
                                                        <asp:TextBox ID="DjTime_5" runat="server" ReadOnly="True" Width="75%"></asp:TextBox><asp:Button
                                                            ID="Button6" runat="server" Text="登  记" OnClick="Button6_Click"></asp:Button></td>
                                                </tr>
                                                <tr style="<%=ViewState["css6"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="25%">
                                                        第六次<font color="#ff0000"><asp:Label ID="DjType_6" runat="server"></asp:Label></font>登记时间：</td>
                                                    <td class="newtd2" height="17" width="75%">
                                                        <asp:TextBox ID="DjTime_6" runat="server" ReadOnly="True" Width="75%"></asp:TextBox><asp:Button
                                                            ID="Button7" runat="server" Text="登  记" OnClick="Button7_Click"></asp:Button></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体"></font>&nbsp;</div>
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

        <script type="text/javascript">
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

        <asp:Label ID="DjType_1_u" runat="server"></asp:Label>
        <asp:Label ID="DjType_2_u" runat="server"></asp:Label>
        <asp:Label ID="DjType_3_u" runat="server"></asp:Label>
        <asp:Label ID="DjType_4_u" runat="server"></asp:Label>
        <asp:Label ID="DjType_5_u" runat="server"></asp:Label>
        <asp:Label ID="DjType_6_u" runat="server"></asp:Label>
        <asp:Label ID="jxtime" runat="server" Visible="false"></asp:Label>
    </form>
</body>
</html>
