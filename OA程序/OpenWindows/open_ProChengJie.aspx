<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="open_ProChengJie.aspx.cs" Inherits="xyoa.OpenWindows.open_ProChengJie" %>

<html>
<head>
    <title>
        <%=Session["Titles"]%>
    </title>

    <script src="/js/public.js" type="text/javascript"></script>

    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <base target="_self" />

    <script language="javascript">	
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
window.returnValue="|||||";  
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

    <script src="../public/public.js" type="text/javascript"></script>

</head>
<body scroll="no" onload="onradiobutton()">
    <form id="Form1" method="post" runat="server">
        <asp:TextBox ID="requeststr" runat="server" Style="display: none"></asp:TextBox>
        <table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0"
            bordercolordark="#ffffff">
            <tr>
                <td height="22" background="/oaimg/nextline.gif" align="left" style="font-size: 12px;
                    font-family: 宋体">
                    请选择承接单位</td>
            </tr>
            <tr>
                <td valign="top" style="text-align: center">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 518px; height: 49px"  align=center>
                        <tr>
                            <td colspan="2" style="height: 31px; text-align: left">
                                单位名称：<asp:TextBox ID="Name" runat="server" Width="130px"></asp:TextBox>
                                信用等级：<asp:DropDownList ID="Xinyong" runat="server" Width="224px">
                                </asp:DropDownList>
                                <asp:Button ID="Button4" runat="server" CssClass="button_css" Text="查询" OnClick="Button4_Click" /></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 31px; text-align: center;">
                                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                    BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px"
                                    CellPadding="3" CellSpacing="1" GridLines="None" Style="font-size: 12px" Width="100%"
                                    OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="选择">
                                            <ItemStyle HorizontalAlign="Center" Width="30px" Wrap="True" />
                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                            <ItemTemplate>
                                                <input id="Radio1" type="radio" value='<%#DataBinder.Eval(Container.DataItem, "id")%>|<%#DataBinder.Eval(Container.DataItem, "Name")%>|<%#DataBinder.Eval(Container.DataItem, "Lianxiren")%>|<%#DataBinder.Eval(Container.DataItem, "Dianhua")%>|<%#DataBinder.Eval(Container.DataItem, "Fax")%>'
                                                    name="Rad" />
                                            </ItemTemplate>
                                            <FooterStyle Wrap="True" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Name" HeaderText="单位名称" SortExpression="Name">
                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
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
                                &nbsp;&nbsp; &nbsp;<input type="button" value="确定" onclick="return checkbutton();"
                                    style="width: 70px" class="button_css" id="Button1">
                                <input type="button" value="关闭" onclick="closewin();" style="width: 72px" class="button_css"
                                    id="Button3">
                                <input type="button" value="清空" onclick="CCC();" style="width: 72px" class="button_css"
                                    id="Button2">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="22">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>