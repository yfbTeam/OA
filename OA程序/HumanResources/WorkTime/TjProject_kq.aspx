<%@ Page Language="C#" AutoEventWireup="true" Codebehind="TjProject_kq.aspx.cs" Inherits="xyoa.HumanResources.WorkTime.TjProject_kq" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

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
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="WorkTimeMG.aspx" class="line_b">
                                                                考勤管理</a> >> 考勤明细(<font color=blue><%=ViewState["leixing"]%></font>)
                                                        </td>
                                                        <td width="16%">
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
                                                                <font class="shadow_but">考勤明细</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                            <input id="Button3" type="button" value="返 回" onclick="history.go(-1)" class="button_blue" />
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
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <div id="Div1">
                                                            <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px"
                                                                CellPadding="4" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%" OnRowCreated="GridView1_RowCreated">
                                                                <PagerSettings Visible="False" />
                                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="日期" SortExpression="Djtime">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# ((Eval("Djtime").ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "")))%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderTemplate>
                                                                            <%=ViewState["DjType_1"]%>
                                                                            (<%=ViewState["DjTime_1"]%>)
                                                                        </HeaderTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "DjTime_1")%>
                                                                            (<asp:Label ID="L_DjState_1" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DjState_1")%>'></asp:Label>)
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <HeaderTemplate>
                                                                            <%=ViewState["DjType_2"]%>
                                                                            (<%=ViewState["DjTime_2"]%>) 
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "DjTime_2")%>
                                                                            (<asp:Label ID="L_DjState_2" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DjState_2")%>'></asp:Label>)
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <HeaderTemplate>
                                                                            <%=ViewState["DjType_3"]%>
                                                                            (<%=ViewState["DjTime_3"]%>)
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "DjTime_3")%>
                                                                            (<asp:Label ID="L_DjState_3" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DjState_3")%>'></asp:Label>)
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <HeaderTemplate>
                                                                            <%=ViewState["DjType_4"]%>
                                                                            (<%=ViewState["DjTime_4"]%>)
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "DjTime_4")%>
                                                                            (<asp:Label ID="L_DjState_4" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DjState_4")%>'></asp:Label>)
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <HeaderTemplate>
                                                                            <%=ViewState["DjType_5"]%>
                                                                            (<%=ViewState["DjTime_5"]%>)
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "DjTime_5")%>
                                                                            (<asp:Label ID="L_DjState_5" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DjState_5")%>'></asp:Label>)
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <HeaderTemplate>
                                                                            <%=ViewState["DjType_6"]%>
                                                                            (<%=ViewState["DjTime_6"]%>)
                                                                        </HeaderTemplate>
                                                                        <ItemTemplate>
                                                                            <%#DataBinder.Eval(Container.DataItem, "DjTime_6")%>
                                                                            (<asp:Label ID="L_DjState_6" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "DjState_6")%>'></asp:Label>)
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
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
        <input id="SortText" type="hidden" runat="server" value="order by id asc" />
    </form>
</body>
</html>
