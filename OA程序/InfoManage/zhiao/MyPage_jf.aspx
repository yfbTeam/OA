<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyPage_jf.aspx.cs" Inherits="xyoa.InfoManage.zhiao.MyPage_jf" %>

<html>
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
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox></td>
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
                                            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                                GridLines="None" Width="372px" PageSize="5" ShowFooter="True">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <HeaderTemplate>
                                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                                <tr>
                                                                    <td align="center" class="newtd1" height="17" nowrap="nowrap" width="34%">
                                                                        相关操作</td>
                                                                    <td align="center" class="newtd1" height="17" width="33%">
                                                                        计算公式
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                                <tr>
                                                                    <td align="center" class="newtd2" height="17" nowrap="nowrap" width="34%">
                                                                        <%# Eval("Leibie")%></td>
                                                                    <td class="newtd2" height="17" width="33%">
                                                                        <%# Eval("gongsi") %><%# Eval("Fenshu") %>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                                <PagerStyle BackColor="#FFFFC0" BorderColor="Blue" BorderStyle="Double" HorizontalAlign="Right" />
                                            </asp:GridView>
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

    </form>
</body>
</html>
