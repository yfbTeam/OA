<%@ Page Language="C#" AutoEventWireup="true" Codebehind="OpenZiChangMc.aspx.cs"
    Inherits="xyoa.OpenWindows.OpenZiChangMc" %>

<html>
<head id="Head1" runat="server">
    <title>请选择物品</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <base target="_self" />
</head>
<body class="newbody">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>&nbsp;
            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage"
                id="tableprint">
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
                        <asp:Label ID="Xinghao" runat="server"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                        物品描述：</td>
                    <td class="newtd2" height="17" colspan="3">
                        <asp:Label ID="ZyIntro" runat="server"></asp:Label>&nbsp;</td>
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
                        可分配库存：</td>
                    <td class="newtd2" width="33%" style="height: 17px">
                        <asp:Label ID="KuCun" runat="server"></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                        产品图片：</td>
                    <td class="newtd2" height="17" colspan="3" width="85%">
                        <asp:Image ID="TuPian" runat="server" />
                    </td>
                </tr>
            </table>
            <asp:TextBox ID="Name" runat="server" Style="display: none"></asp:TextBox>
            <asp:TextBox ID="gncdid" runat="server" Style="display: none"></asp:TextBox>
        </div>
    </form>
</body>
</html>
