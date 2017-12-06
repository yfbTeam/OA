<%@ Page Language="C#" AutoEventWireup="true" Codebehind="KaoPingSz_show.aspx.cs"
    Inherits="xyoa.HumanResources.KaoPing.KaoPingSz.KaoPingSz_show" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <style>
.mbcss {
border-left:0px;
border-top:0px;
border-right:0px;
border-bottom:1px solid #000000
}
</style>
    <script>
function select_type()
{
   if (form1.Jishu.value=="1")
   {
       kpstep1.style.display='';
       kpstep2.style.display='none';
       kpstep3.style.display='none';
       kpstep4.style.display='none';
       kpstep5.style.display='none';
   }
   else if (form1.Jishu.value=="2")
   {
       kpstep1.style.display='';
       kpstep2.style.display='';
       kpstep3.style.display='none';
       kpstep4.style.display='none';
       kpstep5.style.display='none';
   }
   else if (form1.Jishu.value=="3")
   {
       kpstep1.style.display='';
       kpstep2.style.display='';
       kpstep3.style.display='';
       kpstep4.style.display='none';
       kpstep5.style.display='none';
   }
   else if (form1.Jishu.value=="4")
   {
       kpstep1.style.display='';
       kpstep2.style.display='';
       kpstep3.style.display='';
       kpstep4.style.display='';
       kpstep5.style.display='none';
   }
   else if (form1.Jishu.value=="5")
   {
       kpstep1.style.display='';
       kpstep2.style.display='';
       kpstep3.style.display='';
       kpstep4.style.display='';
       kpstep5.style.display='';
   }
}
    </script>

</head>
<body class="newbody" onload="select_type()">
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
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow2">
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
                                                            <a href="KaoPingSz.aspx">考评设置</a>
                                                            >> 查看考评设置</td>
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
                                                                <font class="shadow_but">考评设置</font></button></td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        考评类型：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Leixing" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        考评总分：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Zongfen" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        考评级数：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="Jishu1" runat="server"></asp:Label>级&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        考评模版内容：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="Neirong" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        自我考评权重：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="QuanzhongMy" runat="server"></asp:Label>%
                                                    </td>
                                                </tr>
                                                <tr id="kpstep1" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        1级考评人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Name1" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        1级权重：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Quanzhong1" runat="server"></asp:Label>%
                                                    </td>
                                                </tr>
                                                <tr id="kpstep2" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        2级考评人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Name2" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        2级权重：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Quanzhong2" runat="server"></asp:Label>%
                                                    </td>
                                                </tr>
                                                <tr id="kpstep3" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        3级考评人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Name3" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        3级权重：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Quanzhong3" runat="server"></asp:Label>%
                                                    </td>
                                                </tr>
                                                <tr id="kpstep4" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        4级考评人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Name4" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        4级权重：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Quanzhong4" runat="server"></asp:Label>%
                                                    </td>
                                                </tr>
                                                <tr id="kpstep5" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        5级考评人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Name5" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        5级权重：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Quanzhong5" runat="server"></asp:Label>%
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center" id="printshow4">
                                                            <font face="宋体">
                                                                <input id="Button2" type="button" value="返 回" onclick="history.go(-1)" class="button_css" />
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
        <asp:TextBox ID="Jishu" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="User1" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="User2" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="User3" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="User4" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="User5" runat="server" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>
