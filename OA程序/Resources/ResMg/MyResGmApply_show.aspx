﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyResGmApply_show.aspx.cs"
    Inherits="xyoa.Resources.ResMg.MyResGmApply_show" %>

<html>
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
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" id="printshow1">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0" id="printshow2">
                        <tr>
                            <td height="35">
                                <div>
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="MyResGmApply.aspx">物品购买</a> >> 审批物品购买</td>
                                                        <td width="81%">
                                                            &nbsp;</td>
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
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow3">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">物品购买</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            <input onclick='window.open ("/WorkFlowSysMag/AddWorkFlow_show_lc.aspx?FormId=<%=ViewState["FormId"]%>&DqNodeId=<%=ViewState["DqNodeId"]%>&DqNodeName=<%=ViewState["DqNodeName"]%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'
                                                                type="button" value="办理流程图" id="Button11" class="button_css">
                                                            <input id="button" type="button" value="打 印" onclick="printnewpage()" class="button_css" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage"
                                                id="tableprint">
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17" align="left">
                                                        <b>创建人：</b><asp:Label ID="Realname" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;<b>申请时间：</b><asp:Label ID="NowTimes" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;<b>当前步骤：</b><asp:Label ID="DqNodeName1" runat="server"></asp:Label>
                                                        &nbsp;&nbsp;<b>办理状态：</b><asp:Label ID="LcZhuangtai" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>物品信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        物品编号：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="ZyNum" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        物品名称：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="ZyName" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        物品型号：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="Xinghao" runat="server"></asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        物品描述：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="ZyIntro" runat="server" Text=""></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        所属仓库：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:Label ID="Cangku" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        所属区域：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:Label ID="Quyu" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        当前库存：
                                                    </td>
                                                    <td class="newtd2" width="83%" style="height: 17px" colspan="3">
                                                        <asp:Label ID="KuCun" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
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
                                                        <asp:Label ID="JbName" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        购买时间：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:Label ID="GmTime" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        购买数量：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:Label ID="GmNum" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        购买费用：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:Label ID="GmFeiyong" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        供应商：</td>
                                                    <td class="newtd2" colspan="3" style="height: 17px">
                                                        <asp:Label ID="Gongyinshang" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        其他说明：</td>
                                                    <td class="newtd2" colspan="3" style="height: 17px">
                                                        <asp:Label ID="Shuoming" runat="server"></asp:Label>&nbsp;
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
                                                            <font color="red">※</font>主办人：</td>
                                                        <td class="newtd2" height="17" colspan="3" width="85%">
                                                            <asp:TextBox ID="ZbRealname" runat="server" CssClass="ReadOnlyText" Width="241px"></asp:TextBox><input
                                                                id="Button9" type="button" value="选择主办人" onclick="opengw()" runat="server" />
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
                                                                <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css" OnClick="Button1_Click2" />
                                                            </font>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="ZyId" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="GlNum" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Username" runat="server" Style="display: none"></asp:TextBox>
        <input id="YjbNodeId" type="hidden" runat="server" />
        <input id="NodeName" type="hidden" runat="server" />
        <asp:TextBox ID="ZbUsername" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="JbZhuangjiao" runat="server" Style="display: none"></asp:TextBox>

        <script>
         
function _change()
{
   var text=form1.normalcontent.value;
   if (text !="请选择")
   {
       document.getElementById('Yijian').value +=text;
   }
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
