<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jiaoshi_Pk.aspx.cs" Inherits="xyoa.SchTable.Paike.Jiaoshi_Pk" %>

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

function printKc()
{
document.getElementById("table1") .style.visibility="hidden"
print();
document.getElementById("table1") .style.visibility="visible"
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
                                                    <asp:Label ID="Label1" runat="server" Text="请先选择教师" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="Panel2" runat="server">
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30"
                                                                background="/oaimg/nextline.gif" id="table1">
                                                                <tr>
                                                                    <td valign="top">
                                                                        学期：<asp:DropDownList ID="Xueqi" runat="server" Enabled="false">
                                                                        </asp:DropDownList>
                                                                        学期段：
                                                                        <asp:DropDownList ID="Xueduan" runat="server" Enabled="false">
                                                                            <asp:ListItem>上学期</asp:ListItem>
                                                                            <asp:ListItem>下学期</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:Button ID="Button2" runat="server" Text="导出课程表" CssClass="button_css" OnClick="Button2_Click" />
                                                                        <input id="Button1" type="button" value="打印课程表" onclick="printKc()" class="button_css"/>
                                                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Checked="True" OnCheckedChanged="CheckBox1_CheckedChanged"
                                                                            Text="显示班级名称" /></td>
                                                                </tr>
                                                            </table>
                                                            <div id="Div1">
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
                                                                                    <asp:Label ID="Kecheng1_1" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername1_1" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng2_1" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername2_1" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng3_1" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername3_1" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng4_1" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername4_1" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng5_1" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername5_1" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng6_1" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername6_1" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="P2" runat="server">
                                                                            <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                <td>
                                                                                    第二节
                                                                                </td>
                                                                                 <td>
                                                                                    <asp:Label ID="Kecheng1_2" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername1_2" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng2_2" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername2_2" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng3_2" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername3_2" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng4_2" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername4_2" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng5_2" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername5_2" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng6_2" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername6_2" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="P3" runat="server">
                                                                            <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                <td>
                                                                                    第三节
                                                                                </td>
                                                                                   <td>
                                                                                    <asp:Label ID="Kecheng1_3" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername1_3" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng2_3" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername2_3" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng3_3" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername3_3" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng4_3" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername4_3" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng5_3" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername5_3" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng6_3" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername6_3" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="P4" runat="server">
                                                                            <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                <td>
                                                                                    第四节
                                                                                </td>
                                                                                  <td>
                                                                                    <asp:Label ID="Kecheng1_4" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername1_4" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng2_4" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername2_4" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng3_4" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername3_4" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng4_4" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername4_4" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng5_4" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername5_4" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng6_4" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername6_4" runat="server" ForeColor="Red"></asp:Label>
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
                                                                                    <asp:Label ID="Kecheng1_5" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername1_5" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng2_5" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername2_5" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng3_5" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername3_5" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng4_5" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername4_5" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng5_5" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername5_5" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng6_5" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername6_5" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="P6" runat="server">
                                                                            <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                <td>
                                                                                    第六节
                                                                                </td>
                                                                                 <td>
                                                                                    <asp:Label ID="Kecheng1_6" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername1_6" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng2_6" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername2_6" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng3_6" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername3_6" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng4_6" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername4_6" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng5_6" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername5_6" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng6_6" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername6_6" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="P7" runat="server">
                                                                            <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                <td>
                                                                                    第七节
                                                                                </td>
                                                                                  <td>
                                                                                    <asp:Label ID="Kecheng1_7" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername1_7" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng2_7" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername2_7" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng3_7" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername3_7" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng4_7" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername4_7" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng5_7" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername5_7" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng6_7" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername6_7" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="P8" runat="server">
                                                                            <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                <td>
                                                                                    第八节
                                                                                </td>
                                                                                  <td>
                                                                                    <asp:Label ID="Kecheng1_8" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername1_8" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng2_8" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername2_8" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng3_8" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername3_8" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng4_8" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername4_8" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng5_8" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername5_8" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng6_8" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername6_8" runat="server" ForeColor="Red"></asp:Label>
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
                                                                                    <asp:Label ID="Kecheng1_9" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername1_9" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng2_9" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername2_9" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng3_9" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername3_9" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng4_9" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername4_9" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng5_9" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername5_9" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng6_9" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername6_9" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="P10" runat="server">
                                                                            <tr align="center" height="45px" onclick="if(window.oldtr!=null){window.oldtr.runtimeStyle.cssText='';}this.runtimeStyle.cssText='background-color:#ffff00';window.oldtr=this">
                                                                                <td>
                                                                                    第十节
                                                                                </td>
                                                                                 <td>
                                                                                    <asp:Label ID="Kecheng1_10" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername1_10" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng2_10" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername2_10" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng3_10" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername3_10" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng4_10" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername4_10" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng5_10" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername5_10" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="Kecheng6_10" runat="server" ForeColor="Blue" Font-Size="15px"></asp:Label><br>
                                                                                    <asp:Label ID="LsUsername6_10" runat="server" ForeColor="Red"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </asp:Panel>
                                                                    </table>
                                                                </asp:PlaceHolder>
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
        <asp:TextBox ID="Jieci" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Xingqi" runat="server" Style="display: none"></asp:TextBox>

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
