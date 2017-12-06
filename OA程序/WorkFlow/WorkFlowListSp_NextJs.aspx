<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowListSp_NextJs.aspx.cs"
    Inherits="xyoa.WorkFlow.WorkFlowListSp_NextJs" %>

<html>

<script>
function chknull()
{

if (!confirm("是否确定要结束＂<%=ViewState["Name"]%>＂\n<%=ViewState["ZjBLrealname"]%>"))
return false;


    if(document.form1.txtSmsContent.value=="" && (document.form1.C3.checked || document.form1.C4.checked))
    {
	    alert("短信内容不能为空！");
	    form1.txtSmsContent.focus();
	    return false;
    }
    
    
    showwait();	
}  


function senduser(str)
{
    window.open("/senduser.aspx?user="+str+"","_blank","height=500, width=600,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=200,left=350");
}
			
</script>

<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
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
                                                            待办工作 >> 结束此流程(固定流程)</td>
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td class="newtd1" colspan="4">
                                                        <b>流水号：<%=ViewState["Sequence"]%>
                                                            -
                                                            <%=ViewState["Name"]%>
                                                        </b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" nowrap="nowrap">
                                                        <asp:Label ID="Liucheng" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd1" colspan="4" nowrap="nowrap">
                                                        <img src="../oaimg/menu/workflow_query.gif" />
                                                        <strong>选择下一步骤</strong>&nbsp;&nbsp; &nbsp;<a href='javascript:void(0)' onclick='window.open ("WorkFlowList_bl_lc.aspx?Number=<%=Request.QueryString["Number"]%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'>
                                                            查看流程图</a>&nbsp;&nbsp; <a href='javascript:void(0)' onclick='window.open ("AddWorkFlow_show_lc.aspx?FlowNumber=<%=ViewState["FlowNumber"]%>&NodeName=<%=ViewState["NodeName"]%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'>
                                                                查看流程设计图</a></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" nowrap="nowrap">
                                                        <asp:RadioButtonList ID="FormName" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True"><img src="/oaimg/menu/arrow_down.gif" border=0/>结束流程</asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                       <asp:Panel ID="Panel1" runat="server">
                                                    <tr>
                                                        <td class="newtd1" colspan="4" nowrap="nowrap">
                                                            <img src="../oaimg/menu/flow_close.gif" />
                                                            <strong>将当前步骤办理的内容通过内部邮件发送</strong></td>
                                                    </tr>
                                                    <tr>
                                                        <td class="newtd2" colspan="4" nowrap="nowrap">
                                                            <asp:TextBox ID="YjRealname" runat="server" Width="600px" CssClass="ReadOnlyText"
                                                                Height="64px" TextMode="MultiLine"></asp:TextBox>
                                                            <a href="javascript:void(0)">
                                                                <img onclick="openyjuser();" runat="server" src="/oaimg/FDJ.gif" border="0" id="opency"></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="newtd2" colspan="4" nowrap="nowrap">
                                                            <asp:CheckBoxList ID="YoujianXm" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Value="1" Selected="True">办理表单</asp:ListItem>
                                                                <asp:ListItem Value="2" Selected="True">公共附件</asp:ListItem>
                                                                <asp:ListItem Value="3" Selected="True">办理过程</asp:ListItem>
                                                                <asp:ListItem Value="4" Selected="True">办理日志</asp:ListItem>
                                                                <asp:ListItem Value="5" Selected="True">办理意见</asp:ListItem>
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td class="newtd1" colspan="4" nowrap="nowrap">
                                                        <img src="../oaimg/menu/workflow_query.gif" />
                                                        <strong>短信提醒</strong></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" nowrap="nowrap">
                                                        提醒本流程的发起人：
                                                        <img src="/oaimg/menu/chatroom.gif" />
                                                        <asp:CheckBox ID="C3" runat="server" Text="内部消息" Checked="True" />
                                                        <img src="/oaimg/menu/Menu30.gif" id="IMG2" runat="server" />
                                                        <asp:CheckBox ID="C4" runat="server" Text="手机短信" />
                                                        <br>
                                                        提醒本步骤所有人员：
                                                        <img src="/oaimg/menu/chatroom.gif" />
                                                        <asp:CheckBox ID="C5" runat="server" Text="内部消息" />
                                                        <img src="/oaimg/menu/Menu30.gif" id="IMG3" runat="server" />
                                                        <asp:CheckBox ID="C6" runat="server" Text="手机短信" />
                                                        <br>
                                                        短信内容：
                                                        <asp:TextBox ID="txtSmsContent" runat="server" Width="461px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <asp:Button ID="Button1" runat="server" Text="确定结束" CssClass="button_css" OnClick="Button1_Click" />
                                                            <asp:Button ID="Button2" runat="server" Text="返回重新办理" CssClass="button_css" OnClick="Button2_Click" />
                                                            <input id="Button5" type="button" value="暂不结束并返回" onclick="window.location.href='WorkFlowList.aspx'" class="button_css" />
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
        <asp:TextBox ID="GlNum1" runat="server"  Style="display: none"></asp:TextBox>
              <asp:Label ID="fujian" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="guocheng" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="rizhi" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="yijian" runat="server" Visible="false"></asp:Label>
 <asp:TextBox ID="YjUsername" runat="server" Style="display: none"></asp:TextBox>
 <script>
             function  openyjuser()  
            {
                var  wName_1; 
                var num=Math.random();
                var str=""+document.getElementById('YjUsername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
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
