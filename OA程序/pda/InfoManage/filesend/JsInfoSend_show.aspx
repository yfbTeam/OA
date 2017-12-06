﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="JsInfoSend_show.aspx.cs"
    Inherits="xyoa.pda.InfoManage.filesend.JsInfoSend_show" %>

<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <meta name="viewport" content="width=device-width, minimum-scale=1, maximum-scale=1">
    <title>移动设备平台</title>
    <link rel="stylesheet" href="/pda/images/pda.css">

    <script src="/pda/images/public.js" type="text/javascript"></script>

    <script src="/pda/images/jquery.min.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script type="text/javascript">
var $ = jQuery.noConflict();
	$(function() {
		$('#activator').click(function(){
				$('#box').animate({'top':'50px'},200);
		});
		$('#boxclose').click(function(){
				$('#box').animate({'top':'-1400px'},500);
		});
		$('#activator_share').click(function(){
				$('#box_share').animate({'top':'50px'},200);
		});
		$('#boxclose_share').click(function(){
				$('#box_share').animate({'top':'-1400px'},500);
		});
		$('#meunbn').click(function(){
		        $('#box').animate({'top':'-1400px'},500);
				$('#box_meun').animate({'top':'50px'},200);
		});
		$('#boxclose_meun').click(function(){
				$('#box_meun').animate({'top':'-1400px'},500);
		});
	});

function showMenu()
{
$('#box_meun').animate({'top':'-1400px'},500);
$('#box').animate({'top':'50px'},200);
}

</script>

