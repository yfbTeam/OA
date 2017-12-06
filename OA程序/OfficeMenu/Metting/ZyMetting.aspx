<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ZyMetting.aspx.cs" Inherits="xyoa.OfficeMenu.Metting.ZyMetting" %>

<html>
<head id="Head1" runat="server">
    <title>
        会议室占用情况
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
                                                             会议室占用情况</td>
                                                        <td width="37%">
                                                            </td>
                                                        <td width="40%" align="right">
                                                            <asp:DropDownList ID="years" runat="server">
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
                                                            <asp:DropDownList ID="months" runat="server">
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
                                                            </asp:DropDownList>月<asp:Button ID="Button1" OnClick="Button1_Click" runat="server"
                                                                Text="转到"></asp:Button>
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
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='ZyMetting.aspx';showwait();">
                                                                <font class="shadow_but">占用情况</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                           <img src=/oaimg/zy/1.gif  hspace=2>等待审批  <img src=/oaimg/zy/2.gif  hspace=2>正在审批  <img src=/oaimg/zy/3.gif  hspace=2>通过审批  <img src=/oaimg/zy/4.gif  hspace=2>终止审批 
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
                                                       <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30px"
                                                            background="/oaimg/nextline.gif">
                                                            <tr>
                                                                <td valign="top">
                                                                    选择会议室：<asp:DropDownList ID="typename" runat="server" Width="340px" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
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
