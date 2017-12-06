<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Chaxun_Ss.aspx.cs" Inherits="xyoa.SchTable.Sushe.Chaxun.Chaxun_Ss" %>

<html>

<script>
function chknull()
{
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
                                        <asp:Label ID="Xueqi" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="Xueduan" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="Label1" runat="server" Text="请先选择宿舍" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server">
                                    <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                                
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
