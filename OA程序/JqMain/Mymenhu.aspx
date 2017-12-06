﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mymenhu.aspx.cs" Inherits="xyoa.JqMain.Mymenhu" %>

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
    </script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <asp:TextBox ID="Tupian" runat="server" Style="display: none"></asp:TextBox>
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <asp:Label ID="Label" runat="server"></asp:Label></td>
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
