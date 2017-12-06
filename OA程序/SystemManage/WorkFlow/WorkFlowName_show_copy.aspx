<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_copy.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.WorkFlowName_show_copy" %>

<html>

<script>
function  aaa()  
{
    if(document.getElementById('FlowNumber').value=='请选择')
    {
        alert('请选择流程');
        return false;
    }
    else
    {
        var num=Math.random();
        var littleproduct=document.getElementById("FlowNumber");
        var cindex = littleproduct.selectedIndex;
        var cValue = littleproduct.options[cindex].value;
        window.open ("WorkFlowName_show_add_node.aspx?tmp="+num+"&FlowNumber="+cValue+"", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")             
    }
}			

function  chknull()  
{
    if(document.getElementById('FlowNumber').value=='请选择')
    {
        alert('请选择流程');
        return false;
    }
}	

</script>

<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
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
                                                    <td class="newtd2" height="17" width="85%" align="center">
                                                        选择工作流：<asp:DropDownList ID="FlowNumber" runat="server" Width="227px">
                                                        </asp:DropDownList>［<a href="javascript:void(0)" onclick="aaa()">查看流程</a>］</td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                                 <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="返 回" OnClick="Button2_Click" />
                                                            </font>
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
        <asp:TextBox ID="FormNumber" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FormName" runat="server" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>
