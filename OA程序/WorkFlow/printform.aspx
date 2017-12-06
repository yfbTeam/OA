<%@ Page Language="C#" AutoEventWireup="true" Codebehind="printform.aspx.cs" Inherits="xyoa.WorkFlow.printform" %>

<html>

<script>

</script>

<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/js/div.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script src="/js/prototojquery.js" type="text/javascript"></script>

    <script>
function printnewpage()
{
    document.getElementById("printshow1") .style.visibility="hidden"
    document.getElementById("printshow8") .style.visibility="hidden"
    print();
    document.getElementById("printshow1") .style.visibility="visible"
    document.getElementById("printshow8") .style.visibility="visible"
}

function senduser(str)
{
    window.open("/senduser.aspx?user="+str+"","_blank","height=500, width=600,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=200,left=350");
}

 window.onload= function()
  {
			page_width = _G("formDiv").offsetWidth;
			page_height = _G("FormContent").clientHeight;
 }
 
 var lv_tr = null;
 


function get_nextSibling(n)
{
  y=n.nextSibling;
  while (y.tagName!="DIV")
  {
 	 y=y.nextSibling;
  }
  return y;
}

//将表单放大1%
function fnZoomIn() {
 _G("FormContent").style.zoom = parseFloat(_G("FormContent").style.zoom) + 0.05 ;
 fnWritePos(_G("FormContent").style.zoom);
}

//将表单缩小1%
function fnZoomOut() {
 if(_G("FormContent").style.zoom>0.01){
    _G("FormContent").style.zoom = parseFloat(_G("FormContent").style.zoom) - 0.05 ;
    fnWritePos(_G("FormContent").style.zoom);
 }
}

function ChangeZoomVal() {
  var ChangeZoomStr = _G("zoom").value;
    if(ChangeZoomStr.length==0){
    alert("请输入缩放比例！");
    _G("zoom").focus();
    return false;
  }
    for(var i=0;i<ChangeZoomStr.length;i++){
    if(ChangeZoomStr.charAt(i)<'0'||ChangeZoomStr.charAt(i)>'9'){
    alert("请输入整数！");
    _G("zoom").focus();
    return false;
    }
  }
   if(parseInt(ChangeZoomStr)<=0){
    alert("请输入大于0的整数！");
    _G("zoom").focus();
    return false;
   }
   var ChangeZoomValue = parseFloat(ChangeZoomStr);
   _G("FormContent").style.zoom = ChangeZoomValue/100;
}

//表单大小显示框
function fnWritePos(intZoom) {
   _G("zoom").value = parseInt(intZoom*100);
}
var page_width ;
var page_height;
function zoom_a4()
{
	var width_zoom = 1;
	var height_zoom = 1;
    if(page_width>640)
	{
		width_zoom = parseFloat(640/page_width);
	}
    if(page_height>960)
	{
		height_zoom = parseFloat(690/page_height);
	}
	if(width_zoom>height_zoom)
	 width_zoom = height_zoom;
	_G("FormContent").style.zoom = width_zoom ;
	fnWritePos(width_zoom)
}

function geturl()
{
var num= document.getElementById("Number").value;
<%=ViewState["url"] %>
}
    </script>

