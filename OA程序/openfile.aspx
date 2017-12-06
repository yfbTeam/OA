<%@ Page Language="C#" AutoEventWireup="true" Codebehind="openfile.aspx.cs" Inherits="xyoa.openfile" %>

<html>
<head>
    <title>
        <%=Session["Titles"]%>
    </title>

    <script src="/js/public.js" type="text/javascript"></script>

    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <base target="_self" />
    <script src="../public/public.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
        <table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0"
            bordercolordark="#ffffff">
            <tr>
                <td height="22" background="/oaimg/nextline.gif" align="left" style="font-size: 12px;
                    font-family: 宋体">
                    请选择文件</td>
            </tr>
            <tr>
                <td valign="top" style="text-align: center">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 693px; height: 49px">
                        <tr>
                            <td colspan="2">
                                文件夹：<asp:DropDownList ID="Folder" runat="server" Width="147px">
                                </asp:DropDownList>
                                文件名称：<asp:TextBox ID="OldName" runat="server" Width="77px"></asp:TextBox>&nbsp;<asp:Button
                                    ID="Button4" runat="server" OnClick="Button4_Click1" Text="查询" CssClass="button_css" />
                                    <asp:Button
                                    ID="Button1" runat="server" Text="退出" CssClass="button_css" OnClick="Button1_Click" />
                               </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <hr>
                            </td>
                            <tr>
                        <tr>
                            <td colspan="2">
                                <table border="0" cellpadding="0" cellspacing="0" style="height: 302px; width: 690px;">
                                    <tr>
                                        <td align="center" style="width: 690px" valign="top">
                                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px"
                                                CellPadding="3" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                OnSorting="GridView1_Sorting" PageSize="7" Style="font-size: 12px" Width="99%">
                                                <PagerSettings Visible="False" />
                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="选择">
                                                        <ItemStyle HorizontalAlign="Center" Wrap="True" Width="30px" />
                                                        <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="CheckSelect" runat="server" />
                                                            <asp:Label ID="LabVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                Visible="False" Width="0px"></asp:Label>
                                                            <asp:Label ID="LabNameVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OldName") %>'
                                                                Visible="False" Width="0px"></asp:Label>
                                                        </ItemTemplate>
                                                        <FooterStyle Wrap="True" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="文件名称" SortExpression="OldName">
                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                        <ItemTemplate>
                                                            <img src="/oaimg/filetype/<%# DataBinder.Eval(Container.DataItem, "Fjtype")%>.gif" />
                                                            <a href="/Foldersdown.aspx?number=<%# DataBinder.Eval(Container.DataItem, "NewName")%>"
                                                                target="_blank">
                                                                <%# DataBinder.Eval(Container.DataItem, "OldName")%>
                                                            </a>
                                                        </ItemTemplate>
                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="NowTimes" HeaderText="上传时间" SortExpression="NowTimes">
                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                        <ItemStyle Wrap="False" />
                                                    </asp:BoundField>
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
                                </table>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 31px; text-align: center;">
                                <asp:Button ID="Button2" runat="server" Text="确 定" CssClass="button_css" OnClick="Button2_Click" />
                                <input type="button" value="关 闭" onclick="window.close();" class="button_css" id="Button3">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="22">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
