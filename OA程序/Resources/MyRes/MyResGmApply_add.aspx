<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyResGmApply_add.aspx.cs"
    Inherits="xyoa.Resources.MyRes.MyResGmApply_add" %>

<html>

<script>
function chknull()
{

    if(document.getElementById('ZyName').value=='')
    {
        alert('物品名称不能为空');
        form1.ZyName.focus();
        return false;
    }	

    if(document.getElementById('GmTime').value=='')
    {
        alert('购买时间不能为空');
        form1.GmTime.focus();
        return false;
    }	

    if(document.getElementById('GmNum').value=='')
    {
        alert('购买数量不能为空，没有请填为０');
        form1.GmNum.focus();
        return false;
    }	
 
 
    if(document.getElementById('GmNum').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('GmNum').value))
        {
            alert("购买数量只能为正数");
            form1.GmNum.focus();
            return false;
        }

    }   
    
    
    if(document.getElementById('GmFeiyong').value=='')
    {
        alert('购买费用不能为空，没有请填为０');
        form1.GmFeiyong.focus();
        return false;
    }
    
    if(document.getElementById('GmFeiyong').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('GmFeiyong').value))
        {
            alert("购买费用只能为正数");
            form1.GmFeiyong.focus();
            return false;
        }
    }   
    showwait();					
}

function _change()
{
   var text=form1.normalcontent.value;
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
                                                            <a href="ResGm.aspx">物品购买</a> >> 新增物品购买</td>
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
                                                                <font class="shadow_but">物品购买</font></button></td>
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
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>物品信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>物品名称：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="ZyName" runat="server" Width="90%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img id="Img1" onclick="return opencp()" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>购买信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        经办人：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:TextBox ID="JbName" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        <font color="red">※</font>购买时间：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:TextBox ID="GmTime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        <font color="red">※</font>购买数量：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:TextBox ID="GmNum" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        <font color="red">※</font>购买费用：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:TextBox ID="GmFeiyong" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        供应商：</td>
                                                    <td class="newtd2" colspan="3" style="height: 17px">
                                                        <asp:TextBox ID="Gongyinshang" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        其他说明：</td>
                                                    <td class="newtd2" colspan="3" style="height: 17px">
                                                        <asp:TextBox ID="Shuoming" runat="server" Width="100%" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
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
                                                            <font color="red">※</font>主办人：</td>
                                                        <td class="newtd2" height="17" colspan="3" width="85%">
                                                            <asp:TextBox ID="ZbRealname" runat="server" CssClass="ReadOnlyText" Width="241px"></asp:TextBox><input
                                                                id="Button9" type="button" value="选择主办人" onclick="opengw()" runat="server" />
                                                        </td>
                                                    </tr>
                                                    <tr class="">
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            常用评语：</td>
                                                        <td class="newtd2" colspan="3" height="17" width="83%">
                                                            <asp:DropDownList ID="normalcontent" runat="server" onchange="_change()" Width="100%">
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
        <asp:TextBox ID="ZyId" runat="server" Style="display: none"></asp:TextBox>
        <input id="YjbNodeId" type="hidden" runat="server" />
        <input id="NodeName" type="hidden" runat="server" />
        <asp:TextBox ID="ZbUsername" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
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

        <script language="javascript">	
            var  wName_2;  
            function  opencp()  
            {  
                var num=Math.random();
                var clid=""+document.getElementById('ZyId').value+"";
                wName_2=window.showModalDialog("/OpenWindows/OpenZiChang.aspx?tmp="+num+"&id="+clid+"","window", "dialogWidth:780px;DialogHeight=660px;status:no;scroll=yes;help:no");                
                if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("ZyId").value=arr[0]; 
                    document.getElementById("ZyName").value=arr[1]; 
                }
            }
        </script>

    </form>
</body>
</html>
