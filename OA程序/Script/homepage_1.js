//$(document).ready(function() {
//    var tp = Math.round(new Date().getTime() / 1000);
//    $.get("/Handler/getAfficheByLogin.ashx?t=" + tp, function(data) {
//        if (data == null) {
//        } else if (data == -1000) {
//        } else {
//            $("#taskbarDiv").before(data);
//        }
//    });
//});

function getAff() {
    var tp = Math.round(new Date().getTime() / 1000);
    $.get("/Handler/getAfficheByLogin.ashx?t=" + tp, function(data) {
        if (data == null) {
        } else if (data == -1000) {
        } else {
            $("#affiche_DIV").empty().remove();
            $("#taskbarDiv").before(data);
            $("#affiche_DIV").css("z-index", dd + 2);
        }
    });
}

function chloginTimeOut() {
    //    getAff();
    //    var tp = Math.round(new Date().getTime() / 1000);
    //    $.get("/Handler/CheckupLoginOvertime.ashx?t=" + tp, function(data) {
    //        if (data == -1) {
    //            var htm2 = "<div id=\"alertLoginOut1\"><span></span>很抱歉，你登录超时了，请重新登录！<br/><p><input type=\"button\" onclick=\"window.location.href='/Login.aspx'\" value=\" 重新登录 \" /></p></div>";
    //            $("#taskbarDiv").after("<div id=\"shoesss\"></div>");
    //            var winHeight = document.documentElement.clientHeight;
    //            $("#shoesss").css("height", winHeight);
    //            $("#shoesss").fadeTo(300, 0.66);
    //            $("#taskbarDiv").after(htm2);
    //            clearInterval(MyInterval);
    //        }
    //    });
}
var MyInterval = setInterval("chloginTimeOut()", 60 * 1000);

function hoverUlLi() {
    $(document).ready(function() { $("#winParent ul > li").hover(function() { $(this).addClass("zm_caidan_li_hover") }, function() { $(this).removeClass("zm_caidan_li_hover") }); });
}
var timerID;
var dd = true;
function cle() {
    clearTimeout(timerID)
    if (dd) {
        document.title = "你有1条新消息";
        dd = false;
    } else {
        document.title = "--";
        dd = true;
    }
    timerID = setTimeout("cle()", 800);
}

var msg = "测试标题栏";
var speed = 300;
var msgud = " " + msg;
function titleScroll() {
    if (msgud.length < msg.length) msgud += " - " + msg;
    msgud = msgud.substring(1, msgud.length);
    document.title = msgud.substring(0, msg.length);
    window.setTimeout("titleScroll()", speed);
}

function alie() {
    var divWidth = document.body.clientWidth;
    var winHeight = document.documentElement.clientHeight;
    if (winHeight < 500)
        $("#winParent").css("height", 500);
    else
        $("#winParent").css("height", winHeight - 30);
 
    var shei = document.body.clientHeight;
    var swin = document.body.clientWidth;
    $("#bg_DIV_img_zhe").css({ "height": shei + "px", "width": swin + "px" });
    $("#bg_DIV_img").html("<img src=\"/Handler/bgImg.ashx?h=" + shei + "&w=" + swin + "\" />");
}

var dd = 10;
function fules(id) {
    $("#" + id).css("z-index", dd);
    dd = dd + 1;
    $("#taskbarDiv").css("z-index", dd + 1);
}

function showWin(id, stu, url, key) {
    var obj = $("#" + id).html();
    if (obj == null) { //没有实例化的窗口
        var htm = "<div id=\"" + id + "\" class=\"ifromeDiv\" onmousedown=\"fules('" + id + "')\">";
        htm = htm + "<div class=\"midk\">";
        htm = htm + "<div class=\"Main\"><p class=\"winTitle\" ondblclick=\"zuidahua('" + id + "','" + stu + "')\"><span class=\"closeBtn\" title=\"关闭窗口\" onclick=\"winClose('" + id + "')\"></span><span class=\"closeBtn2\" title=\"最大化窗口\" onclick=\"zuidahua('" + id + "','" + stu + "')\"></span><span class=\"closeBtn1\" title=\"最小化窗口\" onclick=\"showatd('" + id + "','" + stu + "')\"></span><label>" + stu + "</label></p>";
        htm = htm + "<iframe id=\"if" + id + "\" name=\"if" + id + "\" class=\"loadContent\"  src=\"" + url + "&i_chIf_id=" + id + "\" frameborder=\"no\"></iframe>";
        htm = htm + "</div></div></div>";
        $("#winParent").append(htm);
        $("#" + id).draggable({ handle: '.winTitle', containment: 'body', scroll: true,iframeFix: true });
        $("#Ctaskbar").append("<p id=\"p_" + id + "\" onclick=\"showatd('" + id + "')\"><span onclick=\"winClose('" + id + "')\"></span>" + stu + "</p>");
        $("#p_" + id).mouseover(function() { $(this).children("span").css("display", "block"); }).mouseout(function() { $(this).children("span").css("display", "none"); });
        fules(id);
    }
    else { //已实例化的窗口
        $("#" + id).slideToggle(50);
    }
//    if(key=="1")
//    {
      zuidahua(id,stu);
//    }
}

