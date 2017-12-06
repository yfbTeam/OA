<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_add_node_tjsz.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.WorkFlowName_show_add_node_tjsz" %>

<html>

<script>
function  adddatefile()  
{  

var num=Math.random();
var littleproduct=document.getElementById("DropDownList1");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;

if(cText=="请选择")
{
alert('请选择步骤!');
form1.DropDownList1.focus();
return false;
}
else
{
var KeyID=""+cValue+"";
window.showModalDialog("WorkFlowName_show_add_node_tjsz_add.aspx?tmp="+num+"&KeyID="+KeyID+"&FlowId=<%=Request.QueryString["id"]%>","window", "dialogWidth:460px;DialogHeight=280px;status:no;scroll=yes;help:no");  
}

}		

</script>

<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>
<base target="_self" />
</head>
<body class="newbody">
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        步骤序号：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:TextBox ID="NodeNum" runat="server" Width="100%" CssClass="ReadOnlyText"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        步骤名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="NodeName" runat="server" Width="100%" CssClass="ReadOnlyText"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        转入到步骤：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:DropDownList ID="DropDownList1" runat="server" Width="100%" AutoPostBack="True">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <asp:Button ID="Button2" runat="server" Text="设置转入条件" />
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="5" CellSpacing="1"
                                                            GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound"
                                                            PageSize="12" Style="font-size: 12px" Width="100%">
                                                            <PagerSettings Visible="False" />
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Name" HeaderText="字段名称" SortExpression="Name">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Type" HeaderText="字段类型" SortExpression="Type">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Conditions" HeaderText="条件判断" SortExpression="Conditions">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="JudgeBasis" HeaderText="判断依据" SortExpression="JudgeBasis">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="关联机制">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <%# ((Eval("JudgeType").ToString().Replace("&&", "和").Replace("||", "或")))%>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="相关操作">
                                                                    <HeaderStyle CssClass="newtitle"  Width="120px" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="XiuGai">修改</asp:LinkButton>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="ShanChu">删除</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="120px" Wrap="False" />
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
                                                        </asp:GridView><br><asp:Label ID="Label1" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <input id="Button3" class="button_css" onclick="javascript:window.close()" type="button"
                                                                    value="关 闭" /></font></div>
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
        <asp:TextBox ID="FormId" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FormNumber" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FormName" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowId" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowNumber" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowName" runat="server" Width="90%" Style="display: none"></asp:TextBox>
    </form>
</body>
</html>
