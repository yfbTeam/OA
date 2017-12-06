<%@ Page Language="C#" AutoEventWireup="true" Codebehind="BaobiaoSj_update.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.BaobiaoSj_update" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script>
function openqiupengmodle()
{
var num=Math.random();
window.open ("/fckeditor/modle.aspx?tmp="+num+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function qiupengmodel(str)
{
var oEditor = FCKeditorAPI.GetInstance('Content') 
oEditor.InsertHtml(''+str+'');
}

//function ziduan()
//{
//    var num=Math.random();
//    var oEditor = FCKeditorAPI.GetInstance('Content');
//    var littleproduct=document.getElementById("FormFile");
//    var cindex = littleproduct.selectedIndex;
//    var cText  = littleproduct.options[cindex].text;
//    var cValue = littleproduct.options[cindex].value;

//    if(cText=="选择字段")
//    {
//        alert('请先选择字段');
//        form1.FormFile.focus();
//        return false;
//    }
//    AjaxMethod.UpdateBaobiao(cValue,'<%=Request.QueryString["id"] %>');
//    oEditor.InsertHtml('['+cText+']');
//}

function  delfile()  
{  

var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;

    if(cText=="已创建公式")
    {
        alert('请选择要删除的公式');
        form1.FormFile.focus();
        return false;
    }

if (!confirm("是否确定删除“"+cText+"”？"))
return false;

}


function ziduan()
{
var num=Math.random();
window.open ("BaobiaoSj_update_gs.aspx?tmp="+num+"&id=<%=Request.QueryString["id"] %>", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}


function  updatefile()  
{  

var num=Math.random();

var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;
if(cText=="已创建公式")
{
alert('请选择公式');
return false;
}
else
{
var str=""+cValue+"";
window.showModalDialog("BaobiaoSj_update_update.aspx?tmp="+num+"&id="+str+"&keyid=<%=Request.QueryString["id"] %>","window", "dialogWidth:460px;DialogHeight=400px;status:no;scroll=yes;help:no");  
}              

}


    </script>

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
                                                            设计报表
                                                        </td>
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
                                                                <font class="shadow_but">设计报表</font></button></td>
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
                                                        报表名称：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Mingcheng" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        对应表单：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Biaodan" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>设计报表</b></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <strong>公式</strong>
                                                        <asp:DropDownList ID="FormFile" runat="server">
                                                        </asp:DropDownList><asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">【刷新】</asp:LinkButton><asp:LinkButton
                                                            ID="LinkButton2" runat="server">[修改]</asp:LinkButton><asp:LinkButton
                                                            ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">【删除】</asp:LinkButton><a
                                                                href="javascript:void(0)" onclick="alert('统计字段允许选择“数字型”的字段。\n\n公式计算：支持每个字段的加减乘除，形如：[字段A]+[字段B]、[字段A]+[字段B]*[字段C]\n\n先设计好统计报表样式，然后再添加公式进表单编辑器中\n\n设计报表字段时，需通过软件的【新增公式】设计')">【说明】</a><input
                                                                    id="Button3" onclick="ziduan()" style="width: 100px" type="button" value="新增公式" /><input
                                                                        id="Button6" onclick="openqiupengmodle()" style="width: 100px" type="button"
                                                                        value="选择常用模版" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4">
                                                        <FCKeditorV2:FCKeditor ID="Content" runat="server" Height="350px" ToolbarSet="Qiupeng1">
                                                        </FCKeditorV2:FCKeditor>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;
                                                                <asp:Button ID="Button4" runat="server" Text="返 回" CssClass="button_css" OnClick="Button4_Click" />
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
