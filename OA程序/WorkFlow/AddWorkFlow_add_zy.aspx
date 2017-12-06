<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddWorkFlow_add_zy.aspx.cs"
    Inherits="xyoa.WorkFlow.AddWorkFlow_add_zy" %>

<html>

<script>
function openyz()
{
    //控件宽
    var aw = 420;
    //控件高
    var ah = 320;
    //计算控件水平位置
    var al = (screen.width - aw)/2-100;
    //计算控件垂直位置
    var at = (screen.height - ah)/5;
    
    mytop=screen.availHeight-500;
    myleft=200;
    window.open("WorkFlowListSpYzQp.aspx?Number=<%=ViewState["YzSealNumber"]%>&NodeName=<%=ViewState["NodeName"]%>","_blank","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");

}
        
     
function  AddFile()  
{
    if(document.getElementById('wdname').value=='')
    {
        alert('文档名称不允许为空');
        form1.wdname.focus();
        return false;
    }
    showwait();	
}
     
        
        
function  down()  
{
    if(document.getElementById('fjlb').value=='')
    {
        alert('未选中文件');
        return false;
    }
    else
    {
        var num=Math.random();
        var littleproduct=document.getElementById("fjlb");
        var cindex = littleproduct.selectedIndex;
        var cText  = littleproduct.options[cindex].text;
        var cValue = littleproduct.options[cindex].value;
        window.open ("/file_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
       
    }


}

function  delfj()  
{
    if(document.getElementById('fjlb').value=='')
    {
        alert('未选中文件');
        return false;
    }
    else
    {
        if (!confirm("是否确定要删除？"))
        return false;

        showwait();	
        var num=Math.random();
        var littleproduct=document.getElementById("fjlb");
        var cindex = littleproduct.selectedIndex;
        var cText  = littleproduct.options[cindex].text;
        var cValue = littleproduct.options[cindex].value;
        window.showModalDialog("/file_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1px;DialogHeight=1px;status:no;scroll=yes;help:no");                
    }
}			

        
        
   
function zxcheck()
{

    if(document.getElementById('fjlb').value=='')
    {
        alert('未选种编辑文件');
        return false;
    }
    else
    {
        var littleproduct=document.getElementById("fjlb");
        var cindex = littleproduct.selectedIndex;
        var cValue = littleproduct.options[cindex].value;
        var picOK=false;
        var nameLen=cValue.length;
        var rightName=cValue.substr(nameLen-4,4).toLowerCase();
        if (nameLen>0)
        {
            if (  rightName==".doc"  ||   rightName==".DOC"    ||   rightName==".xls"    ||   rightName==".XLS"  ||   rightName==".ppt"    ||   rightName==".PPT"    )
            { 
                picOK=true;
                var num= document.getElementById("Number").value;
                var tmp=Math.random();
                window.open("Document_online.aspx?tmp="+tmp+"&number="+num+"&file="+cValue+"&filetype="+rightName+"&NodeName=<%=ViewState["NodeName"]%>","newwindow","height=700, width=960, top=0, left=30, toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no");
            
          
            }

            if (picOK==false)
            { 
                alert("提示:\r只能编辑.doc|.xls|.ppt|格式的文件！");
                return(false);
            }
        }
    }
}

function _change()
{
   var text=form1.normalcontent.value;
   if (text !="请选择")
   {
       document.getElementById('SpContent').value +="\r\n"+text;
   }
}
   
   
function checkForm()
{

    var strUploadFile=document.getElementById('uploadFile').value;

    if (strUploadFile=="")
    {
        alert("提示:\r您还没有选择上传的文件！"); 
        return false;
    } 
    var nameLen=strUploadFile.length;
    var rightName=strUploadFile.substr(nameLen-4,4).toLowerCase();

    var sAllowExt = "<%=Session["FjKey"]%>";
    var str = document.getElementById('uploadFile').value;
    var rightName=str.substr(str.lastIndexOf('.')+1,str.length - str.lastIndexOf('.')).toLowerCase();

    if(sAllowExt!=="*")
    {
        if(sAllowExt.indexOf(rightName)==-1)
        {
	        alert('格式不对，只能上传'+sAllowExt+'\r如需要上传其他格式文件，请联系管理员！');
	        return false;
        }
    }
    showwait();	

}

  
  
function  zcun()  
{
    if(document.getElementById('fjlb').value=='')
    {
        alert('未选中文件');
        return false;
    }
    else
    {
        var num=Math.random();
        var littleproduct=document.getElementById("fjlb");
        var cindex = littleproduct.selectedIndex;
        var cText  = littleproduct.options[cindex].text;
        var cValue = littleproduct.options[cindex].value;
        window.open ("/fileaddall.aspx?tmp="+num+"&newname="+cValue+"", "_blank", "height=400px, width=470px,top=100,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
    }


}


function  openfile()  
{  
    var num=Math.random();
    var number=document.getElementById('Number').value;
    window.showModalDialog("/openfile.aspx?tmp="+num+"&number="+number+" ","window","dialogWidth:680px;DialogHeight=580px;status:no;scroll=yes;help:no");                
}


        
</script>

<head id="Head1" runat="server">
    <title>新建工作：<%=ViewState["FormName"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/js/div.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body class="newbody" onload="Settb();Load_Do();">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
                                <asp:TextBox ID="GqUpNodeNumKey" runat="server" Visible="False"></asp:TextBox>
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
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="AddWorkFlow.aspx">新建工作</a> >> 新建(<%=ViewState["FormName"]%>)</td>
                                                        <td width="81%" align="right">
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
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="left" class="newtd2" colspan="4" width="33%" style="height: 22px">
                                                        <strong>流水号：</strong><%=ViewState["lshid"]%>
                                                        <strong>工作名称/文号：</strong>
                                                        <asp:TextBox ID="whname" runat="server" CssClass="Twhname2" Width="286px"></asp:TextBox>
                                                        <strong>当前办理人：</strong><%=Session["realname"] %>
                                                        &nbsp;&nbsp;&nbsp;<strong>紧急程度：</strong>
                                                        <asp:DropDownList ID="JinJiChengDu" runat="server">
                                                            <asp:ListItem Value="1">一般</asp:ListItem>
                                                            <asp:ListItem Value="2">紧急</asp:ListItem>
                                                            <asp:ListItem Value="3">重要并紧急</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>表单信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td bgcolor="#ffffff" colspan="4" height="17">
                                                        <div id="strhtm">
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17" style="text-align: center">
                                                        <strong>公共附件</strong></td>
                                                </tr>
                                                <tr class="" id="nextrs22">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        附件列表：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:DropDownList ID="fjlb" runat="server" Width="268px">
                                                        </asp:DropDownList>&nbsp;
                                                        <input id="Button7" type="button" value="转  存" onclick="zcun();" />
                                                        <input id="Button5" type="button" value="下　载" onclick="down();" />
                                                        <asp:Button ID="Button3" runat="server" Text="删　除" />
                                                        <input onclick="zxcheck()" type="button" value="在线编辑" id="Button9" runat="server"></td>
                                                </tr>
                                                <tr class="" id="nextrs23">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        上传附件：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <input id="uploadFile" runat="server" style="width: 404px" type="file" name="uploadFile" />
                                                        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="上  传" />
                                                        <asp:Button ID="Button2" runat="server" Text="从文件柜导入" /></td>
                                                </tr>
                                                <tr class="">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        新建附件：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <table align="center" border="0" width="100%">
                                                            <tr>
                                                                <td width="150px">
                                                                    <asp:RadioButtonList ID="fujian" runat="server" RepeatDirection="Horizontal">
                                                                        <asp:ListItem Selected="True" Value="1">Word</asp:ListItem>
                                                                        <asp:ListItem Value="2">Excel</asp:ListItem>
                                                                        <asp:ListItem Value="3">PPT</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                                <td align="left">
                                                                    文档名称：<asp:TextBox ID="wdname" runat="server" Width="120px"></asp:TextBox>
                                                                    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="新 建" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr class="">
                                                    <td class="newtd2" colspan="4" height="17" style="text-align: center">
                                                        <strong>办理意见</strong></td>
                                                </tr>
                                                <tr class="">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        常用办理意见：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:DropDownList ID="normalcontent" runat="server" onchange="_change()">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr class="">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        电子印章：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:DropDownList ID="Yinzhang" runat="server">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr class="">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        办理意见：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:TextBox ID="SpContent" runat="server" Height="55px" TextMode="MultiLine" Width="100%"></asp:TextBox></td>
                                                </tr>
                                                <tr class="">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        附件：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <input id="File1" runat="server" name="uploadFile" style="width: 401px" type="file" /></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button8" runat="server" Text="保存并转交" CssClass="button_css" OnClick="Button8_Click" />
                                                                <input id="Button10" type="button" value="关 闭" onclick="window.close();" class="button_css" />
                                                            </font>
                                                        </div>
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
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ContractContent" runat="server" TextMode="MultiLine" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="GlNum" runat="server" Style="display: none"></asp:TextBox>
        <%=ViewState["jisuan"] %>
<%=ViewState["liebiao"] %>
<%=ViewState["liebiaoqh"] %>
        <script>
 
function   Settb()  
{  
    document.getElementById("strhtm").innerHTML=document.getElementById("TextBox1").value;
}   
 
 
function Load_Do()
{
    setTimeout("Load_Do()",0);
    var content = document.getElementById("strhtm").innerHTML
    document.getElementById("ContractContent").value=content;  
    document.getElementById("TextBox1").value=document.getElementById("ContractContent").value;
}

function  OpenJbrXzFrom(divname)  
{  
alert('未启动流程');
}//已经办人

        </script>

        <script language="JavaScript">

function deleteRow(r,t)
{
    var i=r.parentNode.parentNode.rowIndex
    if(i=='1')
    {
    alert('第一行不能为空');
    return false;
    }	
    //alert(i);
    document.getElementById(t).deleteRow(i)
}


i=1
function add(t){
++i;
var newt = document.getElementById(""+t+"1")
var newTR = newt.cloneNode(true);
newTR.id=t+i;
newTR.name=t+i;
newt.parentNode.insertAdjacentElement("beforeEnd",newTR);

}
        </script>

    </form>
</body>
</html>
