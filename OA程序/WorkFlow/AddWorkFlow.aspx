<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddWorkFlow.aspx.cs" Inherits="xyoa.WorkFlow.AddWorkFlow" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script>

function opendoclist(str)
{
    var num=Math.random();
    var aw = screen.width-300;
    var ah = screen.height-100;
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    window.open ("AddWorkFlowLogin.aspx?tmp="+num+"&id="+str+"", "_blank", "height=" + ah + ", width=" + aw + ",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function opensclist(str)
{
    var num=Math.random();
    window.open ("AddWorkFlowSc.aspx?tmp="+num+"&id="+str+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=1,left=1")
}
    </script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
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
                                            新建工作 >> <%=ViewState["tilename"] %>
                                        </td>
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
                                            <button class="btn4off" type="button" onclick="javascript:window.location='AddWorkFlow.aspx?id=0';">
                                                <font class="shadow_but">全部表单</font>
                                            </button>
                                            <button class="btn4off" type="button" onclick="javascript:window.location='AddWorkFlow.aspx?id=10000';">
                                                <font class="shadow_but">收藏表单</font>
                                            </button>
                                        </td>
                                        <td style="height: 26px" align="right">
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
                <td class="newtd2" height="100%" valign="top" id="td1">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
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
