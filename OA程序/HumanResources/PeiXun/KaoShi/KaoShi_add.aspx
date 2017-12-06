<%@ Page Language="C#" AutoEventWireup="true" Codebehind="KaoShi_add.aspx.cs" Inherits="xyoa.HumanResources.PeiXun.KaoShi.KaoShi_add" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Zhuti').value=='')
    {
        alert('考试主题不能为空');
        form1.Zhuti.focus();
        return false;
    }
    	
    if(document.getElementById('Shijuan').value=='')
    {
        alert('试卷不能为空');
        form1.Shijuan.focus();
        return false;
    }	

    if(document.getElementById('RealnameCj').value=='')
    {
        alert('参加考试人员不能为空');
        form1.RealnameCj.focus();
        return false;
    }

    if(document.getElementById('Starttime').value=='')
    {
        alert('生效时间不能为空');
        form1.Starttime.focus();
        return false;
    }	
    
    if(document.getElementById('Endtime').value=='')
    {
        alert('终止时间不能为空');
        form1.Endtime.focus();
        return false;
    }	
    
    if(document.getElementById('Shijian').value=='')
    {
        alert('答题时间不能为空');
        form1.Shijian.focus();
        return false;
    }
    
    if(document.getElementById('Shijian').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Shijian').value))
        {
            alert("答题时间只能为正数");
            form1.Shijian.focus();
            return false;
        }
    }  
    showwait();	
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
                                                            <a href="KaoShi.aspx">网上考试</a>
                                                            >> 新增网上考试</td>
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
                                                                <font class="shadow_but">网上考试</font></button></td>
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
                                                        <font color="red">※</font>考试主题：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Zhuti" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>试卷：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="Shijuan" runat="server" Width="100%">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>生效时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Starttime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>终止时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Endtime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        <font color="red">※</font>参加考试人员：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="RealnameCj" runat="server" Width="92%" Height="65px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>答题时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Shijian" runat="server" Width="90%"></asp:TextBox>分钟
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>状态：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:RadioButtonList ID="Zhuangtai" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1">正常</asp:ListItem>
                                                            <asp:ListItem Value="2">停用</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        评分人员：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="PRealname" runat="server" Width="92%" Height="65px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser2();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <input id="Button2" class="button_css" onclick="history.back()" type="button" value="返 回" /></font></div>
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
        <asp:TextBox ID="UsernameCj" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="PUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	

try{
    parent.closeAlert('UploadChoose');
}
catch(err){
}


var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('UsernameCj').value+"";
wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("UsernameCj").value=arr[0]; 
document.getElementById("RealnameCj").value=arr[1]; 
}
}


var  wName_2;  
function  openuser2()  
{  
var num=Math.random();
var str1=""+document.getElementById('PUsername').value+"";
wName_2=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str1+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("PUsername").value=arr[0]; 
document.getElementById("PRealname").value=arr[1]; 
}
}
      
        </script>

    </form>
</body>
</html>
