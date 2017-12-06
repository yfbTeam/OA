<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_add_node_show.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.WorkFlowName_show_add_node_show" %>

<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <link href="/flowcss/style.css" type="text/css" rel="stylesheet">
    <object id="vmlRender" classid="CLSID:10072CEC-8CC1-11D1-986E-00A0C955B42E" viewastext>
    </object>
    <style>vml\:* {FONT-SIZE: 12px; BEHAVIOR: url(#VMLRender)}</style>
    <html xmlns:vml="urn:schemas-microsoft-com:vml">

    <script language="javascript" src="/flowcss/set_main.js"></script>

    <meta content="MSHTML 6.00.3790.3041" name="GENERATOR">
    <title>
        <%=Session["Titles"]%>
    </title>
</head>
<body oncontextmenu="nocontextmenu();" onmousedown="DoRightClick();" leftmargin="2"
    opmargin="2">
    <form id="form1" runat="server">
        <vml:line id="line1" style="display: none; z-index: 15; position: absolute" to="0,0"
            from="0,0"><!--直线可视化--><vml:Stroke 
dashstyle="shortDash"></vml:Stroke></vml:line>
        <%=ViewState["LineContent"]%>
        <%=ViewState["ContentLable"] %>
        <asp:TextBox ID="SET_SQL" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowNumber" runat="server" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>