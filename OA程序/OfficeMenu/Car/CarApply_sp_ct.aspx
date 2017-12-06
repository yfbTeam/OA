<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CarApply_sp_ct.aspx.cs"
    Inherits="xyoa.OfficeMenu.Car.CarApply_sp_ct" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
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
                                                车辆名称：<%=ViewState["CarName"] %>
                                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                    AutoGenerateColumns="False" BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None"
                                                    BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None" PageSize="12"
                                                    Style="font-size: 12px" Width="97%" OnRowDataBound="GridView1_RowDataBound">
                                                    <PagerSettings Visible="False" />
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Drivers" HeaderText="驾驶员" SortExpression="Drivers">
                                                            <ItemStyle Wrap="False" />
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Starttime" HeaderText="开始时间" SortExpression="Starttime">
                                                            <ItemStyle Wrap="False" />
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Endtime" HeaderText="结束时间" SortExpression="Endtime">
                                                            <ItemStyle Wrap="False" />
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="车辆状态" SortExpression="State">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemTemplate>
                                                                <%# ((Eval("State").ToString().Replace("1", "待审批").Replace("2", "已通过").Replace("3", "未通过").Replace("4", "使用中").Replace("5", "已结束").Replace("6", "终止审批")))%>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="False" Width="50px" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="审批状态" SortExpression="LcZhuangtai">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemTemplate>
                                                                <%# ((Eval("LcZhuangtai").ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批")))%>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="False" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="申请人">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemTemplate>
                                                                <a href='javascript:void(0)' onclick='senduser("<%# DataBinder.Eval(Container.DataItem, "Username")%>")'>
                                                                    <%# DataBinder.Eval(Container.DataItem, "Realname")%>
                                                                </a>
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