</head>
<body onload="aaa()">
    <form id="form1" runat="server">
        <div id="overlay">
        </div>
        <div class="ui-loader loading">
            <span class="ui-icon ui-icon-loading"></span>
            <h1>
                正在载入...</h1>
        </div>
        <div id="box_meun" class="box">
            <div class="box_content">
                <div class="box_content_tab">
                    操作菜单
                </div>
                <div class="box_content_center">
                    <div class="social_share">
                        <ul>
                            <li><a id="A1" onclick="LoadingShow();location.href='JsInfoSend.aspx';">
                                <img border="0" alt="" src="/pda/images/home.png"><br>
                                接收文件</a></li>
                            <li><a id="box_meun1" onclick="LoadingShow();location.href='InfoSend_add.aspx';">
                                <img border="0" alt="" src="/pda/images/technorati.png"><br>
                                发送文件</a></li>
                            <li>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/pda/images/rss.png"
                                    OnClick="ImageButton1_Click" />
                                <br>
                                回复文件</li>
                        </ul>
                        <a id="boxclose_meun" class="boxclose">关闭</a>
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
        <div id="header">
            <table width="100%" height="40" border="0" align="center" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="45px" align="left">
                        <asp:Button ID="Button1" runat="server" CssClass="button_shouji" Text="返回" Width="45px"
                            OnClick="Button1_Click" /></td>
                    <td align="center">
                        <span class="t">查看内部邮件</span></td>
                    <td width="45px" align="right">
                        <input id="meunbn" type="button" value="操作" class="button_shouji" width="45px" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divgrid" class="divheight">
            <table align="center" border="0" cellpadding="4" cellspacing="1" width="99%" class="nextpage"
                id="tableprint">
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        文件名称：</td>
                    <td class="newtd2" colspan="3" height="17" width="83%">
                        <asp:Label ID="Name" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr id="trUser">
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        接收人：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:Label ID="JsRealname" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        发送人：</td>
                    <td class="newtd2" colspan="3" height="17" width="83%">
                        <asp:Label ID="Realname" runat="server"></asp:Label>
                        <asp:Label ID="Username" runat="server" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        传阅时间：</td>
                    <td class="newtd2" colspan="3" height="17" width="83%">
                        <asp:Label ID="Settime" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                        <b>讨论记录(<%=ViewState["GridViewCount"] %>)</b><asp:CheckBox ID="CheckBox1" runat="server"
                            onclick="aaa()" /></td>
                </tr>
                <tr id="nextrs1" style="display: none">
                    <td class="newtd2" nowrap="nowrap" colspan="4">
                        <div id="Div1">
                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px"
                                CellPadding="5" CellSpacing="1" GridLines="None" PageSize="8" Style="font-size: 12px"
                                Width="100%" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
                                OnRowDataBound="GridView1_RowDataBound">
                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                <Columns>
                                    <asp:TemplateField HeaderText="讨论记录：">
                                        <HeaderStyle CssClass="newtitle" Wrap="False" HorizontalAlign="Left" />
                                        <ItemTemplate>
                                            <asp:Label ID="FTUsername" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Username")%>'
                                                Visible="false"></asp:Label>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="8">
                                                <tr>
                                                    <td width="80%">
                                                        <font color="#0066CC"><b>
                                                            <%# DataBinder.Eval(Container.DataItem, "Realname")%>
                                                        </b></font>&nbsp;&nbsp;&nbsp;<font color="#BD9999"><%# DataBinder.Eval(Container.DataItem, "Settime")%></font>
                                                    </td>
                                                    <td width="20%" align="right">
                                                        <font color="#BD9999">
                                                            <%# int.Parse(ViewState["GridViewCount"].ToString()) - Container.DataItemIndex%>
                                                            楼</font> <a href='javascript:void(0)' onclick='huifu("回复：<%# int.Parse(ViewState["GridViewCount"].ToString()) - Container.DataItemIndex%>楼(<%# DataBinder.Eval(Container.DataItem, "Realname")%>)\n------------------------\n")'>
                                                                <font color="#0066CC">回复</font></a>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                            CommandName="ShanChu" ForeColor="#0066CC">删除</asp:LinkButton></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <%# ((Eval("Content").ToString().Replace("\n", "<br>").Replace(" ", "&nbsp;&nbsp;")))%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                        <ItemStyle Wrap="False" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                <SelectedRowStyle BackColor="White" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                <AlternatingRowStyle BackColor="White" />
                                <EmptyDataTemplate>
                                    <div align="center">
                                        <font color="white">无相关数据！</font></div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            &nbsp;
                        </div>
                    </td>
                </tr>
                <tr id="nextrs2" style="display: none">
                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                        <font color="red">※</font>讨论内容：</td>
                    <td class="newtd2" height="17" colspan="3">
                        <asp:TextBox ID="taolun" runat="server" Height="80px" TextMode="MultiLine" Width="100%"
                            MaxLength="4000"></asp:TextBox>
                    </td>
                </tr>
                <tr id="nextrs3" style="display: none">
                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                        <div align="center" id="Div2">
                            <asp:Button ID="Button2" runat="server" Text="提交讨论内容" CssClass="button_css" OnClick="Button2_Click" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="footer">
            <div class="footer_menu">
                <ul>
                    <%=ViewState["footulr"] %>
                </ul>
            </div>
        </div>

        <script>
            
            function aaa()
            {   
                if(document.getElementById('CheckBox1').checked)
                {
                   document.getElementById('nextrs1').style.display="";
                   document.getElementById('nextrs2').style.display="";
                   document.getElementById('nextrs3').style.display="";
                }
                else
                {
                   document.getElementById('nextrs1').style.display="none";
                   document.getElementById('nextrs2').style.display="none";
                   document.getElementById('nextrs3').style.display="none";
                }
            }
        
            function huifu(str)
            {
               document.getElementById('taolun').value=str;
               //document.getElementById('taolun').value=""+str+"";
               form1.taolun.focus();
            }
            
            function chknull()
            {

                if(document.getElementById('taolun').value=='')
                {
                    alert('讨论内容不能为空');
                    form1.taolun.focus();
                    return false;
                }
                LoadingShow();	
            }  
        </script>

    </form>
</body>
</html>
