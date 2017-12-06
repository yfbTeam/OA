<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WebDiskLx_qx_update.aspx.cs"
    Inherits="xyoa.PublicWork.WebDisk.WebDiskLx_qx_update" %>

<html>
<head>
    <title>修改关联对象 </title>

    <script src="/js/public.js" type="text/javascript"></script>

    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
    <base target="_self" />

    <script language="javascript">	

function  closewin()  
{ 

window.close();  
}  


    </script>

    <script src="/public/public.js" type="text/javascript"></script>

</head>
<body scroll="no">
    <form id="Form1" method="post" runat="server">
        <table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0"
            bordercolordark="#ffffff">
            <tr>
                <td valign="top" style="text-align: center">
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="2" align="center">
                                <br>
                                修改对象：
                                <asp:TextBox ID="name" runat="server" CssClass="ReadOnlyText" Width="407px"></asp:TextBox><br>
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                文件夹浏览：<asp:DropDownList ID="FLiulang" runat="server">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                                文件夹新增：<asp:DropDownList ID="FXinzeng" runat="server">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                                文件夹修改：<asp:DropDownList ID="FXiugai" runat="server">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                                文件夹删除：<asp:DropDownList ID="FShanchu" runat="server">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                                文件夹权限：<asp:DropDownList ID="FQuanXian" runat="server">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                                <hr>
                                文件浏览：<asp:DropDownList ID="BLiulang" runat="server">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                                文件新增：<asp:DropDownList ID="BXinzeng" runat="server">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                                文件修改/转移/转存/发送：<asp:DropDownList ID="BXiugai" runat="server">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                                文件删除：<asp:DropDownList ID="BShanchu" runat="server">
                                    <asp:ListItem Value="1">是</asp:ListItem>
                                    <asp:ListItem Value="0">否</asp:ListItem>
                                </asp:DropDownList>
                        
                                <hr>
                                文件批注：<asp:DropDownList ID="PiZhu" runat="server">
                                    <asp:ListItem Value="只允许查看用户个人的">只允许查看用户个人的</asp:ListItem>
                                    <asp:ListItem Value="只允许查看用户直属部门的">只允许查看用户直属部门的</asp:ListItem>
                                    <asp:ListItem Value="允许查看全部">允许查看全部</asp:ListItem>
                                    <asp:ListItem Value="不允许查看">不允许查看</asp:ListItem>
                                </asp:DropDownList>
                                文件日志：<asp:DropDownList ID="RiZhi" runat="server">
                                    <asp:ListItem Value="只允许查看用户个人的">只允许查看用户个人的</asp:ListItem>
                                    <asp:ListItem Value="只允许查看用户直属部门的">只允许查看用户直属部门的</asp:ListItem>
                                    <asp:ListItem Value="允许查看全部">允许查看全部</asp:ListItem>
                                    <asp:ListItem Value="不允许查看">不允许查看</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 31px; text-align: center;">
                                <asp:Button ID="Button2" runat="server" Text="确 定" CssClass="button_css" OnClick="Button2_Click" />
                                &nbsp;&nbsp;
                                <input type="button" value="关 闭" onclick="closewin();" class="button_css" id="Button3">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="22">
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
