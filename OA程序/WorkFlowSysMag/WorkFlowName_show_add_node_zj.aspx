<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_add_node_zj.aspx.cs"
    Inherits="xyoa.WorkFlowSysMag.WorkFlowName_show_add_node_zj" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('NodeNum').value=='')
    {
        alert('步骤序号不能为空');
        form1.NodeNum.focus();
        return false;
    }	
   
    if(document.getElementById('NodeNum').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('NodeNum').value))
        {
            alert("步骤序号只能为正数");
            form1.NodeNum.focus();
            return false;
        }
    }

    if(document.getElementById('NodeName').value=='')
    {
        alert('步骤名称不能为空');
        form1.NodeName.focus();
        return false;
    }	


    
    showwait();	
}  

function select_tr()
{
   if (form1.NodeSite.value=="1")
   {
      nd1.style.display='none';
      nd2.style.display='none';
      nd6.style.display='none';
       nd7.style.display='none';
      nd3.style.display=''   
   }
   else if (form1.NodeSite.value=="3")
   {
      nd1.style.display='';
      nd2.style.display='';  
      nd6.style.display='';
      nd7.style.display='';
      nd3.style.display='none';
     
   }
   else
   {
      nd3.style.display='';
      nd1.style.display='';
      nd2.style.display='';  
      nd6.style.display=''; 
      nd7.style.display='';
   }
}

function cleartype()
{
      document.getElementById('ZbUsername').value="";
      document.getElementById('ZbRealname').value="";
}

function select_type()
{
   cleartype();
   if (form1.XrGuize.value=="1")
   {
      nd1.style.display='none';
      document.getElementById("strhtm1").innerHTML="经办人";
      document.getElementById('Button7').style.display='';
      document.getElementById("Button7").value="选择经办人";
   }
   else if (form1.XrGuize.value=="2")
   {
      nd1.style.display='';
      document.getElementById("strhtm1").innerHTML="经办人";
      document.getElementById("ZbRealname").value="流程发起人";
      document.getElementById('Button7').style.display='none';
   }
   else if (form1.XrGuize.value=="3")
   {
      nd1.style.display='';
      document.getElementById("strhtm1").innerHTML="经办人";
      document.getElementById("ZbRealname").value="本部门主管";
      document.getElementById('Button7').style.display='none';
   }
   else if (form1.XrGuize.value=="4")
   {
      nd1.style.display='';
      document.getElementById("strhtm1").innerHTML="经办人";
      document.getElementById("ZbRealname").value="上级部门主管";
      document.getElementById('Button7').style.display='none';
   }
   else if (form1.XrGuize.value=="5")
   {
      nd1.style.display='';
      document.getElementById("strhtm1").innerHTML="经办人";
      document.getElementById("ZbRealname").value="一级部门主管";
      document.getElementById('Button7').style.display='none';
   }
   else if (form1.XrGuize.value=="6")
   {
      nd1.style.display='';
      document.getElementById("strhtm1").innerHTML="经办人";
      document.getElementById("Button7").value="选择经办人";
      document.getElementById('Button7').style.display='';
   }
   else if (form1.XrGuize.value=="7")
   {
      nd1.style.display='';
      document.getElementById("strhtm1").innerHTML="经办人";
      document.getElementById("ZbRealname").value="当前登录人";
      document.getElementById('Button7').style.display='none';
   }
   else if (form1.XrGuize.value=="8")
   {
      nd1.style.display='';
      document.getElementById("strhtm1").innerHTML="经办角色";
      document.getElementById("Button7").value="选择角色";
      document.getElementById('Button7').style.display='';
      
   }
   else if (form1.XrGuize.value=="10")
   {
      nd1.style.display='';
      document.getElementById("strhtm1").innerHTML="经办职位";
      document.getElementById('Button7').style.display='';
      document.getElementById("Button7").value="选择职位";
   }
   else
   {
     nd1.style.display='';
     document.getElementById("strhtm1").innerHTML="经办人";
     document.getElementById("Button7").value="选择经办人";
     document.getElementById('Button7').style.display='';
   }

}

</script>

<head id="Head1" runat="server">
    <title>工作流设置</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <base target="_self" />
