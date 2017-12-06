<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_add_node_tjsz_update.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.WorkFlowName_show_add_node_tjsz_update" %>

<html>

<script>
function killErrors() {
return true;
}
window.onerror = killErrors;	

function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('名称不能为空');
    form1.Name.focus();
    return false;
    }	
    
    if(document.getElementById('JudgeBasis').value=='')
    {
    alert('判断依据不能为空');
    form1.JudgeBasis.focus();
    return false;
    }	    
    
    if(document.getElementById('Type').value=='[数字型]')
    {
    var objRe = /^[-+]?\d+(\.\d+)?$/;
    if(!objRe.test(document.getElementById('JudgeBasis').value))
    {
    alert('字段为[数字型]，判断依据必须为数字');
    form1.JudgeBasis.focus();
    return false;
    }
    }      
    
    
    if(document.getElementById('Type').value=='[常规型]')
    {
        if(document.getElementById('Conditions').value=='>'||document.getElementById('Conditions').value=='>='||document.getElementById('Conditions').value=='<='||document.getElementById('Conditions').value=='<'||document.getElementById('Conditions').value=='=')
        {
          alert('常规型不能使用比较符号');
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
                                                        字段名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Name" runat="server" Width="85%" CssClass="ReadOnlyText"></asp:TextBox><a
                                                            href="javascript:void(0)"><img onclick="openunit()" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        字段类型：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="Type" runat="server" Width="100%" CssClass="ReadOnlyText"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        条件判断：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:DropDownList ID="Conditions" runat="server" Width="100%">
                                                            <asp:ListItem Value="&gt;">大于</asp:ListItem>
                                                            <asp:ListItem Value="&gt;=">大于且等于</asp:ListItem>
                                                            <asp:ListItem Value="==">等于</asp:ListItem>
                                                            <asp:ListItem Value="&lt;">小于</asp:ListItem>
                                                            <asp:ListItem Value="&lt;=">小于且等于</asp:ListItem>
                                                            <asp:ListItem>包含</asp:ListItem>
                                                            <asp:ListItem>不包含</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        关联机制：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:DropDownList ID="JudgeType" runat="server" Width="100%">
                                                            <asp:ListItem Value="">无</asp:ListItem>
                                                            <asp:ListItem Value="&&">和</asp:ListItem>
                                                            <asp:ListItem Value="||">或</asp:ListItem>
                                                        </asp:DropDownList>
                                                        排列到最后一个条件就选择“无”，否则程序无法运行。例如AA和BB和CC，那么CC的关联机制就选择“无”
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        判断依据：
                                                    </td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:TextBox ID="JudgeBasis" runat="server" Width="100%"></asp:TextBox></td>
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
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FormNumber" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FormId" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FormName" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowId" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowNumber" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowName" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="KeyID" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	
var  wName_1;  
function  openunit()  
{  
var num=Math.random();
var str=""+document.getElementById('Number').value+"|"+document.getElementById('Name').value+"|"+document.getElementById('Type').value+"";
FormNumber=document.getElementById('FormNumber').value;
wName_1=window.showModalDialog("/OpenWindows/open_FormFile.aspx?tmp="+num+"&FlowId=<%=Request.QueryString["FlowId"] %>&requeststr="+str+"&FormNumber="+FormNumber+"","window", "dialogWidth:400px;DialogHeight=480px;status:no;scroll=yes;help:no");                
if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("Number").value=arr[0]; 
document.getElementById("Name").value=arr[1]; 
document.getElementById("Type").value=arr[2]; 

}
}
        </script>

    </form>
</body>
</html>
