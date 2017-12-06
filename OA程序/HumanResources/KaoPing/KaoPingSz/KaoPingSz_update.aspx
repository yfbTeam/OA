<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KaoPingSz_update.aspx.cs" Inherits="xyoa.HumanResources.KaoPing.KaoPingSz.KaoPingSz_update" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<html>

<script>
function formset()
{
    var oEditor = FCKeditorAPI.GetInstance('Neirong');
    oEditor.InsertHtml('<input type="text" class="mbcss" style="mbcss" disabled="disabled"/>');
}


function chknull()
{
    if(document.getElementById('Leixing').value=='')
    {
        alert('考评类型不能为空');
        form1.Leixing.focus();
        return false;
    }	

    
    if(document.getElementById('Zongfen').value=='')
    {
        alert('考评总分不能为空');
        form1.Zongfen.focus();
        return false;
    }	

    if(document.getElementById('Zongfen').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Zongfen').value))
        {
            alert('考评总分只能为正整数');
            form1.Zongfen.focus();
            return false;
        }
    }   
    
    
    
    if(document.getElementById('QuanzhongMy').value=='')
    {
        alert('自我考评权重不能为空');
        form1.QuanzhongMy.focus();
        return false;
    }	

    if(document.getElementById('QuanzhongMy').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('QuanzhongMy').value))
        {
            alert('自我考评权重只能为正整数');
            form1.QuanzhongMy.focus();
            return false;
        }
    }   

   if (form1.Jishu.value=="1")
   {
        if(document.getElementById('Name1').value=='')
        {
            alert('1级考评人不能为空');
            form1.Name1.focus();
            return false;
        }
        
        if(document.getElementById('Quanzhong1').value=='')
        {
            alert('1级权重不能为空');
            form1.Quanzhong1.focus();
            return false;
        }	
   }
   else if (form1.Jishu.value=="2")
   {
    if(document.getElementById('Name1').value=='')
    {
        alert('1级考评人不能为空');
        form1.Name1.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong1').value=='')
    {
        alert('1级权重不能为空');
        form1.Quanzhong1.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong1').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong1').value))
        {
            alert('1级权重只能为正整数');
            form1.Quanzhong1.focus();
            return false;
        }
    }   

    if(document.getElementById('Name2').value=='')
    {
        alert('2级考评人不能为空');
        form1.Name2.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong2').value=='')
    {
        alert('2级权重不能为空');
        form1.Quanzhong2.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong2').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong2').value))
        {
            alert('2级权重只能为正整数');
            form1.Quanzhong2.focus();
            return false;
        }
    }  
   }
   else if (form1.Jishu.value=="3")
   {
 
    if(document.getElementById('Name1').value=='')
    {
        alert('1级考评人不能为空');
        form1.Name1.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong1').value=='')
    {
        alert('1级权重不能为空');
        form1.Quanzhong1.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong1').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong1').value))
        {
            alert('1级权重只能为正整数');
            form1.Quanzhong1.focus();
            return false;
        }
    }   

    if(document.getElementById('Name2').value=='')
    {
        alert('2级考评人不能为空');
        form1.Name2.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong2').value=='')
    {
        alert('2级权重不能为空');
        form1.Quanzhong2.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong2').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong2').value))
        {
            alert('2级权重只能为正整数');
            form1.Quanzhong2.focus();
            return false;
        }
    }  

    if(document.getElementById('Name3').value=='')
    {
        alert('3级考评人不能为空');
        form1.Name3.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong3').value=='')
    {
        alert('3级权重不能为空');
        form1.Quanzhong3.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong3').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong3').value))
        {
            alert('3级权重只能为正整数');
            form1.Quanzhong3.focus();
            return false;
        }
    }  
   }
   else if (form1.Jishu.value=="4")
   {

   
    if(document.getElementById('Name1').value=='')
    {
        alert('1级考评人不能为空');
        form1.Name1.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong1').value=='')
    {
        alert('1级权重不能为空');
        form1.Quanzhong1.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong1').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong1').value))
        {
            alert('1级权重只能为正整数');
            form1.Quanzhong1.focus();
            return false;
        }
    }   

    if(document.getElementById('Name2').value=='')
    {
        alert('2级考评人不能为空');
        form1.Name2.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong2').value=='')
    {
        alert('2级权重不能为空');
        form1.Quanzhong2.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong2').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong2').value))
        {
            alert('2级权重只能为正整数');
            form1.Quanzhong2.focus();
            return false;
        }
    }  

    if(document.getElementById('Name3').value=='')
    {
        alert('3级考评人不能为空');
        form1.Name3.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong3').value=='')
    {
        alert('3级权重不能为空');
        form1.Quanzhong3.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong3').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong3').value))
        {
            alert('3级权重只能为正整数');
            form1.Quanzhong3.focus();
            return false;
        }
    }  

    if(document.getElementById('Name4').value=='')
    {
        alert('4级考评人不能为空');
        form1.Name4.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong4').value=='')
    {
        alert('4级权重不能为空');
        form1.Quanzhong4.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong4').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong4').value))
        {
            alert('4级权重只能为正整数');
            form1.Quanzhong4.focus();
            return false;
        }
    }  
   }
   else if (form1.Jishu.value=="5")
   {
  
    if(document.getElementById('Name1').value=='')
    {
        alert('1级考评人不能为空');
        form1.Name1.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong1').value=='')
    {
        alert('1级权重不能为空');
        form1.Quanzhong1.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong1').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong1').value))
        {
            alert('1级权重只能为正整数');
            form1.Quanzhong1.focus();
            return false;
        }
    }   

    if(document.getElementById('Name2').value=='')
    {
        alert('2级考评人不能为空');
        form1.Name2.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong2').value=='')
    {
        alert('2级权重不能为空');
        form1.Quanzhong2.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong2').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong2').value))
        {
            alert('2级权重只能为正整数');
            form1.Quanzhong2.focus();
            return false;
        }
    }  

    if(document.getElementById('Name3').value=='')
    {
        alert('3级考评人不能为空');
        form1.Name3.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong3').value=='')
    {
        alert('3级权重不能为空');
        form1.Quanzhong3.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong3').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong3').value))
        {
            alert('3级权重只能为正整数');
            form1.Quanzhong3.focus();
            return false;
        }
    }  

    if(document.getElementById('Name4').value=='')
    {
        alert('4级考评人不能为空');
        form1.Name4.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong4').value=='')
    {
        alert('4级权重不能为空');
        form1.Quanzhong4.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong4').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong4').value))
        {
            alert('4级权重只能为正整数');
            form1.Quanzhong4.focus();
            return false;
        }
    }  
    
    if(document.getElementById('Name5').value=='')
    {
        alert('5级考评人不能为空');
        form1.Name5.focus();
        return false;
    }
    
    if(document.getElementById('Quanzhong5').value=='')
    {
        alert('5级权重不能为空');
        form1.Quanzhong5.focus();
        return false;
    }	

    if(document.getElementById('Quanzhong5').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Quanzhong5').value))
        {
            alert('5级权重只能为正整数');
            form1.Quanzhong5.focus();
            return false;
        }
    }  
   }

    showwait();	
}  

