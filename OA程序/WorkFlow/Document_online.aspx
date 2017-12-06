<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Document_online.aspx.cs"
    Inherits="xyoa.WorkFlow.Document_online" %>

<html>
<head>
    <title>编辑文件 </title>
    <meta name="GENERATOR" content="Microsoft Visual Studio 7.0">
    <meta name="CODE_LANGUAGE" content="C#">
    <meta name="vs_defaultClientScript" content="JavaScript">
    <meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
    <style type="text/css"> 
    BODY {
	BACKGROUND-COLOR: #ffffff; MARGIN: 0px; BACKGROUND-REPEAT: repeat; FONT-FAMILY: "宋体",Arial, Helvetica, sans-serif; BACKGROUND-POSITION: left top; FONT-SIZE: 12px
}
TD {
	FONT-SIZE: 12px
}
    BUTTON.op { BORDER-RIGHT: #eeeeee 1px solid; BORDER-TOP: #eeeeee 1px solid; BORDER-LEFT: #eeeeee 1px solid; WIDTH: 120px; CURSOR: hand; BORDER-BOTTOM: #eeeeee 1px solid; BACKGROUND-COLOR: #9dc2db }
    
     </style>

    <script>
function killErrors() {
return true;
}
window.onerror = killErrors;	

    
        function chknull()
        {
            TANGER_OCX_OpenDoc("<% = URL %>");
            //TANGER_OCX_OBJ.SetReadOnly(true,'',1);
        }  
        
        
		 function OpenToWeb()
		 {
			if (document.getElementById('redHeadTemplateFile').value=="")
			{
				return(false); 
			} 
			else
			{
				var openurl = document.getElementById('redHeadTemplateFile').value; 
				try{
				TANGER_OCX_OBJ.ActiveDocument.Application.Selection.HomeKey(6);
				}
				catch(err)
				{};
				TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);TANGER_OCX_SetMarkModify(false);TANGER_OCX_OBJ.focus();
				InsertDocFromURL('/hongtou/'+openurl+'');
				TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);TANGER_OCX_SetMarkModify(true);TANGER_OCX_OBJ.focus();
				shuqian();
			}
		 }  
        
         function shuqian()
         {
        
                var doc = TANGER_OCX_OBJ.ActiveDocument;
                TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);TANGER_OCX_SetMarkModify(false);TANGER_OCX_OBJ.focus();
                <% = shuqian %>
                TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);TANGER_OCX_SetMarkModify(true);TANGER_OCX_OBJ.focus();
        

         }  
        
		 function Openyz()
		 {
		 
			if (document.getElementById('ReadSeal').value=="")
			{
				alert("请先选择印章！"); 
				return(false); 
			} 
			else
			{
				var openurl = document.getElementById('ReadSeal').value; 
				//TANGER_OCX_OBJ.SetReadOnly(false,'',1);
				//TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);TANGER_OCX_SetMarkModify(false);TANGER_OCX_OBJ.focus();
				AddPictureFromURL('/seal/'+openurl+'',true,0,0,1,100,1);
				//TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);TANGER_OCX_SetMarkModify(true);TANGER_OCX_OBJ.focus();
			}
		 }  
		 
		 
var TANGER_OCX_bDocOpen = false;
var TANGER_OCX_filename;
var TANGER_OCX_actionURL; //For auto generate form fiields
var TANGER_OCX_OBJ; //The Control
var TANGER_OCX_Username="<% = Session["realname"] %>";

//function SetUsername(URL)
//{
//    var TANGER_OCX_Username=URL;
//}
// alert(TANGER_OCX_Username);
 
 
 
