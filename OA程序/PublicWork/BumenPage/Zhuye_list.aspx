<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zhuye_list.aspx.cs" Inherits="xyoa.PublicWork.BumenPage.Zhuye_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
                                &nbsp;
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
                                                &nbsp;
                                            </td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="50%" valign="bottom">
                                                            <a href="Zhuye.aspx" class="line_b">
                                                                <%=ViewState["BuMenName"] %>
                                                            </a>>> 部门主页浏览
                                                        </td>
                                                        <td width="47%" align="right">
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
                                                &nbsp;
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
                                            &nbsp;
                                        </td>
                                        <td valign="top" style="height: 40px">
                                            <div id="printshow2">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="height: 26px;">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">部门主页浏览</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td width="17" style="height: 40px">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;
                                        </td>
                                        <td valign="top">
                                            <div id="Div1" class="mainDiv">
                                                <div>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="4">
                                                        <tr>
                                                            <td width="60%" valign="top">
                                                                <asp:Label ID="mx" runat="server"></asp:Label>
                                                            </td>
                                                            <td width="40%" valign="top">
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                                    BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="4" CellSpacing="1"
                                                                    GridLines="None" PageSize="12" Style="font-size: 12px" Width="100%">
                                                                    <PagerSettings Visible="False" />
                                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="今天更新文章">
                                                                            <ItemStyle Wrap="False" />
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <img src="/oaimg/point.gif" />&nbsp;<a  href='Zhuye_show.aspx?key=2&id=<%# DataBinder.Eval(Container.DataItem, "id")%>&ZhuyeId=<%# DataBinder.Eval(Container.DataItem, "ZhuyeId")%>'>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "titles")%>
                                                                                    &nbsp;(<%# DataBinder.Eval(Container.DataItem, "BuMenName")%> → <%# DataBinder.Eval(Container.DataItem, "Realname")%>  <%# DataBinder.Eval(Container.DataItem,"Settime","{0:yyyy-MM-dd}")%>)</a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                                    <EmptyDataTemplate>
                                                                        <div align="center">
                                                                            <font color="white">今天未更新文章！</font></div>
                                                                    </EmptyDataTemplate>
                                                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False"
                                                                        HorizontalAlign="left" />
                                                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                                                </asp:GridView>
                                                                <br>
                                                                  <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                                    BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="4" CellSpacing="1"
                                                                    GridLines="None" PageSize="12" Style="font-size: 12px" Width="100%">
                                                                    <PagerSettings Visible="False" />
                                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="10天内更新文章">
                                                                            <ItemStyle Wrap="False" />
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <img src="/oaimg/point.gif" />&nbsp;<a  href='Zhuye_show.aspx?key=2&id=<%# DataBinder.Eval(Container.DataItem, "id")%>&ZhuyeId=<%# DataBinder.Eval(Container.DataItem, "ZhuyeId")%>'>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "titles")%>
                                                                                    &nbsp;(<%# DataBinder.Eval(Container.DataItem, "BuMenName")%> → <%# DataBinder.Eval(Container.DataItem, "Realname")%>  <%# DataBinder.Eval(Container.DataItem,"Settime","{0:yyyy-MM-dd}")%>)</a>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                                    <EmptyDataTemplate>
                                                                        <div align="center">
                                                                            <font color="white">10天内未更新文章！</font></div>
                                                                    </EmptyDataTemplate>
                                                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                                    <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" Wrap="False"
                                                                        HorizontalAlign="left" />
                                                                    <AlternatingRowStyle BackColor="#F7F7F7" />
                                                                </asp:GridView>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                                &nbsp;
                                            </div>
                                        </td>
                                        <td width="17">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <script language="javascript">	

            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
            
        </script>

    </form>
</body>
</html>