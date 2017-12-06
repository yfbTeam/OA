<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="leibie_zl.aspx.cs" Inherits="xyoa.InfoManage.zhiao.leibie_zl" %>

<html>
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
                                                        <a href="/main_d.aspx" class="line_b" >工作台</a> >> 资料分类设置</td>
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
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
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
                                                        <button class="btn4off" type="button" onclick="javascript:window.nexthead.location='leibie_zl_left.aspx';"> <font class="shadow_but">资料分类设置</font></button>
                                                    </td>
                                                    <td style="height: 26px" align="right">
                                                         <button class="button_blue" type="button" onclick="javascript:window.nextrform.location='leibie_zl_add.aspx';" id="BUTTON1" runat="server"> 增 加</button>
                                                      
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
                    <table align="center" border="0" cellpadding="4" cellspacing="0" width="100%" height="80%">
                        <tr>
                            <td width="17">
                                &nbsp;</td>
                            <td class="newtd2" colspan="2" width="22%" height="100%" valign="top">
                                <iframe name="nexthead" marginwidth="0" marginheight="0" src="leibie_zl_left.aspx" frameborder="1"
                                    width="100%" height="100%" scrolling="auto"></iframe>
                            </td>
                            <td class="newtd2" colspan="2" width="78%" valign="top" height="100%">
                                <iframe name="nextrform" marginwidth="0" marginheight="0" src="leibie_zl_add.aspx" frameborder="1"
                                    width="100%" height="100%" scrolling="auto"></iframe>
                            </td>
                            <td width="17">
                                &nbsp;</td>
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