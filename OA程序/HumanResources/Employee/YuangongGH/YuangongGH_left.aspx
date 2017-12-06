<%@ Page Language="C#" AutoEventWireup="true" Codebehind="YuangongGH_left.aspx.cs"
    Inherits="xyoa.HumanResources.Employee.YuangongGH.YuangongGH_left" %>

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
        <div>
            <asp:TreeView ID="ListTreeView" runat="server" CollapseImageUrl="~/images/2.gif"
                ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
                <Nodes>
                    <asp:TreeNode Text="今天生日" Value="今天生日" NavigateUrl="YuangongGH_show.aspx?bdays=0"
                        ImageUrl="~/oaimg/menu/Menu293.gif" Target="nextrform"></asp:TreeNode>
                    <asp:TreeNode Text="3天内" Value="3天内" NavigateUrl="YuangongGH_show.aspx?bdays=3" ImageUrl="~/oaimg/menu/Menu293.gif"
                        Target="nextrform"></asp:TreeNode>
                    <asp:TreeNode Text="7天内" Value="7天内" NavigateUrl="YuangongGH_show.aspx?bdays=7" ImageUrl="~/oaimg/menu/Menu293.gif"
                        Target="nextrform"></asp:TreeNode>
                    <asp:TreeNode Text="15天内" Value="15天内" NavigateUrl="YuangongGH_show.aspx?bdays=15"
                        ImageUrl="~/oaimg/menu/Menu293.gif" Target="nextrform"></asp:TreeNode>
                    <asp:TreeNode Text="30天内" Value="30天内" NavigateUrl="YuangongGH_show.aspx?bdays=30"
                        ImageUrl="~/oaimg/menu/Menu293.gif" Target="nextrform"></asp:TreeNode>
                    <asp:TreeNode Text="全部员工" Value="全部员工" NavigateUrl="YuangongGH_show.aspx" ImageUrl="~/oaimg/menu/Menu293.gif"
                        Target="nextrform"></asp:TreeNode>
                </Nodes>
            </asp:TreeView>
        </div>
    </form>
</body>
</html>
