<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Yuangong_show1.aspx.cs"
    Inherits="xyoa.HumanResources.Employee.Yuangong.Yuangong_show1" %>

<html>
<head id="Head1" runat="server">
    <title>查看员工档案 </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <base target="_self" />

    <script>
    function zx()
    {
        if (!confirm("确定要删除吗？"))
        return false;
    }
    
    var k=window.dialogArguments; 
    //获得父窗口传递来的值 

    function winClose(isRefrash) 
    { 
        alert('删除成功！');
        window.returnValue=isRefrash; 
        window.close(); 
    } 

    
    </script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0" id="printshow1">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow2">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0" id="printshow3">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">员工档案</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            <input id="Button3" type="button" value="打 印" onclick="printnewpage()" class="button_blue" />
                                                            <asp:Button ID="Button1" runat="server" Text="修 改" CssClass="button_blue" OnClick="Button1_Click" />
                                                            <asp:Button ID="Button5" runat="server" Text="删 除" CssClass="button_blue" OnClick="Button5_Click" />
                                                        </td>
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
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage"
                                                id="tableprint">
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <b>基本信息</b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        姓名：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Xingming" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        编号：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Bianhao" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr class="" id="nextrs23">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        员工相片：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <asp:Image ID="Xiangpian" runat="server" Height="119px" Width="104px" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        性别：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Xingbie" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        出生日期：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Chusheng" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        民族：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Mingzhu" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        籍贯：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Jiguan" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        政治面貌：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Mianmao" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        婚姻状况：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Hunyin" runat="server"></asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        学历：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Xuexi" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        毕业院校：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Yuanxiao" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        专业：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Zhuanye" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        身份证号码：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Shenfenzheng" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <b>联系方式</b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        户口所在地：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Hukou" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        电话：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Jiating" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        电子邮箱：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Youxiang" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        家庭住址：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Dizhi" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        传真：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Chuanzhen" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        手机：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Shouji" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        QQ号：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="QQ" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        MSN：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="MSN" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        内部即时通：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Neibu" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        邮政编码：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Youbian" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <b>工作信息</b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        所在部门：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Bumen" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        员工类型：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Leixing" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        职位：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Zhiwei" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        职称：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="Zhicheng" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        参加工作时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="CjShijian" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        进入单位时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="JrShijian" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <b>其他信息</b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        社会关系：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="Shehui" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        工作经历：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="GzJingli" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        学习经历：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="XxJingli" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        备注：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="Beizhu" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center" id="printshow4">
                                                            <font face="宋体">
                                                                <input id="Button2" type="button" value="关 闭" onclick="window.close()" class="button_css" />
                                                            </font>
                                                        </div>
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
        <asp:Label ID="Jineng" runat="server" Visible="false"></asp:Label>&nbsp;
        <asp:Label ID="Tijian" runat="server" Visible="false"></asp:Label>&nbsp;
        <asp:Label ID="Jiangcheng" runat="server" Visible="false"></asp:Label>&nbsp;
    </form>
</body>
</html>
