<%@ Page Language="C#" AutoEventWireup="true" Codebehind="face.aspx.cs" Inherits="xyoa.SystemManage.login.face" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Titles').value=='')
    {
        alert('界面抬头标题不能为空');
        form1.Titles.focus();
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
                                                            界面设置</td>
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
                                                                <font class="shadow_but">界面设置</font></button></td>
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
                                                        登陆界面背景：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Image ID="JmBg" runat="server" Height="87px" Width="123px" />任意象素
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="修改" onclick="a1()" /></td>
                                                </tr>
                                                <tr id="nextrs1" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        浏览图片：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                       <input id="uploadFile" runat="server" style="width: 404px" type="file" name="uploadFile" />
                                                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="更 新" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        登陆主界面：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Image ID="JmText" runat="server" Height="95px" Width="122px" />建议象素607*268
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Text="修改" onclick="a2()" /></td>
                                                </tr>
                                                <tr id="nextrs2" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        浏览图片：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                         <input id="File1" runat="server" style="width: 404px" type="file" name="uploadFile" />
                                                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="更 新" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        界面抬头标题：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Titles" runat="server" Width="85%"></asp:TextBox><asp:Button ID="Button1"
                                                            runat="server" Text="更 新"  OnClick="Button1_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        标准样式主界面LOGO：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Image ID="Logos" runat="server" Width="224" Height="60" />建议象素224*60
                                                        <asp:CheckBox ID="CheckBox3" runat="server" Text="修改" onclick="a3()" />
                                                    </td>
                                                </tr>
                                                <tr id="nextrs3" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        浏览图片：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                         <input id="File2" runat="server" style="width: 404px" type="file" name="uploadFile" />
                                                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="更 新" />
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
                if(document.getElementById('CheckBox1').checked)
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
                if(document.getElementById('CheckBox2').checked)
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
                if(document.getElementById('CheckBox3').checked)
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
