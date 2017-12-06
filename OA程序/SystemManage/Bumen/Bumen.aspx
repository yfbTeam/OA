<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Bumen.aspx.cs" Inherits="xyoa.SystemManage.Bumen.Bumen" %>

<html>
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
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="35">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="17">
                                &nbsp;</td>
                            <td valign="top">
                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%">
                                            <img src="/oaimg/top_3.gif"></td>
                                        <td width="81%" valign="bottom">
                                            部门管理</td>
                                        <td width="16%">
                                            &nbsp;</td>
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
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="35">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="17">
                                &nbsp;</td>
                            <td valign="top">
                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                    cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="height: 26px;">
                                            <button class="btn4off" type="button" onclick="javascript:window.nexthead.location='Bumen_left.aspx';">
                                                <font class="shadow_but">部门管理</font></button>
                                        </td>
                                        <td style="height: 26px" align="right">
                                            <button class="button_blue" type="button" onclick="javascript:window.nextrform.location='Bumen_add.aspx';"
                                                id="BUTTON1" runat="server">
                                                增 加</button>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="17">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
       <table align="center" border="0" cellpadding="4" cellspacing="0" width="100%" height="<%=ViewState["tableheigh"] %>">
            <tr>
               <td width="5">
                    &nbsp;</td>
                 <td class="newtd2" width="250px" height="100%" valign="top" id="td1">
                    <iframe name="nexthead" marginwidth="0" marginheight="0" src="Bumen_left.aspx" frameborder="1"
                        width="100%" height="100%" scrolling="auto"></iframe>
                </td>
                <td class="newtd2" valign="top" height="100%" id="td2">
                    <iframe name="nextrform" marginwidth="0" marginheight="0" src="Bumen_show.aspx" frameborder="1"
                        width="100%" height="100%" scrolling="auto"></iframe>
                </td>
                <td width="5">
                    &nbsp;</td>
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
