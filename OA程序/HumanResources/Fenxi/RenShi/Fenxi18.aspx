<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fenxi18.aspx.cs" Inherits="xyoa.HumanResources.Fenxi.RenShi.Fenxi18" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
                                                            员工调动/月度分析
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
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <div id="Div1" class="mainDiv">
                                                <div>
                                                    <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                        <tr>
                                                            <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                                <b>统计信息</b></td>
                                                        </tr>
                                                        <tr>
                                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                                统计月度：</td>
                                                            <td class="newtd2" height="17" colspan="3" width="83%">
                                                                <asp:DropDownList ID="SYear" runat="server">
                                                                </asp:DropDownList>年<asp:DropDownList ID="SMonth" runat="server">
                                                                </asp:DropDownList>月&nbsp;<strong>至</strong>&nbsp;
                                                                <asp:DropDownList ID="EYear" runat="server">
                                                                </asp:DropDownList>年<asp:DropDownList ID="EMonth" runat="server">
                                                                </asp:DropDownList>月
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="newtd2" width="33%" style="height: 17px" colspan="4" align="center">
                                                                <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="统计结果" OnClick="Button2_Click" /></td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                &nbsp;
                                            </div>
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