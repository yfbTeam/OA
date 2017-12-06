<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Gongyu_show.aspx.cs" Inherits="xyoa.SchTable.Sushe.Gongyu.Gongyu_show" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Mingcheng').value=='')
    {
        alert('建筑名称不能为空');
        form1.Mingcheng.focus();
        return false;
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
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox></td>
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
                                                            <a href="Gongyu.aspx">公寓信息</a> >> 查看公寓信息</td>
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
                                                                <font class="shadow_but">公寓信息</font></button></td>
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
                                        <td width="17" style="height: 441px">
                                        </td>
                                        <td valign="top" style="height: 441px">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        建筑名称：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Mingcheng" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        楼编号：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Bianhao" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        建筑类型：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Leixing" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        建筑用途：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Yongtu" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        房屋状态：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Zhuangtai" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        房屋结构：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Jiegou" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        楼层：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Loucheng" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        每层最大房间数：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Fangjianshu" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        建筑时间：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Shijian" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        楼管处电话：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Dianhua" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        占用面积：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="ZyMianji" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        建筑用费：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Yongfei" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        面积：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Mianji" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        财产：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Caichang" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        所在校区：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Xiaoqu" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        位置：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="Weizhi" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        备注：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:Label ID="Beizhu" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css" OnClick="Button2_Click" />
                                                            </font>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17" style="height: 441px">
                                        </td>
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
