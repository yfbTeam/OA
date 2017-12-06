<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ZaijiSheng_dr.aspx.cs"
    Inherits="xyoa.SchTable.Xueji.ZaijiSheng.ZaijiSheng_dr" %>

<html>

<script>
function chknull()
{
    var strUploadFile=document.getElementById('fileExcel').value;
    if (strUploadFile=="")
    {
        alert("提示:\r您还没有选择上传的文件！"); 
        return false;
    } 
    showwait();	
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
                                                导入“<asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>”学生信息【<a href="学生信息.xls" target="_blank">标准表格下载</a>】
                                            </td>
                                        </tr>
                                        <tr class="" id="nextrs23">
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                导入文档：</td>
                                            <td class="newtd2" height="17" width="85%" colspan="3">
                                                <input id="fileExcel" runat="server" style="width: 383px" type="file" name="fileExcel" />
                                            </td>
                                        </tr>
                                        <tr id="printshow3">
                                            <td align="center" class="newtd2" colspan="8" height="26" width="33%">
                                                <div align="center">
                                                    <font face="宋体">
                                                        <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                    </font>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            </table><asp:TextBox ID="Number" runat="server" Visible="false"></asp:TextBox>
    </form>
</body>
</html>
