<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MokuaiY.aspx.cs" Inherits="xyoa.MyWork.MySet.MokuaiY" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script>
function delWin(str,delid)
{  
  AjaxMethod.delWin(str);
  document.getElementById('keyid'+str+'').style.display="none";
  window.top.moveli('keyid'+delid+'')
}

function delWin1(str,delid)
{  
  AjaxMethod.delWin(str);
  document.getElementById('keyid'+str+'').style.display="none";
  window.top.moveli('kzkeyid'+delid+'5322')
}

function delWin2(str,delid)
{  
  AjaxMethod.delWin(str);
  document.getElementById('keyid'+str+'').style.display="none";
  window.top.moveli('mhkeyid'+delid+'91221')
}
    </script>

    <style>

.lm_caidan
{
	width: 860px;
	overflow: hidden;
	margin-left: 15px;
}

.lm_caidan li
{
	width: 120px;
	height: 89px;
	margin: 8px;
	float: left;
	cursor: pointer;
	font-size: 12px;
	text-align: center;

}
</style>
</head>
<body class="newbody" oncontextmenu="return false">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                cellpadding="0" cellspacing="0" width="100%">
                                                <tr>
                                                    <td style="height: 26px; width: 51%;">
                                                        <button class="btn4off" type="button" onclick="javascript:window.location='Mokuai.aspx?p=<%=Request.QueryString["p"] %>&menhu=<%=Request.QueryString["menhu"] %>&i_chIf_id=<%=Request.QueryString["p"] %>';">
                                                            <font class="shadow_but">添加栏目</font></button>
                                                        <button class="btn4on" type="button" onclick="javascript:window.location='MokuaiY.aspx?p=<%=Request.QueryString["p"] %>&menhu=<%=Request.QueryString["menhu"] %>&i_chIf_id=<%=Request.QueryString["p"] %>';">
                                                            <font class="shadow_but">移除栏目</font></button>
                                                        <button class="btn4off" type="button" onclick="javascript:window.location='MokuaiP.aspx?p=<%=Request.QueryString["p"] %>&menhu=<%=Request.QueryString["menhu"] %>&i_chIf_id=<%=Request.QueryString["p"] %>';">
                                                            <font class="shadow_but">栏目排序</font></button>
                                                    </td>
                                                    <td style="height: 26px" align="right">
                                                        <font color="red">当前为第<%=Request.QueryString["menhu"] %>页桌面</font>
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
                    <table align="center" border="0" cellpadding="4" cellspacing="0" width="100%" height="80%">
                        <tr>
                            <td class="newtd2" colspan="2" width="20%" height="100%" valign="top">
                                <ul class="lm_caidan">
                                    <%=ViewState["myurl"]%>
                                </ul>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <input id="Hidden1" type="hidden" />

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
