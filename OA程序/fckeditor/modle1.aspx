<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modle1.aspx.cs" Inherits="xyoa.fckeditor.modle1" %>
<link href="/css/oa.css" type="text/css" rel="stylesheet">
<html>

<script>
function chknull()
{
    if(document.getElementById('DropDownList1').value=='')
    {
        alert('请选择模版');
        form1.DropDownList1.focus();
        return false;
    }	
    insertfile();
}  



function  insertfile()  
{  
    var littleproduct=document.getElementById("DropDownList1");
    var cindex = littleproduct.selectedIndex;
    var cValue = littleproduct.options[cindex].value;
    var str=cValue;
    window.opener.qiupengmodel1(str);
    window.close();
}

</script>

<head id="Head1" runat="server">
    <title>选择模版</title>
</head>
<body class="bodycolor" topmargin="5">
    <form id="form1" runat="server">
        <br>
        <div align="center">
            模版类型：<asp:DropDownList ID="typename" runat="server" AutoPostBack="True" Width="340px">
            </asp:DropDownList>
            <hr>
            模版名称：<asp:DropDownList ID="DropDownList1" runat="server" Width="340px">
            </asp:DropDownList>
            <hr>
            <input id="Button1" type="button" value="提 交" class="button_css" onclick="chknull()" />
            <input id="Button3" type="button" value="关 闭" class="button_css" onclick="window.close()" />
            <hr>
        </div>
    </form>
</body>
</html>
