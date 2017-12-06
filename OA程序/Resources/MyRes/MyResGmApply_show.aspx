﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyResGmApply_show.aspx.cs"
    Inherits="xyoa.Resources.MyRes.MyResGmApply_show" %>

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
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0" id="printshow1">
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
                                                            <a href="MyResGmApply.aspx">物品购买</a>
                                                            >> 查看物品购买</td>
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
                                                            <input id="Button3" type="button" value="打 印" onclick="printnewpage()" class="button_css" /></td>
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
                                                <tr id="printshow4">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <input id="Button2" type="button" value="返 回" onclick="history.go(-1)" class="button_css" /></font></div>
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
        <asp:TextBox ID="GlNum" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
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
