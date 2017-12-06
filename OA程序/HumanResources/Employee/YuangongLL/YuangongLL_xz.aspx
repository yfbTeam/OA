<%@ Page Language="C#" AutoEventWireup="true" Codebehind="YuangongLL_xz.aspx.cs"
    Inherits="xyoa.HumanResources.Employee.YuangongLL.YuangongLL_xz" %>

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
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='YuangongLL_show.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">档案</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='YuangongLL_px.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">培训</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='YuangongLL_ks.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">考试</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='YuangongLL_ht.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">合同</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='YuangongLL_dd.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">调动</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='YuangongLL_lz.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">离职</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='YuangongLL_fz.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">复职</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='MyAttendance.aspx?id=<%=Request.QueryString["id"] %>&type=1';">
                                                                <font class="shadow_but">出差</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='MyAttendance.aspx?id=<%=Request.QueryString["id"] %>&type=2';">
                                                                <font class="shadow_but">休假</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='MyAttendance.aspx?id=<%=Request.QueryString["id"] %>&type=3';">
                                                                <font class="shadow_but">加班</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='YuangongLL_kq.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">考勤</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='YuangongLL_kp.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">考评</font></button>
                                                            <button class="btn2on" type="button" onclick="javascript:window.location='YuangongLL_xz.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">薪资</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='YuangongLL_jc.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">奖惩</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='YuangongLL_jn.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">技能</font></button>
                                                            <button class="btn2off" type="button" onclick="javascript:window.location='YuangongLL_tj.aspx?id=<%=Request.QueryString["id"] %>';">
                                                                <font class="shadow_but">体检</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                            <input id="Button2" type="button" value="关 闭" onclick="window.close()" class="button_blue" />
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
                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None"
                                                                BorderWidth="1px" CellPadding="4" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%">
                                                                <PagerSettings Visible="False" />
                                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="薪资主题" SortExpression="Zhuti">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <a href='YuangongLL_xz_show.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id")%>'
                                                                                class="LinkLine">
                                                                                <%# DataBinder.Eval(Container.DataItem, "Zhuti")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Neirong" HeaderText="薪资内容" SortExpression="Neirong">
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
                                <div>
                                    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                </td>
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
                                                            &nbsp<asp:LinkButton ID="btnNext" runat="server" CssClass="line" CommandArgument="next"
                                                                OnClick="PagerButtonClick">下页</asp:LinkButton>
                                                            &nbsp;<asp:LinkButton ID="btnLast" runat="server" CssClass="line" CommandArgument="last"
                                                                OnClick="PagerButtonClick">尾页</asp:LinkButton>
                                                            &nbsp;<font color="#000000">页码：<asp:TextBox ID="GoPage" runat="server" Width="25px"></asp:TextBox>
                                                                <asp:Button ID="Button1" runat="server" CssClass="button_jdkd" Text="跳转" Width="36px"
                                                                    Height="20px" OnClick="Button1_Click1" />
                                                                &nbsp;每页<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                        <asp:ListItem>15</asp:ListItem>
                                                                        <asp:ListItem>25</asp:ListItem>
                                                                        <asp:ListItem>50</asp:ListItem>
                                                                        <asp:ListItem>80</asp:ListItem>
                                                                        <asp:ListItem>100</asp:ListItem>
                                                                    </asp:DropDownList>条数据&nbsp; 共有<font color="red"><asp:Label ID="CountsLabel"
                                                                    runat="server"></asp:Label></font>条数据 &nbsp;&nbsp;当前为第<font color="red"><asp:Label
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
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <input id="SortText" type="hidden" runat="server" value="order by A.id desc" />

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
