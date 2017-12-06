<%@ Page Language="C#" AutoEventWireup="true" Codebehind="WorkFlowName_show_add_node_jb.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.WorkFlowName_show_add_node_jb" %>

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
            alert("步骤序号只能为正整数");
            form1.NodeNum.focus();
            return false;
        }
    }


    if(document.getElementById('XbTimes').value=='')
    {
        alert('限办时间不能为空');
        form1.XbTimes.focus();
        return false;
    }	
   
    if(document.getElementById('XbTimes').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('XbTimes').value))
        {
            alert("限办时间只能为正整数");
            form1.XbTimes.focus();
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

function select_type()
{
   if (form1.XrGuize.value=="6")
   {
      trUser.style.display=''; 
      trGuanlian.style.display='none';
   }
   else if (form1.XrGuize.value=="8")
   {
      trUser.style.display='none';
      trGuanlian.style.display='';
      document.getElementById("strhtm1").innerHTML="角色";
      document.getElementById("strhtm2").innerHTML="角色";
//      document.getElementById('ZbGuanlianID').value="";
//      document.getElementById('ZbGuanlianName').value="";
//      document.getElementById('JbGuanlianID').value="";
//      document.getElementById('JbGuanlianName').value="";
      
   }
   else if (form1.XrGuize.value=="10")
   {
      trUser.style.display='none';
      trGuanlian.style.display='';
      document.getElementById("strhtm1").innerHTML="职位";
      document.getElementById("strhtm2").innerHTML="职位";
//      document.getElementById('ZbGuanlianID').value="";
//      document.getElementById('ZbGuanlianName').value="";
//      document.getElementById('JbGuanlianID').value="";
//      document.getElementById('JbGuanlianName').value="";
   }
   else if (form1.XrGuize.value=="13")
   {
      trUser.style.display='none';
      trGuanlian.style.display='';
      document.getElementById("strhtm1").innerHTML="部门";
      document.getElementById("strhtm2").innerHTML="部门";
   }
   else
   {
      trUser.style.display='none';
      trGuanlian.style.display='none';
   }

}

function cleartype()
{
      document.getElementById('ZbGuanlianID').value="";
      document.getElementById('ZbGuanlianName').value="";
      document.getElementById('JbGuanlianID').value="";
      document.getElementById('JbGuanlianName').value="";
}
function select_tr()
{
   if (form1.NodeSite.value=="开始")
   {
      nd1.style.display='none';
      nd2.style.display='none';   
      nd3.style.display='none';   
      nd4.style.display='none';   
      nd5.style.display='none';  
      //nd6.style.display='none';
      //nd7.style.display='none';
      nd8.style.display='none';
      nd9.style.display='';
      nd10.style.display='';
      nd11.style.display='none';
   }
   else if (form1.NodeSite.value=="结束")
   {
      nd1.style.display='';
      nd2.style.display='';   
      nd3.style.display='';   
      nd4.style.display='';   
      nd5.style.display=''; 
      //nd6.style.display='';
      //nd7.style.display='';  
      nd8.style.display=''; 
      nd9.style.display=''; 
      nd10.style.display='none';
      nd11.style.display='';
   }
   else
   {
      nd1.style.display='';
      nd2.style.display='';   
      nd3.style.display='';   
      nd4.style.display='';   
      nd5.style.display=''; 
      //nd6.style.display='';
      //nd7.style.display='';  
      nd8.style.display=''; 
      nd9.style.display=''; 
      nd10.style.display='';
      nd11.style.display='';
   }
}

function select_cy()
{
   if (form1.Chuanyue.value=="2")
   {
      yj1.style.display='none';
      yj2.style.display='none';
      yj3.style.display='none';
   }
   else
   {
      yj1.style.display='';
      yj2.style.display='';
      yj3.style.display='';
      form1.YjRealname.focus(); 
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

    <base target="_self" />
</head>
<body class="newbody" onload="select_type();select_tr();select_cy();">
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
                                                        <asp:TextBox ID="NodeNum" runat="server" Width="100%" CssClass="ReadOnlyText" ReadOnly="True"></asp:TextBox>
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
                                                            <asp:ListItem>开始</asp:ListItem>
                                                            <asp:ListItem>中间段</asp:ListItem>
                                                            <asp:ListItem>结束</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="nd10">
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
                                                        <font color="red">※</font>选人过滤规则：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="GlGuize" runat="server" Width="100%">
                                                            <asp:ListItem Value="1">允许自由选择全部人员</asp:ListItem>
                                                            <asp:ListItem Value="2">允许自由选择本部门人员</asp:ListItem>
                                                            <asp:ListItem Value="3">允许自由选择本角色人员</asp:ListItem>
                                                            <asp:ListItem Value="4">允许自由选择本职位人员</asp:ListItem>
                                                            <asp:ListItem Value="6">只允许从默认人员中选择人员</asp:ListItem>
                                                            <asp:ListItem Value="5">不允许自由选择人员</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr id="nd6">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>自动选择规则：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="XrGuize" runat="server" Width="100%" onchange="select_type();cleartype();">
                                                            <asp:ListItem Value="1">不启动自动选择</asp:ListItem>
                                                            <asp:ListItem Value="2">自动选择流程发起人</asp:ListItem>
                                                            <asp:ListItem Value="7">自动选择当前登录人</asp:ListItem>
                                                            <asp:ListItem Value="3">自动选择本部门主管</asp:ListItem>
                                                            <asp:ListItem Value="4">自动选择上级部门主管</asp:ListItem>
                                                            <asp:ListItem Value="5">自动选择一级部门主管</asp:ListItem>
                                                            <asp:ListItem Value="8">自动关联指定角色中的人员</asp:ListItem>
                                                            <asp:ListItem Value="10">自动关联指定职位中的人员</asp:ListItem>
                                                            <asp:ListItem Value="13">自动关联指定部门中的人员</asp:ListItem>
                                                            <asp:ListItem Value="11">自动选择发起人的部门主管</asp:ListItem>
                                                            <asp:ListItem Value="12">自动选择发起人的上一级部门主管</asp:ListItem>
                                                            <asp:ListItem Value="6">指定自动选入默认人员</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr id="trUser" style="display: none">
                                                    <td class="newtd2" height="17" colspan="4" width="100%">
                                                        主办人：<asp:TextBox ID="ZbRealname" runat="server" Width="120px" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                        <br>
                                                        经办人：<asp:TextBox ID="JbRealname" runat="server" Width="600px" CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="trGuanlian" style="display: none">
                                                    <td class="newtd2" height="17" colspan="4" width="100%">
                                                        主办<span id="strhtm1"></span>：<asp:TextBox ID="ZbGuanlianName" runat="server" Width="120px"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="opengl_zb();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                        <br>
                                                        经办<span id="strhtm2"></span>：<asp:TextBox ID="JbGuanlianName" runat="server" Width="600px"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="opengl_jb();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="nd9">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>限办时间：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="XbTimes" runat="server" Width="42px">72</asp:TextBox>小时（当前步骤若在限办时间内未办理，则步骤为超时步骤）</td>
                                                </tr>
                                                <tr id="nd1">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        经办人转交：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="JcZhuanjiao" runat="server" Width="100%">
                                                            <asp:ListItem Value="2">所有经办人办理完毕才能转交</asp:ListItem>
                                                            <asp:ListItem Value="3">不允许经办人转交</asp:ListItem>
                                                            <asp:ListItem Value="1">任何时候都可以转交</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr id="nd2">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>主办强制转交：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <strong>经办人未办理完毕时是否允许主办人强制转交：</strong>
                                                        <asp:DropDownList ID="ZbZhuanjiao" runat="server">
                                                            <asp:ListItem Value="1">允许</asp:ListItem>
                                                            <asp:ListItem Value="2">不允许</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr id="nd3">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>回退选项：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <strong>是否允许主办人回退：</strong>
                                                        <asp:DropDownList ID="ZbHuitui" runat="server">
                                                            <asp:ListItem Value="3">允许回退之前步骤</asp:ListItem>
                                                            <asp:ListItem Value="2">允许回退上一步</asp:ListItem>
                                                            <asp:ListItem Value="1">不允许</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <strong>是否允许经办人回退：</strong>
                                                        <asp:DropDownList ID="JbHuitui" runat="server">
                                                            <asp:ListItem Value="1">不允许</asp:ListItem>
                                                            <asp:ListItem Value="2">允许回退上一步</asp:ListItem>
                                                            <asp:ListItem Value="3">允许回退之前步骤</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="nd8">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>办理意见：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <strong>是否允许主办查看办理意见：</strong>
                                                        <asp:DropDownList ID="YijianZb" runat="server">
                                                            <asp:ListItem Value="1">允许查看全部办理意见</asp:ListItem>
                                                            <asp:ListItem Value="2">只允许查看当前步骤办理意见</asp:ListItem>
                                                            <asp:ListItem Value="3">只允许查看用户个人办理意见</asp:ListItem>
                                                            <asp:ListItem Value="4">不允许</asp:ListItem>
                                                        </asp:DropDownList><br>
                                                        <strong>是否允许经办查看办理意见：</strong>
                                                        <asp:DropDownList ID="YijianJb" runat="server">
                                                            <asp:ListItem Value="1">允许查看全部办理意见</asp:ListItem>
                                                            <asp:ListItem Value="2">只允许查看当前步骤办理意见</asp:ListItem>
                                                            <asp:ListItem Value="3">只允许查看用户个人办理意见</asp:ListItem>
                                                            <asp:ListItem Value="4">不允许</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="nd4">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>主办人权限：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:CheckBoxList ID="ZbQuanxian" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="13" Selected="True">是否允许新增公共附件</asp:ListItem>
                                                            <asp:ListItem Value="2" Selected="True">是否允许下载公共附件</asp:ListItem>
                                                            <asp:ListItem Value="3" Selected="True">是否允许编辑公共附件</asp:ListItem>
                                                            <asp:ListItem Value="4" Selected="True">是否允许删除公共附件</asp:ListItem>
                                                            <asp:ListItem Value="12" Selected="True">是否允许转存公共附件</asp:ListItem>
                                                            <asp:ListItem Value="7" Selected="True">是否允许查看流转日志</asp:ListItem>
                                                            <asp:ListItem Value="8" Selected="True">是否允许编辑表单</asp:ListItem>
                                                            <asp:ListItem Value="14" Selected="True">办理中是否允许额外增加经办人</asp:ListItem>
                                                            <asp:ListItem Value="15" Selected="True" title="打印将会查看到所有的流转日志，办理意见，印章记录">是否允许打印</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr id="nd5">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>经办人权限：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:CheckBoxList ID="JbQuanxian" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="13" Selected="True">是否允许新增公共附件</asp:ListItem>
                                                            <asp:ListItem Value="2" Selected="True">是否允许下载公共附件</asp:ListItem>
                                                            <asp:ListItem Value="3" Selected="True">是否允许编辑公共附件</asp:ListItem>
                                                            <asp:ListItem Value="4" Selected="True">是否允许删除公共附件</asp:ListItem>
                                                            <asp:ListItem Value="12" Selected="True">是否允许转存公共附件</asp:ListItem>
                                                            <asp:ListItem Value="7" Selected="True">是否允许查看流转日志</asp:ListItem>
                                                            <asp:ListItem Value="8" Selected="True">是否允许编辑表单</asp:ListItem>
                                                            <asp:ListItem Value="14" Selected="True">办理中是否允许额外增加经办人</asp:ListItem>
                                                            <asp:ListItem Value="15" Selected="True" title="打印将会查看到所有的流转日志，办理意见，印章记录">是否允许打印</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>文号修改：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <strong>主办人：</strong>
                                                        <asp:DropDownList ID="WhZbSet" runat="server">
                                                            <asp:ListItem Value="1">允许修改</asp:ListItem>
                                                          <%--  <asp:ListItem Value="2">允许修改文号前缀</asp:ListItem>
                                                            <asp:ListItem Value="3">允许修改文号后缀</asp:ListItem>
                                                            <asp:ListItem Value="4">允许修改文号前后缀</asp:ListItem>--%>
                                                            <asp:ListItem Value="5">不允许修改</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <strong>经办人：</strong>
                                                        <asp:DropDownList ID="WhJbSet" runat="server">
                                                            <asp:ListItem Value="1">允许修改</asp:ListItem>
                                                          <%--  <asp:ListItem Value="2">允许修改文号前缀</asp:ListItem>
                                                            <asp:ListItem Value="3">允许修改文号后缀</asp:ListItem>
                                                            <asp:ListItem Value="4">允许修改文号前后缀</asp:ListItem>--%>
                                                            <asp:ListItem Value="5">不允许修改</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="nd11">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>可监控控件：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <strong>是否允许查看可监控控件操作日志：</strong>
                                                        <asp:DropDownList ID="Jiankong" runat="server">
                                                            <asp:ListItem Value="2">不允许</asp:ListItem>
                                                            <asp:ListItem Value="1">允许</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>邮件传阅设置：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <strong>是否允许邮件传阅：</strong>
                                                        <asp:DropDownList ID="Chuanyue" runat="server" onchange="select_cy();">
                                                            <asp:ListItem Value="2">不允许</asp:ListItem>
                                                            <asp:ListItem Value="1">允许</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr id="yj1">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>邮件接收人：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="YjRealname" runat="server" Width="600px" CssClass="ReadOnlyText"
                                                            Height="64px" TextMode="MultiLine"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openyjuser();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="yj3">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>邮件传阅项目：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:CheckBoxList ID="YoujianXm" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1" Selected="True">办理表单</asp:ListItem>
                                                            <asp:ListItem Value="2" Selected="True">公共附件</asp:ListItem>
                                                            <asp:ListItem Value="3" Selected="True">办理过程</asp:ListItem>
                                                            <asp:ListItem Value="4" Selected="True">办理日志</asp:ListItem>
                                                            <asp:ListItem Value="5" Selected="True">办理意见</asp:ListItem>
                                                        </asp:CheckBoxList>
                                                    </td>
                                                </tr>
                                                <tr id="yj2">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>传阅设置状态：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        在转交时是否允许修改传阅设置(传阅接收人和传阅项目)：
                                                        <asp:DropDownList ID="YjXiugai" runat="server" onchange="select_cy();">
                                                            <asp:ListItem Value="2">不允许</asp:ListItem>
                                                            <asp:ListItem Value="1">允许</asp:ListItem>
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
        <asp:TextBox ID="JbUsername" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowNumber" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="UpNodeNum" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ZbGuanlianID" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="JbGuanlianID" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="YjUsername" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	
 
            function  openyjuser()  
            {
                var  wName_1; 
                var num=Math.random();
                var str=""+document.getElementById('YjUsername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("YjUsername").value=arr[0]; 
                    document.getElementById("YjRealname").value=arr[1]; 
                }
            }
     
           
            function  openuser()  
            {   var  wName_3;  
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
            
            

          
            function  openuser1()  
            {    var  wName_1;  
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
            
            function IndexDemo()
            {
                var str1 = ""+document.getElementById("ZbUsername").value+",";
                var str2 = document.getElementById("JbUsername").value;
                
                var s = str2.indexOf(str1);

                if(s<0)
                {
                  document.form1.ZbUsername.value="";
                  document.form1.ZbRealname.value="";
                }
            }
        </script>

        <script language="javascript">	


            
            function  opengl_zb()  
            {  
            
                if (document.getElementById('XrGuize').value=="8")
                {
                    var  wName_3;  
                    var num=Math.random();
                    var str=""+document.getElementById('ZbGuanlianID').value+"|"+document.getElementById('ZbGuanlianName').value+"";
                    var str1=""+document.getElementById('JbGuanlianID').value+"";
                    wName_3=window.showModalDialog("/OpenWindows/open_juese.aspx?tmp="+num+"&requeststr="+str+"&user="+str1+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                    if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                    for(var i=0;i<arr.length;i++)
                    { 
                        document.getElementById("ZbGuanlianID").value=arr[0]; 
                        document.getElementById("ZbGuanlianName").value=arr[1]; 
                        
                        var strs = ""+document.getElementById("ZbGuanlianID").value+",";
                        var stre = document.getElementById("JbGuanlianID").value;
                        var s = stre.indexOf(strs);
                        if(s<0)
                        {
                           document.getElementById("JbGuanlianID").value=""+arr[0]+","; 
                           document.getElementById("JbGuanlianName").value=""+arr[1]+","; 
                        }
                    }
                }
          
                if (document.getElementById('XrGuize').value=="10")
                {
                
                    var  wName_3;  
                    var num=Math.random();
                    var str=""+document.getElementById('ZbGuanlianID').value+"|"+document.getElementById('ZbGuanlianName').value+"";
                    var str1=""+document.getElementById('JbGuanlianID').value+"";
                    wName_3=window.showModalDialog("/OpenWindows/open_zhiwei.aspx?tmp="+num+"&requeststr="+str+"&user="+str1+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                    if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                    for(var i=0;i<arr.length;i++)
                    { 
                        document.getElementById("ZbGuanlianID").value=arr[0]; 
                        document.getElementById("ZbGuanlianName").value=arr[1]; 
                        
                        var strs = ""+document.getElementById("ZbGuanlianID").value+",";
                        var stre = document.getElementById("JbGuanlianID").value;
                        var s = stre.indexOf(strs);
                        if(s<0)
                        {
                           document.getElementById("JbGuanlianID").value=""+arr[0]+","; 
                           document.getElementById("JbGuanlianName").value=""+arr[1]+","; 
                        }
                    }
                }

                if (document.getElementById('XrGuize').value=="13")
                {
                
                    var  wName_3;  
                    var num=Math.random();
                    var str=""+document.getElementById('ZbGuanlianID').value+"|"+document.getElementById('ZbGuanlianName').value+"";
                    var str1=""+document.getElementById('JbGuanlianID').value+"";
                    wName_3=window.showModalDialog("/OpenWindows/open_bumen.aspx?tmp="+num+"&requeststr="+str+"&user="+str1+"","window", "dialogWidth:550px;DialogHeight=480px;status:no;scroll=yes;help:no");                
                    if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                    for(var i=0;i<arr.length;i++)
                    { 
                        document.getElementById("ZbGuanlianID").value=arr[0]; 
                        document.getElementById("ZbGuanlianName").value=arr[1]; 
                        
                        var strs = ""+document.getElementById("ZbGuanlianID").value+",";
                        var stre = document.getElementById("JbGuanlianID").value;
                        var s = stre.indexOf(strs);
                        if(s<0)
                        {
                           document.getElementById("JbGuanlianID").value=""+arr[0]+","; 
                           document.getElementById("JbGuanlianName").value=""+arr[1]+","; 
                        }
                    }
                }
                
            }
            
            

           
            function  opengl_jb()  
            {   
                if (document.getElementById('XrGuize').value=="8")
                {
                    var  wName_1;  
                    var num=Math.random();
                    var str=""+document.getElementById('ZbGuanlianID').value+","+document.getElementById('JbGuanlianID').value+"";
                    wName_1=window.showModalDialog("/OpenWindows/open_juese_List.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                    if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                    for(var i=0;i<arr.length;i++)
                    { 
                        document.getElementById("JbGuanlianID").value=arr[0]; 
                        document.getElementById("JbGuanlianName").value=arr[1]; 
                        IndexDemo1();
                    }
                }
             
                if (document.getElementById('XrGuize').value=="10")
                {
                    var  wName_1;  
                    var num=Math.random();
                    var str=""+document.getElementById('ZbGuanlianID').value+","+document.getElementById('JbGuanlianID').value+"";
                    wName_1=window.showModalDialog("/OpenWindows/open_zhiwei_List.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                    if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                    for(var i=0;i<arr.length;i++)
                    { 
                        document.getElementById("JbGuanlianID").value=arr[0]; 
                        document.getElementById("JbGuanlianName").value=arr[1]; 
                        IndexDemo1();
                    }
                
                }
                if (document.getElementById('XrGuize').value=="13")
                {
                    var  wName_1;  
                    var num=Math.random();
                    var str=""+document.getElementById('ZbGuanlianID').value+","+document.getElementById('JbGuanlianID').value+"";
                    wName_1=window.showModalDialog("/OpenWindows/open_bumen_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                    if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                    for(var i=0;i<arr.length;i++)
                    { 
                        document.getElementById("JbGuanlianID").value=arr[0]; 
                        document.getElementById("JbGuanlianName").value=arr[1]; 
                        IndexDemo1();
                    }
                }
            }
            
            function IndexDemo1()
            {
                var str1 = ""+document.getElementById("ZbGuanlianID").value+",";
                var str2 = document.getElementById("JbGuanlianID").value;
                
                var s = str2.indexOf(str1);

                if(s<0)
                {
                  document.form1.ZbGuanlianID.value="";
                  document.form1.ZbGuanlianName.value="";
                }
            }



        </script>

    </form>
</body>
</html>
