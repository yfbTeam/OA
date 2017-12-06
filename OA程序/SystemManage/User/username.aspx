<%@ Page Language="C#" AutoEventWireup="true" Codebehind="username.aspx.cs" Inherits="xyoa.SystemManage.User.username" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script>
//function  opendr()  
//{  
//    var num=Math.random();
//    window.showModalDialog("username_dr.aspx?tmp="+num+"","window","dialogWidth:580px;DialogHeight=320px;status:no;scroll=yes;help:no");                
//}

function opendr()
{
var num=Math.random();
window.showModalDialog("username_dr.aspx?tmp="+num+"",window,"dialogWidth:580px;DialogHeight=320px;status:no;scroll=yes;help:no")
}
    </script>

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
                                                        <td width="15%" valign="bottom">
                                                            用户管理</td>
                                                        <td width="82%">
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
                                        <td width="17" style="height: 40px">
                                            </td>
                                        <td valign="top" style="height: 40px">
                                            <div id="printshow2">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="height: 26px;">
                                                            <button class="btn4on" type="button" onclick="javascript:window.location='username.aspx';showwait();">
                                                                <font class="shadow_but">正常用户</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='usernameys.aspx';showwait();">
                                                                <font class="shadow_but">已删用户</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                            <asp:Button ID="AddData" runat="server" Text="增 加" CssClass="button_blue" OnClick="AddData_Click" />
                                                            <input id="Button3" type="button" value="导 入" class="button_blue" runat="server" />
                                                            <asp:Button ID="ShowData" runat="server" Text="查 看" CssClass="button_blue" OnClick="ShowData_Click" />
                                                            <asp:Button ID="UpdateData" runat="server" Text="修 改" CssClass="button_blue" OnClick="UpdateData_Click" />
                                                            <asp:Button ID="ShouquanData" runat="server" Text="授 权" CssClass="button_blue" OnClick="ShouquanData_Click" />
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
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30px"
                                                            background="/oaimg/nextline.gif">
                                                            <tr>
                                                                <td valign="top">
                                                                    姓名：<asp:TextBox ID="Realname" runat="server" Width="62px"></asp:TextBox>
                                                                    用户名：<asp:TextBox ID="Usernames" runat="server" Width="62px"></asp:TextBox>
                                                                    部门：<asp:DropDownList ID="BuMenId" runat="server">
                                                                    </asp:DropDownList>
                                                                    角色：<asp:DropDownList ID="JueseId" runat="server">
                                                                    </asp:DropDownList>
                                                                    职位：<asp:DropDownList ID="Zhiweiid" runat="server">
                                                                    </asp:DropDownList>
                                                                    <asp:Button ID="SearchData" runat="server" Text="查 询" OnClick="SearchData_Click"
                                                                        CssClass="button_css" />
                                                                    <asp:Button ID="Button2" runat="server" CssClass="button_css" OnClick="Button2_Click"
                                                                        Text="退 出" /></td>
                                                            </tr>
                                                        </table>
                                                        <div id="Div1">
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
                                                                            <asp:Label ID="LabNameVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "username") %>'
                                                                                Visible="False" Width="0px"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterStyle Wrap="True" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="真实姓名" SortExpression="Realname">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <a href='javascript:void(0)' onclick='senduser("<%# DataBinder.Eval(Container.DataItem, "Username")%>")'>
                                                                                <%# DataBinder.Eval(Container.DataItem, "Realname")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="Username" HeaderText="用户名" SortExpression="Username">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="BuMenName" HeaderText="部门" SortExpression="BuMenName">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="JueseName" HeaderText="角色" SortExpression="JueseName">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="ZhiweiName" HeaderText="职位" SortExpression="ZhiweiName">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="允许登陆" SortExpression="A.Iflogin">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False"  Width="60px"/>
                                                                        <ItemTemplate>
                                                                            <img src="/oaimg/u_<%# DataBinder.Eval(Container.DataItem, "Iflogin")%>.png" />
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False"  HorizontalAlign=Center/>
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
                                        </td>
                                        <td width="17">
                                            </td>
                                    </tr>
                                </table>
                                <div>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
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
            </tr>
        </table>
        </td> </tr> </table>
        <input id="SortText" type="hidden" runat="server" value="order by A.paixu asc" />

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