function showWinzhezhao(id, stu, url, key) {
    var obj = $("#" + id).html();
    if (obj == null) { //没有实例化的窗口
        var htm = "<div id=\"showzz\" style=\"top:0;width:100%;height:100%;position:absolute;z-index:1;border:0px;background-color:#ffffff;filter:alpha(opacity=30);\"align=\"center\"></div>";
        htm = htm + "<div id=\"" + id + "\" class=\"ifromeDiv\" onmousedown=\"fules('" + id + "')\">";
        htm = htm + "<div class=\"midk\">";
        htm = htm + "<div class=\"Main\"><p class=\"winTitle\" ondblclick=\"zuidahua('" + id + "','" + stu + "')\"><span class=\"closeBtn\" title=\"关闭窗口\" onclick=\"winClose('" + id + "');movezz();\"></span><span class=\"closeBtn2\" title=\"最大化窗口\" onclick=\"zuidahua('" + id + "','" + stu + "')\"></span><span class=\"closeBtn1\" title=\"最小化窗口\" onclick=\"showatd('" + id + "','" + stu + "')\"></span><label>" + stu + "</label></p>";
        htm = htm + "<iframe id=\"if" + id + "\" name=\"if" + id + "\" class=\"loadContent\"  src=\"" + url + "&i_chIf_id=" + id + "\" frameborder=\"no\"></iframe>";
        htm = htm + "</div></div></div>";
        $("#winParent").append(htm);
        $("#" + id).draggable({ handle: '.winTitle', containment: 'body', scroll: true,iframeFix: true });
        $("#Ctaskbar").append("<p id=\"p_" + id + "\" onclick=\"showatd('" + id + "')\"><span onclick=\"winClose('" + id + "')\"></span>" + stu + "</p>");
        $("#p_" + id).mouseover(function() { $(this).children("span").css("display", "block"); }).mouseout(function() { $(this).children("span").css("display", "none"); });
        fules(id);
    }
    else { //已实例化的窗口
        $("#" + id).slideToggle(50);
    }
    if(key=="1")
    {
      zuidahua(id,stu);
    }
}
function movezz() {
   var b = document.getElementById("showzz"); 
   b.parentNode.removeChild(b); 
}

function dreag(id) {
   
        $("#" + id).draggable({containment: 'body', scroll: true,iframeFix: true });
}

function showatd(id) {
    $("#" + id).slideToggle(50);
    fules(id);
}
function loginout() {
    if (confirm('你确定要退出系统吗?') == false)
        return;
    window.location.href = "out.aspx";
}

function zuidahua(id, stu) {
   
    var d = $("#" + id).css("width");
    var divWidth = document.body.clientWidth;
    var winHeight = document.documentElement.clientHeight - 25;
    if (d == '1005px') {
        $("#" + id).css({ "left": "0px", "top": "0px", "width": divWidth - 6 });
        $("#" + id + " .midk").css("height", winHeight - 6);
        $("#" + id + " .midk .Main").css("width", divWidth - 6);
    } else {
        var e = divWidth - 1005 - 36;
        $("#" + id).css({ "left": e + "px", "top": "5px", "width": "1005px" });
        $("#" + id + " .midk").css("height", "500px");
        $("#" + id + " .midk .Main").css("width", "100%");
    }
}


function zdybjtp() {
    try {
        My_showImgDIV("/Handler/index/customDesktopBGImg.ashx?t=" + Math.round(new Date().getTime() / 1000), function(data) {
            $("body").css("background-image", "url(" + data + "?t=" + Math.round(new Date().getTime() / 1000) + ")");
        });
    } catch (e) {
        alert("网络慢，无法加载需要运行的脚本！");
    }
}

//动态加载css
function loadCss(file) {
    var cssTag = document.getElementById('loadCss');
    var head = document.getElementsByTagName('head').item(0);
    if (cssTag) head.removeChild(cssTag);
    css = document.createElement('link');
    css.href = file;
    css.rel = 'stylesheet';
    css.type = 'text/css';
    css.id = 'loadCss';
    head.appendChild(css);
}

