<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CompanyGroup_show.aspx.cs"
    Inherits="xyoa.pda.MyWork.txl.CompanyGroup_show" %>

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
                            <li><a id="A1" onclick="LoadingShow();location.href='CompanyGroup.aspx';">
                                <img border="0" alt="" src="/pda/images/home.png"><br>
                                通讯录</a></li>
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
                        <span class="t">查看通讯录</span></td>
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
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        姓名：</td>
                    <td class="newtd2" height="17" width="85%">
                        <asp:Label ID="Name" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                        所属部门：</td>
                    <td class="newtd2" height="24" width="85%">
                        <asp:Label ID="BuMenId" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        所属职位：</td>
                    <td class="newtd2" height="17" width="85%">
                        <asp:Label ID="Zhiweiid" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        性别：</td>
                    <td class="newtd2" height="17" width="85%">
                        <asp:Label ID="Sex" runat="server"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        生日：</td>
                    <td class="newtd2" height="17" width="85%">
                        <asp:Label ID="BothDay" runat="server"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        办公电话：</td>
                    <td class="newtd2" height="17" width="85%">
                        <asp:Label ID="Officetel" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="15%">
                        传真：</td>
                    <td class="newtd2" width="85%">
                        <asp:Label ID="Fax" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="15%">
                        手机：</td>
                    <td class="newtd2" width="85%">
                        <asp:Label ID="MoveTel" runat="server"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="15%">
                        住宅电话：</td>
                    <td class="newtd2" width="85%">
                        <asp:Label ID="HomeTel" runat="server"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="15%">
                        E-mail ：</td>
                    <td class="newtd2" width="85%">
                        <asp:Label ID="Email" runat="server"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="15%">
                        QQ号：</td>
                    <td class="newtd2" width="85%">
                        <asp:Label ID="QQNum" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="15%">
                        MSN：</td>
                    <td class="newtd2" width="85%">
                        <asp:Label ID="MsnNum" runat="server"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="15%">
                        内部即时通：</td>
                    <td class="newtd2" width="85%">
                        <asp:Label ID="NbNum" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="15%">
                        邮政编码：</td>
                    <td class="newtd2" width="85%">
                        <asp:Label ID="ZipCode" runat="server"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" width="15%">
                        通信地址：</td>
                    <td class="newtd2" width="85%">
                        <asp:Label ID="Address" runat="server"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" width="15%">
                        备注信息：</td>
                    <td class="newtd2" width="85%">
                        <asp:Label ID="Remark" runat="server"></asp:Label>&nbsp;</td>
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
