<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Syspassword.aspx.cs" Inherits="xyoa.pda.MyWork.MySet.Syspassword" %>

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
    if(document.getElementById('Username').value=='')
    {
    alert('用户名不能为空');
    return false;
    }
    	
    if(document.getElementById('Password').value=='')
    {
    alert('旧密码不能为空');
    return false;
    }
    			
    if(document.getElementById('NewPassword').value=='')
    {
    alert('新密码不能为空');
    return false;
    }

    if(document.getElementById('NewPassword').value!=document.getElementById('NewPassword_c').value)
    {
    alert('确认密码和新密码不一样');
    return false;
    }

    LoadingShow();
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
        <div id="header">
            <table width="100%" height="40" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="45px" align="left">
                    <asp:Button ID="Button1" runat="server" CssClass="button_shouji" Text="返回" Width="45px"
                            OnClick="Button1_Click" />
                    </td>
                    <td align="center">
                        <span class="t">修改密码</span></td>
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
                    <td align="right" class="newtd1" nowrap="nowrap" width="17%">
                        用户名：</td>
                    <td class="newtd2" width="83%">
                        <asp:Label ID="Username" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="17%">
                        旧密码：</td>
                    <td class="newtd2" width="83%">
                        <asp:TextBox ID="Password" runat="server" Width="99%" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="17%">
                        新密码：</td>
                    <td class="newtd2" width="83%">
                        <asp:TextBox ID="NewPassword" runat="server" Width="99%" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="17%">
                        确认新密码：</td>
                    <td class="newtd2" width="83%">
                        <asp:TextBox ID="NewPassword_c" runat="server" Width="99%" TextMode="Password"></asp:TextBox></td>
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
