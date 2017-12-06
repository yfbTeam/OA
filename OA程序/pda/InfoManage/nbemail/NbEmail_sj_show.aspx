﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="NbEmail_sj_show.aspx.cs"
    Inherits="xyoa.pda.InfoManage.nbemail.NbEmail_sj_show" %>

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
                            <li><a id="A1" onclick="LoadingShow();location.href='NbEmail_sj.aspx';">
                                <img border="0" alt="" src="/pda/images/home.png"><br>
                                内部邮件</a></li>
                            <li><a id="box_meun1" onclick="LoadingShow();location.href='NbEmail_add.aspx';">
                                <img border="0" alt="" src="/pda/images/technorati.png"><br>
                                写邮件</a></li>
                            <li>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/pda/images/rss.png"
                                    OnClick="ImageButton1_Click" />
                                <br>
                                回复邮件</li>
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
                        <span class="t">查看内部邮件</span></td>
                    <td width="45px" align="right">
                        <input id="meunbn" type="button" value="操作" class="button_shouji" width="45px" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divgrid" class="divheight">
            <table align="center" border="0" cellpadding="4" cellspacing="1" width="99%" class="nextpage"
                id="tableprint">
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="17%">
                        邮件主题：</td>
                    <td class="newtd2" colspan="3" width="83%">
                        <asp:Label ID="Number" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="FsUsername" runat="server" Visible="false"></asp:Label>
                        <asp:Label ID="Titles" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        收件人：</td>
                    <td class="newtd2" colspan="3" height="17">
                        <asp:Label ID="JsRealname" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        发件人：</td>
                    <td class="newtd2" height="17" colspan="3">
                        <asp:Label ID="FsRealname" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        发送时间：</td>
                    <td class="newtd2" colspan="3" height="17">
                        <asp:Label ID="FsTime" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                </tr>
                <tr class="" id="nextrs22">
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        附件：</td>
                    <td class="newtd2" height="17" width="83%" colspan="3">
                        <asp:Label ID="fujian" runat="server" Width="90%"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        邮件正文：</td>
                    <td class="newtd2" height="17" colspan="3" width="83%">
                        <asp:Label ID="Content" runat="server" Width="100%"></asp:Label>&nbsp;</td>
                </tr>
            </table>
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
