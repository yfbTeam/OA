<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowListSpYzLog.aspx.cs"
    Inherits="xyoa.WorkFlow.WorkFlowListSpYzLog" %>

<html>
<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
    <base target="_self" />

    <script src="/js/public.js" type="text/javascript"></script>

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
                                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                    AutoGenerateColumns="False" BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None"
                                                    BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None" PageSize="12"
                                                    Style="font-size: 12px" Width="97%" OnRowDataBound="GridView1_RowDataBound">
                                                    <PagerSettings Visible="False" />
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="印章使用记录">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemTemplate>
                                                                <table width="100%" border="0" cellspacing="3" cellpadding="0">
                                                                    <tr>
                                                                        <td align="center">
                                                                            <img src="/seal/<%# DataBinder.Eval(Container.DataItem, "Newname")%>" style="width: 140px;
                                                                                height: 140px" id="img1" name="img1" /></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="center">
                                                                            <b>印章名称：</b><%# DataBinder.Eval(Container.DataItem, "Name")%>
                                                                            <b>&nbsp;&nbsp;&nbsp;&nbsp;使用人：</b><%# DataBinder.Eval(Container.DataItem, "Realname")%>
                                                                            <b>&nbsp;&nbsp;&nbsp;&nbsp;IP：</b><%# DataBinder.Eval(Container.DataItem, "IpAddress") %>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<b>时间：</b><%# DataBinder.Eval(Container.DataItem, "Settime") %></td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                    <EmptyDataTemplate>
                                                        <div align="center">
                                                            <font color="white">无相关数据！</font></div>
                                                    </EmptyDataTemplate>
                                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                                </asp:GridView>
                                            </td>
                                            <td width="17">
                                                </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
