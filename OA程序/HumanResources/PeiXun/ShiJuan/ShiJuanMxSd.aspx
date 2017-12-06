<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ShiJuanMxSd.aspx.cs" Inherits="xyoa.HumanResources.PeiXun.ShiJuan.ShiJuanMxSd" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script>
function AddDanXuanS(str)
{
    var num=Math.random();
    window.showModalDialog("/HumanResources/PeiXun/ShiJuan/ShiJuanMxSd_Add_Danxuan.aspx?tmp="+num+"&ShijuanID="+str+"&MingchengID=<%=Request.QueryString["MingchengID"] %>","window", "dialogWidth:720px;DialogHeight=480px;status:no;scroll=yes;help:no");       
}

function AddDuoXuanS(str)
{
    var num=Math.random();
    window.showModalDialog("/HumanResources/PeiXun/ShiJuan/ShiJuanMxSd_Add_Duoxuan.aspx?tmp="+num+"&ShijuanID="+str+"&MingchengID=<%=Request.QueryString["MingchengID"] %>","window", "dialogWidth:720px;DialogHeight=480px;status:no;scroll=yes;help:no");       
}

function AddPanDuannS(str)
{
    var num=Math.random();
    window.showModalDialog("/HumanResources/PeiXun/ShiJuan/ShiJuanMxSd_Add_Panduan.aspx?tmp="+num+"&ShijuanID="+str+"&MingchengID=<%=Request.QueryString["MingchengID"] %>","window", "dialogWidth:720px;DialogHeight=480px;status:no;scroll=yes;help:no");       
}

function AddTianKongS(str)
{
    var num=Math.random();
    window.showModalDialog("/HumanResources/PeiXun/ShiJuan/ShiJuanMxSd_Add_Tiankong.aspx?tmp="+num+"&ShijuanID="+str+"&MingchengID=<%=Request.QueryString["MingchengID"] %>","window", "dialogWidth:720px;DialogHeight=480px;status:no;scroll=yes;help:no");       
}

function AddWenDaS(str)
{
    var num=Math.random();
    window.showModalDialog("/HumanResources/PeiXun/ShiJuan/ShiJuanMxSd_Add_Wenda.aspx?tmp="+num+"&ShijuanID="+str+"&MingchengID=<%=Request.QueryString["MingchengID"] %>","window", "dialogWidth:720px;DialogHeight=480px;status:no;scroll=yes;help:no");       
}

    </script>

    <script>
