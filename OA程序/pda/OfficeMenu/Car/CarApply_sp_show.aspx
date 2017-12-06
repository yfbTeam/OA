<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CarApply_sp_show.aspx.cs"
    Inherits="xyoa.pda.OfficeMenu.Car.CarApply_sp_show" %>

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

function openuser1()
{
  $('#box_share').animate({'top':'50px'},200);
  var obj=document.getElementsByName('test');
  for(var i=0; i<obj.length; i++)
  {  
  
    var arr = obj[i].value.split("|");
    var str1=','+arr[0]+',';
    var str2=','+document.getElementById("ZbUsername").value+',';
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
document.getElementById("ZbUsername").value='';
document.getElementById("ZbRealname").value='';

  var obj=document.getElementsByName('test');
  
  for(var i=0; i<obj.length; i++)
  {  
    if(obj[i].checked)
    {
       var arr = obj[i].value.split("|");
       document.getElementById("ZbUsername").value+=''+arr[0]+','; 
       document.getElementById("ZbRealname").value+=''+arr[1]+','; 
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
                    <input id="OpenUser" type="button" value="提交" class="form_submit" onclick="chk()" />
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
                        <span class="t">审批车辆申请</span></td>
                    <td width="45px" align="right">
                        <asp:Button ID="Button3" runat="server" Text="转 交" CssClass="button_shouji" OnClick="Button3_Click" />
                        <asp:Button ID="Button4" runat="server" Text="结 束" CssClass="button_shouji" OnClick="Button4_Click"
                            Visible="false" />
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
                        <asp:TextBox ID="CarpeopleUser" runat="server" Width="90%" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="GlNum" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="Username" runat="server" Style="display: none"></asp:TextBox>
                        <input id="YjbNodeId" type="hidden" runat="server" />
                        <input id="NodeName" type="hidden" runat="server" />
                        <asp:TextBox ID="chongtu" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="ZbUsername" runat="server" Style="display: none"></asp:TextBox>
                        <asp:TextBox ID="JbZhuangjiao" runat="server" Style="display: none"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        车辆名称：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:Label ID="CarId" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        当前状态：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:Label ID="State" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 24px">
                        驾驶员：</td>
                    <td class="newtd2" colspan="3" width="85%">
                        <asp:Label ID="Drivers" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 24px">
                        用车部门：</td>
                    <td class="newtd2" colspan="3" width="85%">
                        <asp:Label ID="UnitId" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 24px">
                        用车人：</td>
                    <td class="newtd2" width="83%" style="height: 24px" colspan="3">
                        <asp:Label ID="Carpeople" runat="server"></asp:Label>&nbsp;
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
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 24px">
                        目的地：</td>
                    <td class="newtd2" width="85%" style="height: 24px" colspan="3">
                        <asp:Label ID="Destination" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 24px">
                        事由：</td>
                    <td class="newtd2" width="85%" style="height: 24px" colspan="3">
                        <asp:Label ID="Subject" runat="server"></asp:Label>&nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        备注：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:Label ID="Remark" runat="server"></asp:Label></td>
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
                <tr>
                    <td class="newtd2" colspan="4" height="17" align="center">
                        <b>工作办理</b></td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        办理意见：</td>
                    <td class="newtd2" height="17" width="85%" colspan="3">
                        <asp:RadioButtonList ID="CaoZuo" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                            OnSelectedIndexChanged="CaoZuo_SelectedIndexChanged">
                            <asp:ListItem Selected="True" Value="3">同意</asp:ListItem>
                            <asp:ListItem Value="4">不同意</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        转交步骤：</td>
                    <td class="newtd2" height="17" width="85%" colspan="3">
                        <asp:RadioButtonList ID="FormName" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="FormName_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:RadioButtonList>
                        <asp:Label ID="Label1" runat="server"></asp:Label>
                    </td>
                </tr>
                <asp:Panel ID="Panel1" runat="server">
                    <tr id="nd1">
                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                            经办人：</td>
                        <td class="newtd2" height="17" colspan="3" width="85%">
                            <asp:TextBox ID="ZbRealname" runat="server" Width="99%"></asp:TextBox>
                        </td>
                    </tr>
                </asp:Panel>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        办理意见：</td>
                    <td class="newtd2" height="17" width="85%" colspan="3">
                        <asp:TextBox ID="Yijian" runat="server" Width="99%"></asp:TextBox>
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
