<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Jiejiari.aspx.cs" Inherits="xyoa.SystemManage.Web.Jiejiari" %>

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
<body class="newbody">
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
                                                            节假日设置</td>
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
                                                            <button class="btn4on" type="button" onclick="javascript:window.location='Jiejiari.aspx';showwait();">
                                                                <font class="shadow_but">节假日图片</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='JiejiariDay.aspx';showwait();">
                                                                <font class="shadow_but">节假日设置</font></button>
                                                        </td>
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
                                                        元旦：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Image ID="Yuandan" runat="server" Height="113px" Width="960px" />宽960像素，高113像素
                                                        <input id="File1" runat="server" style="width: 404px" type="file" name="uploadFile" />
                                                        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="更 新" /></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        春节：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Image ID="Chunjie" runat="server" Height="113px" Width="960px" />宽960像素，高113像素
                                                        <input id="uploadFile" runat="server" style="width: 404px" type="file" name="uploadFile" />
                                                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="更 新" /></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        五一：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Image ID="Wuyi" runat="server" Height="113px" Width="960px" />宽960像素，高113像素
                                                        <input id="File2" runat="server" style="width: 404px" type="file" name="uploadFile" />
                                                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="更 新" /></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        七一：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Image ID="Qiyi" runat="server" Height="113px" Width="960px" />宽960像素，高113像素
                                                        <input id="File3" runat="server" style="width: 404px" type="file" name="uploadFile" />
                                                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="更 新" /></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        十一：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Image ID="Shiyi" runat="server" Height="113px" Width="960px" />宽960像素，高113像素
                                                        <input id="File4" runat="server" style="width: 404px" type="file" name="uploadFile" />
                                                        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="更 新" /></td>
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
         
        </script>

    </form>
</body>
</html>
