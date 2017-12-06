<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ResBfR.aspx.cs" Inherits="xyoa.Resources.ResReport.ResBfR" %>

<html>
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
                                                            物品报废报表
                                                        </td>
                                                        <td width="16%">
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
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='ResBfR.aspx';showwait();">
                                                                <font class="shadow_but">物品报废报表</font></button>
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
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30px"
                                                            background="/oaimg/nextline.gif">
                                                            <tr>
                                                                <td valign="top">
                                                                  物品编号：
                                                                    <asp:TextBox ID="ZyNum" runat="server" Width="112px"></asp:TextBox>
                                                                    物品名称：
                                                                    <asp:TextBox ID="ZyName" runat="server" CssClass="ReadOnlyText" Width="112px"></asp:TextBox>
                                                                    <a href="javascript:void(0)">
                                                                        <img onclick="opencp();" alt="" src="/oaimg/FDJ.gif" border="0"></a>报废时间从<asp:TextBox
                                                                            ID="Starttime" runat="server" Width="80px" onClick="WdatePicker()"></asp:TextBox>至<asp:TextBox ID="Endtime" runat="server" Width="80px"
                                                                                        onClick="WdatePicker()"></asp:TextBox>审批状态：<asp:DropDownList ID="LcZhuangtai" runat="server">
                                                                                                    <asp:ListItem></asp:ListItem>
                                                                                                    <asp:ListItem Value="1">等待办理</asp:ListItem>
                                                                                                    <asp:ListItem Value="2">正在办理</asp:ListItem>
                                                                                                    <asp:ListItem Value="3">通过审批</asp:ListItem>
                                                                                                    <asp:ListItem Value="4">终止审批</asp:ListItem>
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
                                                                BorderWidth="1px" CellPadding="5" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%">
                                                                <PagerSettings Visible="False" />
                                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="物品名称" SortExpression="ZyId">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "ZyName")%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="物品编号" SortExpression="ZyNum">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# DataBinder.Eval(Container.DataItem, "ZyNum")%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="GmTime" HeaderText="报废时间" SortExpression="GmTime" DataFormatString="{0:yyyy-MM-dd}"
                                                                        HtmlEncode="False">
                                                                        <ItemStyle Wrap="False" />
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="GmNum" HeaderText="报废数量" SortExpression="GmNum">
                                                                        <ItemStyle Wrap="False" />
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="GmFeiyong" HeaderText="报废费用" SortExpression="GmFeiyong">
                                                                        <ItemStyle Wrap="False" />
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Gongyinshang" HeaderText="供应商" SortExpression="A.Gongyinshang">
                                                                        <ItemStyle Wrap="False" />
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="审批状态" SortExpression="A.LcZhuangtai">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# ((Eval("LcZhuangtai").ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批")))%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="当前办理人" SortExpression="DqBlXinming">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                                <%# DataBinder.Eval(Container.DataItem, "DqBlXinming")%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="创建人" SortExpression="Realname">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <a href='javascript:void(0)' class="LinkLine" onclick='senduser("<%# DataBinder.Eval(Container.DataItem, "Username")%>")'>
                                                                                <%# DataBinder.Eval(Container.DataItem, "Realname")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" Width="60px" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="操作">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" Width="30px" />
                                                                        <ItemTemplate>
                                                                            <a href='ReBfR_show.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id")%>' class="LinkLine">
                                                                                查看 </a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" Width="30px" />
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
                                                        费用合计：<asp:Label ID="AllMoney" runat="server"></asp:Label>&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            </td>
                                    </tr>
                                </table>
                                <div>
                                    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                </td>
                                            <td valign="top" background="/<%=Session["yangshi"]%>/next_bg.jpg" align="center">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
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
                </td>
            </tr>
        </table>
        <input id="SortText" type="hidden" runat="server" value="order by A.id desc" />
        <asp:TextBox ID="ZyId" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

        <script language="javascript">	
            var  wName_2;  
            function  opencp()  
            {  
                var num=Math.random();
                var clid=""+document.getElementById('ZyId').value+"";
                wName_2=window.showModalDialog("/OpenWindows/OpenZiChang.aspx?tmp="+num+"&id="+clid+"","window", "dialogWidth:780px;DialogHeight=660px;status:no;scroll=yes;help:no");                
                if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("ZyId").value=arr[0]; 
                    document.getElementById("ZyName").value=arr[1]; 
                }
            }
        </script>

    </form>
</body>
</html>
