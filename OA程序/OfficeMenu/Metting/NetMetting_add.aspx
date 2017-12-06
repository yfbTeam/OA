<%@ Page Language="C#" AutoEventWireup="true" Codebehind="NetMetting_add.aspx.cs"
    Inherits="xyoa.OfficeMenu.Metting.NetMetting_add" %>

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

if(document.getElementById('MettingIp').value=='')
{
alert('会议室IP不能为空');
form1.MettingIp.focus();
return false;
}	

if(document.getElementById('MettingHeader').value=='')
{
alert('会议室主持人不能为空');
form1.MettingHeader.focus();
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



return check_Date(document.getElementById('Starttime').value,document.getElementById('Endtime').value,"开始时间","结束时间")

showwait();					



}
function check_Date(date1,date2,date1Text,date2Text)
{
    var date1,date2,date1Text,date2Text;
    date1=date1.replace(/\-/g,"/");
    date2=date2.replace(/\-/g,"/");
    if(Date.parse(date1) > Date.parse(date2))
    {
        alert("错误！"+date1Text+"应在"+date2Text+"之前！")
        return false;
    }

}
</script>

<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
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
                                                            <a href="NetMetting.aspx">网络会议</a>
                                                            >> 新增网络会议</td>
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
                                                                <font class="shadow_but">网络会议</font></button></td>
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
                                                        会议主题：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:TextBox ID="Titles" runat="server" Width="100%"></asp:TextBox></td>
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
                                                            Width="85%" CssClass="ReadOnlyText"></asp:TextBox><a href="javascript:void(0)"><img onclick="openuser1();"
                                                                alt="" src="/oaimg/FDJ.gif" border="0"></a></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 24px">
                                                        <font color="red">※</font>网络会议室IP：</td>
                                                    <td class="newtd2" width="33%" style="height: 24px">
                                                        <asp:TextBox ID="MettingIp" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 24px">
                                                        <font color="red">※</font>会议主持人：</td>
                                                    <td class="newtd2" width="35%" style="height: 24px">
                                                        <asp:TextBox ID="MettingHeader" runat="server" Width="85%"  CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
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
                                                        <asp:TextBox ID="Remark" runat="server" Width="95%" Height="78px" TextMode="MultiLine" MaxLength="4000"></asp:TextBox></td>
                                                </tr>
                                                <tr class="">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        通知会议室管理员：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="33%">
                                                        <img src="/oaimg/menu/chatroom.gif" />
                                                        <asp:CheckBox ID="C1" runat="server" Text="内部消息" Checked="True" />
                                                        <img src="/oaimg/menu/Menu30.gif" id="IMG1" runat="server" />
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Text="手机短信" />
                                                    </td>
                                                </tr>
                                                <tr class="">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        通知出席人员：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="33%">
                                                        <img src="/oaimg/menu/chatroom.gif" />
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="内部消息" Checked="True" />
                                                        <img src="/oaimg/menu/Menu30.gif" id="IMG2" runat="server" />
                                                        <asp:CheckBox ID="CheckBox3" runat="server" Text="手机短信" />
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
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
        <asp:TextBox ID="MettingHeaderUser" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script type="text/javascript">

            var  wName_3;  
            function  openuser()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('MettingHeaderUser').value+"|"+document.getElementById('MettingHeader').value+"";
                wName_3=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("MettingHeaderUser").value=arr[0]; 
                    document.getElementById("MettingHeader").value=arr[1]; 
                }
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
