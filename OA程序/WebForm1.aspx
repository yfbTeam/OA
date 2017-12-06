<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WebForm1.aspx.cs" Inherits="xyoa.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <base target="_self" />

    <script language="javascript">	
function checkbutton()
{
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
    retrunstr=""+document.getElementById("TextBox1").value+"";
    return retrunstr;
}

function  sendFromChild()  
{
if (window.opener != undefined) {
window.opener.returnValue = "opener returnValue";
alert('2');
}
else 
{
window.returnValue = "window returnValue";
alert('1');
}
window.close();
} 

function  bbb()  
{
alert(window.opener);
} 



    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" runat="server">三三四四</asp:TextBox>
            <input id="Button1" type="button" value="提交" onclick="sendFromChild()" />
            <asp:Button ID="Button2" runat="server" Text="Button" />
            <input id="Button3" type="button" value="test" onclick="bbb()" />
        </div>
    </form>
</body>
</html>
