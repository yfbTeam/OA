﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="RichengRi.aspx.cs" Inherits="xyoa.MyWork.Richeng.RichengRi" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <style>
    .TableList{
   border:1px #4686c6 solid;
   line-height:21px;
   font-size:9pt;
   border-collapse:collapse;
   padding:3px;
}
.TableHeader{
   height:30px !important;
   height:32px;
   background:#5d99da;
   border-bottom:1px #4686c6 solid;
   border-right:1px #4686c6 solid;
   font-weight:bold;
   text-align:center;
   color:#fff;
   padding:0px;
}
.TableCorner{
   background:#5d99da;
}

.TableLeft{
   background:#f2f8ff;
   border-bottom:1px #a7bd74 solid;
}
.TableRight{
   background:#FFFFFF;
   border-bottom:1px #a7bd74 solid;
}
.Celldiv {
   display:inline-block;
   color:#666666;
   padding-left:1px;
   padding:4;
}

    </style>
    
    <script>
function display_front(front)
{
   var front=document.getElementById("front");
   if(!front)
      return;
   if(front.style.display=='')
      front.style.display='none';
   else
      front.style.display='';
  
}
    
    </script>
</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow1">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="20%" valign="bottom">
                                                            我的日程</td>
                                                        <td width="37%">
                                                        </td>
                                                        <td width="40%" align="right">
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
                                                &nbsp;</td>
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
                                            &nbsp;</td>
                                        <td valign="top" style="height: 40px">
                                            <div id="printshow2">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="height: 26px;">
                                                            <button class="btn4on" type="button" onclick="javascript:window.location='RichengRi.aspx';showwait();">
                                                                <font class="shadow_but">日视图</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='RichengZhou.aspx';showwait();"><font class="shadow_but">周视图</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='Richengmy.aspx';showwait();"><font class="shadow_but">月视图</font></button>
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='RichengmyList.aspx';showwait();"><font class="shadow_but">列表模式</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                            <asp:Button ID="AddData" runat="server" Text="增 加" CssClass="button_blue" OnClick="AddData_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td width="17" style="height: 40px">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30px"
                                                background="/oaimg/nextline.gif">
                                                <tr>
                                                    <td valign="top">
                                                        <asp:Button ID="Button2" runat="server" Text="今天" OnClick="Button2_Click"></asp:Button>
                                                        
                                                        时间：<asp:DropDownList ID="years" runat="server" AutoPostBack="True" OnSelectedIndexChanged="years_SelectedIndexChanged">
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
                                                        <asp:DropDownList ID="months" runat="server" AutoPostBack="True" OnSelectedIndexChanged="months_SelectedIndexChanged">
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
                                                        <asp:DropDownList ID="days" runat="server" AutoPostBack="True" OnSelectedIndexChanged="days_SelectedIndexChanged">
                                                        </asp:DropDownList>日
                                                        <asp:Button ID="Button1" runat="server" Text="上一天" OnClick="Button1_Click"></asp:Button>
                                                        <asp:Button ID="Button3" runat="server" Text="下一天" OnClick="Button3_Click"></asp:Button>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <div id="Div1">
                                                            <table class="TableList" width="100%" align="center" cellspacing="0" cellpadding="0">
                                                                <tr align="center" class="TableHeader">
                                                                    <td width="9%" class="TableCorner">
                                                                    <a href="javascript:display_front();"><font color=white>0-6点</font></a>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="Day" runat="server" ForeColor="white"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <asp:Label ID="Label1" runat="server"></asp:Label></table>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
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
