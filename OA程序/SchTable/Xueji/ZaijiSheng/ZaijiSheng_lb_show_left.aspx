<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ZaijiSheng_lb_show_left.aspx.cs"
    Inherits="xyoa.SchTable.Xueji.ZaijiSheng.ZaijiSheng_lb_show_left" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body style="overflow: auto" bgcolor="white">
    <form id="form1" runat="server">
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font></div>

        <script language="javascript">
    document.getElementById('show').style.display=''; 
        </script>

   <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
        </asp:TreeView>

        <script language="javascript">
    document.getElementById('show').style.display='none'; 
        </script>

    </form>
</body>
</html>
