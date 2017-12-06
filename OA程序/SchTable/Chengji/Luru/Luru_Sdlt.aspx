<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Luru_Sdlt.aspx.cs" Inherits="xyoa.SchTable.Chengji.Luru.Luru_Sdlt" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('XsId').value=='')
    {
        alert('学生姓名不能为空');
        form1.XsId.focus();
        return false;
    }	
    
    if(document.getElementById('Riqi').value=='')
    {
        alert('考试日期不能为空');
        form1.Riqi.focus();
        return false;
    }	

    if(document.getElementById('Leixing').value=='')
    {
        alert('考试类型不能为空');
        form1.Leixing.focus();
        return false;
    }	

    if(document.getElementById('Kemu').value=='')
    {
        alert('考试科目不能为空');
        form1.Kemu.focus();
        return false;
    }	

    if(document.getElementById('Chengji').value=='')
    {
        alert('成绩不能为空');
        form1.Chengji.focus();
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
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>学生姓名：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="XsId" runat="server" AutoPostBack="True" OnSelectedIndexChanged="XsId_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                学期：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Xueqi" runat="server" Enabled="false">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                学期段：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Xueduan" runat="server" Enabled="false">
                                                    <asp:ListItem>上学期</asp:ListItem>
                                                    <asp:ListItem>下学期</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>考试日期：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Riqi" runat="server"  onClick="WdatePicker()"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>考试类型：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Leixing" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>考试科目：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Kemu" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                <font color="red">※</font>成绩：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="Chengji" runat="server" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='60';};"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                是否免考：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Miankao" runat="server">
                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                    <asp:ListItem>是</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                是否缺考：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Quekao" runat="server">
                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                    <asp:ListItem>是</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                是否补考：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Bukao" runat="server">
                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                    <asp:ListItem>是</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                补考成绩：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:TextBox ID="BukaoCj" runat="server"></asp:TextBox>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                态度：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:DropDownList ID="Taidu" runat="server">
                                                    <asp:ListItem Selected="True">认真</asp:ListItem>
                                                    <asp:ListItem>较认真</asp:ListItem>
                                                    <asp:ListItem>一般</asp:ListItem>
                                                    <asp:ListItem>差</asp:ListItem>
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
                                                <b>成绩记录</b></td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="newtd2" colspan="8" style="height: 26px">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                    BorderColor="#4D77B1"  BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="1"
                                                    GridLines="None" OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                    Width="100%" OnRowCommand="GridView1_RowCommand">
                                                    <PagerSettings Visible="False" />
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <Columns>
                                                       <asp:BoundField DataField="Riqi" HeaderText="考试日期" SortExpression="Riqi" DataFormatString="{0:d}">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemStyle Wrap="False" />
                                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="考试类型" SortExpression="Leixing">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="Leixing" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Leixing")%>'
                                                                    Visible="false"></asp:Label>
                                                                <asp:Label ID="LLeixing" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="考试科目" SortExpression="Kemu">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="Kemu" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Kemu")%>'
                                                                    Visible="false"></asp:Label>
                                                                <asp:Label ID="LKemu" runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Chengji" HeaderText="成绩" SortExpression="Chengji">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Miankao" HeaderText="是否免考" SortExpression="Miankao">
                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Quekao" HeaderText="是否缺考" SortExpression="Quekao">
                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                            <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Bukao" HeaderText="是否补考" SortExpression="Bukao">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemStyle Wrap="True" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="BukaoCj" HeaderText="补考成绩" SortExpression="BukaoCj">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Taidu" HeaderText="态度" SortExpression="Taidu">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RealName" HeaderText="操作人" SortExpression="RealName">
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
                                                                            <ItemStyle HorizontalAlign="Center" Wrap="False" Width="60px" />
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
        </table>
    </form>
</body>
</html>
