<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WebDiskLx_qx.aspx.cs" Inherits="xyoa.PublicWork.WebDisk.WebDiskLx_qx" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('目录名称不能为空');
    form1.Name.focus();
    return false;
    }	
    
    if(document.getElementById('Paixun').value=='')
    {
    alert('排序号不能为空');
    form1.Paixun.focus();
    return false;
    }	
   
    if(document.getElementById('Paixun').value!='')
    {
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Paixun').value))
        {
            alert("排序号只能为正数");
            form1.Paixun.focus();
            return false;
        }
    }
    
    
    
    showwait();	
}  

function  openqx1()  
{  
    var num=Math.random();
    window.showModalDialog("WebDiskLx_qx_add.aspx?tmp="+num+"&KeyId=<%=Request.QueryString["id"]%>","window","dialogWidth:680px;DialogHeight=620px;status:no;scroll=yes;help:no");                
}

function  openqx2()  
{  
    var num=Math.random();
    window.showModalDialog("WebDiskLx_qxbm_add.aspx?tmp="+num+"&KeyId=<%=Request.QueryString["id"]%>","window","dialogWidth:720px;DialogHeight=620px;status:no;scroll=yes;help:no");                
}

function  openqx3()  
{  
    var num=Math.random();
    window.showModalDialog("WebDiskLx_qxry_add.aspx?tmp="+num+"&KeyId=<%=Request.QueryString["id"]%>","window","dialogWidth:760px;DialogHeight=650px;status:no;scroll=yes;help:no");                
}

