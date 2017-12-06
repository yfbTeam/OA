<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DIYForm_add_sp.aspx.cs" Inherits="xyoa.SystemManage.WorkFlow.DIYForm_add_sp" %>

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
        alert('控件宽度不能为空，默认为40');
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
    
    if(document.getElementById('Heignum').value=='')
    {
        alert('控件高度不能为空，默认为5');
        form1.Heignum.focus();
        return false;
    }	
   
    if(document.getElementById('Heignum').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('Heignum').value))
        {
            alert("控件高度只能为正整数");
            form1.Heignum.focus();
            return false;
        }
    }
    
    
   // showwait();	
    insertfile();
}  



function  insertfile()  
{  
    var cValue = document.getElementById('TextBox2').value;
    var csize = document.getElementById('Windnum').value;
    var ccols = document.getElementById('Heignum').value;
    
    if(document.getElementById('Biankuan').value=='下边框')
    {
        var str='<textarea disabled id="'+cValue+'" name="'+cValue+'"   ondblclick="opensetsp('+cValue+')"  cols="'+csize+'" rows="'+ccols+'"  style="font-size:'+document.getElementById('ITEM_SIZE').value+';SCROLLBAR-FACE-COLOR:   #AAAAAA;   SCROLLBAR-HIGHLIGHT-COLOR:   #D8D8D8;  SCROLLBAR-SHADOW-COLOR:   #D8D8D8;   SCROLLBAR-3DLIGHT-COLOR:   #D8D8D8;   SCROLLBAR-ARROW-COLOR:   #D8D8D8;   SCROLLBAR-TRACK-COLOR:   #D8D8D8;   SCROLLBAR-DARKSHADOW-COLOR:   #D8D8D8; border-left:0px;border-top:0px;border-right:0px;border-bottom:1px   solid   #000000 " ></textarea>';
        window.opener.qiupengmodel(str);
        //window.close()
    }
    
    if(document.getElementById('Biankuan').value=='全部边框')
    {
        var str='<textarea disabled id="'+cValue+'" name="'+cValue+'"   ondblclick="opensetsp('+cValue+')"  cols="'+csize+'" rows="'+ccols+'"  style="font-size:'+document.getElementById('ITEM_SIZE').value+';SCROLLBAR-FACE-COLOR:   #AAAAAA;   SCROLLBAR-HIGHLIGHT-COLOR:   #D8D8D8;  SCROLLBAR-SHADOW-COLOR:   #D8D8D8;   SCROLLBAR-3DLIGHT-COLOR:   #D8D8D8;   SCROLLBAR-ARROW-COLOR:   #D8D8D8;   SCROLLBAR-TRACK-COLOR:   #D8D8D8;   SCROLLBAR-DARKSHADOW-COLOR:   #D8D8D8;  solid   #000000 " ></textarea>';
        window.opener.qiupengmodel(str);
        //window.close()
    }
    
    if(document.getElementById('Biankuan').value=='无边框')
    {
        var str='<textarea disabled id="'+cValue+'" name="'+cValue+'"   ondblclick="opensetsp('+cValue+')"  cols="'+csize+'" rows="'+ccols+'"  style="font-size:'+document.getElementById('ITEM_SIZE').value+';SCROLLBAR-FACE-COLOR:   #AAAAAA;   SCROLLBAR-HIGHLIGHT-COLOR:   #D8D8D8;  SCROLLBAR-SHADOW-COLOR:   #D8D8D8;   SCROLLBAR-3DLIGHT-COLOR:   #D8D8D8;   SCROLLBAR-ARROW-COLOR:   #D8D8D8;   SCROLLBAR-TRACK-COLOR:   #D8D8D8;   SCROLLBAR-DARKSHADOW-COLOR:   #D8D8D8; border-left:0px;border-top:0px;border-right:0px;border-bottom:0px   solid   #000000 " ></textarea>';
        window.opener.qiupengmodel(str);
       // window.close()
    }
    

}

</script>

<head id="Head1" runat="server">
    <title>文本输入框</title>
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
                                                        控件宽度：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Windnum" runat="server" Width="100%">40</asp:TextBox>
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
                                                        控件高度：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Heignum" runat="server" Width="100%">5</asp:TextBox>
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