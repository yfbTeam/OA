<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Fenxi3.aspx.cs" Inherits="xyoa.HumanResources.Fenxi.Peixun.Fenxi3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script>
function check_form()
{
    if(document.form1.FqRealname.value=="")
    {
        alert("请选择需要统计人员！");
        form1.FqRealname.focus();
        return false;
    }
    showwait();	
}
    </script>

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
                                                            考试查询
                                                        </td>
                                                        <td width="16%">
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <div>
                                                <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                    <tr>
                                                        <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                            <b>统计信息</b></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            <font color="red">※</font>统计人员：</td>
                                                        <td class="newtd2" height="17" colspan="3" width="83%">
                                                            <asp:TextBox ID="FqRealname" runat="server" Width="90%" CssClass="ReadOnlyText" Height="61px"
                                                                TextMode="MultiLine"></asp:TextBox>
                                                            <a href="javascript:void(0)">
                                                                <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            考试主题：</td>
                                                        <td class="newtd2" height="17" width="83%" colspan="3">
                                                            <asp:TextBox ID="Zhuti" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            考试生效日期：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:TextBox ID="Starttime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                           至<asp:TextBox ID="Endtime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="newtd2" width="33%" style="height: 17px" colspan="4" align="center">
                                                            <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="查询结果" OnClick="Button2_Click" /></td>
                                                    </tr>
                                                </table>
                                                &nbsp;
                                            </div>
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
        <asp:TextBox ID="FqUsername" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	
            var  wName_1;  
            function  openuser1()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('FqUsername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("FqUsername").value=arr[0]; 
                    document.getElementById("FqRealname").value=arr[1]; 
                }
            }
            
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
