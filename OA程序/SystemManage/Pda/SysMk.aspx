﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SysMk.aspx.cs" Inherits="xyoa.SystemManage.Pda.SysMk" %>

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

</head>
<body class="newbody" onload="a1();a2();a3();">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
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
                                                            手机平台模块</td>
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
                                                                <font class="shadow_but">手机平台</font></button></td>
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
                                                    <td class="newtd2" height="17">
                                                        <asp:CheckBox ID="OA" runat="server" Text="OA栏目"  onclick="a1()" Font-Bold="True" />
                                                    </td>
                                                </tr>
                                                <tr id="nextrs1" style="display: none">
                                                    <td class="newtd2" height="17">
                                                        <asp:CheckBoxList ID="OALm" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr id="nextrs3" style="display: none">
                                                    <td class="newtd2" height="17">
                                                        <asp:CheckBoxList ID="PMLm" runat="server" RepeatColumns="5" RepeatDirection="Horizontal">
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
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

        <script type="text/javascript">
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
            
            function a1()
            {   
                if(document.getElementById('OA').checked)
                {
                   document.getElementById('nextrs1').style.display="";
                }
                else
                {
                   document.getElementById('nextrs1').style.display="none";
                }
            }
            
            function a2()
            {   
                if(document.getElementById('CRM').checked)
                {
                   document.getElementById('nextrs2').style.display="";
                }
                else
                {
                   document.getElementById('nextrs2').style.display="none";
                }
            }
            
            function a3()
            {   
                if(document.getElementById('PM').checked)
                {
                   document.getElementById('nextrs3').style.display="";
                }
                else
                {
                   document.getElementById('nextrs3').style.display="none";
                }
            }
        </script>

    </form>
</body>
</html>
