<%@ Page Language="C#" AutoEventWireup="true" Codebehind="BaobiaoSj_update_update.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.BaobiaoSj_update_update" %>

<html>
<head>
    <title>报表公式</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
    <base target="_self" />
</head>
<body topmargin="0">
    <form id="form1" runat="server">
        <table border="1" cellspacing="0" width="100%" cellpadding="3" align="center">
            <tr>
                <td align="center" colspan="2">
                    <asp:DropDownList ID="FormFile" runat="server">
                    </asp:DropDownList><a href="javascript:void(0)" onclick="alert('统计字段允许选择“数字型”的字段。\n\n公式计算：支持每个字段的加减乘除，形如：[字段A]+[字段B]、[字段A]+[字段B]*[字段C]\n\n先设计好统计报表样式，然后再添加公式进表单编辑器中\n\n设计报表字段时，需通过软件的【新增公式】设计')">【说明】</a>
                    <input id="Button3" onclick="ziduan()" style="width: 100px" type="button" value="插入字段" />
                </td>
            </tr>
            <tr>
                <td align="center" bgcolor="#cccccc" width="25%">
                    公式：</td>
                <td align="center" width="75%">
                    <asp:TextBox ID="Gongsi" runat="server" Width="100%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2" nowrap="nowrap">
                    <asp:Button ID="Button1" runat="server" Text="确 定" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
        <input id="Number" type="text" name="Number" runat="server" style="display: none">
        <input id="TextBox2" type="text" name="names" runat="server" style="display: none">
    </form>
</body>
</html>
