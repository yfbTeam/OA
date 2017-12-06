<%@ Page Language="C#" AutoEventWireup="true" Codebehind="DIYForm_add_kj.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.DIYForm_add_kj" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
        alert('控件名称不能为空');
        form1.Name.focus();
        return false;
    }	
    
    if(document.getElementById('Windnum').value=='')
    {
        alert('控件宽度不能为空，默认为20');
        form1.Windnum.focus();
        return false;
    }	
   
    if(document.getElementById('Windnum').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Windnum').value))
        {
            alert("控件宽度只能为正整数");
            form1.Windnum.focus();
            return false;
        }
    }
    
    if(document.getElementById('kjname').value=='请选择宏控件')
    {
        alert('请选择宏控件');
        form1.kjname.focus();
        return false;
    }	
    
   // showwait();	
    insertfile();
}  



function  insertfile()  
{  
    var cValue1 = document.getElementById('TextBox2').value;
    var csize = document.getElementById('Windnum').value;
    
    var littleproduct=document.getElementById("kjname");
    var cindex = littleproduct.selectedIndex;
    var cText  = littleproduct.options[cindex].text;
    var cValue = littleproduct.options[cindex].value;

    if(document.getElementById('Biankuan').value=='下边框')
    {
        var str='<input disabled id="'+cValue1+'"  name="'+cValue1+'" size="'+csize+'"  type="text"  dataFld="'+cValue+'_'+cValue1+'" value="'+cText+'" style="font-size:'+document.getElementById('ITEM_SIZE').value+';border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>';
        window.opener.qiupengmodel(str);
        //window.close()
    }
    
    if(document.getElementById('Biankuan').value=='全部边框')
    {
        var str='<input disabled id="'+cValue1+'"  name="'+cValue1+'" size="'+csize+'"  type="text"  dataFld="'+cValue+'_'+cValue1+'" value="'+cText+'" style="font-size:'+document.getElementById('ITEM_SIZE').value+';solid   #000000"/>';
        window.opener.qiupengmodel(str);
        //window.close()
    }
    
    if(document.getElementById('Biankuan').value=='无边框')
    {
        var str='<input disabled id="'+cValue1+'"  name="'+cValue1+'" size="'+csize+'"  type="text"  dataFld="'+cValue+'_'+cValue1+'" value="'+cText+'" style="font-size:'+document.getElementById('ITEM_SIZE').value+';border-left:0px;border-top:0px;border-right:0px;border-bottom:0px   solid   #000000"/>';
        window.opener.qiupengmodel(str);
        //window.close()
    }


}

</script>

<head id="Head1" runat="server">
    <title>宏控件设置</title>
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
                                                        控件名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Name" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        选择宏控件：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="kjname" runat="server" Width="312px">
                                                            <asp:ListItem>请选择宏控件</asp:ListItem>
                                                            <asp:ListItem Value="SYS_realname">{宏}用户姓名</asp:ListItem>
                                                            <asp:ListItem Value="SYS_Unit">{宏}用户部门短名称</asp:ListItem>
                                                            <asp:ListItem Value="SYS_Respon">{宏}用户角色</asp:ListItem>
                                                            <asp:ListItem Value="SYS_Post">{宏}用户职位</asp:ListItem>
                                                            <asp:ListItem Value="SYS_UnitZgA">{宏}用户部门主管(本部门)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_UnitZgB">{宏}用户部门主管(上级部门)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_UnitZgC">{宏}用户部门主管(一级部门)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateTime">{宏}当前日期(形如2009-1-1)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateYear">{宏}当前日期(年)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateMonth">{宏}当前日期(月)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateDate">{宏}当前日期(日)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateHour">{宏}当前日期(时)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateMinute">{宏}当前日期(分)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateSecond">{宏}当前日期(秒)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateDayOfWeek">{宏}当前日期(星期)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateATime">{宏}当前日期(形如2009年1月1日)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateBTime">{宏}当前日期(形如2009年1月)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateCTime">{宏}当前日期(形如1月1日)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateDTime">{宏}当前时间(形如12:12:12)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_DateETime">{宏}当前时间(形如2009-12-12 12:12:12)</asp:ListItem>
                                                            <asp:ListItem Value="SYS_username">{宏}用户ID</asp:ListItem>
                                                            <asp:ListItem Value="SYS_RRDateDate">{宏}用户的姓名+日期</asp:ListItem>
                                                            <asp:ListItem Value="SYS_RRDateTime">{宏}用户的姓名+具体日期时间</asp:ListItem>
                                                            <asp:ListItem Value="SYS_IpAddress">{宏}经办人IP</asp:ListItem>
                                                            <asp:ListItem Value="SYS_bdmc">{宏}表单名称</asp:ListItem>
                                                            <asp:ListItem Value="SYS_mcwh">{宏}名称/文号</asp:ListItem>
                                                            <asp:ListItem Value="SYS_lcksrq">{宏}流程开始日期</asp:ListItem>
                                                            <asp:ListItem Value="SYS_lckssj">{宏}流程开始的日期+时间</asp:ListItem>
                                                            <asp:ListItem Value="SYS_lsh">{宏}流水号</asp:ListItem>
                                                            <asp:ListItem Value="SYS_AllJbrA">{宏}当前步骤主办人</asp:ListItem>
                                                            <asp:ListItem Value="SYS_AllJbrB">{宏}当前步骤所有经办人</asp:ListItem>
                                                            <asp:ListItem Value="SYS_AllYbr">{宏}所有已经办人员</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        控件长度：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Windnum" runat="server" Width="100%">20</asp:TextBox>
                                                    </td>
                                                </tr>
                                                       <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        字体大小：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="ITEM_SIZE" runat="server" Width="100%"  title="可选，默认14像素">14</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        字段类型：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="Type" runat="server" Width="100%">
                                                            <asp:ListItem>[常规型]</asp:ListItem>
                                                            <asp:ListItem>[数字型]</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        控件边框：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="Biankuan" runat="server" Width="100%">
                                                            <asp:ListItem>下边框</asp:ListItem>
                                                            <asp:ListItem>全部边框</asp:ListItem>
                                                            <asp:ListItem>无边框</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <input id="Button3" type="button" value="关 闭" class="button_css" onclick="window.close()" /></font></div>
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
        <asp:TextBox ID="TextBox2" runat="server" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>
