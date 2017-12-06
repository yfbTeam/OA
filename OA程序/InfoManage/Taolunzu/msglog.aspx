<%@ Page Language="C#" AutoEventWireup="true" Codebehind="msglog.aspx.cs" Inherits="xyoa.InfoManage.Taolunzu.msglog" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=ViewState["Name"]%>
        聊天记录</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body class="newbody" scroll="yes">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td background="bg.png" height="18" valign="middle">
                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30px"
                        background="/oaimg/nextline.gif">
                        <tr>
                            <td valign="top">
                                内容：<asp:TextBox ID="Name" runat="server"></asp:TextBox>
                                <asp:Button ID="SearchData" runat="server" Text="查 询" OnClick="SearchData_Click"
                                    CssClass="button_css" />
                                <asp:Button ID="Button2" runat="server" CssClass="button_css" OnClick="Button2_Click"
                                    Text="退 出" />
                                <asp:Button ID="Button1" runat="server" CssClass="button_css" Text="导 出" OnClick="Button1_Click" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top" style="height: 35px">
                                                        <div id="Div1">
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                                                                BorderColor="#3366CC" BorderWidth="0px" CellPadding="4" Style="font-size: 12px"
                                                                Width="100%" ShowHeader="False" PageSize="12" OnRowDataBound="GridView1_RowDataBound">
                                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                <PagerSettings Visible="False" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="消息内容" SortExpression="titles">
                                                                        <ItemStyle Wrap="True" />
                                                                        <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Lid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:Label ID="SUsername" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SUsername")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:Label ID="SRealname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "SRealname")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:Label ID="Settimes" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Settimes")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:Label ID="Content" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Content")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterStyle Wrap="True" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <RowStyle BackColor="White" ForeColor="#003399" />
                                                                <SelectedRowStyle BackColor="Teal" Font-Bold="True" ForeColor="#CCFF99" />
                                                                <PagerStyle BackColor="WhiteSmoke" ForeColor="#003399" HorizontalAlign="Left" />
                                                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" Wrap="False" />
                                                                <EmptyDataTemplate>
                                                                    <div align="center">
                                                                        <font color="#003399">无相关数据！</font></div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
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
