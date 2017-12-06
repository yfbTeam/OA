<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Biangeng_Bg.aspx.cs" Inherits="xyoa.SchTable.Xueji.Biangeng.Biangeng_Bg" %>

<html>

<script>
function chknull()
{
   if(document.getElementById('XsId').value=='')
    {
    alert('姓名不能为空');
    form1.XsId.focus();
    return false;
    }	


    showwait();	
 
}  

</script>

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
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <asp:Panel ID="Panel1" runat="server">
                                    <div align="center">
                                        <asp:Label ID="Label1" runat="server" Text="请先选择班级" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server">
                                    <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                        <tr>
                                            <td align="center" class="newtd2" colspan="8" style="height: 26px">
                                                <b>学生信息</b></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="8%">
                                                <font color="red">※</font>学生姓名：</td>
                                            <td class="newtd2" colspan="7" height="17">
                                                <asp:DropDownList ID="XsId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="XsId_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                当前学籍状态：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:Label ID="QZhuangtai" runat="server"></asp:Label>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>生效学期：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Xueqi" runat="server" Enabled=false>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>生效学期段：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Xueduan" runat="server" Enabled=false>
                                                    <asp:ListItem>上学期</asp:ListItem>
                                                    <asp:ListItem>下学期</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>变化后状态：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="HZhuangtai" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr id="printshow3">
                                            <td align="center" class="newtd2" colspan="8" height="26" width="33%">
                                                <div align="center">
                                                    <font face="宋体">
                                                        <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                    </font>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="newtd2" colspan="8" style="height: 26px">
                                                <b>操作日志</b></td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="newtd2" colspan="8" style="height: 26px">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                    BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="1"
                                                    GridLines="None" OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                    Width="100%">
                                                    <PagerSettings Visible="False" />
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Xueqi" HeaderText="生效学期" SortExpression="Xueqi">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Xueduan" HeaderText="生效学期段" SortExpression="Xueduan">
                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="QZhuangtai" HeaderText="变化前状态" SortExpression="QZhuangtai">
                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                            <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="HZhuangtai" HeaderText="变化后状态" SortExpression="HZhuangtai">
                                                            <HeaderStyle CssClass="newtitle" HorizontalAlign="Center"  Wrap="False" />
                                                            <ItemStyle Wrap="False"  HorizontalAlign="Center"/>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Realname" HeaderText="操作人" SortExpression="Realname">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Nowtimes" HeaderText="时间" SortExpression="Nowtimes">
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
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <asp:TextBox ID="NianjiName" runat="server" Visible="false"></asp:TextBox></table>
    </form>
</body>
</html>
