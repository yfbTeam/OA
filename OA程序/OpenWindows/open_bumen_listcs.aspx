<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="open_bumen_listcs.aspx.cs" Inherits="xyoa.OpenWindows.open_bumen_listcs" %>

<html>
<head id="Head1" runat="server">
    <title>选择部门</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
    <base target="_self" />

    <script language="javascript">		
function checkbutton()
{

if(rform.document.getElementById('Name').value=='')
{
alert('提交数据失败！未选中分部分项！');
return false;
}
else
{

sendFromChild();
}

}/////	


function  sendFromChild(str1,str2)  
{       
if (window.opener != undefined) 
{
window.opener.returnValue=""+str1+"|"+str2+""; 
}
else 
{
window.returnValue=""+str1+"|"+str2+""; 
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
        <script language='javascript' type='text/javascript'> 
function OnTreeNodeChecked() 
{ 
var ele = event.srcElement; 
if(ele.type=='checkbox') 
{ 
var childrenDivID = ele.id.replace('CheckBox','Nodes'); 
var div = document.getElementById(childrenDivID); 
if(div==null)return; 
var checkBoxs = div.getElementsByTagName('INPUT'); 
for(var i=0;i<checkBoxs.length;i++) 
{ 
if(checkBoxs[i].type=='checkbox') 
checkBoxs[i].checked=ele.checked; 
} 
} 
} 
    </script>
</head>
<body class="newbody" scroll="auto">
    <form id="form1" runat="server">
        <table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0"
            bordercolordark="#ffffff">
            <tr>
                <td height="22" background="/oaimg/show_02.gif" align="left" style="font-size: 12px;
                    font-family: 宋体">
                    选择部门</td>
            </tr>
            <tr>
                <td valign="top" style="text-align: center" align="left">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 550px; height: 500px" align="left">
                        <tr>
                            <td colspan="2" style="height: 31px;" valign="top">
                                <table border="0" cellpadding="0" cellspacing="0" width="100%" height="500">
                                    <tr>
                                        <td colspan="2" valign="top">
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                            <asp:TreeView ID="ListTreeView" runat="server" NodeIndent="10" ShowLines="True">
                                            </asp:TreeView>
                                            <asp:Label ID="Message" runat="server"></asp:Label>
                                            <asp:Label ID="Message1" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 31px; text-align: center;">
                                <asp:Button ID="bbb1" runat="server" OnClick="Button1_Click" Text="确定" Style="width: 72px"
                                    class="button_css" />
                                <input type="button" value="关闭" onclick="closewin();" style="width: 72px" class="button_css"
                                    id="Button3">
                                <input type="button" value="清空" onclick="CCC();" style="width: 72px" class="button_css"
                                    id="Button4">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="22" background="/oaimg/show_02.gif">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
