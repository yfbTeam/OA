﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="open_user_list_Zw.aspx.cs" Inherits="xyoa.OpenWindows.open_user_list_Zw" %>
<HTML>
	<HEAD>
		 <title><%=Session["Titles"]%></title>
          <script src="/js/public.js" type="text/javascript"></script>
      <LINK href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
		<base target=_self />	

<script  language="javascript">	
function checkbutton()
{
    for(var i=0;i<document.getElementById('TargetListBox').length;i++)
    { 

    document.getElementById("TextBox1").value=""+document.getElementById("TextBox1").value+""+document.getElementById('TargetListBox').options[i].value+",";
    document.getElementById("TextBox2").value=""+document.getElementById("TextBox2").value+""+document.getElementById('TargetListBox').options[i].text+",";

    } 

    if(document.getElementById("TextBox1").value=='')
    {
     alert('提交数据失败！未选中项');
    return false;
    }
    else
    {
     sendFromChild();
    }

}


		
var  getFromParent=window.dialogArguments;  
function CheckSelect()
{



var retrunstr="";
retrunstr=""+document.getElementById("TextBox1").value+"|"+document.getElementById("TextBox2").value+"";
return retrunstr;




}

function  sendFromChild()  
{       
if (window.opener != undefined) {window.opener.returnValue = CheckSelect();}else {window.returnValue=CheckSelect();}
window.close();  
} 

function  CCC()  
{       
window.returnValue="|";  
window.close();  
} 

window.onbeforeunload = function()  
{
var n = window.event.screenX - window.screenLeft;
var b = n > document.documentElement.scrollWidth-20;
if(b && window.event.clientY < 0 || window.event.altKey)
{


}


}      

function  closewin()  
{ 

window.close();  
     

}  


function qingkong()
{
   document.getElementById('BuMenId').value='';
   document.getElementById('JueseId').value='';
   document.getElementById('Zhiweiid').value='';
   document.getElementById('Realname').value='';
   
}  


</script>

  <script src="/js/public.js" type="text/javascript"></script>
 	
</HEAD>
	<body scroll="no">
	
		<form id="Form1" method="post" runat="server">
		 
           <asp:TextBox ID="requeststr" runat="server" style="DISPLAY: none"></asp:TextBox>
             <asp:TextBox ID="TextBox1" runat="server"  style="DISPLAY: none"></asp:TextBox>
               <asp:TextBox ID="TextBox2" runat="server"  style="DISPLAY: none"></asp:TextBox>
			<table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0" bordercolordark="#ffffff">
				<tr>
					<td height="22" background="/oaimg/nextline.gif" align="left" style="font-size: 12px; font-family: 宋体"> 　请选择用户</td>
				</tr>
				<tr>
			    <td valign="top" style="text-align: center">
			    <table  border="0" cellspacing="0" cellpadding="0" style="width: 693px; height: 49px">
                    <tr>
                        <td colspan="2">
                            &nbsp;部门：<asp:DropDownList ID="BuMenId" runat="server" Width="147px" AutoPostBack="True" OnSelectedIndexChanged="ListChangedBind">
                            </asp:DropDownList>
                            角色：<asp:DropDownList ID="JueseId" runat="server" Width="93px" AutoPostBack="True" OnSelectedIndexChanged="ListChangedBind">
                            </asp:DropDownList>
                            姓名：<asp:TextBox ID="Realname" runat="server" Width="77px"></asp:TextBox>
                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click1" Text="查询" CssClass="button_css" />
                           <asp:Button ID="Button10" runat="server" Text="退出" CssClass="button_css" OnClick="Button10_Click" /></td>
                    </tr>
                    <tr>
                    <td colspan="2">
                    <hr>
                    </td>
                    <tr>
                    <tr>
                        <td colspan="2" style="height: 31px; text-align: center;">
                            <table border="0" cellpadding="0" cellspacing="0" style="height: 302px" align=center>
                                <tr>
                                    <td align="center" style="width: 113px" valign="top">
                                        <asp:ListBox ID="SourceListBox" runat="server" Height="411px" Width="204px" SelectionMode="Multiple"></asp:ListBox></td>
                                    <td align="center" style="width: 42px" valign="top">
                                        <asp:Button ID="Button5" runat="server" OnClick="Button1_Click" Text=">" Width="58px" /><br />
                                        <br />
                                        <asp:Button ID="Button6" runat="server" OnClick="Button5_Click" Text=">>" Width="58px" />
                                        <br />
                                        <asp:Button ID="Button7" runat="server" OnClick="Button4_Click" Text="<" Width="58px" /><br />
                                        <br />
                                        <asp:Button ID="Button8" runat="server" OnClick="Button6_Click" Text="<<" Width="58px" />
                                    </td>
                                    <td align="center" style="width: 100px" valign="top">
                                        <asp:ListBox ID="TargetListBox" runat="server" Height="411px" Width="197px" SelectionMode="Multiple"></asp:ListBox></td>
                                </tr>
                            </table>
                            &nbsp;</td>
                    </tr>
                      <tr>
                          <td colspan="2" style="height: 31px; text-align: center;">
                              &nbsp;&nbsp; &nbsp;<INPUT  TYPE="button"  VALUE="确定"  onclick="return checkbutton();" style="width: 70px" class="button_css" id="Button1">  <INPUT  TYPE="button"  VALUE="关闭"  onclick="closewin();" style="width: 72px" class="button_css" id="Button3">  <INPUT  TYPE="button"  VALUE="清空"  onclick="CCC();" style="width: 72px" class="button_css" id="Button2">
                             </td>
                      </tr>                        
                    </table></td>
				</tr>
				<tr>
					<td height="22">
					</td>
				</tr>
			</table>
		</form>
	</body>			
</HTML>