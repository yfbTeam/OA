<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QikanLxList_left.aspx.cs" Inherits="xyoa.PublicWork.Qikan.QikanLxList_left" %>
<html>
<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <%=showtitle %>
    	<asp:TreeView ID="ListTreeView" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
        </asp:TreeView>
    </div>
    </form>
</body>
</html>