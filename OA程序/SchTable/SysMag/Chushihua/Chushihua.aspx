<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Chushihua.aspx.cs" Inherits="xyoa.SchTable.SysMag.Chushihua.Chushihua" %>

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
                                                            当前学期设置</td>
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
                                                                <font class="shadow_but">当前学期</font></button></td>
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
                                                        <font color="red">※</font>当前学期：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="Xueqi" runat="server">
                                                       <asp:ListItem>2013-2014</asp:ListItem>
                                                            <asp:ListItem>2014-2015</asp:ListItem>
                                                            <asp:ListItem>2015-2016</asp:ListItem>
                                                            <asp:ListItem>2016-2017</asp:ListItem>
                                                            <asp:ListItem>2017-2018</asp:ListItem>
                                                            <asp:ListItem>2018-2019</asp:ListItem>
                                                            <asp:ListItem>2019-2020</asp:ListItem>
                                                            <asp:ListItem>2020-2021</asp:ListItem>
                                                            <asp:ListItem>2021-2022</asp:ListItem>
                                                            <asp:ListItem>2022-2023</asp:ListItem>
                                                            <asp:ListItem>2023-2024</asp:ListItem>
                                                            <asp:ListItem>2024-2025</asp:ListItem>
                                                            <asp:ListItem>2025-2026</asp:ListItem>
                                                            <asp:ListItem>2026-2027</asp:ListItem>
                                                            <asp:ListItem>2027-2028</asp:ListItem>
                                                        </asp:DropDownList><asp:TextBox ID="ById" runat="server" Visible=false></asp:TextBox><asp:TextBox ID="YsXueqi" runat="server" Visible=false></asp:TextBox><asp:TextBox ID="YsXueduan" runat="server" Visible=false></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>当前学段：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="Xueduan" runat="server">
                                                            <asp:ListItem>上学期</asp:ListItem>
                                                            <asp:ListItem>下学期</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="Tr2">
                                                    <td class="newtd2" colspan="4" height="26" width="33%">
                                                        <asp:CheckBox ID="CheckBox1" runat="server"  Text="自动升级学生信息" ForeColor="Red"/>
                                                    </td>
                                                </tr>
                                                <tr id="Tr1">
                                                    <td class="newtd2" colspan="4" height="26" width="33%">
                                                        【自动升级】说明：跨学年设置系统当前学期时应特别注意如下<br>
（在同一年度由上学期设置为下学期时，不受下面几点限制）<br>
1.选择自动升级时，前提条件要求各个年级的班级数目及名称相同。如果不存在班级，系统将自动创建升级后的班级。 <br>
2.选择自动升级时，毕业班级将自动把学籍状态为“在校”的学生转换为“毕业”。 <br>
手动升级操作说明：<br>
1.可以在“学籍变更”，“学生日常管理”中对学籍状态和班级进行调整。<br>
2.自动升级以后，如果需要做留级操作，请先把时间段调到上一个年度学期，然后再做留级操作，最后再选择【不启用自动升级】把时间段调到当前年度学期即可。 <br>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
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
        </script>
    </form>
</body>
</html>