//Open Document From URL
function TANGER_OCX_OpenDoc(URL)
{
	TANGER_OCX_OBJ = document.all.item("TANGER_OCX");
	if( (typeof(URL) != "undefined") && (URL != "") )
	{	
		try{TANGER_OCX_OBJ.BeginOpenFromURL(URL);}catch(err){};
	}
	else
	{
		try{TANGER_OCX_OBJ.BeginOpenFromURL("default.doc");}catch(err){};
	}
	
}
function TANGER_OCX_SaveEditToServerDatabase()
{
	if(!TANGER_OCX_bDocOpen)
	{
		alert("No document opened now.");
		return;
	}	
	TANGER_OCX_filename = document.all.item("filename").value;
	if ( (typeof(TANGER_OCX_filename) == "undefined")||(!TANGER_OCX_filename) || (strtrim(TANGER_OCX_filename)==""))
	{
		alert("You must input a file name.");
		return;
	}
	var newwin,newdoc;
	try
	{
	 	if(!TANGER_OCX_doFormOnSubmit())return; //we may do onsubmit first
	 	//call SaveToURL with other form data
		var retHTML = TANGER_OCX_OBJ.SaveToURL
		(
			document.forms[0].action,  
			"EDITFILE",	
			"", //other params seperrated by '&'. For example:myname=tanger&hisname=tom
			TANGER_OCX_filename, //filename
			"myForm" //submit myForm's data with document data
		); //this function returns dta from server
		//open a new window to show the returned data
		newwin = window.open("","_blank","left=200,top=200,width=400,height=300,status=0,toolbar=0,menubar=0,location=0,scrollbars=1,resizable=1",false);
		newdoc = newwin.document;
		newdoc.open();
		newdoc.write("<html><head><title>Data returned from server:</title></head><body><center><hr>")
		newdoc.write(retHTML+"<hr>");
		newdoc.write("<input type=button VALUE='Close Window' onclick='window.close()'>");
		newdoc.write('</center></body></html>');
		newdoc.close();
//		if(window.opener) 
//		{
//			window.opener.location.reload();
//		}
		window.close();
	}
	catch(err){
		alert("err:" + err.number + ":" + err.description);
	}
	finally{
	}
}
function TANGER_OCX_SaveEditToServerDisk()
{
	if(!TANGER_OCX_bDocOpen)
	{
		alert("No document opened now.");
		return;
	}	
	TANGER_OCX_filename = document.all.item("filename").value;
	if ( (typeof(TANGER_OCX_filename) == "undefined")||(!TANGER_OCX_filename) || (strtrim(TANGER_OCX_filename)==""))
	{
		alert("You must input a file name.");
		return;
	}
	var newwin,newdoc;
	try
	{
	 	if(!TANGER_OCX_doFormOnSubmit())return; //we may do onsubmit first
	 	//call SaveToURL WITOUT other form data
		var retHTML = TANGER_OCX_OBJ.SaveToURL
		(
			"uploaddisk.aspx",  
			"EDITFILE",	
			"", //other params seperrated by '&'. For example:myname=tanger&hisname=tom
			TANGER_OCX_filename //filename
		); 
	
//		newwin = window.open("","_blank","left=200,top=200,width=400,height=300,status=0,toolbar=0,menubar=0,location=0,scrollbars=1,resizable=1",false);
//		newdoc = newwin.document;
//		newdoc.open();
//		newdoc.write("<html><head><title>服务器返回信息:</title></head><body><center><hr>")
//		newdoc.write(retHTML+"<hr>");
//		newdoc.write("<input type=button VALUE='关闭窗口' onclick='window.close()'>");
//		newdoc.write('</center></body></html>');
//		newdoc.close();
alert('保存成功');
window.close();
       
//		if(window.opener) 
//		{
//			window.opener.location.reload();
//		}
		window.close();
	}
	catch(err){
		alert("err:" + err.number + ":" + err.description);
	}
	finally{
	}
}

//从本地增加印章文档指定位置
function AddSignFromLocal()
{

   if(TANGER_OCX_bDocOpen)
   {
      TANGER_OCX_OBJ.AddSignFromLocal(
	TANGER_OCX_Username,//当前登陆用户
	"",//缺省文件
	true,//提示选择
	0,//left
	0,"",1,100,0)  //top
   }
}

