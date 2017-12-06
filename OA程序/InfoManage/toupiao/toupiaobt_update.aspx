<%@ Page Language="C#" AutoEventWireup="true" Codebehind="toupiaobt_update.aspx.cs"
    Inherits="xyoa.InfoManage.toupiao.toupiaobt_update" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('title').value=='')
    {
    alert('投票标题不能为空');
    form1.title.focus();
    return false;
    }	
    
    showwait();	
}  

function  setall1()  
{
    document.getElementById('Gkusername').value='0';
    document.getElementById('Gkrealname').value='全部人员';
}


</script>

<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

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
                                                            <a href="toupiaobt.aspx">投票管理</a>
                                                            >> 修改投票</td>
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
                                                                <font class="shadow_but">投票管理</font></button></td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>投票主题：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="83%">
                                                        <asp:TextBox ID="title" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        投票描述：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="83%">
                                                        <asp:TextBox ID="contents" runat="server" Width="100%" Height="90px" TextMode="MultiLine" MaxLength="4000"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>选择类型：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:RadioButtonList ID="xuanze" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1">单选</asp:ListItem>
                                                            <asp:ListItem Value="2">多选</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>匿名投票：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:RadioButtonList ID="ifopen" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1">允许</asp:ListItem>
                                                            <asp:ListItem Value="2">不允许</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        允许投票人员：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Gkrealname" runat="server" Width="100%" MaxLength="2000" Height="71px"
                                                            TextMode="MultiLine" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <input id="Button3" type="button" value="选择人员" onclick="openuser1()" /><input id="Button4"
                                                            type="button" value="全部人员" onclick="setall1()" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        投票状态：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:RadioButtonList ID="type" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1">进行中</asp:ListItem>
                                                            <asp:ListItem Value="2">已结束</asp:ListItem>
                                                            <asp:ListItem Value="3">隐藏投票</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <img src="/oaimg/menu/chatroom.gif" />
                                                        <asp:CheckBox ID="C1" runat="server" Text="发送内部消息提醒参与人投票" />
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button5" runat="server" Text="提 交" CssClass="button_css" OnClick="Button5_Click" />
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
        <asp:TextBox ID="Gkusername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	

            var  wName_1;  
            function  openuser1()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('Gkusername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("Gkusername").value=arr[0]; 
                    document.getElementById("Gkrealname").value=arr[1]; 
                }
            }




        </script>

    </form>
</body>
</html>
