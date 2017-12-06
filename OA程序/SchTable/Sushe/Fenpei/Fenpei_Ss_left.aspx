<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fenpei_Ss_left.aspx.cs" Inherits="xyoa.SchTable.Sushe.Fenpei.Fenpei_Ss_left" %>
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
        <asp:Label ID="Label1" runat="server" Visible=false></asp:Label>
    </div>
    </form>
</body>
</html>