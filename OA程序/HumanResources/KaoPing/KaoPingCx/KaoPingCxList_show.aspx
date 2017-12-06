<%@ Page Language="C#" AutoEventWireup="true" Codebehind="KaoPingCxList_show.aspx.cs"
    Inherits="xyoa.HumanResources.KaoPing.KaoPingCx.KaoPingCxList_show" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script>
    function zx()
    {
        if (!confirm("是否确定签字确认？"))
        return false;
    }

    </script>

    <style type="text/css"> 
#content { overflow:auto; height:480px; width:220px; } 

.mbcss {
border-left:0px;
border-top:0px;
border-right:0px;
border-bottom:1px solid #000000
}
</style>
</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0" id="printshow1">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow2">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="KaoPingCx.aspx">考评查询</a>
                                                            >> 查询结果</td>
                                                        <td width="81%">
                                                            &nbsp;</td>
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
                                <div id="printshow3">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">查询结果</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage"
                                                id="tableprint">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        考评主题：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Zhuti" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        考评类型：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="LeixingID" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        生效时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Starttime" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        终止时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Endtime" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        描述：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="Miaoshu" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        自我考评：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="FenshuMy" runat="server"></asp:Label>&nbsp;<asp:CheckBox ID="CheckBox0"
                                                            runat="server" onclick="aaa()" />
                                                    </td>
                                                </tr>
                                                <tr id="nextrs0" style="display: none">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <strong>自我考评明细</strong></div>
                                                        <br>
                                                        <asp:Label ID="NeirongMy" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="<%=ViewState["XianshiCss1"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        一级考评：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="Fenshu1" runat="server"></asp:Label>&nbsp;<asp:CheckBox ID="CheckBox1"
                                                            runat="server" onclick="bbb()" />
                                                    </td>
                                                </tr>
                                                <tr id="nextrs1" style="display: none">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <strong>一级考评明细</strong></div>
                                                        <br>
                                                        <asp:Label ID="Neirong1" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="<%=ViewState["XianshiCss2"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        二级考评：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="Fenshu2" runat="server"></asp:Label>&nbsp;<asp:CheckBox ID="CheckBox2"
                                                            runat="server" onclick="ccc()" />
                                                    </td>
                                                </tr>
                                                <tr id="nextrs2" style="display: none">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <strong>二级考评明细</strong></div>
                                                        <br>
                                                        <asp:Label ID="Neirong2" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="<%=ViewState["XianshiCss3"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        三级考评：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="Fenshu3" runat="server"></asp:Label>&nbsp;<asp:CheckBox ID="CheckBox3"
                                                            runat="server" onclick="ddd()" />
                                                    </td>
                                                </tr>
                                                <tr id="nextrs3" style="display: none">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <strong>三级考评明细</strong></div>
                                                        <br>
                                                        <asp:Label ID="Neirong3" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="<%=ViewState["XianshiCss4"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        四级考评：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="Fenshu4" runat="server"></asp:Label>&nbsp;<asp:CheckBox ID="CheckBox4"
                                                            runat="server" onclick="eee()" />
                                                    </td>
                                                </tr>
                                                <tr id="nextrs4" style="display: none">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <strong>四级考评明细</strong></div>
                                                        <br>
                                                        <asp:Label ID="Neirong4" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr style="<%=ViewState["XianshiCss5"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        五级考评：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="Fenshu5" runat="server"></asp:Label>&nbsp;<asp:CheckBox ID="CheckBox5"
                                                            runat="server" onclick="fff()" />
                                                    </td>
                                                </tr>
                                                <tr id="nextrs5" style="display: none">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <strong>五级考评明细</strong></div>
                                                        <br>
                                                        <asp:Label ID="Neirong5" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        考评总分：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="Zongfen" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center" id="printshow4">
                                                            <font face="宋体">
                                                                <input id="Button2" class="button_css" onclick="history.back()" type="button" value="返 回" /></font></div>
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

        <script>
function aaa()
{   
    if(document.getElementById('CheckBox0').checked)
    {
       document.getElementById('nextrs0').style.display="";
    }
    else
    {
       document.getElementById('nextrs0').style.display="none";
    }
}

function bbb()
{   
    if(document.getElementById('CheckBox1').checked)
    {
       document.getElementById('nextrs1').style.display="";
    }
    else
    {
       document.getElementById('nextrs1').style.display="none";
    }
}

function ccc()
{   
    if(document.getElementById('CheckBox2').checked)
    {
       document.getElementById('nextrs2').style.display="";
    }
    else
    {
       document.getElementById('nextrs2').style.display="none";
    }
}

function ddd()
{   
    if(document.getElementById('CheckBox3').checked)
    {
       document.getElementById('nextrs3').style.display="";
    }
    else
    {
       document.getElementById('nextrs3').style.display="none";
    }
}


function eee()
{
    if(document.getElementById('CheckBox4').checked)
    {
       document.getElementById('nextrs4').style.display="";
    }
    else
    {
       document.getElementById('nextrs4').style.display="none";
    }
}

function fff()
{
    if(document.getElementById('CheckBox5').checked)
    {
       document.getElementById('nextrs5').style.display="";
    }
    else
    {
       document.getElementById('nextrs5').style.display="none";
    }
}

        </script>

    </form>
</body>
</html>
