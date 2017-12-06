<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="right.ascx.cs" Inherits="xyoa.InfoManage.zhiao.right" %>
<table width="100%" height="33" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td background="../../oaimg/zst/a1.jpg">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="10%">&nbsp;
                                                                                            </td>
                                                                                        <td width="60%">
                                                                                            <a href="MyPage.aspx"><font color="#393939" style="font-size: 13px;"><b>用户信息 </b></font></a>
                                                                                        </td>
                                                                                        <td width="30%">
                                                                                             <a href="MyPage.aspx">我的主页</a></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="126" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td valign="top" background="../../oaimg/zst/a2.jpg">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                            </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="5">
                                                                                    <tr>
                                                                                        <td width="2%">&nbsp;
                                                                                            </td>
                                                                                        <td width="89%">
                                                                                            您好，<%=Session["realname"] %></td>
                                                                                        <td width="9%">&nbsp;
                                                                                            </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                            </td>
                                                                                        <td>
                                                                                            级别：<%=ViewState["dengji"] %></td>
                                                                                        <td>&nbsp;
                                                                                            </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                            </td>
                                                                                        <td>
                                                                                            知识堂积分：<%=ViewState["jifen"] %></td>
                                                                                        <td>&nbsp;
                                                                                            </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table width="100%" height="4" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table width="175" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
                                                                                    bgcolor="#F2EBB7">
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table width="100%" height="10" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table width="184" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td align="center">
                                                                                            <a href="MyPage.aspx?url=2">我的问题</a> <a href="MyPage.aspx?url=3">我的回答</a> <a href="MyPage.aspx?url=4">管理资料</a>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="55" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td valign="top" background="../../oaimg/zst/a3.jpg">
                                                                                <table width="100%" height="32" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>&nbsp;
                                                                                            </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="15%">&nbsp;
                                                                                            </td>
                                                                                        <td width="68%">
                                                                                            <a href="MyPage.aspx?url=1"><font color="#393939" style="font-size: 13px;"><b>积分排行 </b></font></a>
                                                                                        </td>
                                                                                        <td width="17%">&nbsp;
                                                                                            </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="530" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td valign="top" background="../../oaimg/zst/a4.jpg">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="5%" height="30">
                                                                                        </td>
                                                                                        <td width="90%" background="../../oaimg/zst/dd.jpg">
                                                                                            <asp:Label ID="paihang" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td width="5%">&nbsp;
                                                                                            </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="19" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td background="../../oaimg/zst/a5.jpg">&nbsp;
                                                                                </td>
                                                                        </tr>
                                                                    </table>