<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TongZhiGongGao.aspx.cs"
    Inherits="xyoa.PublicWork.Menu" %>

<html>
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>
      通知公告
    </title>
    <link href="../Css/reset.css" rel="stylesheet" />
    <link href="../Css/styles.css" rel="stylesheet" />
    <link href="../Css/iconfont.css" rel="stylesheet" />
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <script src="../Css/jquery-1.8.3.min.js"></script>
	    <script type="text/javascript">
	        $(function () {
	            function reSize() {
	                $('.box .left').height($(window).height() - 60 + 'px');
	                $('.box .right,#iframbox').height($(window).height() - 60 + 'px');
	            }
	            reSize();
	            $(window).resize(function () {
	                reSize();
	            })
	        })
	    </script>
</head>
<body style="overflow: auto" bgcolor="white">
    <form id="form1" runat="server">
        <%--<table width="100%" height="20" border="0" cellpadding="0" cellspacing="0" class="blueleft">
            <tr>
                <td width="30%" align="right" valign="top">
                    <img src="/oaimg/menu/Choose55.gif" width="16" height="16" hspace="10"></td>
                <td width="70%">
                    <a href="PublicWorkMenu.aspx"><font class="lefttd">公共事务</font></a></td>
            </tr>
        </table>
        <div id="show" style="display: none">
            <font color="#ff0000" size="2">菜单下载中...</font>
        </div>--%>

        <asp:TreeView ID="TreeView9" runat="server" NodeIndent="10" ShowLines="True">
            <Nodes>
                <asp:TreeNode Expanded="False" SelectAction="Expand" Text="通知公告" Value="jjjj3" ImageUrl="~/oaimg/menu/Menu46.gif">
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="&lt;a href='/PublicWork/BumenNewsMg/BumenNewsMgList.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;通知浏览&lt;/a&gt;"
                        Value="jjjj3a" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="&lt;a href='/PublicWork/BumenNewsMg/BumenNewsMg.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;通知管理&lt;/a&gt;"
                        Value="jjjj3b" SelectAction="None"></asp:TreeNode>
                    <asp:TreeNode ImageUrl="~/oaimg/menu/Menu46.gif" Text="&lt;a href='/PublicWork/BumenNewsMg/BumenNewsSc.aspx ' target='rform' onclick='parent.UploadComplete();'&gt;我的收藏&lt;/a&gt;"
                        Value="jjjj3c" SelectAction="None"></asp:TreeNode>
                </asp:TreeNode>

            </Nodes>
        </asp:TreeView>

        <div class="wrap">
            <!--头部-->
            <div class="top">
                <div class="topcon">
                    <div style="width:1200px;margin: 0 auto;">
                        <div class="top_left fl">
                            <div class="logo fl">
                                <img src="../Css/logo.png" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="clear"></div>
            <div class="center">
                <!--内容区域-->
                <div class="box">
                    <!--左边-->
                    <div class="left" id="sliderbox" style="height: 918px;">
                        <div class="menubox">
                            <div class="aside" style="display: block;"></div>
                            <!--菜单区域-->
                            <div class="menu" id="menubox">
                                <ul id="ul_leftmenu">
                                	<li>
                                		<a class="menuclick" href="javascript:;">通知公告<span class="iconfont icon-icoxiala"></span></a>
                                		<ul class="submenu" style="display:block;">
                                			<li><a href="javascript:void(0);" data-src="/PublicWork/BumenNewsMg/BumenNewsMgList.aspx">通知浏览</a></li>
                                			<li><a href="javascript:void(0);" data-src="/PublicWork/BumenNewsMg/BumenNewsMg.aspx">通知管理</a></li>
                                			<li><a href="javascript:void(0);" data-src="/PublicWork/BumenNewsMg/BumenNewsSc.aspx">我的收藏</a></li>   
                             			
                                		</ul>
                                	</li>
                                	
                                </ul>
                            </div>
                            <!--end 菜单区域-->
                        </div>
                    </div>
                    <!--右边-->
                    <div class="right" style="height: 918px;">
                        <iframe id="iframbox" src="/PublicWork/BumenNewsMg/BumenNewsMgList.aspx" width="100%" frameborder="0" height="100%" style="height: 918px;"></iframe>
                    </div>
                </div>
            </div>
       </div>
       <script>
           $(function () {
               $('#TreeView9').hide();
               loading();
               //$("#menubox").find(".menuclick").click(function () {
               //    $(this).parent().toggleClass("selected").siblings().removeClass("selected").find('span').toggleClass('active');
               //    $(this).find('span').toggleClass('active');
               //    $("#menubox").find('span').not($(this).find('span')).removeClass('active');
               //    $(this).next().stop(true, true).slideToggle("fast").end().parent().siblings().find(".submenu")
               //    .addClass("animated flipInX").stop(true, true)
               //    .slideUp("fast").end();
               //});
           })
           function loading() {
               var silderBox = document.getElementById("sliderbox");//dom对象
               var adoms = silderBox.getElementsByTagName("a");//这是一个集合对象HTMLCollection对象
               //document.getElementsByClassName document.querySelectorAll(".items");
               var len = adoms.length;
               while (len--) {
                   adoms[len].onclick = function () {
                       var src = this.getAttribute("data-src");

                       //$(".submenu li").each(function(){
                       //$(this).removeClass("selected");
                       // });

                       $(this).parent().addClass("selected").siblings().removeClass("selected");
                       if (src != null) {
                           document.getElementById("iframbox").src = src;
                       }
                   }
               };
           };
       </script>

    </form>
</body>
</html>
