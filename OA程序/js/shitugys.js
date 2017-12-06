
//－－－－－－－联系人－－－－－－－－－－
function AddLxr(str)
{
    var num=Math.random();
    window.showModalDialog("/CRMtable/PublicPage/GysLxr_add.aspx?tmp="+num+"&id="+str+"","window", "dialogWidth:720px;DialogHeight=660px;status:no;scroll=yes;help:no");       
}

function ShowLxr1(str)
{
    var num=Math.random();
    window.showModalDialog("/CRMtable/PublicPage/GysLxr_show1.aspx?tmp="+num+"&id="+str+"","window", "dialogWidth:720px;DialogHeight=560px;status:no;scroll=yes;help:no");       
}

function ShowLxr(str)
{
    var num=Math.random();
    window.showModalDialog("/CRMtable/PublicPage/GysLxr_show.aspx?tmp="+num+"&id="+str+"","window", "dialogWidth:720px;DialogHeight=660px;status:no;scroll=yes;help:no");       
}


//－－－－－－－合同信息－－－－－－－－－－

//function AddHtxx(str)
//{
//    var num=Math.random();
//    window.showModalDialog("/CRMtable/PublicPage/Dingdan_add.aspx?tmp="+num+"&id="+str+"","window", "dialogWidth:950px;DialogHeight=720px;status:no;scroll=yes;help:no");       
//}

function ShowHtxx(str)
{
    var num=Math.random();
    window.showModalDialog("/CRMtable/PublicPage/CaiGouST.aspx?tmp="+num+"&id="+str+"","window", "dialogWidth:950px;DialogHeight=720px;status:no;scroll=yes;help:no");       
}

function ShowHtxx1(str)
{
    var num=Math.random();
    window.showModalDialog("/CRMtable/PublicPage/CaiGouST.aspx?tmp="+num+"&id="+str+"","window", "dialogWidth:950px;DialogHeight:720px;status:no;scroll=yes;help:no");       
}
