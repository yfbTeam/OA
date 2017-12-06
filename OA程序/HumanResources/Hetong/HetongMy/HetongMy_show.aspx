<%@ Page Language="C#" AutoEventWireup="true" Codebehind="HetongMy_show.aspx.cs"
    Inherits="xyoa.HumanResources.Hetong.HetongMy.HetongMy_show" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <style type="text/css"> 
.mbcss {
border-left:0px;
border-top:0px;
border-right:0px;
border-bottom:1px solid #000000
}
</style>
</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0" id="printshow1">
                        <tr>
                            <td>
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
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="HetongMy.aspx">我的合同</a>
                                                            >> 查看我的合同</td>
                                                        <td width="16%">
                                                            &nbsp;</td>
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
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">合同信息</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                            <input id="Button1" type="button" value="返 回" onclick="history.go(-1)" class="button_css" />
                                                            <input id="Button3" type="button" value="打 印" onclick="printnewpage()" class="button_css" /></td>
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
                                                        签约合同：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="LeibieID" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        签定日期：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="QdTime" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd1" width="15%" align="right">
                                                        签约人：
                                                    </td>
                                                    <td class="newtd2" width="35%">
                                                        <asp:Label ID="QyRealname" runat="server"></asp:Label>
                                                    </td>
                                                    <td class="newtd1" width="15%" align="right">
                                                        合同状态：
                                                    </td>
                                                    <td class="newtd2" width="35%">
                                                        <asp:Label ID="Zhuangtai" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd1" width="15%" align="right">
                                                        合同生效日期：
                                                    </td>
                                                    <td class="newtd2" width="35%">
                                                        <asp:Label ID="Starttime" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td class="newtd1" width="15%" align="right">
                                                        合同期限：
                                                    </td>
                                                    <td class="newtd2" width="35%">
                                                        <asp:Label ID="Qixian" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="Panel1" runat="server">
                                                    <tr id="trDept">
                                                        <td class="newtd1" width="15%" align="right">
                                                            合同终止日期：
                                                        </td>
                                                        <td class="newtd2" width="85%" colspan="3">
                                                            <asp:Label ID="Endtime" runat="server"></asp:Label>&nbsp;
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td class="newtd2" colspan="4">
                                                        <asp:Label ID="Label1" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>合同操作日志</b><asp:CheckBox ID="CheckBox1" runat="server" onclick="aaa()" /></td>
                                                </tr>
                                                <tr id="nextrs1" style="display: none">
                                                    <td class="newtd2" nowrap="nowrap" colspan="4">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="4" CellSpacing="1"
                                                            GridLines="None" OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                            Width="100%">
                                                            <PagerSettings Visible="False" />
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:BoundField DataField="QyRealname" HeaderText="合同签约人" SortExpression="QyRealname">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="LeibieName" HeaderText="签约合同" SortExpression="LeibieName">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="日志类型" SortExpression="A.Leixing">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <%# ((Eval("Leixing").ToString().Replace("1", "合同新签").Replace("2", "合同变更").Replace("3", "合同续签").Replace("4", "合同解除").Replace("5", "合同终止").Replace("6", "合同修改").Replace("7", "到期终止")))%>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="操作人" SortExpression="Realname">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <a href='javascript:void(0)' onclick='senduser("<%# DataBinder.Eval(Container.DataItem, "Username")%>")'>
                                                                            <%# DataBinder.Eval(Container.DataItem, "Realname")%>
                                                                        </a>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="SetTimes" HeaderText="操作时间" SortExpression="SetTimes">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    <ItemStyle Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="操作">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" HorizontalAlign="Center"
                                                                        Width="50px" />
                                                                    <ItemTemplate>
                                                                        <a href='javascript:void(0)' class="LinkLine" onclick='openbd("<%# DataBinder.Eval(Container.DataItem, "Xiangqing")%>")'>
                                                                            对应表单</a>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" />
                                                                </asp:TemplateField>
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
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center" id="printshow4">
                                                            <font face="宋体">
                                                                <input id="Button2" type="button" value="返 回" onclick="history.go(-1)" class="button_css" />
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
                }
                else
                {
                   document.getElementById('nextrs1').style.display="none";
                }
            }
            function openbd(biaodan)
            {
                if(biaodan=="#")
                {
                    alert('无对应表单');
                }
                else
                {
                    var num=Math.random();
                    window.showModalDialog("/"+biaodan+"&tmp="+num+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no"); 
                }
            }   
        </script>

    </form>
</body>
</html>
