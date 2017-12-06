<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyResApply_show.aspx.cs"
    Inherits="xyoa.Resources.MyRes.MyResApply_show" %>

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
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>基本信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        物品编号：</td>
                                                    <td class="newtd2" height="17" width="33%">
                                                        <asp:Label ID="ZyNum" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        物品名称：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="ZyName" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        物品型号：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="Xinghao" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        物品描述：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="ZyIntro" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        物品类别：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:Label ID="ZyLeibie" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        物品性质：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:Label ID="ZyXingzhi" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        所属仓库：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:Label ID="Cangku" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        所属区域：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:Label ID="Quyu" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        物品状态：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="Zhuangtai" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        计量单位：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:Label ID="Danwei" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        单价：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:Label ID="Danjia" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        供应商：</td>
                                                    <td class="newtd2" colspan="3" style="height: 17px">
                                                        <asp:Label ID="Gongyinshang" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        总库存：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:Label ID="AllKuCun" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        <b><font color="red">可分配库存</font></b></td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:Label ID="KuCun" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        已借用(正在使用)：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:Label ID="YjyKuCun" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        已报废：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:Label ID="BfKuCun" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        库警上限：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:Label ID="LimitsS" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        库警下限：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:Label ID="LimitsE" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        产品图片：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:Image ID="TuPian" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="申请使用" OnClick="Button2_Click" />
                                                            <asp:Button ID="Button1" runat="server" CssClass="button_css" Text="申请借用" OnClick="Button1_Click" />
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
    </form>
</body>
</html>
