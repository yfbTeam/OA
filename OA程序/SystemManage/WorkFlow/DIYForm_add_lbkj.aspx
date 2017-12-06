<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DIYForm_add_lbkj.aspx.cs" Inherits="xyoa.SystemManage.WorkFlow.DIYForm_add_lbkj" %>

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
 
    if(document.getElementById('kjname').value=='请选择宏控件')
    {
        alert('请选择宏控件');
        form1.kjname.focus();
        return false;
    }	
    
   // showwait();	
    insertfile();
}  



function  insertfile()  
{  
    var cValue1 = document.getElementById('TextBox2').value;
    
    var littleproduct=document.getElementById("kjname");
    var cindex = littleproduct.selectedIndex;
    var cText  = littleproduct.options[cindex].text;
    var cValue = littleproduct.options[cindex].value;
    
    var str='<select name=\"'+cValue1+'\">'+cText+'_'+cValue1+'</select>';
    window.opener.qiupengmodel(str);
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
                                                        <asp:DropDownList ID="kjname" runat="server" Width="312px">
                                                            <asp:ListItem>请选择宏控件</asp:ListItem>
                                                            <asp:ListItem Value="SYS_Lb_Bumen">{宏}部门列表</asp:ListItem>
                                                            <asp:ListItem Value="SYS_Lb_Kehu">{宏}我的客户列表</asp:ListItem>
                                                            <asp:ListItem Value="SYS_Lb_Renyuan">{宏}用户列表</asp:ListItem>
                                                            <asp:ListItem Value="SYS_Lb_Juese">{宏}角色列表</asp:ListItem>
                                                            <asp:ListItem Value="SYS_Lb_Zhiwei">{宏}职位列表</asp:ListItem>
                                                        </asp:DropDownList></td>
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