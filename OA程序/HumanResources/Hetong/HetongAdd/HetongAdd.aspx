<%@ Page Language="C#" AutoEventWireup="true" Codebehind="HetongAdd.aspx.cs" Inherits="xyoa.HumanResources.Hetong.HetongAdd.HetongAdd" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <style type="text/css"> 
#content { overflow:auto; height:480px; width:220px; } 

.mbcss {
border-left:0px;
border-top:0px;
border-right:0px;
border-bottom:1px solid #000000
}
</style>

    <script>
function chknull()
{
    if(document.getElementById('LeibieID').value=='')
    {
        alert('签约合同不能为空');
        form1.LeibieID.focus();
        return false;
    }	

    if(document.getElementById('QdTime').value=='')
    {
        alert('签定日期不能为空');
        form1.QdTime.focus();
        return false;
    }	
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
    var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
	}
	
	if(a>0)
	{

    }
	else
	{
		alert('请选中签约人员，如果你想选择，请点击人员前的选择框即可');
		return false;
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

</head>
<body class="newbody" onload="Settb();Load_Do();select_type();">
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
                            <td>
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
                                                        <td colspan="2">
                                                            <strong><font color="blue">合同新签：选择[签约合同]以后将自动根据设置的模版生成合同。人员列表只显示在职的员工。</font></strong></td>
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
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                        </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td class="newtd2" valign="top" width="220">
                                                        <div align="center">
                                                            <strong>
                                                                <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">[已签约]</asp:LinkButton><asp:LinkButton
                                                                    ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">[未签约]</asp:LinkButton></strong>
                                                        </div>
                                                        <hr />
                                                        <div id="content">
                                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                                            <asp:TreeView ID="ListTreeView" runat="server" NodeIndent="10" ShowLines="True">
                                                            </asp:TreeView>
                                                        </div>
                                                    </td>
                                                    <td class="newtd2" valign="top">
                                                        <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                            <tr>
                                                                <td class="newtd1" width="15%" align="right">
                                                                    <font color="red">※</font>签约合同：</td>
                                                                <td class="newtd2" width="35%">
                                                                    <asp:DropDownList ID="LeibieID" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="LeibieID_SelectedIndexChanged">
                                                                    </asp:DropDownList></td>
                                                                <td class="newtd1" width="15%" align="right">
                                                                    <font color="red">※</font>签定日期：</td>
                                                                <td class="newtd2" width="35%">
                                                                    <asp:TextBox ID="QdTime" runat="server" onClick="WdatePicker()"></asp:TextBox>
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
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" valign="top" colspan="2" height="20px">
                                                        <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" /></td>
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

        <script type="text/javascript">
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

        <asp:TextBox ID="HetongZdId" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ContractContent" runat="server" TextMode="MultiLine" Style="display: none"></asp:TextBox>

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
