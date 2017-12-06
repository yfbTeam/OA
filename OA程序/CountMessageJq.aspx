<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CountMessageJq.aspx.cs" Inherits="xyoa.CountMessageJq" %>

<html>
<head id="Head1" runat="server">
    <title></title>

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
					    }
					    else
					    {
					        new_sms.innerHTML="";
					        window.parent.document.getElementById('TextBox1').value="111";
					    }
					}
				}
			}
			
		
		  window.setInterval("send_request('CountMessage.aspx?tmp='+Math.random())",<%=txtime%>);
    	
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
