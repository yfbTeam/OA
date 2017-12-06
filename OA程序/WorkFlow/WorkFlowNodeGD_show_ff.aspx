<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowNodeGD_show_ff.aspx.cs"
    Inherits="xyoa.WorkFlow.WorkFlowNodeGD_show_ff" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('FfRealname').value=='')
    {
        alert('传阅用户不能为空');
        form1.FfRealname.focus();
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

</head>
<body class="newbody">
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
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            文件传阅</td>
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        工作名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Label ID="Name" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>传阅用户：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="YjRealname" runat="server" Width="100%" Height="58px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <input id="Button2" type="button" value="选择用户" onclick="openuser3()" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" nowrap="nowrap">
                                                        <asp:CheckBoxList ID="YoujianXm" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1" Selected="True">办理表单</asp:ListItem>
                                                            <asp:ListItem Value="2" Selected="True">公共附件</asp:ListItem>
                                                            <asp:ListItem Value="3" Selected="True">办理过程</asp:ListItem>
                                                            <asp:ListItem Value="5" Selected="True">办理意见</asp:ListItem>
                                                            <asp:ListItem Value="4" Selected="True">办理日志</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" nowrap="nowrap">
                                                        提醒接收人：
                                                        <img src="/oaimg/menu/chatroom.gif" />
                                                        <asp:CheckBox ID="C1" runat="server" Text="内部消息" Checked="True" />
                                                        <img src="/oaimg/menu/Menu30.gif" id="IMG1" runat="server" />
                                                        <asp:CheckBox ID="C2" runat="server" Text="手机短信" />
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <asp:Button ID="Button5" runat="server" Text="传 阅" CssClass="button_css" OnClick="Button1_Click1" />
                                                            <input id="Button1" type="button" value="返 回" onclick="history.go(-1)" class="button_css" />
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
        <asp:TextBox ID="YjUsername" runat="server" Style="display: none"></asp:TextBox>
        <asp:Label ID="fujian" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="guocheng" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="rizhi" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="yijian" runat="server" Visible="false"></asp:Label>
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	
          
            function  openuser3()  
            {    var  wName_3;  
                var num=Math.random();
                var str=""+document.getElementById('YjUsername').value+"";
                wName_3=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("YjUsername").value=arr[0]; 
                    document.getElementById("YjRealname").value=arr[1]; 
                }
            }
            
        </script>

    </form>
</body>
</html>
