<%@ Page Language="C#" AutoEventWireup="true" Codebehind="TaolunzuMy_update.aspx.cs"
    Inherits="xyoa.InfoManage.Taolunzu.TaolunzuMy_update" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('讨论组名称不能为空');
    form1.Name.focus();
    return false;
    }	
    
    if(document.getElementById('Paixun').value=='')
    {
    alert('排序号不能为空');
    form1.Paixun.focus();
    return false;
    }	
   
    if(document.getElementById('Paixun').value!='')
    {
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Paixun').value))
        {
            alert("排序号只能为正数");
            form1.Paixun.focus();
            return false;
        }
    }
    
    
    
    showwait();	
}  

function select_type()
{
   if (form1.States.value=="1")
   {
       trDept.style.display='none';
       trUser.style.display='none';
   }
   else if (form1.States.value=="2")
   {
       trDept.style.display='';       
       trUser.style.display='none';
   }
   else if (form1.States.value=="3")
   {
       trDept.style.display='none';
       trUser.style.display='';
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

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow1">
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
                                                            <a href="TaolunzuMy.aspx">讨论组管理</a> >> 修改讨论组</td>
                                                        <td width="81%">
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
                                <div id="printshow2">
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
                                                                <font class="shadow_but">讨论组管理</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            &nbsp;</td>
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
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>讨论组名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Name" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>状态：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:RadioButtonList ID="Zhuangtai" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1">活动中</asp:ListItem>
                                                            <asp:ListItem Value="0">已停止</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>加入权限：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:RadioButtonList ID="Leixing" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="2">有权限的用户随时可以加入</asp:ListItem>
                                                            <asp:ListItem Value="1">需要验证加入</asp:ListItem>
                                                            <asp:ListItem Value="0">不允许主动加入</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        开放权限：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="States" runat="server" Width="100%" onchange="select_type()">
                                                            <asp:ListItem Value="1">全部</asp:ListItem>
                                                            <asp:ListItem Value="2">对指定部门开放</asp:ListItem>
                                                            <asp:ListItem Value="3">对指定人员开放</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr id="trDept" style="display: none">
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        选择部门（对指定部门开放）：</td>
                                                    <td class="newtd2" colspan="3" width="85%" style="height: 17px">
                                                        <asp:TextBox ID="ZdBumen" runat="server" Height="58px" TextMode="MultiLine" Width="85%"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openunit();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="trUser" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        选择人员（对指定人员开放）：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="ZdRealname" runat="server" Width="85%" Height="58px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>排序号：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Paixun" runat="server" Width="100%" MaxLength="4">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="newtd2" colspan="4" height="26" width="33%">
                                                        增加参与人：
                                                        <asp:TextBox ID="Realname" runat="server" CssClass="ReadOnlyText"></asp:TextBox><a
                                                            href="javascript:void(0)"><img onclick="openuser();" alt="" src="/oaimg/FDJ.gif"
                                                                border="0"></a>
                                                        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="确定增加" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="newtd2" colspan="4" height="26" width="33%">
                                                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px"
                                                            CellPadding="4" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                            OnSorting="GridView1_Sorting" PageSize="6" Style="font-size: 12px" Width="100%"
                                                            OnRowCommand="GridView1_RowCommand">
                                                            <PagerSettings Visible="False" />
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Realname" HeaderText="姓名" SortExpression="Realname">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Settime" HeaderText="活动时间" SortExpression="Settime">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="相关操作">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" Width="160px" />
                                                                    <ItemTemplate>
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
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <b>申请人列表</b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="left" class="newtd2" colspan="4" height="26" width="33%">
                                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="4" CellSpacing="1"
                                                            GridLines="None" OnRowDataBound="GridView2_RowDataBound" PageSize="6" Style="font-size: 12px"
                                                            Width="100%" OnRowCommand="GridView2_RowCommand">
                                                            <PagerSettings Visible="False" />
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Realname" HeaderText="申请人" SortExpression="Realname">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Settimes" HeaderText="申请时间" SortExpression="Settimes">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="相关操作">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" Width="160px" />
                                                                    <ItemTemplate>
                                                                        <asp:LinkButton ID="Tongyi" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="Tongyi">同意</asp:LinkButton>
                                                                        <asp:LinkButton ID="Jujue" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="Jujue">拒绝</asp:LinkButton>
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
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="返 回" OnClick="Button2_Click" /></font></div>
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
        <asp:TextBox ID="ZdBumenId" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ZdUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
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




 
function  openuser()  
{  var  wName_3; 
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

            function  openunit()  
            {  var  wName_2;  
            var num=Math.random();
            var str=""+document.getElementById('ZdBumenId').value+"";
            wName_2=window.showModalDialog("/OpenWindows/open_bumen_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
            if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
            for(var i=0;i<arr.length;i++)
            { 
            document.getElementById("ZdBumenId").value=arr[0]; 
            document.getElementById("ZdBumen").value=arr[1]; 
            }


            }


            
            function  openuser1()  
            {  var  wName_1;  
                var num=Math.random();
                var str=""+document.getElementById('ZdUsername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("ZdUsername").value=arr[0]; 
                    document.getElementById("ZdRealname").value=arr[1]; 
                }
            }
            
            
        </script>

    </form>
</body>
</html>
