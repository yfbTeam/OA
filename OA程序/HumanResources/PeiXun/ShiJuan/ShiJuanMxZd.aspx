<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ShiJuanMxZd.aspx.cs" Inherits="xyoa.HumanResources.PeiXun.ShiJuan.ShiJuanMxZd" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Shumu1').value=='')
    {
        alert('题目数目不能为空');
        form1.Shumu1.focus();
        return false;
    }
    
    if(document.getElementById('Shumu1').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Shumu1').value))
        {
            alert("题目数目只能为正数");
            form1.Shumu1.focus();
            return false;
        }
    }   
    
    if(document.getElementById('Fenzhi1').value=='')
    {
        alert('每题分值不能为空');
        form1.Fenzhi1.focus();
        return false;
    }	
 
    if(document.getElementById('Fenzhi1').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Fenzhi1').value))
        {
            alert("每题分值只能为数字");
            form1.Fenzhi1.focus();
            return false;
        }
    }  

    if(document.getElementById('Shumu2').value=='')
    {
        alert('题目数目不能为空');
        form1.Shumu2.focus();
        return false;
    }
    
    if(document.getElementById('Shumu2').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Shumu2').value))
        {
            alert("题目数目只能为正数");
            form1.Shumu2.focus();
            return false;
        }
    }   
    
    if(document.getElementById('Fenzhi2').value=='')
    {
        alert('每题分值不能为空');
        form1.Fenzhi2.focus();
        return false;
    }	
 
    if(document.getElementById('Fenzhi2').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Fenzhi2').value))
        {
            alert("每题分值只能为数字");
            form1.Fenzhi2.focus();
            return false;
        }
    }  
    

    if(document.getElementById('Shumu3').value=='')
    {
        alert('题目数目不能为空');
        form1.Shumu3.focus();
        return false;
    }
    
    if(document.getElementById('Shumu3').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Shumu3').value))
        {
            alert("题目数目只能为正数");
            form1.Shumu3.focus();
            return false;
        }
    }   
    
    if(document.getElementById('Fenzhi3').value=='')
    {
        alert('每题分值不能为空');
        form1.Fenzhi3.focus();
        return false;
    }	
 
    if(document.getElementById('Fenzhi3').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Fenzhi3').value))
        {
            alert("每题分值只能为数字");
            form1.Fenzhi3.focus();
            return false;
        }
    }  
    
    if(document.getElementById('Shumu4').value=='')
    {
        alert('题目数目不能为空');
        form1.Shumu4.focus();
        return false;
    }
    
    if(document.getElementById('Shumu4').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Shumu4').value))
        {
            alert("题目数目只能为正数");
            form1.Shumu4.focus();
            return false;
        }
    }   
    
    if(document.getElementById('Fenzhi4').value=='')
    {
        alert('每题分值不能为空');
        form1.Fenzhi4.focus();
        return false;
    }	
 
    if(document.getElementById('Fenzhi4').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Fenzhi4').value))
        {
            alert("每题分值只能为数字");
            form1.Fenzhi4.focus();
            return false;
        }
    }  
    
    if(document.getElementById('Shumu5').value=='')
    {
        alert('题目数目不能为空');
        form1.Shumu5.focus();
        return false;
    }
    
    if(document.getElementById('Shumu5').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Shumu5').value))
        {
            alert("题目数目只能为正数");
            form1.Shumu5.focus();
            return false;
        }
    }   
    
    if(document.getElementById('Fenzhi5').value=='')
    {
        alert('每题分值不能为空');
        form1.Fenzhi5.focus();
        return false;
    }	
 
    if(document.getElementById('Fenzhi5').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Fenzhi5').value))
        {
            alert("每题分值只能为数字");
            form1.Fenzhi5.focus();
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
                                                            <a href="ShiJuan.aspx">试卷管理</a>
                                                            >> 新增试卷明细(按题库类别随机出题)</td>
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
                                                                <font class="shadow_but">试卷明细</font></button></td>
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
                                                        题库类别：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="MingchengID" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        对应试卷：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="ShijuanID" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <strong>
                                                            <img src="/oaimg/sfind.png" />单选题</strong></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>题目数目：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Shumu1" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>每题分值：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Fenzhi1" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <strong>
                                                            <img src="/oaimg/sfind.png" />多选题</strong></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>题目数目：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Shumu2" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>每题分值：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Fenzhi2" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <strong>
                                                            <img src="/oaimg/sfind.png" />判断题</strong></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>题目数目：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Shumu3" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>每题分值：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Fenzhi3" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <strong>
                                                            <img src="/oaimg/sfind.png" />填空题</strong></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>题目数目：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Shumu4" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>每题分值：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Fenzhi4" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <strong>
                                                            <img src="/oaimg/sfind.png" />问答题</strong></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>题目数目：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Shumu5" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>每题分值：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Fenzhi5" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp;
                                                                <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css" OnClick="Button2_Click" />
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
    </form>
</body>
</html>
