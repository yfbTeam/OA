<%@ Page Language="C#" AutoEventWireup="true" Codebehind="KaoShi_show.aspx.cs" Inherits="xyoa.HumanResources.PeiXun.KaoShi.KaoShi_show" %>

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
                                                            <a href="KaoShi.aspx">网上考试</a>
                                                            >> 查看网上考试</td>
                                                        <td width="81%">
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
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        考试主题：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Label ID="Zhuti" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" nowrap="nowrap" colspan="4">
                                                        <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                                                            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px"
                                                            CellPadding="3">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="一、单选题">
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
                                                            CellPadding="3">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="二、多选题">
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
                                                            CellPadding="3">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="三、判断题">
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
                                                                                </td>
                                                                                <td width="15%">
                                                                                    <asp:CheckBox ID="CheckBox5" runat="server" Text="正确"></asp:CheckBox></td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <HeaderStyle Font-Size="12pt" HorizontalAlign="Left" />
                                                        </asp:GridView>
                                                        <asp:GridView ID="GridView4" runat="server" Width="100%" AutoGenerateColumns="False">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="四、填空题">
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
                                                            CellPadding="3">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="五、问答题">
                                                                    <ItemTemplate>
                                                                        <table id="Table6" cellspacing="1" cellpadding="1" width="100%" align="center" border="0">
                                                                            <br>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="Label21" runat="server" Text='<%# Container.DataItemIndex+1 %>'>
                                                                                    </asp:Label>
                                                                                    <asp:Label ID="Label22" runat="server" Text='<%# Eval("TitlesC","、{0}") %>'>
                                                                                    </asp:Label>
                                                                                    <br />
                                                                                    <asp:TextBox ID="txtAnswer" runat="server" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                                                                    <asp:Label ID="Label23" runat="server" Text='<%# Eval("ID") %>' Visible="False">
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
                                                            <input id="Button2" class="button_css" onclick="history.back()" type="button" value="返 回" /></div>
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
    </form>
</body>
</html>
