<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_add_node_lb.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.WorkFlowName_show_add_node_lb" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
    <link href="/flowcss/style.css" type="text/css" rel="stylesheet">

    <script language="javascript" src="/flowcss/set_main.js"></script>

    <script src="/js/public.js" type="text/javascript"></script>


</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
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
                                                    <td valign="top">
                                                        <div id="Div1">
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                                                                BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px"
                                                                CellPadding="3" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                                PageSize="12" Style="font-size: 12px" Width="100%">
                                                                <PagerSettings Visible="False" />
                                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                <Columns>
                                                                    <asp:BoundField DataField="NodeNum" HeaderText="序号">
                                                                        <ItemStyle Wrap="False" Width="50px" />
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="NodeName" HeaderText="步骤名称">
                                                                        <ItemStyle Wrap="False" />
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="下一步骤">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="NodeSite" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "NodeSite")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:Label ID="UpNodeNum" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "UpNodeNum")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="编辑该步骤的各项属性">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:void(0)" onclick="Edit_Process(<%# DataBinder.Eval(Container.DataItem, "ID") %>);">
                                                                                基本属性</a> <a href="javascript:void(0)" onclick="set_next(<%# DataBinder.Eval(Container.DataItem, "ID") %>);">
                                                                                    追加步骤</a> <a href="javascript:void(0)" onclick="set_item(<%# DataBinder.Eval(Container.DataItem, "ID") %>);"
                                                                                        title="<%# DataBinder.Eval(Container.DataItem, "WriteFileName") %>">可写字段</a>
                                                                            <a href="javascript:void(0)" onclick="set_hong(<%# DataBinder.Eval(Container.DataItem, "ID") %>);"
                                                                                title="<%# DataBinder.Eval(Container.DataItem, "WriteFileName") %>">可转换宏控件</a>
                                                                            <a href="javascript:void(0)" onclick="set_dept(<%# DataBinder.Eval(Container.DataItem, "ID") %>);"
                                                                                title="<%# DataBinder.Eval(Container.DataItem, "WriteFileName") %>">保密字段</a>
                                                                            <a href="javascript:void(0)" onclick="set_bitian(<%# DataBinder.Eval(Container.DataItem, "ID") %>);"
                                                                                title="<%# DataBinder.Eval(Container.DataItem, "CouFileName") %>">必填字段</a> <a href="javascript:void(0)"
                                                                                    onclick="set_condition(<%# DataBinder.Eval(Container.DataItem, "ID") %>);">条件设置</a>
                                                                                    <a href="javascript:void(0)"
                                                                                    onclick="set_guolv(<%# DataBinder.Eval(Container.DataItem, "ID") %>);">过滤设置</a>
                                                                                       <a href="javascript:void(0)"
                                                                                    onclick="set_yinzhang(<%# DataBinder.Eval(Container.DataItem, "ID") %>);">必选印章</a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="操作">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" Width="40px" />
                                                                        <ItemTemplate>
                                                                            <a href="javascript:void(0)" onclick="Del_Process(<%# DataBinder.Eval(Container.DataItem, "ID") %>);">
                                                                                删除</a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" Width="40px" />
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
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="FlowNumber" runat="server" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>
