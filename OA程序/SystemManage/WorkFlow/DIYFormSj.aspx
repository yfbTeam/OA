<%@ Page Language="C#" AutoEventWireup="true" Codebehind="DIYFormSj.aspx.cs" Inherits="xyoa.SystemManage.WorkFlow.DIYFormSj" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<html>

<script>
	window.resizeTo(screen.availWidth, screen.availHeight);
	window.moveTo(0, 0);
		
function closefrom()
{
    msg='确定关闭表单设计器吗？';
    if(window.confirm(msg))
    {
        window.close();
    }
    else
    {
        return false;
    }
}


function chknull()
{
    if(document.getElementById('FormName').value=='')
    {
    alert('表单名称为空');
    form1.FormName.focus();
    return false;
    }	


    if(document.getElementById('paixu').value=='')
    {
        alert('排序号不能为空，没有请填写为0');
        form1.paixu.focus();
        return false;
    }	
 
    if(document.getElementById('paixu').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('paixu').value))
        {
            alert("排序号只能为数字");
            form1.paixu.focus();
            return false;
        }
    }  
    showwait();					
}


function formset(str)
{
var oEditor = FCKeditorAPI.GetInstance('d_content') 
var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cValue = littleproduct.options[cindex].value;

//常规控件
if(str=="1")
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_cg.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=420px, width=617px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

if(str=="2")
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_wb.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=420px, width=617px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

if(str=="3")
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_fxk.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=420px, width=617px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

if(str=="12")
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_sz.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=420px, width=617px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

if(str=="13")
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_rq.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=420px, width=617px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}


if(str=="20")
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_sp.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=350px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

if(str=="21")
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_spbt.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=350px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

}



function  updatefile()  
{  

var num=Math.random();

var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;
if(cText=="常规表单字段")
{
alert('此选项不能修改');
return false;
}
else
{

var str=""+cValue+"";
window.showModalDialog("DIYForm_add_update.aspx?tmp="+num+"&Number="+str+"","window", "dialogWidth:460px;DialogHeight=400px;status:no;scroll=yes;help:no");  
}              

}


function  delfile()  
{  
var num=Math.random();

var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;
if(cText=="常规表单字段")
{
alert('此选项不能修改');
return false;
}
else
{
if (!confirm("是否确定删除“"+cText+"”？"))
return false;


var str=""+cValue+"";
window.showModalDialog("DIYForm_add_del.aspx?tmp="+num+"&Number="+str+"","window", "dialogWidth:1px;DialogHeight=1px;status:no;scroll=yes;help:no");  
}  



}


