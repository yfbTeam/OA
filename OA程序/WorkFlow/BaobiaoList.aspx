<%@ Page Language="C#" AutoEventWireup="true" Codebehind="BaobiaoList.aspx.cs" Inherits="xyoa.WorkFlow.BaobiaoList" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/js/prototojquery.js" type="text/javascript"></script>

    <script language="javascript">
  window.onload= function()
  {
			page_width = _G("formDiv").offsetWidth;
			page_height = _G("FormContent").clientHeight;
 }
 
 var lv_tr = null;
 


function get_nextSibling(n)
{
  y=n.nextSibling;
  while (y.tagName!="DIV")
  {
 	 y=y.nextSibling;
  }
  return y;
}

//将表单放大1%
function fnZoomIn() {
 _G("FormContent").style.zoom = parseFloat(_G("FormContent").style.zoom) + 0.05 ;
 fnWritePos(_G("FormContent").style.zoom);
}

//将表单缩小1%
function fnZoomOut() {
 if(_G("FormContent").style.zoom>0.01){
    _G("FormContent").style.zoom = parseFloat(_G("FormContent").style.zoom) - 0.05 ;
    fnWritePos(_G("FormContent").style.zoom);
 }
}

function ChangeZoomVal() {
  var ChangeZoomStr = _G("zoom").value;
    if(ChangeZoomStr.length==0){
    alert("请输入缩放比例！");
    _G("zoom").focus();
    return false;
  }
    for(var i=0;i<ChangeZoomStr.length;i++){
    if(ChangeZoomStr.charAt(i)<'0'||ChangeZoomStr.charAt(i)>'9'){
    alert("请输入整数！");
    _G("zoom").focus();
    return false;
    }
  }
   if(parseInt(ChangeZoomStr)<=0){
    alert("请输入大于0的整数！");
    _G("zoom").focus();
    return false;
   }
   var ChangeZoomValue = parseFloat(ChangeZoomStr);
   _G("FormContent").style.zoom = ChangeZoomValue/100;
}

//表单大小显示框
function fnWritePos(intZoom) {
   _G("zoom").value = parseInt(intZoom*100);
}
var page_width ;
var page_height;
function zoom_a4()
{
	var width_zoom = 1;
	var height_zoom = 1;
    if(page_width>640)
	{
		width_zoom = parseFloat(640/page_width);
	}
    if(page_height>960)
	{
		height_zoom = parseFloat(690/page_height);
	}
	if(width_zoom>height_zoom)
	 width_zoom = height_zoom;
	_G("FormContent").style.zoom = width_zoom ;
	fnWritePos(width_zoom)
}

function printbb()
{
document.getElementById("prtable") .style.visibility="hidden"
document.getElementById("prhr") .style.visibility="hidden"
print();
document.getElementById("prtable") .style.visibility="visible"
document.getElementById("prhr") .style.visibility="visible"
}
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" id="prtable">
            <tr>
                <td width="9%">
                    缩放比例：<input onblur="ChangeZoomVal()" style="width: 25px; height: 18px; font-size: 12px"
                        id="zoom" value="100" name="zoom">%&nbsp;</td>
                <td width="56%">
                    <img src="/oaimg/zoom.gif" alt="放大打印" width="16" height="16" align="absmiddle" style="cursor: pointer"
                        onclick="fnZoomIn()">&nbsp;&nbsp;<img src="/oaimg/zoom-.gif" style="cursor: pointer"
                            onclick="fnZoomOut()" alt="缩小打印" align="absmiddle">&nbsp;&nbsp;<img src="/oaimg/zoom-base.gif"
                                style="cursor: pointer" onclick="zoom_a4()" alt="使之符合A4大小" align="absmiddle"
                                if="if"></td>
                <td width="35%" align="right">
                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="返回重新统计" />
                    <asp:Button ID="Button1" runat="server" Text="导出到EXCEL" OnClick="Button1_Click" />
                    <asp:Button ID="Button2" runat="server" Text="导出到WORD" OnClick="Button2_Click" /><input
                        id="btnPrint" class="btn2" onclick="printbb();" value=" 打 印 " type="button" name="btnPrint"></td>
            </tr>
        </table>
        <hr  id="prhr">
        <div style="zoom: 1" id="FormContent" align=center>
            <table class="mytable" border="0" cellspacing="0" cellpadding="0">
                <tbody>
                    <tr>
                        <td valign="top" colspan="2" align=center>
                            <div style="height: 100%">
                                <div id="formDiv">
                                 <asp:Label ID="Label1" runat="server"></asp:Label>
                                </div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            
        </div>
    </form>
</body>
</html>
