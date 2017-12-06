<%@ Page Language="C#" AutoEventWireup="true" Codebehind="talk.aspx.cs" Inherits="xyoa.InfoManage.messages.talk" %>

<html>
<head runat="server">
    <title>与&nbsp;<%=ViewState["Realname"] %>&nbsp;交谈中 </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script>
		function ifnull()
		{
			if(document.getElementById('content').value=='')
			{
			    alert('发送内容不能为空');
			    form1.content.focus();
			}
			else
			{
			    send();
			}
		}
		
		
		function send()
		{
		    window.form1.btn_AddCity.value='发送中...';
		    window.form1.btn_AddCity.disabled=true;
    		
		 
		    var ycontent=document.getElementById('content').value;
		    var ysuser='<%=Request.QueryString["user"]%>';
		    var ysname='<%=ViewState["Realname"] %>';
		   
    		
		    AjaxMethod.talkmessage(ycontent,ysuser,ysname);
    		
	        document.getElementById('content').value='';
	        setTimeout("rform.scrolldowm()","2000");
		}
		
		
		function del()
		{ 
		    var ysuser='<%=Request.QueryString["user"]%>';
		    AjaxMethod.delmessage(ysuser);
		    window.rform.document.getElementById('show').style.display=''
		}
		
		
		
		function keydown()
		{
		 	if(event.keyCode==13&&event.ctrlKey)
		    {
			    if(document.getElementById('content').value=='')
			    {
			        alert('发送的内容不能为空');
			        form1.content.focus();
			    }
			    else
			    {
			        send();
			        
			    }
			}		
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
            window.open(""+urlstr+"","_blank","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
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
            window.showModalDialog("fujian.aspx?tmp="+num+"&user=<%=Request.QueryString["user"]%>","window","dialogWidth:458px;DialogHeight=200px;status:no;scroll=no;help:no");  
        }
        
        window.setInterval("AjaxMethod.GetchatWd(get_chatwb)",2000);
		function get_chatwb(response)
		{
			if (response.value != null)
			{
			  var ds = response.value;
			  if(ds.Tables[0].Rows.length>0)
			  {
			    setTimeout("rform.scrolldowm()","1200");
			  }
			}
		}
        
    </script>

</head>
<body>
    <form id="form1" runat="server">
      <table width="100%" height="100%" border="0" align="center" cellpadding="0" cellspacing="1"
            bgcolor="#003B81">
            <tr>
                <td valign="top" bgcolor="#A2DEFF" height="29">
                    <table width="100%" height="29" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td background="/oaimg/lt1.jpg">
                                <b><font color="#ffffff">
                                    <img src="../../oaimg/menu/Choose55.gif" hspace="4" />与&nbsp;<%=ViewState["Realname"] %>&nbsp;交谈中</font></b></td>
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
                                            <iframe name="rform" marginwidth="1" marginheight="1" src="SeadChat.aspx?user=<%=Request.QueryString["user"]%>"
                                                frameborder="0" width="100%" height="100%" bordercolor="#EDEDED"></iframe>
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
                                                            <img src="b1.gif" border="0" hspace="4" onclick="face();"></a> <a href="javascript:void(0)">
                                                                <img src="b2.gif" border="0" onclick="fujian();"></a> <a href="javascript:void(0)">
                                                                    <img src="b4.gif" border="0" onclick="del();"></a>
                                                    </td>
                                                    <td background="/oaimg/lt2.jpg" align="right">
                                                        <a href='javascript:void(0)' onclick='openwindows("/mainpage/msg.aspx?user=<%=Request.QueryString["user"]%>")'>
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
                                            <b><font color="#1A3761">&nbsp;<%=ViewState["Realname"] %>的个人资料</font></b></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="line-height: 215%">
                                            部门名称：<asp:Label ID="Unit" runat="server"></asp:Label><br>
                                            职位：<asp:Label ID="Post" runat="server"></asp:Label>
                                            <br>
                                            在线：<asp:Label ID="Zaixian" runat="server"></asp:Label>
                                            <br>
                                            工号：<asp:Label ID="Worknum" runat="server"></asp:Label>
                                            <br>
                                            性别：<asp:Label ID="Sex" runat="server"></asp:Label><br>
                                            生日：<asp:Label ID="Bothday" runat="server"></asp:Label><br>
                                            单位电话：<asp:Label ID="Tel" runat="server"></asp:Label><br>
                                            单位传真：<asp:Label ID="Fax" runat="server"></asp:Label><br>
                                            手机：<asp:Label ID="MoveTel" runat="server"></asp:Label><br>
                                            备用电话：<asp:Label ID="LittleTel" runat="server"></asp:Label><br>
                                            电子邮件：<asp:Label ID="Email" runat="server"></asp:Label><br>
                                            QQ号码：<asp:Label ID="QQNum" runat="server"></asp:Label><br>
                                            MSN：<asp:Label ID="Msn" runat="server"></asp:Label><br>
                                            ICQ号码：<asp:Label ID="ICQ" runat="server"></asp:Label><br>
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
    <script language="javascript">
            AjaxMethod.GetchatWd(get_chatwb);
    </script>
</body>
</html>