</head>
<body class="newbody" onload="select_tr();select_type();">
    <form id="form1" runat="server">
        <table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" height="4" border="0" cellpadding="0" cellspacing="0">
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
                                        <td width="17">
                                            &nbsp;</td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>步骤序号：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="NodeNum" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>步骤名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="NodeName" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>步骤位置：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="NodeSite" runat="server" Width="100%" onchange="select_tr()">
                                                            <asp:ListItem Value="1">开始</asp:ListItem>
                                                            <asp:ListItem Value="2">中间段</asp:ListItem>
                                                            <asp:ListItem Value="3">结束</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="nd3">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        下一步骤：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td align="center" style="width: 113px" valign="top">
                                                                    <strong>待选步骤</strong></td>
                                                                <td align="center" style="width: 42px" valign="top">
                                                                </td>
                                                                <td align="center" style="width: 100px" valign="top">
                                                                    <strong>已选步骤</strong></td>
                                                            </tr>
                                                            <tr>
                                                                <td align="center" style="width: 113px" valign="top">
                                                                    <asp:ListBox ID="SourceListBox" runat="server" Height="171px" Width="157px" SelectionMode="Multiple">
                                                                    </asp:ListBox></td>
                                                                <td align="center" style="width: 42px" valign="top">
                                                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text=">" Width="58px" /><br />
                                                                    <br />
                                                                    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text=">>" Width="58px" />
                                                                    <br />
                                                                    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="<" Width="58px" /><br />
                                                                    <br />
                                                                    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="<<" Width="58px" />
                                                                </td>
                                                                <td align="center" style="width: 100px" valign="top">
                                                                    <asp:ListBox ID="TargetListBox" runat="server" Height="171px" Width="157px" SelectionMode="Multiple">
                                                                    </asp:ListBox></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                     <tr id="nd7">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>经办人转交：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="JbZhuangjiao" runat="server" Width="100%" onchange="select_type();">
                                                            <asp:ListItem Value="1">任何时候都可以转交</asp:ListItem>
                                                            <asp:ListItem Value="2">所有经办人办理完毕才能转交</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr id="nd6">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>自动选择规则：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="XrGuize" runat="server" Width="100%" onchange="select_type();">
                                                            <asp:ListItem Value="1">不启动自动选择</asp:ListItem>
                                                            <asp:ListItem Value="6">指定自动选入默认人员</asp:ListItem>
                                                            <asp:ListItem Value="2">自动选择流程发起人</asp:ListItem>
                                                            <asp:ListItem Value="7">自动选择当前登录人</asp:ListItem>
                                                            <asp:ListItem Value="3">自动选择本部门主管</asp:ListItem>
                                                            <asp:ListItem Value="4">自动选择上级部门主管</asp:ListItem>
                                                            <asp:ListItem Value="5">自动选择一级部门主管</asp:ListItem>
                                                            <asp:ListItem Value="8">自动关联指定角色中的人员</asp:ListItem>
                                                            <asp:ListItem Value="10">自动关联指定职位中的人员</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr id="nd1">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font><span id="strhtm1"></span>：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="ZbRealname" runat="server" CssClass="ReadOnlyText" Width="241px"></asp:TextBox><input
                                                            id="Button7" type="button" value="选择经办人" onclick="opengw()" />
                                                        <strong>是否允许修改经办人：</strong>
                                                        <asp:DropDownList ID="XiugaiZb" runat="server">
                                                            <asp:ListItem Value="2">允许</asp:ListItem>
                                                            <asp:ListItem Value="1">不允许</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="nd2">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>回退选项：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <strong>是否允许回退：</strong>
                                                        <asp:DropDownList ID="Huitui" runat="server">
                                                            <asp:ListItem Value="3">允许回退</asp:ListItem>
                                                            <asp:ListItem Value="1">不允许</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                <input id="Button3" class="button_css" onclick="javascript:window.close()" type="button"
                                                                    value="关 闭" /></font></div>
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
        <asp:TextBox ID="NodeNumber" runat="server" Visible="False"></asp:TextBox>
        <asp:TextBox ID="ZbUsername" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="shangbu" runat="server" Style="display: none"></asp:TextBox>

        <script>
           function  opengw()  
            {  
                if (document.getElementById('XrGuize').value=="8")
                {
                    var  wName_5;  
                    var num=Math.random();
                    var str=""+document.getElementById('ZbUsername').value+"";
                    wName_5=window.showModalDialog("/OpenWindows/open_juese_List.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=660px;status:no;scroll=yes;help:no");                
                    if (wName_5 == undefined) {wName_5 = window.returnValue;}var arr = wName_5.split("|");
                    for(var i=0;i<arr.length;i++)
                    { 
                        document.getElementById("ZbUsername").value=arr[0]; 
                        document.getElementById("ZbRealname").value=arr[1]; 
                    }
                }
                else if (document.getElementById('XrGuize').value=="10")
                {
                    var  wName_5;  
                    var num=Math.random();
                    var str=""+document.getElementById('ZbUsername').value+"";
                    wName_5=window.showModalDialog("/OpenWindows/open_zhiwei_List.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=660px;status:no;scroll=yes;help:no");                
                    if (wName_5 == undefined) {wName_5 = window.returnValue;}var arr = wName_5.split("|");
                    for(var i=0;i<arr.length;i++)
                    { 
                        document.getElementById("ZbUsername").value=arr[0]; 
                        document.getElementById("ZbRealname").value=arr[1]; 
                    }
                }
                else
                {
                    var  wName_5;  
                    var num=Math.random();
                    var str=""+document.getElementById('ZbUsername').value+"";
                    wName_5=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=660px;status:no;scroll=yes;help:no");                
                    if (wName_5 == undefined) {wName_5 = window.returnValue;}var arr = wName_5.split("|");
                    for(var i=0;i<arr.length;i++)
                    { 
                        document.getElementById("ZbUsername").value=arr[0]; 
                        document.getElementById("ZbRealname").value=arr[1]; 
                    }
                }

                
            }
        </script>

    </form>
</body>
</html>
