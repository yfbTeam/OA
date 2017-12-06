<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Luru_PlSdlt.aspx.cs" Inherits="xyoa.SchTable.Chengji.Luru.Luru_PlSdlt" %>

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
                                                                        学期：<asp:DropDownList ID="Xueqi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Xueqi_SelectedIndexChanged"
                                                                            Enabled="false">
                                                                        </asp:DropDownList>
                                                                        学期段：
                                                                        <asp:DropDownList ID="Xueduan" runat="server" Enabled="false">
                                                                            <asp:ListItem>上学期</asp:ListItem>
                                                                            <asp:ListItem>下学期</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        考试日期：
                                                                        <asp:TextBox ID="Riqi" runat="server" Width="80px" onClick="WdatePicker()"></asp:TextBox>
                                                                        考试类型：
                                                                        <asp:DropDownList ID="Leixing" runat="server">
                                                                        </asp:DropDownList>
                                                                        考试科目：
                                                                        <asp:DropDownList ID="Kemu" runat="server">
                                                                        </asp:DropDownList>
                                                                        <asp:Button ID="Button1" runat="server" Text="确定提交" CssClass="button_css" OnClick="Button1_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                            <div id="Div1">
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                                    BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="4" CellSpacing="1"
                                                                    GridLines="None" OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                                    Width="100%">
                                                                    <PagerSettings Visible="False" />
                                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="学生姓名" SortExpression="A.Xingming">
                                                                            <ItemStyle Wrap="True" />
                                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="XsId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "XsId") %>'
                                                                                    Visible="False" Width="0px"></asp:Label>
                                                                                <asp:Label ID="Xingming" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Xingming")%>'
                                                                                    Visible="false"></asp:Label>
                                                                                <a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open ("/SchTable/Xueji/ZaijiSheng/ZaijiSheng_lb_show.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>&Xueduan=<%#DataBinder.Eval(Container.DataItem, "Xueduan")%>&Xueqi=<%#DataBinder.Eval(Container.DataItem, "Xueqi")%>", "_blank", "height=" + ah + ", width=" + aw + ",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=" + loc_y + ",left=" + loc_x + "")'>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "Xingming")%>
                                                                                </a>
                                                                            </ItemTemplate>
                                                                            <FooterStyle Wrap="True" />
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="Xuejihao" HeaderText="学籍号" SortExpression="Xuejihao">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemStyle Wrap="False" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Xuehao" HeaderText="学号" SortExpression="Xuehao">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemStyle Wrap="False" />
                                                                        </asp:BoundField>
                                                                        <asp:TemplateField HeaderText="成绩">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="Chengji" runat="server" Width="100px" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='60';};"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="是否免考">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="Miankao" runat="server">
                                                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                                                    <asp:ListItem>是</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="是否缺考">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="Quekao" runat="server">
                                                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                                                    <asp:ListItem>是</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="是否补考">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="Bukao" runat="server">
                                                                                    <asp:ListItem Selected="True">否</asp:ListItem>
                                                                                    <asp:ListItem>是</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="补考成绩">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:TextBox ID="BukaoCj" runat="server" Width="100px"></asp:TextBox>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="态度">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:DropDownList ID="Taidu" runat="server">
                                                                                    <asp:ListItem Selected="True">认真</asp:ListItem>
                                                                                    <asp:ListItem>较认真</asp:ListItem>
                                                                                    <asp:ListItem>一般</asp:ListItem>
                                                                                    <asp:ListItem>差</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="学籍状态" SortExpression="XuejiZhuangtai">
                                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="XuejiZhuangtai" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "XuejiZhuangtai")%>'
                                                                                    Visible="false"></asp:Label>
                                                                                <asp:Label ID="LXuejiZhuangtai" runat="server"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle Wrap="False" HorizontalAlign="Left" />
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
