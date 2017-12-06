<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowName_show_add_node_gl_add.aspx.cs" Inherits="xyoa.SystemManage.WorkFlow.WorkFlowName_show_add_node_gl_add" %>
<html>
<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>
<base target="_self" />
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        步骤序号：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:TextBox ID="NodeNum" runat="server" Width="100%"  CssClass="ReadOnlyText"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        步骤名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="NodeName" runat="server" Width="100%"  CssClass="ReadOnlyText"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        过滤字段：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="center" style="width: 113px" valign="top">
                                                                    <strong>待选字段</strong></td>
                                                                <td align="center" style="width: 42px" valign="top">
                                                                </td>
                                                                <td align="center" style="width: 100px" valign="top">
                                                                    <strong>已选字段</strong></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="width: 113px" valign="top">
                                                                    <asp:ListBox ID="SourceListBox" runat="server" Height="200px" Width="229px" SelectionMode="Multiple"></asp:ListBox></td>
                                                                <td align="center" style="width: 42px" valign="top">
                                                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text=">" Width="58px" /><br />
                                                                    <br />
                                                                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text=">>" Width="58px" />
                                                                    <br />
                                                                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="<" Width="58px" /><br />
                                                                    <br />
                                                                    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="<<" Width="58px" />
                                                                </td>
                                                                <td align="center" style="width: 100px" valign="top">
                                                                    <asp:ListBox ID="TargetListBox" runat="server" Height="200px" Width="229px" SelectionMode="Multiple"></asp:ListBox></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                       <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        可写字段过滤：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="KxGuoLvName" runat="server" Width="92%" Height="64px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        保密字段过滤：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="BmGuoLvName" runat="server" Width="92%" Height="69px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser2();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <input id="Button3" class="button_css" onclick="javascript:window.close()" type="button"
                                                                    value="关 闭" /></font></div>
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
        <asp:TextBox ID="NodeNumber" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="FormId" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FormNumber" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FormName" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="SecFileID" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowNumber" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowName" runat="server" Style="display: none"></asp:TextBox>
        
          <asp:TextBox ID="KxGuoLvUser" runat="server" Width="90%" Style="display: none"></asp:TextBox>
         <asp:TextBox ID="BmGuoLvUser" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	

var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('KxGuoLvUser').value+"";
wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("KxGuoLvUser").value=arr[0]; 
document.getElementById("KxGuoLvName").value=arr[1]; 
}
}



var  wName_2;  
function  openuser2()  
{  
var num=Math.random();
var str=""+document.getElementById('BmGuoLvUser').value+"";
wName_2=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("BmGuoLvUser").value=arr[0]; 
document.getElementById("BmGuoLvName").value=arr[1]; 
}
}
        </script>
    </form>
</body>
</html>