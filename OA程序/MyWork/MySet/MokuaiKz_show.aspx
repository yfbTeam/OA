<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MokuaiKz_show.aspx.cs" Inherits="xyoa.MyWork.MySet.MokuaiKz_show" %>

<html>
<head id="Head1" runat="server">
    <title>桌面栏目 </title>
    <link href="/Css/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/skin1/index2.css" rel="stylesheet" type="text/css" />

    <script src="/js/public.js" type="text/javascript"></script>

    <script>
function addWin(liid,str,urlname,url,openkey,chuangzhi,bigpic)
{
    if(document.getElementById('TextBox1').value>=30)
    {
        if (!confirm("你已经添加"+document.getElementById('TextBox1').value+"项了，是否还要继续添加？"))
        return false;
    }
    
    AjaxMethod.addWin(str,'<%=Request.QueryString["menhu"] %>','2',document.getElementById('Paixun').value);
    document.getElementById('kzkeyid'+str+'').style.display="none";
    document.getElementById('TextBox1').value =parseInt(document.getElementById('TextBox1').value) + 1;
    document.getElementById('Paixun').value =parseInt(document.getElementById('Paixun').value) + 1;
    window.top.setli(liid,<%=Request.QueryString["menhu"] %>,''+str+'5322',urlname,url,openkey,chuangzhi,bigpic)
}

    </script>

</head>
<body class="newbody"  oncontextmenu="return false">
    <form id="form1" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Paixun" runat="server" Style="display: none"></asp:TextBox>
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div>
                                                            <ul class="lm_caidan">
                                                               
                                                                <%=ViewState["myurl"]%>
                                                            </ul>
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
    </form>
</body>
</html>
