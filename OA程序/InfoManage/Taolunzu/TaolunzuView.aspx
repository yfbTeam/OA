<%@ Page Language="C#" AutoEventWireup="true" Codebehind="TaolunzuView.aspx.cs" Inherits="xyoa.InfoManage.Taolunzu.TaolunzuView" %>

<html xmlns="http://www.w3.org/1999/xhtml">

<script>
		
		function ifnull()
		{
			if(document.getElementById('content').value=='')
			{
			    alert('发送的内容不能为空');
			    Form1.content.focus();
			}
			else
			{
			    send();
			}
		}
		
		function send()
		{
		    window.Form1.btn_AddCity.value='发送中...';
		    window.Form1.btn_AddCity.disabled=true;
		    var ycontent=document.getElementById('content').value;
		    var ysChatNameId='<%=Request.QueryString["id"]%>';
		    AjaxMethod.AddTaolun(ycontent,ysChatNameId);
	        document.getElementById('content').value='';
		}
	
		function keydown()
		{
		 	if(event.keyCode==13)
		    {
			    if(document.getElementById('content').value=='')
			    {
			        alert('发送的内容不能为空');
			        Form1.content.focus();
			    }
			    else
			    {
			        send();
			    }
			}		
		}	
			
        function setuser(username,realname)
		{
		    document.getElementById('user').value=username;
		    document.getElementById('name').value=realname;
		}
			
	
			
        function face()
        {
            var  wName_1;  
            var num=Math.random();
            wName_1=window.showModalDialog("face.aspx","window", "dialogWidth:458px;DialogHeight=200px;status:no;scroll=yes;help:no");
            if(wName_1!='undefined')
            {
            
            document.getElementById("content").focus();
            var r = document.selection.createRange();
            document.selection.empty();
            r.text = wName_1;
             // document.getElementById('content').value+=wName_1
            }
        }
        
        function fujian()
        {
            var num=Math.random();
            window.showModalDialog("fujian.aspx?tmp="+num+"&KeyId=<%=Request.QueryString["id"]%>","window","dialogWidth:458px;DialogHeight=200px;status:no;scroll=no;help:no");  
        }		

        function openwindows(urlstr)
        {
            //控件宽
            var aw = 800;
            //控件高
            var ah = 540;
            //计算控件水平位置
            var al = (screen.width - aw)/2+100;
            //计算控件垂直位置
            var at = (screen.height - ah)/5;
            window.open(""+urlstr+"","_blank","height="+ah+",width="+aw+",top="+at+",left="+al+"");
        }	
        

</script>

<head id="Head1" runat="server">
    <title>
        <%=ViewState["ChatName"] %>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body>
    <form id="Form1" runat="server">
        <table width="100%" height="100%" border="0" align="center" cellpadding="0" cellspacing="1"
            bgcolor="#003B81">
            <tr>
                <td valign="top" bgcolor="#A2DEFF" height="29">
                    <table width="100%" height="29" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td background="/oaimg/lt1.jpg">
                                <b><font color="#ffffff">
                                    <img src="../../oaimg/menu/Choose55.gif" hspace="4" />讨论组：<%=ViewState["ChatName"]%></font></b></td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td valign="top" bgcolor="#A2DEFF" height="7">
                </td>
            </tr>
            <tr>
                <td valign="top" bgcolor="#A2DEFF">
                    <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td width="5">
                                &nbsp;
                            </td>
                            <td valign="top" bgcolor="#FFFFFF">
                                <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            <iframe name="rform" marginwidth="1" marginheight="1" src="SeadChat.aspx?id=<%=Request.QueryString["id"]%>"
                                                frameborder="0" width="99%" height="100%" bordercolor="#EDEDED"></iframe>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5" bgcolor="#A2DEFF">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="147" bgcolor="#FFFFFF">
                                            <table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td background="/oaimg/lt2.jpg">
                                                        <a href="javascript:void(0)">
                                                            <img src="/InfoManage/messages/b1.gif" border="0" hspace="4" onclick="face();"></a> <a href="javascript:void(0)">
                                                                <img src="/InfoManage/messages/b2.gif" border="0" onclick="fujian();"></a>
                                                    </td>
                                                    <td background="/oaimg/lt2.jpg" align="right">
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="是否需要提醒"  onclick="aaa()"/>
                                                        <a href='javascript:void(0)' onclick='openwindows("msglog.aspx?id=<%=Request.QueryString["id"]%>")'>
                                                            <img src="/InfoManage/messages/b5.gif" border="0" hspace="4"></a>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table width="100%" height="97" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td valign="top" align="center">
                                                        <asp:TextBox ID="content" runat="server" Height="95px" Width="100%" TextMode="MultiLine"
                                                            onkeydown="keydown()" MaxLength="500"></asp:TextBox></td>
                                                </tr>
                                            </table>
                                            <table width="100%" height="25" border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td background="/oaimg/lt3.jpg" align="right">
                                                        <input id="Button2" type="button" value="关 闭" onclick="window.close();" />&nbsp;
                                                        <input id="btn_AddCity" type="button" value="发 送" onclick="ifnull()" />
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="5">
                                &nbsp;
                            </td>
                            <td width="177" valign="top" bgcolor="#FFFFFF">
                                <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td background="/oaimg/lt2.jpg" height="25">
                                            <b><font color="#1A3761">&nbsp;讨论组成员</font></b></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <iframe name="lform" marginwidth="1" marginheight="1" src="SeadChatPeople.aspx?id=<%=Request.QueryString["id"]%>"
                                                frameborder="0" width="99%" height="100%" bordercolor="#EDEDED"></iframe>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="6">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
        <script>
            function aaa()
            {   
                if(document.getElementById('CheckBox1').checked)
                {
                     var ysChatNameId='<%=Request.QueryString["id"]%>';
		             AjaxMethod.UpdateTixing('1',ysChatNameId);
                }
                else
                {
                     var ysChatNameId='<%=Request.QueryString["id"]%>';
		             AjaxMethod.UpdateTixing('0',ysChatNameId);
                }
            }
        </script>
</body>
</html>
