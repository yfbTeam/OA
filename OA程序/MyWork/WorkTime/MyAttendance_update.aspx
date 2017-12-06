<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyAttendance_update.aspx.cs"
    Inherits="xyoa.MyWork.WorkTime.MyAttendance_update" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Subject').value=='')
    {
        alert('事由不能为空');
        form1.Subject.focus();
        return false;
    }	
    

    if(document.getElementById('StartTime').value=='')
    {
        alert('开始时间不能为空');
        form1.StartTime.focus();
        return false;
    }	
    
    if(document.getElementById('EndTime').value=='')
    {
        alert('结束时间不能为空');
        form1.EndTime.focus();
        return false;
    }	  
    
    if(document.getElementById('DiffTime').value=='')
    {
        alert('<%=ViewState["diffname"] %>不能为空');
        form1.DiffTime.focus();
        return false;
    }	
   
    if(document.getElementById('DiffTime').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('DiffTime').value))
        {
            alert('<%=ViewState["diffname"] %>只能为数字');
            form1.DiffTime.focus();
            return false;
        }
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
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow1">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                </td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="MyAttendance.aspx?type=<%=Request.QueryString["type"].ToString() %>">
                                                                <%=ViewState["typename"] %>
                                                            </a>>> 修改<%=ViewState["typename"] %></td>
                                                        <td width="81%">
                                                            </td>
                                                    </tr>
                                                </table>
                                                <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" class="nexttop">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
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
                                <div id="printshow2">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                </td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">
                                                                    <%=ViewState["typename"] %>
                                                                </font>
                                                            </button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                        <input onclick='window.open ("/WorkFlowSysMag/AddWorkFlow_show_lc.aspx?FormId=<%=ViewState["FormId"]%>&DqNodeId=<%=ViewState["DqNodeId"]%>&DqNodeName=<%=ViewState["DqNodeName"]%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'
                                                                type="button" value="办理流程图" id="Button11" class="button_css"> </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>事由：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Subject" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>开始时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="StartTime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                      
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>结束时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="EndTime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                       
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <%=ViewState["diffname"] %>
                                                        ：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="DiffTime" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        登记人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Realname" runat="server" Width="100%" CssClass="ReadOnlyText"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        备注：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Beizhu" runat="server" Width="100%" Height="70px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        审批状态：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="LcZhuangtai" runat="server" Width="100%" CssClass="ReadOnlyText"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体"> <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;
                                                                <input id="Button2" type="button" value="返 回" onclick="history.go(-1)" class="button_css" />
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
        <asp:TextBox ID="TDiffTime" runat="server" Style="display: none"></asp:TextBox>


    </form>
</body>
</html>
