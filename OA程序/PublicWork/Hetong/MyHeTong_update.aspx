<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyHeTong_update.aspx.cs" Inherits="xyoa.PublicWork.Hetong.MyHeTong_update" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<html>

<script>
function chknull()
{

    
    if(document.getElementById('Zhuti').value=='')
    {
        alert('合同主题不能为空');
        form1.Zhuti.focus();
        return false;
    }
    
    
    if(document.getElementById('Jine').value=='')
    {
        alert('金额不能为空，没有请填为0');
        form1.Jine.focus();
        return false;
    }	
 
    if(document.getElementById('Jine').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Jine').value))
        {
            alert("金额只能为正数");
            form1.Jine.focus();
            return false;
        }
    }  

    if(document.getElementById('Fenlei').value=='')
    {
        alert('请选择合同类别');
        form1.Fenlei.focus();
        return false;
    }	
    
    
    if(document.getElementById('Qianyue').value=='')
    {
        alert('签定时间不能为空');
        form1.Qianyue.focus();
        return false;
    }	
    
    if(document.getElementById('Daoqi').value=='' && document.getElementById('Qixian').value=='1')
    {
        alert('到期时间不能为空');
        form1.Daoqi.focus();
        return false;
    }	
    
    
    showwait();					
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


function yijian()
{
   var text=form1.DropDownList1.value;
   if (text !="请选择")
   {
       document.getElementById('Yijian').value +=text;
   }
}

function openqiupengmodle()
{
    var num=Math.random();
    window.open ("/fckeditor/modle.aspx?tmp="+num+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}


function qiupengmodel(str)
{
    var oEditor = FCKeditorAPI.GetInstance('Neirong') 
    oEditor.InsertHtml(''+str+'');
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
<body class="newbody" onload="select_type()">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
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
                                                            <a href="MyHetong.aspx">我的合同</a>
                                                            >> 修改我的合同</td>
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
                                                                <font class="shadow_but">我的合同</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            <input onclick='window.open ("/WorkFlowSysMag/AddWorkFlow_show_lc.aspx?FormId=<%=ViewState["FormId"]%>&DqNodeId=<%=ViewState["DqNodeId"]%>&DqNodeName=<%=ViewState["DqNodeName"]%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'
                                                                type="button" value="办理流程图" id="Button11" class="button_css"></td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>合同主题：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="Zhuti" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        合同号：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Hetonghao" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>合同金额(元)：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Jine" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        对方单位：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="Danwei" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>合同类别：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Fenlei" runat="server" Width="100%">
                                                        </asp:DropDownList></td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>状态：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:RadioButtonList ID="Zhuangtai" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1">执行中</asp:ListItem>
                                                            <asp:ListItem Value="2">结束</asp:ListItem>
                                                            <asp:ListItem Value="3">意外终止</asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>签定时间：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="Qianyue" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                      
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>有无期限：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="Qixian" runat="server" Width="100%" onchange="select_type()">
                                                            <asp:ListItem Value="1">有</asp:ListItem>
                                                            <asp:ListItem Value="2">无</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="trshijian">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>到期时间：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Daoqi" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                        
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        合同内容(<a href="javascript:void(0)" onclick="openqiupengmodle()">模版</a>)：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <FCKeditorV2:FCKeditor ID="Neirong" runat="server" Height="220px" ToolbarSet="Qiupeng1">
                                                        </FCKeditorV2:FCKeditor>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        审批状态：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="LcZhuangtai" runat="server" Width="100%"  CssClass="ReadOnlyText"></asp:TextBox>
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
                                              
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                <asp:Button ID="Button6" runat="server" Text="提 交" CssClass="button_css" OnClick="Button6_Click" />
                                                                <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="返 回" OnClick="Button2_Click" /></font></div>
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
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
        <input id="YjbNodeId" type="hidden" runat="server" />
        <input id="NodeName" type="hidden" runat="server" />

        <script>
function select_type()
{
   if (form1.Qixian.value=="1")
   {
       trshijian.style.display='';
   }
   else if (form1.Qixian.value=="2")
   {
       trshijian.style.display='none';
   }
}
        </script>

    </form>
</body>
</html>