</head>
<body class="newbody" onload="Settb();Load_Do();geturl();">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
                    <asp:TextBox ID="GqUpNodeNumKey" runat="server" Visible="False"></asp:TextBox>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0" id="printshow1">
                        <tr>
                            <td height="35">
                                <div>
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="10%" valign="bottom">
                                                          <img src="/oaimg/top_3.gif">打印 </td>
                                                        <td width="90%" align="right">
                                                          缩放比例：<input onblur="ChangeZoomVal()" style="width: 25px; height: 18px; font-size: 12px"
                                                                id="zoom" value="100" name="zoom">%&nbsp;
                                                            <img src="/oaimg/zoom.gif" alt="放大打印" width="16" height="16" align="absmiddle" style="cursor: pointer"
                                                                onclick="fnZoomIn()">&nbsp;&nbsp;<img src="/oaimg/zoom-.gif" style="cursor: pointer"
                                                                    onclick="fnZoomOut()" alt="缩小打印" align="absmiddle">&nbsp;&nbsp;<img src="/oaimg/zoom-base.gif"
                                                                        style="cursor: pointer" onclick="zoom_a4()" alt="使之符合A4大小" align="absmiddle"
                                                                        if="if">
                                                            打印项：
                                                            <asp:CheckBox ID="CheckBox2" runat="server" Text="工作标题" AutoPostBack="True" />
                                                            <asp:CheckBox ID="CheckBox1" runat="server" Text="表单明细" Checked="True" AutoPostBack="True" />
                                                            <asp:CheckBox ID="CheckBox3" runat="server" Text="公共附件" AutoPostBack="True" />
                                                            <asp:CheckBox ID="CheckBox4" runat="server" Text="操作日志" AutoPostBack="True" />
                                                            <asp:CheckBox ID="CheckBox5" runat="server" Text="办理意见" AutoPostBack="True" />
                                                            <asp:CheckBox ID="CheckBox6" runat="server" Text="印章使用记录" AutoPostBack="True" />
                                                            <asp:CheckBox ID="CheckBox7" runat="server" Text="已办理流程"  AutoPostBack="True" />
                                                            <input onclick="printnewpage()" type="button" value="打 印" id="Button14" class="button_css">
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
                                <div style="zoom: 1" id="FormContent" align="center">
                                    <div id="formDiv">
                                        <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="17">
                                                    &nbsp;</td>
                                                <td valign="top">
                                                    <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                        <asp:Panel ID="Panel1" runat="server">
                                                            <tr id="printshow2">
                                                                <td align="left" class="newtd2" colspan="4" width="33%" style="height: 22px">
                                                                    <strong>流水号：</strong><%=lshid %>
                                                                    <strong>工作名称/文号：</strong>
                                                                    <asp:Label ID="whname1" runat="server"></asp:Label>
                                                                    <strong>当前步骤：</strong><%=NodeName %>
                                                                    &nbsp;&nbsp;&nbsp;<strong>紧急程度：</strong><asp:Label ID="JinJiChengDu" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                        <asp:Panel ID="Panel2" runat="server">
                                                            <tr id="printshow3">
                                                                <td bgcolor="#ffffff" colspan="4" height="17" align="left">
                                                                    <div id="strhtm">
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                        <asp:Panel ID="Panel3" runat="server">
                                                            <tr id="printshow4">
                                                                <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                                    公共附件列表：</td>
                                                                <td class="newtd2" height="17" width="83%" colspan="3">
                                                                    <asp:Label ID="fujian" runat="server" Width="90%"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                        <asp:Panel ID="Panel4" runat="server">
                                                            <tr id="printshow5">
                                                                <td class="newtd2" colspan="4" height="17" style="text-align: center">
                                                                    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                                        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px"
                                                                        CellPadding="4" CellSpacing="2" PageSize="12" Style="font-size: 12px" Width="97%"
                                                                        ForeColor="Black">
                                                                        <FooterStyle BackColor="#CCCCCC" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="操作日志">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <table border="0" cellpadding="4" cellspacing="0">
                                                                                        <tr>
                                                                                            <td style="width: 100%">
                                                                                                <b>表单名称：</b><%# DataBinder.Eval(Container.DataItem, "FormName")%>
                                                                                                <b>操作人：</b><%# DataBinder.Eval(Container.DataItem, "Realname") %>(<%# DataBinder.Eval(Container.DataItem, "ZbOrJb") %>)
                                                                                                <b>时间：</b><%# DataBinder.Eval(Container.DataItem, "SetTime") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 100%">
                                                                                                <b>内容：</b><%# DataBinder.Eval(Container.DataItem, "Contents") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <RowStyle BackColor="White" />
                                                                        <EmptyDataTemplate>
                                                                            <div align="center">
                                                                                <font color="black">操作日志-无相关数据！</font></div>
                                                                        </EmptyDataTemplate>
                                                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Wrap="False" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                        <asp:Panel ID="Panel5" runat="server">
                                                            <tr id="printshow6">
                                                                <td class="newtd2" colspan="4" height="17" style="text-align: center">
                                                                    <asp:GridView ID="GridView2" runat="server" AllowPaging="True" AllowSorting="True"
                                                                        AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid"
                                                                        BorderWidth="3px" CellPadding="4" CellSpacing="2" PageSize="12" Style="font-size: 12px"
                                                                        Width="97%" ForeColor="Black">
                                                                        <PagerSettings Visible="False" />
                                                                        <FooterStyle BackColor="#CCCCCC" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="办理意见">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <table border="0" cellpadding="4" cellspacing="0">
                                                                                        <tr>
                                                                                            <td style="width: 100%">
                                                                                                <b>步骤名称：</b><%# DataBinder.Eval(Container.DataItem, "Buzhou")%>
                                                                                                <b>办理人：</b><%# DataBinder.Eval(Container.DataItem, "Realname") %>(<%# DataBinder.Eval(Container.DataItem, "ZbOrJb") %>)
                                                                                                <b>时间：</b><%# DataBinder.Eval(Container.DataItem, "SetTime") %>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 100%">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "Content") %>
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
                                                                        <RowStyle BackColor="White" />
                                                                        <EmptyDataTemplate>
                                                                            <div align="center">
                                                                                <font color="black">办理意见-无相关数据！</font></div>
                                                                        </EmptyDataTemplate>
                                                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Wrap="False" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                        <asp:Panel ID="Panel6" runat="server">
                                                            <tr id="printshow7">
                                                                <td class="newtd2" colspan="4" height="17" style="text-align: center">
                                                                    <asp:GridView ID="GridView3" runat="server" AllowPaging="True" AllowSorting="True"
                                                                        AutoGenerateColumns="False" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid"
                                                                        BorderWidth="3px" CellPadding="4" CellSpacing="2" PageSize="12" Style="font-size: 12px"
                                                                        Width="97%" ForeColor="Black">
                                                                        <PagerSettings Visible="False" />
                                                                        <FooterStyle BackColor="#CCCCCC" />
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="印章使用记录">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <table width="100%" border="0" cellspacing="3" cellpadding="0">
                                                                                        <tr>
                                                                                            <td align="center">
                                                                                                <img src="/seal/<%# DataBinder.Eval(Container.DataItem, "Newname")%>" style="width: 140px;
                                                                                                    height: 140px" id="img1" name="img1" /></td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="center">
                                                                                                <b>印章名称：</b><%# DataBinder.Eval(Container.DataItem, "Name")%>
                                                                                                <b>&nbsp;&nbsp;&nbsp;&nbsp;使用人：</b><%# DataBinder.Eval(Container.DataItem, "Realname")%>
                                                                                                <b>&nbsp;&nbsp;&nbsp;&nbsp;IP：</b><%# DataBinder.Eval(Container.DataItem, "IpAddress") %>
                                                                                                &nbsp;&nbsp;&nbsp;&nbsp;<b>时间：</b><%# DataBinder.Eval(Container.DataItem, "Settime") %></td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <RowStyle BackColor="White" />
                                                                        <EmptyDataTemplate>
                                                                            <div align="center">
                                                                                <font color="black">印章使用记录-无相关数据！</font></div>
                                                                        </EmptyDataTemplate>
                                                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" Wrap="False" />
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                        <asp:Panel ID="Panel7" runat="server">
                                                            <tr>
                                                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                                    <b>已办理流程</b>
                                                                    <hr>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="newtd2" colspan="4" nowrap="nowrap">
                                                                    <asp:Label ID="Liucheng" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </asp:Panel>
                                                        <tr id="printshow8">
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
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
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
