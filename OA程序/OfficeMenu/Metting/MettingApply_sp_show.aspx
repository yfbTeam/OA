﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MettingApply_sp_show.aspx.cs"
    Inherits="xyoa.OfficeMenu.Metting.MettingApply_sp_show" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script>
function _change()
{
   var text=form1.normalcontent.value;
   if (text !="请选择")
   {
       document.getElementById('Yijian').value +=text;
   }
}
function m_show()
{ 
    var num=Math.random();
    window.showModalDialog('MettingApply_sp_ct.aspx?id=<%=Request.QueryString["id"] %>&tmp='+num+'','window','dialogWidth:877px;DialogHeight=500px;status:no;help=no;scroll=on');
}
    </script>

</head>
<body class="newbody" onload="aaa()">
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
                                                            <a href="MettingApply_sp.aspx">会议审批</a> >> 审批会议申请</td>
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
                                                                <font class="shadow_but">会议审批</font></button></td>
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
                                                    <td class="newtd2" colspan="4" height="17" align="left">
                                                        <b>创建人：</b><asp:Label ID="Realname" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;<b>申请时间：</b><asp:Label ID="NowTimes" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;<b>当前步骤：</b><asp:Label ID="DqNodeName1" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;<b>办理状态：</b><asp:Label ID="LcZhuangtai" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        会议名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Label ID="Name" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        描述：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:Label ID="Introduction" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        出席人员(外部)：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:Label ID="WbPeople" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        出席人员(内部)：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:Label ID="NbPeopleName" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 24px">
                                                        会议室：</td>
                                                    <td class="newtd2" width="83%" style="height: 24px" colspan="3">
                                                        <asp:Label ID="MettingName" runat="server"></asp:Label>&nbsp;
                                                        <input id="Button2" type="button" value="<%=ViewState["ctstr"]%>检测" onclick="m_show();" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        开始时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Starttime" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        结束时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Endtime" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr class="" id="Tr2">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        备注：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:Label ID="Remark" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr class="" id="nextrs22">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        附件：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:Label ID="fujian" runat="server" Width="90%"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17" align="center">
                                                        <b>办理过程信息</b><asp:CheckBox ID="CheckBox1" runat="server" onclick="aaa()" /></td>
                                                </tr>
                                                <tr id="nextrs1" style="display: none">
                                                    <td class="newtd2" height="17" nowrap="nowrap" colspan="4">
                                                        <asp:Label ID="Liucheng" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17" align="center">
                                                        <b>工作办理</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        办理意见：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:RadioButtonList ID="CaoZuo" runat="server" RepeatDirection="Horizontal" AutoPostBack="True"
                                                            OnSelectedIndexChanged="CaoZuo_SelectedIndexChanged">
                                                            <asp:ListItem Selected="True" Value="3">同意</asp:ListItem>
                                                            <asp:ListItem Value="4">不同意</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        转交步骤：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:RadioButtonList ID="FormName" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="FormName_SelectedIndexChanged"
                                                            AutoPostBack="True">
                                                        </asp:RadioButtonList>
                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="Panel1" runat="server">
                                                    <tr id="nd1">
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                            <font color="red">※</font>经办人：</td>
                                                        <td class="newtd2" height="17" colspan="3" width="85%">
                                                            <asp:TextBox ID="ZbRealname" runat="server" CssClass="ReadOnlyText" Width="241px"></asp:TextBox><input
                                                                id="Button9" type="button" value="选择经办人" onclick="opengw()" runat="server" />
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <asp:Panel ID="Panel2" runat="server">
                                                    <tr class="" id="trDept">
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            通知出席人员：</td>
                                                        <td class="newtd2" colspan="3" height="17" width="33%">
                                                            <img src="/oaimg/menu/chatroom.gif" />
                                                            <asp:CheckBox ID="CheckBox2" runat="server" Text="内部消息" Checked="True" />
                                                            <img src="/oaimg/menu/Menu30.gif" id="IMG2" runat="server" />
                                                            <asp:CheckBox ID="CheckBox3" runat="server" Text="手机短信" />
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr class="">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        常用评语：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:DropDownList ID="normalcontent" runat="server" onchange="_change()" Width="100%">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        办理意见：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:TextBox ID="Yijian" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center" id="printshow4">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button3" runat="server" Text="转 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <asp:Button ID="Button4" runat="server" Text="结 束" CssClass="button_css" OnClick="Button4_Click"
                                                                    Visible="false" />
                                                                <asp:Button ID="Button1" runat="server" Text="返 回" CssClass="button_css" OnClick="Button1_Click2" /></font></div>
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
        <asp:TextBox ID="GlNum" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Username" runat="server" Style="display: none"></asp:TextBox>
        <input id="YjbNodeId" type="hidden" runat="server" />
        <input id="NodeName" type="hidden" runat="server" />
        <asp:TextBox ID="chongtu" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ZbUsername" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="JbZhuangjiao" runat="server" Style="display: none"></asp:TextBox>

        <script>
        
           try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        
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
