<%@ Page Language="C#" AutoEventWireup="true" Codebehind="zhishitang.aspx.cs" Inherits="xyoa.InfoManage.zhiao.zhishitang" %>

<%@ Register Src="taitou.ascx" TagName="taitou" TagPrefix="uc2" %>
<%@ Register Src="right.ascx" TagName="right" TagPrefix="uc1" %>
<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="zst.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script>
function m_show(id)
{ 
var num=Math.random();
window.showModalDialog('ziliao_tj_show.aspx?id='+id+'&tmp='+num+'','window','dialogWidth:730px;DialogHeight=500px;status:no;help=no;scroll=on');window.location='#'
}  

function w_show(id)
{ 
var num=Math.random();
window.showModalDialog('wenti_tj_show.aspx?id='+id+'&tmp='+num+'','window','dialogWidth:727px;DialogHeight=700px;status:no;help=no;scroll=on');window.location='#'
}  

    </script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        &nbsp;
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;
                                        </td>
                                        <td valign="top">
                                            <table width="991" height="620" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td valign="top">
                                                        <uc2:taitou ID="Taitou1" runat="server"></uc2:taitou>
                                                        <table width="991" height="743" border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td width="207" valign="top">
                                                                    <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td background="../../oaimg/zst/l1.jpg">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td width="73%">
                                                                                            <a href="#"><font color="#393939" style="font-size: 13px;"><b>问题分类 </b></font></a>
                                                                                        </td>
                                                                                        <td width="17%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="429" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td valign="top" background="../../oaimg/zst/l2.jpg">
                                                                                <table width="100%" height="429" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td width="7%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td width="88%" valign="top">
                                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="5">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <font color="#008800">已解决问题数：</font><a href="wenti_yjj.aspx"><font color="#008800"><%=ViewState["yjjcount"] %></font></a></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <font color="#008800">待解决问题数：</font><a href="wenti_wjj.aspx"><font color="#008800"><%=ViewState["wjjcount"] %></font></a></td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <table width="170" height="1" border="0" align="center" cellpadding="0" cellspacing="0"
                                                                                                bgcolor="#DBEEF5">
                                                                                                <tr>
                                                                                                    <td>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                            <asp:Label ID="wtfenlei" runat="server"></asp:Label></td>
                                                                                        <td width="5%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="48" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td valign="top" background="../../oaimg/zst/l3.jpg">
                                                                                <table width="100" height="28" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="10%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td width="73%">
                                                                                            <a href="ziliao_all.aspx"><font color="#393939" style="font-size: 13px;"><b>共享资料分类 </b>
                                                                                            </font></a>
                                                                                        </td>
                                                                                        <td width="17%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="231" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td valign="top" background="../../oaimg/zst/l4.jpg">
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="7%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td width="88%" valign="top">
                                                                                            <asp:Label ID="zlfenlei" runat="server"></asp:Label>
                                                                                        </td>
                                                                                        <td width="5%">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="21" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td background="../../oaimg/zst/l5.jpg">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td width="577" valign="top">
                                                                    <table width="100%" height="33" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td background="../../oaimg/zst/z1.jpg">
                                                                                <table width="568" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="31">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td width="500">
                                                                                            <a href="wenti_tj.aspx"><font color="#393939" style="font-size: 13px;"><b>推荐问题 </b></font></a>
                                                                                        </td>
                                                                                        <td width="37">
                                                                                            <a href="wenti_tj.aspx"><font color="#393939">更多</font></a></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="109" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td valign="top" background="../../oaimg/zst/z2.jpg">
                                                                                <asp:Label ID="tuijianwenti" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="47" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td background="../../oaimg/zst/z3.jpg">
                                                                                <table width="100%" height="20" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table width="568" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="35">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td width="496">
                                                                                            <a href="wenti_wjj.aspx"><font color="#393939" style="font-size: 13px;"><b>待解决问题 </b></font></a>
                                                                                        </td>
                                                                                        <td width="37">
                                                                                            <a href="wenti_wjj.aspx"><font color="#393939">更多</font></a></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="151" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td valign="top" background="../../oaimg/zst/z4.jpg">
                                                                                  <asp:Label ID="daijiejuewenti" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="44" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td background="../../oaimg/zst/z5.jpg">
                                                                                <table width="100%" height="20" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table width="568" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="35">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td width="496">
                                                                                            <a href="wenti_yjj.aspx"><font color="#393939" style="font-size: 13px;"><b>已解决问题 </b></font></a>
                                                                                        </td>
                                                                                        <td width="37">
                                                                                            <a href="wenti_yjj.aspx"><font color="#393939">更多</font></a></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="151" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td valign="top" background="../../oaimg/zst/z6.jpg">
                                                                                <asp:Label ID="yijiejuewenti" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="48" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td valign="top" background="../../oaimg/zst/z7.jpg">
                                                                                <table width="100%" height="22" border="0" cellpadding="0" cellspacing="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            &nbsp;
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                <table width="568" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td width="41">
                                                                                            &nbsp;
                                                                                        </td>
                                                                                        <td width="490">
                                                                                            <a href="ziliao_tj.aspx"><font color="#133DB6" style="font-size: 13px;"><b>共享资料推荐 </b>
                                                                                            </font></a>
                                                                                        </td>
                                                                                        <td width="37">
                                                                                            <a href="ziliao_tj.aspx"><font color="#133DB6">更多</font></a></td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="139" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td valign="top" background="../../oaimg/zst/z8.jpg">
                                                                                <asp:Label ID="tuijianziliao" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table width="100%" height="13" border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td background="../../oaimg/zst/z9.jpg">
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                                <td width="207" valign="top">
                                                                    <uc1:right ID="Right1" runat="server"></uc1:right>
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
