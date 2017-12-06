<%@ Page Language="C#" AutoEventWireup="true" Codebehind="admin.aspx.cs" Inherits="xyoa.SystemManage.anquan.admin" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

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
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            模块设置
                                                        </td>
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
                                                                <font class="shadow_but">模块设置</font></button></td>
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
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        快速导航：[<a href="#grsw">个人事务</a>][<a href="#ggsw">公共信息</a>][<a href="#xzbg">行政办公</a>][<a
                                                            href="#gzlc">工作流程</a>][<a href="#xxjl">互动交流</a>][<a href="#zygl">物品管理</a>][<a href="#xmgl">项目管理</a>][<a
                                                                href="#fjcx">扩展应用</a>][<a href="#xsgl">销售平台</a>][<a href="#rlzy">人力资源</a>][<a href="#xtgl">系统设置</a>]</td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px"
                                                            CellPadding="3" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                            PageSize="12" Style="font-size: 12px" Width="100%">
                                                            <PagerSettings Visible="False" />
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="模块名称">
                                                                    <ItemStyle Width="180px" HorizontalAlign="Center" />
                                                                    <HeaderStyle CssClass="newtitle" Width="180px" />
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "name") %>
                                                                        <asp:Label ID="Lid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'
                                                                            Visible="False" Width="0px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="模块设置<a href='javascript:void(0)' onclick='checkAll()' class='line'><font color=#ffffff>【全选】</font></a><a href='javascript:void(0)' onclick='fanAll()' class='line'><font color=#ffffff>【反选】</font></a>">
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                                    <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="quanbu" runat="server" Text="使用" />
                                                                        <asp:Label ID="quanbuid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ifopen") %>'
                                                                            Visible="False" Width="0px"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterStyle Wrap="True" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                                            <EmptyDataTemplate>
                                                                <div align="center">
                                                                    <font color="white">无相关数据！</font></div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        访问密码：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="mima" runat="server" TextMode="Password" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" CssClass="button_css" OnClick="Button1_Click"
                                                                    Text="保存设置" />
                                                                <asp:Button ID="Button2" runat="server" Text="返回首页" CssClass="button_css" OnClick="Button2_Click" />
                                                            </font>
                                                        </div>
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
    </form>
</body>
</html>
