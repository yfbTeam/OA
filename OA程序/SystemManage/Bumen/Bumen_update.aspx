<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Bumen_update.aspx.cs" Inherits="xyoa.SystemManage.Bumen.Bumen_update" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('部门名不能为空');
    form1.Name.focus();
    return false;
    }
    
    if(document.getElementById('Bianhao').value=='')
    {
        alert('排序号不能为空，没有请填写为0');
        form1.Bianhao.focus();
        return false;
    }	
 
    if(document.getElementById('Bianhao').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Bianhao').value))
        {
            alert("排序号只能为数字");
            form1.Bianhao.focus();
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

</head>
<body class="newbody">
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
                                                        <b>部门信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>排序号：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Bianhao" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>部门名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Name" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>上级部门名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="ParentNodesID" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        部门主管：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="BmRealname" runat="server" Width="85%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        备注：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="remark" runat="server" Width="90%" MaxLength="200"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                            <input id="Button2" type="button" value="返 回" onclick="history.go(-1)" class="button_css" />
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
        <asp:TextBox ID="BmUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="QxString1" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="Linew1" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="ParentNodes" runat="server" Visible="False"></asp:TextBox>

        <script language="javascript">	


            var  wName_3;  
            function  openuser()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('BmUsername').value+"|"+document.getElementById('BmRealname').value+"";
                wName_3=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("BmUsername").value=arr[0]; 
                    document.getElementById("BmRealname").value=arr[1]; 
                }
            }

        </script>

    </form>
</body>
</html>
