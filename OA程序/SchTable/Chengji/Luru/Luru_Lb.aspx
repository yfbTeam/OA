<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Luru_Lb.aspx.cs" Inherits="xyoa.SchTable.Chengji.Luru.Luru_Lb" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script>
function chknull()
{
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
    
    showwait();	
 
}  
    </script>

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
                                                                <font class="shadow_but">学籍列表</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                            <asp:Button ID="DelData" runat="server" Text="删 除" CssClass="button_blue" OnClick="DelData_Click" />
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
                                            <asp:Panel ID="Panel1" runat="server">
                                                <div align="center">
                                                    <asp:Label ID="Label1" runat="server" Text="请先选择班级" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel2" runat="server">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30px"
                                                                background="/oaimg/nextline.gif">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <asp:DropDownList ID="DXingming" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DXingming_SelectedIndexChanged">
                                                                        </asp:DropDownList>&nbsp; 姓名：<asp:TextBox ID="Xingming" runat="server" Width="77px"></asp:TextBox>
                                                                        学期：<asp:DropDownList ID="Xueqi" runat="server" Enabled="false">
                                                                        </asp:DropDownList>
                                                                        学期段：
                                                                        <asp:DropDownList ID="Xueduan" runat="server" Enabled="false">
                                                                            <asp:ListItem>上学期</asp:ListItem>
                                                                            <asp:ListItem>下学期</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        考试日期：
                                                                       <asp:TextBox ID="Startime" runat="server" onClick="WdatePicker()" Width="75px"></asp:TextBox>至<asp:TextBox ID="Endtime" runat="server" onClick="WdatePicker()"
                                                                                Width="75px"></asp:TextBox>
                                                                        考试类型：
                                                                        <asp:DropDownList ID="Leixing" runat="server">
                                                                        </asp:DropDownList>
                                                                        考试科目：
                                                                        <asp:DropDownList ID="Kemu" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:Button ID="SearchData" runat="server" Text="查 询" OnClick="SearchData_Click"
                                                                            CssClass="button_css" />
                                                                        <asp:Button ID="Button2" runat="server" CssClass="button_css" OnClick="Button2_Click"
                                                                            Text="退 出" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div id="Div1">
                                                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                    AutoGenerateColumns="False" BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None"
                                                                    BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                                    OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%" OnRowCommand="GridView1_RowCommand">
                                                                    <PagerSettings Visible="False" />
                                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="选择">
                                                                            <ItemStyle HorizontalAlign="Center" Wrap="True" Width="30px" />
                                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="CheckSelect" runat="server" />
                                                                                <asp:Label ID="LabVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                                    Visible="False" Width="0px"></asp:Label>
                                                                                <asp:Label ID="LabNameVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Xingming") %>'
                                                                                    Visible="False" Width="0px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <FooterStyle Wrap="True" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="学生姓名" SortExpression="C.Xingming">
                                                                            <ItemStyle Wrap="True" />
                                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open ("/SchTable/Xueji/ZaijiSheng/ZaijiSheng_lb_show.aspx?id=<%#DataBinder.Eval(Container.DataItem, "XsId")%>&Xueduan=<%#DataBinder.Eval(Container.DataItem, "Xueduan")%>&Xueqi=<%#DataBinder.Eval(Container.DataItem, "Xueqi")%>", "_blank", "height=" + ah + ", width=" + aw + ",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=" + loc_y + ",left=" + loc_x + "")'>
                                                                                    <font color="blue">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "Xingming")%>
                                                                                    </font></a>
                                                                            </ItemTemplate>
                                                                            <FooterStyle Wrap="True" />
                                                                        </asp:TemplateField>
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
                                                                        <asp:BoundField DataField="RealName" HeaderText="操作人" SortExpression="A.RealName">
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
                                                                &nbsp;
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div>
                                                    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                     
                                                            <td valign="top" background="/<%=Session["yangshi"]%>/next_bg.jpg" align="center">
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <a href="javascript:void(0)" onclick="checkAll()" class="line">全选</a> &nbsp;&nbsp;<a
                                                                                href="javascript:void(0)" onclick="fanAll()" class="line">反选</a> &nbsp;&nbsp;
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
                                                                                &nbsp;&nbsp;每页<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                                                                                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                                                    <asp:ListItem>10</asp:ListItem>
                                                                                    <asp:ListItem>15</asp:ListItem>
                                                                                    <asp:ListItem>25</asp:ListItem>
                                                                                    <asp:ListItem>50</asp:ListItem>
                                                                                    <asp:ListItem>80</asp:ListItem>
                                                                                    <asp:ListItem>100</asp:ListItem>
                                                                                </asp:DropDownList>条数据&nbsp; 共有<font color="red"><asp:Label ID="CountsLabel" runat="server"></asp:Label></font>条数据
                                                                                &nbsp;&nbsp;当前为第<font color="red"><asp:Label ID="CurrentlyPageLabel" runat="server"></asp:Label></font>页
                                                                                &nbsp;&nbsp; 共<font color="red"><asp:Label ID="AllPageLabel" runat="server"></asp:Label></font>页</font>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>

                                                        </tr>
                                                    </table>
                                                </div>
                                            </asp:Panel>
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
