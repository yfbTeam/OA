<%@ Page Language="C#" AutoEventWireup="true" Codebehind="AddWorkFlow_add_Next_Zy.aspx.cs"
    Inherits="xyoa.WorkFlow.AddWorkFlow_add_Next_Zy" %>

<html>

<script>
function chknull()
{
    if(document.form1.JbRealname.value=="")
    {
	    alert("请至少选择一个经办人！");
	    form1.JbRealname.focus();
        return false;
    }


    if(document.form1.JcZhuanjiao.value=="3")
    {
        if(document.form1.ZbRealname.value=="")
        {
	        alert("当前经办人权限为【不允许经办人转交】，请指定一个主办人！");
	        form1.ZbRealname.focus();
	        return false;
        }
    }
    else
    {
        if(document.form1.ZbRealname.value=="" && !document.form1.CheckBox1.checked)
        {
	        alert("请指定主办人！");
	        form1.ZbRealname.focus();
	        return false;
        }
    }

    
    if(document.form1.txtSmsContent.value=="" && (document.form1.C1.checked || document.form1.C2.checked))
    {
	    alert("短信内容不能为空！");
	    form1.txtSmsContent.focus();
	    return false;
    }
    
    showwait();	
}  

function no_op()
{
  document.form1.ZbUsername.value="";
  document.form1.ZbRealname.value="";
}

function senduser(str)
{
    window.open("/senduser.aspx?user="+str+"","_blank","height=500, width=600,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=200,left=350");
}
			
</script>

<head id="Head1" runat="server">
    <title>转交工作：<%=ViewState["Name"] %>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

</head>
<body class="newbody">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%"  border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="Number" runat="server" Visible="False"></asp:TextBox></td>
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
                                                            <a href="AddWorkFlow.aspx">新建工作</a>
                                                            >> 转交下一步骤(自由流程)</td>
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td class="newtd1" colspan="4">
                                                        <b>流水号：<%=ViewState["Sequence"]%>
                                                            -
                                                            <%=ViewState["Name"]%>
                                                        </b>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" nowrap="nowrap">
                                                        <asp:Label ID="Liucheng" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd1" colspan="4" nowrap="nowrap">
                                                        <img src="../oaimg/menu/workflow_others.gif" />
                                                        <strong>选择人员</strong> <a href='javascript:void(0)' onclick='window.open ("AddWorkFlow_bl_lc.aspx?Number=<%=Request.QueryString["Number"]%>", "_blank", "height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0")'>
                                                            查看流程图</a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" nowrap="nowrap">
                                                        主办人：<asp:TextBox ID="ZbRealname" runat="server" Width="152px" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" Text="不指定主办人。" onclick="no_op();" />
                                                        <input id="Button4" type="button" value="选择主办人员" runat="server" />选择主办人员只能是经办人员中的一员，建议先选择经办人员。<br>
                                                        经办人：<asp:TextBox ID="JbRealname" runat="server" Width="461px" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <input id="Button6" type="button" value="选择经办人员" runat="server" /><br>
                                                        经办人转交权限：
                                                        <asp:DropDownList ID="JcZhuanjiao" runat="server">
                                                            <asp:ListItem Value="2">所有经办人办理完毕才能转交</asp:ListItem>
                                                            <asp:ListItem Value="3">不允许经办人转交</asp:ListItem>
                                                            <asp:ListItem Value="1">任何时候都可以转交</asp:ListItem>
                                                        </asp:DropDownList><br>
                                                        主办强制转交： <strong>经办人未办理完毕时是否允许主办人强制转交：</strong>
                                                        <asp:DropDownList ID="ZbZhuanjiao" runat="server">
                                                            <asp:ListItem Value="1">允许</asp:ListItem>
                                                            <asp:ListItem Value="2">不允许</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd1" colspan="4" nowrap="nowrap">
                                                        <img src="../oaimg/menu/workflow_query.gif" />
                                                        <strong>短信提醒</strong></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" nowrap="nowrap">
                                                        提醒下一步骤办理人：
                                                        <img src="/oaimg/menu/chatroom.gif" />
                                                        <asp:CheckBox ID="C1" runat="server" Text="内部消息" Checked="True" />
                                                        <img src="/oaimg/menu/Menu30.gif" id="IMG1" runat="server" />
                                                        <asp:CheckBox ID="C2" runat="server" Text="手机短信" />
                                                        <br>
                                                        提醒本流程的发起人：
                                                        <img src="/oaimg/menu/chatroom.gif" />
                                                        <asp:CheckBox ID="C3" runat="server" Text="内部消息" />
                                                        <img src="/oaimg/menu/Menu30.gif" id="IMG2" runat="server" />
                                                        <asp:CheckBox ID="C4" runat="server" Text="手机短信" />
                                                        <br>
                                                        短信内容：
                                                        <asp:TextBox ID="txtSmsContent" runat="server" Width="461px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="确定转交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <input id="Button5" type="button" value="取消转交并关闭" onclick="window.opener.parent.location.href='WorkFlowList_blz.aspx';window.close();"
                                                                    class="button_css" />
                                                            </font>
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
        <asp:TextBox ID="ZbUsername" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="GlNum" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="JbUsername" runat="server" Style="display: none"></asp:TextBox>

        <script>
function  openUser1()//主办人  
{  
        var  wName_3;  
        var num=Math.random();
        var str=""+document.getElementById('ZbUsername').value+"|"+document.getElementById('ZbRealname').value+"";
        var str1=""+document.getElementById('JbUsername').value+"";
        wName_3=window.showModalDialog("/OpenWindows/open_AddWorkFlow_add_Next_Zb.aspx?tmp="+num+"&requeststr="+str+"&user="+str1+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
        if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
        for(var i=0;i<arr.length;i++)
        { 
            document.getElementById("ZbUsername").value=arr[0]; 
            document.getElementById("ZbRealname").value=arr[1]; 
            
            
            var strs = ""+document.getElementById("ZbUsername").value+",";
            var stre = document.getElementById("JbUsername").value;
            var s = stre.indexOf(strs);
            if(s<0)
            {
               document.getElementById("JbUsername").value=""+arr[0]+","; 
               document.getElementById("JbRealname").value=""+arr[1]+","; 
            }
        }
}


function  openUser2()//经办人  
{  
    var  wName_1;  
    var num=Math.random();
    var str=""+document.getElementById('ZbUsername').value+","+document.getElementById('JbUsername').value+"";
    wName_1=window.showModalDialog("/OpenWindows/open_user_list_all.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
    if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
    for(var i=0;i<arr.length;i++)
    { 
        document.getElementById("JbUsername").value=arr[0]; 
        document.getElementById("JbRealname").value=arr[1]; 
        IndexDemo();
    }
}
        </script>

    </form>
</body>
</html>
