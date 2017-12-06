<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_add_yz_add.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.WorkFlowName_show_add_yz_add" %>

<html>

<script>
function killErrors() {
return true;
}
window.onerror = killErrors;	

function chknull()
{
    if(document.getElementById('yinzhang').value=='请选择')
    {
        alert('请选择印章域');
        form1.yinzhang.focus();
        return false;
    }	
    
    if(document.getElementById('SyRealname').value=='')
    {
        alert('允许使用人员不能为空');
        form1.SyRealname.focus();
        return false;
    }	    
    showwait();	
}  
				

</script>

<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <base target="_self" />
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
                                                        印章域名：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="yinzhang" runat="server" Width="90%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                        <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        使用步骤：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="NodeName" runat="server" Width="90%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        允许使用人员：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="SyRealname" runat="server" Height="55px" TextMode="MultiLine" Width="85%" CssClass="ReadOnlyText"></asp:TextBox>
                                                          <input id="Button2" type="button" value="选择人员" onclick="openuser1();" />
                                                        <input id="Button4" type="button" value="全部人员" onclick="quanbu();" />
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;<input id="Button3" class="button_css" onclick="javascript:window.close()"
                                                                    type="button" value="关 闭" />
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
        <asp:TextBox ID="FormId" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowId" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FormNumber" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="SyUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	

var  wName_1;  
function  openuser1()  
{  
var num=Math.random();
var str=""+document.getElementById('SyUsername').value+"";
wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("SyUsername").value=arr[0]; 
document.getElementById("SyRealname").value=arr[1]; 
}
}

function  quanbu()  
{  
document.getElementById("SyUsername").value='全部人员'; 
document.getElementById("SyRealname").value='全部人员';
}

        </script>

    </form>
</body>
</html>
