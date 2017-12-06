//function search()
//{  
//    if(document.getElementById('SearchList').value=="1")
//    {
//       document.getElementById('searchdiv').style.display="";
//       document.getElementById('SearchList').value="0";
//    }
//    else
//    {
//       document.getElementById('searchdiv').style.display="none";
//       document.getElementById('SearchList').value="1";
//    }
//}

//function searchLoad()
//{  
//    if(document.getElementById('SearchList').value=="0")
//    {
//       document.getElementById('searchdiv').style.display="";
//    }
//    else
//    {
//       document.getElementById('searchdiv').style.display="none";
//    }
//}


function search()
{  
    if(document.getElementById('searchdiv').style.display=="none")
    {
       document.getElementById('searchdiv').style.display="";
    }
    else
    {
       document.getElementById('searchdiv').style.display="none";
    }
}

function chgColor(_this)
{ 
var perDiv=null;
    if(perDiv) 
    perDiv.style.backgroundColor=''; 
     _this.style.backgroundColor='#FFFF00'; 
      perDiv=_this;
}

function LoadingShow()
{
//  $("#overlay").show();
//  $(".ui-loader").show();   
}

function checkForm()
{
    var strUploadFile=document.getElementById('uploadFile').value;
    if (strUploadFile=="")
    {
        alert("您还没有选择上传的文件！"); 
        return false;
    } 
    LoadingShow();
}


function  delfj()  
{
    if(document.getElementById('fjlb').value=='')
    {
        alert('未选中文件');
        return false;
    }
    else
    {
        if (!confirm("是否确定要删除？"))
        return false;
        LoadingShow();
    }
}	

