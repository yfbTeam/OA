<%@ Page Language="C#" AutoEventWireup="true" Codebehind="YjBoxMg_show.aspx.cs" Inherits="xyoa.InfoManage.YjBox.YjBoxMg_show" %>

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
       document.getElementById('HfCotent').value +=text;
   }
}

function yjopen()
{
    var num=Math.random();
    window.showModalDialog("YjBoxMg_show_zf.aspx?tmp="+num+"&id=<%=Request.QueryString["id"]%>","window","dialogWidth:760px;DialogHeight=650px;status:no;scroll=yes;help:no");    
}


    </script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0"  id="printshow1">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0"  id="printshow2">
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
                                                            <a href="YjBoxMg.aspx">意见管理</a>
                                                            >> 查看意见</td>
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
                                                                <font class="shadow_but">意见管理</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                             <input id="Button3" type="button" value="打 印" onclick="printnewpage()" class="button_css" />
                                                             <input id="Button4" type="button" value="指派处理人" onclick="yjopen()" class="button_css" />
                                                             </td>
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
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage"  id="tableprint">
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17" align="center">
                                                        意见基本信息
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        意见标题：</td>
                                                    <td class="newtd2" colspan="3" height="17">
                                                        <asp:Label ID="Titles" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        意见箱：</td>
                                                    <td class="newtd2" colspan="3" height="17">
                                                        <asp:Label ID="BoxId" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        详细内容：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="Content" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        填写人：</td>
                                                    <td class="newtd2" colspan="3" height="17">
                                                        <asp:Label ID="TxRealname" runat="server"></asp:Label>
                                                        <asp:Label ID="Username" runat="server" Visible="false"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        填写时间：</td>
                                                    <td class="newtd2" colspan="3" height="17">
                                                        <asp:Label ID="TxTime" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17" align="center">
                                                        回复信息
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        回复人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="HfRealname" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        回复时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="HfTimes" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        常用备注：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:DropDownList ID="normalcontent" runat="server" Width="100%" onchange="_change()">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        回复内容：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:TextBox ID="HfCotent" runat="server" Width="100%" Height="87px" TextMode="MultiLine"></asp:TextBox></td>
                                                </tr>
                                                <tr class="">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        通知填写人：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="33%">
                                                        <img src="/oaimg/menu/chatroom.gif" />
                                                        <asp:CheckBox ID="C1" runat="server" Text="内部消息" Checked="True" />
                                                        <img src="/oaimg/menu/Menu30.gif" id="IMG1" runat="server" />
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Text="手机短信" />
                                                    </td>
                                                </tr>
                                                <tr  id="printshow4">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="回 复" OnClick="Button1_Click" />&nbsp;
                                                            <input id="Button1" class="button_css" onclick="history.back()" type="button" value="返 回" /></div>
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

        <script>
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        
        </script>

    </form>
</body>
</html>