function chknull()
{
    
    if(document.getElementById('Fenzhi1').value=='')
    {
        alert('每题分值不能为空');
        form1.Fenzhi1.focus();
        return false;
    }	
 
    if(document.getElementById('Fenzhi1').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Fenzhi1').value))
        {
            alert("每题分值只能为数字");
            form1.Fenzhi1.focus();
            return false;
        }
    }  


    if(document.getElementById('Fenzhi2').value=='')
    {
        alert('每题分值不能为空');
        form1.Fenzhi2.focus();
        return false;
    }	
 
    if(document.getElementById('Fenzhi2').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Fenzhi2').value))
        {
            alert("每题分值只能为数字");
            form1.Fenzhi2.focus();
            return false;
        }
    }  
    

    if(document.getElementById('Fenzhi3').value=='')
    {
        alert('每题分值不能为空');
        form1.Fenzhi3.focus();
        return false;
    }	
 
    if(document.getElementById('Fenzhi3').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Fenzhi3').value))
        {
            alert("每题分值只能为数字");
            form1.Fenzhi3.focus();
            return false;
        }
    }  
    
  
    if(document.getElementById('Fenzhi4').value=='')
    {
        alert('每题分值不能为空');
        form1.Fenzhi4.focus();
        return false;
    }	
 
    if(document.getElementById('Fenzhi4').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Fenzhi4').value))
        {
            alert("每题分值只能为数字");
            form1.Fenzhi4.focus();
            return false;
        }
    }  
    

    if(document.getElementById('Fenzhi5').value=='')
    {
        alert('每题分值不能为空');
        form1.Fenzhi5.focus();
        return false;
    }	
 
    if(document.getElementById('Fenzhi5').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Fenzhi5').value))
        {
            alert("每题分值只能为数字");
            form1.Fenzhi5.focus();
            return false;
        }
    }  
    showwait();	
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
                                                            <a href="ShiJuan.aspx">试卷管理</a>
                                                            >> 试卷明细(按题库类别手动出题)</td>
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
                                                                <font class="shadow_but">试卷明细</font></button></td>
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
                                                        题库类别：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="MingchengID" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        对应试卷：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="ShijuanID" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>单选题每题分值：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Fenzhi1" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>多选题每题分值：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Fenzhi2" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>判断题每题分值：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Fenzhi3" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>填空题每题分值：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:TextBox ID="Fenzhi4" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>问答题每题分值：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:TextBox ID="Fenzhi5" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <strong>
                                                            <img src="/oaimg/sfind.png" />单选题</strong><asp:LinkButton ID="AddDanXuan" runat="server"><img src="/oaimg/menu/Menu46.gif"  border=0/>新增单选题</asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="0px" CellPadding="4" GridLines="None"
                                                            OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                            Width="100%" OnRowCommand="GridView1_RowCommand">
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="题目名称">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" HorizontalAlign="Left" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "TitlesC")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="删除">
                                                                    <ItemStyle HorizontalAlign="Center" Width="30px" Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" HorizontalAlign="Center" Width="30px" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="ShanChu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="ShanChu" CssClass="LinkLine">删除</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                            <EmptyDataTemplate>
                                                                <div align="center">
                                                                    <font color="white">无相关数据！</font></div>
                                                            </EmptyDataTemplate>
                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="DarkTurquoise" ForeColor="Black" HorizontalAlign="Right" />
                                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <strong>
                                                            <img src="/oaimg/sfind.png" />多选题</strong><asp:LinkButton ID="AddDuoXuan" runat="server"><img src="/oaimg/menu/Menu46.gif"  border=0/>新增多选题</asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="0px" CellPadding="4" GridLines="None"
                                                            OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                            Width="100%" OnRowCommand="GridView1_RowCommand">
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="题目名称">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" HorizontalAlign="Left" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "TitlesC")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="删除">
                                                                    <ItemStyle HorizontalAlign="Center" Width="30px" Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" HorizontalAlign="Center" Width="30px" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="ShanChu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="ShanChu" CssClass="LinkLine">删除</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                            <EmptyDataTemplate>
                                                                <div align="center">
                                                                    <font color="white">无相关数据！</font></div>
                                                            </EmptyDataTemplate>
                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="DarkTurquoise" ForeColor="Black" HorizontalAlign="Right" />
                                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <strong>
                                                            <img src="/oaimg/sfind.png" />判断题</strong><asp:LinkButton ID="AddPanDuan" runat="server"><img src="/oaimg/menu/Menu46.gif"  border=0/>新增判断题</asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="0px" CellPadding="4" GridLines="None"
                                                            OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                            Width="100%" OnRowCommand="GridView1_RowCommand">
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="题目名称">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" HorizontalAlign="Left" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "TitlesC")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="删除">
                                                                    <ItemStyle HorizontalAlign="Center" Width="30px" Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" HorizontalAlign="Center" Width="30px" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="ShanChu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="ShanChu" CssClass="LinkLine">删除</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                            <EmptyDataTemplate>
                                                                <div align="center">
                                                                    <font color="white">无相关数据！</font></div>
                                                            </EmptyDataTemplate>
                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="DarkTurquoise" ForeColor="Black" HorizontalAlign="Right" />
                                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <strong>
                                                            <img src="/oaimg/sfind.png" />填空题</strong><asp:LinkButton ID="AddTianKong" runat="server"><img src="/oaimg/menu/Menu46.gif"  border=0/>新增填空题</asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" style="height: 16px">
                                                        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="0px" CellPadding="4" GridLines="None"
                                                            OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                            Width="100%" OnRowCommand="GridView1_RowCommand">
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="题目名称">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" HorizontalAlign="Left" Wrap="False" />
                                                                    <ItemTemplate>
                                                                   <%# DataBinder.Eval(Container.DataItem, "FrontTitle")%><font color="blue"><u><%# DataBinder.Eval(Container.DataItem, "Answer")%></u></font><%# DataBinder.Eval(Container.DataItem, "BackTitle")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="删除">
                                                                    <ItemStyle HorizontalAlign="Center" Width="30px" Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" HorizontalAlign="Center" Width="30px" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="ShanChu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="ShanChu" CssClass="LinkLine">删除</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                            <EmptyDataTemplate>
                                                                <div align="center">
                                                                    <font color="white">无相关数据！</font></div>
                                                            </EmptyDataTemplate>
                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="DarkTurquoise" ForeColor="Black" HorizontalAlign="Right" />
                                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <strong>
                                                            <img src="/oaimg/sfind.png" />问答题</strong><asp:LinkButton ID="AddWenDa" runat="server"><img src="/oaimg/menu/Menu46.gif"  border=0/>新增问答题</asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="0px" CellPadding="4" GridLines="None"
                                                            OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                            Width="100%" OnRowCommand="GridView1_RowCommand">
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="题目名称">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" HorizontalAlign="Left" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "TitlesC")%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="删除">
                                                                    <ItemStyle HorizontalAlign="Center" Width="30px" Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" HorizontalAlign="Center" Width="30px" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="ShanChu" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="ShanChu" CssClass="LinkLine">删除</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                            <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                            <EmptyDataTemplate>
                                                                <div align="center">
                                                                    <font color="white">无相关数据！</font></div>
                                                            </EmptyDataTemplate>
                                                            <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                            <PagerStyle BackColor="DarkTurquoise" ForeColor="Black" HorizontalAlign="Right" />
                                                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                            <AlternatingRowStyle BackColor="#F7F7F7" />
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp;
                                                                <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css" OnClick="Button2_Click" />
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
