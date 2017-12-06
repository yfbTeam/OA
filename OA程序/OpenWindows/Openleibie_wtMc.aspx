<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Openleibie_wtMc.aspx.cs" Inherits="xyoa.OpenWindows.Openleibie_wtMc" %>
<html>
<head id="Head1" runat="server">
    <title>请选择问题分类</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <base target="_self" />
</head>
<body class="newbody">
    <form id="form1" runat="server">
        <div>
            <br>
            <br>
            <br>
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label><br>
            分类名称：<asp:TextBox ID="Name" runat="server" CssClass="ReadOnlyText" Width="169px"></asp:TextBox>
            <asp:TextBox ID="gncdid" runat="server" Style="display: none"></asp:TextBox>
            <asp:TextBox ID="States" runat="server" Style="display: none"></asp:TextBox>
            <asp:TextBox ID="ZdBumenId" runat="server" Style="display: none"></asp:TextBox>
            <asp:TextBox ID="ZdBumen" runat="server" Style="display: none"></asp:TextBox>
            <asp:TextBox ID="ZdUsername" runat="server" Style="display: none"></asp:TextBox>
            <asp:TextBox ID="ZdRealname" runat="server" Style="display: none"></asp:TextBox>
        </div>
    </form>
</body>
</html>
