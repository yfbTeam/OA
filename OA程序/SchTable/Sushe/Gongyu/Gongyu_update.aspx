<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Gongyu_update.aspx.cs" Inherits="xyoa.SchTable.Sushe.Gongyu.Gongyu_update" %>
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

    if(document.getElementById('Bianhao').value=='')
    {
        alert('楼编号不能为空');
        form1.Bianhao.focus();
        return false;
    }	
    
    if(document.getElementById('Loucheng').value=='')
    {
        alert('楼层不能为空');
        form1.Loucheng.focus();
        return false;
    }	
    
    if(document.getElementById('Fangjianshu').value=='')
    {
        alert('每层最大房间数不能为空');
        form1.Fangjianshu.focus();
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
                                                            <a href="Gongyu.aspx">公寓信息</a> >> 修改公寓信息</td>
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
                                                        <font color="red">※</font>建筑名称：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Mingcheng" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        楼编号：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Bianhao" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        建筑类型：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:DropDownList ID="Leixing" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        建筑用途：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:DropDownList ID="Yongtu" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        房屋状态：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:DropDownList ID="Zhuangtai" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        房屋结构：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:DropDownList ID="Jiegou" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                           <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>楼层：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Loucheng" runat="server" Width="100%" MaxLength="25" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='1';};"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>每层最大房间数：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Fangjianshu" runat="server" Width="100%" MaxLength="25" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='1';};"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        建筑时间：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Shijian" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        楼管处电话：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Dianhua" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        占用面积：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="ZyMianji" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        建筑用费：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Yongfei" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        面积：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Mianji" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        财产：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Caichang" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        所在校区：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Xiaoqu" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        位置：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Weizhi" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        备注：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="Beizhu" runat="server" Width="100%" MaxLength="2000" Height="78px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css"
                                                                    OnClick="Button2_Click" />
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
