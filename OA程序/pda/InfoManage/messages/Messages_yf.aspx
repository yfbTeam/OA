<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Messages_yf.aspx.cs" Inherits="xyoa.pda.InfoManage.messages.Messages_yf" %>

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
        <div id="box" class="box">
            <div class="box_content">
                <div class="box_content_tab">
                    查询
                </div>
                <div class="box_content_center">
                    <div class="social_share">
                        <ul>
                            <li>消息内容：<asp:TextBox ID="titles" runat="server" Width="100px"></asp:TextBox></li>
                            <li>接收人员：<asp:TextBox ID="sendrealname" runat="server" Width="100px"></asp:TextBox></li>
                            <li>发送时间：<asp:TextBox ID="itimes" runat="server" Width="100px" onClick="WdatePicker()" readonly></asp:TextBox></li>
                        </ul>
                        <a id="boxclose" class="boxclose">关闭</a>
                        <asp:Button ID="Button4" runat="server" Text="提交" CssClass="form_submit" OnClick="Button4_Click" />
                    </div>
                    <div class="clear">
                    </div>
                </div>
            </div>
        </div>
        <div id="box_meun" class="box">
            <div class="box_content">
                <div class="box_content_tab">
                    操作菜单
                </div>
                <div class="box_content_center">
                    <div class="social_share">
                        <ul>
                            <li><a id="box_meun1" onclick="LoadingShow();location.href='Messages_add.aspx';">
                                <img border="0" alt="" src="/pda/images/technorati.png"><br>
                                发送消息</a></li>
                            <li><a id="box_meun4" onclick="showMenu();">
                                <img border="0" alt="" src="/pda/images/search.png"><br>
                                查询</a></li>
                            <li><a id="A2" onclick="LoadingShow();location.href='Messages.aspx';">
                                <img border="0" alt="" src="/pda/images/rss.png"><br>
                                已收消息 </a></li>
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
                        <span class="t">已发消息</span></td>
                    <td width="45px" align="right">
                        <input id="meunbn" type="button" value="操作" class="button_shouji" width="45px" />
                    </td>
                </tr>
            </table>
        </div>
        <div id="divgrid" class="divheight">
            <asp:GridView ID="GridView1" runat="server" Width="100%" AutoGenerateColumns="False"
                BackColor="White" BorderColor="White" BorderWidth="0px" CellPadding="0" ShowHeader="False"
                GridLines="None" AllowPaging="True" PageSize="12">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="corner_wrap" onclick="LoadingShow();location.href='Messages_yf_show.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id")%>';">
                                <h2>
                                    <img src='/oaimg/pda/<%# DataBinder.Eval(Container.DataItem, "sfck") %>.gif'><%# ((Eval("titles").ToString().Replace("<微笑>", "<img src=/oaimg/Face/0.gif border=0/>").Replace("<撇嘴>", "<img src=/oaimg/Face/1.gif border=0/>").Replace("<色>", "<img src=/oaimg/Face/2.gif border=0/>").Replace("<发呆>", "<img src=/oaimg/Face/3.gif border=0/>").Replace("<得意>", "<img src=/oaimg/Face/4.gif border=0/>").Replace("<流泪>", "<img src=/oaimg/Face/5.gif border=0/>").Replace("<害羞>", "<img src=/oaimg/Face/6.gif border=0/>").Replace("<闭嘴>", "<img src=/oaimg/Face/7.gif border=0/>").Replace("<睡>", "<img src=/oaimg/Face/8.gif border=0/>").Replace("<大哭>", "<img src=/oaimg/Face/9.gif border=0/>").Replace("<尴尬>", "<img src=/oaimg/Face/10.gif border=0/>").Replace("<发怒>", "<img src=/oaimg/Face/11.gif border=0/>").Replace("<调皮>", "<img src=/oaimg/Face/12.gif border=0/>").Replace("<呲牙>", "<img src=/oaimg/Face/13.gif border=0/>").Replace("<惊呆>", "<img src=/oaimg/Face/14.gif border=0/>").Replace("<难过>", "<img src=/oaimg/Face/15.gif border=0/>").Replace("<酷>", "<img src=/oaimg/Face/16.gif border=0/>").Replace("<冷汗>", "<img src=/oaimg/Face/17.gif border=0/>").Replace("<抓狂>", "<img src=/oaimg/Face/18.gif border=0/>").Replace("<吐>", "<img src=/oaimg/Face/19.gif border=0/>").Replace("<偷笑>", "<img src=/oaimg/Face/20.gif border=0/>").Replace("<可爱>", "<img src=/oaimg/Face/21.gif border=0/>").Replace("<白眼>", "<img src=/oaimg/Face/22.gif border=0/>").Replace("<傲慢>", "<img src=/oaimg/Face/23.gif border=0/>").Replace("<饥饿>", "<img src=/oaimg/Face/24.gif border=0/>").Replace("<困>", "<img src=/oaimg/Face/25.gif border=0/>").Replace("<惊恐>", "<img src=/oaimg/Face/26.gif border=0/>").Replace("<流汗>", "<img src=/oaimg/Face/27.gif border=0/>").Replace("<憨笑>", "<img src=/oaimg/Face/28.gif border=0/>").Replace("<大兵>", "<img src=/oaimg/Face/29.gif border=0/>").Replace("<奋斗>", "<img src=/oaimg/Face/30.gif border=0/>").Replace("<咒骂>", "<img src=/oaimg/Face/31.gif border=0/>").Replace("<疑问>", "<img src=/oaimg/Face/32.gif border=0/>").Replace("<嘘>", "<img src=/oaimg/Face/33.gif border=0/>").Replace("<晕>", "<img src=/oaimg/Face/34.gif border=0/>").Replace("<折磨>", "<img src=/oaimg/Face/35.gif border=0/>").Replace("<衰>", "<img src=/oaimg/Face/36.gif border=0/>").Replace("<骷髅>", "<img src=/oaimg/Face/37.gif border=0/>").Replace("<敲打>", "<img src=/oaimg/Face/38.gif border=0/>").Replace("<再见>", "<img src=/oaimg/Face/39.gif border=0/>").Replace("<插汗>", "<img src=/oaimg/Face/40.gif border=0/>").Replace("<抠鼻>", "<img src=/oaimg/Face/41.gif border=0/>").Replace("<鼓掌>", "<img src=/oaimg/Face/42.gif border=0/>").Replace("<糗大了>", "<img src=/oaimg/Face/43.gif border=0/>").Replace("<坏笑>", "<img src=/oaimg/Face/44.gif border=0/>").Replace("<左哼哼>", "<img src=/oaimg/Face/45.gif border=0/>").Replace("<右哼哼>", "<img src=/oaimg/Face/46.gif border=0/>").Replace("<哈欠>", "<img src=/oaimg/Face/47.gif border=0/>").Replace("<鄙视>", "<img src=/oaimg/Face/48.gif border=0/>").Replace("<委屈>", "<img src=/oaimg/Face/49.gif border=0/>").Replace("<快哭了>", "<img src=/oaimg/Face/50.gif border=0/>").Replace("<阴险>", "<img src=/oaimg/Face/51.gif border=0/>").Replace("<亲亲>", "<img src=/oaimg/Face/52.gif border=0/>").Replace("<吓>", "<img src=/oaimg/Face/53.gif border=0/>").Replace("<可怜>", "<img src=/oaimg/Face/54.gif border=0/>").Replace("<菜刀>", "<img src=/oaimg/Face/55.gif border=0/>").Replace("<OK>", "<img src=/oaimg/Face/55.gif border=0/>")))%>
                                </h2>
                                <h1>
                                    <%# DataBinder.Eval(Container.DataItem, "acceptrealname")%>
                                    <%# DataBinder.Eval(Container.DataItem, "itimes")%>
                                </h1>
                                <div class="clear">
                                </div>
                            </div>
                            <div class="shadow_wrap">
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerSettings Visible="False" />
                <EmptyDataTemplate>
                    <div align="center">
                        <font color="black">无数据</font></div>
                </EmptyDataTemplate>
            </asp:GridView>
        </div>
        <div id="fenye">
            <div class="fenye_menu">
                <ul>
                    <li>
                        <asp:Button ID="btnFirst" runat="server" Text="首页" OnClick="btnPrev_Click" />
                    </li>
                    <li>
                        <asp:Button ID="btnPrev" runat="server" Text="上页" OnClick="btnPrev_Click" />
                    </li>
                    <li>
                        <asp:Button ID="btnNext" runat="server" Text="下页" OnClick="btnPrev_Click" />
                    </li>
                    <li>
                        <asp:Button ID="btnLast" runat="server" Text="尾页" OnClick="btnPrev_Click" />
                    </li>
                </ul>
            </div>
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
