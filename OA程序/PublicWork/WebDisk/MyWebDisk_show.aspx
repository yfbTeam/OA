<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyWebDisk_show.aspx.cs"
    Inherits="xyoa.PublicWork.WebDisk.MyWebDisk_show" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/js/OpenWin.js" type="text/javascript"></script>

    <script>
    function delf()
    {
    if (!confirm("是否确定删除文件夹？\n此操作将删除对应文件夹的子文件夹和文件夹里面的所有文件！"))
    return false;
    }
    
    
function  Openczrz(num)  
{
window.open ("MyWebDisk_Rz.aspx?KeyId="+num+"", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}



function  OpenSpyj(num)  
{
window.open ("MyWebDisk_pz.aspx?KeyId="+num+"", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}


function OpenDisk(id)
{
    var tmp=Math.random();
    window.open("Document_online.aspx?tmp="+tmp+"&id="+id+"","newwindow","height=700, width=960, top=0, left=30, toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no");

}
    </script>

    <style type="text/css">
.caozuo {
	BORDER-RIGHT: black 0px solid; BORDER-TOP: black 0px solid; DISPLAY: none; Z-INDEX: 1; BORDER-LEFT: black 0px solid; BORDER-BOTTOM: black 0px solid; POSITION: absolute; BACKGROUND-COLOR: #cccccc
}

.Operation {
	LINE-HEIGHT: 20px; BORDER-RIGHT: #5fa6cf 1px solid; BORDER-TOP: #5fa6cf 1px solid; PADDING-LEFT: 0px; BACKGROUND: #fafdff; LEFT: -3px; PADDING-BOTTOM: 5px; BORDER-LEFT: #5fa6cf 1px solid; WIDTH: 70px; PADDING-TOP: 5px; BORDER-BOTTOM: #5fa6cf 1px solid; POSITION: absolute; TOP: -8px
}

.Operation A {
	PADDING-LEFT: 6px; WIDTH: 70px; COLOR: #277fc2
}
.Operation A:hover {
	COLOR: #ffffff; BACKGROUND-COLOR: #277fc2
}
</style>
</head>
<body class="newbody" style="overflow: auto">
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" Visible=false></asp:TextBox>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="10" border="0" cellpadding="0" cellspacing="0">
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
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30px"
                                                            background="/oaimg/nextline.gif">
                                                            <tr>
                                                                <td valign="top">
                                                                    文件名称：<asp:TextBox ID="Titles" runat="server"></asp:TextBox>
                                                                    <asp:Button ID="SearchData" runat="server" Text="查 询" OnClick="SearchData_Click"
                                                                        CssClass="button_css" />
                                                                    <asp:Button ID="Button2" runat="server" CssClass="button_css" OnClick="Button2_Click"
                                                                        Text="退 出" /></td>
                                                            </tr>
                                                        </table>
                                                        <div>
                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None"
                                                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%">
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
                                                                            <asp:Label ID="LabNameVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OldName") %>'
                                                                                Visible="False" Width="0px"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterStyle Wrap="True" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="文件名称" SortExpression="OldName">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <img src="/oaimg/filetype/<%# DataBinder.Eval(Container.DataItem, "Fjtype")%>.gif" />
                                                                                 <asp:Label ID="Name" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "OldName")%>' Visible=false></asp:Label>
                                                                                <asp:Label ID="OldName" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="left" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="创建人" SortExpression="A.Realname">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <a href='javascript:void(0)' onclick='senduser("<%# DataBinder.Eval(Container.DataItem, "Username")%>")'>
                                                                                <%# DataBinder.Eval(Container.DataItem, "Realname")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="NowTimes" HeaderText="更新日期" SortExpression="NowTimes"
                                                                        DataFormatString="{0:yyyy-MM-dd}" HtmlEncode="False">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="操作">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Fjtype" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Fjtype")%>' Visible=false></asp:Label>
                                                                            <asp:Label ID="Lid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id")%>' Visible=false></asp:Label>
                                                                            <asp:Label ID="NewName" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NewName")%>' Visible=false></asp:Label>
                                                                            <asp:Label ID="TypeId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "TypeId")%>' Visible=false></asp:Label>
                                                                            <asp:Label ID="Caidan" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" Width="30px" />
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
                                                        <table align="center" class="nextpage" border="0" cellpadding="4" cellspacing="1"
                                                            width="100%" id="tableprint">
                                                            <tr>
                                                                <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                                    文件操作：</td>
                                                                <td class="newtd2" colspan="3" width="85%" style="height: 17px">
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">新建文件</asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton9_Click">发送文件</asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">删除文件</asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton10_Click">修改文件</asp:LinkButton>
                                                                    <asp:Label ID="Label1" runat="server" Text="文件转移："></asp:Label><asp:DropDownList ID="Folder" runat="server" Width="121px">
                                                                    </asp:DropDownList>
                                                                    <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">确定转移</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" class="newtd1" nowrap="nowrap" style="height: 17px" width="15%">
                                                                    文件夹操作：
                                                                </td>
                                                                <td class="newtd2" colspan="3" style="height: 17px" width="85%">
                                                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">新建文件夹</asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">修改文件夹</asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">文件夹权限</asp:LinkButton>
                                                                    <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">删除文件夹</asp:LinkButton>
                                                                    &nbsp;&nbsp; 当前目录：<font color="red"><asp:Label ID="Namefile" runat="server"></asp:Label>。创建人：<asp:Label
                                                                        ID="CjName" runat="server"></asp:Label></font>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td valign="top" background="/<%=Session["yangshi"]%>/next_bg.jpg" align="center">
                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <a href="javascript:void(0)" onclick="checkAll()" class="line">全选</a>&nbsp;<a href="javascript:void(0)"
                                                                                    onclick="fanAll()" class="line">反选</a>&nbsp;
                                                                                <asp:LinkButton ID="btnFirst" runat="server" CssClass="line" CommandArgument="first"
                                                                                    OnClick="PagerButtonClick">首页</asp:LinkButton>
                                                                                &nbsp;<asp:LinkButton ID="btnPrev" runat="server" CssClass="line" CommandArgument="prev"
                                                                                    OnClick="PagerButtonClick">上页</asp:LinkButton>
                                                                                &nbsp;<asp:LinkButton ID="btnNext" runat="server" CssClass="line" CommandArgument="next"
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
                                                                    </asp:DropDownList>条数据&nbsp;共有<font color="red"><asp:Label ID="CountsLabel"
                                                                                        runat="server"></asp:Label></font>条数据&nbsp;第<font color="red"><asp:Label ID="CurrentlyPageLabel"
                                                                                            runat="server"></asp:Label></font>页&nbsp;共<font color="red"><asp:Label ID="AllPageLabel"
                                                                                                runat="server"></asp:Label></font>页</font>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                <div>
                                    &nbsp;</div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <input id="SortText" type="hidden" runat="server" value="order by A.id desc" />
    </form>
</body>
</html>
