﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MettingApply_ysp_show.aspx.cs"
    Inherits="xyoa.pda.OfficeMenu.Metting.MettingApply_ysp_show" %>

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
                            <li><a id="A2" onclick="LoadingShow();location.href='MettingApply_sp.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                未审批</a></li>
                            <li><a id="A1" onclick="LoadingShow();location.href='MettingApply_ysp.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                已审批</a></li>
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
                        <span class="t">已审批会议</span></td>
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
                    <td class="newtd2" colspan="4" height="17" align="left">
                        <b>创建人：</b><asp:Label ID="Realname" runat="server"></asp:Label>
                        &nbsp;&nbsp;<b>申请时间：</b><asp:Label ID="NowTimes" runat="server"></asp:Label>
                        &nbsp;&nbsp;<b>当前步骤：</b><asp:Label ID="DqNodeName1" runat="server"></asp:Label>
                        &nbsp;&nbsp;<b>办理状态：</b><asp:Label ID="LcZhuangtai" runat="server"></asp:Label>
                        <asp:TextBox ID="NbPeopleUser" runat="server" Width="90%" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
                        <input id="YjbNodeId" type="hidden" runat="server" />
                        <asp:TextBox ID="GlNum" runat="server" Style="display: none"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        会议名称：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:Label ID="Name" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        描述：
                    </td>
                    <td class="newtd2" colspan="3" height="17" width="85%">
                        <asp:Label ID="Introduction" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        出席人员(外部)：
                    </td>
                    <td class="newtd2" colspan="3" height="17" width="85%">
                        <asp:Label ID="WbPeople" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        出席人员(内部)：
                    </td>
                    <td class="newtd2" colspan="3" height="17" width="85%">
                        <asp:Label ID="NbPeopleName" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 24px">
                        会议室：</td>
                    <td class="newtd2" width="83%" style="height: 24px" colspan="3">
                        <asp:Label ID="MettingName" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        开始时间：
                    </td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:Label ID="Starttime" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        结束时间：
                    </td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:Label ID="Endtime" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr class="" id="Tr2">
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        备注：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:Label ID="Remark" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr class="" id="nextrs22">
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        附件：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:Label ID="fujian" runat="server" Width="90%"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="newtd2" colspan="4" height="17" align="center">
                        <b>办理过程信息</b><asp:CheckBox ID="CheckBox1" runat="server" onclick="aaa()" /></td>
                </tr>
                <tr id="nextrs1" style="display: none">
                    <td class="newtd2" height="17" nowrap="nowrap" colspan="4">
                        <asp:Label ID="Liucheng" runat="server"></asp:Label>
                    </td>
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

        <script>
function aaa()
{   
    if(document.getElementById('CheckBox1').checked)
    {
       document.getElementById('nextrs1').style.display="";
    }
    else
    {
       document.getElementById('nextrs1').style.display="none";
    }
}
        </script>

    </form>
</body>
</html>
