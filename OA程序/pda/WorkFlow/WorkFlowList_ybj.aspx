<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowList_ybj.aspx.cs" Inherits="xyoa.pda.WorkFlow.WorkFlowList_ybj" %>
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, minimum-scale=1, maximum-scale=1">
    <title>移动设备平台</title>
    <link rel="stylesheet" href="/pda/images/pda.css">

    <script src="/pda/images/public.js" type="text/javascript"></script>

    <script src="/pda/images/jquery.min.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript">
var $ = jQuery.noConflict();
	$(function() {
		$('#activator').click(function(){
				$('#box').animate({'top':'50px'},200);
		});
		$('#boxclose').click(function(){
				$('#box').animate({'top':'-1400px'},500);
		});
		$('#activator_share').click(function(){
				$('#box_share').animate({'top':'50px'},200);
		});
		$('#boxclose_share').click(function(){
				$('#box_share').animate({'top':'-1400px'},500);
		});
		$('#meunbn').click(function(){
		        $('#box').animate({'top':'-1400px'},500);
				$('#box_meun').animate({'top':'50px'},200);
		});
		$('#boxclose_meun').click(function(){
				$('#box_meun').animate({'top':'-1400px'},500);
		});
	});

function showMenu()
{
$('#box_meun').animate({'top':'-1400px'},500);
$('#box').animate({'top':'50px'},200);
}

</script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="overlay">
        </div>
        <div class="ui-loader loading">
            <span class="ui-icon ui-icon-loading"></span>
            <h1>
                正在载入...</h1>
        </div>
        <div id="box" class="box">
            <div class="box_content">
                <div class="box_content_tab">
                    查询
                </div>
                <div class="box_content_center">
                    <div class="social_share">
                        <ul>
                            <li>工作名称：<asp:TextBox ID="Name" runat="server" Width="100px"></asp:TextBox></li>
                            <li>表单名称：<asp:DropDownList ID="FormName" runat="server" Width="100px">
                            </asp:DropDownList></li>
                            <li>发起人员：<asp:TextBox ID="FqRealname" runat="server" Width="100px"></asp:TextBox></li>
                        </ul>
                        <a id="boxclose" class="boxclose">关闭</a>
                        <asp:Button ID="Button4" runat="server" Text="提交" CssClass="form_submit" OnClick="Button4_Click" />
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
        <div id="box_meun" class="box">
            <div class="box_content">
                <div class="box_content_tab">
                    操作菜单
                </div>
                <div class="box_content_center">
                    <div class="social_share">
                        <ul>
                            <li><a id="box_meun4" onclick="showMenu();">
                                <img border="0" alt="" src="/pda/images/search.png"><br>
                                查询</a></li>
                            <li><a id="A2" onclick="LoadingShow();location.href='WorkFlowListAll.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                全部工作</a></li>
                            <li><a id="A1" onclick="LoadingShow();location.href='WorkFlowList.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                未接收</a></li>
                            <li><a id="A3" onclick="LoadingShow();location.href='WorkFlowList_blz.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                办理中</a></li>
                            <li><a id="A4" onclick="LoadingShow();location.href='WorkFlowList_ybj.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                已办结</a></li>
                            <li><a id="A5" onclick="LoadingShow();location.href='WorkFlowList_ywt.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                已委托</a></li>
                            <li><a id="A6" onclick="LoadingShow();location.href='MyAddWorkFlow.aspx';">
                                <img border="0" alt="" src="/pda/images/myspace.png"><br>
                                我发起的</a></li>
                            <li><a id="A7" onclick="LoadingShow();location.href='MyAddWorkFlowJb.aspx';">
                                <img border="0" alt="" src="/pda/images/myspace.png"><br>
                                我经办过的</a></li>
                        </ul>
                        <a id="boxclose_meun" class="boxclose">关闭</a>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
        <div id="header">
            <table width="100%" height="40" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="45px" align="left">
                        <asp:Button ID="Button1" runat="server" CssClass="button_shouji" Text="返回" Width="45px"
                            OnClick="Button1_Click" /></td>
                    <td align="center">
                        <span class="t">已办结待办工作</span></td>
                    <td width="45px" align="right">
                        <input id="meunbn" type="button" value="操作" class="button_shouji" width="45px" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divgrid" class="divheight">
            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                BackColor="White" BorderColor="White" BorderWidth="0px" CellPadding="0" ShowHeader="False"
                GridLines="None" AllowPaging="True" PageSize="12" OnRowDataBound="GridView1_RowDataBound"
                OnRowCommand="GridView1_RowCommand">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="corner_wrap">
                                <h2>
                                    <%# DataBinder.Eval(Container.DataItem, "Name")%>
                                </h2>
                                <h1>
                                    <font color="red">表单名称：</font><%# DataBinder.Eval(Container.DataItem, "FormName")%><br>
                                    <font color="red">发起人：</font><%# DataBinder.Eval(Container.DataItem, "FqRealname")%><br>
                                    <font color="red">步骤：</font><asp:Label ID="Label2" runat="server"></asp:Label><br>
                                    <font color="red">状态：</font><asp:Label ID="States" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "States")%>'></asp:Label><br>
                                    <font color="red">最后办理时间：</font><%# DataBinder.Eval(Container.DataItem, "UpTimeSet")%>
                                    <asp:Label ID="fujian" runat="server"></asp:Label>
                                    <asp:Label ID="Lid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>'
                                        Visible="false"></asp:Label>
                                    <asp:Label ID="Number" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Number")%>'
                                        Visible="false"></asp:Label>
                                </h1>
                                <h1>
                                    <asp:Label ID="UpNodeId" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UpNodeId") %>'
                                        Visible="false"></asp:Label>
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                    <asp:Label ID="Label4" runat="server"></asp:Label>
                                    <asp:Label ID="Label8" runat="server"></asp:Label>
                                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                    <asp:Label ID="Label3" runat="server"></asp:Label>
                                    <asp:Label ID="Label5" runat="server"></asp:Label>
                                    <asp:Label ID="Label7" runat="server"></asp:Label>
                                    <asp:Label ID="SjStartTime" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "SjStartTime") %>'
                                        Visible="false"></asp:Label>
                                    <asp:Button ID="LinkButton1" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                        CommandName="ShouhuiBj" runat="server" Text="收回" CssClass="form_wf" />
                                    <asp:Button ID="LinkButton2" runat="server" Text="取消委托" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                        CommandName="ShanChuWt" CssClass="form_wf" />
                                </h1>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="shadow_wrap">
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Visible="False" />
                <EmptyDataTemplate>
                    <div align="center">
                        <font color="black">无数据</font></div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        <div id="fenye">
            <div class="fenye_menu">
                <ul>
                    <li>
                        <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnPrev_Click" />
                    </li>
                    <li>
                        <asp:Button ID="btnPrev" runat="server" Text="上页" OnClick="btnPrev_Click" />
                    </li>
                    <li>
                        <asp:Button ID="btnNext" runat="server" Text="下页" OnClick="btnPrev_Click" />
                    </li>
                    <li>
                        <asp:Button ID="btnLast" runat="server" Text="尾页" OnClick="btnPrev_Click" />
                    </li>
                </ul>
            </div>
        </div>
        <div id="footer">
            <div class="footer_menu">
                <ul>
                    <%=ViewState["footulr"] %>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