function openqiupengmodle()
{
var num=Math.random();
window.open ("/fckeditor/modle.aspx?tmp="+num+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function qiupengmodel(str)
{
var oEditor = FCKeditorAPI.GetInstance('d_content') 
oEditor.InsertHtml(''+str+'');
}





function openfile()
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_kj.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function openfile1()
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_bj.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}


function openlb()
{
var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cValue = littleproduct.options[cindex].value;

var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_lb.aspx?tmp="+num+"&Number="+str+"&cValue="+cValue+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}


function openyz()
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_yz.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function openlist()
{
var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cValue = littleproduct.options[cindex].value;

var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_list.aspx?tmp="+num+"&Number="+str+"&cValue="+cValue+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}

function opendxlist()
{
var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cValue = littleproduct.options[cindex].value;

var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_dxlist.aspx?tmp="+num+"&Number="+str+"&cValue="+cValue+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}

function openfxlist()
{
var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cValue = littleproduct.options[cindex].value;

var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_fxlist.aspx?tmp="+num+"&Number="+str+"&cValue="+cValue+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}


function openbiaodan()
{
var littleproduct=document.getElementById("FormFile");
var cindex = littleproduct.selectedIndex;
var cValue = littleproduct.options[cindex].value;

var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_bd.aspx?tmp="+num+"&Number="+str+"&cValue="+cValue+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}

function formKk(str)
{
    //可监控控件-常规
    if(str=="1")
    {
        var num=Math.random();
        var str  = document.getElementById("Number").value;
        window.open ("DIYForm_add_jk.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=420px, width=617px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
    }

    //可监控控件-数字
    if(str=="2")
    {
        var num=Math.random();
        var str  = document.getElementById("Number").value;
        window.open ("DIYForm_add_jksz.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=420px, width=617px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
    }
    
    
    //可监控控件-文本
    if(str=="3")
    {
        var num=Math.random();
        var str  = document.getElementById("Number").value;
        window.open ("DIYForm_add_jkwb.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=420px, width=617px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
    }
    
    //可监控控件-下拉列表
    if(str=="4")
    {
        var littleproduct=document.getElementById("FormFile");
        var cindex = littleproduct.selectedIndex;
        var cValue = littleproduct.options[cindex].value;

        var num=Math.random();
        var str  = document.getElementById("Number").value;
        window.open ("DIYForm_add_jklb.aspx?tmp="+num+"&Number="+str+"&cValue="+cValue+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
     }
}

function openfilezdy()
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_zdy.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function openfilelb()
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_lbkj.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function openfilejs()
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_js.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=417px, width=657px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function opendaxie()
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_dx.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=420px, width=617px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}
function spyjgl()
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_spyj.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=420px, width=617px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function openfilelbjh()
{
var num=Math.random();
var str  = document.getElementById("Number").value;
window.open ("DIYForm_add_qh.aspx?tmp="+num+"&Number="+str+"", "_blank", "height=417px, width=657px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
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
<body class="newbody" onload="aaa();bbb()">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
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
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td colspan="2">
                                                            <strong><font color="blue">表单智能设计器：首先，将网页设计工具或Word编辑好的表格框架粘贴到表单设计区或者通过表单设计器设计，然后，创建表单控件。</font></strong>&nbsp;</td>
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
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0" height="100%">
                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellpadding="0" cellspacing="0" height="100%">
                                    <tr>
                                        <td width="17">
                                        </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" height="100%"
                                                class="nextpage">
                                                <tr>
                                                    <td align="center" class="newtd2" nowrap="nowrap" rowspan="4" style="width: 14%"
                                                        valign="top">
                                                        <strong>已增字段<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">[刷新]</asp:LinkButton><asp:LinkButton
                                                            ID="LinkButton2" runat="server">[修改]</asp:LinkButton><asp:LinkButton ID="LinkButton4"
                                                                runat="server">[删除]</asp:LinkButton></strong>
                                                        <hr />
                                                        <asp:DropDownList ID="FormFile" runat="server" Width="95%">
                                                        </asp:DropDownList><br />
                                                        表单的自定义字段<br />
                                                        可以在此处修编辑
                                                        <hr />
                                                        <asp:CheckBox ID="CheckBox1" runat="server" onclick="aaa()" Text="<strong>标准控件</strong>" />
                                                        <div id="bzkj" style="display: none">
                                                            <hr />
                                                            <input id="Button2" onclick="formset(1)" style="width: 100px" type="button" value="单行常规输入框" />
                                                            <br />
                                                            <br />
                                                            <input id="Button14" onclick="formset(12)" style="width: 100px" type="button" value="数字输入框" />
                                                            <br />
                                                            <br />
                                                            <input id="Button4" onclick="formset(2)" style="width: 100px" type="button" value="多行文本输入框" /><br />
                                                            <br />
                                                            <input id="Button15" onclick="formset(13)" style="width: 100px" type="button" value="日期选择控件" />
                                                            <br />
                                                            <br />
                                                            <input id="Button10" onclick="openlb()" style="width: 100px" type="button" value="下拉列表控件" />
                                                            <br />
                                                            <br />
                                                            <input id="Button11" onclick="opendxlist()" style="width: 100px" type="button" value="单选框列表控件" />
                                                            <br />
                                                            <br />
                                                            <input id="Button13" onclick="openfxlist()" style="width: 100px" type="button" value="复选框列表控件" />
                                                            <br />
                                                            <br />
                                                            <input id="Button21" onclick="openbiaodan()" style="width: 100px" type="button" value="表单域控件" />
                                                            <br />
                                                            <br />
                                                            <input id="Button3" onclick="openfile1()" style="width: 100px" type="button" value="选择类控件" />
                                                            <br />
                                                            <br />
                                                            <input id="Button7" onclick="openyz()" style="width: 100px" type="button" value="印章域控件" />
                                                            <br />
                                                            <br />
                                                            <input id="Button17" onclick="formset(21)" style="width: 100px" type="button" value="审批控件" />
                                                            <br />
                                                            <br />
                                                            <input id="Button25" onclick="spyjgl()" style="width: 100px" type="button" value="审批意见关联" />
                                                            <br />
                                                            <br />
                                                        </div>
                                                        <hr />
                                                        <asp:CheckBox ID="CheckBox2" runat="server" onclick="bbb()" Text="<strong>可监控控件</strong>" />
                                                        <div id="jkkj" style="display: none">
                                                            <hr />
                                                            <input id="Button16" onclick="formKk(1)" style="width: 100px" type="button" value="常规输入框" />
                                                            <br />
                                                            <br />
                                                            <input id="Button18" onclick="formKk(2)" style="width: 100px" type="button" value="数字输入框" />
                                                            <br />
                                                            <br />
                                                            <input id="Button19" onclick="formKk(3)" style="width: 100px" type="button" value="文本输入框" />
                                                            <br />
                                                            <br />
                                                            <input id="Button20" onclick="formKk(4)" style="width: 100px" type="button" value="下拉列表控件" />
                                                            <br />
                                                            <br />
                                                        </div>
                                                        <hr />
                                                        <strong>宏控件</strong>
                                                        <hr />
                                                        <input id="Button12" onclick="openfile()" style="width: 100px" type="button" value="文本框宏控件" />
                                                        <br />
                                                        <br />
                                                        <input id="Button23" onclick="openfilelb()" style="width: 100px" type="button" value="下拉列表宏控件" />
                                                        <br />
                                                        <br />
                                                        <hr />
                                                        <strong>其他控件</strong>
                                                        <hr />
                                                        <input id="Button22" onclick="openfilejs()" style="width: 100px" type="button" value="计算控件" />
                                                        <br />
                                                        <br />
                                                        <input id="Button24" onclick="opendaxie()" style="width: 100px" type="button" value="小写转大写控件" />
                                                        <br />
                                                        <br />
                                                        <input id="Button9" onclick="openlist()" style="width: 100px" type="button" value="列表控件" />
                                                        <br />
                                                        <br />
                                                        <input id="Button26" onclick="openfilelbjh()" style="width: 100px" type="button"
                                                            value="列表求和控件" />
                                                        <br />
                                                        <br />
                                                        <hr />
                                                        <strong>表单模版</strong>
                                                        <hr />
                                                        <input id="Button6" onclick="openqiupengmodle()" style="width: 100px" type="button"
                                                            value="表单常用模版" />
                                                        <br />
                                                        <hr />
                                                        <strong>操作按钮</strong>
                                                        <hr />
                                                        <asp:Button ID="Button5" runat="server" Text="保存表单不关闭" OnClick="Button5_Click" />
                                                        <br />
                                                        <br />
                                                        <asp:Button ID="Button1" runat="server" Text="保存表单并关闭" OnClick="Button1_Click" />
                                                        <br />
                                                        <br />
                                                        <input id="Button8" type="button" value="关闭表单设计器" onclick="closefrom()" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" valign="top">
                                                        类别：<asp:DropDownList ID="FormType" runat="server" Width="90%">
                                                        </asp:DropDownList><br>
                                                        <br>
                                                        排序：<asp:TextBox ID="paixu" runat="server" Width="90%"></asp:TextBox>
                                                        <br>
                                                        <br>
                                                        名称：<asp:TextBox ID="FormName" runat="server" Width="85%" MaxLength="10"></asp:TextBox>(10字符)<br>
                                                        <br>
                                                        <FCKeditorV2:FCKeditor ID="d_content" runat="server" Height="85%" ToolbarSet="Qiupeng">
                                                        </FCKeditorV2:FCKeditor>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="30">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>

        <script>
            function aaa()
            {   
                if(document.getElementById('CheckBox1').checked)
                {
                   document.getElementById('bzkj').style.display="";
                }
                else
                {
                   document.getElementById('bzkj').style.display="none";
                }
            }

            function bbb()
            {   
                if(document.getElementById('CheckBox2').checked)
                {
                   document.getElementById('jkkj').style.display="";
                }
                else
                {
                   document.getElementById('jkkj').style.display="none";
                }
            }
        </script>

    </form>
</body>
</html>
