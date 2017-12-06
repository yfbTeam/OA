﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="HetongCx.aspx.cs" Inherits="xyoa.PublicWork.Hetong.HetongCx" %>

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
function check_form()
{
    showwait();	
}
    </script>

</head>
<body class="newbody" onload="select_yy();select_type();">
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
                                                            合同查询统计
                                                        </td>
                                                        <td width="16%">
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
                                        <td width="17" style="height: 40px">
                                            </td>
                                        <td valign="top" style="height: 40px">
                                            <div id="printshow2">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="height: 26px;">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">合同查询统计</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td width="17" style="height: 40px">
                                            </td>
                                    </tr>
                                </table>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <div>
                                                <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                    <tr>
                                                        <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                            <b>查询信息</b></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            查询范围：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:DropDownList ID="fangwei" runat="server" Width="100%" onchange="select_yy()">
                                                                <asp:ListItem Value="0">全部范围</asp:ListItem>
                                                                <asp:ListItem Value="1">自有合同</asp:ListItem>
                                                                <asp:ListItem Value="2">监控合同</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="tryyr">
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            合同拥有人：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:TextBox ID="Realname" runat="server" Width="90%" CssClass="ReadOnlyText" Height="61px"
                                                                TextMode="MultiLine"></asp:TextBox>
                                                            <a href="javascript:void(0)">
                                                                <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            合同主题：</td>
                                                        <td class="newtd2" height="17" width="83%" colspan="3">
                                                            <asp:TextBox ID="Zhuti" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            合同号：</td>
                                                        <td class="newtd2" height="17" width="83%" colspan="3">
                                                            <asp:TextBox ID="Hetonghao" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            合同状态：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:DropDownList ID="Zhuangtai" runat="server" Width="100%">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem Value="1">执行中</asp:ListItem>
                                                                <asp:ListItem Value="2">结束</asp:ListItem>
                                                                <asp:ListItem Value="3">意外终止</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            合同类别：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:DropDownList ID="Fenlei" runat="server" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            合同金额(元)：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:TextBox ID="Jine1" runat="server"></asp:TextBox>至
                                                            <asp:TextBox ID="Jine2" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            对方单位：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:TextBox ID="Danwei" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            流程状态：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:DropDownList ID="LcZhuangtai" runat="server" Width="100%">
                                                                <asp:ListItem></asp:ListItem>
                                                                <asp:ListItem Value="1">等待办理</asp:ListItem>
                                                                <asp:ListItem Value="2">正在办理</asp:ListItem>
                                                                <asp:ListItem Value="3">通过审批</asp:ListItem>
                                                                <asp:ListItem Value="4">终止审批</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            签约时间：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:TextBox ID="Starttime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                            至<asp:TextBox ID="Endtime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            有无合同期限：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:DropDownList ID="Qixian" runat="server" Width="100%" onchange="select_type()">
                                                                <asp:ListItem Value="0">全部</asp:ListItem>
                                                                <asp:ListItem Value="1">有</asp:ListItem>
                                                                <asp:ListItem Value="2">无</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr id="trshijian">
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            到期时间：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:TextBox ID="DaoqiS" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                          至<asp:TextBox ID="DaoqiE" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="newtd2" width="33%" style="height: 17px" colspan="4" align="center">
                                                            <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="查询结果" OnClick="Button2_Click" /></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            &nbsp;
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
        <asp:TextBox ID="Username" runat="server" Style="display: none"></asp:TextBox>

        <script>
function select_type()
{
   if (form1.Qixian.value=="1")
   {
       trshijian.style.display='';
   }
   else
   {
       trshijian.style.display='none';
   }
}
function select_yy()
{
   if (form1.fangwei.value=="2")
   {
       tryyr.style.display='';
   }
   else 
   {
       tryyr.style.display='none';
   }
}

        </script>

        <script language="javascript">	
            var  wName_1;  
            function  openuser1()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('Username').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_listht.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("Username").value=arr[0]; 
                    document.getElementById("Realname").value=arr[1]; 
                }
            }
            
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
