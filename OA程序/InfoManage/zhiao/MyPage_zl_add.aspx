﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyPage_zl_add.aspx.cs"
    Inherits="xyoa.InfoManage.zhiao.MyPage_zl_add" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.js"></script>

    <script type="text/javascript">
        $(document).ready(function(){
           $("#btnAddFile").bind("click",function(){
              $(this).before("<div><input type='file' id='file'  name='file' /><input  type='button' value='移除' onclick='RemoveFile(this)'/></div>"); 
           });
        });
        function RemoveFile(obj){
           $(obj).parent().remove(); 
        }
    </script>

    <script>
function chknull()
{
    if(document.getElementById('LeibieName').value=='')
    {
        alert('请选择所属类别');
        form1.LeibieName.focus();
        return false;
    }	

    showwait();	
}  

function select_type()
{
   if (form1.States.value=="1")
   {
       trDept.style.display='none';
       trUser.style.display='none';
   }
   else if (form1.States.value=="2")
   {
       trDept.style.display='';       
       trUser.style.display='none';
   }
   else if (form1.States.value=="3")
   {
       trDept.style.display='none';
       trUser.style.display='';
   }
}


    </script>

</head>
<body class="newbody" onload="select_type();">
  <form id="form1" runat="server" enctype="multipart/form-data">
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>所属类别：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="LeibieName" runat="server" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="opencp();" alt="" src="/oaimg/FDJ.gif" border="0"></a></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        附件：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <div><input type='file' id='file' name='file' /></div>
                                                        <input type="button" value="添加上传框" id="btnAddFile" />
                                                        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        开放范围：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="States" runat="server" Width="100%" onchange="select_type()">
                                                            <asp:ListItem Value="1">全部</asp:ListItem>
                                                            <asp:ListItem Value="2">对指定部门开放</asp:ListItem>
                                                            <asp:ListItem Value="3">对指定人员开放</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr id="trDept" style="display: none">
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        选择部门（对指定部门开放）：</td>
                                                    <td class="newtd2" colspan="3" width="85%" style="height: 17px">
                                                        <asp:TextBox ID="ZdBumen" runat="server" Height="58px" TextMode="MultiLine" Width="85%"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openunit();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="trUser" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        选择人员（对指定人员开放）：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="ZdRealname" runat="server" Width="85%" Height="58px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button2" runat="server" Text="上 传" CssClass="button_css" OnClick="Button2_Click" />
                                                                <asp:Button ID="Button1" runat="server" CssClass="button_css" OnClick="Button1_Click"
                                                                    Text="返 回" /></font></div>
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
        <asp:TextBox ID="Leibie" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ZdBumenId" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ZdUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	
            var  wName_2;  
            function  openunit()  
            {  
            var num=Math.random();
            var str=""+document.getElementById('ZdBumenId').value+"";
            wName_2=window.showModalDialog("/OpenWindows/open_bumen_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
            if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
            for(var i=0;i<arr.length;i++)
            { 
            document.getElementById("ZdBumenId").value=arr[0]; 
            document.getElementById("ZdBumen").value=arr[1]; 
            }


            }



            var  wName_1;  
            function  openuser1()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('ZdUsername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("ZdUsername").value=arr[0]; 
                    document.getElementById("ZdRealname").value=arr[1]; 
                }
            }
            
            
        </script>

        <script>
         
            function  opencp()  
            {
                var  wName_2;  
                var num=Math.random();
                var clid=""+document.getElementById('Leibie').value+"";
                wName_2=window.showModalDialog("/OpenWindows/Openleibie_zl.aspx?tmp="+num+"&id="+clid+"","window", "dialogWidth:780px;DialogHeight=660px;status:no;scroll=yes;help:no");                
                if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("Leibie").value=arr[0]; 
                    document.getElementById("LeibieName").value=arr[1]; 
                    document.getElementById("States").value=arr[2]; 
                    document.getElementById("ZdBumenId").value=arr[3]; 
                    document.getElementById("ZdBumen").value=arr[4]; 
                    document.getElementById("ZdUsername").value=arr[5]; 
                    document.getElementById("ZdRealname").value=arr[6]; 
                }
                
                select_type();
            }
        </script>

    </form>
</body>
</html>
