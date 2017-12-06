<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ResourcesAdd_add.aspx.cs"
    Inherits="xyoa.Resources.ResSet.ResourcesAdd_add" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('ZyNum').value=='')
    {
        alert('物品编号不能为空');
        form1.ZyNum.focus();
        return false;
    }	


    if(document.getElementById('Cangku').value=='')
    {
        alert('所属仓库不能为空');
        form1.Cangku.focus();
        return false;
    }	
    
    if(document.getElementById('Quyu').value=='')
    {
        alert('所属区域不能为空');
        form1.Quyu.focus();
        return false;
    }	
    
    if(document.getElementById('ZyName').value=='')
    {
        alert('物品名称不能为空');
        form1.ZyName.focus();
        return false;
    }	
    
    
    
    if(document.getElementById('Danjia').value=='')
    {
        alert('单价不能为空，没有请填为0');
        form1.Danjia.focus();
        return false;
    }
    
    if(document.getElementById('Danjia').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Danjia').value))
        {
            alert("单价只能为正数");
            form1.Danjia.focus();
            return false;
        }
    }   
    

    if(document.getElementById('KuCun').value=='')
    {
        alert('当前库存不能为空，没有请填为0');
        form1.KuCun.focus();
        return false;
    }	
 
 
    if(document.getElementById('KuCun').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('KuCun').value))
        {
            alert("当前库存只能为正数");
            form1.KuCun.focus();
            return false;
        }

    }   
    
    
    if(document.getElementById('LimitsS').value=='')
    {
        alert('库警上限不能为空，没有请填为0');
        form1.LimitsS.focus();
        return false;
    }
    
    if(document.getElementById('LimitsS').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('LimitsS').value))
        {
            alert("库警上限只能为正数");
            form1.LimitsS.focus();
            return false;
        }
    }   


    if(document.getElementById('LimitsE').value=='')
    {
        alert('库警下限不能为空，没有请填为０');
        form1.LimitsE.focus();
        return false;
    }
    
    if(document.getElementById('LimitsE').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('LimitsE').value))
        {
            alert("库警下限只能为正数");
            form1.LimitsE.focus();
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

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

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
                                                            <a href="ResourcesAdd.aspx">物品登记</a>
                                                            >> 新增物品登记</td>
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
                                                                <font class="shadow_but">物品登记</font></button></td>
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
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>基本信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>物品编号：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="ZyNum" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>物品名称：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="ZyName" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        物品型号：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="Xinghao" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        物品描述：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="ZyIntro" runat="server" Width="100%" Height="101px" TextMode="MultiLine"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        <font color="red">※</font>物品类别：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:DropDownList ID="ZyLeibie" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        <font color="red">※</font>物品性质：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:DropDownList ID="ZyXingzhi" runat="server" Width="100%">
                                                            <asp:ListItem Value="1">消耗品</asp:ListItem>
                                                            <asp:ListItem Value="2">借用品</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        <font color="red">※</font>所属仓库：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:DropDownList ID="Cangku" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        <font color="red">※</font>所属区域：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:DropDownList ID="Quyu" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>物品状态：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:DropDownList ID="Zhuangtai" runat="server" Width="100%">
                                                            <asp:ListItem Value="1">正常</asp:ListItem>
                                                            <asp:ListItem Value="2">丢失</asp:ListItem>
                                                            <asp:ListItem Value="3">停用</asp:ListItem>
                                                            <asp:ListItem Value="4">维修</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        计量单位：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:TextBox ID="Danwei" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        <font color="red">※</font>单价：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:TextBox ID="Danjia" runat="server" Width="100%">0</asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        供应商：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:TextBox ID="Gongyinshang" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        <font color="red">※</font>总库存：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:TextBox ID="KuCun" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        <font color="red">※</font>库警上限：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:TextBox ID="LimitsS" runat="server" Width="100%"></asp:TextBox></td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        <font color="red">※</font> 库警下限：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:TextBox ID="LimitsE" runat="server" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        相片：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <input id="uploadFile" runat="server" name="uploadFile" style="width: 383px" type="file" />
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="返 回" OnClick="Button2_Click" /></font></div>
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
