<%@ Page Language="C#" AutoEventWireup="true" Codebehind="InfoSend_add.aspx.cs" Inherits="xyoa.pda.InfoManage.filesend.InfoSend_add" %>

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
    if(document.getElementById('JsRealname').value=='')
    {
        alert('接收人不能为空');
        form1.JsRealname.focus();
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
    var str2=','+document.getElementById("JsUsername").value+',';
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
document.getElementById("JsUsername").value='';
document.getElementById("JsRealname").value='';

  var obj=document.getElementsByName('test');
  
  for(var i=0; i<obj.length; i++)
  {  
    if(obj[i].checked)
    {
       var arr = obj[i].value.split("|");
       document.getElementById("JsUsername").value+=''+arr[0]+','; 
       document.getElementById("JsRealname").value+=''+arr[1]+','; 
    }
  }  
$('#box_share').animate({'top':'-1400px'},500);

}  


        $(document).ready(function(){
           $("#btnAddFile").bind("click",function(){
              $(this).before("<div><input type='file' id='file'  name='file' /><input  type='button' value='移除' onclick='RemoveFile(this)'/></div>"); 
           });
        });
        function RemoveFile(obj){
           $(obj).parent().remove(); 
        }
</script>

</head>
<body>
    <form id="form1" runat="server" enctype="multipart/form-data">
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
                    <input id="Button3" type="button" value="提交" class="form_submit" onclick="chk()" />
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
                        <span class="t">传阅文件</span></td>
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
                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                        接收人：</td>
                    <td class="newtd2" height="17" width="85%">
                        <asp:TextBox ID="JsRealname" runat="server" Width="95%" onclick="openuser1();"></asp:TextBox>
                        <asp:TextBox ID="JsUsername" runat="server" Style="display: none"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        附件：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <div>
                            <input type='file' id='file' name='file' /></div>
                        <input type="button" value="添加上传框" id="btnAddFile" />
                        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
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
