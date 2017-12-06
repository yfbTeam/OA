﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="RichengmyList_add.aspx.cs"
    Inherits="xyoa.MyWork.Richeng.RichengmyList_add" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<html>

<script>
function chknull()
{
    if(document.getElementById('titles').value=='')
    {
    alert('日程标题不能为空');
    form1.titles.focus();
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
    
    
    showwait();	
}  

function openqiupengmodle()
{
var num=Math.random();
window.open ("/fckeditor/modle.aspx?tmp="+num+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function qiupengmodel(str)
{
var oEditor = FCKeditorAPI.GetInstance('Content') 
oEditor.InsertHtml(''+str+'');
}
</script>

<script language="javascript" type="text/javascript">

function checkForm()
{

var strUploadFile=document.getElementById('uploadFile').value;

if (strUploadFile=="")
{
alert("提示:\r您还没有选择上传的文件！"); 
return false;


} 
var nameLen=strUploadFile.length;
var rightName=strUploadFile.substr(nameLen-4,4).toLowerCase();

var sAllowExt = "<%=Session["FjKey"]%>";
var str = document.getElementById('uploadFile').value;
var rightName=str.substr(str.lastIndexOf('.')+1,str.length - str.lastIndexOf('.')).toLowerCase();

if(sAllowExt!=="*")
{
    if(sAllowExt.indexOf(rightName)==-1)
    {
	    alert('格式不对，只能上传'+sAllowExt+'\r如需要上传其他格式文件，请联系管理员！');
	    return false;
    }
}

showwait();	



}


function  down()  
{
if(document.getElementById('fjlb').value=='')
{

alert('未选中文件');

return false;
}
else
{

var num=Math.random();
var littleproduct=document.getElementById("fjlb");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;

window.open ("/file_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}


}

function  delfj()  
{
if(document.getElementById('fjlb').value=='')
{

alert('未选中文件');
return false;
}
else
{
if (!confirm("是否确定要删除？"))
return false;

showwait();	
var num=Math.random();
var littleproduct=document.getElementById("fjlb");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;

window.showModalDialog("/file_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1000px;DialogHeight=600px;status:no;scroll=yes;help:no");                

}


}			


function  openfile()  
{  
    var num=Math.random();
    var number=document.getElementById('Number').value;
    window.showModalDialog("/openfile.aspx?tmp="+num+"&number="+number+" ","window","dialogWidth:680px;DialogHeight=580px;status:no;scroll=yes;help:no");                
}


</script>

<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow1">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                </td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="Richengmy.aspx">我的日程</a>
                                                            >> 新增我的日程</td>
                                                        <td width="81%">
                                                            </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" class="nexttop">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow2">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                </td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">我的日程</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            隐私警示：相关的监控人员将可能查看到您的日程安排，请注意隐私。</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>日程信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>日程标题：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="titles" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>开始时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="StartTime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                       
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>结束时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="EndTime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                        
                                                    </td>
                                                </tr>
                                                                     <tr id="trUser">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        协办人员：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="XbRealname" runat="server" Width="85%" Height="38px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        日程内容(<a href="javascript:void(0)" onclick="openqiupengmodle()">模版</a>)：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <FCKeditorV2:FCKeditor ID="Content" runat="server" Height="250px" ToolbarSet="Qiupeng1">
                                                        </FCKeditorV2:FCKeditor>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        是否公开：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="Gongkai" runat="server" Width="100%">
                                                            <asp:ListItem>否</asp:ListItem>
                                                            <asp:ListItem>是</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr class="" id="nextrs22">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        附件：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:DropDownList ID="fjlb" runat="server" Width="70%">
                                                        </asp:DropDownList>&nbsp;
                                                        <input id="Button5" type="button" value="下　载" onclick="down();" />
                                                        <asp:Button ID="Button3" runat="server" Text="删　除" /></td>
                                                </tr>
                                                <tr class="" id="nextrs23">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        上传附件：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <input id="uploadFile" runat="server" style="width: 383px" type="file" name="uploadFile" />
                                                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="上　传" />
                                                        <asp:Button ID="Button12" runat="server" Text="从文件柜导入" /></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>导入闹钟提醒</b><asp:CheckBox ID="CheckBox1" runat="server" onclick="aaa()" /></td>
                                                </tr>
                                                <tr id="nextrs1" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        提醒类型：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Types" runat="server" Width="100%">
                                                            <asp:ListItem Value="2">仅一次</asp:ListItem>
                                                            <asp:ListItem Value="1">每天循环</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        提醒时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="txtime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                      
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css"
                                                                    OnClick="Button2_Click" />
                                                            </font>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="XbUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	

            var  wName_1;  
            function  openuser1()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('XbUsername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("XbUsername").value=arr[0]; 
                    document.getElementById("XbRealname").value=arr[1]; 
                }
            }
            
        </script>
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
