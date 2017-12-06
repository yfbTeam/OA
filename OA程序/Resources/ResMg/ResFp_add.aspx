<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ResFp_add.aspx.cs" Inherits="xyoa.Resources.ResMg.ResFp_add" %>

<html>

<script>
function chknull()
{

    if(document.getElementById('ZyName').value=='')
    {
        alert('物品名称不能为空');
        form1.ZyName.focus();
        return false;
    }	

    if(document.getElementById('GmTime').value=='')
    {
        alert('分配时间不能为空');
        form1.GmTime.focus();
        return false;
    }	

    if(document.getElementById('GmNum').value=='')
    {
        alert('分配数量不能为空，没有请填为０');
        form1.GmNum.focus();
        return false;
    }	
 
    if(document.getElementById('GmNum').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('GmNum').value))
        {
            alert("分配数量只能为正数");
            form1.GmNum.focus();
            return false;
        }

    }   
    
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
                                                            <a href="ResFp.aspx">物品分配</a> >>
                                                            新增物品分配</td>
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
                                                                <font class="shadow_but">物品分配</font></button></td>
                                                        <td style="height: 26px" align="right">
                                                            </td>
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
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>物品信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>物品名称：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="ZyName" runat="server" Width="90%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img id="Img1" onclick="return opencp()" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>分配信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        接收人：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:TextBox ID="JsRealname" runat="server" Width="90%" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser2();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        经办人：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:TextBox ID="JbName" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        <font color="red">※</font>分配数量：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:TextBox ID="GmNum" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        <font color="red">※</font>分配时间：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:TextBox ID="GmTime" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                       </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        其他说明：</td>
                                                    <td class="newtd2" colspan="3" style="height: 17px">
                                                        <asp:TextBox ID="Shuoming" runat="server" Width="100%" Height="100px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        通知接收人：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="33%">
                                                        <img src="/oaimg/menu/chatroom.gif" />
                                                        <asp:CheckBox ID="C1" runat="server" Text="内部消息" Checked="True" />
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <asp:Button ID="Button2" runat="server" CssClass="button_css" Text="返 回" OnClick="Button2_Click" /></font></div>
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
        <asp:TextBox ID="ZyId" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="JsUsername" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Gongyinshang" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	
            var  wName_2;  
            function  opencp()  
            {  
                var num=Math.random();
                var clid=""+document.getElementById('ZyId').value+"";
                wName_2=window.showModalDialog("/OpenWindows/OpenZiChang.aspx?tmp="+num+"&id="+clid+"","window", "dialogWidth:780px;DialogHeight=660px;status:no;scroll=yes;help:no");                
                if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("ZyId").value=arr[0]; 
                    document.getElementById("ZyName").value=arr[1]; 
                }
            }
            
            var  wName_4;  
            function  openuser2()  
            {  
                var num=Math.random();
                var str=""+document.getElementById('JsUsername').value+"|"+document.getElementById('JsRealname').value+"";
                wName_4=window.showModalDialog("/OpenWindows/open_Username_two.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                if (wName_4 == undefined) {wName_4 = window.returnValue;}var arr = wName_4.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("JsUsername").value=arr[0]; 
                    document.getElementById("JsRealname").value=arr[1]; 
                }
            }
            
        </script>

    </form>
</body>
</html>
