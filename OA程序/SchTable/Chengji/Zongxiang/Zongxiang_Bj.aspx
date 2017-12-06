<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Zongxiang_Bj.aspx.cs" Inherits="xyoa.SchTable.Chengji.Zongxiang.Zongxiang_Bj" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

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
        
function chknull()
{
    showwait();	
 
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
                                            成绩纵向分析</td>
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
                                            <button class="btn4off" type="button" onclick="javascript:window.location='Zongxiang.aspx';"
                                                runat="server" id="Button1">
                                                <font class="shadow_but">个人成绩追踪</font></button>
                                            <button class="btn4off" type="button" onclick="javascript:window.location='Zongxiang_Mc.aspx';"
                                                runat="server" id="Button2">
                                                <font class="shadow_but">个人名次追踪</font></button>
                                            <button class="btn4off" type="button" onclick="javascript:window.location='Zongxiang_Bj.aspx';"
                                                runat="server" id="Button3">
                                                <font class="shadow_but">班级质量追踪</font></button>
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
                            <td width="60" height="100%" align="center" valign="middle" bgcolor="#FFFFFF">
                                学期
                            </td>
                            <td width="140" height="100%" valign="middle" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Xueqi" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Xueqi_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" valign="middle" bgcolor="#FFFFFF">
                                学期段
                            </td>
                            <td height="100%" valign="middle" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Xueduan" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Xueduan_SelectedIndexChanged">
                                    <asp:ListItem>上学期</asp:ListItem>
                                    <asp:ListItem>下学期</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" valign="middle" bgcolor="#FFFFFF">
                                年级
                            </td>
                            <td height="100%" valign="middle" bgcolor="#FFFFFF">
                                <asp:DropDownList ID="Nianji" runat="server" AutoPostBack="True" OnSelectedIndexChanged="Nianji_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" align="center" valign="middle" bgcolor="#FFFFFF">
                                班级
                            </td>
                            <td height="100%" valign="middle" bgcolor="#FFFFFF">
                                  <div style='overflow-y: auto; scrollbar-face-color: #f8fcf5; height: 120px; width: 100%'>
                                    <asp:CheckBox ID="CheckBox3" runat="server" onclick='ReverseAll("BanJi")' ForeColor="Red"
                                        Text="全选/反选" TextAlign="Left" />
                                    <asp:CheckBoxList ID="BanJi" runat="server">
                                    </asp:CheckBoxList>
                                </div>
                            </td>
                        </tr>

                        <tr>
                            <td align="center" valign="middle" bgcolor="#FFFFFF">
                                考试类型
                            </td>
                            <td valign="middle" bgcolor="#FFFFFF">
                                <div style='overflow-y: auto; scrollbar-face-color: #f8fcf5; height: 120px; width: 100%'>
                                    <asp:CheckBox ID="CheckBox1" runat="server" onclick='ReverseAll("Leixing")' ForeColor="Red"
                                        Text="全选/反选" TextAlign="Left" />
                                    <asp:CheckBoxList ID="Leixing" runat="server">
                                    </asp:CheckBoxList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle" bgcolor="#FFFFFF">
                                科目选择
                            </td>
                            <td valign="top" bgcolor="#FFFFFF">
                                <div style='overflow-y: auto; scrollbar-face-color: #f8fcf5; height: 120px; width: 100%'>
                                    <asp:CheckBox ID="CheckBox2" runat="server" onclick='ReverseAll("Kemu")' ForeColor="Red"
                                        Text="全选/反选" TextAlign="Left" />
                                    <asp:CheckBoxList ID="Kemu" runat="server">
                                    </asp:CheckBoxList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td height="100%" colspan="2" align="center" valign="top" bgcolor="#FFFFFF">
                                <asp:Button ID="Button6" runat="server" Text="查 询" OnClick="Button6_Click" />
                                &nbsp;<asp:Button ID="Button7" runat="server" Text="导 出" OnClick="Button7_Click" />
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
                        <asp:Label ID="LTongji" runat="server"></asp:Label>
                    </asp:Panel>
                </td>
                <td width="5">
                    &nbsp;
                </td>
            </tr>
        </table>

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

