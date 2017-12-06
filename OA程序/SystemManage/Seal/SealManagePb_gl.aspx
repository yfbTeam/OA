<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SealManagePb_gl.aspx.cs"
    Inherits="xyoa.SystemManage.Seal.SealManagePb_gl" %>

<html>
<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox></td>
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
                                                            <a href="SealManagePb.aspx">公章维护</a>
                                                            >> 查看公章</td>
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
                                                                <font class="shadow_but">公章维护</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css" OnClick="Button2_Click1" /></td>
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
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        印章名称：</td>
                                                    <td class="newtd2" colspan="3" width="85%" style="height: 17px">
                                                        <asp:TextBox ID="Name" runat="server" Width="100%" CssClass="ReadOnlyText" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        印章：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="85%">
                                                        <asp:Image ID="Newname" runat="server" /></td>
                                                </tr>
                                                <tr id="Tr1">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体"><strong>印章使用人</strong></font></div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="newtd2" colspan="4" height="26" width="33%">
                                                        增加使用人：
                                                        <asp:TextBox ID="Realname" runat="server" Width="19%" CssClass="ReadOnlyText"></asp:TextBox><a href="javascript:void(0)"><img
                                                            onclick="openuser();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                        <asp:Button ID="Button1" runat="server" OnClick="Button2_Click" Text="确定增加" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="newtd2" colspan="4" height="26" width="33%">
                                                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True"
                                                            AutoGenerateColumns="False" BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None"
                                                            BorderWidth="1px" CellPadding="4" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                            OnSorting="GridView1_Sorting" PageSize="6" Style="font-size: 12px" Width="100%"
                                                            OnRowCommand="GridView1_RowCommand">
                                                            <PagerSettings Visible="False" />
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Name" HeaderText="印章名称" SortExpression="Name">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="State" HeaderText="印章状态" SortExpression="State">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Realname" HeaderText="印章使用人" SortExpression="Realname">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="相关操作">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" Width="160px" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="LinkButton3" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="Chongzhi">密码重置</asp:LinkButton>
                                                                        <asp:LinkButton ID="LinkButton2" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="Tingzhi">停止</asp:LinkButton>
                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="ShanChu">删除</asp:LinkButton>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="160px" />
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
        <asp:TextBox ID="Username" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	


function chksyr()
{
    if(document.getElementById('Realname').value=='')
    {
    alert('使用人不能为空');
    form1.Realname.focus();
    return false;
    }	
    
    showwait();	
}  




var  wName_3;  
function  openuser()  
{  
var num=Math.random();
var str=""+document.getElementById('Username').value+"|"+document.getElementById('Realname').value+"";
wName_3=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
for(var i=0;i<arr.length;i++)
{ 
document.getElementById("Username").value=arr[0]; 
document.getElementById("Realname").value=arr[1]; 


}
}




        </script>

    </form>
</body>
</html>
