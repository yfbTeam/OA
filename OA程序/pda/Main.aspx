<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="xyoa.pda.Main" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=GBK">
    <meta name="viewport" content="width=device-width, minimum-scale=1, maximum-scale=1">
    <meta name="apple-mobile-web-app-status-bar-style" content="black">
    <meta name="format-detection" content="telephone=no">
    <title>移动设备平台</title>
    <link rel="stylesheet" href="images/pda.css">

    <script src="images/jquery.min.js" type="text/javascript"></script>

    <script src="images/public.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div id="overlay">
        </div>
        <div class="ui-loader loading">
            <span class="ui-icon ui-icon-loading"></span>
            <h1>
                正在载入...</h1>
        </div>
        <div id="header">
            <span class="t"><%=ViewState["HeadName"] %></span></div>
        <div id="divgrid" class="divheight">
            <div class="menu">
                <ul>
                  <%=ViewState["pdaurl"] %>
                </ul>
            </div>
        </div>
        <div id="footer">
            <div class="footer_menu">
                <ul>
                  <%=ViewState["footulr"] %>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
