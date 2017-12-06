<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Folders_update.aspx.cs"
    Inherits="xyoa.MyWork.wjk.Folders_update" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('文件夹名不能为空');
    form1.Name.focus();
    return false;
    }	
    showwait();	
}

function select_type()
{
   if (form1.IfShare.value=="1")
   {
       trDept.style.display='';
   }
   else if(form1.IfShare.value=="2")
   {
       trDept.style.display='none';
   }
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
                                                        <b>文件夹信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>文件夹名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Name" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        上级节点名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="ParentNodesID" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        是否共享：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:DropDownList ID="IfShare" runat="server" Width="100%" onchange="select_type()">
                                                            <asp:ListItem Value="2">否</asp:ListItem>
                                                            <asp:ListItem Value="1">是</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr id="trDept" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        共享人员：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="GxRealname" runat="server" Width="100%" Height="55px" TextMode="MultiLine" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <input id="Button3" type="button" value="选择人员" onclick="openuser();" />
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" /></font>&nbsp;<asp:Button
                                                                    ID="Button2" runat="server" CssClass="button_css" OnClick="Button2_Click" Text="返 回" /></div>
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
        <asp:TextBox ID="GxUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ParentNodes" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="QxString1" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="Linew1" runat="server" Visible="False"></asp:TextBox>

        <script language="javascript">	
            var  wName_3;  
            function  openuser()  
            {  
            
                if(document.getElementById('IfShare').value=='2')
                {
                alert('请先选择共享文件夹');
                form1.IfShare.focus();
                return false;
                }	
            
                var num=Math.random();
                var str=""+document.getElementById('GxUsername').value+"";
                wName_3=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("GxUsername").value=arr[0]; 
                    document.getElementById("GxRealname").value=arr[1]; 
                }
            }

        </script>

    </form>
</body>
</html>
