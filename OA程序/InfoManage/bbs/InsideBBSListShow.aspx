<%@ Page Language="C#" AutoEventWireup="true" Codebehind="InsideBBSListShow.aspx.cs"
    Inherits="xyoa.InfoManage.bbs.InsideBBSListShow" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body class="newbody">
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
                                                            <a href="InsideBBS.aspx" class="line_b">
                                                                论坛BBS</a> >> <a href="InsideBBSList.aspx?ID=<%= Request.QueryString["BigId"] %>" class="line_b">
                                                                    <%=ViewState["Name"] %>
                                                                </a>>> 查看帖子
                                                        </td>
                                                        <td width="16%" align="right">
                                                            &nbsp;<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="回 复" />
                                                            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="返 回" /></td>
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <div id="Div1">
                                                            <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
                                                                <tr>
                                                                    <td style="padding-left: 5px; background-color: #EEF7FC; height: 25px;">
                                                                        &nbsp;
                                                                        <img src="/oaimg/JianTou.gif" /><%=ViewState["Titles"] %></td>
                                                                </tr>
                                                            </table>
                                                            <br>
                                                            <%=ViewState["Content"] %>
                                                            <%=ViewState["Content_list"] %>
                                                        </div>
                                                        <br>
                                                        &nbsp; 
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

        <script language="javascript">	

            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
