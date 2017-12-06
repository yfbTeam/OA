<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyPage_yxz.aspx.cs" Inherits="xyoa.InfoManage.zhiao.MyPage_yxz" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>
    <script>
function m_show(id)
{ 
var num=Math.random();
window.showModalDialog('MyPage_zl_xz.aspx?id='+id+'&tmp='+num+'','window','dialogWidth:727px;DialogHeight=400px;status:no;help=no;scroll=on');window.location='#'
}  
    </script>

</head>
<body class="newbody" style="overflow: auto">
    <form id="form1" runat="server">
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
                                                                    所属类别：
                                                                    <asp:TextBox ID="LeibieName" runat="server" CssClass="ReadOnlyText"></asp:TextBox>
                                                                    <a href="javascript:void(0)">
                                                                        <img onclick="opencp();" alt="" src="/oaimg/FDJ.gif" border="0"></a> 文件名称：<asp:TextBox
                                                                            ID="Name" runat="server"></asp:TextBox>
                                                                    <asp:Button ID="SearchData" runat="server" Text="查 询" OnClick="SearchData_Click"
                                                                        CssClass="button_css" />
                                                                    <asp:Button ID="Button2" runat="server" CssClass="button_css" OnClick="Button2_Click"
                                                                        Text="退 出" /></td>
                                                            </tr>
                                                        </table>
                                                        <div id="Div1">
                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None"
                                                                BorderWidth="1px" CellPadding="4" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%">
                                                                <PagerSettings Visible="False" />
                                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="文件名称" SortExpression="A.Name">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <img src="/oaimg/filetype/<%# DataBinder.Eval(Container.DataItem, "Filetype")%>.gif" />
                                                                            <a href="MyPage_yxz_show.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id")%>">
                                                                                <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="left" />
                                                                    </asp:TemplateField>
                                                                                  <asp:TemplateField HeaderText="下载次数" SortExpression="A.cishu">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <a href='javascript:void(0)' onclick='m_show("<%# DataBinder.Eval(Container.DataItem, "id")%>")' title="点击可查看下载人员">
                                                                                <%# DataBinder.Eval(Container.DataItem, "cishu")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
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
                                                                    <asp:BoundField DataField="Settimes" HeaderText="更新时间" SortExpression="Settimes">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                     <asp:TemplateField HeaderText="所属类别" SortExpression="LeibieName">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Leibie" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Leibie") %>'
                                                                                Visible="False" Width="0px"></asp:Label>
                                                                            <asp:Label ID="LeibieName" runat="server"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
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
                                                        <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
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
        <asp:TextBox ID="Leibie" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script>
            var  wName_2;  
            function  opencp()  
            {  
                var num=Math.random();
                var clid=""+document.getElementById('Leibie').value+"";
                wName_2=window.showModalDialog("/OpenWindows/Openleibie_zl.aspx?tmp="+num+"&id="+clid+"","window", "dialogWidth:780px;DialogHeight=660px;status:no;scroll=yes;help:no");                
                if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("Leibie").value=arr[0]; 
                    document.getElementById("LeibieName").value=arr[1]; 
                }
            }
        </script>

    </form>
</body>
</html>
