<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Richengjk.aspx.cs" Inherits="xyoa.MyWork.Richeng.Richengjk" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow1">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                </td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="20%" valign="bottom">
                                                            日程监控</td>
                                                        <td width="37%">
                                                            </td>
                                                        <td width="40%" align="right">
                                                                   <asp:DropDownList ID="years" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Button1_Click">
                                                                <asp:ListItem>2008</asp:ListItem>
                                                                <asp:ListItem>2009</asp:ListItem>
                                                                <asp:ListItem>2010</asp:ListItem>
                                                                <asp:ListItem>2011</asp:ListItem>
                                                                <asp:ListItem>2012</asp:ListItem>
                                                                <asp:ListItem>2013</asp:ListItem>
                                                                <asp:ListItem>2014</asp:ListItem>
                                                                <asp:ListItem>2015</asp:ListItem>
                                                                <asp:ListItem>2016</asp:ListItem>
                                                                <asp:ListItem>2017</asp:ListItem>
                                                                <asp:ListItem>2018</asp:ListItem>
                                                                <asp:ListItem>2019</asp:ListItem>
                                                                <asp:ListItem>2020</asp:ListItem>
                                                            </asp:DropDownList>年
                                                            <asp:DropDownList ID="months" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Button1_Click">
                                                                <asp:ListItem>1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                                <asp:ListItem>6</asp:ListItem>
                                                                <asp:ListItem>7</asp:ListItem>
                                                                <asp:ListItem>8</asp:ListItem>
                                                                <asp:ListItem>9</asp:ListItem>
                                                                <asp:ListItem>10</asp:ListItem>
                                                                <asp:ListItem>11</asp:ListItem>
                                                                <asp:ListItem>12</asp:ListItem>
                                                            </asp:DropDownList>月
                                                        </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" class="nexttop">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17" style="height: 40px">
                                            </td>
                                        <td valign="top" style="height: 40px">
                                            <div id="printshow2">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="height: 26px;">
                                                  <button class="btn4off" type="button" onclick="javascript:window.location='RichengjkRi.aspx';showwait();">
                                                                <font class="shadow_but">日视图</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='RichengjkZhou.aspx';showwait();"><font class="shadow_but">周视图</font></button>
                                                            <button class="btn4on" type="button" onclick="javascript:window.location='Richengjk.aspx';showwait();"><font class="shadow_but">月视图</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='Richengjklist.aspx';showwait();"><font class="shadow_but">列表模式</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                           
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td width="17" style="height: 40px">
                                            </td>
                                    </tr>
                                </table>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <div id="Div1">
                                                            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#C3D9FF"
                                                                CellPadding="0" FirstDayOfWeek="Monday" ForeColor="Black" Height="320px" NextPrevFormat="ShortMonth"
                                                                OnDayRender="Calendar1_DayRender" ShowGridLines="True" Width="100%" SelectionMode="None">
                                                                <DayStyle BorderWidth="1px" VerticalAlign="Top" />
                                                                <DayHeaderStyle BackColor="#C3D9FF" BorderWidth="1px" ForeColor="#0000CC" />
                                                                <TitleStyle BorderWidth="1px" BackColor="#E8EEF7" />
                                                            </asp:Calendar>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

        <script type="text/javascript">
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
