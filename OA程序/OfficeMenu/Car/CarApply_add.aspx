<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CarApply_add.aspx.cs" Inherits="xyoa.OfficeMenu.Car.CarApply_add" %>

<html>

<script>
function chknull()
{
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
    var strUploadFile=document.getElementById('CarId').value;
    if (strUploadFile=="")
    {
        alert("请选择车辆！"); 
        return false;
    } 


    window.open ("ZyCar.aspx?HyName="+strUploadFile+"", "_blank", "height=600, width=860,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function yijian()
{
   var text=form1.DropDownList1.value;
   if (text !="请选择")
   {
       document.getElementById('Yijian').value +=text;
   }
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
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
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
                                                            <a href="CarApply.aspx">用车申请</a> >> 新增用车申请</td>
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
                                                                <font class="shadow_but">用车申请</font></button></td>
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
                                                        <font color="red">※</font>车辆名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="CarId" runat="server" Width="80%">
                                                        </asp:DropDownList>
                                                        <input id="Button3" type="button" value="占用情况" onclick="openhys();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 24px">
                                                        驾驶员：</td>
                                                    <td class="newtd2" width="33%" style="height: 24px">
                                                        <asp:DropDownList ID="Drivers" runat="server" Width="100%">
                                                        </asp:DropDownList></td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 24px">
                                                        用车部门：</td>
                                                    <td class="newtd2" width="35%" style="height: 24px">
                                                        <asp:DropDownList ID="UnitId" runat="server" Width="100%">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 24px">
                                                        用车人：</td>
                                                    <td class="newtd2" width="83%" style="height: 24px" colspan="3">
                                                        <asp:TextBox ID="Carpeople" runat="server" Width="85%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
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
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 24px">
                                                        目的地：</td>
                                                    <td class="newtd2" width="83%" style="height: 24px" colspan="3">
                                                        <asp:TextBox ID="Destination" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 24px">
                                                        事由：</td>
                                                    <td class="newtd2" width="83%" style="height: 24px" colspan="3">
                                                        <asp:TextBox ID="Subject" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        备注：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Remark" runat="server" Width="100%" Height="65px" TextMode="MultiLine"></asp:TextBox></td>
                                                </tr>
                                                <asp:Panel ID="PWorkFlowQy" runat="server">
                                                    <tr>
                                                        <td class="newtd2" colspan="4" height="17" align="center">
                                                            <b>审批转交信息</b></td>
                                                    </tr>
                                                    <tr id="Tr1">
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                            <font color="red">※</font>审批流程(<a href="javascript:void(0)" onclick="OpenWfPic(''+document.getElementById('FormId').value+'')">查看</a>)：</td>
                                                        <td class="newtd2" height="17" colspan="3" width="85%">
                                                            <asp:DropDownList ID="FormId" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="FormId_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                            <font color="red">※</font>转交步骤：</td>
                                                        <td class="newtd2" height="17" width="85%" colspan="3">
                                                            <asp:RadioButtonList ID="FormName" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="FormName_SelectedIndexChanged"
                                                                AutoPostBack="True">
                                                            </asp:RadioButtonList></td>
                                                    </tr>
                                                    <tr id="nd1">
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                            <font color="red">※</font>经办人：</td>
                                                        <td class="newtd2" height="17" colspan="3" width="85%">
                                                            <asp:TextBox ID="ZbRealname" runat="server" CssClass="ReadOnlyText" Width="241px"></asp:TextBox><input
                                                                id="Button9" type="button" value="选择经办人" onclick="opengw()" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr class="">
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            常用评语：</td>
                                                        <td class="newtd2" colspan="3" height="17" width="83%">
                                                            <asp:DropDownList ID="DropDownList1" runat="server" onchange="yijian()" Width="100%">
                                                            </asp:DropDownList></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                            办理意见：</td>
                                                        <td class="newtd2" width="85%" colspan="3" style="height: 17px">
                                                            <asp:TextBox ID="Yijian" runat="server" Width="100%" MaxLength="500"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
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
        <asp:TextBox ID="CarpeopleUser" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <input id="YjbNodeId" type="hidden" runat="server" />
        <input id="NodeName" type="hidden" runat="server" />
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ZbUsername" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="WorkFlowQy" runat="server" Visible="false"></asp:TextBox>

        <script>
            var  wName_5;  
            function  opengw()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('ZbUsername').value+"";
                wName_5=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=660px;status:no;scroll=yes;help:no");                
                if (wName_5 == undefined) {wName_5 = window.returnValue;}var arr = wName_5.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("ZbUsername").value=arr[0]; 
                    document.getElementById("ZbRealname").value=arr[1]; 
                }
            }
         
        </script>

        <script type="text/javascript">
           var  wName_1;  
            function  openuser1()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('CarpeopleUser').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("CarpeopleUser").value=arr[0]; 
                    document.getElementById("Carpeople").value=arr[1]; 
                }
            }
            
        </script>

    </form>
</body>
</html>
