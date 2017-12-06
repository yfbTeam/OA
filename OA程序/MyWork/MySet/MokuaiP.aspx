<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MokuaiP.aspx.cs" Inherits="xyoa.MyWork.MySet.MokuaiP" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body class="newbody" oncontextmenu="return false">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="height: 26px; width: 51%;">
                                                        <button class="btn4off" type="button" onclick="javascript:window.location='Mokuai.aspx?p=<%=Request.QueryString["p"] %>&menhu=<%=Request.QueryString["menhu"] %>&i_chIf_id=<%=Request.QueryString["p"] %>';">
                                                            <font class="shadow_but">添加栏目</font></button>
                                                        <button class="btn4off" type="button" onclick="javascript:window.location='MokuaiY.aspx?p=<%=Request.QueryString["p"] %>&menhu=<%=Request.QueryString["menhu"] %>&i_chIf_id=<%=Request.QueryString["p"] %>';">
                                                            <font class="shadow_but">移除栏目</font></button>
                                                        <button class="btn4on" type="button" onclick="javascript:window.location='MokuaiP.aspx?p=<%=Request.QueryString["p"] %>&menhu=<%=Request.QueryString["menhu"] %>&i_chIf_id=<%=Request.QueryString["p"] %>';">
                                                            <font class="shadow_but">栏目排序</font></button>
                                                    </td>
                                                    <td style="height: 26px" align="right">
                                                        <font color="red">当前为第<%=Request.QueryString["menhu"] %>页桌面，排序以后刷新页面生效</font>
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
                    <table align="center" border="0" cellpadding="4" cellspacing="0" width="100%" height="80%">
                        <tr>
                            <td class="newtd2" colspan="2" width="20%" height="100%" valign="top">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tr>
                                        <td width="12">
                                        </td>
                                        <td valign="top">
                                            <div id="Div1">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                    BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="4" CellSpacing="1"
                                                    GridLines="None" OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                    Width="100%" OnRowCommand="GridView1_RowCommand">
                                                    <PagerSettings Visible="False" />
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="栏目名称">
                                                            <HeaderStyle CssClass="newtitle"  />
                                                            <ItemTemplate>
                                                                <asp:Label ID="Lid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "keyid")%>'
                                                                    Visible="false"></asp:Label>
                                                                <asp:Label ID="leixing" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "leixing")%>'
                                                                    Visible="false"></asp:Label>
                                                                <asp:Label ID="lanmu" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="排序">
                                                            <HeaderStyle CssClass="newtitle"  Width="70px" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PaiXun") %>'
                                                                    CommandName="xiayi">上移</asp:LinkButton>
                                                                       <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PaiXun") %>'
                                                                    CommandName="shangyi">下移</asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
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
                                        <td width="10">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <input id="Hidden1" type="hidden" />

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
