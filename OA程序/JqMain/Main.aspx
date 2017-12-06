<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Main.aspx.cs" Inherits="xyoa.JqMain.WorkFlow" %>

<html>
<head id="Head1" runat="server">
    <title>门户</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script>
    function visible_click()
    {
        if(document.getElementById('td1').style.display=="")
        {
            document.getElementById('td1').style.display="none";
            form1.middle_picture.src="/oaimg/right.gif";

        }
        else
        {
            document.getElementById('td1').style.display="";
            form1.middle_picture.src="/oaimg/left.gif";
        }
    }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="10" class="bluetop" align="center" colspan="3">
                    <a href='<%=ViewState["meunr"] %>' target="rform"><font color="white">返回主页</font></a>
                </td>
            </tr>
            <tr>
                <td valign="top" width="200" id="td1">
                    <iframe name="lhead" marginwidth="0" marginheight="0" src="<%=ViewState["meun"] %>"
                        frameborder="0" width="100%" height="100%" scrolling="auto"></iframe>
                </td>
                <td background="/NewStyleLan/m1.gif" style="width: 5px">
                    <img onclick="visible_click()" style="cursor: hand;" src="/oaimg/left.gif" id="middle_picture"></td>
                </td>
                <td>
                    <iframe name="rform" marginwidth="0" marginheight="0" src="<%=ViewState["meunr"] %>"
                        frameborder="0" width="100%" height="100%" scrolling="auto"></iframe>
                </td>
            </tr>
            <tr>
                <td height="10" colspan="3">
                    <table width="100%" height="10" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td align="center" class="bluetop">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
