<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Juese_mk2.aspx.cs" Inherits="xyoa.SystemManage.Juese.Juese_mk2" %>

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
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
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
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="Juese.aspx">角色管理</a> >> 系统模块初始</td>
                                                        <td width="81%">
                                                            &nbsp;</td>
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
                                                &nbsp;</td>
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
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='Juese_mk1.aspx?id=<%=Request.QueryString["id"] %>';showwait();">
                                                                <font class="shadow_but">版面1</font></button>
                                                            <button class="btn4on" type="button" onclick="javascript:window.location='Juese_mk2.aspx?id=<%=Request.QueryString["id"] %>';showwait();"><font class="shadow_but">版面2</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='Juese_mk3.aspx?id=<%=Request.QueryString["id"] %>';showwait();"><font class="shadow_but">版面3</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='Juese_mk4.aspx?id=<%=Request.QueryString["id"] %>';showwait();"><font class="shadow_but">版面4</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='Juese_mk5.aspx?id=<%=Request.QueryString["id"] %>';showwait();"><font class="shadow_but">版面5</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="left" class="newtd2" style="height: 26px">
                                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30px"
                                                            background="/oaimg/nextline.gif">
                                                            <tr>
                                                                <td valign="top">
                                                                    从<asp:DropDownList ID="JueseId" runat="server">
                                                                    </asp:DropDownList>角色复制版面
                                                                    <asp:Button ID="Button3" runat="server" Text="确定复制" OnClick="Button3_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17">
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
                                                                        <%# DataBinder.Eval(Container.DataItem, "urlname")%>
                                                                        <asp:Label ID="Lid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'
                                                                            Visible="False" Width="0px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="模块设置">
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                                    <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="quanbu" runat="server" Text="选择" />
                                                                        <asp:Label ID="quanbuid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'
                                                                            Visible="False" Width="0px"></asp:Label>
                                                                        <asp:Label ID="ParentNodesID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParentNodesID") %>'
                                                                            Visible="False" Width="0px"></asp:Label>
                                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
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
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css"
                                                                    OnClick="Button2_Click" />
                                                            </font>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
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