//从URL增加印章文档指定位置
function AddSignFromURL(URL)
{
   if(TANGER_OCX_bDocOpen)
   {
      TANGER_OCX_OBJ.AddSignFromURL(
	TANGER_OCX_Username,//当前登陆用户
	URL,//URL
	-50,//left
	-50,"",1,100,0)  //top
   }
}

//开始手写签名
function DoHandSign()
{
   if(TANGER_OCX_bDocOpen)
   {	
	TANGER_OCX_OBJ.DoHandSign2(
	TANGER_OCX_Username,//当前登陆用户 必须
	"",0,0,0); //top//可选参数
	}
}
//检查签名结果
function DoCheckSign()
{
	if(TANGER_OCX_bDocOpen)
	{		
	var ret = TANGER_OCX_OBJ.DoCheckSign
	(
	/*可选参数 IsSilent 缺省为FAlSE，表示弹出验证对话框,否则，只是返回验证结果到返回值*/
	);//返回值，验证结果字符串
	//alert(ret);
	}	
}
function AddPictureFromLocal()
{
	if(TANGER_OCX_bDocOpen)
	{	
    TANGER_OCX_OBJ.AddPicFromLocal(
	"", //path 
	true,//prompt to select
	true,//is float
	0,//left
	0); //top
	};	
}

function AddPictureFromURL(URL)
{
	if(TANGER_OCX_bDocOpen)
	{
    TANGER_OCX_OBJ.AddPicFromURL(
	URL,//URL Note: URL must return Word supported picture types
	true,//is float
	0,//left
	0);//top
	};
}
function InsertDocFromURL(URL)
{
	if(TANGER_OCX_bDocOpen)
	{
		TANGER_OCX_OBJ.AddTemplateFromURL(URL);
	};
}


function DoHandDraw()
{
	if(TANGER_OCX_bDocOpen)
	{	
	TANGER_OCX_OBJ.DoHandDraw2(
	0,0,0);//top optional
	}
}

function TANGER_OCX_AddDocHeader( strHeader )
{
	var i,cNum = 30;
	var lineStr = "";
	try
	{
		for(i=0;i<cNum;i++) lineStr += "_"; 
		with(TANGER_OCX_OBJ.ActiveDocument.Application)
		{
			Selection.HomeKey(6,0); // go home
			Selection.TypeText(strHeader);
			Selection.TypeParagraph(); 
			Selection.TypeText(lineStr); 
			Selection.TypeText("★");
			Selection.TypeText(lineStr);  
			Selection.TypeParagraph();
			Selection.HomeKey(6,1); 
			Selection.ParagraphFormat.Alignment = 1; 
			with(Selection.Font)
			{
				Name = "Arial";
				Size = 12;
				Bold = false;
				Italic = false;
				Underline = 0;
				UnderlineColor = 0;
				StrikeThrough = false;
				DoubleStrikeThrough = false;
				Outline = false;
				Emboss = false;
				Shadow = false;
				Hidden = false;
				SmallCaps = false;
				AllCaps = false;
				Color = 255;
				Engrave = false;
				Superscript = false;
				Subscript = false;
				Spacing = 0;
				Scaling = 100;
				Position = 0;
				Kerning = 0;
				Animation = 0;
				DisableCharacterSpaceGrid = false;
				EmphasisMark = 0;
			}
			Selection.MoveDown(5, 3, 0); 
		}
	}
	catch(err){
		//alert("err:" + err.number + ":" + err.description);
	}
	finally{
	}
}
function strtrim(value)
{
	return value.replace(/^\s+/,'').replace(/\s+$/,'');
}

