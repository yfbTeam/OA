<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MySms_Shenqing_update.aspx.cs"
    Inherits="xyoa.InfoManage.sms.MySms_Shenqing_update" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('Content').value=='')
    {
    alert('短信不能为空');
    form1.Content.focus();
    return false;
    }	
    
    showwait();	
}  

function  setall1()  
{
    document.getElementById('acceptusername').value='0';
    document.getElementById('acceptrealname').value='全部人员';
}



function notice()
{
   msg="注意：\n\n所发送的手机短信将在本系统中进行记录，\n请勿发送与工作无关的涉及个人隐私的信息，\n请提醒接收方：其直接回复的信息也可能导致隐私泄露。";
   alert(msg);
}
function yijian()
{
   var text=form1.DropDownList1.value;
   if (text !="请选择")
   {
       document.getElementById('Yijian').value +=text;
   }
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
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
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
                                                </td>
                                            <td valign="top">
                                                <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td width="3%">
                                                            <img src="/oaimg/top_3.gif"></td>
                                                        <td width="81%" valign="bottom">
                                                            <a href="MySms_Shenqing.aspx" class="line_b">
                                                                发送短信申请</a> >> 修改发送手机短信</td>
                                                        <td width="81%">
                                                            </td>
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
                                                </td>
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
                                                </td>
                                            <td valign="top">
                                                <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0"
                                                    cellpadding="0" cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">手机短信</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            <input onclick='window.open ("/WorkFlowSysMag/AddWorkFlow_show_lc.aspx?FormId=<%=ViewState["FormId"]%>&DqNodeId=<%=ViewState["DqNodeId"]%>&DqNodeName=<%=ViewState["DqNodeName"]%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'
                                                                type="button" value="办理流程图" id="Button11" class="button_css"></td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="17">
                                                </td>
                                        </tr>
                                    </table>
                                </div>
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        内部接收人：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="acceptrealname" runat="server" Width="100%" Height="86px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <input id="Button6" type="button" value="选择人员" onclick="openuser1()" /><input id="Button7"
                                                            type="button" value="全部人员" onclick="setall1()" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        外部接收人：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="wbUsername" runat="server" Width="100%" Height="86px" TextMode="MultiLine"></asp:TextBox>
                                                        <input id="Button3" type="button" value="选择人员" onclick="openuser2()" />人员手机号是从“通讯录管理-个人通讯录”中选取，自己添加请用","分开。
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        信息内容：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Content" runat="server" Width="100%" Height="67px" TextMode="MultiLine"></asp:TextBox>
                                                        <a href="javascript:notice();"><font color="red">隐私警示</font></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        计划发送时间：
                                                    </td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Starttime" runat="server" onClick="WdatePicker({dateFmt:'yyyy-MM-dd H:m:s'})"></asp:TextBox>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        审批状态：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="LcZhuangtai" runat="server" Width="100%" CssClass="ReadOnlyText"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                                            <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                            <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="返 回" OnClick="Button2_Click" />
                                                        </div>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="17">
                                            </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:TextBox ID="acceptusername" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="wbRealname" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
        <input id="YjbNodeId" type="hidden" runat="server" />
        <input id="NodeName" type="hidden" runat="server" />
        <asp:TextBox ID="ZbUsername" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
            
            
            var  wName_1;  
            function  openuser1()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('acceptusername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("acceptusername").value=arr[0]; 
                    document.getElementById("acceptrealname").value=arr[1]; 
                }
            }

            var  wName_2;  
            function  openuser2()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('wbUsername').value+"";
                wName_2=window.showModalDialog("/OpenWindows/open_wbuser_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:680px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("wbUsername").value=arr[0]; 
                    document.getElementById("wbRealname").value=arr[1]; 
                }
            }



        </script>

    </form>
</body>
</html>
