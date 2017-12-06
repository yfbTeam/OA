<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Kecheng_add.aspx.cs" Inherits="xyoa.SchTable.SysMag.Kecheng.Kecheng_add" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
        alert('课程名称不能为空');
        form1.Name.focus();
        return false;
    }	

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
                                                            <a href="Kecheng.aspx">课程设置</a> >> 新增课程设置</td>
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
                                                                <font class="shadow_but">课程设置</font></button></td>
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
                                        <td width="17" style="height: 441px">
                                        </td>
                                        <td valign="top" style="height: 441px">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>课程名称：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:TextBox ID="Name" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>优秀分数段：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:TextBox ID="Youxiu1" runat="server" Width="100" MaxLength="25" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='0';};">90</asp:TextBox>
                                                        至
                                                        <asp:TextBox ID="Youxiu2" runat="server" Width="100" MaxLength="25" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='0';};">100</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>良好分数段：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:TextBox ID="Lianghao1" runat="server" Width="100" MaxLength="25" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='0';};">80</asp:TextBox>
                                                        至
                                                        <asp:TextBox ID="Lianghao2" runat="server" Width="100" MaxLength="25" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='0';};">89</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>合格分数段：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:TextBox ID="Hege1" runat="server" Width="100" MaxLength="25" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='0';};">60</asp:TextBox>
                                                        至
                                                        <asp:TextBox ID="Hege2" runat="server" Width="100" MaxLength="25" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='0';};">79</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>不及格分数段：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:TextBox ID="Bujige1" runat="server" Width="100" MaxLength="25" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='0';};">0</asp:TextBox>
                                                        至
                                                        <asp:TextBox ID="Bujige2" runat="server" Width="100" MaxLength="25" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='0';};">59</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>极差分数段：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:TextBox ID="Jicha1" runat="server" Width="100" MaxLength="25" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='0';};">0</asp:TextBox>
                                                        至
                                                        <asp:TextBox ID="Jicha2" runat="server" Width="100" MaxLength="25" onchange="if(!/^\d+(\.\d+)?$/.test(this.value)){alert('只能输入正数');this.value='0';};">39</asp:TextBox>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        任课教师：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="RkRealname" runat="server" Width="90%" MaxLength="200" Height="71px"
                                                            TextMode="MultiLine" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp; &nbsp;<input id="Button3" type="button" value="返 回" class="button_css"  onclick="history.go(-1)"/>
                                                            </font>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17" style="height: 441px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
          <asp:TextBox ID="RkUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
           <script language="javascript">	
            function  openuser1()  
            {  var  wName_1;  
                var num=Math.random();
                var str=""+document.getElementById('RkUsername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("RkUsername").value=arr[0]; 
                    document.getElementById("RkRealname").value=arr[1]; 
                }
            }
        </script>
    </form>
</body>
</html>
