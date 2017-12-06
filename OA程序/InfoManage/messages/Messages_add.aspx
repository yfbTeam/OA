﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Messages_add.aspx.cs" Inherits="xyoa.InfoManage.messages.Messages_add" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Content').value=='')
    {
        alert('短信不能为空');
        form1.Content.focus();
        return false;
    }	
    
    if(document.getElementById('acceptrealname').value=='')
    {
        alert('接收人不能为空');
        form1.acceptrealname.focus();
        return false;
    }	
    showwait();	
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
                         <table width="100%" height="5" border="0" cellpadding="0" cellspacing="0" id="printshow1">
                        <tr>
                            <td>
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
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">发送消息</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            &nbsp;</td>
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
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>信息内容：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Content" runat="server" Width="95%" Height="65px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        <font color="red">※</font>接收人：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="acceptrealname" runat="server" Width="92%" Height="86px" TextMode="MultiLine" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                               <input id="Button2" class="button_css" onclick="history.back()" type="button" value="返 回" /></font></div>
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
        <asp:TextBox ID="acceptusername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	

        try{
            parent.closeAlert('UploadChoose');
        }
        catch(err){
        }


        var  wName_1;  
        function  openuser1()  
        {  
            var num=Math.random();
            var str=""+document.getElementById('acceptusername').value+"";
            wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:780px;DialogHeight=620px;status:no;scroll=no;help:no");
            if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
            for(var i=0;i<arr.length;i++)
            { 
                document.getElementById("acceptusername").value=arr[0]; 
                document.getElementById("acceptrealname").value=arr[1]; 
            }
        }
        </script>

    </form>
</body>
</html>
