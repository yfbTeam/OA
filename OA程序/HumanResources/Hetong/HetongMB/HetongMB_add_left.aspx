<%@ Page Language="C#" AutoEventWireup="true" Codebehind="HetongMB_add_left.aspx.cs"
    Inherits="xyoa.HumanResources.Hetong.HetongMB.HetongMB_add_left" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div align=center>
            <%=showtitle %>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
