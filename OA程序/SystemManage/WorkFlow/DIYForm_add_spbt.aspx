<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DIYForm_add_spbt.aspx.cs" Inherits="xyoa.SystemManage.WorkFlow.DIYForm_add_spbt" %>
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
    
    if(document.getElementById('Windnum').value=='')
    {
        alert('请填写关联文本框');
        form1.Windnum.focus();
        return false;
    }	

    insertfile();
}  



function  insertfile()  
{  
    var cValue = document.getElementById('Windnum').value;
    var cVaID = document.getElementById('TextBox2').value;
    
    var str='<input id="'+cVaID+'" name="'+cVaID+'" type="button" onclick="opensetsp('+cValue+')" value="办理意见" />';
    window.opener.qiupengmodel(str);
}

</script>

<head id="Head1" runat="server">
    <title>文本输入框</title>
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
                                                        关联文本框：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Windnum" runat="server" Width="100%"></asp:TextBox>
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