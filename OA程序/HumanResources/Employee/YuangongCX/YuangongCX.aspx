<%@ Page Language="C#" AutoEventWireup="true" Codebehind="YuangongCX.aspx.cs" Inherits="xyoa.HumanResources.Employee.YuangongCX.YuangongCX" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <script>
function check_form()
{
    showwait();	
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
                                                            档案查询
                                                        </td>
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
                            <td style="height: 35px">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17" style="height: 40px">
                                            </td>
                                        <td valign="top" style="height: 40px">
                                            <div id="printshow2">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td style="height: 26px;">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">档案查询</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                        <td width="17" style="height: 40px">
                                            </td>
                                    </tr>
                                </table>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <div>
                                                <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                    <tr>
                                                        <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                            <b>查询信息</b></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            所属部门：</td>
                                                        <td class="newtd2" height="17" width="83%" colspan="3">
                                                            <asp:TextBox ID="Bumen" runat="server" Width="90%" Height="53px" TextMode="MultiLine"
                                                                CssClass="ReadOnlyText"></asp:TextBox>
                                                            <a href="javascript:void(0)">
                                                                <img onclick="openunit()" src="/oaimg/FDJ.gif" border="0"></a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            姓名：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:TextBox ID="Xingming" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            编号：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:TextBox ID="Bianhao" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            性别：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:RadioButtonList ID="Xingbie" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
                                                                <asp:ListItem Value="1">男</asp:ListItem>
                                                                <asp:ListItem Value="2">女</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            年龄：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:TextBox ID="Nianling1" runat="server" Width="53px"></asp:TextBox>至<asp:TextBox
                                                                ID="Nianling2" runat="server" Width="53px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            民族：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:DropDownList ID="Mingzhu" runat="server" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            籍贯：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:DropDownList ID="Jiguan" runat="server" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            政治面貌：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:DropDownList ID="Mianmao" runat="server" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            婚姻状况：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:RadioButtonList ID="Hunyin" runat="server" RepeatDirection="Horizontal">
                                                                <asp:ListItem Selected="True" Value="0">全部</asp:ListItem>
                                                                <asp:ListItem Value="2">未婚</asp:ListItem>
                                                                <asp:ListItem Value="1">已婚</asp:ListItem>
                                                            </asp:RadioButtonList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            学历：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:DropDownList ID="Xuexi" runat="server" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            毕业院校：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:TextBox ID="Yuanxiao" runat="server" Width="100%"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            专业：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:DropDownList ID="Zhuanye" runat="server" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            员工类型：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:DropDownList ID="Leixing" runat="server" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            职位：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:DropDownList ID="Zhiwei" runat="server" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            职称：</td>
                                                        <td class="newtd2" height="17" width="33%">
                                                            <asp:DropDownList ID="Zhicheng" runat="server" Width="100%">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            出生日期：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:TextBox ID="Chusheng1" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                            至<asp:TextBox ID="Chusheng2" runat="server"
                                                                        onClick="WdatePicker()"></asp:TextBox>
                                                            
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            参加工作时间：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:TextBox ID="CjShijian1" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                            至<asp:TextBox ID="CjShijian2" runat="server"
                                                                        onClick="WdatePicker()"></asp:TextBox>
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                            进入单位时间：</td>
                                                        <td class="newtd2" height="17" colspan="3">
                                                            <asp:TextBox ID="JrShijian1" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                           至<asp:TextBox ID="JrShijian2" runat="server"
                                                                        onClick="WdatePicker()"></asp:TextBox>
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="newtd2" width="33%" style="height: 17px" colspan="4" align="center">
                                                            <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="查询结果" OnClick="Button2_Click" /></td>
                                                    </tr>
                                                </table>
                                            </div>
                                            &nbsp;
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
        <asp:TextBox ID="BumenId" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	
           
            function  openunit()  
            
            {   var  wName_2;  
                var num=Math.random();
                var str=""+document.getElementById('BumenId').value+"";
                wName_2=window.showModalDialog("/OpenWindows/open_bumen_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("BumenId").value=arr[0]; 
                    document.getElementById("Bumen").value=arr[1]; 
                }
            }

            
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
