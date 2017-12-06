<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Tongji.aspx.cs" Inherits="xyoa.SchTable.Xueji.Tongji.Tongji" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script language="javascript">
    function visible_click()
    {
   
        if(document.getElementById('td1').style.display=="")
        {
            document.getElementById('td1').style.display="none";
        }
        else
        {
            document.getElementById('td1').style.display="";
        }
    }           

    </script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="35">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="17">
                                &nbsp;
                            </td>
                            <td valign="top">
                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%">
                                            <img src="/oaimg/top_3.gif"></td>
                                        <td width="81%" valign="bottom">
                                            学生统计</td>
                                        <td width="16%">
                                            &nbsp;
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
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="35">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="17">
                                &nbsp;
                            </td>
                            <td valign="top">
                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                    cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="height: 26px;">
                                            <button class="btn4off" type="button" runat="server" id="Button1">
                                                <font class="shadow_but">学生统计</font></button>
                                            <a href="javascript:void(0)" onclick="visible_click()">
                                                <img src="/oaimg/menu/yc.gif" border="0" /></a>
                                        </td>
                                        <td style="height: 26px" align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="17">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="4" cellspacing="0" width="100%" height="<%=ViewState["tableheigh"] %>">
            <tr>
                <td width="5">
                    &nbsp;
                </td>
                <td class="newtd2" width="200px" height="100%" valign="top" id="td1">
                    <table width="200" height="25px" border="0" cellpadding="0" cellspacing="1" class="maincss">
                        <tr>
                            <td height="25px" align="center" valign="top" bgcolor="#FFFFFF" colspan="2">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="25" class="mainbody1" height="25" align="center">
                                            <img src="/oaimg/menu/Menu4.gif" /></td>
                                        <td width="175" class="mainbody1" height="25">
                                            <strong><font color="#0F62A4">选择统计条件</font></strong></td>
                                        <td width="45" class="mainbody1" height="25" align="center">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="200" border="0" cellpadding="4" cellspacing="1" class="maincss">
                        <tr>
                            <td width="44" height="100%" align="center" valign="top" bgcolor="#FFFFFF">
                                学期
                            </td>
                            <td width="137" height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Xueqi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Xueqi_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="44" height="100%" align="center" valign="top" bgcolor="#FFFFFF">
                                学期段
                            </td>
                            <td width="137" height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Xueduan" runat="server">
                                    <asp:ListItem>上学期</asp:ListItem>
                                    <asp:ListItem>下学期</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="44" height="100%" align="center" valign="top" bgcolor="#FFFFFF">
                                年级
                            </td>
                            <td width="137" height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Nianji" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" valign="top" bgcolor="#FFFFFF" colspan="2">
                                <strong><font color="#0F62A4">统计类型</font></strong>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" valign="top" bgcolor="#FFFFFF" colspan="2">
                                <asp:RadioButtonList ID="Leixing" runat="server">
                                    <asp:ListItem Selected="True" Value="1">学籍状态</asp:ListItem>
                                    <asp:ListItem Value="2">户口类型(在校)</asp:ListItem>
                                    <asp:ListItem Value="3">男女性别(在校)</asp:ListItem>
                                   <%-- <asp:ListItem Value="4">生源类别(在校)</asp:ListItem>--%>
                                    <asp:ListItem Value="5">三残(在校)</asp:ListItem>
                                    <asp:ListItem Value="6">户口性质(在校)</asp:ListItem>
                                    <asp:ListItem Value="7">民族类型(在校)</asp:ListItem>
                                    <asp:ListItem Value="8">政治面貌(在校)</asp:ListItem>
                                    <asp:ListItem Value="9">职务(在校)</asp:ListItem>
                                    <asp:ListItem Value="10">健康状况(在校)</asp:ListItem>
                                    <asp:ListItem Value="11">其他(在校)</asp:ListItem>
                                    <asp:ListItem Value="12">户口类型(离校)</asp:ListItem>
                                    <asp:ListItem Value="13">男女性别(离校)</asp:ListItem>
                                   <%-- <asp:ListItem Value="14">生源类别(离校)</asp:ListItem>--%>
                                    <asp:ListItem Value="15">三残(离校)</asp:ListItem>
                                    <asp:ListItem Value="16">户口性质(离校)</asp:ListItem>
                                    <asp:ListItem Value="17">民族类型(离校)</asp:ListItem>
                                    <asp:ListItem Value="18">政治面貌(离校)</asp:ListItem>
                                    <asp:ListItem Value="19">职务(离校)</asp:ListItem>
                                    <asp:ListItem Value="20">健康状况(离校)</asp:ListItem>
                                    <asp:ListItem Value="21">其他(离校)</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" colspan="2" align="center" valign="top" bgcolor="#FFFFFF">
                                <asp:Button ID="Button4" runat="server" Text="统 计" OnClick="Button4_Click" />
                                &nbsp;<asp:Button ID="Button5" runat="server" Text="导 出" OnClick="Button5_Click" /></td>
                        </tr>
                    </table>
                </td>
                <td class="newtd2" valign="top" height="100%" id="td2">
                    <asp:Panel ID="Panel1" runat="server">
                        <div align="center">
                            <asp:Label ID="Label1" runat="server" Text="请先选择统计条件" Font-Bold="True" ForeColor="Red"></asp:Label><br>
                            1、在校学生数=软件内学籍状态为“在校”的学生数。<br>
                            2、离校学生数=软件内学籍状态不为“在校”的学生数。
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <asp:Label ID="LTongji" runat="server"></asp:Label>
                    </asp:Panel>
                </td>
                <td width="5">
                    &nbsp;
                </td>
            </tr>
        </table>
        <input id="Hidden1" type="hidden" />
        <input id="SortText" type="hidden" runat="server" value="order by A.Banji asc" />

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
