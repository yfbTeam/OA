<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Info_left.aspx.cs" Inherits="xyoa.InfoManage.messages.Info_left" %>
<html>
<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
    <link href="/Css/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/left_menu.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    	<asp:TreeView ID="ListTreeView" runat="server" CollapseImageUrl="~/images/2.gif" ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
        </asp:TreeView>
    </div>
    </form>
</body>
</html>