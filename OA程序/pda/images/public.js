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
        alert("����û��ѡ���ϴ����ļ���"); 
        return false;
    } 
    LoadingShow();
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
        LoadingShow();
    }
}	

