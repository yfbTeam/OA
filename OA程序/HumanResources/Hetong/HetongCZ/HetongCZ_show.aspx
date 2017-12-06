﻿<%@ Page Language="C#" AutoEventWireup="true" Codebehind="HetongCZ_show.aspx.cs"
    Inherits="xyoa.HumanResources.Hetong.HetongCZ.HetongCZ_show" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script>
function updatefrom1(str)
{
    var num=Math.random();
    var k=window.showModalDialog("HetongBG.aspx?tmp="+num+"&id="+str+"&bmid=<%=Request.QueryString["bmid"] %>",window,"dialogWidth:600px;DialogHeight=350px;status:no;scroll=yes;help:no")
    
     if(k == 1)
     { 
       showwait();
       window.location.href = 'HetongCZ_show.aspx?bmid=<%=Request.QueryString["bmid"] %>';
     } 
}

function updatefrom2(str)
{
    var num=Math.random();
    var k=window.showModalDialog("HetongXQ.aspx?tmp="+num+"&id="+str+"&bmid=<%=Request.QueryString["bmid"] %>",window,"dialogWidth:600px;DialogHeight=350px;status:no;scroll=yes;help:no")  
    
    if(k == 1)
    { 
        showwait();
        window.location.href = 'HetongCZ_show.aspx?bmid=<%=Request.QueryString["bmid"] %>';
    } 
}

function updatefrom3(str)
{
    var num=Math.random();
    var k=window.showModalDialog("HetongJC.aspx?tmp="+num+"&id="+str+"&bmid=<%=Request.QueryString["bmid"] %>",window,"dialogWidth:600px;DialogHeight=350px;status:no;scroll=yes;help:no")  
    
    if(k == 1)
    { 
        showwait();
        window.location.href = 'HetongCZ_show.aspx?bmid=<%=Request.QueryString["bmid"] %>';
    } 
}

function updatefrom4(str)
{
    var num=Math.random();
    var k=window.showModalDialog("HetongZZ.aspx?tmp="+num+"&id="+str+"&bmid=<%=Request.QueryString["bmid"] %>",window,"dialogWidth:600px;DialogHeight=350px;status:no;scroll=yes;help:no")  
    
    if(k == 1)
    { 
        showwait();
        window.location.href = 'HetongCZ_show.aspx?bmid=<%=Request.QueryString["bmid"] %>';
    } 
}

