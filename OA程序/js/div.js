//�����س���Ա�Ͷ��ɹ�������Ҫ��������,����ϵ������13002355133������ʹ�õ��棬�����˲���ʧ
var  wDiyFrom;  
function  OpenRyXzFrom(divname)  
{  
    var num=Math.random();
    var str=document.getElementById(divname).value;
    wDiyFrom=window.showModalDialog("/OpenWindows/open_div_user.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:770px;DialogHeight=680px;status:no;scroll=yes;help:no");               
    if(wDiyFrom!=null && wDiyFrom!= "undefined")
    {
    document.getElementById(divname).value+=wDiyFrom; 
    }

}//ѡ����Ա

var  wDiyFromdx;  
function  OpenBmXzFrom(divname)  
{  

    var num=Math.random();
    var str=document.getElementById(divname).value;
    wDiyFromdx=window.showModalDialog("/OpenWindows/open_div_bm.aspx?tmp="+num+"","window", "dialogWidth:600px;DialogHeight=680px;status:no;scroll=yes;help:no");               
    if(wDiyFromdx!=null && wDiyFromdx!= "undefined")
    {
    document.getElementById(divname).value+=""+wDiyFromdx+""; 
    }

}//ѡ����

var  OpenZwXzFrom;  
function  OpenZwXzFrom(divname)  
{  

    var num=Math.random();
    var str=document.getElementById(divname).value;
    wDiyFrombm=window.showModalDialog("/OpenWindows/open_div_zw.aspx?tmp="+num+"","window", "dialogWidth:600px;DialogHeight=680px;status:no;scroll=yes;help:no");               
    if(wDiyFrombm!=null && wDiyFrombm!= "undefined")
    {
    document.getElementById(divname).value+=""+wDiyFrombm+""; 
    }
}//ѡ��ְλ

var  OpenJsXzFrom;  
function  OpenJsXzFrom(divname)  
{  
    var num=Math.random();
    var str=document.getElementById(divname).value;
    wDiyFrombmdx=window.showModalDialog("/OpenWindows/open_div_js.aspx?tmp="+num+"","window", "dialogWidth:600px;DialogHeight=680px;status:no;scroll=yes;help:no");               
    if(wDiyFrombmdx!=null && wDiyFrombmdx!= "undefined")
    {
    document.getElementById(divname).value+=""+wDiyFrombmdx+""; 
    }
}//ѡ���ɫ


var  OpenJbrXzFrom;  
function  OpenJbrXzFrom(divname)  
{  

    var num=Math.random();
    var str=document.getElementById(divname).value;
    wDiyFromdxjtld=window.showModalDialog("/OpenWindows/open_div_jbr.aspx?tmp="+num+"&key=1","window", "dialogWidth:600px;DialogHeight=680px;status:no;scroll=yes;help:no");               
    if(wDiyFromdxjtld!=null && wDiyFromdxjtld!= "undefined")
    {
    document.getElementById(divname).value+=""+wDiyFromdxjtld+""; 
    }

}//�Ѿ�����
