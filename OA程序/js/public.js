//v10.3
function killErrors() {
return true;
}
window.onerror = killErrors;	


var oldgridSelectedColor;
function setMouseOverColor(element) {

    oldgridSelectedColor = element.style.backgroundColor;
    element.style.backgroundColor='#EAEAEA';
   // element.style.cursor='hand';
   // element.style.textDecoration='underline';
}
function setMouseOutColor(element) {

    element.style.backgroundColor=oldgridSelectedColor;
    element.style.textDecoration='none';
}

function setMouseOverColor1(element) {

    oldgridSelectedColor = element.style.backgroundColor;
    element.style.backgroundColor='#ECF8E9';
}

function OpenWfPic(str)
{
    if(str=='')
    {
        alert('请选择需要打开的表单'); 
        return false;
    }
    
    var num=Math.random();
    loc_x=(screen.availWidth-700)/2;
    loc_y=(screen.availHeight-550)/2;
    window.open ("/WorkFlowSysMag/AddWorkFlow_show_lc.aspx?tmp="+num+"&FormId="+str+"&DqNodeId=&DqNodeName=无步骤", "_blank", "height=560, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function opennewwin(str1,str2)
{
    var num=Math.random();
    window.showModalDialog(""+str1+"?tmp="+num+"&"+str2+"","window", "dialogWidth:920px;DialogHeight=580px;status:no;scroll=yes;help:no");       
}



function ReverseAll(str){

            for(var i=0;i<document.getElementById(""+str+"").getElementsByTagName("input").length;i++)

             {

                var objCheck = document.getElementById(""+str+"_"+i);

                if(objCheck.checked)

                    objCheck.checked = false;

                else

                    objCheck.checked = true;

            }

        }


function showwait()
{
    showCover();
    //控件宽
    var aw = 400;
    //控件高
    var ah = 80;
    //计算控件水平位置
    var al = (screen.width - aw)/2-150;
    //计算控件垂直位置
    var at = (screen.height - ah)/5;
    //内容管理
    var title = '';
    var icon = 'indi.gif';
    var cardID = '0';
    //输出提示框
    var div = document.createElement("div");
    div.id = "UploadChoose";
    div.innerHTML = '\
    <div style="background-color:#FFFFFF;position:absolute;top:'+at+'px;left:'+al+'px;width:'+aw+'px;height:'+ah+'px;border:2px solid #000000;text-align:center">\
        <div style="clear:both;background-color:#0099AA;line-height:25px;font-weight:bold;color:#FFFFFF;font-size:12px;padding-left:10px">'+title+'</div>\
        <div style="padding-top:30px;">\
        <div style="float:left;width:60px;padding-left:50px"><img src="/oaimg/'+icon+'" alert"Cardo" /></div>\
       <div style="float:left;width:180px;margin-top:13px;padding-left:0px"><b>数据加载中，请稍候...</b></div>\
    <div style="clear:both;text-align:center;margin-top:10px;padding-bottom:10px">\
            </div>\
        </div>\
    </div>';
    document.body.appendChild(div);
}


function chkyema()
{
    if(document.getElementById('GoPage').value=='')
    {
    alert('页码不能为空');
    form1.GoPage.focus();
    return false;
    }	
   
    if(document.getElementById('GoPage').value!='')
    {
    var objRe = /^(0|[1-9]\d*)$/;
    if(!objRe.test(document.getElementById('GoPage').value))
    {
    alert('页码只能为数字');
    form1.GoPage.focus();
    return false;
    }
    }
   
    
    showwait();	
}  


function printnewpage()
{
document.getElementById("printshow1") .style.visibility="hidden"
document.getElementById("printshow2") .style.visibility="hidden"
document.getElementById("printshow3") .style.visibility="hidden"
document.getElementById("printshow4") .style.visibility="hidden"
document.getElementById("tableprint") .border="1"
print();
document.getElementById("printshow1") .style.visibility="visible"
document.getElementById("printshow2") .style.visibility="visible"
document.getElementById("printshow3") .style.visibility="visible"
document.getElementById("printshow4") .style.visibility="visible"
document.getElementById("tableprint") .border="0"
}



function printpage()
{
document.getElementById("printshow2") .style.visibility="hidden"
document.getElementById("printshow1") .style.visibility="hidden"
document.getElementById("printshow3") .style.visibility="hidden"
document.getElementById("tableprint") .border="1"
print();
document.getElementById("printshow1") .style.visibility="visible"
document.getElementById("printshow2") .style.visibility="visible"
document.getElementById("printshow3") .style.visibility="visible"
document.getElementById("tableprint") .border="0"
}

function printpage8()
{
document.getElementById("printshow3") .style.visibility="hidden"
document.getElementById("printshow1") .style.visibility="hidden"
document.getElementById("printshow3") .style.visibility="hidden"
document.getElementById("tableprint") .border="1"
print();
document.getElementById("printshow1") .style.visibility="visible"
document.getElementById("printshow4") .style.visibility="visible"
document.getElementById("printshow3") .style.visibility="visible"
document.getElementById("tableprint") .border="0"
}

function printaa()
{
document.getElementById("printshow1") .style.visibility="hidden"
document.getElementById("printshow3") .style.visibility="hidden"
document.getElementById("tableprint") .border="1"
print();
document.getElementById("printshow1") .style.visibility="visible"
document.getElementById("printshow3") .style.visibility="visible"
document.getElementById("tableprint") .border="0"
}

function printKh()
{
document.getElementById("printshow1") .style.visibility="hidden"
document.getElementById("printshow3") .style.visibility="hidden"
print();
document.getElementById("printshow1") .style.visibility="visible"
document.getElementById("printshow3") .style.visibility="visible"
}

function changecolor(obj,color)
{
     e = event.srcElement
     if(e.checked==true)
     {
      e = e.parentElement
      e.style.background = "#C0C0FF"
     }
     else
     {
       e = e.parentElement
       e.style.background = color
     }
      
      
      
}





function checkAll()
{
	for(var i=0;i<document.form1.elements.length;i++)
	{
	
		document.form1.elements[i].checked=true;
	}
}

function fanAll()
{
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			document.form1.elements[i].checked=false;
		else
			document.form1.elements[i].checked=true;
	}
}





function delcheck()
{
	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
	
    if (window.confirm("你确认删除选中项吗？"))
    {
      showwait()

      return true;
    }
    else
    {
      return false;
    }
	
}

function sendfile()
{
	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
	
    if (window.confirm("你确认提交选中项吗？"))
    {
      showwait()

      return true;
    }
    else
    {
      return false;
    }
	
}


function Movecheck()
{
    if(document.getElementById('Realname').value=='')
    {
    alert('用户不能为空');
   
    return false;
    }	


	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
	
    if (window.confirm("你确认转移选中项到给用户["+document.getElementById('Realname').value+"]吗？"))
    {
      showwait()

      return true;
    }
    else
    {
      return false;
    }
	
}




function FolderMovecheck()
{

	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
	
    if (window.confirm("确认转移选中项吗？"))
    {
      showwait()

      return true;
    }
    else
    {
      return false;
    }
	
}





function gxcheck()
{
	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
	
    if (window.confirm("你确认共享选中项？"))
    {
      showwait()

      return true;
    }
    else
    {
      return false;
    }
	
}


function qxgxcheck()
{
	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
	
    if (window.confirm("你确认取消共享选中项？"))
    {
      showwait()

      return true;
    }
    else
    {
      return false;
    }
	
}


function hycheck()
{
	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{

	}
	else
	{
		alert('请至少选中一项，如果你想选择一项或者多项，请点击每行数据前的选择框即可');
		return false;
	}
	
    if (window.confirm("你确认还原选中项吗？"))
    {
      showwait()

      return true;
    }
    else
    {
      return false;
    }
	
}
















function updatecheck()
{
	var a=0
	for(var i=0;i<document.form1.elements.length;i++)
	{
		if(document.form1.elements[i].checked==true)
			{a=a+1}
		
	}
	
	if(a>0)
	{
        if(a>1)
	    {
	    alert('此项操作只能选择一项')
	    return false;
	    }
	    else
	    {
         showwait()
	    
	    }
    }
	else
	{
		alert('请选中一项，如果你想选择一项，请点击每行数据前的选择框即可');
		return false;
	}
	
}




function closeAlert(alertid)
{
    document.getElementById(alertid).outerHTML = '';
    closeCover();
}
function closeCover()
{
    if(document.getElementById('AlexCoverV1_0'))
    {
        document.getElementById('AlexCoverV1_0').style.display = 'none';
        DispalySelect(1);
    }
}
function showCover()
{
    //遮罩宽
    var sw = document.body.scrollWidth;
    //遮罩高
    var sh = document.body.scrollHeight;
    if(document.getElementById('AlexCoverV1_0'))
    {
        DispalySelect(0);
        document.getElementById('AlexCoverV1_0').style.display = 'block';
    }
    else
    {
        DispalySelect(0);
        var div = document.createElement("div");
        div.id="AlexCoverV1_0";
        div.style.position="absolute";
        div.style.top="0px";
        div.style.left="0px";
        div.style.height=sh+"px";
        div.style.width=sw+"px";
        div.style.background="#ffffff";
        div.style.filter="alpha(opacity=20)";
        document.body.appendChild(div);
    }
}

//显示和隐藏select控件
function DispalySelect(val)
{   
    var dispalyType;
   var arrdispalyType=["hidden","visible"];
   var arrObjSelect=document.getElementsByTagName("select");
   for (i=0;i<arrObjSelect.length;i++)
   {
     arrObjSelect[i].style.visibility=arrdispalyType[val];
   }
}



function UploadComplete()
{

    showCover();
    //控件宽
    var aw = 400;
    //控件高
    var ah = 80;
    //计算控件水平位置
    var al = (screen.width - aw)/2;
    //计算控件垂直位置
    var at = (screen.height - ah)/5;
    //内容管理
    var title = '';
    var icon = 'indi.gif';
    var cardID = '0';
    //输出提示框
    var div = document.createElement("div");
    div.id = "UploadChoose";
    div.innerHTML = '\
    <div style="background-color:#FFFFFF;position:absolute;top:'+at+'px;left:'+al+'px;width:'+aw+'px;height:'+ah+'px;border:2px solid #000000;text-align:center">\
        <div style="clear:both;background-color:#0099AA;line-height:25px;font-weight:bold;color:#FFFFFF;font-size:12px;padding-left:10px">'+title+'</div>\
        <div style="padding-top:30px;">\
        <div style="float:left;width:60px;padding-left:50px"><img src="/oaimg/'+icon+'" alert"Cardo" /></div>\
       <div style="float:left;width:180px;margin-top:13px;padding-left:0px"><b>数据加载中，请稍候...</b></div>\
    <div style="clear:both;text-align:center;margin-top:10px;padding-bottom:10px">\
            </div>\
        </div>\
    </div>';
    document.body.appendChild(div);

}

function closeAlert(alertid)
{
    document.getElementById(alertid).outerHTML = '';
    closeCover();
}


function fileadd(newname)
{

    if(newname=="")
    {
        alert('未找到转存文件');
    }
    else
    {
        var num=Math.random();
        window.showModalDialog("/fileaddall.aspx?tmp="+num+"&newname="+newname+"","window", "dialogWidth:500px;DialogHeight=400px;status:no;scroll=yes;help:no");         
        
       //window.open ("/fileaddall.aspx?newname="+newname+"", "_blank", "height=400, width=500,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=220,left=370")
    }
    
    
}

function opensend(str)
{
    var num=Math.random();
    loc_x=(screen.availWidth-700)/2;
    loc_y=(screen.availHeight-550)/2;
    window.open ("/CRMtable/PublicPage/SendMail.aspx?tmp="+num+"&mail="+str+"", "_blank", "height=560, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openplanfx(str)
{
    var num=Math.random();
    loc_x=(screen.availWidth-700)/2;
    loc_y=(screen.availHeight-550)/2;
    window.open ("myplanfx_list.aspx?tmp="+num+"&"+str+"", "_blank", "height=560, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkhxx(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerLogin.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkhxxgr(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxGr.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function sendmsg(str)
{
    var num=Math.random();
    window.showModalDialog("/CRMtable/PublicPage/SeadMessage.aspx?tmp="+num+"&sms="+str+"","window", "dialogWidth:600px;DialogHeight=480px;status:no;scroll=yes;help:no");         
}

function opencpxx(str)
{
//    var num=Math.random();
//          //控件宽
//    var aw = screen.width-500;
//    //控件高
//    var ah = screen.height-300;
//    
//    loc_x=(screen.availWidth-aw)/2;
//    loc_y=(screen.availHeight-ah)/2;
//    
//    window.open ("/CRMtable/PublicPage/ChangPinMx.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")

    var num=Math.random();
    window.showModalDialog("/CRMtable/PublicPage/ChangPinMx.aspx?tmp="+num+"&id="+str+"","window", "dialogWidth:750px;DialogHeight=680px;status:no;scroll=yes;help:no");  
}

function senduser(str)
{
    var num=Math.random();
    window.showModalDialog("/senduser.aspx?tmp="+num+"&user="+str+"","window", "dialogWidth:600px;DialogHeight=480px;status:no;scroll=yes;help:no");         
}

function openhtxx(str)
{
    var num=Math.random();
          //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/HTDD/HeTong/HeTongST.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openjfxx(str)
{
    var num=Math.random();
    loc_x=(screen.availWidth-700)/2;
    loc_y=(screen.availHeight-550)/2;
    window.open ("/CRMtable/HTDD/HeTongJF/AddDingDanMxJF.aspx?tmp="+num+"&id="+str+"", "_blank", "height=560, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openhkxx(str)
{
    var num=Math.random();
    loc_x=(screen.availWidth-700)/2;
    loc_y=(screen.availHeight-550)/2;
    window.open ("/CRMtable/HTDD/HuiKuanJL/AddHuiKuanJL.aspx?tmp="+num+"&id="+str+"", "_blank", "height=560, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openhkxxkp(str)
{
    var num=Math.random();
    loc_x=(screen.availWidth-700)/2;
    loc_y=(screen.availHeight-550)/2;
    window.open ("/CRMtable/HTDD/HuiKuanJL/AddHuiKuanJLKP.aspx?tmp="+num+"&id="+str+"", "_blank", "height=560, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkpxx(str)
{
    var num=Math.random();
    loc_x=(screen.availWidth-700)/2;
    loc_y=(screen.availHeight-550)/2;
    window.open ("/CRMtable/HTDD/KaiPiao/AddKaiPiao.aspx?tmp="+num+"&id="+str+"", "_blank", "height=560, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}


function openhtxxjk(str)
{
    var num=Math.random();
          //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/HTDD/Jiankong/HeTongST.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function opengysxx(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/GongYinShangMx.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function opengysxxS(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/GongYinShangMx_show.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function opencgxx(str)
{
    var num=Math.random();
          //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/CGGL/CaiGou/CaiGouST.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function opencgxxjk(str)
{
    var num=Math.random();
          //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/CGGL/Jiankong/CaiGouST.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openjfxx_cg(str)
{
    var num=Math.random();
    loc_x=(screen.availWidth-700)/2;
    loc_y=(screen.availHeight-550)/2;
    window.open ("/CRMtable/CGGL/CaiGouJF/AddCaiGouMxJF.aspx?tmp="+num+"&id="+str+"", "_blank", "height=560, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openfkxx(str)
{
    var num=Math.random();
    loc_x=(screen.availWidth-700)/2;
    loc_y=(screen.availHeight-550)/2;
    window.open ("/CRMtable/CGGL/FuKuanJL/AddFuKuanJL.aspx?tmp="+num+"&id="+str+"", "_blank", "height=560, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openfpxx(str)
{
    var num=Math.random();
    loc_x=(screen.availWidth-700)/2;
    loc_y=(screen.availHeight-550)/2;
    window.open ("/CRMtable/CGGL/Fapiao/AddFapiao.aspx?tmp="+num+"&id="+str+"", "_blank", "height=560, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openhkxxfp(str)
{
    var num=Math.random();
    loc_x=(screen.availWidth-700)/2;
    loc_y=(screen.availHeight-550)/2;
    window.open ("/CRMtable/CGGL/FuKuanJL/AddFuKuanJLKP.aspx?tmp="+num+"&id="+str+"", "_blank", "height=560, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}


function openkhxxtt_zd(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxTT_zd.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkhxxtt_kx(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxTT_kx.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}


function openkhxxtt_zdgr(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxTT_zdGr.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkhxxtt_kxgr(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxTT_kxGr.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkhxxgx_zd(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxGX_zd.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkhxxgx_kx(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxGX_kx.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkhxxgx_zdgr(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxGX_zdGr.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkhxxgx_kxgr(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxGX_kxGr.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}


//function openzhifu(str)
//{
//    var num=Math.random();
//    window.showModalDialog("/CRMtable/PublicPage/ZhifuCp.aspx?tmp="+num+"&id="+str+"","window", "dialogWidth:750px;DialogHeight=680px;status:no;scroll=yes;help:no");  
//}

function openkhhh(str)
{
    var num=Math.random();
    window.showModelessDialog("/CRMtable/KHFW/Kongzhitai/CustomerMx_zd.aspx?tmp="+num+"&id="+str+"","window", "dialogWidth:970px;DialogHeight=720px;status:no;scroll=yes;help:no");  
}

function openkhxxjk(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxJkLogin.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkhxxjkgr(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxJkGr.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkhxxhs(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxhs.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkhxxgh(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxGh.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openkhxxghgr(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/CRMtable/PublicPage/CustomerMxGhGr.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}

function openxm(str)
{
    var num=Math.random();
    //控件宽
    var aw = screen.width-300;
    //控件高
    var ah = screen.height-200;
    
    loc_x=(screen.availWidth-aw)/2;
    loc_y=(screen.availHeight-ah)/2;
    
    window.open ("/ProManage/ProjectView/View.aspx?tmp="+num+"&id="+str+"", "_blank", "height="+ah+", width="+aw+",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top="+loc_y+",left="+loc_x+"")
}//项目浏览

function tb_cal(lv_tb_id,cal)
{

  var mytable=document.getElementById(lv_tb_id);
  
  if(mytable.rows.length==1) return;
  if(cal)
  {
    var cal_array=cal.split("`"); 
    for(i=1;i<mytable.rows.length;i++)
    {
      for(k=0;k<cal_array.length-1;k++)
      {
        var cal_str=cal_array[k];
        if(cal_str=="")
          continue;
        for(j=0;j<mytable.rows[i].cells.length-1;j++)
        {
          cell_value=parseFloat(mytable.rows[i].cells[j].firstChild.value);
          cal_str=cal_str.replace("["+(j+1)+"]",cell_value);
        }
        mytable.rows[i].cells[k].firstChild.value=isNaN(eval(cal_str))?0:Math.round(parseFloat(eval(cal_str))*10000)/10000;
      }
    }
  }
}

function sum(name,output){
	var shits = document.getElementsByName(""+name+"");
	var cnt = 0;
	for(var i = 0; i < shits.length; i++){
	//	alert(shits[i].value);
		var str = shits[i].value.match(/[-+]?\d+/g);
		if(str != null)
			shits[i].value = str[0];	
		else{
	//		alert(x);
			shits[i].value = "";
		}
		if(!isNaN(shits[i].value) && shits[i].value != ""){

			cnt += parseFloat(shits[i].value);
		}
	}
	if(isNaN(cnt))cnt = 0;
	document.getElementById(""+output+"").value = cnt;
}

function aaa(){
    document.all.FramerControl1.ProtectDoc(1,2,"0x0xx0x0x0x");  
    document.all.FramerControl1.ShowRevisions(0);
    document.all.FramerControl1.SetTrackRevisions(0);
    document.all.FramerControl1.SetMenuDisplay(1);
}
         
var stmp = "";
function nst(t,str)
{
if(t.value==stmp) return;
if(isNaN(t.value))
{
alert("请输入数字");
}
else
{
var ms = t.value.replace(/[^\\d\\.]/g,"").replace(/(\\.\\d{2}).+$/,"$1").replace(/^0+([1-9])/,"$1").replace(/^0+$/,"0");
var ms = t.value;
var txt = ms.split(".");
while(/\\d{4}(,|$)/.test(txt[0]))
txt[0] = txt[0].replace(/(\\d)(\\d{3}(,|$))/,"$1,$2");
t.value = stmp = txt[0]+(txt.length>1?"."+txt[1]:"");
document.getElementById(''+str+'').value = number2num1(ms-0,t);
}
}
function number2num1(strg,obj)
{
var number = Math.round(strg*100)/100;
number = number.toString(10).split(".");
var a = number[0];
if (a.length > 12)
{
obj.value = obj.value.substring(0,12);
return "数值超出范围！支持的最大数值为 999999999999.99";
}
else
{
var e = "零壹贰叁肆伍陆柒捌玖";
var num1 = "";
var len = a.length-1;
for (var i=0 ; i<=len; i++)
num1 += e.charAt(parseInt(a.charAt(i))) + [["圆","万","亿"][Math.floor((len-i)/4)],"拾","佰","仟"][(len-i)%4];
if(number.length==2 && number[1]!="")
{
var a = number[1];
for (var i=0 ; i<a.length; i++)
num1 += e.charAt(parseInt(a.charAt(i))) + ["角","分"]; 
}
num1 = num1.replace(/零佰|零拾|零仟|零角/g,"零");
num1 = num1.replace(/零{2,}/g,"零");
num1 = num1.replace(/零(?=圆|万|亿)/g,"");
num1 = num1.replace(/亿万/,"亿");
num1 = num1.replace(/^圆零?/,"");
if(num1!="" && !/分$/.test(num1))
num1 += "整";
return num1;
}
}
