<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Shoudong_Pk.aspx.cs" Inherits="xyoa.SchTable.Paike.Shoudong_Pk" %>

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
function chknull()
{
  if(document.getElementById('Jieci').value=='')
    {
    alert('未选中课程');
    return false;
    }	
    
   if(document.getElementById('Kecheng').value=='请选择')
    {
    alert('课程名称不能为空');
    form1.Kecheng.focus();
    return false;
    }	
    
  if(document.getElementById('LsUsername').value=='请选择')
    {
    alert('任课教师不能为空');
    form1.LsUsername.focus();
    return false;
    }
    showwait();	
 
}  

function yichu()
{
   if(document.getElementById('Jieci').value=='')
    {
    alert('未选中课程');
    return false;
    }	
}  


  function ycquanbu()
    {
        if (!confirm("确定移除全部课程吗？"))
        return false;
        showwait();	
    }

  function Daoru()
    {
        if (!confirm("确定导入课程吗？"))
        return false;
        showwait();	
    }
    
    </script>

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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                        </td>
                                        <td valign="top">
                                            <asp:Panel ID="Panel1" runat="server">
                                                <div align="center">
                                                    <asp:Label ID="Label1" runat="server" Text="请先选择班级" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel2" runat="server">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30"
                                                                background="/oaimg/nextline.gif">
                                                                <tr>
                                                                    <td valign="top">
                                                                        学期：<asp:DropDownList ID="Xueqi" runat="server" Enabled="false">
                                                                        </asp:DropDownList>
                                                                        学期段：
                                                                        <asp:DropDownList ID="Xueduan" runat="server" Enabled="false">
                                                                            <asp:ListItem>上学期</asp:ListItem>
                                                                            <asp:ListItem>下学期</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                       
                                                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="CheckBox1_CheckedChanged"
                                                                            Text="显示教师名称" /></td>
                                                                </tr>
                                                            </table>
                                                            <div id="Div1">
                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                    <tr>
                                                                        <td width="560" valign=top>
                                                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server">
                                                                            <table id="showinfo" style="width: 560px; border-collapse: collapse" border="1" bordercolor="black"
                                                                                cellpadding="4" cellspacing="0">
                                                                                <tr align="center">
                                                                                    <td colspan="7">
                                                                                        <font style='font-weight: bold; color: red'>
                                                                                            <%=ViewState["Mingcheng"] %>
                                                                                            课程表</font></td>
                                                                                </tr>
                                                                                <tr align="center">
                                                                                    <td width="80" align="center">
                                                                                        节次\星期</td>
                                                                                    <td width="80" align="center" bgcolor="#cbf1c7">
                                                                                        星期一</td>
                                                                                    <td width="80" align="center" bgcolor="#cbf1c7">
                                                                                        星期二</td>
                                                                                    <td width="80" align="center" bgcolor="#cbf1c7">
                                                                                        星期三</td>
                                                                                    <td width="80" align="center" bgcolor="#cbf1c7">
                                                                                        星期四</td>
                                                                                    <td width="80" align="center" bgcolor="#cbf1c7">
                                                                                        星期五</td>
                                                                                    <td width="80" align="center" bgcolor="#cbf1c7">
                                                                                        星期六</td>
                                                                                </tr>
                                                                                <asp:Panel ID="P1" runat="server">
                                                                                    <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                        <td>
                                                                                            第一节
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng1_1" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng1_1_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername1_1" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername1_1_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng2_1" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng2_1_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername2_1" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername2_1_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng3_1" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng3_1_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername3_1" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername3_1_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng4_1" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng4_1_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername4_1" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername4_1_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng5_1" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng5_1_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername5_1" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername5_1_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng6_1" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng6_1_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername6_1" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername6_1_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="P2" runat="server">
                                                                                    <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                        <td>
                                                                                            第二节
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng1_2" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng1_2_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername1_2" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername1_2_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng2_2" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng2_2_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername2_2" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername2_2_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng3_2" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng3_2_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername3_2" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername3_2_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng4_2" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng4_2_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername4_2" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername4_2_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng5_2" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng5_2_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername5_2" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername5_2_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng6_2" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng6_2_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername6_2" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername6_2_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="P3" runat="server">
                                                                                    <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                        <td>
                                                                                            第三节
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng1_3" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng1_3_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername1_3" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername1_3_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng2_3" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng2_3_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername2_3" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername2_3_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng3_3" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng3_3_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername3_3" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername3_3_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng4_3" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng4_3_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername4_3" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername4_3_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng5_3" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng5_3_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername5_3" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername5_3_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng6_3" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng6_3_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername6_3" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername6_3_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="P4" runat="server">
                                                                                    <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                        <td>
                                                                                            第四节
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng1_4" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng1_4_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername1_4" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername1_4_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng2_4" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng2_4_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername2_4" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername2_4_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng3_4" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng3_4_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername3_4" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername3_4_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng4_4" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng4_4_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername4_4" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername4_4_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng5_4" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng5_4_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername5_4" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername5_4_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng6_4" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng6_4_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername6_4" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername6_4_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <tr align="center" height="5">
                                                                                    <td colspan="7" align="center">
                                                                                        中午休息
                                                                                    </td>
                                                                                </tr>
                                                                                <asp:Panel ID="P5" runat="server">
                                                                                    <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                        <td>
                                                                                            第五节
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng1_5" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng1_5_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername1_5" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername1_5_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng2_5" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng2_5_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername2_5" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername2_5_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng3_5" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng3_5_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername3_5" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername3_5_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng4_5" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng4_5_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername4_5" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername4_5_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng5_5" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng5_5_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername5_5" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername5_5_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng6_5" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng6_5_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername6_5" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername6_5_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="P6" runat="server">
                                                                                    <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                        <td>
                                                                                            第六节
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng1_6" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng1_6_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername1_6" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername1_6_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng2_6" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng2_6_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername2_6" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername2_6_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng3_6" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng3_6_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername3_6" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername3_6_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng4_6" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng4_6_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername4_6" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername4_6_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng5_6" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng5_6_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername5_6" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername5_6_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng6_6" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng6_6_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername6_6" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername6_6_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="P7" runat="server">
                                                                                    <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                        <td>
                                                                                            第七节
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng1_7" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng1_7_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername1_7" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername1_7_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng2_7" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng2_7_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername2_7" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername2_7_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng3_7" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng3_7_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername3_7" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername3_7_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng4_7" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng4_7_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername4_7" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername4_7_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng5_7" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng5_7_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername5_7" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername5_7_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng6_7" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng6_7_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername6_7" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername6_7_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="P8" runat="server">
                                                                                    <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                        <td>
                                                                                            第八节
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng1_8" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng1_8_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername1_8" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername1_8_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng2_8" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng2_8_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername2_8" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername2_8_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng3_8" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng3_8_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername3_8" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername3_8_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng4_8" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng4_8_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername4_8" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername4_8_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng5_8" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng5_8_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername5_8" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername5_8_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng6_8" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng6_8_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername6_8" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername6_8_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="P11" runat="server">
                                                                                    <tr align="center" height="5px">
                                                                                        <td colspan="7" align="center">
                                                                                            下午休息
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="P9" runat="server">
                                                                                    <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                        <td>
                                                                                            第九节
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng1_9" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng1_9_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername1_9" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername1_9_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng2_9" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng2_9_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername2_9" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername2_9_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng3_9" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng3_9_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername3_9" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername3_9_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng4_9" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng4_9_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername4_9" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername4_9_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng5_9" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng5_9_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername5_9" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername5_9_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng6_9" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng6_9_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername6_9" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername6_9_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                                <asp:Panel ID="P10" runat="server">
                                                                                    <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                        <td>
                                                                                            第十节
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng1_10" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng1_10_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername1_10" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername1_10_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng2_10" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng2_10_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername2_10" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername2_10_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng3_10" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng3_10_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername3_10" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername3_10_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng4_10" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng4_10_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername4_10" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername4_10_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng5_10" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng5_10_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername5_10" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername5_10_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="Kecheng6_10" runat="server" CommandArgument='0' ForeColor="Blue"
                                                                                                OnClick="Kecheng6_10_Click" Font-Size="15px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</asp:LinkButton><br>
                                                                                            <asp:LinkButton ID="LsUsername6_10" runat="server" CommandArgument='0' ForeColor="Red"
                                                                                                OnClick="LsUsername6_10_Click"></asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </asp:Panel>
                                                                            </table>
                                                                             </asp:PlaceHolder>
                                                                        </td>
                                                                        <td valign="top" width="20">
                                                                        </td>
                                                                        <td valign="top">
                                                                            <table width="100%" height="30" style="border-collapse: collapse" border="1" bordercolor="black"
                                                                                cellpadding="4" cellspacing="0">
                                                                                <tr>
                                                                                    <td colspan="4" align="center" bgcolor="#cbf1c7">
                                                                                        导入课程表</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="15%" align="right" nowrap="nowrap">
                                                                                        学期</td>
                                                                                    <td width="40%">
                                                                                        <asp:DropDownList ID="DrXueqi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrXueqi_SelectedIndexChanged">
                                                                                        </asp:DropDownList></td>
                                                                                    <td width="15%" align="right" nowrap="nowrap">
                                                                                        学期段</td>
                                                                                    <td width="40%">
                                                                                        <asp:DropDownList ID="DrXueduan" runat="server">
                                                                                            <asp:ListItem>上学期</asp:ListItem>
                                                                                            <asp:ListItem>下学期</asp:ListItem>
                                                                                        </asp:DropDownList></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="15%" align="right" nowrap="nowrap">
                                                                                        年级</td>
                                                                                    <td width="40%">
                                                                                        <asp:DropDownList ID="DrNianji" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DrNianji_SelectedIndexChanged">
                                                                                        </asp:DropDownList></td>
                                                                                    <td width="15%" align="right" nowrap="nowrap">
                                                                                        班级</td>
                                                                                    <td width="40%">
                                                                                        <asp:DropDownList ID="DrBanji" runat="server">
                                                                                        </asp:DropDownList></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="4" align="center" nowrap="nowrap">
                                                                                        <asp:Button ID="Button3" runat="server" Text="导入课程表" OnClick="Button3_Click" />
                                                                                        <asp:Button ID="Button5" runat="server" Text="移除全部课程" OnClick="Button5_Click" />
                                                                                        </td>
                                                                                </tr>
                                                                            </table>
                                                                            <br>
                                                                            <table width="100%" height="30" style="border-collapse: collapse" border="1" bordercolor="black"
                                                                                cellpadding="4" cellspacing="0">
                                                                                <tr>
                                                                                    <td colspan="4" align="center" bgcolor="#cbf1c7">
                                                                                        选择课程</td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="4">
                                                                                        <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                                                        <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Blue"></asp:Label>
                                                                                        </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="15%" align="right" nowrap="nowrap">
                                                                                        课程名称</td>
                                                                                    <td width="40%">
                                                                                        <asp:DropDownList ID="Kecheng" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Kecheng_SelectedIndexChanged">
                                                                                        </asp:DropDownList></td>
                                                                                    <td width="15%" align="right" nowrap="nowrap">
                                                                                        任课教师</td>
                                                                                    <td width="40%">
                                                                                        <asp:DropDownList ID="LsUsername" runat="server" AutoPostBack="True" OnSelectedIndexChanged="LsUsername_SelectedIndexChanged">
                                                                                        </asp:DropDownList></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="4" align="center" nowrap="nowrap">
                                                                                        <asp:Button ID="Button4" runat="server" Text="更新课程表" OnClick="Button4_Click" />
                                                                                         <asp:Button ID="Button1" runat="server" Text="移除所选课程" OnClick="Button1_Click" />
                                                                                      
                                                                                         </td>
                                                                                </tr>
                                                                            </table>
                                                                            <br>
                                                                            <table width="100%" height="30" style="border-collapse: collapse" border="1" bordercolor="black"
                                                                                cellpadding="4" cellspacing="0">
                                                                                <asp:Label ID="Label6" runat="server"></asp:Label>
                                                                                <tr>
                                                                                    <td align="center" bgcolor="#cbf1c7">  
                                                                                        <asp:Label ID="Label2" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="line-height: 190%">
                                                                                        <asp:Label ID="Label4" runat="server"></asp:Label></td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
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
        <asp:TextBox ID="Jieci" runat="server"  Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Xingqi" runat="server"  Style="display: none"></asp:TextBox>

        <script type="text/javascript">
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
