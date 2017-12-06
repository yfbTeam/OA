<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ziliao_xiaolei_xzph.aspx.cs" Inherits="xyoa.InfoManage.zhiao.ziliao_xiaolei_xzph" %>

<%@ Register Src="xiaolei_zl.ascx" TagName="xiaolei_zl" TagPrefix="uc3" %>
<%@ Register Src="taitou.ascx" TagName="taitou" TagPrefix="uc2" %>
<%@ Register Src="right.ascx" TagName="right" TagPrefix="uc1" %>
<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="zst.css" type="text/css" rel="stylesheet">
    <link href="img/oa.css" type="text/css" rel="stylesheet">
    <link href="img/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script>
function m_show(id)
{ 
var num=Math.random();
window.showModalDialog('ziliao_tj_show.aspx?id='+id+'&tmp='+num+'','window','dialogWidth:730px;DialogHeight=500px;status:no;help=no;scroll=on');window.location='#'
}  
    </script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        &nbsp;
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;
                                        </td>
                                        <td valign="top">
                                            <table width="991" height="620" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td valign="top">
                                                        <uc2:taitou ID="Taitou1" runat="server"></uc2:taitou>
                                                        <table width="991" height="743" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td valign="top">
                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0" id="printshow2">
                                                                        <tr>
                                                                            <td>
                                                                                <div>
                                                                                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td width="17">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td valign="top">
                                                                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                                                                    <tr>
                                                                                                        <td width="70%" valign="bottom">
                                                                                                            <a href="zhishitang.aspx" class="line_b">知识堂</a> >> <a href="ziliao_all.aspx" class="line_b">
                                                                                                                全部共享资料分类</a> >> <a href="ziliao_xiaolei.aspx?ParentNodesID=<%=Request.QueryString["ParentNodesID"] %>&id=0"
                                                                                                                    class="line_b">
                                                                                                                    <%=ViewState["Name"] %>
                                                                                                                </a>>>
                                                                                                            <%=ViewState["XName"] %>
                                                                                                            全部资料</td>
                                                                                                        <td width="30%" align="right">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                                <table width="100%" height="2" border="0" cellpadding="0" cellspacing="0" background="img/bg_nav_30.gif">
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
                                                                                <uc3:xiaolei_zl ID="Xiaolei_zl1" runat="server" />
                                                                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td width="17" style="height: 40px">
                                                                                            &nbsp;</td>
                                                                                        <td valign="top" style="height: 40px">
                                                                                            <div id="Div1">
                                                                                                <table align="center" background="img/bg0003.gif" border="0" cellpadding="0" cellspacing="0"
                                                                                                    width="100%">
                                                                                                    <tr>
                                                                                                        <td style="height: 26px;">
                                                                                                            <button class="btn4off" type="button" onclick="javascript:window.location='ziliao_xiaolei.aspx?ParentNodesID=<%=Request.QueryString["ParentNodesID"] %>&id=<%=Request.QueryString["id"] %>';showwait();">
                                                                                                                <font class="shadow_but">全部资料</font></button>
                                                                                                            <button class="btn4off" type="button" onclick="javascript:window.location='ziliao_xiaolei_tj.aspx?ParentNodesID=<%=Request.QueryString["ParentNodesID"] %>&id=<%=Request.QueryString["id"] %>';showwait();">
                                                                                                                <font class="shadow_but">推荐资料</font></button>
                                                                                                            <button class="btn4on" type="button" onclick="javascript:window.location='ziliao_xiaolei_xzph.aspx?ParentNodesID=<%=Request.QueryString["ParentNodesID"] %>&id=<%=Request.QueryString["id"] %>';showwait();">
                                                                                                                <font class="shadow_but">下载排行榜</font></button>
                                                                                                        </td>
                                                                                                        <td style="height: 26px" align="right">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </div>
                                                                                        </td>
                                                                                        <td width="17" style="height: 40px">
                                                                                            &nbsp;</td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="17">
                                                                                &nbsp;</td>
                                                                            <td valign="top">
                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                    <tr>
                                                                                        <td valign="top">
                                                                                            <div id="Div2">
                                                                                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                                                    AutoGenerateColumns="False" BackColor="#E0E0E0" BorderColor="#4D77B1" CellPadding="3"
                                                                                                    GridLines="None" OnRowDataBound="GridView1_RowDataBound" OnSorting="GridView1_Sorting"
                                                                                                    PageSize="12" Style="font-size: 12px" Width="100%">
                                                                                                    <PagerSettings Visible="False" />
                                                                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                                                    <Columns>
                                                                                                          <asp:TemplateField HeaderText="文件名称" SortExpression="A.Name">
                                                                                                            <HeaderStyle BackColor="#F2EBB7" ForeColor="#444659" Wrap="False" />
                                                                                                            <ItemTemplate>
                                                                                                                <img src="/oaimg/filetype/<%# DataBinder.Eval(Container.DataItem, "Filetype")%>.gif" />
                                                                                                              <a href='javascript:void(0)' onclick='m_show("<%# DataBinder.Eval(Container.DataItem, "id")%>")'>
                                                                                                                    <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                                                                                                </a>
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="下载次数" SortExpression="A.cishu">
                                                                                                            <HeaderStyle BackColor="#F2EBB7" ForeColor="#444659" Wrap="False" />
                                                                                                            <ItemTemplate>
                                                                                                                <%# DataBinder.Eval(Container.DataItem, "cishu")%>
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:BoundField DataField="Settimes" HeaderText="更新时间" SortExpression="Settimes">
                                                                                                            <HeaderStyle BackColor="#F2EBB7" ForeColor="#444659" Wrap="False" />
                                                                                                            <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                                                        </asp:BoundField>
                                                                                                <asp:TemplateField HeaderText="所属类别" SortExpression="A.Leibie">
                                                                                                            <HeaderStyle BackColor="#F2EBB7" ForeColor="#444659" Wrap="False" />
                                                                                                            <ItemTemplate>
                                                                                                                <asp:Label ID="Leibie" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Leibie") %>'
                                                                                                                    Visible="False" Width="0px"></asp:Label>
                                                                                                                <asp:Label ID="LeibieName" runat="server"></asp:Label>
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                        <asp:TemplateField HeaderText="上传人" SortExpression="Realname">
                                                                                                            <HeaderStyle BackColor="#F2EBB7" ForeColor="#444659" Wrap="False" />
                                                                                                            <ItemTemplate>
                                                                                                                <a href='javascript:void(0)' onclick='senduser("<%# DataBinder.Eval(Container.DataItem, "Username")%>")'>
                                                                                                                    <%# DataBinder.Eval(Container.DataItem, "Realname")%>
                                                                                                                </a>
                                                                                                            </ItemTemplate>
                                                                                                            <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                                                        </asp:TemplateField>
                                                                                                    </Columns>
                                                                                                    <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                                                                    <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                                                    <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                                                                    <HeaderStyle BackColor="#F2EBB7" ForeColor="#261CDC" Wrap="False" Font-Bold="False" />
                                                                                                    <AlternatingRowStyle BackColor="#FBF9E6" />
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
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                    <div>
                                                                        <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td width="17">
                                                                                    &nbsp;</td>
                                                                                <td valign="top" background="img/next_bg.jpg" align="center">
                                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:LinkButton ID="btnFirst" runat="server" CssClass="line" CommandArgument="first"
                                                                                                    OnClick="PagerButtonClick">首页</asp:LinkButton>
                                                                                                &nbsp;&nbsp;<asp:LinkButton ID="btnPrev" runat="server" CssClass="line" CommandArgument="prev"
                                                                                                    OnClick="PagerButtonClick">上页</asp:LinkButton>
                                                                                                &nbsp;&nbsp;<asp:LinkButton ID="btnNext" runat="server" CssClass="line" CommandArgument="next"
                                                                                                    OnClick="PagerButtonClick">下页</asp:LinkButton>
                                                                                                &nbsp;&nbsp;<asp:LinkButton ID="btnLast" runat="server" CssClass="line" CommandArgument="last"
                                                                                                    OnClick="PagerButtonClick">尾页</asp:LinkButton>
                                                                                                &nbsp;&nbsp;<font color="#000000">页码：<asp:TextBox ID="GoPage" runat="server" Width="25px"></asp:TextBox>
                                                                                                    <asp:Button ID="Button1" runat="server" CssClass="button_jdkd" Text="跳转" Width="36px"
                                                                                                        Height="20px" OnClick="Button1_Click1" />
                                                                                                    &nbsp;&nbsp;每页<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                        <asp:ListItem>15</asp:ListItem>
                                                                        <asp:ListItem>25</asp:ListItem>
                                                                        <asp:ListItem>50</asp:ListItem>
                                                                        <asp:ListItem>80</asp:ListItem>
                                                                        <asp:ListItem>100</asp:ListItem>
                                                                    </asp:DropDownList>条数据&nbsp; 共有<font color="red"><asp:Label
                                                                                                        ID="CountsLabel" runat="server"></asp:Label></font>条数据 &nbsp;&nbsp;当前为第<font color="red"><asp:Label
                                                                                                            ID="CurrentlyPageLabel" runat="server"></asp:Label></font>页 &nbsp;&nbsp;
                                                                                                    共<font color="red"><asp:Label ID="AllPageLabel" runat="server"></asp:Label></font>页</font>
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
                                                                <td width="207" valign="top">
                                                                    <uc1:right ID="Right1" runat="server"></uc1:right>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
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
        <input id="SortText" type="hidden" runat="server" value="order by A.cishu desc" />
    </form>
</body>
</html>