<%@ Page Language="C#" AutoEventWireup="true" Codebehind="index.aspx.cs" Inherits="xyoa.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
        <%=ViewState["Geyan"] %>
    </title>

    <script>
window.moveTo(0,0)
window.resizeTo(screen.availWidth+9,screen.availHeight+9)



document.write('<div id="loading" style="background:#CC4444;color:#FFF;width:120px;padding-left:5px;position:absolute;line-height:22px;z-index:30;">页面加载中，请稍后...</div>');; 
document.write('<div id="backloading" style="width:100%;height:100%;position:absolute;z-index:20;border:0px;background-color:#ffffff;filter:alpha(opacity=30);"align="center"></div>'); 
    </script>
 
    <link href="/Css/style.css" rel="stylesheet" type="text/css" />
    <link href="/Css/skin1/index2.css" rel="stylesheet" type="text/css" />

    

    <script src="/Script/jquery.js" type="text/javascript"></script>

    <script src="/Script/jqueryUI/jquery.ui.core.js" type="text/javascript"></script>

    <script src="/Script/jqueryUI/jquery.ui.widget.js" type="text/javascript"></script>

    <script src="/Script/jqueryUI/jquery.ui.mouse.js" type="text/javascript"></script>

    <script src="/Script/jqueryUI/jquery.ui.draggable.js" type="text/javascript"></script>

    <script src="/Script/homepage_1.js" type="text/javascript"></script>

    <script src="/Script/jquery.contextmenu.r2.packed.js" type="text/javascript"></script>


    <script src="/Script/iepngfix_tilebg.js" type="text/javascript"></script>

    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            $("#Start").hover(function() { $(this).css("background-image", "url(/Images/skin1/mydesign1.png)"); }, function() { $("#Start").css("background-image", "url(/Images/skin1/mydesign.png)"); });
            $("#Start").click(function() { $("#delcin").slideDown(50); });
            $("#delcin").hover(function() { }, function() { setTimeout("$('#delcin').slideUp(100)", 200); });
            $("#delcin > ul > li").hover(function() { $(this).css("background-color", "#F1C9EE"); }, function() { $(this).css("background-color", "#ffffff"); });
        });
        var tp = Math.round(new Date().getTime() / 1000);
        function winClose(stu) { $("#" + stu).empty().remove(); $("#p_" + stu).empty().remove(); }
        //window.onbeforeunload = function() { loginoutclo(); }
        function loadingJS() {
            (function() {
                var ga1 = document.createElement('script'); ga1.type = 'text/javascript'; ga1.async = true;
                ga1.src = "/Script/jquery.form.js";
                var s = document.getElementsByTagName('script')[0];
                s.parentNode.insertBefore(ga1, s);
            })();
            (function() {
                var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
                ga.src = "/Script/MyUploadImg.js";
                var s = document.getElementsByTagName('script')[0];
                s.parentNode.insertBefore(ga, s);
            })();
        }
        function saa() { $(".ifromeDiv").hide(); }
    </script>
<style>
.winTitle
{
	width:100%;
	height:25px;
	line-height:25px;
	text-indent:20px;
	background-image:url(/<%=ViewState["btlstl"] %>/header_bg.gif);
	cursor:move;
}
#taskbarDiv
{
	width: 100%;
	height: 29px;
	border-top: 1px solid #666;
	background-image: url(/<%=ViewState["btlstl"] %>/header_bg.gif);
	position:absolute;
}

.icon-text{
   cursor: pointer;
	margin-top: 3px;
	padding-left: 10px;
	height: 20px;
	display: inline-block;
	<%=ViewState["css1"] %>
	overflow:hidden
}

.icon-text span{
	display: inline-block;
	height: 20px;
	line-height: 20px;
	<%=ViewState["css2"] %>
	<%=ViewState["css3"] %>
	padding: 0 10px 0 0px;
	overflow:hidden
}

.toppng 
{
	width:231px;
	height:30px;
	line-height:30px;
	background-image:url(/Images/toppng.png);
	color:#ffffff;
	text-align:center;
	position: absolute;
	<%=ViewState["css4"] %>
    letter-spacing:12px;
    _*behavior: url(/Script/ie6pan/iepngfix.htc);
}
</style>
</head>
<body onresize="alie()" scroll="no" style="background-position: center center; overflow: hidden;
    _*overflow: visible; *+overflow: visible"  oncontextmenu="return false">
    <form id="form1" runat="server">

        <script> 
var g_blinkswitch = 0; 
var g_blinktitle = document.title; 
function blinkNewMsg() 
{ 
if(document.getElementById('TextBox1').value=="tixing")
{
    document.title = g_blinkswitch % 2==0 ? "【　　　】 - " + g_blinktitle : "【新消息】 - " + g_blinktitle;
    $("#msgtx").show();
}
else
{
    document.title = "<%=Session["Titles"]%><%=ViewState["Geyan"] %>";
    $("#msgtx").hide();
}
g_blinkswitch++; 
} 

setInterval(blinkNewMsg, 1000); 



        </script>
         <asp:TextBox ID="TextBox1" runat="server"  Style="display: none"></asp:TextBox>
        <asp:TextBox ID="menhuid" runat="server" Text="1" Style="display: none"></asp:TextBox>
        <asp:Label ID="Label1" runat="server"></asp:Label>
          <div class="ieold" id="ieli"  onmousedown="dreag('ieli')"  style="display: none;">
           提醒：当前IE版本过低，影响网页性能及软件美观，建议您切换为<a href="main.aspx"><font color="#0000FF">经典界面</font></a>或<a href="http://windows.microsoft.com/zh-CN/internet-explorer/downloads/ie" target=_blank><font color="#0000FF">升级IE版本</font></a>  <a href="javascript:void(0)" onclick="ielidel()"><font color="#0000FF">我知道了</font></a></div>
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <asp:Label ID="daibanshiyi" runat="server"></asp:Label>
        <asp:Label ID="Label3" runat="server" Visible=false></asp:Label>
    </form>
</body>
</html>
<%=ViewState["js"] %>
<script type="text/javascript"> 
window.onload=function(){ 
var a = document.getElementById("loading"); 
   var b = document.getElementById("backloading"); 
  a.parentNode.removeChild(a); 
   b.parentNode.removeChild(b); 
}


</script>
