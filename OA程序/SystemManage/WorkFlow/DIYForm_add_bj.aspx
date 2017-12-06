<%@ Page Language="C#" AutoEventWireup="true" Codebehind="DIYForm_add_bj.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.DIYForm_add_bj" %>

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
    
    if(document.getElementById('kjname').value=='请选择控件')
    {
        alert('请选择控件');
        form1.kjname.focus();
        return false;
    }	
    
   // showwait();	
    insertfile();
}  



function  insertfile()  
{  
    var cValue = document.getElementById('TextBox2').value;
    var csize = document.getElementById('Windnum').value;
    var cvalues = document.getElementById('Vaules').value;
    
    
    if(document.getElementById('kjname').value=='人员选择控件')
    {
    
        if(document.getElementById('Biankuan').value=='下边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>  <input id="Button2"  name="'+cValue+'"  onclick="OpenRyXzFrom('+num+')" style="width: 60px" type="button" value="选择人员" />';
        }
        
        if(document.getElementById('Biankuan').value=='全部边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenRyXzFrom('+num+')" style="width: 60px" type="button" value="选择人员" />';
        }
        
        if(document.getElementById('Biankuan').value=='无边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:0px   solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenRyXzFrom('+num+')" style="width: 60px" type="button" value="选择人员" />';
        }
    
    
    }
    

    if(document.getElementById('kjname').value=='部门选择控件')
    { 
    
        if(document.getElementById('Biankuan').value=='下边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenBmXzFrom('+num+')" style="width: 60px" type="button" value="选择部门" />';
        }
        
        if(document.getElementById('Biankuan').value=='全部边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenBmXzFrom('+num+')" style="width: 60px" type="button" value="选择部门" />';
        }
        
        if(document.getElementById('Biankuan').value=='无边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:0px   solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenBmXzFrom('+num+')" style="width: 60px" type="button" value="选择部门" />';
        }
        
    }
    
    
    if(document.getElementById('kjname').value=='职位选择控件')
    { 
        if(document.getElementById('Biankuan').value=='下边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenZwXzFrom('+num+')" style="width: 60px" type="button" value="选择职位" />';
        }
        
        if(document.getElementById('Biankuan').value=='全部边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenZwXzFrom('+num+')" style="width: 60px" type="button" value="选择职位" />';
        }
        
        if(document.getElementById('Biankuan').value=='无边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:0px   solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenZwXzFrom('+num+')" style="width: 60px" type="button" value="选择职位" />';
        }
    }

    
    if(document.getElementById('kjname').value=='角色选择控件')
    { 
        if(document.getElementById('Biankuan').value=='下边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenJsXzFrom('+num+')" style="width: 60px" type="button" value="选择角色" />';
        }
        
        if(document.getElementById('Biankuan').value=='全部边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenJsXzFrom('+num+')" style="width: 60px" type="button" value="选择角色" />';
        }
        
        if(document.getElementById('Biankuan').value=='无边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:0px   solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenJsXzFrom('+num+')" style="width: 60px" type="button" value="选择角色" />';
        }
    
    }

    if(document.getElementById('kjname').value=='流程所有已经办人')
    { 
        if(document.getElementById('Biankuan').value=='下边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenJbrXzFrom('+num+')" style="width: 60px" type="button" value="已经办人" />';
        }
        
        if(document.getElementById('Biankuan').value=='全部边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenJbrXzFrom('+num+')" style="width: 60px" type="button" value="已经办人" />';
        }
        
        if(document.getElementById('Biankuan').value=='无边框')
        {
            var num=Math.random();
            var str='<input disabled id="'+num+'"  name="'+cValue+'"  type="text" size="'+csize+'" style="border-left:0px;border-top:0px;border-right:0px;border-bottom:0px   solid   #000000"/>  <input id="Button2" name="'+cValue+'"  onclick="OpenJbrXzFrom('+num+')" style="width: 60px" type="button" value="已经办人" />';
        }
    }


   window.opener.qiupengmodel(str);
   //window.close()
}

</script>

<head id="Head1" runat="server">
    <title>宏选择控件</title>
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
                                                        控件长度：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Windnum" runat="server" Width="100%">20</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        初始值：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Vaules" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        选择控件：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="kjname" runat="server" Width="100%">
                                                            <asp:ListItem>请选择控件</asp:ListItem>
                                                            <asp:ListItem>人员选择控件</asp:ListItem>
                                                            <asp:ListItem>部门选择控件</asp:ListItem>
                                                            <asp:ListItem>职位选择控件</asp:ListItem>
                                                            <asp:ListItem>角色选择控件</asp:ListItem>
                                                            <asp:ListItem>流程所有已经办人</asp:ListItem>
                                                        </asp:DropDownList></td>
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
