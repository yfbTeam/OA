<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Chaxun_ListBj.aspx.cs"
    Inherits="xyoa.SchTable.Chengji.Chaxun.Chaxun_ListBj" %>

<html>

<script>
function chknull()
{
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
                                <asp:Panel ID="Panel1" runat="server">
                                    <div align="center">
                                        <asp:Label ID="Label1" runat="server" Text="请先选择班级" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server">
                                    <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                学期：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Xueqi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Xueqi_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                学期段：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Xueduan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Xueduan_SelectedIndexChanged">
                                                    <asp:ListItem>上学期</asp:ListItem>
                                                    <asp:ListItem>下学期</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                考试类型：</td>
                                            <td class="newtd2" height="17" width="45%" colspan="3">
                                                <asp:DropDownList ID="Leixing" runat="server">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td class="newtd2" colspan="8" height="17">
                                                <asp:CheckBoxList ID="Kemu" runat="server" RepeatColumns="10" RepeatDirection="Horizontal">
                                                </asp:CheckBoxList>
                                                <input id="Button3" type="button" value="全选" onclick='checkAll()' />
                                                <input id="Button4" type="button" value="反选" onclick='fanAll()' />
                                            </td>
                                        </tr>
                                        <tr id="printshow3">
                                            <td align="center" class="newtd2" colspan="8" height="26" width="33%">
                                                <asp:Button ID="Button1" runat="server" Text="查 询" CssClass="button_css" OnClick="Button1_Click" />
                                                <asp:Button ID="Button2" runat="server" Text="导 出" CssClass="button_css" OnClick="Button2_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                    <br>
                                    <div align="center">
                                        <asp:Label ID="LTongji" runat="server"></asp:Label>
                                    </div>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
