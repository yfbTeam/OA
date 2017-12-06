<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Document_online.aspx.cs" Inherits="xyoa.PublicWork.WebDisk.Document_online" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <meta http-equiv="Pragma" content="no-cache">
    <meta http-equiv="Cache-Control" content="no-cache">
    <meta http-equiv="Expires" content="0">
    <base target="_self" />
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/js/ParametersOnClient.js"></script>

    <script>
			 //******************************************************************************************\\
			//code by qiupeng , you can copy code, but the author to retain information please;(2006-11-5)\\
		   //**********************************************************************************************\\


		function chknull()
		{
			document.all.FramerControl1.caption = "阅读：<%=ViewState["forname"]%>";
			var serverpath=window.location.host+v_online_path; 
			var num=Math.random();
			document.all.FramerControl1.Open("http://"+serverpath+"/<%=ViewState["forfile"]%>?tmp="+num+"", true);
		}              
             

         
    </script>

</head>
<body class="newbody" onload="chknull();">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="35">
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td height="22" align="left" style="font-size: 12px; font-family: 宋体">
                                            <font color="red">阅读：<%=ViewState["forname"]%></font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;提醒：如页面显示为“小红叉”不能正常在线编辑，<a
                                                href="/Down/RegOfficeOcx.rar" target="_blank">请先点击此处下载插件。</a></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="text-align: center">
                                            <table cellspacing="1" cellpadding="4" width="100%" bgcolor="#d8e1e8" border="0">
                                                <tr bgcolor="#f3f8fe">
                                                    <td align="center" style="height: 8px">
                                                        <object id="FramerControl1" codebase="dsoframer.ocx" height="650px" width="99%" classid="clsid:00460182-9E5E-11D5-B7C8-B8269041DD57">
                                                            <param name="_ExtentX" value="16960">
                                                            <param name="_ExtentY" value="13600">
                                                            <param name="BorderColor" value="-2147483632">
                                                            <param name="BackColor" value="-2147483643">
                                                            <param name="ForeColor" value="-2147483640">
                                                            <param name="TitlebarColor" value="-2147483635">
                                                            <param name="TitlebarTextColor" value="-2147483634">
                                                            <param name="BorderStyle" value="1">
                                                            <param name="Titlebar" value="0">
                                                            <param name="Toolbars" value="1">
                                                            <param name="Menubar" value="1">
                                                        </object>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
<SCRIPT>
setInterval("aaa()",1000);
</SCRIPT>
    </form>
</body>
</html>
