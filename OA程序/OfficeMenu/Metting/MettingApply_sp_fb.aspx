<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MettingApply_sp_fb.aspx.cs"
    Inherits="xyoa.OfficeMenu.Metting.MettingApply_sp_fb" %>

<html>

<script>
function chknull()
{
if(document.getElementById('Name').value=='')
{
alert('名称不能为空');
form1.Name.focus();
return false;
}	

if(document.getElementById('NbPeopleName').value=='')
{
alert('出席人员(内部)不能为空');
form1.NbPeopleName.focus();
return false;
}	

if(document.getElementById('MettingName').value=='')
{
    alert('会议室不能为空');
    form1.MettingName.focus();
    return false;
}	

if(document.getElementById('Starttime').value=='')
{
alert('开始时间不能为空');
form1.Starttime.focus();
return false;
}	

if(document.getElementById('Endtime').value=='')
{
alert('结束时间不能为空');
form1.Endtime.focus();
return false;
}	



showwait();					
}


function openhys()
{
    var strUploadFile=document.getElementById('MettingName').value;
    if (strUploadFile=="")
    {
        alert("请选择会议室！"); 
        return false;
    } 

    var littleproduct=document.getElementById("MettingName");
    var cindex = littleproduct.selectedIndex;
    var cValue = littleproduct.options[cindex].value;

    window.open ("ZyMetting.aspx?HyName="+cValue+"", "_blank", "height=600, width=860,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
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
<body class="newbody">
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
                                                            <a href="MettingApply_sp.aspx">会议审批</a>
                                                            >> 直接发布会议</td>
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
                                                                <font class="shadow_but">直接发布</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                        </td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>会议名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Name" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        描述：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:TextBox ID="Introduction" runat="server" Height="78px" TextMode="MultiLine"
                                                            Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        出席人员(外部)：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:TextBox ID="WbPeople" runat="server" Height="55px" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>出席人员(内部)：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:TextBox ID="NbPeopleName" runat="server" Height="55px" TextMode="MultiLine"
                                                            Width="85%" CssClass="ReadOnlyText"></asp:TextBox><a href="javascript:void(0)"><img
                                                                onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 24px">
                                                        <font color="red">※</font>会议室：</td>
                                                    <td class="newtd2" width="83%" style="height: 24px" colspan="3">
                                                        <asp:DropDownList ID="MettingName" runat="server" Width="70%">
                                                        </asp:DropDownList>
                                                        <input id="Button31" type="button" value="占用情况" onclick="openhys();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>开始时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Starttime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                        </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>结束时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Endtime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                       </td>
                                                </tr>
                                                <tr class="" id="Tr2">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        备注：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:TextBox ID="Remark" runat="server" Width="100%" Height="78px" TextMode="MultiLine"></asp:TextBox></td>
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
                                                <tr class="" id="trDept">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        通知出席人员：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="33%">
                                                        <img src="/oaimg/menu/chatroom.gif" />
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="内部消息" Checked="true" />
                                                        <img src="/oaimg/menu/Menu30.gif" id="IMG2" runat="server" />
                                                        <asp:CheckBox ID="CheckBox3" runat="server" Text="手机短信" />
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
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
        <asp:TextBox ID="NbPeopleUser" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
        <input id="YjbNodeId" type="hidden" runat="server" />
        <input id="NodeName" type="hidden" runat="server" />

        <script type="text/javascript">
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
            
           var  wName_1;  
            function  openuser1()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('NbPeopleUser').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("NbPeopleUser").value=arr[0]; 
                    document.getElementById("NbPeopleName").value=arr[1]; 
                }
            }
            
        </script>

    </form>
</body>
</html>
