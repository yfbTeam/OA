<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Mokuai.aspx.cs" Inherits="xyoa.MyWork.MySet.Mokuai" %>

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
                <td width="5">
                    &nbsp;</td>
                <td style="height: 26px; width: 50%;" background="/<%=Session["yangshi"]%>/bg0003.gif">
                    <button class="btn4on" type="button" onclick="javascript:window.location='Mokuai.aspx?p=<%=Request.QueryString["p"] %>&menhu=<%=Request.QueryString["menhu"] %>&i_chIf_id=<%=Request.QueryString["p"] %>';">
                        <font class="shadow_but">添加栏目</font></button>
                    <button class="btn4off" type="button" onclick="javascript:window.location='MokuaiY.aspx?p=<%=Request.QueryString["p"] %>&menhu=<%=Request.QueryString["menhu"] %>&i_chIf_id=<%=Request.QueryString["p"] %>';">
                        <font class="shadow_but">移除栏目</font></button>
                    <button class="btn4off" type="button" onclick="javascript:window.location='MokuaiP.aspx?p=<%=Request.QueryString["p"] %>&menhu=<%=Request.QueryString["menhu"] %>&i_chIf_id=<%=Request.QueryString["p"] %>';">
                        <font class="shadow_but">栏目排序</font></button>
                    <a href="javascript:void(0)" onclick="visible_click()">
                        <img src="/oaimg/menu/yc.gif" border="0" /></a>
                </td>
                <td style="height: 26px" align="right" background="/<%=Session["yangshi"]%>/bg0003.gif">
                    <font color="red">当前为第<%=Request.QueryString["menhu"] %>页桌面</font>
                </td>
                <td width="5">
                    &nbsp;</td>
            </tr>
        </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <table width="100%" height="80%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td width="5">
                    &nbsp;</td>
                <td class="newtd2" width="200px" height="100%" valign="top" id="td1">
                    <iframe name="nexthead" marginwidth="0" marginheight="0" src="Mokuai_left.aspx?menhu=<%=Request.QueryString["menhu"] %>"
                        frameborder="1" width="100%" height="100%" scrolling="auto"></iframe>
                </td>
                <td class="newtd2" valign="top" height="100%" id="td2">
                    <iframe name="nextrform" marginwidth="0" marginheight="0" src="Mokuai_show.aspx?id=1&menhu=<%=Request.QueryString["menhu"] %>"
                        frameborder="1" width="100%" height="100%" scrolling="auto"></iframe>
                </td>
                <td width="5">
                    &nbsp;</td>
            </tr>
        </table>
        <input id="Hidden1" type="hidden" />

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
