<%@ Page Language="C#" AutoEventWireup="true" Codebehind="mymessage.aspx.cs" Inherits="xyoa.Client.mymessage" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script>
function openwindows(urlstr)
{
    //控件宽
    var aw = 695;
    //控件高
    var ah = 466;
    //计算控件水平位置
    var al = (screen.width - aw)/2-100;
    //计算控件垂直位置
    var at = (screen.height - ah)/5;
    window.open("/Client/urlcheck.aspx?url="+urlstr+"&user=<%=Request.QueryString["user"].ToString() %>&pwd=<%=Request.QueryString["pwd"].ToString() %>","_blank","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
}
    </script>

</head>
<body class="newbody" oncontextmenu="return false">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <div id="Div1">
                                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                                BorderColor="#3366CC" BorderWidth="0px" CellPadding="4" PageSize="6" Style="font-size: 12px"
                                                                Width="100%" ShowHeader="False" OnRowDataBound="GridView1_RowDataBound">
                                                                <PagerSettings Visible="False" />
                                                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="消息标题" SortExpression="titles">
                                                                        <ItemStyle Wrap="True" />
                                                                        <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Lid" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "id")%>'
                                                                                Visible="false"></asp:Label>
                                                                            <table class="nextpage" width="100%" cellspacing="0" cellpadding="2">
                                                                                <tr>
                                                                                    <td class="newtitle">
                                                                                        <img src='/InfoManage/nbemail/<%# DataBinder.Eval(Container.DataItem, "sfck") %>.gif'
                                                                                            align="absMiddle">
                                                                                        <a href='javascript:void(0)' onclick='openwindows("/senduser.aspx?user=<%# DataBinder.Eval(Container.DataItem, "sendusername") %>")', "_blank", "height=500, width=600,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=200,left=350")'>
                                                                                            <font style="font-size:12px; color:Red;">
                                                                                                <%# DataBinder.Eval(Container.DataItem, "sendrealname")%>
                                                                                                ： </font></a>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td class="newtd2">
                                                                                        <%# ((Eval("titles").ToString().Replace("<微笑>", "<img src=/oaimg/Face/0.gif border=0/>").Replace("<撇嘴>", "<img src=/oaimg/Face/1.gif border=0/>").Replace("<色>", "<img src=/oaimg/Face/2.gif border=0/>").Replace("<发呆>", "<img src=/oaimg/Face/3.gif border=0/>").Replace("<得意>", "<img src=/oaimg/Face/4.gif border=0/>").Replace("<流泪>", "<img src=/oaimg/Face/5.gif border=0/>").Replace("<害羞>", "<img src=/oaimg/Face/6.gif border=0/>").Replace("<闭嘴>", "<img src=/oaimg/Face/7.gif border=0/>").Replace("<睡>", "<img src=/oaimg/Face/8.gif border=0/>").Replace("<大哭>", "<img src=/oaimg/Face/9.gif border=0/>").Replace("<尴尬>", "<img src=/oaimg/Face/10.gif border=0/>").Replace("<发怒>", "<img src=/oaimg/Face/11.gif border=0/>").Replace("<调皮>", "<img src=/oaimg/Face/12.gif border=0/>").Replace("<呲牙>", "<img src=/oaimg/Face/13.gif border=0/>").Replace("<惊呆>", "<img src=/oaimg/Face/14.gif border=0/>").Replace("<难过>", "<img src=/oaimg/Face/15.gif border=0/>").Replace("<酷>", "<img src=/oaimg/Face/16.gif border=0/>").Replace("<冷汗>", "<img src=/oaimg/Face/17.gif border=0/>").Replace("<抓狂>", "<img src=/oaimg/Face/18.gif border=0/>").Replace("<吐>", "<img src=/oaimg/Face/19.gif border=0/>").Replace("<偷笑>", "<img src=/oaimg/Face/20.gif border=0/>").Replace("<可爱>", "<img src=/oaimg/Face/21.gif border=0/>").Replace("<白眼>", "<img src=/oaimg/Face/22.gif border=0/>").Replace("<傲慢>", "<img src=/oaimg/Face/23.gif border=0/>").Replace("<饥饿>", "<img src=/oaimg/Face/24.gif border=0/>").Replace("<困>", "<img src=/oaimg/Face/25.gif border=0/>").Replace("<惊恐>", "<img src=/oaimg/Face/26.gif border=0/>").Replace("<流汗>", "<img src=/oaimg/Face/27.gif border=0/>").Replace("<憨笑>", "<img src=/oaimg/Face/28.gif border=0/>").Replace("<大兵>", "<img src=/oaimg/Face/29.gif border=0/>").Replace("<奋斗>", "<img src=/oaimg/Face/30.gif border=0/>").Replace("<咒骂>", "<img src=/oaimg/Face/31.gif border=0/>").Replace("<疑问>", "<img src=/oaimg/Face/32.gif border=0/>").Replace("<嘘>", "<img src=/oaimg/Face/33.gif border=0/>").Replace("<晕>", "<img src=/oaimg/Face/34.gif border=0/>").Replace("<折磨>", "<img src=/oaimg/Face/35.gif border=0/>").Replace("<衰>", "<img src=/oaimg/Face/36.gif border=0/>").Replace("<骷髅>", "<img src=/oaimg/Face/37.gif border=0/>").Replace("<敲打>", "<img src=/oaimg/Face/38.gif border=0/>").Replace("<再见>", "<img src=/oaimg/Face/39.gif border=0/>").Replace("<插汗>", "<img src=/oaimg/Face/40.gif border=0/>").Replace("<抠鼻>", "<img src=/oaimg/Face/41.gif border=0/>").Replace("<鼓掌>", "<img src=/oaimg/Face/42.gif border=0/>").Replace("<糗大了>", "<img src=/oaimg/Face/43.gif border=0/>").Replace("<坏笑>", "<img src=/oaimg/Face/44.gif border=0/>").Replace("<左哼哼>", "<img src=/oaimg/Face/45.gif border=0/>").Replace("<右哼哼>", "<img src=/oaimg/Face/46.gif border=0/>").Replace("<哈欠>", "<img src=/oaimg/Face/47.gif border=0/>").Replace("<鄙视>", "<img src=/oaimg/Face/48.gif border=0/>").Replace("<委屈>", "<img src=/oaimg/Face/49.gif border=0/>").Replace("<快哭了>", "<img src=/oaimg/Face/50.gif border=0/>").Replace("<阴险>", "<img src=/oaimg/Face/51.gif border=0/>").Replace("<亲亲>", "<img src=/oaimg/Face/52.gif border=0/>").Replace("<吓>", "<img src=/oaimg/Face/53.gif border=0/>").Replace("<可怜>", "<img src=/oaimg/Face/54.gif border=0/>").Replace("<菜刀>", "<img src=/oaimg/Face/55.gif border=0/>").Replace("<OK>", "<img src=/oaimg/Face/55.gif border=0/>")))%>
                                                                                        <br>
                                                                                        <i>
                                                                                            <%# DataBinder.Eval(Container.DataItem, "itimes")%>
                                                                                        </i>
                                                                                        <br>
                                                                                        <div align="right">
                                                                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                                                                            <a href='javascript:void(0)' onclick='openwindows("/InfoManage/messages/talk.aspx?user=<%# DataBinder.Eval(Container.DataItem, "sendusername") %>")', "_blank", "height=500, width=600,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=200,left=350")'>
                                                                                                回复</a>&nbsp;
                                                                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                                                                            <a href="messagedel.aspx?delid=<%# DataBinder.Eval(Container.DataItem, "id") %>&user=<%=Request.QueryString["user"].ToString() %>&pwd=<%=Request.QueryString["pwd"].ToString() %>">
                                                                                                删除</a>&nbsp;
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                        <FooterStyle Wrap="True" />
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <RowStyle BackColor="White" ForeColor="#003399" />
                                                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                                                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                                                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" Wrap="False" />
                                                                <EmptyDataTemplate>
                                                                    <div align="center">
                                                                        <font color="white">无相关数据！</font></div>
                                                                </EmptyDataTemplate>
                                                            </asp:GridView>
                                                            &nbsp;
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
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
