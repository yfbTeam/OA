<%@ Page Language="C#" AutoEventWireup="true" Codebehind="UserInfo.aspx.cs" Inherits="xyoa.Client.UserInfo" %>

<html>

<script>
function chknull()
{
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

    <base target="_self" />

    <script>
function openwindows(urlstr)
{
    //控件宽
    var aw = 695;
    //控件高
    var ah = 466;
    //计算控件水平位置
    var al = (screen.width - aw)/2-190;
    //计算控件垂直位置
    var at = (screen.height - ah)/5+80;
    window.open(""+urlstr+"","_blank","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
}

function openwindowsemail(urlstr)
{
    //控件宽
    var aw = 725;
    //控件高
    var ah = 556;
    //计算控件水平位置
    var al = (screen.width - aw)/2-190;
    //计算控件垂直位置
    var at = (screen.height - ah)/5+80;
    window.open(""+urlstr+"","_blank","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
}

function opendr()
{
    var num=Math.random();
    window.showModalDialog("UserInfo_pm.aspx?tmp="+num+"",window,"dialogWidth:680px;DialogHeight=520px;status:no;scroll=yes;help:no")
}
    </script>

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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>基本信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        用户姓名：</td>
                                                    <td class="newtd2" height="17" colspan="2">
                                                        <asp:Label ID="Realname" runat="server"></asp:Label>
                                                        <a href="javascript:void(0)" onclick="openwindows('/InfoManage/messages/talk.aspx?user=<%=Request.QueryString["user"].ToString() %>')">
                                                            [消息]</a><a href="javascript:void(0)" onclick="openemail()">[邮件]</a><asp:LinkButton
                                                                ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">[关注]</asp:LinkButton>
                                                    </td>
                                                    <td class="newtd2" rowspan="4" width="27%">
                                                        <asp:Image ID="Xiangpian" runat="server" Height="119px" Width="104px" /></td>
                                                </tr>
                                                <tr class="" id="Tr4">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        知识堂积分：</td>
                                                    <td class="newtd2" height="17" colspan="2">
                                                        <asp:Label ID="zhishitang" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr class="" id="Tr3">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        在线时长：</td>
                                                    <td class="newtd2" height="17" colspan="2">
                                                        当前<asp:Label ID="Zhuangtai" runat="server" ForeColor="Red"></asp:Label>，共在线：<font
                                                            color="blue"><asp:Label ID="Zaixian" runat="server"></asp:Label></font>，最后活动时间：<font
                                                                color="blue"><%=ViewState["lasttime"]%></font>，当前在线时间排名：<font color="blue"><%=ViewState["count"] %></font>，【<a
                                                                    href="javascript:void(0)" onclick="opendr();">全部排名</a>】</td>
                                                </tr>
                                                <tr class="" id="Tr5">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        最新动态：</td>
                                                    <td class="newtd2" height="17" colspan="2">
                                                        <%=ViewState["dongtai"] %>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        部门名称：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Unit" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        职位：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Post" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        性别：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:Label ID="Sex" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        生日：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:Label ID="Bothday" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr class="" id="nextrs1">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <strong>联系信息</strong>&nbsp;</div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        单位电话：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:Label ID="Tel" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        单位传真：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:Label ID="Fax" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        手机：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:Label ID="MoveTel" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        备用电话：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:Label ID="LittleTel" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        电子邮件：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:Label ID="Email" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        QQ号码：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:Label ID="QQNum" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        MSN：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:Label ID="Msn" runat="server"></asp:Label></td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        内部即时通：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:Label ID="ICQ" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr class="" id="Tr1">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <strong>家庭信息</strong>&nbsp;</div>
                                                    </td>
                                                </tr>
                                                <tr class="" id="Tr2">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        家庭住址：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:Label ID="Address" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="17%">
                                                        家庭邮编：</td>
                                                    <td class="newtd2" height="24" width="33%">
                                                        <asp:Label ID="ZipCode" runat="server"></asp:Label></td>
                                                    <td align="right" class="newtd1" height="24" nowrap="nowrap" width="15%">
                                                        家庭电话：</td>
                                                    <td class="newtd2" height="24" width="35%">
                                                        <asp:Label ID="HomeTel" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <asp:Button ID="Button1" runat="server" Text="修 改" CssClass="button_css" OnClick="Button1_Click" />
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
    </form>
</body>
</html>
