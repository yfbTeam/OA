<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyRizhi_add.aspx.cs" Inherits="xyoa.pda.OfficeMenu.Rizhi.MyRizhi_add" %>

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

function chknull()
{
    if(document.getElementById('titles').value=='')
    {
        alert('标题不能为空');
        form1.titles.focus();
        return false;
    }	

    if(document.getElementById('NowTimes').value=='')
    {
        alert('日志时间不能为空');
        form1.NowTimes.focus();
        return false;
    }	
       
    LoadingShow();
}  


    </script>

</head>
<body onload="select_type()">
    <form id="form1" runat="server">
        <div id="overlay">
        </div>
        <div class="ui-loader loading">
            <span class="ui-icon ui-icon-loading"></span>
            <h1>
                正在载入...</h1>
        </div>
        <div id="header">
            <table width="100%" height="40" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="45px" align="left">
                        <asp:Button ID="Button1" runat="server" CssClass="button_shouji" Text="返回" Width="45px"
                            OnClick="Button1_Click" /></td>
                    <td align="center">
                        <span class="t">新增我的日志</span></td>
                    <td width="45px" align="right">
                        <asp:Button ID="Button2" runat="server" CssClass="button_shouji" Text="提交" Width="45px"
                            OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divgrid" class="divheight">
            <table align="center" border="0" cellpadding="4" cellspacing="1" width="99%" class="nextpage"
                id="tableprint">
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        日志标题：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:TextBox ID="titles" runat="server" Width="95%"></asp:TextBox>
                        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        日志时间：</td>
                    <td class="newtd2" height="17" width="85%" colspan="3">
                        <asp:TextBox ID="NowTimes" runat="server" onClick="WdatePicker()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        类别：</td>
                    <td class="newtd2" height="17" width="83%" colspan="3">
                        <asp:DropDownList ID="LeiBie" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        日志内容：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:TextBox ID="Content" runat="server" Width="95%" Height="65px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr class="" id="nextrs22">
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        附件：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:DropDownList ID="fjlb" runat="server">
                        </asp:DropDownList>
                        <asp:Button ID="Button5" runat="server" Text="删除" OnClick="Button5_Click" />
                    </td>
                </tr>
                <tr class="" id="nextrs23">
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        上传附件：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <input id="uploadFile" runat="server" type="file" name="uploadFile" />
                        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="上　传" />
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
    </form>
</body>
</html>
