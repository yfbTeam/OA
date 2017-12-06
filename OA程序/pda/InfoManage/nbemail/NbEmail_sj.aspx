<%@ Page Language="C#" AutoEventWireup="true" Codebehind="NbEmail_sj.aspx.cs" Inherits="xyoa.pda.InfoManage.nbemail.NbEmail_sj" %>

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
                            <li>是否阅读：<asp:DropDownList ID="IfRead" runat="server" Width="100px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem Value="0">未读</asp:ListItem>
                                <asp:ListItem Value="1">已读</asp:ListItem>
                            </asp:DropDownList></li>
                            <li>邮件主题：<asp:TextBox ID="titles" runat="server" Width="100px"></asp:TextBox></li>
                            <li>发送人员：<asp:TextBox ID="FsRealname" runat="server" Width="100px"></asp:TextBox></li>
                            <li>开始时间：<asp:TextBox ID="Starttime" runat="server" Width="100px" onClick="WdatePicker()"></asp:TextBox></li>
                            <li>结束时间：<asp:TextBox ID="Endtime" runat="server" Width="100px" onClick="WdatePicker()"></asp:TextBox></li>
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
                            <li><a id="box_meun1" onclick="LoadingShow();location.href='NbEmail_add.aspx';">
                                <img border="0" alt="" src="/pda/images/technorati.png"><br>
                                写邮件</a></li>
                            <li><a id="box_meun4" onclick="showMenu();">
                                <img border="0" alt="" src="/pda/images/search.png"><br>
                                查询</a></li>
                            <li>
                                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="/pda/images/rss.png"
                                    OnClick="ImageButton4_Click" />
                                <br>
                                全部邮件</li>
                            <li>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/pda/images/rss.png"
                                    OnClick="ImageButton1_Click" />
                                <br>
                                未读邮件</li>
                            <li><a id="box_meun3">
                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="/pda/images/rss.png"
                                    OnClick="ImageButton2_Click" /><br>
                                已读邮件</a></li>
                            <li><a id="A2" onclick="LoadingShow();location.href='NbEmail_fj.aspx';">
                                <img border="0" alt="" src="/pda/images/linkedin.png"><br>
                                已发邮件</a></li>
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
                        <span class="t">内部邮件</span></td>
                    <td width="45px" align="right">
                        <input id="meunbn" type="button" value="操作" class="button_shouji" width="45px" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divgrid" class="divheight">
            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                BackColor="White" BorderColor="White" BorderWidth="0px" CellPadding="0" ShowHeader="False"
                GridLines="None" AllowPaging="True" PageSize="12">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="corner_wrap" onclick="LoadingShow();location.href='NbEmail_sj_show.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id")%>';">
                                <h2>
                                    <img src='/oaimg/pda/<%# DataBinder.Eval(Container.DataItem, "IfRead") %>.gif'><%# DataBinder.Eval(Container.DataItem, "titles") %>
                                </h2>
                                <h1>
                                    <%# DataBinder.Eval(Container.DataItem, "FsRealname")%>
                                    <%# DataBinder.Eval(Container.DataItem, "FsTime")%>
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
