<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Xueshengxinxi_jspy_show.aspx.cs"
    Inherits="xyoa.SchTable.Xueji.Xueshengxinxi.Xueshengxinxi_jspy_show" %>

<html>

<script>
function chknull()
{
   if(document.getElementById('XsId').value=='')
    {
    alert('学生姓名不能为空');
    form1.XsId.focus();
    return false;
    }	

    showwait();	
 
}  

function _change()
{
   var text=form1.PingyuS.value;
   if (text !="")
   {
       document.getElementById('Pingyu').value +="\r\n"+text;
   }
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
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top" style="height: 40px">
                                <div id="printshow2">
                                    <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                        cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td style="height: 26px;">
                                                <button class="btn4off" type="button">
                                                    <font class="shadow_but">教师评语</font></button>
                                            </td>
                                            <td style="height: 26px" align="right">
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
                                <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            学期：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Xueqi" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            学段：</td>
                                        <td class="newtd2" height="17" width="20%">
                                            <asp:Label ID="Xueduan" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            学生姓名：</td>
                                        <td class="newtd2" height="17" width="45%" colspan="3">
                                            <asp:Label ID="XsId" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            品德总评等第：</td>
                                        <td class="newtd2" height="17" width="95%" colspan="7">
                                            <asp:Label ID="Zongpin" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                            评语：</td>
                                        <td class="newtd2" height="17" width="95%" colspan="7">
                                            <asp:Label ID="Pingyu" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr id="printshow3">
                                        <td align="center" class="newtd2" colspan="8" height="26" width="33%">
                                            <div align="center">
                                                <font face="宋体">
                                                    <input id="Button3" type="button" value="返 回" class="button_css" onclick="history.go(-1)" />
                                                </font>
                                            </div>
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
