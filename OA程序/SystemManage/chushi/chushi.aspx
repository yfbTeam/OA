<%@ Page Language="C#" AutoEventWireup="true" Codebehind="chushi.aspx.cs" Inherits="xyoa.SystemManage.chushi.chushi" %>

<html>

<script>
function select_sound()
{
	sound=document.form1.Sound.value;
	if(sound!="0")
	{
	   str="<object  classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='#' width='0' height='0'><param name='movie' value='/sound/"+sound+"'><param name=quality value=high><embed src='/sound/"+sound+"' width='0' height='0' quality='autohigh' wmode='opaque' type='application/x-shockwave-flash' plugspace='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash'></embed></object>"
	   document.getElementById("sms_sound").innerHTML=str;
	}
}

function chknull()
{
    showwait();	
}  

</script>

<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow1">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            初始化设置
                                                        </td>
                                                        <td width="81%">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                                <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0" class="nexttop">
                                                    <tr>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <div id="printshow2">
                                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="17">
                                                &nbsp;</td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button" onclick="javascript:window.location='chushi.aspx';showwait();">
                                                                <font class="shadow_but">初始化设置</font></button>
                                                        </td>
                                                        <td style="height: 26px" align="right">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="center" class="newtd1" nowrap="nowrap" style="height: 17px" colspan="4">
                                                        <b>个性样式初始化</b>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        工作台背景：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Gongzuotai" runat="server" Width="100%">
                                                        </asp:DropDownList></td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        标题栏样式：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Biaotilan" runat="server" Width="100%">
                                                            <asp:ListItem Value="NewStyleLan">典雅蓝</asp:ListItem>
                                                            <asp:ListItem Value="NewStyleHui">典雅灰</asp:ListItem>
                                                            <asp:ListItem Value="NewStyleZi">典雅紫</asp:ListItem>
                                                            <asp:ListItem Value="NewStyleHong">典雅红</asp:ListItem>
                                                            <asp:ListItem Value="percss">清爽简洁</asp:ListItem>
                                                            <asp:ListItem Value="bluecss">蓝色经典</asp:ListItem>
                                                            <asp:ListItem Value="redcss">红色心韵</asp:ListItem>
                                                            <asp:ListItem Value="greencss">艳绿缘情</asp:ListItem>
                                                            <asp:ListItem Value="romanticcss">浪漫情怀</asp:ListItem>
                                                            <asp:ListItem Value="springcss">忆春思雨</asp:ListItem>
                                                            <asp:ListItem Value="wintercss">暖冬飘雪</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd1" nowrap="nowrap" style="height: 17px" colspan="4">
                                                        <b>标准样式初始化</b>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        界面及内页样式：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Yangshi" runat="server" Width="100%">
                                                            <asp:ListItem Value="NewStyleLan">典雅蓝</asp:ListItem>
                                                            <asp:ListItem Value="NewStyleHui">典雅灰</asp:ListItem>
                                                            <asp:ListItem Value="NewStyleZi">典雅紫</asp:ListItem>
                                                            <asp:ListItem Value="NewStyleHong">典雅红</asp:ListItem>
                                                            <asp:ListItem Value="percss">清爽简洁</asp:ListItem>
                                                            <asp:ListItem Value="bluecss">蓝色经典</asp:ListItem>
                                                            <asp:ListItem Value="redcss">红色心韵</asp:ListItem>
                                                            <asp:ListItem Value="greencss">艳绿缘情</asp:ListItem>
                                                            <asp:ListItem Value="romanticcss">浪漫情怀</asp:ListItem>
                                                            <asp:ListItem Value="springcss">忆春思雨</asp:ListItem>
                                                            <asp:ListItem Value="wintercss">暖冬飘雪</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        是否需要弹窗提醒：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="iftx" runat="server" Width="100%">
                                                            <asp:ListItem Value="1">是</asp:ListItem>
                                                            <asp:ListItem Value="0">否</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        提醒间歇时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="txtime" runat="server" Width="100%">
                                                            <asp:ListItem Value="10000">10秒</asp:ListItem>
                                                            <asp:ListItem Value="30000">30秒</asp:ListItem>
                                                            <asp:ListItem Value="60000">1分钟</asp:ListItem>
                                                            <asp:ListItem Value="300000">5分钟</asp:ListItem>
                                                            <asp:ListItem Value="600000">10分钟</asp:ListItem>
                                                            <asp:ListItem Value="900000">15分钟</asp:ListItem>
                                                            <asp:ListItem Value="1200000">20分钟</asp:ListItem>
                                                            <asp:ListItem Value="1500000">25分钟</asp:ListItem>
                                                            <asp:ListItem Value="1800000">30分钟</asp:ListItem>
                                                            <asp:ListItem Value="3600000">60分钟</asp:ListItem>
                                                            <asp:ListItem Value="5400000">90分钟</asp:ListItem>
                                                            <asp:ListItem Value="7200000">120分钟</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        系统提示音：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Sound" runat="server" Width="100%" onchange="select_sound()">
                                                            <asp:ListItem Value="1.swf">语音1</asp:ListItem>
                                                            <asp:ListItem Value="8.swf">语音2</asp:ListItem>
                                                            <asp:ListItem Value="2.swf">激光</asp:ListItem>
                                                            <asp:ListItem Value="3.swf">水滴</asp:ListItem>
                                                            <asp:ListItem Value="4.swf">手机</asp:ListItem>
                                                            <asp:ListItem Value="5.swf">电话</asp:ListItem>
                                                            <asp:ListItem Value="6.swf">鸡叫</asp:ListItem>
                                                            <asp:ListItem Value="7.swf">OICQ</asp:ListItem>
                                                            <asp:ListItem Value="0.swf">无</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        标准版工作台：</td>
                                                    <td class="newtd2" colspan="3" width="85%" style="height: 17px">
                                                        <asp:TextBox ID="Mokuai" runat="server" Height="58px" TextMode="MultiLine" Width="85%"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openunit();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            &nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <div align="right" id="sms_sound">
        </div>

        <script type="text/javascript">
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

        <asp:TextBox ID="MokuaiID" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	
          
            function  openunit()  
            {   
                var  wName_2;  
                var num=Math.random();
                var str=""+document.getElementById('MokuaiID').value+"";
                wName_2=window.showModalDialog("/OpenWindows/open_mokuai.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("MokuaiID").value=arr[0]; 
                    document.getElementById("Mokuai").value=arr[1]; 
                }
            }
            
        </script>

    </form>
</body>
</html>
