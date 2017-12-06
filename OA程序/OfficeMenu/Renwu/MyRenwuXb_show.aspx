<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyRenwuXb_show.aspx.cs" Inherits="xyoa.OfficeMenu.Renwu.MyRenwuXb_show" %>
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
<body class="newbody" onload="aaa();bbb()">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox></td>
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
                                                            <a href="MyRenwuXb.aspx">我的任务</a>
                                                            >> 查看任务</td>
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
                                                        <td width="20%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">我的任务</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                        </td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        任务标题：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Label ID="titles" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        开始时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Starttime" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        预计结束时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Endtime" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        任务类型：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Leixing" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        主办人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="ZbRealname" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        完成比例：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Benbi" runat="server"></asp:Label>%&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        任务状态：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="State" runat="server"></asp:Label>&nbsp;<asp:CheckBox ID="CheckBox2"
                                                            runat="server" onclick="bbb()" Text="修改状态和比例" />
                                                    </td>
                                                </tr>
                                                <tr id="TrTitle1" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        完成比例：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                    <asp:TextBox ID="BenbiXg" runat="server" Width="95%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        任务状态：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                     <asp:DropDownList ID="ZhuangtaiXg" runat="server" Width="95%">
                                                            <asp:ListItem Value="1">进行中</asp:ListItem>
                                                            <asp:ListItem Value="2">已暂停</asp:ListItem>
                                                            <asp:ListItem Value="3">强行停止</asp:ListItem>
                                                            <asp:ListItem Value="4">已完成</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        完成时间：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Label ID="WcTime" runat="server"></asp:Label>&nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                              <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        领导阅读情况：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:Label ID="YdRealname" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr id="TrTitle2" style="display: none">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <asp:Button ID="Button3" runat="server" Text="修改状态和比例" CssClass="button_css" OnClick="Button3_Click" />
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" height="17" colspan="4" width="100%">
                                                        <div align="center">
                                                            <font face="宋体"><strong>协办人员</strong></font></div>
                                                    </td>
                                                </tr>
                                                <asp:Panel ID="Panel1" runat="server">
                                                    <tr>
                                                        <td align="left" class="newtd2" colspan="4" height="26" width="33%">
                                                            增加协办人：
                                                            <asp:TextBox ID="Realname" runat="server" CssClass="ReadOnlyText"></asp:TextBox><a
                                                                href="javascript:void(0)"><img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif"
                                                                    border="0"></a>
                                                            <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="确定增加" />
                                                        </td>
                                                    </tr>
                                                </asp:Panel>
                                                <tr>
                                                    <td align="left" class="newtd2" colspan="4" height="26" width="33%">
                                                        <asp:GridView ID="XieBanUser" runat="server" AutoGenerateColumns="False" BackColor="#E0E0E0"
                                                            BorderColor="#4D77B1" BorderStyle="None" BorderWidth="1px" CellPadding="4" CellSpacing="1"
                                                            GridLines="None" PageSize="6" Style="font-size: 12px" Width="100%" OnRowCommand="XieBanUser_RowCommand"
                                                            OnRowDataBound="XieBanUser_RowDataBound">
                                                            <PagerSettings Visible="False" />
                                                            <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                            <Columns>
                                                                <asp:BoundField DataField="Realname" HeaderText="姓名" SortExpression="Realname">
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="状态" SortExpression="Zhuangtai">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                    <ItemTemplate>
                                                                        <%# ((Eval("Zhuangtai").ToString().Replace("1", "进行中").Replace("2", "已暂停").Replace("3", "强行停止").Replace("4", "已完成")))%>
                                                                    </ItemTemplate>
                                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Neirong" HeaderText="工作内容" SortExpression="Neirong">
                                                                    <ItemStyle Wrap="False" />
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                </asp:BoundField>
                                                               
                                                                       <asp:TemplateField HeaderText="完成百分比" SortExpression="Baifenbi">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# ((Eval("Baifenbi").ToString()))%>%
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" Width="50px" />
                                                                    </asp:TemplateField>
                                                                    
                                                                <asp:TemplateField HeaderText="相关操作">
                                                                    <HeaderStyle CssClass="newtitle" Wrap="False" Width="160px" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="Username" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Username") %>'
                                                                            Visible="False" Width="0px"></asp:Label>
                                                                        <asp:LinkButton ID="XiuGai" runat="server" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                            CommandName="Xiugai">更新</asp:LinkButton>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        任务内容：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="Content" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        分配人：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Realname1" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        分配时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="SetTime" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr class="" id="nextrs22">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        附件：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:Label ID="fujian" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css" OnClick="Button2_Click" />
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
                                                        讨论内容：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="taolun" runat="server" Height="80px" TextMode="MultiLine" Width="100%"
                                                            MaxLength="4000"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="nextrs3" style="display: none">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center" id="Div2">
                                                            <asp:Button ID="Button1" runat="server" Text="提交讨论内容" CssClass="button_css" OnClick="Button1_Click" />
                                                        </div>
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

        <script>
function chknullxg()
{

    if(document.getElementById('BenbiXg').value=='')
    {
        alert('完成百分比不能为空，没有请填写为0');
        form1.BenbiXg.focus();
        return false;
    }	
 
    if(document.getElementById('BenbiXg').value!='')
    {    
        var objRe = /^[-+]?\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('BenbiXg').value))
        {
            alert("完成百分比只能为数字");
            form1.BenbiXg.focus();
            return false;
        }
    }  
    
   if(document.getElementById('ZhuangtaiXg').value=='4')
    { 
     if (!confirm("是否确定要完成任务，完成以后不允许再更改状态和完成比例？"))
        return false;
    }
}

            function bbb()
            {   
                if(document.getElementById('CheckBox2').checked)
                {
                   document.getElementById('TrTitle1').style.display="";
                   document.getElementById('TrTitle2').style.display="";
                }
                else
                {
                   document.getElementById('TrTitle1').style.display="none";
                   document.getElementById('TrTitle2').style.display="none";
                }
            }
            
            
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
            
            function  openuser1()  
            {  
                var  wName_3;  
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