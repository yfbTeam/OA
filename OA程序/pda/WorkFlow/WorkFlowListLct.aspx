<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowListLct.aspx.cs" Inherits="xyoa.pda.WorkFlow.WorkFlowListLct" %>

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
        <div id="box_meun" class="box">
            <div class="box_content">
                <div class="box_content_tab">
                    操作菜单
                </div>
                <div class="box_content_center">
                    <div class="social_share">
                        <ul>
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
                        <span class="t">办理流程图</span></td>
                    <td width="45px" align="right">
                        <input id="meunbn" type="button" value="操作" class="button_shouji" width="45px" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divgrid" class="divheight">
           <asp:Label ID="Liucheng" runat="server"></asp:Label>
            <asp:TextBox ID="Number" runat="server" Visible="false"></asp:TextBox>
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
