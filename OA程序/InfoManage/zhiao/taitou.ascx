<%@ Control Language="C#" AutoEventWireup="true" Codebehind="taitou.ascx.cs" Inherits="xyoa.InfoManage.zhiao.taitou" %>
<table width="991" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td valign="top">
            <table width="991" height="10" border="0" cellpadding="0" cellspacing="0">
                <tr>
                </tr>
            </table>
            <table width="991" height="41" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="19" background="../../oaimg/zst/zst1.jpg">
                        &nbsp;
                    </td>
                    <td width="623" background="../../oaimg/zst/zst2.jpg">
                        <table width="100%" height="29" border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="88%">
                                    &nbsp;<asp:TextBox ID="Search" runat="server" BorderWidth="0px" Width="536px"></asp:TextBox></td>
                                <td width="12%">
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="/oaimg/zst/ss.jpg" OnClick="ImageButton1_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td width="20" background="../../oaimg/zst/zst3.jpg">
                        &nbsp;
                    </td>
                    <td width="83">
                        <a href="MyPage.aspx?url=5">
                            <img src="../../oaimg/zst/tw.jpg" width="83" height="41" border="0"></a></td>
                    <td width="88">
                        <a href="wenti_all.aspx">
                            <img src="../../oaimg/zst/hd.jpg" width="88" height="41" border="0"></a></td>
                    <td width="86">
                        <a href="ziliao_all.aspx">
                            <img src="../../oaimg/zst/zl.jpg" width="86" height="41" border="0"></a></td>
                    <td width="72">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </td>
</table>
<table width="991" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td width="111" align="right">
        </td>
        <td width="880" valign="top">
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True">问题</asp:ListItem>
                <asp:ListItem>资料</asp:ListItem>
            </asp:RadioButtonList></td>
    </tr>
</table>
