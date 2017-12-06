<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddWorkFlow_spyj.aspx.cs"
    Inherits="xyoa.WorkFlow.AddWorkFlow_spyj" %>

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
        <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox>
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow1">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="1">
                                            </td>
                                            <td valign="top">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                    BorderColor="White" BorderStyle="None" BorderWidth="0px" CellPadding="6" GridLines="None"
                                                    PageSize="12" Style="font-size: 12px" Width="100%" ShowHeader="False">
                                                    <PagerSettings Visible="False" />
                                                    <FooterStyle BackColor="White" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="办理意见">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemTemplate>
                                                                <table border="0" cellpadding="4" cellspacing="0" width="100%">
                                                                    <tr>
                                                                        <td>
                                                                            <%# DataBinder.Eval(Container.DataItem, "Content") %>
                                                                            <a href="/AddWorkFlow_add_down.aspx?number=<%# DataBinder.Eval(Container.DataItem, "NewName") %>"
                                                                                target="_blank">
                                                                                <%# DataBinder.Eval(Container.DataItem, "OldName") %>
                                                                            </a>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td align="right">
                                                                            <%# DataBinder.Eval(Container.DataItem, "Realname") %>
                                                                            &nbsp;&nbsp;&nbsp;&nbsp;<%# DataBinder.Eval(Container.DataItem, "SetTime") %>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td background="/oaimg/dian.gif" height="1px">
                                                                          
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="False" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle BackColor="White" ForeColor="Black" />
                                                    <EmptyDataTemplate>
                                                        <div align="center">
                                                            <font color="#000">无办理意见！</font></div>
                                                    </EmptyDataTemplate>
                                                    <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                                    <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False" />
                                                </asp:GridView>
                                            </td>
                                            <td width="1">
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
