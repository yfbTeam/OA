<%@ Page Language="C#" AutoEventWireup="true" Codebehind="FlowMg_list_update.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.FlowMg_list_update" %>

<html>

<script>
function chknull()
{
    if(document.getElementById('FlowName').value=='')
    {
        alert('流程名称不能为空');
        form1.FlowName.focus();
        return false;
    }
    
    if(document.getElementById('Paixun').value=='')
    {
        alert('排序号不能为空');
        form1.Paixun.focus();
        return false;
    }	
   
    if(document.getElementById('Paixun').value!='')
    {
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Paixun').value))
        {
            alert("排序号只能为正数");
            form1.Paixun.focus();
            return false;
        }
    }
    
    if(document.getElementById('BianhaoJs').value=='')
    {
        alert('自动编号计数器不能为空');
        form1.BianhaoJs.focus();
        return false;
    }	
   
    if(document.getElementById('BianhaoJs').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('BianhaoJs').value))
        {
            alert("自动编号计数器只能为正数");
            form1.BianhaoJs.focus();
            return false;
        }
    }
    
    
    if(document.getElementById('BianhaoWs').value=='')
    {
        alert('自动编号位数不能为空');
        form1.BianhaoWs.focus();
        return false;
    }	
   
    if(document.getElementById('BianhaoWs').value!='')
    {
        var objRe = /^(0|[1-9]\d*)$/;
        if(!objRe.test(document.getElementById('BianhaoWs').value))
        {
            alert("自动编号位数只能为正数");
            form1.BianhaoWs.focus();
            return false;
        }
    }    
    
    
    showwait();	
}  


function  setall1()  
{
    document.getElementById('JkUsername').value='0';
    document.getElementById('JkRealname').value='全部用户';
}



function  setall3()  
{
    document.getElementById('CxUsername').value='0';
    document.getElementById('CxRealname').value='全部用户';
}

function my_tip()
{
   if(document.getElementById("tip").style.display=="none")
      document.getElementById("tip").style.display="";
   else
   	  document.getElementById("tip").style.display="none";
}

