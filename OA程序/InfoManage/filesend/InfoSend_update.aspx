﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="InfoSend_update.aspx.cs"
    Inherits="xyoa.InfoManage.filesend.InfoSend_update" %>

<html>

<script>
function chknull()
{

    if(document.getElementById('JsRealname').value=='')
    {
        alert('接收人不能为空');
        form1.JsRealname.focus();
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
<body class="newbody" onload="a1();">
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
                                                            <a href="InfoSend.aspx">传阅文件</a>
                                                            >> 修改传阅文件</td>
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
                                                                <font class="shadow_but">传阅文件</font></button></td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        文件名称：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:Label ID="Name" runat="server"></asp:Label><asp:CheckBox ID="CheckBox1" runat="server"
                                                            Text="重新上传红头文件" onclick="a1()" />
                                                    </td>
                                                </tr>
                                                <tr id="nextrs1">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        上传文件：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <input id="uploadFile" runat="server" style="width: 501px" type="file" name="uploadFile" />
                                                    </td>
                                                </tr>
                                                <tr id="trUser">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        选择接收人：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="JsRealname" runat="server" Width="85%" Height="58px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="返 回" OnClick="Button2_Click" /></font></div>
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
        <asp:TextBox ID="JsUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	

            var  wName_1;  
            function  openuser1()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('JsUsername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("JsUsername").value=arr[0]; 
                    document.getElementById("JsRealname").value=arr[1]; 
                }
            }
            
            function a1()
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