function openqiupengmodle()
{
var num=Math.random();
window.open ("/fckeditor/modle.aspx?tmp="+num+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function qiupengmodel(str)
{
var oEditor = FCKeditorAPI.GetInstance('Neirong') 
oEditor.InsertHtml(''+str+'');
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

    <script>
function select_type()
{
   if (form1.Jishu.value=="1")
   {
       kpstep1.style.display='';
       kpstep2.style.display='none';
       kpstep3.style.display='none';
       kpstep4.style.display='none';
       kpstep5.style.display='none';
   }
   else if (form1.Jishu.value=="2")
   {
       kpstep1.style.display='';
       kpstep2.style.display='';
       kpstep3.style.display='none';
       kpstep4.style.display='none';
       kpstep5.style.display='none';
   }
   else if (form1.Jishu.value=="3")
   {
       kpstep1.style.display='';
       kpstep2.style.display='';
       kpstep3.style.display='';
       kpstep4.style.display='none';
       kpstep5.style.display='none';
   }
   else if (form1.Jishu.value=="4")
   {
       kpstep1.style.display='';
       kpstep2.style.display='';
       kpstep3.style.display='';
       kpstep4.style.display='';
       kpstep5.style.display='none';
   }
   else if (form1.Jishu.value=="5")
   {
       kpstep1.style.display='';
       kpstep2.style.display='';
       kpstep3.style.display='';
       kpstep4.style.display='';
       kpstep5.style.display='';
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
                                                            <a href="KaoPingSz.aspx">考评设置</a>
                                                            >> 修改考评设置</td>
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
                                                                <font class="shadow_but">考评设置</font></button></td>
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
                                                        考评类型：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Leixing" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        考评总分：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Zongfen" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        考评级数：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:DropDownList ID="Jishu" runat="server" onchange="select_type()" Width="100%">
                                                            <asp:ListItem Value="1">1级</asp:ListItem>
                                                            <asp:ListItem Value="2">2级</asp:ListItem>
                                                            <asp:ListItem Value="3">3级</asp:ListItem>
                                                            <asp:ListItem Value="4">4级</asp:ListItem>
                                                            <asp:ListItem Value="5">5级</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        考评模版内容(<a href="javascript:void(0)" onclick="openqiupengmodle()">模版</a>)：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <input id="Button3" type="button" value="插入输入框" onclick="formset()"/>
                                                        <FCKeditorV2:FCKeditor ID="Neirong" runat="server" Height="250px" ToolbarSet="Qiupeng1">
                                                        </FCKeditorV2:FCKeditor>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        自我考评权重：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="QuanzhongMy" runat="server" Width="95%"></asp:TextBox>&nbsp;%
                                                    </td>
                                                </tr>
                                                <tr id="kpstep1" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        1级考评人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Name1" runat="server" Width="90%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        1级权重：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Quanzhong1" runat="server" Width="90%"></asp:TextBox>&nbsp;%
                                                    </td>
                                                </tr>
                                                <tr id="kpstep2" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        2级考评人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Name2" runat="server" Width="90%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser2();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        2级权重：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Quanzhong2" runat="server" Width="90%"></asp:TextBox>&nbsp;%
                                                    </td>
                                                </tr>
                                                <tr id="kpstep3" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        3级考评人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Name3" runat="server" Width="90%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser3();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        3级权重：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Quanzhong3" runat="server" Width="90%"></asp:TextBox>&nbsp;%
                                                    </td>
                                                </tr>
                                                <tr id="kpstep4" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        4级考评人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Name4" runat="server" Width="90%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser4();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        4级权重：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Quanzhong4" runat="server" Width="90%"></asp:TextBox>&nbsp;%
                                                    </td>
                                                </tr>
                                                <tr id="kpstep5" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        5级考评人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Name5" runat="server" Width="90%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser5();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        5级权重：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Quanzhong5" runat="server" Width="90%"></asp:TextBox>&nbsp;%
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css"
                                                                    OnClick="Button2_Click" />
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
        <asp:TextBox ID="User1" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="User2" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="User3" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="User4" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="User5" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	
            function  openuser1()  
            {   
                var  wName_1;
                var num=Math.random();
                var str=""+document.getElementById('User1').value+"|"+document.getElementById('Name1').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("User1").value=arr[0]; 
                    document.getElementById("Name1").value=arr[1]; 
                }
            }

            function  openuser2()  
            {   
                var  wName_1;
                var num=Math.random();
                var str=""+document.getElementById('User2').value+"|"+document.getElementById('Name2').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("User2").value=arr[0]; 
                    document.getElementById("Name2").value=arr[1]; 
                }
            }

            function  openuser3()  
            {   
                var  wName_1;
                var num=Math.random();
                var str=""+document.getElementById('User3').value+"|"+document.getElementById('Name3').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("User3").value=arr[0]; 
                    document.getElementById("Name3").value=arr[1]; 
                }
            }
            
            function  openuser4()  
            {   
                var  wName_1;
                var num=Math.random();
                var str=""+document.getElementById('User4').value+"|"+document.getElementById('Name4').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("User4").value=arr[0]; 
                    document.getElementById("Name4").value=arr[1]; 
                }
            }
            
            function  openuser5()  
            {   
                var  wName_1;
                var num=Math.random();
                var str=""+document.getElementById('User5').value+"|"+document.getElementById('Name5').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("User5").value=arr[0]; 
                    document.getElementById("Name5").value=arr[1]; 
                }
            }
        </script>

    </form>
</body>
</html>