function addcheck()
{
	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
}

    </script>

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
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0" height="30px"
                                                            background="/oaimg/nextline.gif">
                                                            <tr>
                                                                <td valign="top">
                                                                    签约人：<asp:TextBox ID="QyRealname" runat="server" Width="88px" CssClass="ReadOnlyText"></asp:TextBox>
                                                                    <a href="javascript:void(0)">
                                                                        <img onclick="openuser();" alt="" src="/oaimg/FDJ.gif" border="0"></a> 签约合同：<asp:DropDownList
                                                                            ID="LeibieID" runat="server">
                                                                        </asp:DropDownList>
                                                                    <asp:Button ID="SearchData" runat="server" Text="查 询" OnClick="SearchData_Click"
                                                                        CssClass="button_css" />
                                                                    <asp:Button ID="Button2" runat="server" CssClass="button_css" OnClick="Button2_Click"
                                                                        Text="退 出" /></td>
                                                                <td valign="top" align="right">
                                                                    <asp:Button ID="Button3" runat="server" Text="合同变更" CssClass="button_css" OnClick="Button3_Click" />
                                                                    <asp:Button ID="Button4" runat="server" Text="合同续签" CssClass="button_css" OnClick="Button4_Click" />
                                                                    <asp:Button ID="Button5" runat="server" Text="合同解除" CssClass="button_css" OnClick="Button5_Click" />
                                                                    <asp:Button ID="Button6" runat="server" Text="合同终止" CssClass="button_css" OnClick="Button6_Click" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <div id="Div1">
                                                            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                                                                AutoGenerateColumns="False" BackColor="#E0E0E0" BorderColor="#4D77B1" BorderStyle="None"
                                                                BorderWidth="1px" CellPadding="3" CellSpacing="1" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                                                                OnSorting="GridView1_Sorting" PageSize="12" Style="font-size: 12px" Width="100%">
                                                                <PagerSettings Visible="False" />
                                                                <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="选择">
                                                                        <ItemStyle HorizontalAlign="Center" Wrap="True" Width="30px" />
                                                                        <HeaderStyle CssClass="newtitle"  HorizontalAlign="Center" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="CheckSelect" runat="server" />
                                                                            <asp:Label ID="LabVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                                                                Visible="False" Width="0px"></asp:Label>
                                                                            <asp:Label ID="LabNameVisible" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "QyRealname") %>'
                                                                                Visible="False" Width="0px"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <FooterStyle Wrap="True" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="签约人" SortExpression="QyRealname">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <a href='HetongMg_show.aspx?id=<%# DataBinder.Eval(Container.DataItem, "id")%>' class="LinkLine">
                                                                                <%# DataBinder.Eval(Container.DataItem, "QyRealname")%>
                                                                            </a>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="LeibieName" HeaderText="签约合同" SortExpression="LeibieName">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="合同生效日期" SortExpression="A.Starttime">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# ((Eval("Starttime").ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "")))%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="合同终止日期" SortExpression="A.Endtime">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="EndtimeT" runat="server">
                                                                            </asp:Label>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="合同签定日期" SortExpression="A.QdTime">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <%# ((Eval("QdTime").ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "")))%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="合同状态" SortExpression="A.Zhuangtai">
                                                                        <HeaderStyle CssClass="newtitle" Wrap="False" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Zhuangtai") %>' Visible="False">
                                                                            </asp:Label>
                                                                            <asp:Label ID="QixianS" runat="server" Text='<%# Eval("Qixian") %>' Visible="False">
                                                                            </asp:Label>
                                                                            <asp:Label ID="EndtimeS" runat="server" Text='<%# ((Eval("Endtime").ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "")))%>' Visible="False">
                                                                            </asp:Label>
                                                                            <%# ((Eval("Zhuangtai").ToString().Replace("1", "正常状态").Replace("2", "到期终止").Replace("3", "强行终止").Replace("4", "合同解除")))%>
                                                                        </ItemTemplate>
                                                                        <ItemStyle Wrap="False" />
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
                                                            &nbsp;
                                                        </div>
                                                        只允许操作状态为：“正常状态”或者“到期终止”的合同
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
                                                            <a href="javascript:void(0)" onclick="checkAll()" class="line">全选</a> &nbsp;<a href="javascript:void(0)"
                                                                onclick="fanAll()" class="line">反选</a> &nbsp;
                                                            <asp:LinkButton ID="btnFirst" runat="server" CssClass="line" CommandArgument="first"
                                                                OnClick="PagerButtonClick">首页</asp:LinkButton>
                                                            &nbsp;<asp:LinkButton ID="btnPrev" runat="server" CssClass="line" CommandArgument="prev"
                                                                OnClick="PagerButtonClick">上页</asp:LinkButton>
                                                            &nbsp<asp:LinkButton ID="btnNext" runat="server" CssClass="line" CommandArgument="next"
                                                                OnClick="PagerButtonClick">下页</asp:LinkButton>
                                                            &nbsp;<asp:LinkButton ID="btnLast" runat="server" CssClass="line" CommandArgument="last"
                                                                OnClick="PagerButtonClick">尾页</asp:LinkButton>
                                                            &nbsp;<font color="#000000">页码：<asp:TextBox ID="GoPage" runat="server" Width="25px"></asp:TextBox>
                                                                <asp:Button ID="Button1" runat="server" CssClass="button_jdkd" Text="跳转" Width="36px"
                                                                    Height="20px" OnClick="Button1_Click1" />
                                                                &nbsp;每页<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                                        <asp:ListItem>10</asp:ListItem>
                                                                        <asp:ListItem>15</asp:ListItem>
                                                                        <asp:ListItem>25</asp:ListItem>
                                                                        <asp:ListItem>50</asp:ListItem>
                                                                        <asp:ListItem>80</asp:ListItem>
                                                                        <asp:ListItem>100</asp:ListItem>
                                                                    </asp:DropDownList>条数据&nbsp; 共有<font color="red"><asp:Label ID="CountsLabel"
                                                                    runat="server"></asp:Label></font>条数据 &nbsp;&nbsp;当前为第<font color="red"><asp:Label
                                                                        ID="CurrentlyPageLabel" runat="server"></asp:Label></font>页 &nbsp;&nbsp;
                                                                共<font color="red"><asp:Label ID="AllPageLabel" runat="server"></asp:Label></font>页</font>
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
                </td>
            </tr>
        </table>
        <input id="SortText" type="hidden" runat="server" value="order by A.id desc" />
        <asp:TextBox ID="Username" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	

            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
            
           var  wName_3;  
            function  openuser()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('Username').value+"|"+document.getElementById('QyRealname').value+"";
                wName_3=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("Username").value=arr[0]; 
                    document.getElementById("QyRealname").value=arr[1]; 
                }
            }
            
        </script>

    </form>
</body>
</html>
