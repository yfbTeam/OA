<%@ Page Language="C#" AutoEventWireup="true" Codebehind="index_if.aspx.cs" Inherits="xyoa.JqMain.index_if" %>

<html>
<head runat="server">
    <title>无标题页</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
    <meta http-equiv="refresh" content="300"> 
</head>
<body bgcolor=white>
    <form id="form1" runat="server">
        <asp:Label ID="daibanshiyi" runat="server"></asp:Label>
    </form>
</body>
</html>
