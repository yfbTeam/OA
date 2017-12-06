<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowListYj.aspx.cs"
    Inherits="xyoa.pda.WorkFlow.WorkFlowListYj" %>

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
<body>
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
                            <li><a id="A2" onclick="LoadingShow();location.href='WorkFlowListAll.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                全部工作</a></li>
                            <li><a id="A1" onclick="LoadingShow();location.href='WorkFlowList.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                未接收</a></li>
                            <li><a id="A3" onclick="LoadingShow();location.href='WorkFlowList_blz.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                办理中</a></li>
                            <li><a id="A4" onclick="LoadingShow();location.href='WorkFlowList_ybj.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                已办结</a></li>
                            <li><a id="A5" onclick="LoadingShow();location.href='WorkFlowList_ywt.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                已委托</a></li>
                            <li><a id="A6" onclick="LoadingShow();location.href='MyAddWorkFlow.aspx';">
                                <img border="0" alt="" src="/pda/images/myspace.png"><br>
                                我发起的</a></li>
                            <li><a id="A7" onclick="LoadingShow();location.href='MyAddWorkFlowJb.aspx';">
                                <img border="0" alt="" src="/pda/images/myspace.png"><br>
                                我经办过的</a></li>
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
                        <span class="t">查看办理意见</span></td>
                    <td width="45px" align="right">
                        <input id="meunbn" type="button" value="操作" class="button_shouji" width="45px" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divgrid" class="divheight">
            <table align="center" border="0" cellpadding="4" cellspacing="1" width="99%" class="nextpage">
                <tr>
                    <td align="left" class="newtd2" colspan="2" style="height: 22px">
                        <strong>流水号：</strong><%=ViewState["lshid"]%>
                        <strong>工作名称/文号：</strong><%=ViewState["whname"]%>
                        <asp:TextBox ID="whendname" runat="server" Width="94px" Visible="False" CssClass="Twhname2"></asp:TextBox>
                        <strong>当前步骤：</strong><%=ViewState["NodeName"]%>&nbsp;<strong>紧急程度：</strong><asp:Label
                            ID="JinJiChengDu" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2" class="newtd2">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="1"
                            GridLines="None" PageSize="12" Style="font-size: 12px" Width="97%">
                            <PagerSettings Visible="False" />
                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
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
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        电子印章：</td>
                    <td class="newtd2" height="17" width="85%">
                        <asp:DropDownList ID="Yinzhang" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr class="">
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        办理意见：</td>
                    <td class="newtd2" colspan="3" height="17" width="85%">
                        <asp:TextBox ID="SpContent" runat="server" Height="55px" TextMode="MultiLine" Width="95%"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="newtd2">
                        <asp:Button ID="Button2" runat="server" Text="保存意见" OnClick="Button2_Click" />
                        <asp:TextBox ID="GlNum" runat="server" Style="display: none"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <asp:TextBox ID="Number" runat="server" Visible="false"></asp:TextBox>
        </div>
        <div id="footer">
            <div class="footer_menu">
                <ul>
                    <%=ViewState["footulr"] %>
                </ul>
            </div>
        </div>
    </form>
</body>
</html>
