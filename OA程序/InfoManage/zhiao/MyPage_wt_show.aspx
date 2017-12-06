<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyPage_wt_show.aspx.cs"
    Inherits="xyoa.InfoManage.zhiao.MyPage_wt_show" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <base target="_self" />
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script>
function m_show(id)
{ 
var num=Math.random();
window.showModalDialog('ziliao_tj_show.aspx?id='+id+'&tmp='+num+'','window','dialogWidth:730px;DialogHeight=500px;status:no;help=no;scroll=on');window.location='#'
}  

function select_zj()
{
   if (document.getElementById('neirong_zj').value=='0')
   {
       document.getElementById('neirong_zj').value='1';
       zhuijia.style.display='';  
   }
   else
   {
       document.getElementById('neirong_zj').value='0';
       zhuijia.style.display='none';
   }
}

function select_hd()
{
   if (document.getElementById('neirong_hd').value=='0')
   {
       document.getElementById('neirong_hd').value='1';
       huidadiv.style.display='';  
   }
   else
   {
       document.getElementById('neirong_hd').value='0';
       huidadiv.style.display='none';
   }
}

function chknull()
{
    if(document.getElementById('TextBox1').value=='')
    {
        alert('追加问题内容不能为空');
        form1.TextBox1.focus();
        return false;
    }
}

function huidanull()
{
    if(document.getElementById('TextBox2').value=='')
    {
        alert('回答问题内容不能为空');
        form1.TextBox1.focus();
        return false;
    }	
}  

