<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowListSp.aspx.cs"
    Inherits="xyoa.WorkFlow.WorkFlowListSp" %>

<html>

<script>

  
function Addjbr()
{
    window.open("WorkFlowListSp_Jbr.aspx?id=<%=Request.QueryString["id"]%>","_blank","height=250,width=680,status=0,toolbar=no,menubar=no,location=no,top=0,left=0,resizable=no,resizable=yes");
}
        
function UpdateData(ziduan,content)
{
    var number=document.getElementById('Number').value;
    AjaxMethod.InsertTable(number,ziduan,content);
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
       

function  OpenYzLog()  
{

var num= document.getElementById("number").value;
window.open ("WorkFlowListSpYzLog.aspx?Number="+num+"", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}

function  Openczrz()  
{
var num= document.getElementById("number").value;
window.open ("AddWorkFlow_czrz.aspx?Number="+num+"", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}



function  OpenSpyj()  
{
var num= document.getElementById("number").value;
window.open ("AddWorkFlow_spyj.aspx?Number="+num+"&key=<%=ViewState["YijianZb"]%>&Buzhou=<%=ViewState["NodeName"]%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}

function  PrintPage()  
{
var num= document.getElementById("number").value;
window.open ("printform.aspx?Number="+num+"&UpNodeId=<%=Request.QueryString["UpNodeId"]%>&id=<%=Request.QueryString["id"]%>", "_blank", "height=660, width=920,toolbar=no, menubar=no, scrollbars=yes,resizable=no,location=no, status=no")
}

function  openfile()  
{  
    var num=Math.random();
    var number=document.getElementById('Number').value;
    window.showModalDialog("/openfile.aspx?tmp="+num+"&number="+number+" ","window","dialogWidth:680px;DialogHeight=580px;status:no;scroll=yes;help:no");                
}

function  ConFile()  
{
    if(document.getElementById('whname').value=='')
    {
        alert('工作名称不允许为空');
        form1.whname.focus();
        return false;
    }
    
    <%=ViewState["bitian"] %>
    <%=ViewState["YzKongzhi"] %>
    showwait();	
}

function  Openkjrz()  
{
 var num=Math.random();
 var number=document.getElementById('Number').value;
 window.showModalDialog("WorkFlowListKjLog.aspx?tmp="+num+"&number="+number+"","window", "dialogWidth:820px;DialogHeight=580px;status:no;scroll=yes;help:no");       
}

function geturl()
{
var num= document.getElementById("Number").value;
<%=ViewState["url"] %>
}

function opensetsp(str1)
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
    window.open("WorkFlowListSpYj.aspx?picname="+str1+"","_blank","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
}

function  openxg(KeyId)  
{  
    var num=Math.random();
    window.showModalDialog("WorkFlowListSp_Yijian_xg.aspx?tmp="+num+"&Id="+KeyId+"","window","dialogWidth:680px;DialogHeight=480px;status:no;scroll=yes;help:no");                
}

</script>

<head id="Head1" runat="server">
    <title>工作办理：<%=ViewState["FormName"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/js/div.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body class="newbody" onload="Settb();Load_Do();Dis_Do();aaa();geturl();">
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
                                                        <td width="30%" valign="bottom">
                                                            待办工作 >> 办理(<%=ViewState["FormName"]%>)</td>
                                                        <td width="67%" align="right">
                                                            <input onclick="PrintPage()" type="button" value="打 印" id="Button16" class="button_css"
                                                                runat="server">
                                                            <input onclick="Addjbr()" type="button" value="增加经办人" id="Button2" class="button_css"
                                                                runat="server">
                                                            <input onclick='var num = Math.random();window.open ("WorkFlowList_bl_lc.aspx?Number=<%=ViewState["Numbers"]%>&tmp=" + num + "", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'
                                                                type="button" value="流程图" id="Button13" class="button_css">
                                                            <input onclick='var num = Math.random();window.open ("AddWorkFlow_show_lc.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"]%>&NodeName=<%=ViewState["NodeName"]%>&tmp=" + num + "", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'
                                                                type="button" value="流程设计图" id="Button11" class="button_css">
                                                            <input onclick="Openczrz()" type="button" value="流转日志" id="Button10" runat="server"
                                                                class="button_css">
                                                            <input onclick="OpenYzLog()" type="button" value="印章记录" id="Button14" runat="server"
                                                                class="button_css">
                                                            <input onclick="Openkjrz()" type="button" value="控件日志" id="Button18" runat="server"
                                                                class="button_css">
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
                            <td>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="left" class="newtd2" colspan="4" width="33%" style="height: 22px">
                                                        <strong>流水号：</strong><%=ViewState["lshid"]%>
                                                        <strong>工作名称/文号：</strong><asp:TextBox ID="whname" runat="server"
                                                                CssClass="Twhname2" Width="231px"></asp:TextBox>
                                                        <asp:Label ID="whname1" runat="server" Visible="False"></asp:Label>
                                                        <strong>当前步骤：</strong><%=ViewState["NodeName"]%>
                                                        &nbsp;&nbsp;&nbsp;<strong>紧急程度：</strong><asp:Label ID="JinJiChengDu" runat="server"></asp:Label>
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
                                                        <input id="Button7" type="button" value="转  存" onclick="zcun();" runat="server" />
                                                        <input id="Button5" type="button" value="下　载" onclick="down();" runat="server" />
                                                        <asp:Button ID="Button3" runat="server" Text="删　除" />
                                                        <input onclick="zxcheck()" type="button" value="在线编辑" id="Button9" runat="server"></td>
                                                </tr>
                                                <asp:Panel ID="Panel1" runat="server">
                                                    <tr class="" id="nextrs23">
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            上传附件：</td>
                                                        <td class="newtd2" height="17" width="83%" colspan="3">
                                                            <input id="uploadFile" runat="server" style="width: 404px" type="file" name="uploadFile" />
                                                            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="上  传" />
                                                            <asp:Button ID="Button17" runat="server" Text="从文件柜导入" /></td>
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
                                                </asp:Panel>
                                                <tr class="">
                                                    <td class="newtd2" colspan="4" height="17" style="text-align: center">
                                                        <strong>办理意见</strong><asp:CheckBox ID="CheckBox1" runat="server" onclick="aaa()" /></td>
                                                </tr>
                                                <tr id="nextrs1" style="display: none">
                                                    <td class="newtd2" nowrap="nowrap" colspan="4">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="1"
                                                            GridLines="None" PageSize="12" Style="font-size: 12px" Width="97%" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand">
                                                            <PagerSettings Visible="False" />
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="办理意见">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <table border="0" cellpadding="4" cellspacing="0">
                                                                            <tr>
                                                                                <td style="width: 100%">
                                                                                 <asp:Label ID="Buzhou" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Buzhou")%>'
                                                                                        Visible="false"></asp:Label>
                                                                                    <asp:Label ID="Username" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Username")%>'
                                                                                        Visible="false"></asp:Label>
                                                                                    <asp:LinkButton ID="Xiugai" runat="server" CommandName="Xiugai" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'><font color=red>[修改]</font></asp:LinkButton>
                                                                                    <asp:LinkButton ID="ShanChu" runat="server" CommandName="ShanChu" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'><font color=red>[删除]</font></asp:LinkButton>
                                                                                    <b>步骤名称：</b><%# DataBinder.Eval(Container.DataItem, "Buzhou")%>
                                                                                    <b>办理人：</b><%# DataBinder.Eval(Container.DataItem, "Realname") %>(<%# DataBinder.Eval(Container.DataItem, "ZbOrJb") %>)
                                                                                    <b>时间：</b><%# DataBinder.Eval(Container.DataItem, "SetTime") %>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td style="width: 100%">
                                                                                    <b>意见：</b><%# DataBinder.Eval(Container.DataItem, "Content") %>
                                                                                    <br>
                                                                                    <br>
                                                                                    <a href="/AddWorkFlow_add_down.aspx?number=<%# DataBinder.Eval(Container.DataItem, "NewName") %>"
                                                                                        target="_blank">
                                                                                        <%# DataBinder.Eval(Container.DataItem, "OldName") %>
                                                                                    </a>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                            <EmptyDataTemplate>
                                                                <div align="center">
                                                                    <font color="white">无相关数据！</font></div>
                                                            </EmptyDataTemplate>
                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr class="">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        常用评语：</td>
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
                                                        <input id="File1" runat="server" name="uploadFile" style="width: 401px" type="file" />
                                                        <asp:Button ID="Button15" runat="server" OnClick="Button15_Click1" Text="保存办理意见" /></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="转交下一步" CssClass="button_css" OnClick="Button1_Click" />
                                                                <asp:Button ID="Wanbi" runat="server" Text="办理完毕" CssClass="button_css" OnClick="Button15_Click" />
                                                                <asp:Button ID="BaoCun" runat="server" Text="保存并返回" CssClass="button_css" OnClick="BaoCun_Click" />
                                                                <asp:Button ID="HuiTui" runat="server" Text="回 退" CssClass="button_css" OnClick="HuiTui_Click" />
                                                                <input id="Button12" type="button" value="关 闭" onclick="window.close()" class="button_css" />
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

        <script>
            function aaa()
            {   
                if(document.getElementById('CheckBox1').checked)
                {
                   document.getElementById('nextrs1').style.display="";
                }
                else
                {
                   document.getElementById('nextrs1').style.display="none";
                }
            }
 
        </script>

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

function Dis_Do()
{
 <%=ViewState["liebiaobkx"] %>
}

function disable(name)
{
    var divObj = document.getElementById(name); 
    var txts = divObj.getElementsByTagName("input");  
    for(var i=0;i<txts.length;i++)  
    {  
        if(txts[i].type=="text")
        {  
            txts[i].disabled = "disabled";
        } 
    }
} 
function  OpenJbrXzFrom(divname)  
{  

    var num=Math.random();
    var str=document.getElementById(divname).value;
    wDiyFrom=window.showModalDialog("/OpenWindows/open_div_yjbuser.aspx?tmp="+num+"&requeststr="+str+"&lcid=<%=Request.QueryString["id"]%>","window", "dialogWidth:600px;DialogHeight=680px;status:no;scroll=yes;help:no");               
    if(wDiyFrom!=null && wDiyFrom!= "undefined")
    {
    document.getElementById(divname).value+=wDiyFrom; 
    }

}//已经办人

function opensetyz(str)
{

    var  wName_5;  
    var num=Math.random();
    wName_5=window.showModalDialog("WorkFlowListSpYzY.aspx?<%=ViewState["YzSealNumber"]%>&FormId=<%=Request.QueryString["FormId"] %>&NodeName=<%=ViewState["NodeName"]%>&picname="+str+"&tmp=" + num + "","window", "dialogWidth:600px;DialogHeight=460px;status:no;scroll=yes;help:no");                
    if (wName_5 == undefined) {wName_5 = window.returnValue;}var arr = wName_5.split("|");
    for(var i=0;i<arr.length;i++)
    { 
        setpic(arr[0],arr[1],arr[2])
    }
}

function setpic(str1,str2,str3)
{
  document.getElementById(''+str1+'').src = "/seal/"+str2+"";
  document.getElementById(''+str1+'').alt = ''+str3+'';
}

function opensetsp(str1)
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
    window.open("WorkFlowListSpYj.aspx?picname="+str1+"","_blank","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
}

function setyijian(str1,str2)
{
  document.getElementById(''+str1+'').value += str2;
}


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
