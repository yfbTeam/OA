<%@ Page Language="C#" AutoEventWireup="true" Codebehind="KaoShi_show.aspx.cs" Inherits="xyoa.HumanResources.PeiXun.MyPage.KaoShi_show" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["yangshi"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

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
                                        <td height="35">
                                            <div id="printshow1">
                                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="17">
                                                            &nbsp;</td>
                                                        <td valign="top">
                                                            <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="3%">
                                                                        <img src="/oaimg/top_3.gif"></td>
                                                                    <td width="81%" valign="bottom">
                                                                        参与考试
                                                                    </td>
                                                                    <td width="16%">
                                                                        &nbsp;</td>
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
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        考试主题：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Zhuti" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        当前状态：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Zhuangtai" runat="server" ForeColor="Blue"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        考试开始时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Starttime" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        考试结束时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Endtime" runat="server" ForeColor="Blue"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        考试结果：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="Label14" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" nowrap="nowrap" colspan="4">
                                                        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                                                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                            CellPadding="3" OnRowDataBound="GridView1_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        一、单选题(每题<%=ViewState["Fenzhi1"] %>分)<a name='top1'></a>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <table id="Table2" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                                            <br />
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("TitlesC","、{0}") %>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("ID") %>' Visible="False">
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Fenshu") %>' Visible="false">
                                                                                    </asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="35%">
                                                                                    <asp:RadioButton ID="RadioButton1" runat="server" Text='<%# Eval("AnswerA") %>' GroupName="Sl">
                                                                                    </asp:RadioButton></td>
                                                                                <td width="35%">
                                                                                    <asp:RadioButton ID="RadioButton2" runat="server" Text='<%# Eval("AnswerB") %>' GroupName="Sl">
                                                                                    </asp:RadioButton></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="35%">
                                                                                    <asp:RadioButton ID="RadioButton3" runat="server" Text='<%# Eval("AnswerC") %>' GroupName="Sl">
                                                                                    </asp:RadioButton></td>
                                                                                <td width="35%">
                                                                                    <asp:RadioButton ID="RadioButton4" runat="server" Text='<%# Eval("AnswerD") %>' GroupName="Sl">
                                                                                    </asp:RadioButton></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                                        </asp:GridView>
                                                        <asp:GridView ID="GridView2" runat="server" Width="100%" AutoGenerateColumns="False"
                                                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                            CellPadding="3" OnRowDataBound="GridView2_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        二、多选题(每题<%=ViewState["Fenzhi2"] %>分)<a name='top2'></a>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <table id="Table3" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                                            <br />
                                                                            <tr>
                                                                                <td colspan="3">
                                                                                    <asp:Label ID="Label9" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label10" runat="server" Text='<%# Eval("TitlesC","、{0}") %>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("ID") %>' Visible="False">
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Fenshu") %>' Visible="False">
                                                                                    </asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="height: 22px" width="35%">
                                                                                    <asp:CheckBox ID="CheckBox1" runat="server" Text='<%# Eval("AnswerA") %>'></asp:CheckBox></td>
                                                                                <td style="height: 22px" width="35%">
                                                                                    <asp:CheckBox ID="CheckBox2" runat="server" Text='<%# Eval("AnswerB") %>'></asp:CheckBox></td>
                                                                                <td style="height: 22px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td width="35%">
                                                                                    <asp:CheckBox ID="CheckBox3" runat="server" Text='<%# Eval("AnswerC") %>'></asp:CheckBox></td>
                                                                                <td width="350%">
                                                                                    <asp:CheckBox ID="CheckBox4" runat="server" Text='<%# Eval("AnswerD") %>'></asp:CheckBox></td>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                                        </asp:GridView>
                                                        <asp:GridView ID="GridView3" runat="server" Width="100%" AutoGenerateColumns="False"
                                                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                            CellPadding="3" OnRowDataBound="GridView3_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        三、判断题(每题<%=ViewState["Fenzhi3"] %>分)<a name='top3'></a>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <table id="Table4" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                                            <br />
                                                                            <tr>
                                                                                <td width="85%">
                                                                                    <asp:Label ID="Label19" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label20" runat="server" Text='<%# Eval("TitlesC","、{0}") %>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("ID") %>' Visible="False">
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label11" runat="server" Text='<%# Eval("Fenshu") %>' Visible="False">
                                                                                    </asp:Label>
                                                                                </td>
                                                                                <td width="15%">
                                                                                    <asp:RadioButton ID="RadioButton5" runat="server" Text='正确' GroupName="Pl"></asp:RadioButton>
                                                                                    <asp:RadioButton ID="RadioButton6" runat="server" Text='错误' GroupName="Pl"></asp:RadioButton>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                                        </asp:GridView>
                                                        <asp:GridView ID="GridView4" runat="server" Width="100%" AutoGenerateColumns="False"
                                                            OnRowDataBound="GridView4_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        四、填空题(每题<%=ViewState["Fenzhi4"] %>分)<a name='top4'></a>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <table id="Table5" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                                            <br />
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label16" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label17" runat="server" Text='<%# Eval("FrontTitle","、{0}") %>'>
                                                                                    </asp:Label>
                                                                                    <asp:TextBox ID="TextBox1" runat="server" Width="150px" Style="border-bottom: gray   1px   solid"
                                                                                        BorderStyle="None"></asp:TextBox>
                                                                                    <asp:Label ID="Label18" runat="server" Text='<%# Eval("BackTitle") %>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("ID") %>' Visible="False">
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label12" runat="server" Text='<%# Eval("Fenshu") %>' Visible="False">
                                                                                    </asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                                        </asp:GridView>
                                                        <asp:GridView ID="GridView5" runat="server" Width="100%" AutoGenerateColumns="False"
                                                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                            CellPadding="3" OnRowDataBound="GridView5_RowDataBound">
                                                            <Columns>
                                                                <asp:TemplateField>
                                                                    <HeaderTemplate>
                                                                        五、问答题(每题<%=ViewState["Fenzhi5"] %>分)<a name='top5'></a>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <table id="Table6" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                                            <br>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label21" runat="server" Text='<%# Container.DataItemIndex+1 %>' Font-Bold="True">
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label22" runat="server" Text='<%# Eval("TitlesC","、{0}") %>' Font-Bold="True">
                                                                                    </asp:Label>
                                                                                    <br />
                                                                                    <asp:TextBox ID="txtAnswer" runat="server" Width="100%" TextMode="MultiLine" MaxLength="500"
                                                                                        Height="60px"></asp:TextBox>
                                                                                    <asp:Label ID="Label23" runat="server" Text='<%# Eval("ID") %>' Visible="False">
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label13" runat="server" Text='<%# Eval("Fenshu") %>' Visible="False">
                                                                                    </asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                            <asp:Button ID="Button3" runat="server" Text="返 回" CssClass="button_css" OnClick="Button3_Click" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="Tr1">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        快速导航：[<a href="#">顶部</a>][<a href="#top1">单选题</a>][<a href="#top2">多选题</a>][<a href="#top3">判断题</a>][<a
                                                            href="#top4">填空题</a>][<a href="#top5">问答题</a>]
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
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
