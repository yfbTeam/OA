<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WorkFlowName_show_add_node_del.aspx.cs" Inherits="xyoa.SystemManage.WorkFlow.WorkFlowName_show_add_node_del" %>
<html>
<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="FlowNumber" runat="server"></asp:TextBox>
        <asp:TextBox ID="NodeNum" runat="server"></asp:TextBox>
        <asp:TextBox ID="NodeNumber" runat="server"></asp:TextBox></div>
    </form>
</body>
</html>
