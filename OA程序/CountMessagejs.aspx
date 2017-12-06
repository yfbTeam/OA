<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CountMessagejs.aspx.cs"
    Inherits="xyoa.CountMessagejs" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">

    <script language="javascript">

function sms_mon()
{
  document.getElementById("new_sms").innerHTML="<a href='javascript:void(0)' onclick='javascript:show_sms();' title='点击查看短信'><img src='/oaimg/menu/xx.gif'border=0 height=16><font color=#ffffff>新短消息</font></a><object id='sms_sound' classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0' width='0' height='0'><param name='movie' value='/sound/<%=Sound %>'><param name=quality value=high><embed id='sms_sound' src='/sound/<%=Sound%>' width='0' height='0' quality='autohigh' wmode='opaque' type='application/x-shockwave-flash' plugspace='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash'></embed></object>";
}

function sms_no()
{
  document.getElementById("new_sms").innerHTML="<a href='javascript:void(0)' onclick='javascript:show_sms();' title='点击查看短信'><img src='/oaimg/menu/xx.gif'border=0 height=16><font color=#ffffff>新短消息</font></a><object id='sms_sound' classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0' width='0' height='0'><param name='movie' value='/sound/<%=Sound %>'><param name=quality value=high><embed id='sms_sound' src='/sound/<%=Sound%>' width='0' height='0' quality='autohigh' wmode='opaque' type='application/x-shockwave-flash' plugspace='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash'></embed></object>";
}

function show_sms()
{
   mytop=screen.availHeight-305;
   myleft=0;
   var num=Math.random();
   window.open("SmsOpen.aspx?tmp="+num+"","tixing","height=235,width=370,status=0,toolbar=no,menubar=no,location=no,scrollbars=yes,top="+mytop+",left="+myleft+",resizable=yes");
}


function gourl()
{
    window.parent.rform.location.href='/InfoManage/messages/Messages.aspx';
}

function hfurl(suser_table,sname_table)
{
    window.parent.rform.location.href='/InfoManage/messages/Messages_add.aspx?user='+suser_table+'&name='+sname_table+'';
}



function sms_mon1()
{
  document.getElementById("new_sms").innerHTML="<a href='javascript:void(0)' onclick='javascript:show_sms();' title='点击查看短信'><img src='/oaimg/menu/xx.gif'border=0 height=16><font color=#ffffff>新短消息</font></a>";
}

function sms_no1()
{
  document.getElementById("new_sms").innerHTML="<a href='javascript:void(0)' onclick='javascript:show_sms();' title='点击查看短信'><img src='/oaimg/menu/xx.gif'border=0 height=16><font color=#ffffff>新短消息</font></a>";
}

    </script>

    <script>

			function send_request(url)
			{
				http_request=false;
				if(window.XMLHttpRequest)//Mozilla 浏览器
				{
					http_request=new XMLHttpRequest();
					if(http_request.overrideMimeType)//设置MiME类别
					{
						http_request.overrideMimeType("text/xml");
					}
				}
				else if(window.ActiveXObject)// IE浏览器
				{
					try
					{
						http_request=new ActiveXObject("Msxml2.XMLHTTP");
					}
					catch(e)
					{
						try
						{
							http_request=new ActivexObject("Microsoft.XMLHTTP");
						}
						catch(e)
						{}
					}
				}
				if(!http_request)// 异常，创建对象实例失败
				{
				    content.innerHTML="不能创建XMLHttpRequest对象实例";
					//window.alert("不能创建XMLHttpRequest对象实例");
					return false;
				}
				//指定服务器返回信息时处理程序
				http_request.onreadystatechange=processRequest;
				// 确定发送请求的方式和URL以及是否同步执行下段代码
				http_request.open("GET",url,true);
				http_request.send(null);
			}
			
			
			
			function processRequest()
			{
				if(http_request.readyState==4)
				{					
					if(http_request.status==200)
					{						
					
					    if(http_request.responseText=='1')
					    {  
					    
					        window.parent.document.getElementById('TextBox1').value="tixing";
					    
					        if('<%=iftx%>'=='1')
                            {
                               show_sms();
                               sms_mon1();
                               
                            }
                            else
                            {
                              //document.getElementById("new_sms").innerHTML="";
                               sms_no1();
                            }
					    }
					    else
					    {
					       // window.parent.location = 'default.aspx'
					        new_sms.innerHTML="";
					        window.parent.document.getElementById('TextBox1').value="111";
					    }
					}
				}
			}
			
		
		  window.setInterval("send_request('CountMessage.aspx?tmp='+Math.random())",<%=txtime%>);
    	
    </script>



  <script>

			function send_request1(url)
			{
				http_request=false;
				if(window.XMLHttpRequest)//Mozilla 浏览器
				{
					http_request=new XMLHttpRequest();
					if(http_request.overrideMimeType)//设置MiME类别
					{
						http_request.overrideMimeType("text/xml");
					}
				}
				else if(window.ActiveXObject)// IE浏览器
				{
					try
					{
						http_request=new ActiveXObject("Msxml2.XMLHTTP");
					}
					catch(e)
					{
						try
						{
							http_request=new ActivexObject("Microsoft.XMLHTTP");
						}
						catch(e)
						{}
					}
				}
				if(!http_request)// 异常，创建对象实例失败
				{
				    content.innerHTML="不能创建XMLHttpRequest对象实例";
					//window.alert("不能创建XMLHttpRequest对象实例");
					return false;
				}
				//指定服务器返回信息时处理程序
				http_request.onreadystatechange=processRequest1;
				// 确定发送请求的方式和URL以及是否同步执行下段代码
				http_request.open("GET",url,true);
				http_request.send(null);
			}
			
			
			
			function processRequest1()
			{
				if(http_request.readyState==4)
				{					
					if(http_request.status==200)
					{						
					
					    if(http_request.responseText=='1')
					    {  
					    
					        window.parent.document.getElementById('TextBox1').value="tixing";
					    
					        if('<%=iftx%>'=='1')
                            {
                               sms_mon();
                               
                            }
                            else
                            {
                               sms_no();
                            }
					    }
					    else
					    {

					        new_sms.innerHTML="";
					        window.parent.document.getElementById('TextBox1').value="111";
					    }
					}
				}
			}
    	
    </script>
</head>
<body class="bluetail">
    <form id="form1" runat="server">
        <div>
            <span id="new_sms"></span>

            <script>send_request('CountMessage.aspx?tmp='+Math.random());</script>

        </div>
    </form>
</body>
</html>
