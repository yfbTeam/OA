<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Menhu_add.aspx.cs" Inherits="xyoa.SystemManage.Menhu.Menhu_add" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('name').value=='')
    {
    alert('名称不能为空');
    form1.name.focus();
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
                                                            <a href="Menhu.aspx">门户中心</a> >> 新增门户中心</td>
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
                                                                <font class="shadow_but">门户中心</font></button></td>
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
                                                        <font color="red">※</font>门户中心：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="name" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17">
                                                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False"
                                                            BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px"
                                                            CellPadding="3" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                            PageSize="12" Style="font-size: 12px" Width="100%">
                                                            <PagerSettings Visible="False" />
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="模块名称">
                                                                    <ItemStyle Width="180px" HorizontalAlign="Center" />
                                                                    <HeaderStyle CssClass="newtitle" Width="180px" />
                                                                    <ItemTemplate>
                                                                        <%# DataBinder.Eval(Container.DataItem, "urlname")%>
                                                                        <asp:Label ID="Lid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'
                                                                            Visible="False" Width="0px"></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="模块设置<a href='javascript:void(0)' onclick='checkAll()' class='line'><font color=#ffffff>【全选】</font></a><a href='javascript:void(0)' onclick='fanAll()' class='line'><font color=#ffffff>【反选】</font></a>">
                                                                    <ItemStyle HorizontalAlign="Left" Wrap="True" />
                                                                    <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="quanbu" runat="server" Text="选择" />
                                                                        <asp:Label ID="quanbuid" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>'
                                                                            Visible="False" Width="0px"></asp:Label>
                                                                             <asp:Label ID="ParentNodesID" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ParentNodesID") %>'
                                                                            Visible="False" Width="0px"></asp:Label>
                                                                        <asp:Label ID="Label1" runat="server" ></asp:Label>
                                                                    </ItemTemplate>
                                                                    <FooterStyle Wrap="True" />
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        开放范围：</td>
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

        <script language="javascript">	
            
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
