<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="officeonline.aspx.cs" Inherits="xyoa.officeonline" %>
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
			document.all.FramerControl1.caption = "在线编辑：<%=ViewState["forname"]%>";
			var serverpath=window.location.host+v_online_path; 
			var num=Math.random();
			var aaa="http://"+serverpath+"/<%=ViewState["forfile"]%>?tmp="+num+"";
			alert(aaa);
			document.all.FramerControl1.Open("http://"+serverpath+"/<%=ViewState["forfile"]%>?tmp="+num+"", true);
		}              
 
        function SaveToWeb()
        {
          showwait();	
			document.all.FramerControl1.SetTrackRevisions(0);
            var serverpath=window.location.host+v_online_path; 
            document.all.FramerControl1.HttpInit();
            document.all.FramerControl1.HttpAddPostString("RecordID","200601022");
            document.all.FramerControl1.HttpAddPostString("UserID","李局长");
            document.all.FramerControl1.HttpAddPostCurrFile("FileData", "bbb.doc");
              
           document.all.FramerControl1.HttpPost("http://"+serverpath+"/Document_online_save.aspx?file=<%=ViewState["forfile"]%>&number=<%=ViewState["number"]%>&forname=<%=ViewState["forname"]%>");
        } 
        
        function Track(){
            document.all.FramerControl1.SetTrackRevisions(1);
			document.all.FramerControl1.SetCurrUserName("<%=ViewState["realname"]%>");	
        }
        function UnTrack(){
            document.all.FramerControl1.SetTrackRevisions(0);
          
        }

        function print(){
        document.all.FramerControl1.PrintOut();
           
         }
         function printview(){
        
        document.all.FramerControl1.PrintPreview();
           
         }
         function printviewexit(){
        
        document.all.FramerControl1.PrintPreviewExit();
           
         }

        
        function clearTrack(){
           document.all.FramerControl1.SetTrackRevisions(4);
        }	
        
		 function OpenToWeb()
		 {
		 
			if (document.getElementById('DropDownList1').value=="请选择")
			{
				alert("请先选择红头文件！"); 
				return(false); 
			} 
			else
			{
			    if (!confirm("插入红头文件到光标停留处？"))
                return false;
                
				var openurl = document.getElementById('DropDownList1').value; 
				var serverpath=window.location.host+v_online_path; 
				
				document.all.FramerControl1.InSertFile("http://"+serverpath+"/SystemManage/DocumentModle/file/"+openurl+"",0);
			}
		
    
		 }        
        
 
        function openyz()
        {
            //控件宽
            var aw = 420;
            //控件高
            var ah = 320;
            //计算控件水平位置
            var al = (screen.width - aw)/2-100;
            //计算控件垂直位置
            var at = (screen.height - ah)/5;
            
            mytop=screen.availHeight-500;
            myleft=200;
            window.open("/WorkFlow/WorkFlowListSpYz.aspx?Number=<%=ViewState["number"]%>&NodeName=<%=Request.QueryString["NodeName"] %>","online","height="+ah+",width="+aw+",status=0,toolbar=no,menubar=no,location=no,top="+at+",left="+al+",resizable=yes");
       
        }
        
        function OpenSealToWeb(name){
           var serverpath=window.location.host+v_online_path; 
           document.all.FramerControl1.InSertFile("http://"+serverpath+"/seal/"+name+"",8);
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
                                            <font color="red">在线编辑：<%=ViewState["forname"]%></font>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;提醒：如页面显示为“小红叉”不能正常在线编辑，<a
                                                href="/Down/RegOfficeOcx.rar" target="_blank">请先点击此处下载插件。</a></td>
                                    </tr>
                                    <tr>
                                        <td valign="top" style="text-align: center">
                                            <table height="26" cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td>
                                                        <input style="width: 84px" onclick="openyz()" type="button" value="我的印章" id="Button10"
                                                            runat="server">
                                                        <input style="width: 100px" onclick="Track()" type="button" value="进入留痕" id="Button8"
                                                            runat="server">
                                                        <input style="width: 100px" type="button" value="打印文档" id="Button6" language="javascript"
                                                            onclick="return print()" size="" runat="server">
                                                        <input type="button" value="插入红头文件" onclick="OpenToWeb()" style="width: 100px;" id="Button3"
                                                            runat="server">
                                                        <asp:DropDownList ID="DropDownList1" runat="server" Width="208px">
                                                        </asp:DropDownList></td>
                                                </tr>
                                            </table>
                                            <table cellspacing="1" cellpadding="4" width="100%" bgcolor="#d8e1e8" border="0">
                                                <tr bgcolor="#f3f8fe">
                                                    <td align="center" style="height: 8px">
                                                        <object id="FramerControl1" codebase="dsoframer.ocx" height="600px" width="99%" classid="clsid:00460182-9E5E-11D5-B7C8-B8269041DD57">
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
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td width="39%">
                                                        </td>
                                                    <td width="9%">
                                                        <asp:Button ID="Button1" runat="server" Text="提　交" OnClick="Button1_Click" />
                                                    </td>
                                                    <td width="52%">
                                                        <input id="Button2" type="button" value="关　闭" onclick="window.close()" /></td>
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
    </form>
</body>
</html>