<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="open_biaodan.aspx.cs" Inherits="xyoa.OpenWindows.open_biaodan" %>

<html>
<head>
    <title><%=Session["Titles"]%></title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
    <base target="_self" />

    <script language="javascript">	
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
    </script>

</head>
<body>
    <form id="Form1" method="post" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="requeststr" runat="server" Style="display: none"></asp:TextBox>
        <table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0"
            bordercolordark="#ffffff">
            <tr>
                <td height="22" align="left" style="font-size: 12px; font-family: 宋体">
                    请选择表单</td>
            </tr>
            <tr>
                <td valign="top" style="text-align: center">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 588px; height: 49px">
                        <tr>
                            <td style="height: 31px; text-align: center;">
                                <asp:TextBox ID="KeyBox" runat="server" Style="display: none"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 31px; text-align: center;">
                                <table border="0" cellpadding="0" cellspacing="0" style="height: 302px" align=center>
                                    <tr>
                                        <td align="center" style="width: 113px" valign="top">
                                            <asp:ListBox ID="SourceListBox" runat="server" Height="411px" Width="157px" SelectionMode="Multiple"></asp:ListBox></td>
                                        <td align="center" style="width: 42px" valign="top">
                                            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text=">" Width="58px" /><br />
                                            <br />
                                            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text=">>" Width="58px" />
                                            <br />
                                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="<" Width="58px" /><br />
                                            <br />
                                            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="<<" Width="58px" />
                                        </td>
                                        <td align="center" style="width: 100px" valign="top">
                                            <asp:ListBox ID="TargetListBox" runat="server" Height="411px" Width="157px" SelectionMode="Multiple"></asp:ListBox></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 31px; text-align: center;">
                                <input id="Button2" class="button_css" onclick="return checkbutton();" type="button"
                                    value="确  定" />
                                <input type="button" value="关　闭" onclick="closewin();" class="button_css" id="Button3">
                                <input id="Button12" class="button_css" onclick="CCC();" type="button" value="清  空" /></td>
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