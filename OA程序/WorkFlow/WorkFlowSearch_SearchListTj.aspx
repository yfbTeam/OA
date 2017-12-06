<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowSearch_SearchListTj.aspx.cs"
    Inherits="xyoa.WorkFlow.WorkFlowSearch_SearchListTj" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="Div1" align="right">
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="返回重新统计" />
            <asp:Button ID="Button1" runat="server" Text="导出到EXCEL" OnClick="Button1_Click" />
            <asp:Button ID="Button2" runat="server" Text="导出到WORD" OnClick="Button2_Click" />
            <asp:Button ID="Button3" runat="server" Text="导出到PPT" OnClick="Button3_Click" />
            <asp:Button ID="Button4" runat="server" Text="导出到网页" OnClick="Button4_Click" />
            <hr>
        </div>
        <div id="printmx">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>
