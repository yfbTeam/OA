<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyWebDisk_Rz.aspx.cs" Inherits="xyoa.PublicWork.WebDisk.MyWebDisk_Rz" %>
<html>
<head id="Head1" runat="server">
    <title>文件日志 </title>
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
                            </td>
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
                                                <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                    BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px"
                                                    CellPadding="5" CellSpacing="1" GridLines="None" Style="font-size: 12px" Width="97%"
                                                    OnRowDataBound="GridView1_RowDataBound" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                    AllowPaging="True">
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="文件日志">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemTemplate>
                                                                <table border="0" cellpadding="4" cellspacing="0">
                                                                    <tr>
                                                                        <td style="width: 100%">
                                                                            <b>操作人：</b>&nbsp;   <a href='javascript:void(0)' onclick='senduser("<%# DataBinder.Eval(Container.DataItem, "Username")%>")'>
                                                                                <%# DataBinder.Eval(Container.DataItem, "Realname")%>
                                                                            </a>&nbsp;<b>操作时间：</b><%# DataBinder.Eval(Container.DataItem, "SetTime") %>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 100%">
                                                                            <b>操作内容：</b><%# DataBinder.Eval(Container.DataItem, "Contents") %>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="False" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                    <EmptyDataTemplate>
                                                        <div align="center">
                                                            <font color="white">无相关数据！</font></div>
                                                    </EmptyDataTemplate>
                                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="White" HorizontalAlign="Right" />
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
