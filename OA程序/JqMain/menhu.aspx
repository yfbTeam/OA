<%@ Page Language="C#" AutoEventWireup="true" Codebehind="menhu.aspx.cs" Inherits="xyoa.JqMain.menhu" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
    <link href="/flowcss/oa.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/js/main.js" type="text/javascript"></script>

    <script>
function showfrom1(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/HumanResources/Employee/YuangongLL/YuangongLL_show.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function showfrom2(str)
{
    var num=Math.random();
    var k=window.showModalDialog("/HumanResources/Employee/YuangongGH/YuangongGH_show1.aspx?tmp="+num+"&id="+str+"",window,"dialogWidth:850px;DialogHeight=650px;status:no;scroll=yes;help:no")
}

function AddUrl()
{
    var num=Math.random();
    window.showModalDialog("MyLmUrl.aspx?tmp="+num+"&leixing=<%=Request.QueryString["id"] %>","window", "dialogWidth:720px;DialogHeight=580px;status:no;scroll=yes;help:no");       
}
    </script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <asp:TextBox ID="Tupian" runat="server" Style="display: none"></asp:TextBox>
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <asp:Label ID="Label" runat="server"></asp:Label></td>
                <td valign="top" width="4">
                </td>
                <td width="210" align="right" valign="top">
                    <table width="100%" height="13" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="200" height="300" border="0" cellpadding="0" cellspacing="1" class="maincss">
                        <tr>
                            <td height="100%" align="center" valign="top" bgcolor="#FFFFFF">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="25" class="mainbody1" height="25" align="center">
                                            <img src="/oaimg/menu/Menu4.gif" /></td>
                                        <td width="175" class="mainbody1" height="25">
                                            <a href="menhu.aspx?id=<%=Request.QueryString["id"] %>" class="MainLine"><strong>快速入口</strong></a></td>
                                        <td width="45" class="mainbody1" height="25" align="center">
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">设置</asp:LinkButton></td>
                                    </tr>
                                </table>
                                <asp:Label ID="daibanshiyi" runat="server"></asp:Label>
                            </td>
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
