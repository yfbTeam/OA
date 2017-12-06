<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Jiaofei_Lb.aspx.cs" Inherits="xyoa.SchTable.Houqin.Jiaofei.Jiaofei_Lb" %>

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
    
   if(document.getElementById('Jine').value=='')
    {
    alert('缴费金额不能为空');
    form1.Jine.focus();
    return false;
    }	
    
    
   if(document.getElementById('Leixing').value=='')
    {
    alert('缴费类型不能为空');
    form1.Leixing.focus();
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
                                                <font color="red">※</font>学期：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Xueqi" runat="server" Enabled="false">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>学期段：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Xueduan" runat="server" Enabled="false">
                                                    <asp:ListItem>上学期</asp:ListItem>
                                                    <asp:ListItem>下学期</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>缴费金额：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Jine" runat="server" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='1';};"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>缴费类型：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Leixing" runat="server">
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
                                                <b>缴费记录</b></td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="newtd2" colspan="8" style="height: 26px">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                    BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="1"
                                                    GridLines="None" OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                    Width="100%" OnRowCommand="GridView1_RowCommand">
                                                    <PagerSettings Visible="False" />
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Xueqi" HeaderText="学期" SortExpression="Xueqi">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Xueduan" HeaderText="学期段" SortExpression="Xueduan">
                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Jine" HeaderText="金额" SortExpression="Jine">
                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                            <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="LeixingName" HeaderText="缴费类型" SortExpression="Leixing">
                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                            <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Realname" HeaderText="操作人" SortExpression="Realname">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Nowtimes" HeaderText="操作时间" SortExpression="Nowtimes">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="相关操作">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="XiuGai" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                    CommandName="XiuGai">修改</asp:LinkButton>
                                                                <asp:LinkButton ID="ShanChu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                    CommandName="ShanChu">删除</asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" Wrap="False"  Width="60px" />
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
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
           </table> <asp:TextBox ID="NianjiName" runat="server" Visible="false"></asp:TextBox>
    </form>
</body>
</html>
