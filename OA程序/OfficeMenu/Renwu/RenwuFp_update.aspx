<%@ Page Language="C#" AutoEventWireup="true" Codebehind="RenwuFp_update.aspx.cs"
    Inherits="xyoa.OfficeMenu.Renwu.RenwuFp_update" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<html>

<script>
function chknull()
{
    if(document.getElementById('titles').value=='')
    {
    alert('任务标题不能为空');
    form1.titles.focus();
    return false;
    }	
    
    if(document.getElementById('Leixing').value=='')
    {
    alert('任务类型不能为空');
    form1.Leixing.focus();
    return false;
    }	
    
    if(document.getElementById('ZbRealname').value=='')
    {
    alert('主办人不能为空');
    form1.ZbRealname.focus();
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
                                                            <a href="RenwuFp.aspx">任务分配</a>
                                                            >> 修改任务</td>
                                                        <td width="16%">
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
                                                        <td width="20%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">任务分配</font></button></td>
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
                                                        <font color="red">※</font>任务标题：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="titles" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>开始时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Starttime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                      
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>预计结束时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Endtime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                   
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>任务类型：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Leixing" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>主办人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="ZbRealname" runat="server" Width="85%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser();" alt="" src="/oaimg/FDJ.gif" border="0"></a></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" colspan="4" width="100%">
                                                        <div align="center">
                                                            <font face="宋体"><strong>协办人员</strong></font></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="newtd2" colspan="4" height="26" width="33%">
                                                        增加协办人：
                                                        <asp:TextBox ID="Realname" runat="server" CssClass="ReadOnlyText"></asp:TextBox><a
                                                            href="javascript:void(0)"><img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif"
                                                                border="0"></a>
                                                        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="确定增加" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="newtd2" colspan="4" height="26" width="33%">
                                                        <asp:GridView ID="XieBanUser" runat="server" AutoGenerateColumns="False"
                                                            BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px"
                                                            CellPadding="4" CellSpacing="1" GridLines="None" PageSize="6" Style="font-size: 12px"
                                                            Width="100%" OnRowCommand="XieBanUser_RowCommand" OnRowDataBound="XieBanUser_RowDataBound">
                                                            <PagerSettings Visible="False" />
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Realname" HeaderText="姓名" SortExpression="Realname">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="状态" SortExpression="Zhuangtai">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <%# ((Eval("Zhuangtai").ToString().Replace("1", "进行中").Replace("2", "已暂停").Replace("3", "强行停止").Replace("4", "已完成")))%>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Neirong" HeaderText="工作内容" SortExpression="Neirong">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Baifenbi" HeaderText="完成百分比" SortExpression="Baifenbi">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="相关操作">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" Width="160px" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="XiuGai" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="Xiugai">修改</asp:LinkButton>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="ShanChu">删除</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="160px" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                                            <EmptyDataTemplate>
                                                                <div align="center">
                                                                    <font color="white">无相关数据！</font></div>
                                                            </EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        任务内容(<a href="javascript:void(0)" onclick="openqiupengmodle()">模版</a>)：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <FCKeditorV2:FCKeditor ID="Content" runat="server" Height="250px" ToolbarSet="Qiupeng1">
                                                        </FCKeditorV2:FCKeditor>
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
        <asp:TextBox ID="ZbUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Username" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	


           
            function  openuser()  
            {  
                var  wName_3;  
                var num=Math.random();
                var str=""+document.getElementById('ZbUsername').value+"|"+document.getElementById('ZbRealname').value+"";
                wName_3=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("ZbUsername").value=arr[0]; 
                    document.getElementById("ZbRealname").value=arr[1]; 
                }
            }


            function  openuser1()  
            {  
                var  wName_3;  
                var num=Math.random();
                var str=""+document.getElementById('Username').value+"|"+document.getElementById('Realname').value+"";
                wName_3=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("Username").value=arr[0]; 
                    document.getElementById("Realname").value=arr[1]; 
                }
            }
            
        </script>

    </form>
</body>
</html>