function TANGER_OCX_doFormOnSubmit()
{
	var form = document.forms[0];
  	if (form.onsubmit)
	{
    	var retVal = form.onsubmit();
     	if (typeof retVal == "boolean" && retVal == false)
       	return false;
	}
	return true;
}

function TANGER_OCX_EnableReviewBar(boolvalue)
{
	TANGER_OCX_OBJ.ActiveDocument.CommandBars("Reviewing").Enabled = boolvalue;
	TANGER_OCX_OBJ.ActiveDocument.CommandBars("Track Changes").Enabled = boolvalue;
	TANGER_OCX_OBJ.IsShowToolMenu = boolvalue;
}

function TANGER_OCX_SetReviewMode(boolvalue)
{
	TANGER_OCX_OBJ.ActiveDocument.TrackRevisions = boolvalue;
}

function TANGER_OCX_SetMarkModify(boolvalue)
{
	TANGER_OCX_SetReviewMode(boolvalue);
	TANGER_OCX_EnableReviewBar(!boolvalue);
}

function TANGER_OCX_ShowRevisions(boolvalue)
{
	TANGER_OCX_OBJ.ActiveDocument.ShowRevisions = boolvalue;
}

function TANGER_OCX_PrintRevisions(boolvalue)
{
	TANGER_OCX_OBJ.ActiveDocument.PrintRevisions = boolvalue;
}

function TANGER_OCX_SetDocUser(cuser)
{
	with(TANGER_OCX_OBJ.ActiveDocument.Application)
	{
		UserName = cuser;
		TANGER_OCX_Username = cuser;
	}	
}

function TANGER_OCX_ChgLayout()
{
 	try
	{
		TANGER_OCX_OBJ.showdialog(5); 
	}
	catch(err){
		alert("err:" + err.number + ":" + err.description);
	}
	finally{
	}
}

function TANGER_OCX_PrintDoc()
{
	try
	{
		TANGER_OCX_OBJ.printout(true);
	}
	catch(err){
		alert("err:"  + err.number + ":" + err.description);
	}
	finally{
	}
}


function TANGER_OCX_EnableFileNewMenu(boolvalue)
{
	TANGER_OCX_OBJ.EnableFileCommand(0) = boolvalue;
}

function TANGER_OCX_EnableFileOpenMenu(boolvalue)
{
	TANGER_OCX_OBJ.EnableFileCommand(1) = boolvalue;
}

function TANGER_OCX_EnableFileCloseMenu(boolvalue)
{
	TANGER_OCX_OBJ.EnableFileCommand(2) = boolvalue;
}

function TANGER_OCX_EnableFileSaveMenu(boolvalue)
{
	TANGER_OCX_OBJ.EnableFileCommand(3) = boolvalue;
}

function TANGER_OCX_EnableFileSaveAsMenu(boolvalue)
{
	TANGER_OCX_OBJ.EnableFileCommand(4) = boolvalue;
}

function TANGER_OCX_EnableFilePrintMenu(boolvalue)
{
	TANGER_OCX_OBJ.EnableFileCommand(5) = boolvalue;
}

function TANGER_OCX_EnableFilePrintPreviewMenu(boolvalue)
{
	TANGER_OCX_OBJ.EnableFileCommand(6) = boolvalue;
}

function TANGER_OCX_OnDocumentOpened(str, obj)
{
	TANGER_OCX_bDocOpen = true;	
	TANGER_OCX_SetDocUser(TANGER_OCX_Username);
	//TANGER_OCX_OBJ.SetReadOnly(true);//保护文档
	TANGER_OCX_SetReviewMode(true);//留痕
}

function TANGER_OCX_OnDocumentClosed()
{
   TANGER_OCX_bDocOpen = false;
}

    </script>

    <script language="javascript">
function myselect()
{
var s1=document.getElementById("select1");
var select2=document.getElementById("redHeadTemplateFile");
var number=select2.length;
for(var j=select2.length-1;j>=0;j--){
select2.removeChild(select2.childNodes.item(j));
}

var dopt = document.createElement("OPTION");
dopt.text="请选择模版";
select2.add(dopt);

<%=fljs%>


}

