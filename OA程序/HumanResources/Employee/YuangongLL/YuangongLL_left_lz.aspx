<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YuangongLL_left_lz.aspx.cs" Inherits="xyoa.HumanResources.Employee.YuangongLL.YuangongLL_left_lz" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
    
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
    
    window.open ("YuangongLL_show.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TreeView ID="ListTreeView" runat="server" CollapseImageUrl="~/images/2.gif"
                ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            </asp:TreeView>
        </div>
    </form>
</body>
</html>