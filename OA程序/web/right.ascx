<%@ Control Language="C#" AutoEventWireup="true" Codebehind="right.ascx.cs" Inherits="xyoa.web.right" %>
<style type="text/css">
<!--
.STYLE1 {font-weight: bold}
-->
</style>
<table width="99%" height="276" border="0" cellpadding="0" cellspacing="0" bgcolor="0">
    <tr>
        <td align="center" valign="top" bgcolor="#FFFFFF">
            <table width="100%" height="33" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td align="center" background="img/lhead_<%=ViewState["RightPic"] %>.jpg">
                        <span class="STYLE1">
                            <%=ViewState["str"] %>
                        </span>
                    </td>
                </tr>
            </table>
            <table width="218" border="0" cellspacing="0" cellpadding="4">
                <tr>
                    <td width="17%" align="center" background="img/diandian.jpg">
                        <img src="img/ndian_<%=ViewState["RightPic"] %>.jpg" width="15" height="14"></td>
                    <td width="83%" height="36" background="img/diandian.jpg">
                        <a href="/web/Xinwen.aspx">单位新闻</a></td>
                </tr>
                <%=ViewState["LeftUrl"] %>
                <tr>
                    <td align="center" background="img/diandian.jpg">
                        <img src="img/ndian_<%=ViewState["RightPic"] %>.jpg" width="15" height="14"></td>
                    <td height="36" background="img/diandian.jpg">
                        <a href="/web/Zhuangti.aspx?Leibie=0">专题报道</a></td>
                </tr>
                <%=ViewState["ZtUrl"] %>
                <tr>
                    <td align="center" background="img/diandian.jpg">
                        <img src="img/ndian_<%=ViewState["RightPic"] %>.jpg" width="15" height="14"></td>
                    <td height="36" background="img/diandian.jpg">
                        <a href="/web/Yuandi.aspx?Leibie=0">学习原地</a></td>
                </tr>
                <%=ViewState["XxUrl"] %>
            </table>
        </td>
    </tr>
</table>
