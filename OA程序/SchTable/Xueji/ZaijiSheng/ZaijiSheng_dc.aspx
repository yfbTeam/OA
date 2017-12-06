<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ZaijiSheng_dc.aspx.cs"
    Inherits="xyoa.SchTable.Xueji.ZaijiSheng.ZaijiSheng_dc" %>

<html>


<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>
<script>
function CopyTable()
{
 var txt = document.body.createTextRange();
txt.moveToElementText(oTable);   

txt.select();

txt.execCommand("copy","",null); // 复制
}


</script>
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
                            <td height="35">
                                <asp:Panel ID="Panel1" runat="server">
                                    <div align="center">
                                        <asp:Label ID="Label1" runat="server" Text="请先选择班级" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server">
                                    <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                        <tr id="Tr1">
                                            <td class="newtd2" colspan="8" height="26" width="33%">
                                                导出“<asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>”学生信息
                                            </td>
                                        </tr>
                                        <tr id="printshow3">
                                            <td align="center" class="newtd2" colspan="8" height="26" width="33%">
                                                <div align="center">
                                                    <font face="宋体">
                                                        <asp:Button ID="Button1" runat="server" Text="导出学生信息表" CssClass="button_css" OnClick="Button1_Click" />
                                                        <input id="Button2" type="button" value="复制学生信息表"  onclick="CopyTable()" class="button_css"/>
                                                    </font>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr id="Tr2">
                                            <td align="center" class="newtd2" colspan="8" height="26" width="33%">
                                                <asp:Label ID="LTongji" runat="server"></asp:Label>
                                             
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
