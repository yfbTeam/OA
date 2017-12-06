﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HetongCX_show.aspx.cs" Inherits="xyoa.HumanResources.Fenxi.Hetong.HetongCX_show" %>
<html>

<script>
function chknull()
{
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
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>查询信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        签约合同：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="83%">
                                                        <asp:DropDownList ID="LeibieID" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        合同状态：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="83%">
                                                        <asp:DropDownList ID="Zhuangtai" runat="server" Width="100%">
                                                            <asp:ListItem Value="0">全部状态</asp:ListItem>
                                                            <asp:ListItem Value="1">正常状态</asp:ListItem>
                                                            <asp:ListItem Value="2">到期终止</asp:ListItem>
                                                            <asp:ListItem Value="3">强行终止</asp:ListItem>
                                                            <asp:ListItem Value="4">合同解除</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        签约人：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="QyRealname" runat="server" Width="90%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        到期日期：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:DropDownList ID="DQtime" runat="server" Width="100%">
                                                            <asp:ListItem></asp:ListItem>
                                                            <asp:ListItem Value="3">3天内到期</asp:ListItem>
                                                            <asp:ListItem Value="7">7天内到期</asp:ListItem>
                                                            <asp:ListItem Value="30">30天内到期</asp:ListItem>
                                                            <asp:ListItem Value="90">90天内到期</asp:ListItem>
                                                            <asp:ListItem Value="180">180天内到期</asp:ListItem>
                                                            <asp:ListItem Value="0">今天到期</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        签定日期：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="Starttime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                       至<asp:TextBox ID="Endtime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                       
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="Panel1" runat="server">
                                                    <tr>
                                                        <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                            <b>是否启用合同明细数据条件</b><asp:CheckBox ID="CheckBox1" runat="server" onclick="aaa()" /></td>
                                                    </tr>
                                                    <tr id="nextrs1" style="display: none">
                                                        <td class="newtd2" colspan="4">
                                                            <div align="center">
                                                                <font color="red">此查询条件为单一查询条件,即满足A项,或者满足B项的数据都可以显示出来,提高效率.</font></div>
                                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td class="newtd2" width="33%" style="height: 17px" colspan="4" align="center">
                                                        <asp:Button ID="Button1" runat="server" Text="开始查询" CssClass="button_css" OnClick="Button1_Click" />
                                                    </td>
                                                </tr>
                                            </table>
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
        <asp:TextBox ID="QyUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	
            var  wName_3;  
            function  openuser()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('QyUsername').value+"|"+document.getElementById('QyRealname').value+"";
                wName_3=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("QyUsername").value=arr[0]; 
                    document.getElementById("QyRealname").value=arr[1]; 
                }
            }


function aaa()
{   
    if(document.getElementById('CheckBox1').checked)
    {
       document.getElementById('nextrs1').style.display="";
    }
    else
    {
       document.getElementById('nextrs1').style.display="none";
    }
}

        </script>

    </form>
</body>
</html>