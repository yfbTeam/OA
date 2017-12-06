<%@ Page Language="C#" AutoEventWireup="true" Codebehind="HetongMg_update.aspx.cs"
    Inherits="xyoa.HumanResources.Hetong.HetongMg.HetongMg_update" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Starttime').value=='')
    {
        alert('合同生效日期不能为空');
        form1.Starttime.focus();
        return false;
    }	
    
    if (form1.Qixian.value=="1")
    {
        if(document.getElementById('Endtime').value=='')
        {
            alert('合同终止日期不能为空');
            form1.Endtime.focus();
            return false;
        }	
    }
    
    showwait();	
}  

function select_type()
{
   if (form1.Qixian.value=="2")
   {
       trDept.style.display='none';
   }
   else if (form1.Qixian.value=="1")
   {
       trDept.style.display='';       
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

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <style type="text/css"> 
.mbcss {
border-left:0px;
border-top:0px;
border-right:0px;
border-bottom:1px solid #000000
}
</style>
</head>
<body class="newbody" onload="Settb();Load_Do();select_type();">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox></td>
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
                                                            <a href="HetongMg.aspx">合同管理</a>
                                                            >> 修改合同管理</td>
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
                                                                <font class="shadow_but">合同管理</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            </td>
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
                                                        签约合同：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="LeibieID" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        签定日期：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="QdTime" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd1" width="15%" align="right">
                                                        签约人：
                                                    </td>
                                                    <td class="newtd2" width="35%">
                                                        <asp:Label ID="QyRealname" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="newtd1" width="15%" align="right">
                                                        合同状态：
                                                    </td>
                                                    <td class="newtd2" width="35%">
                                                        <asp:Label ID="Zhuangtai" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd1" width="15%" align="right">
                                                        <font color="red">※</font>合同生效日期：
                                                    </td>
                                                    <td class="newtd2" width="35%">
                                                        <asp:TextBox ID="Starttime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                    </td>
                                                    <td class="newtd1" width="15%" align="right">
                                                        <font color="red">※</font>合同期限：
                                                    </td>
                                                    <td class="newtd2" width="35%">
                                                        <asp:DropDownList ID="Qixian" runat="server" Width="100%" onchange="select_type()">
                                                            <asp:ListItem Value="1">固定期限</asp:ListItem>
                                                            <asp:ListItem Value="2">无固定期限</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="trDept">
                                                    <td class="newtd1" width="15%" align="right">
                                                        <font color="red">※</font>合同终止日期：
                                                    </td>
                                                    <td class="newtd2" width="85%" colspan="3">
                                                        <asp:TextBox ID="Endtime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4">
                                                        <div id="strhtm">
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp;
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
        <asp:TextBox ID="QyUsername" runat="server" TextMode="MultiLine" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ContractContent" runat="server" TextMode="MultiLine" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="HetongZdId" runat="server" Style="display: none"></asp:TextBox>

        <script>
            function   Settb()  
            {  
                document.getElementById("strhtm").innerHTML=document.getElementById("TextBox1").value;
            }   
             
             
            function Load_Do()
            {
                setTimeout("Load_Do()",0);
                var content = document.getElementById("strhtm").innerHTML
                document.getElementById("ContractContent").value=content;  
                document.getElementById("TextBox1").value=document.getElementById("ContractContent").value;
            }
        </script>

    </form>
</body>
</html>
