﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OpenZiChangLeft.aspx.cs" Inherits="xyoa.OpenWindows.OpenZiChangLeft" %>
<html>
<head id="Head1" runat="server">
    <title>请选择物品</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body background="/oaimg/menuBG.gif" style="overflow: auto">
    <form id="form1" runat="server">
        <div>
            <%=showtitle %>
            <asp:TreeView ID="ListTreeView" runat="server" NodeIndent="10" ShowLines="True">
            </asp:TreeView>
        </div>
    </form>
</body>
</html>
