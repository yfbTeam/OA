<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Fenpei_Ss_Wfp.aspx.cs"
    Inherits="xyoa.SchTable.Sushe.Fenpei.Fenpei_Ss_Wfp" %>

<html>

<script>
function chknull()
{
    showwait();	
 
}  

</script>

<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

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
                                <asp:Panel ID="Panel1" runat="server">
                                    <div align="center">
                                        <asp:Label ID="Label1" runat="server" Text="请先选择宿舍" Font-Bold="True" ForeColor="Red"></asp:Label>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="Panel2" runat="server">
                                    <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                        <tr>
                                            <td align="center" class="newtd2" colspan="8" style="height: 26px">
                                                <b>宿舍信息</b></td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="8%">
                                                <font color="red">※</font>宿舍：</td>
                                            <td class="newtd2" colspan="7" height="17">
                                                <asp:Label ID="Bianhao" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                所在楼层：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:Label ID="Louceng" runat="server"></asp:Label>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                面积：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:Label ID="Mianji" runat="server"></asp:Label>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                座位数：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:Label ID="Zuowei" runat="server"></asp:Label>
                                            </td>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="5%">
                                                是否在用：</td>
                                            <td class="newtd2" height="17" width="20%">
                                                <asp:Label ID="Zaiyong" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" class="newtd1" height="17" nowrap="nowrap" width="8%">
                                                <font color="red">※</font>学生：</td>
                                            <td class="newtd2" colspan="7" height="17">
                                                <asp:TextBox ID="acceptrealname" runat="server" Width="92%" Height="86px" TextMode="MultiLine"
                                                    CssClass="ReadOnlyText"></asp:TextBox>
                                                <a href="javascript:void(0)">
                                                    <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                            </td>
                                        </tr>
                                        <tr id="printshow3">
                                            <td align="center" class="newtd2" colspan="8" height="26" width="33%">
                                                <div align="center">
                                                    <font face="宋体">
                                                        <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                    </font>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="newtd2" colspan="8" style="height: 26px">
                                                <b>信息登记</b></td>
                                        </tr>
                                        <tr>
                                            <td align="center" class="newtd2" colspan="8" style="height: 26px">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                    BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="1"
                                                    GridLines="None" OnRowDataBound="GridView1_RowDataBound" PageSize="12" Style="font-size: 12px"
                                                    Width="100%">
                                                    <PagerSettings Visible="False" />
                                                    <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                    <Columns>
                                                        <asp:BoundField DataField="Xingming" HeaderText="学生姓名" SortExpression="A.XsId">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Shijian" HeaderText="时间" SortExpression="Shijian">
                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Miaosu" HeaderText="事件描述" SortExpression="Miaosu">
                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Yijian" HeaderText="处理意见" SortExpression="Yijian">
                                                            <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                            <ItemStyle Wrap="True" HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Peichang" HeaderText="赔偿" SortExpression="Peichang">
                                                            <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                            <ItemStyle Wrap="False" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="Jingbanren" HeaderText="经办人" SortExpression="Jingbanren">
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
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="acceptusername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	

        try{
            parent.closeAlert('UploadChoose');
        }
        catch(err){
        }


        var  wName_1;  
        function  openuser1()  
        {  
            var num=Math.random();
            var str=""+document.getElementById('acceptusername').value+"";
            wName_1=window.showModalDialog("/OpenWindows/open_xs_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:780px;DialogHeight=620px;status:no;scroll=no;help:no");
            if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
            for(var i=0;i<arr.length;i++)
            { 
                document.getElementById("acceptusername").value=arr[0]; 
                document.getElementById("acceptrealname").value=arr[1]; 
            }
        }
        </script>

    </form>
</body>
</html>
