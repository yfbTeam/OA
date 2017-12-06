<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DIYForm_add_zdy.aspx.cs" Inherits="xyoa.SystemManage.WorkFlow.DIYForm_add_zdy" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
        alert('控件名称不能为空');
        form1.Name.focus();
        return false;
    }	
    
    if(document.getElementById('sqlstr').value=='')
    {
        alert('SQL语句不能为空');
        form1.sqlstr.focus();
        return false;
    }	
    insertfile();
}  



function  insertfile()  
{  
   var str='#'+document.getElementById('Name').value+'-自定义宏控件#';
   window.opener.qiupengmodel(str);
}

function my_tip()
{
   if(document.getElementById("tip").style.display=="none")
      document.getElementById("tip").style.display="";
   else
   	  document.getElementById("tip").style.display="none";
}
</script>

<head id="Head1" runat="server">
    <title>宏控件设置</title>
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        控件名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Name" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        选择宏控件：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="leixing" runat="server" Width="312px">
                                                            <asp:ListItem Value="1">文本框</asp:ListItem>
                                                            <asp:ListItem Value="2">下拉列表框</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                 <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        SQL语句：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="sqlstr" runat="server" Width="100%"></asp:TextBox>
                                                        <a href="javascript:my_tip()">查看说明</a>
                                                    </td>
                                                </tr>
                                                  <tr id="tip" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        说明：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        系统提供关键字：<br>
                                                        [用户姓名]、[用户登录名]、[部门名称]、
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <input id="Button3" type="button" value="关 闭" class="button_css" onclick="window.close()" /></font></div>
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
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>
