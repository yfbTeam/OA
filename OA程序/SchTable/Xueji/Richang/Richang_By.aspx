<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Richang_By.aspx.cs" Inherits="xyoa.SchTable.Xueji.Richang.Richang_By" %>

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
        <asp:TextBox ID="Count" runat="server" Style="display: none"></asp:TextBox>
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
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
                                        <td width="17" style="height: 40px">
                                        </td>
                                        <td valign="top" style="height: 40px">
                                            <div id="printshow2">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="height: 26px;">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">学籍列表</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td width="17" style="height: 40px">
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                        </td>
                                        <td valign="top">
                                            <asp:Panel ID="Panel1" runat="server">
                                                <div align="center">
                                                    <asp:Label ID="Label1" runat="server" Text="请先选择班级" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel2" runat="server">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30px"
                                                                background="/oaimg/nextline.gif">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:Button ID="Button1" runat="server" Text="确定提交" CssClass="button_css" OnClick="Button1_Click" />
                                                                        <input id="Button2" type="button" value="全选" onclick="checkAll()" />
                                                                        <input id="Button3" type="button" value="反选" onclick="fanAll()" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div id="Div1">
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                                    BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="1"
                                                                    GridLines="None" OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                                    Width="100%">
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
                                                                                <asp:Label ID="XsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "XsId") %>'
                                                                                    Visible="False" Width="0px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterStyle Wrap="True" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="BanJiName" HeaderText="班级" SortExpression="A.BanJi">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemStyle Wrap="False" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="学生姓名" SortExpression="A.Xingming">
                                                                            <ItemStyle Wrap="True" />
                                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="Xingming" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Xingming")%>'
                                                                                    Visible="false"></asp:Label>
                                                                                <a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open ("/SchTable/Xueji/ZaijiSheng/ZaijiSheng_lb_show.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>&Xueduan=<%#DataBinder.Eval(Container.DataItem, "Xueduan")%>&Xueqi=<%#DataBinder.Eval(Container.DataItem, "Xueqi")%>", "_blank", "height=" + ah + ", width=" + aw + ",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=" + loc_y + ",left=" + loc_x + "")'>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "Xingming")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                            <FooterStyle Wrap="True" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Xuejihao" HeaderText="学籍号" SortExpression="Xuejihao">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemStyle Wrap="False" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Xuehao" HeaderText="学号" SortExpression="Xuehao">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemStyle Wrap="False" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="毕业去向">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="Quxiang" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                                                </asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="毕业备注">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="Beizhu" runat="server" Width="100%" MaxLength="200" Height="71px"
                                                                                    TextMode="MultiLine"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
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
                                            </asp:Panel>
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

        <script type="text/javascript">
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