function  openqx4()  
{  
    var num=Math.random();
    window.showModalDialog("WebDiskLx_qxzw_add.aspx?tmp="+num+"&KeyId=<%=Request.QueryString["id"]%>","window","dialogWidth:720px;DialogHeight=620px;status:no;scroll=yes;help:no");                
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
<body class="newbody" onload="quanxian()">
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
                                                            <a href="WebDiskLx.aspx">硬盘目录</a>
                                                            >> 硬盘目录权限设置</td>
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
                                                                <font class="shadow_but">硬盘目录</font></button></td>
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
                                                        类型名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Name" runat="server" Width="100%" CssClass="ReadOnlyText"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17" align="center">
                                                        <img src="/oaimg/menu/workflow_others.gif" />设置权限</td>
                                                </tr>
                                                <tr id="nextrs1">
                                                    <td class="newtd2" colspan="4" height="17" align="center">
                                                        <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                            <tr>
                                                                <td align="left" class="newtd1" height="17" nowrap="nowrap" colspan="4">
                                                                    <img src="/oaimg/menu/workflow_query.gif" /><strong>关联权限</strong>
                                                                    <img src="/oaimg/menu/Menu46.gif" />
                                                                    <asp:LinkButton ID="LinkButton1" runat="server">新增关联信息</asp:LinkButton></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="newtd2" height="17" nowrap="nowrap" colspan="4">
                                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                                        BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="1"
                                                                        GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                                                                        PageSize="12" Style="font-size: 12px" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                                        AllowPaging="True">
                                                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="name" HeaderText="关联" SortExpression="name">
                                                                                <ItemStyle Wrap="False" />
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="文件夹浏览" SortExpression="FLiulang">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FLiulang").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹新增" SortExpression="FXinzeng">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FXinzeng").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹修改" SortExpression="FXiugai">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FXiugai").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹删除" SortExpression="FShanchu">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FShanchu").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹权限" SortExpression="FQuanXian">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FQuanXian").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件浏览" SortExpression="BLiulang">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BLiulang").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件新增" SortExpression="BXinzeng">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BXinzeng").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件修改/转移/转存/发送" SortExpression="BXiugai">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BXiugai").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件删除" SortExpression="BShanchu">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BShanchu").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件批注" SortExpression="PiZhu">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "PiZhu") %>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件日志" SortExpression="RiZhi">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "RiZhi") %>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="相关操作">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="XiuGai" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                                        CommandName="XiuGai">修改</asp:LinkButton>
                                                                                    <asp:LinkButton ID="ShanChu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                                        CommandName="ShanChu">删除</asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="DarkTurquoise" ForeColor="Black" HorizontalAlign="Right" />
                                                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                                        <AlternatingRowStyle BackColor="#F7F7F7" />
                                                                        <EmptyDataTemplate>
                                                                            <div align="center">
                                                                                <font color="white">无相关数据！</font></div>
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="newtd1" height="17" nowrap="nowrap" colspan="4">
                                                                    <img src="/oaimg/menu/workflow_query.gif" /><strong>部门权限</strong>
                                                                    <img src="/oaimg/menu/Menu46.gif" />
                                                                    <asp:LinkButton ID="LinkButton2" runat="server">新增部门信息</asp:LinkButton></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="newtd2" height="17" nowrap="nowrap" colspan="4">
                                                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                                        BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="1"
                                                                        GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                                                                        PageSize="12" Style="font-size: 12px" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                                        AllowPaging="True">
                                                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="name" HeaderText="部门" SortExpression="name">
                                                                                <ItemStyle Wrap="False" />
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="文件夹浏览" SortExpression="FLiulang">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FLiulang").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹新增" SortExpression="FXinzeng">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FXinzeng").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹修改" SortExpression="FXiugai">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FXiugai").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹删除" SortExpression="FShanchu">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FShanchu").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹权限" SortExpression="FQuanXian">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FQuanXian").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件浏览" SortExpression="BLiulang">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BLiulang").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件新增" SortExpression="BXinzeng">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BXinzeng").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件修改/转移/转存/发送" SortExpression="BXiugai">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BXiugai").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件删除" SortExpression="BShanchu">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BShanchu").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件批注" SortExpression="PiZhu">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "PiZhu") %>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件日志" SortExpression="RiZhi">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "RiZhi") %>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="相关操作">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="XiuGai" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                                        CommandName="XiuGai">修改</asp:LinkButton>
                                                                                    <asp:LinkButton ID="ShanChu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                                        CommandName="ShanChu">删除</asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="DarkTurquoise" ForeColor="Black" HorizontalAlign="Right" />
                                                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                                        <AlternatingRowStyle BackColor="#F7F7F7" />
                                                                        <EmptyDataTemplate>
                                                                            <div align="center">
                                                                                <font color="white">无相关数据！</font></div>
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="newtd1" height="17" nowrap="nowrap" colspan="4">
                                                                    <img src="/oaimg/menu/workflow_query.gif" /><strong>人员权限</strong>
                                                                    <img src="/oaimg/menu/Menu46.gif" />
                                                                    <asp:LinkButton ID="LinkButton3" runat="server">新增人员信息</asp:LinkButton></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="newtd2" height="17" nowrap="nowrap" colspan="4">
                                                                    <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                                        BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="1"
                                                                        GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                                                                        PageSize="12" Style="font-size: 12px" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                                        AllowPaging="True">
                                                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="name" HeaderText="人员" SortExpression="name">
                                                                                <ItemStyle Wrap="False" />
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="文件夹浏览" SortExpression="FLiulang">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FLiulang").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹新增" SortExpression="FXinzeng">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FXinzeng").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹修改" SortExpression="FXiugai">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FXiugai").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹删除" SortExpression="FShanchu">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FShanchu").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹权限" SortExpression="FQuanXian">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FQuanXian").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件浏览" SortExpression="BLiulang">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BLiulang").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件新增" SortExpression="BXinzeng">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BXinzeng").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件修改/转移/转存/发送" SortExpression="BXiugai">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BXiugai").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件删除" SortExpression="BShanchu">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BShanchu").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件批注" SortExpression="PiZhu">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "PiZhu") %>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件日志" SortExpression="RiZhi">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "RiZhi") %>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="相关操作">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="XiuGai" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                                        CommandName="XiuGai">修改</asp:LinkButton>
                                                                                    <asp:LinkButton ID="ShanChu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                                        CommandName="ShanChu">删除</asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="DarkTurquoise" ForeColor="Black" HorizontalAlign="Right" />
                                                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                                        <AlternatingRowStyle BackColor="#F7F7F7" />
                                                                        <EmptyDataTemplate>
                                                                            <div align="center">
                                                                                <font color="white">无相关数据！</font></div>
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="newtd1" height="17" nowrap="nowrap" colspan="4">
                                                                    <img src="/oaimg/menu/workflow_query.gif" /><strong>职位权限</strong>
                                                                    <img src="/oaimg/menu/Menu46.gif" />
                                                                    <asp:LinkButton ID="LinkButton4" runat="server">新增职位信息</asp:LinkButton></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="left" class="newtd2" height="17" nowrap="nowrap" colspan="4">
                                                                    <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                                        BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="1"
                                                                        GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                                                                        PageSize="12" Style="font-size: 12px" Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging"
                                                                        AllowPaging="True">
                                                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                        <Columns>
                                                                            <asp:BoundField DataField="name" HeaderText="职位" SortExpression="name">
                                                                                <ItemStyle Wrap="False" />
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                            </asp:BoundField>
                                                                            <asp:TemplateField HeaderText="文件夹浏览" SortExpression="FLiulang">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FLiulang").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹新增" SortExpression="FXinzeng">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FXinzeng").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹修改" SortExpression="FXiugai">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FXiugai").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹删除" SortExpression="FShanchu">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FShanchu").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件夹权限" SortExpression="FQuanXian">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("FQuanXian").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件浏览" SortExpression="BLiulang">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BLiulang").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件新增" SortExpression="BXinzeng">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BXinzeng").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件修改/转移/转存/发送" SortExpression="BXiugai">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BXiugai").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件删除" SortExpression="BShanchu">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# ((Eval("BShanchu").ToString() == "1")) ? "是" : "否"%>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件批注" SortExpression="PiZhu">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "PiZhu") %>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="文件日志" SortExpression="RiZhi">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <%# DataBinder.Eval(Container.DataItem, "RiZhi") %>
                                                                                </ItemTemplate>
                                                                                <ItemStyle Wrap="False" />
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="相关操作">
                                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                                <ItemTemplate>
                                                                                    <asp:LinkButton ID="XiuGai" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                                        CommandName="XiuGai">修改</asp:LinkButton>
                                                                                    <asp:LinkButton ID="ShanChu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                                        CommandName="ShanChu">删除</asp:LinkButton>
                                                                                </ItemTemplate>
                                                                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                                                                            </asp:TemplateField>
                                                                        </Columns>
                                                                        <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="DarkTurquoise" ForeColor="Black" HorizontalAlign="Right" />
                                                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                                        <AlternatingRowStyle BackColor="#F7F7F7" />
                                                                        <EmptyDataTemplate>
                                                                            <div align="center">
                                                                                <font color="white">无相关数据！</font></div>
                                                                        </EmptyDataTemplate>
                                                                    </asp:GridView>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        排序号：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Paixun" runat="server" Width="100%" MaxLength="4" CssClass="ReadOnlyText">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="设置完成并返回" OnClick="Button2_Click" /></font></div>
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
        <asp:TextBox ID="ZdBumenId" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ZdUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	
            var  wName_2;  
            function  openunit()  
            {  
            var num=Math.random();
            var str=""+document.getElementById('ZdBumenId').value+"";
            wName_2=window.showModalDialog("/OpenWindows/open_bumen_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
            if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
            for(var i=0;i<arr.length;i++)
            { 
            document.getElementById("ZdBumenId").value=arr[0]; 
            document.getElementById("ZdBumen").value=arr[1]; 
            }


            }



            var  wName_1;  
            function  openuser1()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('ZdUsername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("ZdUsername").value=arr[0]; 
                    document.getElementById("ZdRealname").value=arr[1]; 
                }
            }
            
            
        </script>

    </form>
</body>
</html>
