<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chaxun_Bys.aspx.cs" Inherits="xyoa.SchTable.Xueji.Chaxun.Chaxun_Bys" %>
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
                                                runat="server" id="Button3"><font class="shadow_but">综合查询</font></button>
                                            <button class="btn4off" type="button" onclick="javascript:window.location='Chaxun_Bys.aspx';"
                                                runat="server" id="Button6"><font class="shadow_but">毕业生查询</font></button>
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
                            <td width="44" height="100%" align="center" valign="top" bgcolor="#FFFFFF">
                                学期
                            </td>
                            <td width="137" height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Xueqi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Xueqi_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="44" height="100%" align="center" valign="top" bgcolor="#FFFFFF">
                                学期段
                            </td>
                            <td width="137" height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Xueduan" runat="server">
                                    <asp:ListItem>上学期</asp:ListItem>
                                    <asp:ListItem>下学期</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="44" height="100%" align="center" valign="top" bgcolor="#FFFFFF">
                                年级
                            </td>
                            <td width="137" height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Nianji" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Nianji_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="44" height="100%" align="center" valign="top" bgcolor="#FFFFFF">
                                班级
                            </td>
                            <td width="137" height="100%" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="BanJi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="BanJi_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td width="44" align="center" valign="top" bgcolor="#FFFFFF">
                                学生名
                            </td>
                            <td width="137" valign="top" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="XsId" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" colspan="2" align="center" valign="top" bgcolor="#FFFFFF">
                                <asp:Button ID="Button4" runat="server" Text="查 询" OnClick="Button4_Click" />
                                <asp:Button ID="Button5" runat="server" Text="导出Excel" OnClick="Button5_Click" />
                                <asp:Button ID="Button2" runat="server" Text="导出Word" OnClick="Button2_Click" />
                                </td>
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
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound"
                                                        PageSize="12" Style="font-size: 12px" Width="100%" ShowHeader="False" BorderWidth="0px">
                                                        <PagerSettings Visible="False" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemStyle Wrap="True" />
                                                                <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                <ItemTemplate>
                                                                 <asp:Label ID="GrXsId" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "XsId")%>'
                                                                        Visible="false"></asp:Label>
                                                                        
                                                                    <table align="center" border="1" bordercolor="black" cellpadding="4" cellspacing="0" style="width: 100%; border-collapse: collapse">
                                                                        <tr>
                                                                            <td  colspan="8" style="height: 26px">
                                                                                <b>基本信息</b></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                学生姓名：</td>
                                                                            <td  height="17" width="20%">
                                                                                <asp:Label ID="Xingming" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                性别：</td>
                                                                            <td  height="17" width="20%">
                                                                                <asp:Label ID="Xingbie" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                出生日期：</td>
                                                                            <td height="17" colspan="2" width="20%" >
                                                                                <asp:Label ID="Chusheng" runat="server"></asp:Label></td>
                                                                            <td width="25%" rowspan="4" >
                                                                                <asp:Image ID="Zhaopian" runat="server" />
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                民族：</td>
                                                                            <td  height="17" width="20%">
                                                                                <asp:Label ID="Mingzhu" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                籍贯：</td>
                                                                            <td  height="17" width="20%">
                                                                                <asp:Label ID="Jiguan" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                出生地：</td>
                                                                            <td height="17" colspan="2" width="20%" >
                                                                                <asp:Label ID="Chushengdi" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                政治面貌：</td>
                                                                            <td  height="17" width="20%">
                                                                                <asp:Label ID="Zhengzhimianmhao" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                来源校(园)：</td>
                                                                            <td  height="17" width="20%">
                                                                                <asp:Label ID="Laiyuanxiao" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                身份证号：</td>
                                                                            <td height="17" colspan="2" width="20%" >
                                                                                <asp:Label ID="Shengfenzheng" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                健康状况：</td>
                                                                            <td  height="17" width="20%">
                                                                                <asp:Label ID="Jiangkan" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                联系电话：</td>
                                                                            <td  height="17" width="20%">
                                                                                <asp:Label ID="Dianhua" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                家庭住址：</td>
                                                                            <td height="17" colspan="2" width="20%" >
                                                                                <asp:Label ID="Dizhi" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                邮编：</td>
                                                                            <td  height="17" width="20%">
                                                                                <asp:Label ID="Youbian" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                通信地址：</td>
                                                                            <td  height="17" width="45%" colspan="3">
                                                                                <asp:Label ID="Tongxin" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td align="right"  height="17" nowrap="nowrap" width="5%">
                                                                                电子邮箱：</td>
                                                                            <td  height="17" width="20%">
                                                                                <asp:Label ID="Youxiang" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                    </table><br>
                                                                    <asp:Label ID="JiaTingXinxi" runat="server"></asp:Label>
                                                                  <br>
                                                                  <asp:Label ID="Chengji" runat="server"></asp:Label>
                                                                   <br>
                                                                    <asp:Label ID="Pingyu" runat="server"></asp:Label>
                                                                  
                                                                    <br><hr color=black><br>
                                                                </ItemTemplate>
                                                                <FooterStyle Wrap="True" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle Wrap="False" />
                                                    </asp:GridView>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="17">
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
                <td width="5">
                    &nbsp;
                </td>
            </tr>
        </table>
        <input id="Hidden1" type="hidden" />
        <asp:TextBox ID="BiYeId" runat="server" Visible=false></asp:TextBox>
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
