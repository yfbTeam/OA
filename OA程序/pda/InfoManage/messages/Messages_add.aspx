<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Messages_add.aspx.cs" Inherits="xyoa.pda.InfoManage.messages.Messages_add" %>

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
    if(document.getElementById('Content').value=='')
    {
        alert('短信不能为空');
        form1.Content.focus();
        return false;
    }	
    
    if(document.getElementById('acceptrealname').value=='')
    {
        alert('接收人不能为空');
        form1.acceptrealname.focus();
        return false;
    }	
    LoadingShow();
}  

function openuser1()
{
  $('#box_share').animate({'top':'50px'},200);
  var obj=document.getElementsByName('test');
  for(var i=0; i<obj.length; i++)
  {  
  
    var arr = obj[i].value.split("|");
    var str1=','+arr[0]+',';
    var str2=','+document.getElementById("acceptusername").value+',';
    if (str2.indexOf(str1) < 0)
    {
    }
    else
    {
      obj[i].checked=true;
    }
  } 
}  

function chk(){
document.getElementById("acceptusername").value='';
document.getElementById("acceptrealname").value='';

  var obj=document.getElementsByName('test');
  
  for(var i=0; i<obj.length; i++)
  {  
    if(obj[i].checked)
    {
       var arr = obj[i].value.split("|");
       document.getElementById("acceptusername").value+=''+arr[0]+','; 
       document.getElementById("acceptrealname").value+=''+arr[1]+','; 
    }
  }  
$('#box_share').animate({'top':'-1400px'},500);

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
        <div id="box_share" class="box">
            <div class="box_content">
                <div class="box_content_tab">
                    选择用户
                </div>
                <div class="box_content_center">
                    <div class="social_share">
                        <ul>
                           <%=ViewState["pdauer"] %>
                        </ul>
                    </div>
                    
                    <a id="boxclose_share" class="boxclose_right">关闭</a>
                    <input id="Button3" type="button" value="提交" class="form_submit" onclick="chk()"/>
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
                        <span class="t">发送内部消息</span></td>
                    <td width="45px" align="right">
                        <asp:Button ID="Button2" runat="server" CssClass="button_shouji" Text="发送" Width="45px"
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
                        信息内容：</td>
                    <td class="newtd2" height="17" width="85%">
                        <asp:TextBox ID="Content" runat="server" Width="95%" Height="65px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                       接收人：</td>
                    <td class="newtd2" height="17" width="85%">
                        <asp:TextBox ID="acceptrealname" runat="server" Width="95%" 
                            onclick="openuser1();"></asp:TextBox>
                        <asp:TextBox ID="acceptusername" runat="server"  Style="display: none"></asp:TextBox>
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
