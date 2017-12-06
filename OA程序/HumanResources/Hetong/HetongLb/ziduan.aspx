<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ziduan.aspx.cs" Inherits="xyoa.HumanResources.Hetong.HetongLb.ziduan" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script>
function AddZiduan(str)
{
    var num=Math.random();
    window.showModalDialog("ziduan_add.aspx?tmp="+num+"&LeibieID=<%=Request.QueryString["LeibieID"] %>","window", "dialogWidth:680px;DialogHeight=280px;status:no;scroll=yes;help:no");       
}
    </script>

    <base target="_self" />
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30px"
                                                            background="/oaimg/nextline.gif">
                                                            <tr>
                                                                <td valign="top">
                                                                    <img src="/oaimg/menu/Menu46.gif" />
                                                                    <asp:LinkButton ID="LinkButton1" runat="server">新增字段</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div id="Div1">
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                                BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="4" CellSpacing="1"
                                                                GridLines="None" OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                                Width="100%" OnRowCommand="GridView1_RowCommand">
                                                                <PagerSettings Visible="False" />
                                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="Mingcheng" HeaderText="字段名称">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="字段类型">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# ((Eval("Leixing").ToString().Replace("2", "多行输入框").Replace("1", "单行输入框")))%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="相关操作">
                                                                        <ItemStyle HorizontalAlign="Center" Width="70px" Wrap="False" />
                                                                        <HeaderStyle CssClass="newtitle" HorizontalAlign="Center" Width="70px" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton ID="XiuGai" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                                CommandName="XiuGai" CssClass="LinkLine">修改</asp:LinkButton>
                                                                            <asp:LinkButton ID="ShanChu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                                CommandName="ShanChu" CssClass="LinkLine">删除</asp:LinkButton>
                                                                        </ItemTemplate>
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
                                                            &nbsp;
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
