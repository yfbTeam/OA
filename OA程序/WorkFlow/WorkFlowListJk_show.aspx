﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowListJk_show.aspx.cs"
    Inherits="xyoa.WorkFlow.WorkFlowListJk_show" %>

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
    window.open("WorkFlowListSpYzQp.aspx?Number=<%=YzSealNumber%>&NodeName=<%=NodeName %>","online","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");

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
window.open ("AddWorkFlow_spyj.aspx?Number="+num+"&key=<%=YijianZb%>&Buzhou=<%=NodeName%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no")
}


function  PrintPage()  
{
var num= document.getElementById("number").value;
window.open ("printform.aspx?Number="+num+"&UpNodeId=<%=Request.QueryString["UpNodeId"]%>&id=<%=Request.QueryString["id"]%>", "_blank", "height=660, width=920,toolbar=no, menubar=no, scrollbars=yes,resizable=no,location=no, status=no")
}

function geturl()
{
var num= document.getElementById("Number").value;
<%=ViewState["url"] %>
}

</script>

<head id="Head1" runat="server">
    <title>查看工作：<%=FormName %>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/js/div.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body class="newbody" onload="Settb();Load_Do();geturl();">
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
                                            </td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="37%" valign="bottom">
                                                            工作监控 >> 查看(<%=FormName %>)</td>
                                                        <td width="60%" align="right">
                                                            <input onclick="PrintPage()" type="button" value="打 印" id="Button16" class="button_css"
                                                                runat="server">
                                                            <input onclick='window.open ("WorkFlowList_bl_lc.aspx?Number=<%=Numbers%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'
                                                                type="button" value="流程图" id="Button13" class="button_css">
                                                            <input onclick='window.open ("AddWorkFlow_show_lc.aspx?FlowNumber=<%=Request.QueryString["FlowNumber"]%>&NodeName=<%=NodeName%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'
                                                                type="button" value="流程设计图" id="Button11" class="button_css">
                                                            <input onclick="Openczrz()" type="button" value="流转日志" id="Button10" runat="server"
                                                                class="button_css">
                                                            <input onclick="OpenYzLog()" type="button" value="印章记录" id="Button14" runat="server"
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                        </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="left" class="newtd2" colspan="4" width="33%" style="height: 22px">
                                                        <strong>流水号：</strong><%=lshid %>
                                                        <strong>工作名称/文号：</strong><asp:TextBox ID="whstartname" runat="server" Width="94px"
                                                            Visible="False"></asp:TextBox><asp:TextBox ID="whname" runat="server" CssClass="Twhname"></asp:TextBox>
                                                        <asp:Label ID="whname1" runat="server" Visible="False"></asp:Label>
                                                        <asp:TextBox ID="whendname" runat="server" Width="94px" Visible="False"></asp:TextBox>
                                                        <strong>当前步骤：</strong><%=NodeName %>
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
                                                        <strong>办理意见</strong></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="1"
                                                            GridLines="None" PageSize="12" Style="font-size: 12px" Width="97%" OnRowDataBound="GridView1_RowDataBound">
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
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <input id="Button15" type="button" value="关 闭" onclick="window.close()" class="button_css" />
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
        <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ContractContent" runat="server" TextMode="MultiLine" Style="display: none"></asp:TextBox>

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

    </form>
</body>
</html>
