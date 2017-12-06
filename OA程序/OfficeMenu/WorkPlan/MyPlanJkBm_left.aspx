<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyPlanJkBm_left.aspx.cs" Inherits="xyoa.OfficeMenu.WorkPlan.MyPlanJkBm_left" %>

<html>
<head id="Head1" runat="server">
    <title>组织信息</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body style="overflow: auto">
    <form id="form1" runat="server">
        <div>
            <%=showtitle %>
            <asp:TreeView ID="ListTreeView" runat="server" CollapseImageUrl="~/images/2.gif"
                ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
            </asp:TreeView>
        </div>
    </form>
</body>
</html>