function menhu(str)
{
    if(str=='1')
    {
       document.getElementById('Menhu1').src = "/Images/topurl1a.png";
       document.getElementById('Menhu2').src = "/Images/topurl2b.png";
       document.getElementById('Menhu3').src = "/Images/topurl3b.png";
       document.getElementById('Menhu4').src = "/Images/topurl4b.png";
       document.getElementById('Menhu5').src = "/Images/topurl5b.png";
       document.getElementById('menhuid').value="1";
       document.getElementById('desk1').style.display="";
       document.getElementById('desk2').style.display="none";
       document.getElementById('desk3').style.display="none";
       document.getElementById('desk4').style.display="none";
       document.getElementById('desk5').style.display="none";
    }
    if(str=='2')
    {
       document.getElementById('Menhu1').src = "/Images/topurl1b.png";
       document.getElementById('Menhu2').src = "/Images/topurl2a.png";
       document.getElementById('Menhu3').src = "/Images/topurl3b.png";
       document.getElementById('Menhu4').src = "/Images/topurl4b.png";
       document.getElementById('Menhu5').src = "/Images/topurl5b.png";
       document.getElementById('menhuid').value="2";
       document.getElementById('desk1').style.display="none";
       document.getElementById('desk2').style.display="";
       document.getElementById('desk3').style.display="none";
       document.getElementById('desk4').style.display="none";
       document.getElementById('desk5').style.display="none";
    }
    if(str=='3')
    {
       document.getElementById('Menhu1').src = "/Images/topurl1b.png";
       document.getElementById('Menhu2').src = "/Images/topurl2b.png";
       document.getElementById('Menhu3').src = "/Images/topurl3a.png";
       document.getElementById('Menhu4').src = "/Images/topurl4b.png";
       document.getElementById('Menhu5').src = "/Images/topurl5b.png";
       document.getElementById('menhuid').value="3";
       document.getElementById('desk1').style.display="none";
       document.getElementById('desk2').style.display="none";
       document.getElementById('desk3').style.display="";
       document.getElementById('desk4').style.display="none";
       document.getElementById('desk5').style.display="none";
    }
    if(str=='4')
    {
       document.getElementById('Menhu1').src = "/Images/topurl1b.png";
       document.getElementById('Menhu2').src = "/Images/topurl2b.png";
       document.getElementById('Menhu3').src = "/Images/topurl3b.png";
       document.getElementById('Menhu4').src = "/Images/topurl4a.png";
       document.getElementById('Menhu5').src = "/Images/topurl5b.png";
       document.getElementById('menhuid').value="4";
       document.getElementById('desk1').style.display="none";
       document.getElementById('desk2').style.display="none";
       document.getElementById('desk3').style.display="none";
       document.getElementById('desk4').style.display="";
       document.getElementById('desk5').style.display="none";
    }
    if(str=='5')
    {
       document.getElementById('Menhu1').src = "/Images/topurl1b.png";
       document.getElementById('Menhu2').src = "/Images/topurl2b.png";
       document.getElementById('Menhu3').src = "/Images/topurl3b.png";
       document.getElementById('Menhu4').src = "/Images/topurl4b.png";
       document.getElementById('Menhu5').src = "/Images/topurl5a.png";
       document.getElementById('menhuid').value="5";
       document.getElementById('desk1').style.display="none";
       document.getElementById('desk2').style.display="none";
       document.getElementById('desk3').style.display="none";
       document.getElementById('desk4').style.display="none";
       document.getElementById('desk5').style.display="";
    }	
}  



function dbsyset()
{ 
    if(document.getElementById('dbsykey').style.display=="")
    {
        document.getElementById('dbsykey').style.display="none";
        AjaxMethod.dbsy("1");
    }
    else
    {
        document.getElementById('dbsykey').style.display="";
        AjaxMethod.dbsy("0");
    }
}

function addli()
{ 
var menhu=document.getElementById('menhuid').value;
showWinzhezhao('54387','桌面栏目','/MyWork/MySet/Mokuai.aspx?p=54387&menhu='+menhu+'','0')
}

function setli(liid,id,str,urlname,url,openkey,chuangzhi,bigpic)
{ 
    if(chuangzhi=="0")
    {
        $("#desk"+id+"").prepend("<li id=\""+liid+"\" onclick=\"showWin('"+str+"','"+urlname+"','"+url+"?p="+str+"','"+openkey+"')\"><img src=\"/Images/desktopIOC/"+bigpic+"\" /><br /><div  class=\"icon-text\"><span>"+urlname+"</span></div></li>");
    }
    else
    {
        $("#desk"+id+"").prepend("<li id=\""+liid+"\" onclick=\"showWin('"+str+"','"+urlname+"','"+url+"','"+openkey+"')\"><img src=\"/Images/desktopIOC/"+bigpic+"\" /><br /><div  class=\"icon-text\"><span>"+urlname+"</span></div></li>");
    }
}

function moveli(str)
{ 
$("#"+str+"").hide();
}

function msgdel(str)
{ 
var ver=navigator.appVersion.substring(navigator.appVersion.indexOf("MSIE ")+5,navigator.appVersion.indexOf("MSIE ")+8);
if ( ver<7 ){
document.getElementById('ieli').style.display="";
}
else
{
document.getElementById('ieli').style.display="none";
$("#ieold").hide();
}

  $("#msgtx").hide();
  
  if(str=="1")
  {
    window.infotx.location.href='CountMessageYy.aspx?alldelid=t'
  }
  if(str=="0")
  {
    window.infotx.location.href='CountMessageYy.aspx?allyyid=t'
  }
}

function ielidel()
{ 
 document.getElementById('ieli').style.display="none";
}