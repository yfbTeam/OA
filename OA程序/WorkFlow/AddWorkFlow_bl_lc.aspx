<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddWorkFlow_bl_lc.aspx.cs"
    Inherits="xyoa.WorkFlow.AddWorkFlow_bl_lc" %>

<html>
<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>
<script>
function senduser(str)
{
    window.open("/senduser.aspx?user="+str+"","_blank","height=500, width=600,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=200,left=350");
}

function cbsenduser()
{
    window.open("cbuser.aspx?user=<%=ViewState["CbUser"]%>&name=<%=ViewState["CbName"]%>&Number=<%=Request.QueryString["Number"]%>","_blank","height=380, width=600,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=200,left=350");
}
function select_type()
{
   if ("<%=ViewState["Shuxing"]%>"=="自由流程")
   {
       form1.Button2.style.display='none';  
   }
   else
   {
      form1.Button2.style.display='';     
   }

}

</script>
</head>
<body class="newbody" onload="select_type()">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox></td>
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
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>已办理流程</b></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" nowrap="nowrap">
                                                        <asp:Label ID="Liucheng" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <input id="Button2" type="button" value="查看流程设计图" class="button_css"  onclick='window.open ("AddWorkFlow_show_lc.aspx?FlowNumber=<%=ViewState["FlowNumber"]%>&NodeName=<%=ViewState["NodeName"]%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=50,left=50")'  />
                                                            <input id="Button3" type="button" value="催办与提醒" class="button_css" onclick="cbsenduser()"/>
                                                            <input id="Button1" type="button" value="关 闭" class="button_css" onclick="window.close()"/>
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
