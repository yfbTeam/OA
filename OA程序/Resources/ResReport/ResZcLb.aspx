<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResZcLb.aspx.cs" Inherits="xyoa.Resources.ResReport.ResZcLb" %>
<html>
<script>
function openfrom(str)
{
var num=Math.random();
loc_x=(screen.availWidth-877)/2;
loc_y=(screen.availHeight-600)/2;
window.open ("Zichang_list.aspx?tmp="+num+"&"+str+"", "_blank", "height=600, width=877,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}
 </script>
           
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

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
                                                        <td width="41%" valign="bottom">
                                                            按物品类别分析</td>
                                                        <td width="56%">
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
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" >
                                                        <strong>列表分析</strong></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" >
                                                        <table width="100%" border="0" cellpadding="4" cellspacing="1" class="nextpage">
                                                          <tr> 
                                                            <td width="16%" class="newtd2"><div align="center">类型</div></td>
                                                            <td width="14%" class="newtd2"><div align="center">数量</div></td>
                                                            <td width="64%" class="newtd2"><div align="center">比例图</div></td>
                                                            <td width="6%" class="newtd2"><div align="center">操作</div></td>
                                                          </tr>
                                                              <%=ViewState["showlb"]%>
                                                        </table>
                                                    </td>
                                                </tr>
                                                          <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26">
                                                        <strong>图形分析</strong></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26">
                                                    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="500" height="230" align="" viewastext>
<param name="allowScriptAccess" value="sameDomain">
<param name="FlashVars" value="&dataXML=<graph shownames='1' showvalues='0' decimalPrecision='0' pieRadius='150' numberPrefix='' formatNumber='1' formatNumberScale='0'  baseFont='宋体' baseFontSize='12' outCnvBaseFontSze='宋体' outCnvBaseFontSize='11'>
<%=ViewState["showjg"]%>
</graph>">
<param name="movie" value="/oaimg/round.swf?chartWidth=500&ChartHeight=230">
<param name="quality" value="high">           
<param name="wmode" value="transparent">
<embed src="/oaimg/round.swf" flashVars="&dataXML=<graph shownames='1' showvalues='0' decimalPrecision='0' pieRadius='150' numberPrefix='' formatNumber='1' formatNumberScale='0'  baseFont='宋体' baseFontSize='12' outCnvBaseFontSze='宋体' outCnvBaseFontSize='11'><%=ViewState["showjg"]%></graph>" quality="high" width="500" height="330" name="Column3D" type="application/x-shockwave-flash" pluginspage=" http://www.macromedia.com/go/getflashplayer" wmode="transparent"/>
</object>      
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
          <script language="javascript">	
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>