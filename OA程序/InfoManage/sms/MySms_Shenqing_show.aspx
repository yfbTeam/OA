﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MySms_Shenqing_show.aspx.cs"
    Inherits="xyoa.InfoManage.sms.MySms_Shenqing_show" %>

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
                                                            <a href="MySms_Shenqing.aspx" class="line_b">
                                                                发送短信申请</a> >> 查看发送手机短信</td>
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
                                                                <font class="shadow_but">手机短信</font></button></td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        内部接收人：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="acceptrealname" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        外部接收人：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="wbUsername" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        信息内容：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Label ID="Content" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        计划发送时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Starttime" runat="server"></asp:Label></td>
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
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="返 回" OnClick="Button2_Click" />
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
        <asp:TextBox ID="acceptusername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="wbRealname" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
        <input id="YjbNodeId" type="hidden" runat="server" />
        <input id="NodeName" type="hidden" runat="server" />
        <asp:TextBox ID="GlNum" runat="server" Style="display: none"></asp:TextBox>
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