function opencaina(str,WentiId)
{
var num=Math.random();
window.open ("MyPage_wt_show_cn.aspx?tmp="+num+"&id="+str+"&WentiId="+WentiId+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=1,left=1")
}

function openyincan(str,WentiId)
{
var num=Math.random();
window.open ("MyPage_wt_show_yc.aspx?tmp="+num+"&id="+str+"&WentiId="+WentiId+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=1,left=1")
}

function select_tj()
{
var num=Math.random();
window.open ("MyPage_wt_show_tj.aspx?tmp="+num+"&id=<%=Request.QueryString["id"] %>", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=1,left=1")
}

function select_qxtj()
{
var num=Math.random();
window.open ("MyPage_wt_show_qxtj.aspx?tmp="+num+"&id=<%=Request.QueryString["id"] %>", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=1,left=1")
}

function select_sc()
{
var num=Math.random();
window.open ("MyPage_wt_show_sc.aspx?tmp="+num+"&id=<%=Request.QueryString["id"] %>", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=1,left=1")
}
    </script>

</head>
<body class="newbody" >
    <form id="form1" runat="server">
        <asp:TextBox ID="neirong_zj" runat="server" Text="0" style="display: none"></asp:TextBox>
        <asp:TextBox ID="neirong_hd" runat="server"  Text="0" style="display: none"></asp:TextBox>
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="10" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;
                                        </td>
                                        <td valign="top">
                                            <table width="685" height="184" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table width="685" height="12" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td background="img/b1.jpg">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="685" height="29" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td background="img/b2.jpg">
                                                                    <table width="685" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="41" align="right">
                                                                                <img src="img/<%=ViewState["jiejue"] %>.jpg" width="16" height="16" hspace="6" vspace="0"></td>
                                                                            <td width="564">
                                                                                <font color="#020204" style="font-size: 14px;"><b>
                                                                                    <%=ViewState["Zhuti"]%>
                                                                                </b></font>
                                                                            </td>
                                                                            <td width="80" align="left">
                                                                                &nbsp;</td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="685" height="27" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td background="img/b3.jpg">
                                                                    <table width="685" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="19">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="515">
                                                                                <font color="#666666">提问时间：<%=ViewState["Settimes"] %></font>&nbsp;&nbsp;&nbsp;提问人：<a
                                                                                    href='javascript:void(0)' onclick='senduser("<%=ViewState["Username"] %>")' class="LinkLine"><font
                                                                                        color="#4D3CCF"><%=ViewState["Realname"] %></font></a></td>
                                                                            <td width="151">
                                                                                <font color="#666666">浏览次数：<%=ViewState["Dianji"] %>次</font></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="685" height="31" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td background="img/b4.jpg">
                                                                    <table width="685" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="19">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="666">
                                                                                <font color="#020204" style="font-size: 14px;"><b>问题内容：</b></font></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="685" height="140" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td valign="top" background="img/b5.jpg">
                                                                    <table width="685" height="103" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="19">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="655" valign="top">
                                                                                <p>
                                                                                    <%=ViewState["Neirong"] %>
                                                                                </p>
                                                                                <asp:Label ID="fujian" runat="server" Width="90%"></asp:Label>
                                                                                <div id="zhuijia" style="display: none">
                                                                                    <asp:TextBox ID="TextBox1" runat="server" Width="489px" Height="58px" TextMode="MultiLine"></asp:TextBox>
                                                                                    <asp:Button ID="Button1" runat="server" Text="提交追加问题" OnClick="Button1_Click" />
                                                                                </div>
                                                                                <div id="huidadiv" style="display: none">
                                                                                    <asp:TextBox ID="TextBox2" runat="server" Width="490px" Height="58px" TextMode="MultiLine"></asp:TextBox>
                                                                                    <asp:Button ID="Button2" runat="server" Text="提交回答问题" OnClick="Button2_Click" />
                                                                                </div>
                                                                            </td>
                                                                            <td width="11">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="3%">
                                                                                &nbsp;</td>
                                                                            <td width="97%">
                                                                                <a href='javascript:void(0)'><img src="img/hf.gif" hspace="4" border="0" onclick="select_hd()"></a><a href='javascript:void(0)'><img src="img/zhuijia.gif"
                                                                                    hspace="4" border="0" onclick="select_zj()" id="IMG4" runat="server"></a><a href='javascript:void(0)'><img src="img/tuijian.gif" hspace="4" onclick="select_tj()"  border=0 id="IMG1" runat="server"></a><a href='javascript:void(0)'><img src="img/quxiao.gif" hspace="4" onclick="select_qxtj()"  border=0 id="IMG3" runat="server"></a><a href='javascript:void(0)'><img src="img/shanchu.gif" hspace="4" onclick="select_sc()" border=0 id="IMG2" runat="server"></a></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="685" height="15" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td background="img/b6.jpg">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <asp:Panel ID="Panel1" runat="server">
                                                            <table width="685" height="128" border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <table width="685" height="39" border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td background="img/b7.jpg">
                                                                                    &nbsp;
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table width="685" height="48" border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td valign="top" background="img/b8.jpg">
                                                                                    <table width="685" height="103" border="0" cellpadding="0" cellspacing="0">
                                                                                        <tr>
                                                                                            <td width="27">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td width="647" valign="top">
                                                                                                <p>
                                                                                                    <%=ViewState["NeirongZj"]%>
                                                                                                </p>
                                                                                                <asp:Label ID="fujianZj" runat="server" Width="90%"></asp:Label>
                                                                                            </td>
                                                                                            <td width="11">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table width="685" height="22" border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td background="img/b9.jpg">
                                                                                    <table width="685" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td width="10">
                                                                                                &nbsp;
                                                                                            </td>
                                                                                            <td width="102">
                                                                                                回答人：<a href='javascript:void(0)' onclick='senduser("<%=ViewState["UsernameZj"] %>")'
                                                                                                    class="LinkLine"><font color="#4D3CCF"><%=ViewState["RealnameZj"] %></font></a>&nbsp;&nbsp;<font
                                                                                                        color="#666666">|</font></td>
                                                                                            <td width="368" valign="top">
                                                                                                <img src="img/d_5.gif" width="84" height="16"></td>
                                                                                            <td width="205">
                                                                                                <font color="#666666">回答时间：<%=ViewState["SettimesZj"] %></font></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                        <table width="685" height="19" border="0" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td background="img/b10.jpg">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                        <table width="685" height="14" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td background="img/b11.jpg">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="685" height="30" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td valign="middle" background="img/b12.jpg">
                                                                    <table width="685" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="50">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="635">
                                                                                <font color="#020204" style="font-size: 14px;"><b>回答</b></font><font color="#666666">共<%=ViewState["heji"] %>条</font></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="685" height="150" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td valign="top" background="img/b13.jpg">
                                                                    <table width="685" height="103" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="27">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td width="647" valign="top">
                                                                                <asp:Label ID="huida" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td width="11">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table width="685" height="8" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td background="img/b14.jpg">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
