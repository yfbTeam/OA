<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Yuandi.aspx.cs" Inherits="xyoa.web.Yuandi" %>

<%@ Register Src="head.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="tail.ascx" TagName="tail" TagPrefix="uc2" %>
<%@ Register Src="right.ascx" TagName="right" TagPrefix="uc3" %>
<html>
<head id="Head1" runat="server">
    <title>
        <%=ViewState["Biaoti"] %>
    </title>
    <link href="img/css.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <table width="960" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top" style="height: 681px">
                    <uc1:head ID="Head2" runat="server" />
                    <table width="960" height="9" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="960" height="420" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top">
                                <table width="960" height="650" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="253" align="right" valign="top" bgcolor="#F8F8F8">
                                            <uc3:right ID="Right1" runat="server"></uc3:right>
                                        </td>
                                        <td width="707" valign="top">
                                            <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="1" bgcolor="#E0E0E0">
                                                <tr>
                                                    <td height="32" valign="middle" background="img/nhead_1.jpg" bgcolor="#FFFFFF">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="4%" align="center">
                                                                    <img src="img/nahead_<%=ViewState["RightPic"] %>.jpg" width="19" height="32"></td>
                                                                <td width="96%">
                                                                    当前位置：<a href="/">首页</a>&nbsp;&nbsp;&gt;&gt;&nbsp;&nbsp;<%=ViewState["LeftName"] %></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" bgcolor="#FFFFFF">
                                                        <table width="707" height="32" border="0" cellpadding="4" cellspacing="0" align="center">
                                                            <tr>
                                                                <td>
                                                                    文件名：<asp:TextBox ID="Titles" runat="server"></asp:TextBox>
                                                                    <asp:Button ID="Button1" runat="server" Text="查 询" OnClick="Button1_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="100%" height="1" border="0" cellpadding="0" cellspacing="0" bgcolor="#E0E0E0">
                                                            <tr>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="707" height="32" border="0" cellpadding="4" cellspacing="0" align="center">
                                                            <tr>
                                                                <td align="center">
                                                                    <%=listall %>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="707" height="5" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="center">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="707" height="15" border="0" cellpadding="5" cellspacing="0">
                                                            <tr>
                                                                <td align="center">
                                                                    每页16条&nbsp;&nbsp;&nbsp;&nbsp;共<%=totalRows%>条&nbsp;&nbsp;&nbsp;&nbsp;共<%=totalPage%>页&nbsp;&nbsp;&nbsp;&nbsp;<a
                                                                        href="Yuandi.aspx?page=1&Leibie=<%=Request.QueryString["Leibie"]%>">首页</a>&nbsp;&nbsp;&nbsp;&nbsp;<a
                                                                            href="Yuandi.aspx?page=<%=pre%>&Leibie=<%=Request.QueryString["Leibie"]%>">上一页</a>&nbsp;&nbsp;&nbsp;&nbsp;<a
                                                                                href="Yuandi.aspx?page=<%=next%>&Leibie=<%=Request.QueryString["Leibie"]%>">下一页</a>&nbsp;&nbsp;&nbsp;&nbsp;<a
                                                                                    href="Yuandi.aspx?page=<%=totalPage%>&Leibie=<%=Request.QueryString["Leibie"]%>">末页</a></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <uc2:tail ID="Tail1" runat="server" />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
