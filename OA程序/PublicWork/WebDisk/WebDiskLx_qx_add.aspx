<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WebDiskLx_qx_add.aspx.cs"
    Inherits="xyoa.PublicWork.WebDisk.WebDiskLx_qx_add" %>

<html>
<head>
    <title>请选择关联对象</title>

    <script src="/js/public.js" type="text/javascript"></script>

    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <base target="_self" />

    <script language="javascript">	
function checkbutton()
{
    for(var i=0;i<document.getElementById('TargetListBox').length;i++)
    { 

    document.getElementById("TextBox1").value=""+document.getElementById("TextBox1").value+""+document.getElementById('TargetListBox').options[i].value+",";
    document.getElementById("TextBox2").value=""+document.getElementById("TextBox2").value+""+document.getElementById('TargetListBox').options[i].text+",";

    } 

    if(document.getElementById("TextBox1").value=='')
    {
      alert('提交数据失败！未选中项');
      return false;
    }

}

function  closewin()  
{ 

window.close();  
}  


    </script>

    <script src="/public/public.js" type="text/javascript"></script>

</head>
<body scroll="no">
    <form id="Form1" method="post" runat="server">
        <asp:TextBox ID="TextBox1" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="requeststr" runat="server" Style="display: none"></asp:TextBox>
        <table border="0" width="100%" cellspacing="0" cellpadding="0" height="100%" bordercolorlight="#c0c0c0"
            bordercolordark="#ffffff">
            <tr>
                <td valign="top" style="text-align: center">
                    <table border="0" cellspacing="0" cellpadding="0" style="width: 693px; height: 49px">
                        <tr>
                        <tr>
                            <td colspan="2" style="height: 31px; text-align: center;">
                                <table border="0" cellpadding="0" cellspacing="0" style="height: 302px">
                                    <tr>
                                        <td align="center" style="width: 113px" valign="top">
                                            <asp:ListBox ID="SourceListBox" runat="server" Height="411px" Width="204px" SelectionMode="Multiple">
                                            </asp:ListBox></td>
                                        <td align="center" style="width: 42px" valign="top">
                                            <asp:Button ID="Button5" runat="server" OnClick="Button1_Click" Text=">" Width="58px" /><br />
                                            <br />
                                            <asp:Button ID="Button6" runat="server" OnClick="Button5_Click" Text=">>" Width="58px" />
                                            <br />
                                            <asp:Button ID="Button7" runat="server" OnClick="Button4_Click" Text="<" Width="58px" /><br />
                                            <br />
                                            <asp:Button ID="Button8" runat="server" OnClick="Button6_Click" Text="<<" Width="58px" />
                                        </td>
                                        <td align="center" style="width: 100px" valign="top">
                                            <asp:ListBox ID="TargetListBox" runat="server" Height="411px" Width="197px" SelectionMode="Multiple">
                                            </asp:ListBox></td>
                                    </tr>
                                </table>
                                &nbsp;</td>
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
