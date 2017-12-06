<%@ Page Language="C#" AutoEventWireup="true" Codebehind="KaoPingSJ_KP2.aspx.cs"
    Inherits="xyoa.HumanResources.KaoPing.KaoPingSJ.KaoPingSJ_KP2" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <style type="text/css"> 
#content { overflow:auto; height:480px; width:220px; } 

.mbcss {
border-left:0px;
border-top:0px;
border-right:0px;
border-bottom:1px solid #000000
}
</style>

    <script>
function chknull()
{
    if(document.getElementById('Fenshu').value=='')
    {
        alert('考评分数不能为空');
        form1.Fenshu.focus();
        return false;
    }
    showwait();	
}  

    </script>

</head>
<body class="newbody" onload="Settb();Load_Do();">
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
                                                            <a href="KaoPingSJ.aspx">上级考评</a>
                                                            >> 进行二级考评</td>
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
                                                                <font class="shadow_but">上级考评</font></button></td>
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
                                                <tr>
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
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <strong>二级考评明细</strong>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div id="strhtm">
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>二级考评分数：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Fenshu" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        二级考评权重：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Quanzhong" runat="server"></asp:Label>%&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center" id="printshow4">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
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
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ContractContent" runat="server" TextMode="MultiLine" Style="display: none"></asp:TextBox>

        <script>
            function   Settb()  
            {  
                document.getElementById("strhtm").innerHTML=document.getElementById("TextBox1").value;
            }   
             
             
            function Load_Do()
            {
                setTimeout("Load_Do()",0);
                var content = document.getElementById("strhtm").innerHTML
                document.getElementById("ContractContent").value=content;  
                document.getElementById("TextBox1").value=document.getElementById("ContractContent").value;
            }
            
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
        </script>

    </form>
</body>
</html>
