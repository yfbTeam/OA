<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="open_Username_two_lz.aspx.cs" Inherits="xyoa.OpenWindows.open_Username_two_lz" %>
<HTML>
	<HEAD>
		 <title>选择离职员工</title>
          <script src="/js/public.js" type="text/javascript"></script>
      <LINK href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
		<base target=_self />	

<script  language="javascript">	
function checkbutton()
{
var a=0
for(var i=0;i<document.Form1.elements.length;i++)
{
if(document.Form1.elements[i].checked==true)
	{a=a+1}

}

if(a>0)
{
sendFromChild();
}
else
{
alert('提交数据失败！未选中项');
return false;
}

}/////


		
var  getFromParent=window.dialogArguments;  
function CheckSelect()
{



for(var i=0;i<window.document.Form1.elements.length;i++)
{
var e = Form1.elements[i];
if (e.checked)
return e.value;
}
var retrunstr="";
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
</script>
<script>
function onradiobutton()
{
aa   =   document.getElementsByName("Rad");  

for   (i=0;i<aa.length;i++)  
{ 

 if(aa[i].value==document.getElementById('requeststr').value)
 {
 aa[i].checked=true;
 
 //alert(i);  
 return false;
 }
 else
 {
  aa[i].checked=false;
 }

}   
}
</script>

  <script src="/js/public.js" type="text/javascript"></script>
 	
</HEAD>
	<body scroll="no" onload="onradiobutton()">
	
		<form id="Form1" method="post" runat="server">
		 
           <asp:TextBox ID="requeststr" runat="server" style="DISPLAY: none"></asp:TextBox>
			<table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0" bordercolordark="#ffffff">
				<tr>
					<td height="22" background="/oaimg/nextline.gif" align="left" style="font-size: 12px; font-family: 宋体"> 　选择离职员工</td>
				</tr>
				<tr>
			    <td valign="top" style="text-align: center">
			    <table  border="0" cellspacing="0" cellpadding="0" style="width: 518px; height: 49px" align=center>
                    <tr>
                        <td colspan="2" style="height: 31px; text-align: left">
                            用户组：<asp:DropDownList ID="MyUserList" runat="server" Width="102px" AutoPostBack="True" OnSelectedIndexChanged="ListChangedBind">
                            </asp:DropDownList>
                            部门：<asp:DropDownList ID="Unit" runat="server" Width="136px" AutoPostBack="True" OnSelectedIndexChanged="ListChangedBind">
                            </asp:DropDownList>名称关键字：<asp:TextBox ID="name" runat="server" Width="67px"></asp:TextBox>
                            <asp:Button ID="Button4" runat="server" CssClass="button_css" Text="查询" OnClick="Button4_Click" /></td>
                    </tr>
                    <tr>
                        <td colspan="2" style="height: 31px; text-align: center;">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                                AutoGenerateColumns="False" BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None"
                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" Style="font-size: 12px" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField HeaderText="选择">
                                        <ItemStyle HorizontalAlign="Center" Width="30px" Wrap="False" />
                                        <HeaderStyle CssClass="newtitle" HorizontalAlign="Center"
                                            Wrap="False" />
                                        <ItemTemplate>
                                           <input id="Radio1" type="radio" value='<%#DataBinder.Eval(Container.DataItem, "username")%>|<%#DataBinder.Eval(Container.DataItem, "realname")%>' name="Rad" />
                                        </ItemTemplate>
                                        <FooterStyle Wrap="True" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="realname" HeaderText="名称" SortExpression="realname">
                                        <HeaderStyle CssClass="newtitle" Wrap="False"/>
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                <EmptyDataTemplate>
                                    <div align="center">
                                        <font color="white">无相关数据！</font></div>
                                </EmptyDataTemplate>
                                <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#94C3CE" ForeColor="red" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                <AlternatingRowStyle BackColor="#F7F7F7" />
                            </asp:GridView>
                        </td>
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