﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyPlanJk_lb_show.aspx.cs"
    Inherits="xyoa.OfficeMenu.WorkPlan.MyPlanJk_lb_show" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body class="newbody" onload="aaa()">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0" id="printshow1">
                        <tr>
                            <td>
                                <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox></td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0" id="printshow2">
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
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="MyPlanJk_lb.aspx">计划监控</a> >> 查看监控计划</td>
                                                        <td width="16%">
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
                                <div id="printshow3">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="20%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">计划监控</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            <input id="Button3" type="button" value="打 印" onclick="printnewpage()" class="button_css" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage"
                                                id="tableprint">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        计划标题：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Label ID="Biaoti" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        计划类型：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Leixing" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        优先级：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Youxian" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        开始时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="StartTime" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        结束时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="EndTime" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        当前状态：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="DqState" runat="server"></asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        计划内容：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="Neirong" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr class="" id="nextrs22">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        附件：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:Label ID="fujian" runat="server" Width="90%"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        领导阅读情况：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="YdRealname" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        计划共享：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="Sharing" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="gx1" style="<%=ViewState["Sharing"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        只读共享人员：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="SharingNameZd" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="gx2" style="<%=ViewState["Sharing"] %>">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        可写共享人员：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="SharingNameKx" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center" id="printshow4">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button4" runat="server" Text="返 回" CssClass="button_css" OnClick="Button2_Click" />
                                                            </font>
                                                        </div>
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
                                                                                        <a href='javascript:void(0)' onclick='senduser("<%# DataBinder.Eval(Container.DataItem, "Username")%>")'>
                                                                                            <font color="#0066CC"><b>
                                                                                                <%# DataBinder.Eval(Container.DataItem, "Realname")%>
                                                                                            </b></font></a>&nbsp;&nbsp;&nbsp;<font color="#BD9999"><%# DataBinder.Eval(Container.DataItem, "Settime")%></font>
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
                                                            <asp:Button ID="Button2" runat="server" Text="提交讨论内容" CssClass="button_css" OnClick="Button1_Click" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>

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
                showwait();	
            }  
        </script>

    </form>
</body>
</html>
