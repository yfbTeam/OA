<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyPlan_add.aspx.cs" Inherits="xyoa.pda.OfficeMenu.WorkPlan.MyPlan_add" %>

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
    if(document.getElementById('Biaoti').value=='')
    {
    alert('计划标题不能为空');
    form1.Biaoti.focus();
    return false;
    }	
    
    
    if(document.getElementById('Leixing').value=='')
    {
    alert('计划类型不能为空');
    form1.Leixing.focus();
    return false;
    }	   
    
    if(document.getElementById('StartTime').value=='')
    {
    alert('开始时间不能为空');
    form1.StartTime.focus();
    return false;
    }	
    
    if(document.getElementById('EndTime').value=='')
    {
    alert('结束时间不能为空');
    form1.EndTime.focus();
    return false;
    }	   
    LoadingShow();
}  

function openuser1(str)
{
  $('#box_share').animate({'top':'50px'},200);
  var obj=document.getElementsByName('test');
  for(var i=0; i<obj.length; i++)
  {  
  
    var arr = obj[i].value.split("|");
    var str1=','+arr[0]+',';
    if(str=="1")
    {
       var str2=','+document.getElementById("SharingUserZd").value+',';
    }
    else
    {
       var str2=','+document.getElementById("SharingUserKx").value+',';
    }
    if (str2.indexOf(str1) < 0)
    {
    }
    else
    {
      obj[i].checked=true;
    }
  }
  document.getElementById("OpenBack").value=str;
}  

function chk(){
if(document.getElementById("OpenBack").value=="1")
{
    document.getElementById("SharingUserZd").value='';
    document.getElementById("SharingNameZd").value='';
}
else
{
    document.getElementById("SharingUserKx").value='';
    document.getElementById("SharingNameKx").value='';
}
  var obj=document.getElementsByName('test');
  
  for(var i=0; i<obj.length; i++)
  {  
    if(obj[i].checked)
    {
       var arr = obj[i].value.split("|");
       if(document.getElementById("OpenBack").value=="1")
       {
          document.getElementById("SharingUserZd").value+=''+arr[0]+','; 
          document.getElementById("SharingNameZd").value+=''+arr[1]+','; 
       }
       else
       {
          document.getElementById("SharingUserKx").value+=''+arr[0]+','; 
          document.getElementById("SharingNameKx").value+=''+arr[1]+','; 
       }

    }
  }  
$('#box_share').animate({'top':'-1400px'},500);

}  


function select_type()
{
   if (form1.Sharing.value=="1")
   {
       gx1.style.display='none';
       gx2.style.display='none';
   }
   else if (form1.Sharing.value=="2")
   {
       gx1.style.display='';
       gx2.style.display='';
   }
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
                        <span class="t">新增工作计划</span></td>
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
                        计划标题：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:TextBox ID="Biaoti" runat="server" Width="95%"></asp:TextBox>
                        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        计划类型：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:DropDownList ID="Leixing" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        优先级：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:DropDownList ID="Youxian" runat="server">
                            <asp:ListItem Selected="True" Value="1">高</asp:ListItem>
                            <asp:ListItem Value="2">中</asp:ListItem>
                            <asp:ListItem Value="3">低</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        开始时间：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:TextBox ID="StartTime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        结束时间：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:TextBox ID="EndTime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        当前状态：</td>
                    <td class="newtd2" height="17" width="85%" colspan="3">
                        <asp:RadioButtonList ID="DqState" runat="server" RepeatDirection="Horizontal" RepeatColumns="2">
                            <asp:ListItem Selected="True" Value="1">未处理</asp:ListItem>
                            <asp:ListItem Value="2">进行中</asp:ListItem>
                            <asp:ListItem Value="3">已办结</asp:ListItem>
                            <asp:ListItem Value="4">已暂停</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        计划内容：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:TextBox ID="Neirong" runat="server" Width="95%" Height="65px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        计划共享：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:DropDownList ID="Sharing" runat="server" onchange="select_type()">
                            <asp:ListItem Value="1">未共享</asp:ListItem>
                            <asp:ListItem Value="2">已共享</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr id="gx1" style="display: none">
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        只读共享人员：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:TextBox ID="SharingNameZd" runat="server" Width="95%" onclick="openuser1('1');"></asp:TextBox>
                        <asp:TextBox ID="SharingUserZd" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="OpenBack" runat="server" Style="display: none"></asp:TextBox>
                    </td>
                </tr>
                <tr id="gx2" style="display: none">
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        可写共享人员：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:TextBox ID="SharingNameKx" runat="server" Width="95%" onclick="openuser1('2');"></asp:TextBox>
                        <asp:TextBox ID="SharingUserKx" runat="server" Style="display: none"></asp:TextBox>
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
