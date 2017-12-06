<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Chaxun_Zh.aspx.cs" Inherits="xyoa.SchTable.Xueji.Chaxun.Chaxun_Zh" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script language="javascript">
    function visible_click()
    {
   
        if(document.getElementById('td1').style.display=="")
        {
            document.getElementById('td1').style.display="none";
        }
        else
        {
            document.getElementById('td1').style.display="";
        }
    }           

    </script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td height="35">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="17">
                                &nbsp;
                            </td>
                            <td valign="top">
                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%">
                                            <img src="/oaimg/top_3.gif"></td>
                                        <td width="81%" valign="bottom">
                                            学生查询</td>
                                        <td width="16%">
                                            &nbsp;
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
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="35">
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="17">
                                &nbsp;
                            </td>
                            <td valign="top">
                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                    cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                        <td style="height: 26px;">
                                            <button class="btn4off" type="button" onclick="javascript:window.location='Chaxun.aspx';"
                                                runat="server" id="Button1">
                                                <font class="shadow_but">班级/年级查询</font></button>
                                            <button class="btn4off" type="button" onclick="javascript:window.location='Chaxun_Zh.aspx';"
                                                runat="server" id="Button2">
                                                <font class="shadow_but">综合查询</font></button>
                                            <button class="btn4off" type="button" onclick="javascript:window.location='Chaxun_Bys.aspx';"
                                                runat="server" id="Button3">
                                                <font class="shadow_but">毕业生查询</font></button>
                                            <a href="javascript:void(0)" onclick="visible_click()">
                                                <img src="/oaimg/menu/yc.gif" border="0" /></a>
                                        </td>
                                        <td style="height: 26px" align="right">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="17">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table align="center" border="0" cellpadding="4" cellspacing="0" width="100%" height="<%=ViewState["tableheigh"] %>">
            <tr>
                <td width="5">
                    &nbsp;
                </td>
                <td class="newtd2" width="200px" height="100%" valign="top" id="td1">
                    <table width="200" height="25px" border="0" cellpadding="0" cellspacing="1" class="maincss">
                        <tr>
                            <td height="25px" align="center" valign="top" bgcolor="#FFFFFF" colspan="2">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="25" class="mainbody1" height="25" align="center">
                                            <img src="/oaimg/menu/Menu4.gif" /></td>
                                        <td width="175" class="mainbody1" height="25">
                                            <strong><font color="#0F62A4">选择查询条件</font></strong></td>
                                        <td width="45" class="mainbody1" height="25" align="center">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="200" border="0" cellpadding="4" cellspacing="1" class="maincss">
                        <tr>
                            <td width="80" align="center" valign="top" bgcolor="#FFFFFF">
                                学期
                            </td>
                            <td width="120" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Xueqi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Xueqi_SelectedIndexChanged"
                                    Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                学期段
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Xueduan" runat="server" Width="100%">
                                    <asp:ListItem>上学期</asp:ListItem>
                                    <asp:ListItem>下学期</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                年级
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Nianji" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Nianji_SelectedIndexChanged"
                                    Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                班级
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="BanJi" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                性别
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Xingbie" runat="server" Width="100%">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>男</asp:ListItem>
                                    <asp:ListItem>女</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                民族
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Mingzhu" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                政治面貌
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Zhengzhimianmhao" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#FFFFFF">
                                来源校
                            </td>
                            <td valign="top" bgcolor="#FFFFFF">
                                <asp:TextBox ID="Laiyuanxiao" runat="server" Width="100%"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                学籍状态
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="XuejiZhuangtai" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                职务
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Zhiwu" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                健康状况
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Jiangkan" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                生源类别
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Shengyuan" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                户口类型
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="HukouLeixing" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                户口性质
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="HukouXingzhi" runat="server" Width="100%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                三残
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Sancan" runat="server" Width="100%">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>智力残疾</asp:ListItem>
                                    <asp:ListItem>视力残疾</asp:ListItem>
                                    <asp:ListItem>听力残疾</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                留守儿童
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="LiushouErtong" runat="server" Width="100%">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                农民工子女
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Nongminggao" runat="server" Width="100%">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                军人子女
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Junrenzinv" runat="server" Width="100%">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                教师子女
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Jiaoshizinv" runat="server" Width="100%">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                单亲家庭
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Danqinjiating" runat="server" Width="100%">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                独生子女
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Dushengzinv" runat="server" Width="100%">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" bgcolor="#FFFFFF">
                                贫困生
                            </td>
                            <td height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Pingkunsheng" runat="server" Width="100%">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>是</asp:ListItem>
                                    <asp:ListItem>否</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" bgcolor="#FFFFFF">
                                学生姓名
                            </td>
                            <td valign="top" bgcolor="#FFFFFF">
                                <asp:TextBox ID="Xingming" runat="server" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" colspan="2" align="center" valign="top" bgcolor="#FFFFFF">
                                &nbsp;<asp:Button ID="Button4" runat="server" Text="查 询" OnClick="Button4_Click" /></td>
                        </tr>
                    </table>
                </td>
                <td class="newtd2" valign="top" height="100%" id="td2">
                    <asp:Panel ID="Panel1" runat="server">
                        <div align="center">
                            <asp:Label ID="Label1" runat="server" Text="请先选择查询条件" Font-Bold="True" ForeColor="Red"></asp:Label>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="17">
                                </td>
                                <td valign="top">
                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                        <tr>
                                            <td valign="top">
                                                <div id="Div1">
                                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                        AutoGenerateColumns="False" BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None"
                                                        BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                        OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%">
                                                        <PagerSettings Visible="False" />
                                                        <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                        <Columns>
                                                            <asp:BoundField DataField="Nianji" HeaderText="年级" SortExpression="Nianji">
                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="BanJiName" HeaderText="班级" SortExpression="A.BanJi">
                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="学生姓名" SortExpression="A.Xingming">
                                                                <ItemStyle Wrap="True" />
                                                                <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                <ItemTemplate>
                                                                    <a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open ("/SchTable/Xueji/ZaijiSheng/ZaijiSheng_lb_show.aspx?id=<%#DataBinder.Eval(Container.DataItem, "id")%>&Xueduan=<%#DataBinder.Eval(Container.DataItem, "Xueduan")%>&Xueqi=<%#DataBinder.Eval(Container.DataItem, "Xueqi")%>", "_blank", "height=" + ah + ", width=" + aw + ",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=" + loc_y + ",left=" + loc_x + "")'>
                                                                        <%# DataBinder.Eval(Container.DataItem, "Xingming")%>
                                                                    </a>
                                                                </ItemTemplate>
                                                                <FooterStyle Wrap="True" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Xuejihao" HeaderText="学籍号" SortExpression="Xuejihao">
                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Xuehao" HeaderText="学号" SortExpression="Xuehao">
                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Xingbie" HeaderText="性别" SortExpression="Xingbie">
                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="民族" SortExpression="Mingzhu">
                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="Mingzhu" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "Mingzhu")%>'
                                                                        Visible="false"></asp:Label>
                                                                    <asp:Label ID="LMingzhu" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Jiguan" HeaderText="籍贯" SortExpression="Jiguan">
                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField HeaderText="出生日期" SortExpression="Chusheng">
                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                <ItemTemplate>
                                                                    <%# ((Eval("Chusheng").ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "")))%>
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="学籍状态" SortExpression="XuejiZhuangtai">
                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="XuejiZhuangtai" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "XuejiZhuangtai")%>'
                                                                        Visible="false"></asp:Label>
                                                                    <asp:Label ID="LXuejiZhuangtai" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="户口类型" SortExpression="HukouLeixing">
                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="HukouLeixing" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "HukouLeixing")%>'
                                                                        Visible="false"></asp:Label>
                                                                    <asp:Label ID="LHukouLeixing" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle Wrap="False" HorizontalAlign="Left" />
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="Dianhua" HeaderText="联系电话" SortExpression="Dianhua">
                                                                <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                <ItemStyle Wrap="False" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                        <RowStyle BackColor="#FBFCFE" ForeColor="Black" />
                                                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                                                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                                                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True"  Wrap="False" />
                                                        <AlternatingRowStyle BackColor="#F7F7F7" />
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
                                <td width="17">
                                </td>
                            </tr>
                        </table>
                        <div>
                            <table width="100%" height="34" border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="17">
                                    </td>
                                    <td valign="top" background="/<%=Session["yangshi"]%>/next_bg.jpg" align="center">
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:LinkButton ID="btnFirst" runat="server" CssClass="line" CommandArgument="first"
                                                        OnClick="PagerButtonClick">首页</asp:LinkButton>
                                                    &nbsp;&nbsp;<asp:LinkButton ID="btnPrev" runat="server" CssClass="line" CommandArgument="prev"
                                                        OnClick="PagerButtonClick">上页</asp:LinkButton>
                                                    &nbsp;&nbsp;<asp:LinkButton ID="btnNext" runat="server" CssClass="line" CommandArgument="next"
                                                        OnClick="PagerButtonClick">下页</asp:LinkButton>
                                                    &nbsp;&nbsp;<asp:LinkButton ID="btnLast" runat="server" CssClass="line" CommandArgument="last"
                                                        OnClick="PagerButtonClick">尾页</asp:LinkButton>
                                                    &nbsp;&nbsp;<font color="#000000">页码：<asp:TextBox ID="GoPage" runat="server" Width="25px"></asp:TextBox>
                                                        <asp:Button ID="Button6" runat="server" CssClass="button_jdkd" Text="跳转" Width="36px"
                                                            Height="20px" OnClick="Button1_Click1" />
                                                        &nbsp;&nbsp;每页<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True"
                                                            OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                            <asp:ListItem>10</asp:ListItem>
                                                            <asp:ListItem>15</asp:ListItem>
                                                            <asp:ListItem>25</asp:ListItem>
                                                            <asp:ListItem>50</asp:ListItem>
                                                            <asp:ListItem>80</asp:ListItem>
                                                            <asp:ListItem>100</asp:ListItem>
                                                        </asp:DropDownList>条数据&nbsp; 共有<font color="red"><asp:Label ID="CountsLabel" runat="server"></asp:Label></font>条数据
                                                        &nbsp;&nbsp;当前为第<font color="red"><asp:Label ID="CurrentlyPageLabel" runat="server"></asp:Label></font>页
                                                        &nbsp;&nbsp; 共<font color="red"><asp:Label ID="AllPageLabel" runat="server"></asp:Label></font>页</font>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="17">
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </asp:Panel>
                </td>
                <td width="5">
                    &nbsp;
                </td>
            </tr>
        </table>
        <input id="Hidden1" type="hidden" />
        <input id="SortText" type="hidden" runat="server" value="order by A.Banji asc" />

        <script type="text/javascript">
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
