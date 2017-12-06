<%@ Page Language="C#" AutoEventWireup="true" Codebehind="msglog.aspx.cs" Inherits="xyoa.mainpage.msglog" %>

<html>
<head id="Head1" runat="server">
    <title>与<%=ViewState["Realname"] %>的聊天记录</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body class="newbody" >
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td background="bg.png" height="18" valign="middle">
                    与
                    <%=ViewState["Realname"] %>
                    的聊天记录
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
                                                                Width="100%" ShowHeader="False" PageSize="12" OnRowDataBound="GridView1_RowDataBound"
                                                                AllowPaging="True">
                                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                <PagerSettings Visible="False" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="消息内容" SortExpression="titles">
                                                                        <ItemStyle Wrap="True" />
                                                                        <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Lid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:Label ID="acceptusername" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "acceptusername")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:Label ID="sendrealname" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "sendrealname")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:Label ID="itimes" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "itimes")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:Label ID="titles" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "titles")%>'
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
                                                            &nbsp;
                                                            <table width="100%" height="27" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td valign="top" background="/<%=Session["yangshi"]%>/next_bg.jpg" align="center">
                                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:LinkButton ID="btnFirst" runat="server" CssClass="line" CommandArgument="first"
                                                                                        OnClick="PagerButtonClick">首页</asp:LinkButton>
                                                                                    &nbsp;<asp:LinkButton ID="btnPrev" runat="server" CssClass="line" CommandArgument="prev"
                                                                                        OnClick="PagerButtonClick">上页</asp:LinkButton>
                                                                                    &nbsp;<asp:LinkButton ID="btnNext" runat="server" CssClass="line" CommandArgument="next"
                                                                                        OnClick="PagerButtonClick">下页</asp:LinkButton>
                                                                                    &nbsp;<asp:LinkButton ID="btnLast" runat="server" CssClass="line" CommandArgument="last"
                                                                                        OnClick="PagerButtonClick">尾页</asp:LinkButton>
                                                                                    &nbsp;<font color="#000000">页码：<asp:TextBox ID="GoPage" runat="server" Width="25px"></asp:TextBox>
                                                                                        <asp:Button ID="Button1" runat="server" CssClass="button_jdkd" Text="跳转" Width="36px"
                                                                                            Height="20px" OnClick="Button1_Click1" />
                                                                                        &nbsp;每页<font color="red">12</font>条&nbsp;共<font color="red"><asp:Label ID="CountsLabel"
                                                                                            runat="server"></asp:Label></font>条&nbsp;当前为第<font color="red"><asp:Label ID="CurrentlyPageLabel"
                                                                                                runat="server"></asp:Label></font>页 &nbsp; 共<font color="red"><asp:Label ID="AllPageLabel"
                                                                                                    runat="server"></asp:Label></font>页</font>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
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
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