function select_faqi()
{
   if (form1.States.value=="1")
   {
       trDept.style.display='none';
       trUser.style.display='none';
   }
   else if (form1.States.value=="2")
   {
       trDept.style.display='';       
       trUser.style.display='none';
   }
   else if (form1.States.value=="3")
   {
       trDept.style.display='none';
       trUser.style.display='';
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

</head>
<body class="newbody" onload="select_faqi()">
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
                                                            修改工作流</td>
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
                                                    <td align="center" class="newtd2" height="17" nowrap="nowrap" colspan="4">
                                                        <b>流程基本属性</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>对应表单：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="FormId" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>排序号：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Paixun" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>流程名称：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="FlowName" runat="server" Width="100%" MaxLength="25"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>流程状态：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="FlowType" runat="server" Width="100%">
                                                            <asp:ListItem>正常</asp:ListItem>
                                                            <asp:ListItem>停止</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>允许查询用户：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="CxRealname" runat="server" Width="100%" Height="58px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <input id="Button2" type="button" value="选择用户" onclick="openuser3()" /><input id="Button4"
                                                            type="button" value="全部用户" onclick="setall3()" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>允许监控用户：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="JkRealname" runat="server" Width="100%" Height="58px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <input id="Button6" type="button" value="选择用户" onclick="openuserjk()" /><input id="Button7"
                                                            type="button" value="全部用户" onclick="setall1()" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font> 流程发起权限：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="States" runat="server" Width="100%" onchange="select_faqi()">
                                                            <asp:ListItem Value="1">全部</asp:ListItem>
                                                            <asp:ListItem Value="2">对指定部门开放</asp:ListItem>
                                                            <asp:ListItem Value="3">对指定人员开放</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr id="trDept" style="display: none">
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        选择部门（对指定部门开放）：</td>
                                                    <td class="newtd2" colspan="3" width="85%" style="height: 17px">
                                                        <asp:TextBox ID="ZdBumen" runat="server" Height="58px" TextMode="MultiLine" Width="85%"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openunit();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr id="trUser" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        选择人员（对指定人员开放）：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="ZdRealname" runat="server" Width="85%" Height="58px" TextMode="MultiLine"
                                                            CssClass="ReadOnlyText"></asp:TextBox>
                                                        <a href="javascript:void(0)">
                                                            <img onclick="openuser1();" alt="" src="/oaimg/FDJ.gif" border="0"></a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>流程属性：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="ShuXing" runat="server" Width="100%">
                                                            <asp:ListItem>固定流程</asp:ListItem>
                                                            <asp:ListItem>自由流程</asp:ListItem>
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>归档目录：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="OverSetCon" runat="server" Width="90%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                   <tr>
                                                    <td align="right" class="newtd1" height="17"  width="15%">
                                                        <font color="red">※</font>是否允许发起人保存模板：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:RadioButtonList ID="Muban" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1">允许</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="0">不允许</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                
                                                <tr>
                                                    <td align="center" class="newtd2" height="17" nowrap="nowrap" colspan="4">
                                                        <b>工作名称/文号的设定</b></td>
                                                </tr>
                                                  <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>是否关联表单字段：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="Guanlian" runat="server">
                                                            <asp:ListItem Value="1">是</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="0">否</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>关联字段：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="GlZiduan" runat="server">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>自动文号表达式：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="Wenhao" runat="server" Width="90%"></asp:TextBox><a href="javascript:my_tip()">查看说明</a>
                                                    </td>
                                                </tr>
                                                <tr id="tip" style="display: none">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        说明：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        表达式中可以使用以下特殊标记：<br>
                                                        {Y}：表示年<br>
                                                        {M}：表示月<br>
                                                        {D}：表示日<br>
                                                        {H}：表示时<br>
                                                        {I}：表示分<br>
                                                        {S}：表示秒<br>
                                                        {W}：表示星期<br>
                                                        {F}：表示流程名<br>
                                                        {U}：表示用户姓名<br>
                                                        {DN}：部门排序号<br>
                                                        {SD}：表示短部门<br>
                                                        {LD}：表示长部门<br>
                                                        {R}：表示角色<br>
                                                        {N}：表示编号，通过 <u>编号计数器</u> 取值并自动增加计数值<br>
                                                        <br>
                                                        例如，表达式为：成建委发[{Y}]{N}号，编号位数为4<br>
                                                        自动生成文号如：成建委发[2006]0001号<br>
                                                        <br>
                                                        例如，表达式为：BH{N}，编号位数为3<br>
                                                        自动生成文号如：BH001<br>
                                                        <br>
                                                        例如，表达式为：{F}流程（{Y}年{M}月{D}日{H}:{I}）{U}<br>
                                                        自动生成文号如：请假流程（2006年01月01日10:30）张三<br>
                                                        <br>
                                                        可以不填写自动文号表达式，则系统默认按以下格式，如：<br>
                                                        请假流程(2006-01-01 10:30:30)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>自动编号计数器：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="BianhaoJs" runat="server" Width="65%">1</asp:TextBox>同一流程下编号开始的数字
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>自动编号位数：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="BianhaoWs" runat="server" Width="100%">1</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                           <asp:Button ID="Button5" runat="server" Text="保存并返回" CssClass="button_css" OnClick="Button1_Click1" />
                                                                <asp:Button ID="Button8" runat="server" CssClass="button_css" Text="不保存并返回" OnClick="Button2_Click" />
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
   
        <asp:TextBox ID="JkUsername" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="FlowNumber" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="CxUsername" runat="server" Style="display: none"></asp:TextBox>

        <script language="javascript">	


           
            function  openuserjk()  
            {   var  wName_1;  
                var num=Math.random();
                var str=""+document.getElementById('JkUsername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:680px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("JkUsername").value=arr[0]; 
                    document.getElementById("JkRealname").value=arr[1]; 
                }
            }
            
          
            function  openuser3()  
            {    var  wName_3;  
                var num=Math.random();
                var str=""+document.getElementById('CxUsername').value+"";
                wName_3=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_3 == undefined) {wName_3 = window.returnValue;}var arr = wName_3.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("CxUsername").value=arr[0]; 
                    document.getElementById("CxRealname").value=arr[1]; 
                }
            }
            
            
        </script>
        <asp:TextBox ID="ZdBumenId" runat="server" Width="90%" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ZdUsername" runat="server" Width="90%" Style="display: none"></asp:TextBox>

        <script language="javascript">	
          
            function  openunit()  
            {   
                var  wName_2;  
                var num=Math.random();
                var str=""+document.getElementById('ZdBumenId').value+"";
                wName_2=window.showModalDialog("/OpenWindows/open_bumen_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:650px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_2 == undefined) {wName_2 = window.returnValue;}var arr = wName_2.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("ZdBumenId").value=arr[0]; 
                    document.getElementById("ZdBumen").value=arr[1]; 
                }
            }



          
            function  openuser1()  
            {    
                var  wName_1;  
                var num=Math.random();
                var str=""+document.getElementById('ZdUsername').value+"";
                wName_1=window.showModalDialog("/OpenWindows/open_user_list.aspx?tmp="+num+"&requeststr="+str+"","window", "dialogWidth:750px;DialogHeight=580px;status:no;scroll=yes;help:no");                
                if (wName_1 == undefined) {wName_1 = window.returnValue;}var arr = wName_1.split("|");
                for(var i=0;i<arr.length;i++)
                { 
                    document.getElementById("ZdUsername").value=arr[0]; 
                    document.getElementById("ZdRealname").value=arr[1]; 
                }
            }
            
            
        </script>
    </form>
</body>
</html>
