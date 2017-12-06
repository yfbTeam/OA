<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Openleibie_wt.aspx.cs" Inherits="xyoa.OpenWindows.Openleibie_wt" %>
<html>
<head>
    <title>请选择问题分类（只显示权限范围内的分类）</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <base target="_self" />

    <script language="javascript">		
function checkbutton()
{

if(rform.document.getElementById('Name').value=='')
{
alert('提交数据失败！未选中问题分类！');
return false;
}
else
{

sendFromChild();
}

}/////	


function  sendFromChild()  
{
if (window.opener != undefined) 
{
window.opener.returnValue=""+rform.document.getElementById('gncdid').value+"|"+rform.document.getElementById('Name').value+"";  
}
else 
{
window.returnValue=""+rform.document.getElementById('gncdid').value+"|"+rform.document.getElementById('Name').value+"";  
}
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

</head>
<body onload="onradiobutton()" scroll="no">
    <form id="Form1" method="post" runat="server">
        <asp:TextBox ID="requeststr" runat="server" Style="display: none"></asp:TextBox>
        <table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0"
            bordercolordark="#ffffff">
            <tr>
                <td height="22" background="/oaimg/show_02.gif" align="left" style="font-size: 12px;
                    font-family: 宋体">
                    请选择问题分类</td>
            </tr>
            <tr>
                <td valign="top" style="text-align: center">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 755px; height: 550px" align=center>
                        <tr>
                            <td colspan="2" style="height: 31px;" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%" height="550">
                                    <tr>
                                        <td valign="top" width="50%">
                                            <iframe name="lhead" marginwidth="0" marginheight="0" src="Openleibie_wtLeft.aspx?type=<%=Request.QueryString["type"]%>"
                                                frameborder="0" width="100%" height="100%" scrolling="auto"></iframe>
                                        </td>
                                        <td valign="top" width="50%">
                                            <iframe name="rform" marginwidth="0" marginheight="0" src="Openleibie_wtMc.aspx?id=<%=Request.QueryString["id"]%>"
                                                frameborder="1" width="100%" height="96%" scrolling="auto"></iframe>
                                        </td>
                                    </tr>
                                </table>
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
                <td height="22" background="/img/show_02.gif">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>