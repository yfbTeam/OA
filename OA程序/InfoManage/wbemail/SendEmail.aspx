<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SendEmail.aspx.cs" Inherits="xyoa.InfoManage.wbemail.SendEmail" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<html>

<script>
function chknull()
{
    if(document.getElementById('Title').value=='')
    {
        alert('邮件主题不能为空');
        form1.Title.focus();
        return false;
    }	
    
    if(document.getElementById('toemail').value=='')
    {
        alert('收件人不能为空');
        form1.toemail.focus();
        return false;
    }	
    
    showwait();	
}  
function openqiupengmodle()
{
var num=Math.random();
window.open ("/fckeditor/modle.aspx?tmp="+num+"", "_blank", "height=417px, width=417px,toolbar=no, menubar=no, scrollbars=no,resizable=yes,location=no, status=no")
}

function qiupengmodel(str)
{
var oEditor = FCKeditorAPI.GetInstance('Content') 
oEditor.InsertHtml(''+str+'');
}
</script>

<script language="javascript" type="text/javascript">

function  openfile()  
{  
    var num=Math.random();
    var number=document.getElementById('Number').value;
    window.showModalDialog("/openfile.aspx?tmp="+num+"&number="+number+" ","window","dialogWidth:680px;DialogHeight=580px;status:no;scroll=yes;help:no");                
}


</script>

<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="5" border="0" cellpadding="0" cellspacing="0" id="printshow1">
                        <tr>
                            <td>
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
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">外部邮件</font></button></td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        <font color="red">※</font>选择邮箱：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:DropDownList ID="youxiang" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>邮件主题：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Title" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        <font color="red">※</font>收件人邮箱：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="toemail" runat="server" Width="90%" Height="57px" TextMode="MultiLine"></asp:TextBox>
                                                        <input id="Button3" type="button" value="从单位内部选择" onclick="openuser2()" />
                                                        多邮件用","分开。
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        发送时间：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="Settimes" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                       
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        邮件正文(<a href="javascript:void(0)" onclick="openqiupengmodle()">模版</a>)：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <FCKeditorV2:FCKeditor ID="Content" runat="server" Height="250px" ToolbarSet="Qiupeng1">
                                                        </FCKeditorV2:FCKeditor>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="发 送" CssClass="button_css" OnClick="Button1_Click" />
                                                                <asp:Button ID="Button2" runat="server" Text="返 回" CssClass="button_css" OnClick="Button2_Click" />
                                                            </font>
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

        <script language="javascript">	
try{
    parent.closeAlert('UploadChoose');
}
catch(err){
}

       
            function  openuser2()  
            {   var  wName_2;  
                var num=Math.random();
                var str=""+document.getElementById('toemail').value+"";
                wName_2=window.showModalDialog("/OpenWindows/open_user_list_yj.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:780px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("toemail").value=arr[0]; 
                }
            }



        </script>

    </form>
</body>
</html>
