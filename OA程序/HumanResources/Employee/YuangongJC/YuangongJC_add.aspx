﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YuangongJC_add.aspx.cs" Inherits="xyoa.HumanResources.Employee.YuangongJC.YuangongJC_add" %>
<html>

<script>
function chknull()
{
    if(document.getElementById('RealnameYG').value=='')
    {
        alert('员工姓名不能为空');
        form1.RealnameYG.focus();
        return false;
    }
    	
    if(document.getElementById('Leibie').value=='')
    {
        alert('<%=ViewState["Jiangcheng"] %>类型不能为空');
        form1.Leixing.focus();
        return false;
    }	

    if(document.getElementById('JiangchengSj').value=='')
    {
        alert('<%=ViewState["Jiangcheng"] %>日期不能为空');
        form1.JiangchengSj.focus();
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
                                                            <a href="YuangongJC.aspx?Jiangcheng=<%=Request.QueryString["Jiangcheng"] %>"><%=ViewState["Jiangcheng"] %>记录</a>
                                                            >> 新增<%=ViewState["Jiangcheng"] %>记录</td>
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
                                                                <font class="shadow_but"><%=ViewState["Jiangcheng"] %>记录</font></button></td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>员工姓名：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="RealnameYG" runat="server" Width="90%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img id="Img1" onclick="openuser();" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font><%=ViewState["Jiangcheng"] %>日期：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="JiangchengSj" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font><%=ViewState["Jiangcheng"] %>类型：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="Leibie" runat="server" Width="100%">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <%=ViewState["Jiangcheng"] %>原因：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:TextBox ID="JianchengYy" runat="server" Width="100%" Height="55px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <%=ViewState["Jiangcheng"] %>内容：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:TextBox ID="Neirong" runat="server" Width="100%" Height="55px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        备注：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:TextBox ID="Beizhu" runat="server" Width="100%" Height="55px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <input id="Button2" type="button" value="返 回" onclick="history.go(-1)" class="button_css" />
                                                            </font>
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
        <asp:TextBox ID="UsernameYG" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	

           var  wName_3;  
            function  openuser()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('UsernameYG').value+"|"+document.getElementById('RealnameYG').value+"";
                wName_3=window.showModalDialog("/OpenWindows/open_Username_two_zz.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("UsernameYG").value=arr[0]; 
                    document.getElementById("RealnameYG").value=arr[1]; 
                }
            }
        </script>

    </form>
</body>
</html>