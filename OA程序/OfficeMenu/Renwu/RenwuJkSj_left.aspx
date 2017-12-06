<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RenwuJkSj_left.aspx.cs" Inherits="xyoa.OfficeMenu.Renwu.RenwuJkSj_left" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TreeView ID="ListTreeView" runat="server" CollapseImageUrl="~/images/2.gif"
                ExpandImageUrl="~/images/1.gif" NodeIndent="10" ShowLines="True">
                <Nodes>
                    <asp:TreeNode Text="2010" Value="2010" ImageUrl="~/oaimg/menu/knowledge.gif" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2010-01-01&EndTime=2010-01-31' target='nextrform'>1月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2010-02-01&EndTime=2010-02-28' target='nextrform'>2月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2010-03-01&EndTime=2010-03-31' target='nextrform'>3月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2010-04-01&EndTime=2010-04-30' target='nextrform'>4月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2010-05-01&EndTime=2010-05-31' target='nextrform'>5月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2010-06-01&EndTime=2010-06-30' target='nextrform'>6月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2010-07-01&EndTime=2010-07-31' target='nextrform'>7月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2010-08-01&EndTime=2010-08-31' target='nextrform'>8月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2010-09-01&EndTime=2010-09-30' target='nextrform'>9月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2010-10-01&EndTime=2010-10-31' target='nextrform'>10月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2010-11-01&EndTime=2010-11-30' target='nextrform'>11月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2010-12-01&EndTime=2010-12-30' target='nextrform'>12月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="2011" Value="2011" ImageUrl="~/oaimg/menu/knowledge.gif" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2011-01-01&EndTime=2011-01-31' target='nextrform'>1月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2011-02-01&EndTime=2011-02-28' target='nextrform'>2月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2011-03-01&EndTime=2011-03-31' target='nextrform'>3月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2011-04-01&EndTime=2011-04-30' target='nextrform'>4月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2011-05-01&EndTime=2011-05-31' target='nextrform'>5月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2011-06-01&EndTime=2011-06-30' target='nextrform'>6月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2011-07-01&EndTime=2011-07-31' target='nextrform'>7月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2011-08-01&EndTime=2011-08-31' target='nextrform'>8月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2011-09-01&EndTime=2011-09-30' target='nextrform'>9月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2011-10-01&EndTime=2011-10-31' target='nextrform'>10月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2011-11-01&EndTime=2011-11-30' target='nextrform'>11月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2011-12-01&EndTime=2011-12-30' target='nextrform'>12月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="2012" Value="2012" ImageUrl="~/oaimg/menu/knowledge.gif" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2012-01-01&EndTime=2012-01-31' target='nextrform'>1月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2012-02-01&EndTime=2012-02-29' target='nextrform'>2月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2012-03-01&EndTime=2012-03-31' target='nextrform'>3月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2012-04-01&EndTime=2012-04-30' target='nextrform'>4月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2012-05-01&EndTime=2012-05-31' target='nextrform'>5月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2012-06-01&EndTime=2012-06-30' target='nextrform'>6月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2012-07-01&EndTime=2012-07-31' target='nextrform'>7月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2012-08-01&EndTime=2012-08-31' target='nextrform'>8月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2012-09-01&EndTime=2012-09-30' target='nextrform'>9月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2012-10-01&EndTime=2012-10-31' target='nextrform'>10月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2012-11-01&EndTime=2012-11-30' target='nextrform'>11月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2012-12-01&EndTime=2012-12-30' target='nextrform'>12月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="2013" Value="2013" ImageUrl="~/oaimg/menu/knowledge.gif" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2013-01-01&EndTime=2013-01-31' target='nextrform'>1月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2013-02-01&EndTime=2013-02-28' target='nextrform'>2月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2013-03-01&EndTime=2013-03-31' target='nextrform'>3月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2013-04-01&EndTime=2013-04-30' target='nextrform'>4月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2013-05-01&EndTime=2013-05-31' target='nextrform'>5月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2013-06-01&EndTime=2013-06-30' target='nextrform'>6月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2013-07-01&EndTime=2013-07-31' target='nextrform'>7月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2013-08-01&EndTime=2013-08-31' target='nextrform'>8月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2013-09-01&EndTime=2013-09-30' target='nextrform'>9月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2013-10-01&EndTime=2013-10-31' target='nextrform'>10月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2013-11-01&EndTime=2013-11-30' target='nextrform'>11月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2013-12-01&EndTime=2013-12-30' target='nextrform'>12月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="2014" Value="2014" ImageUrl="~/oaimg/menu/knowledge.gif" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2014-01-01&EndTime=2014-01-31' target='nextrform'>1月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2014-02-01&EndTime=2014-02-28' target='nextrform'>2月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2014-03-01&EndTime=2014-03-31' target='nextrform'>3月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2014-04-01&EndTime=2014-04-30' target='nextrform'>4月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2014-05-01&EndTime=2014-05-31' target='nextrform'>5月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2014-06-01&EndTime=2014-06-30' target='nextrform'>6月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2014-07-01&EndTime=2014-07-31' target='nextrform'>7月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2014-08-01&EndTime=2014-08-31' target='nextrform'>8月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2014-09-01&EndTime=2014-09-30' target='nextrform'>9月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2014-10-01&EndTime=2014-10-31' target='nextrform'>10月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2014-11-01&EndTime=2014-11-30' target='nextrform'>11月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2014-12-01&EndTime=2014-12-30' target='nextrform'>12月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="2015" Value="2015" ImageUrl="~/oaimg/menu/knowledge.gif" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2015-01-01&EndTime=2015-01-31' target='nextrform'>1月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2015-02-01&EndTime=2015-02-28' target='nextrform'>2月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2015-03-01&EndTime=2015-03-31' target='nextrform'>3月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2015-04-01&EndTime=2015-04-30' target='nextrform'>4月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2015-05-01&EndTime=2015-05-31' target='nextrform'>5月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2015-06-01&EndTime=2015-06-30' target='nextrform'>6月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2015-07-01&EndTime=2015-07-31' target='nextrform'>7月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2015-08-01&EndTime=2015-08-31' target='nextrform'>8月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2015-09-01&EndTime=2015-09-30' target='nextrform'>9月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2015-10-01&EndTime=2015-10-31' target='nextrform'>10月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2015-11-01&EndTime=2015-11-30' target='nextrform'>11月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2015-12-01&EndTime=2015-12-30' target='nextrform'>12月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="2016" Value="2016" ImageUrl="~/oaimg/menu/knowledge.gif" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2016-01-01&EndTime=2016-01-31' target='nextrform'>1月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2016-02-01&EndTime=2016-02-29' target='nextrform'>2月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2016-03-01&EndTime=2016-03-31' target='nextrform'>3月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2016-04-01&EndTime=2016-04-30' target='nextrform'>4月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2016-05-01&EndTime=2016-05-31' target='nextrform'>5月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2016-06-01&EndTime=2016-06-30' target='nextrform'>6月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2016-07-01&EndTime=2016-07-31' target='nextrform'>7月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2016-08-01&EndTime=2016-08-31' target='nextrform'>8月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2016-09-01&EndTime=2016-09-30' target='nextrform'>9月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2016-10-01&EndTime=2016-10-31' target='nextrform'>10月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2016-11-01&EndTime=2016-11-30' target='nextrform'>11月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2016-12-01&EndTime=2016-12-30' target='nextrform'>12月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="2017" Value="2017" ImageUrl="~/oaimg/menu/knowledge.gif" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2017-01-01&EndTime=2017-01-31' target='nextrform'>1月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2017-02-01&EndTime=2017-02-28' target='nextrform'>2月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2017-03-01&EndTime=2017-03-31' target='nextrform'>3月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2017-04-01&EndTime=2017-04-30' target='nextrform'>4月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2017-05-01&EndTime=2017-05-31' target='nextrform'>5月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2017-06-01&EndTime=2017-06-30' target='nextrform'>6月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2017-07-01&EndTime=2017-07-31' target='nextrform'>7月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2017-08-01&EndTime=2017-08-31' target='nextrform'>8月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2017-09-01&EndTime=2017-09-30' target='nextrform'>9月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2017-10-01&EndTime=2017-10-31' target='nextrform'>10月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2017-11-01&EndTime=2017-11-30' target='nextrform'>11月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2017-12-01&EndTime=2017-12-30' target='nextrform'>12月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="2018" Value="2018" ImageUrl="~/oaimg/menu/knowledge.gif" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2018-01-01&EndTime=2018-01-31' target='nextrform'>1月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2018-02-01&EndTime=2018-02-28' target='nextrform'>2月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2018-03-01&EndTime=2018-03-31' target='nextrform'>3月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2018-04-01&EndTime=2018-04-30' target='nextrform'>4月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2018-05-01&EndTime=2018-05-31' target='nextrform'>5月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2018-06-01&EndTime=2018-06-30' target='nextrform'>6月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2018-07-01&EndTime=2018-07-31' target='nextrform'>7月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2018-08-01&EndTime=2018-08-31' target='nextrform'>8月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2018-09-01&EndTime=2018-09-30' target='nextrform'>9月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2018-10-01&EndTime=2018-10-31' target='nextrform'>10月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2018-11-01&EndTime=2018-11-30' target='nextrform'>11月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2018-12-01&EndTime=2018-12-30' target='nextrform'>12月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="2019" Value="2019" ImageUrl="~/oaimg/menu/knowledge.gif" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2019-01-01&EndTime=2019-01-31' target='nextrform'>1月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2019-02-01&EndTime=2019-02-28' target='nextrform'>2月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2019-03-01&EndTime=2019-03-31' target='nextrform'>3月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2019-04-01&EndTime=2019-04-30' target='nextrform'>4月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2019-05-01&EndTime=2019-05-31' target='nextrform'>5月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2019-06-01&EndTime=2019-06-30' target='nextrform'>6月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2019-07-01&EndTime=2019-07-31' target='nextrform'>7月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2019-08-01&EndTime=2019-08-31' target='nextrform'>8月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2019-09-01&EndTime=2019-09-30' target='nextrform'>9月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2019-10-01&EndTime=2019-10-31' target='nextrform'>10月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2019-11-01&EndTime=2019-11-30' target='nextrform'>11月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2019-12-01&EndTime=2019-12-30' target='nextrform'>12月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                    </asp:TreeNode>
                    <asp:TreeNode Text="2020" Value="2020" ImageUrl="~/oaimg/menu/knowledge.gif" Expanded="False"
                        SelectAction="Expand">
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2020-01-01&EndTime=2020-01-31' target='nextrform'>1月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2020-02-01&EndTime=2020-02-29' target='nextrform'>2月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2020-03-01&EndTime=2020-03-31' target='nextrform'>3月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2020-04-01&EndTime=2020-04-30' target='nextrform'>4月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2020-05-01&EndTime=2020-05-31' target='nextrform'>5月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2020-06-01&EndTime=2020-06-30' target='nextrform'>6月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2020-07-01&EndTime=2020-07-31' target='nextrform'>7月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2020-08-01&EndTime=2020-08-31' target='nextrform'>8月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2020-09-01&EndTime=2020-09-30' target='nextrform'>9月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2020-10-01&EndTime=2020-10-31' target='nextrform'>10月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2020-11-01&EndTime=2020-11-30' target='nextrform'>11月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                        <asp:TreeNode Text="<a href='RenwuJk_list.aspx?StartTime=2020-12-01&EndTime=2020-12-30' target='nextrform'>12月</a>"
                            ImageUrl="~/oaimg/menu/Menu293.gif" SelectAction="Expand"></asp:TreeNode>
                    </asp:TreeNode>
                </Nodes>
            </asp:TreeView>
        </div>
    </form>
</body>
</html>