
var g_zzjs_net={};
var oDiv=null;
var g_iSpeed=0;
var t=null;
window.onload=function(){
 oDiv=document.getElementById("zzjs_net");
 oDiv.style.height="0px";
 document.oncontextmenu=function(ev){
   var oEvent=window.event||ev;
   cancelDefault(oEvent);
   g_zzjs_net.MouseX=oEvent.clientX;
   g_zzjs_net.MouseY=oEvent.clientY;
   oDiv.style.left=g_zzjs_net.MouseX+"px";
   oDiv.style.top=g_zzjs_net.MouseY+"px";
   var oUl=document.getElementById("zzjs");
   var aLi=oUl.getElementsByTagName("li");
   for(var i=0;i<aLi.length;i++){
    aLi[i].style.background="none";
   }
   clearInterval(t);
   doDiv();
 }
 document.body.onmousedown=function(ev){
  var oEvent=window.event||ev;
  clearInterval(t);
  g_iSpeed=0;
  g_zzjs_net.h=0;
  oDiv.style.height=g_zzjs_net.h+"px";
  oDiv.style.display="none";
 }
 oDiv.onmousedown=function(ev){
  var oEvent=window.event||ev;
  oEvent.cancelBubble=true;
 }
}
function doDiv(ev){
 var oEvent=window.event||ev;
 oDiv.style.display="block";
 t=setInterval(doMove,30);
}
function doMove(){
 if(oDiv.offsetHeight>=185){
  g_iSpeed*=-0;
  oDiv.style.height=185+"px";
 }
 g_zzjs_net.h=g_iSpeed+oDiv.offsetHeight;
 g_iSpeed+=10;
 oDiv.style.height=g_zzjs_net.h+"px";
}
function cancelDefault(oEvent){
 if(oEvent.preventDefault){
  oEvent.preventDefault();
 }
 else{
  oEvent.returnValue=false;
 }
}
