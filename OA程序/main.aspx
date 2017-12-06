<%@ Page Language="C#" AutoEventWireup="true" Codebehind="main.aspx.cs" Inherits="xyoa.main" %>

<html>
<head runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>

    <script>
		window.resizeTo(screen.availWidth, screen.availHeight);
		window.moveTo(0, 0);
    </script>

    <script src="js/public.js" type="text/javascript"></script>

    <script language="javascript">
    function visible_click()
    {
   
//        if(document.getElementById('Hidden1').value=="")
//        {
//            document.getElementById('td1').style.width="0%";
//            document.getElementById('td2').style.width="100%";
//            document.getElementById('Hidden1').value="left"
            form1.middle_picture.src="/oaimg/right.gif";
//        }
//        else if(document.getElementById('Hidden1').value=="left")
//        {
//            document.getElementById('Hidden1').value=""
//            document.getElementById('td1').style.width="19%";
//            document.getElementById('td2').style.width="81%";
//            form1.middle_picture.src="/oaimg/left.gif";
//        }

if(td1.className=="")
{

td1.className="tddisp";
form1.middle_picture.src="/oaimg/right.gif";

}
else
{
td1.className="";
form1.middle_picture.src="/oaimg/left.gif";
}
    }
    
    function zx()
    {
        if (!confirm("是否确定要注销？"))
        return false;
    }
        
function card()
{
    var num=Math.random();
    window.showModalDialog("SystemManage/anquan/card.aspx?tmp="+num+"","window","dialogWidth:600px;DialogHeight=450px;status:no;scroll=no;help:no");  
}

function openwindows()
{
   var num=Math.random();
   window.showModalDialog("help/help.aspx?tmp="+num+"","window","dialogWidth:600px;DialogHeight=490px;status:no;scroll=no;help:no");  
}

    </script>

    <script> 
var g_blinkswitch = 0; 
var g_blinktitle = document.title; 
function blinkNewMsg() 
{ 
if(document.getElementById('TextBox1').value=="tixing")
{
    document.title = g_blinkswitch % 2==0 ? "【　　　】 - " + g_blinktitle : "【新消息】 - " + g_blinktitle;
}
else
{
    document.title = "<%=Session["Titles"]%><%=ViewState["Geyan"] %>";
}
g_blinkswitch++; 
} 

setInterval(blinkNewMsg, 1000); 


function geturl(leixing,url)
{
if(leixing=='10')
{
    window.lhead.location.href='menu/'+url+'';
    window.rform.location.href='SystemManage/User/username.aspx';
}
else if(leixing=='25')
{
    window.lhead.location.href='menu/'+url+'';
    window.rform.location.href='SchTable/Xueji/ZaijiSheng/ZaijiSheng.aspx';
}
else if(leixing=='11')
{
    window.lhead.location.href='menu/'+url+'';
    window.rform.location.href='JqMain/Mymenhu.aspx?p=12&id=0';
}
else if(leixing=='12')
{
    window.lhead.location.href='menu/'+url+'';
    window.rform.location.href='JqMain/Mymenhu.aspx?p=12&id=0';
}
else if(leixing=='8')
{
    window.lhead.location.href='menu/'+url+'';
    window.rform.location.href='CRMtable/main.aspx';
}
else
{
    window.lhead.location.href='menu/'+url+'';
    window.rform.location.href='JqMain/menhu.aspx?id='+leixing+'';
}
}
    </script>

    <link href="<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="<%=Session["yangshi"]%>/css/menu.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Label3" runat="server" Visible="false"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Style="display: none"></asp:TextBox>
        <iframe marginwidth="0" marginheight="0" src="CountMessageNew.aspx" frameborder="0"
            width="0" height="0" scrolling="auto"></iframe>
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td height="94">
                                <table width="100%" height="63" border="0" cellpadding="0" cellspacing="0" class="bluetable">
                                    <tr>
                                        <td>
                                            <table width="100%" height="63" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td width="22%">
                                                        <img src="LoginBg/<%=ViewState["Logos"] %>"></td>
                                                    <td width="41%">
                                                      
                                                        <asp:Label ID="Label2" runat="server"></asp:Label>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="bluecss/topb7.gif" OnClick="ImageButton1_Click" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="40" align="right">
                                                        <font style="font-family: Georgia, sans-serif; background-color: #EEEEEE;">
                                                            <%=Session["realname"]%>
                                                            ：<%=ViewState["showtime"]%>
                                                            <span id="liveclock"></span>

                                                            <script language="javascript" type="text/javascript">                      
                                                function www_helpor_net()                      
                                                {                      
                                                var Digital=new Date()                      
                                                var hours=Digital.getHours()                      
                                                var minutes=Digital.getMinutes()                      
                                                var seconds=Digital.getSeconds()                      

                                                if(minutes<=9)                      
                                                minutes="0"+minutes                      
                                                if(seconds<=9)                      
                                                seconds="0"+seconds                      
                                                myclock=""+hours+":"+minutes+":"+seconds+""                      
                                                if(document.layers){document.layers.liveclock.document.write(myclock)                      
                                                document.layers.liveclock.document.close()                      
                                                }else if(document.all)                      
                                                liveclock.innerHTML=myclock                      
                                                setTimeout("www_helpor_net()",1000)                      
                                                }                      
                                                www_helpor_net();                      
                                                //-->                      
                                                            </script>

                                                        </font>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="bluetop">
                                <table width="100%" height="31" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="5">
                                        </td>
                                        <td width="2">
                                            <img src="bluecss/line.gif" width="2" height="20"></td>
                                        <td class="blueheadtr" width="1000">
                                            <asp:Label ID="url" runat="server" Text=""></asp:Label>
                                            <asp:Label ID="strhtml" runat="server"></asp:Label>
                                            <%=ViewState["Label4"] %>
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                            <input id="Hidden1" type="hidden" />
    </form>
</body>
</html>
