




function checkForm()
{

var strUploadFile=document.getElementById('uploadFile').value;

if (strUploadFile=="")
{
alert("��ʾ:\r����û��ѡ���ϴ����ļ���"); 
return false;


} 
var nameLen=strUploadFile.length;
var rightName=strUploadFile.substr(nameLen-4,4).toLowerCase();

var sAllowExt = "<%=Session["FjKey"]%>";
var str = document.getElementById('uploadFile').value;
var rightName=str.substr(str.lastIndexOf('.')+1,str.length - str.lastIndexOf('.')).toLowerCase();

if(sAllowExt.indexOf(rightName)==-1)
{
	alert('��ʽ���ԣ�ֻ���ϴ�'+sAllowExt+'\r����Ҫ�ϴ�������ʽ�ļ�������ϵ����Ա��');
	return false;
}


showwait();	



}




function  down()  
{
if(document.getElementById('fjlb').value=='')
{

alert('δѡ���ļ�');

return false;
}
else
{

var num=Math.random();
var littleproduct=document.getElementById("fjlb");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;

window.open ("../file_down.aspx?tmp="+num+"&number="+cValue+"", "_blank", "height=1, width=1,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}


}

function  delfj()  
{
if(document.getElementById('fjlb').value=='')
{

alert('δѡ���ļ�');
return false;
}
else
{
if (!confirm("�Ƿ�ȷ��Ҫɾ����"))
return false;

showwait();	
var num=Math.random();
var littleproduct=document.getElementById("fjlb");
var cindex = littleproduct.selectedIndex;
var cText  = littleproduct.options[cindex].text;
var cValue = littleproduct.options[cindex].value;

window.showModalDialog("../file_del.aspx?tmp="+num+"&number="+cValue+" ","window","dialogWidth:1000px;DialogHeight=600px;status:no;scroll=yes;help:no");                

}


}			



