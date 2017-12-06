﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyPlanJk_lb.aspx.cs" Inherits="xyoa.OfficeMenu.WorkPlan.MyPlanJk_lb" %>

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
                                                            计划监控
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
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='MyPlanJk.aspx?left=1';">
                                                                <font class="shadow_but">按人员</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='MyPlanJk.aspx?left=2';">
                                                                <font class="shadow_but">按部门</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='MyPlanJk.aspx?left=3';">
                                                                <font class="shadow_but">按时间</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='MyPlanJk.aspx?left=4';">
                                                                <font class="shadow_but">按分类</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='MyPlanJk_lb.aspx';">
                                                                <font class="shadow_but">按列表</font></button>
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
                                                                 <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="12" RepeatDirection="Horizontal">
                                                                    </asp:CheckBoxList>
                                                                    标题：<asp:TextBox ID="Biaoti" runat="server" Width="83px"></asp:TextBox>
                                                                    类型：<asp:DropDownList ID="Leixing" runat="server">
                                                                    </asp:DropDownList>
                                                                    状态：<asp:DropDownList ID="DqState" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem Value="1">未处理</asp:ListItem>
                                                                        <asp:ListItem Value="2">进行中</asp:ListItem>
                                                                        <asp:ListItem Value="3">已办结</asp:ListItem>
                                                                        <asp:ListItem Value="4">已暂停</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    优先级：<asp:DropDownList ID="Youxian" runat="server">
                                                                        <asp:ListItem></asp:ListItem>
                                                                        <asp:ListItem Value="1">高</asp:ListItem>
                                                                        <asp:ListItem Value="2">中</asp:ListItem>
                                                                        <asp:ListItem Value="3">低</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    创建时间：<asp:TextBox ID="Startime" runat="server" onClick="WdatePicker()" Width="66px"></asp:TextBox>至<asp:TextBox ID="Endtime" runat="server" onClick="WdatePicker()"
                                                                                Width="66px"></asp:TextBox>
                                                                                            是否阅读：<asp:DropDownList ID="Pizhu" runat="server">
                                                                                             <asp:ListItem></asp:ListItem>
                                                                                             <asp:ListItem Selected=True>未阅读</asp:ListItem>
                                                                                             <asp:ListItem>已阅读</asp:ListItem>
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
                                                                BorderWidth="1px" CellPadding="4" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%">
                                                                <PagerSettings Visible="False" />
                                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="计划标题" SortExpression="Biaoti">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <a href='MyPlanJk_lb_show.aspx?id= <%# DataBinder.Eval(Container.DataItem, "id")%>' class="LinkLine">
                                                                                <%# DataBinder.Eval(Container.DataItem, "Biaoti")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="LeixingName" HeaderText="计划类型" SortExpression="LeixingName">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="开始时间" SortExpression="StartTime">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# ((Eval("StartTime").ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "")))%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="结束时间" SortExpression="EndTime">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# ((Eval("EndTime").ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "")))%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="优先级" SortExpression="A.Youxian">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# ((Eval("Youxian").ToString().Replace("1", "高").Replace("2", "中").Replace("3", "低")))%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="当前状态" SortExpression="A.DqState">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# ((Eval("DqState").ToString().Replace("1", "未处理").Replace("2", "进行中").Replace("3", "已办结").Replace("4", "已暂停")))%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                     <asp:TemplateField HeaderText="创建人" SortExpression="Realname">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <a href='javascript:void(0)' onclick='senduser("<%# DataBinder.Eval(Container.DataItem, "Username")%>")'>
                                                                                <%# DataBinder.Eval(Container.DataItem, "Realname")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="SetTimes" HeaderText="创建时间" SortExpression="SetTimes">
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
                                                                    </asp:DropDownList>条数据&nbsp; 共有<font color="red"><asp:Label ID="CountsLabel"
                                                                    runat="server"></asp:Label></font>条数据 &nbsp;当前为第<font color="red"><asp:Label ID="CurrentlyPageLabel"
                                                                        runat="server"></asp:Label></font>页 &nbsp;&nbsp; 共<font color="red"><asp:Label ID="AllPageLabel"
                                                                            runat="server"></asp:Label></font>页</font>
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

        <script language="javascript">	

            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