function aaa()
{

TANGER_OCX_OBJ.SetBookmarkValue("zhusong","aaaa");


//var value= TANGER_OCX_OBJ.GetBookmarkValue("zhusong");
//alert(value);
}

function addServerjianpan()
{
    TANGER_OCX_OBJ.AddSecKeyboardComment("<%=Session["realname"] %>");
}

function addServerSecSign()
{
		var signUrl="/seal/1.esp";
	
		if(TANGER_OCX_OBJ.doctype==1||TANGER_OCX_OBJ.doctype==2)
		{
			try
			{TANGER_OCX_OBJ.AddSecSignFromURL("<%=Session["realname"] %>",signUrl);}
			catch(error){}
		}
		else
		{alert("不能在该类型文档中使用安全签名印章.");}

}
    </script>

</head>
<body class="newbody" onload='chknull()'>
    <input name="docid" type="hidden" value="<% = docid %>">
    <input id="filename" name="filename" maxlength="50" size="50" value="<% = filename %>"
        style="display: none">
    <input type="button" value="Set user:" onclick="TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);"
        style="display: none">
    <input id="TANGER_OCX_Username" type="text" size="20" value="<% = Session["realname"] %>"
        style="display: none">
    <center>
        <form id="myForm" method="post" enctype="multipart/form-data">
            <table width="100%" height="100%" border="1" cellpadding="0" cellspacing="0" style="border-right: #9dc2db 1px solid;
                border-top: #9dc2db 1px solid; border-left: #9dc2db 1px solid; border-bottom: #9dc2db 1px solid">
                <tr width="100%">
                    <td valign="top" width="120">
                        <button class="op" onclick="TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);DoHandDraw()"
                            type="button">
                            手写签名</button>
                        <button class="op" onclick="TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);TANGER_OCX_SetMarkModify(true);TANGER_OCX_OBJ.focus();"
                            type="button">
                            保留痕迹</button>
                        <button class="op" onclick="TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);TANGER_OCX_SetMarkModify(false);TANGER_OCX_OBJ.focus();"
                            type="button">
                            不留痕</button>
                        <button class="op" onclick="TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);TANGER_OCX_ShowRevisions(true);"
                            type="button">
                            显示痕迹</button>
                        <button class="op" onclick="TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);TANGER_OCX_ShowRevisions(false);"
                            type="button">
                            隐藏痕迹</button>
                        <hr>
                        <button class="op" onclick="Openyz()" type="button">
                            添加印章</button>
                        <select id="ReadSeal" style="width: 110px" name="ReadSeal">
                            <option value="" "selected">请选择印章</option>
                            <%=yzlist %>
                        </select>
                        <button class="op" onclick="TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);DoHandSign()"
                            type="button">
                            手写签名</button>
                        <button class="op" onclick="addServerSecSign()" type="button">
                            服务器盖章</button>
                        <button class="op" onclick="addServerjianpan()" type="button">
                            键盘批注</button>
                        <button class="op" onclick="TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);DoCheckSign()"
                            type="button">
                            印章验证</button>
                        <button class="op" onclick="TANGER_OCX_OBJ.SetReadOnly(true,'',1);" type="button">
                            保护印章</button>
                        <button class="op" onclick="TANGER_OCX_OBJ.SetReadOnly(false,'',1);" type="button">
                            取消保护</button>
                        <hr>
                        <button class="op" onclick="TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);TANGER_OCX_PrintDoc()"
                            type="button">
                            打印</button>
                        <button class="op" onclick="window.location.reload();" type="button">
                            刷新页面</button>
                        <button class="op" onclick="javascript:window.close();" type="button">
                            关闭页面</button>
                        <button class="op" onclick="TANGER_OCX_SaveEditToServerDisk();" type="button">
                            保存并关闭</button>
                    </td>
                    <td width="100%">
                        <object id="TANGER_OCX" codebase="/OfficeControl.cab#version=5,0,2,2" height="100%"
                            width="100%" classid="clsid:A39F1330-3322-4a1d-9BF0-0BA2BB90E970">
                            <param name="_ExtentX" value="18071">
                            <param name="_ExtentY" value="20981">
                            <param name="BorderColor" value="14402205">
                            <param name="BackColor" value="-2147483643">
                            <param name="ForeColor" value="-2147483640">
                            <param name="TitlebarColor" value="14402205">
                            <param name="TitlebarTextColor" value="0">
                            <param name="BorderStyle" value="1">
                            <param name="Titlebar" value="1">
                            <param name="Toolbars" value="1">
                            <param name="Caption" value="在线编辑文档">
                            <param name="IsShowToolMenu" value="1">
                            <param name="IsNoCopy" value="0">
                            <param name="IsHiddenOpenURL" value="0">
                            <param name="MaxUploadSize" value="0">
                            <param name="Menubar" value="1">
                            <param name="Statusbar" value="1">
                            <param name="FileNew" value="-1">
                            <param name="FileOpen" value="-1">
                            <param name="FileClose" value="-1">
                            <param name="FileSave" value="-1">
                            <param name="FileSaveAs" value="-1">
                            <param name="FilePrint" value="-1">
                            <param name="FilePrintPreview" value="-1">
                            <param name="FilePageSetup" value="-1">
                            <param name="FileProperties" value="-1">
                            <param name="IsStrictNoCopy" value="0">
                            <param name="IsUseUTF8URL" value="0">
                            <param name="MenubarColor" value="-2147483643">
                            <param name="IsUseControlAgent" value="0">
                            <param name="IsUseUTF8Data" value="0">
                            <param name="IsSaveDocExtention" value="0">
                            <param name="IsDirectConnect" value="0">
                            <param name="SignCursorType" value="0">
                            <param name="IsResetToolbarsOnOpen" value="0">
                            <param name="IsSaveDataIfHasVDS" value="0">
                            <span style="color: red">不能装载文档控件。请在检查浏览器的选项中检查浏览器的安全设置。</span>
                        </object>
                        <!-- OnDocumentClosed and OnDocumentOpened -->

                        <script language="JScript" for="TANGER_OCX" event="OnDocumentClosed()">
		TANGER_OCX_OnDocumentClosed();
                        </script>

                        <script language="JScript" for="TANGER_OCX" event="OnDocumentOpened(TANGER_OCX_str,TANGER_OCX_obj)">
		TANGER_OCX_OnDocumentOpened(TANGER_OCX_str,TANGER_OCX_obj);
                        </script>

                        <script language="JScript" for="TANGER_OCX" event="OnFileCommand(cmd,canceled)">
		if (cmd == 3) //user has clicked on file save menu or button
		{
			//save to server
			//cancel default process
			//TANGER_OCX_SaveEditToServerDisk();
			//document.all("TANGER_OCX").CancelLastCommand = true;
		}
                        </script>

                        <script language="JScript" for="TANGER_OCX" event="OnSignSelect(issign,signinfo)">
								if(issign)
								{
										//TANGER_OCX_OBJ.SetReadOnly(true);
										//TANGER_OCX_OBJ.SetReadOnly(false);
								}
								else
								{
								}
								
								 TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);
								 TANGER_OCX_SetMarkModify(false);TANGER_OCX_OBJ.focus();
								 
								 
                                function aaa()
                                {
                                    TANGER_OCX_SetDocUser(document.all('TANGER_OCX_Username').value);
                                    TANGER_OCX_SetMarkModify(false);TANGER_OCX_OBJ.focus();
                                }  
                                
                        </script>

                    </td>
                </tr>
            </table>
        </form>
    </center>
</body>
</html>
