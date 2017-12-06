<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Yuangong_add.aspx.cs" Inherits="xyoa.HumanResources.Employee.Yuangong.Yuangong_add" %>

<html>

<script>
function chknull()
{

    if(document.getElementById('Username').value=='')
    {
    alert('用户名不能为空');
    form1.Username.focus();
    return false;
    }	

    if(document.getElementById('Username').value!='')
    {
        var objRe = /^[A-Za-z0-9]+$/;
        if(!objRe.test(document.getElementById('Username').value))
        {
            alert('用户名建议使用字母或数字');
            form1.Username.focus();
            return false;
        }
    }

    if(document.getElementById('Password').value=='')
    {
    alert('用户密码不能为空');
    form1.Password.focus();
    return false;
    }	
    
    if(document.getElementById('JueseId').value=='')
    {
    alert('角色不能为空');
    form1.JueseId.focus();
    return false;
    }	


    if(document.getElementById('Xingming').value=='')
    {
        alert('姓名不能为空');
        form1.Xingming.focus();
        return false;
    }	
    
    if(document.getElementById('Bumen').value=='')
    {
        alert('部门不能为空');
        form1.Bumen.focus();
        return false;
    }	

    if(document.getElementById('Zhiwei').value=='')
    {
        alert('职位不能为空');
        form1.Zhiwei.focus();
        return false;
    }	
    

    showwait();	
}  

var k=window.dialogArguments; 
//获得父窗口传递来的值 

function winClose(isRefrash) 
{ 
    alert('新增成功！');
    window.returnValue=isRefrash; 
    window.close(); 
} 

</script>

<head id="Head1" runat="server">
    <title>新增员工档案 </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script src="/DatePicker/WdatePicker.js" type="text/javascript"></script>

    <base target="_self" />
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
                                                                <font class="shadow_but">员工档案</font></button></td>
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
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <b>系统信息</b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>系统用户：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Username" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>系统角色：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="JueseId" runat="server" Width="100%">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>用户密码：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Password" runat="server" Width="100%">123</asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>允许登陆：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:RadioButtonList ID="Iflogin" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Value="1">是</asp:ListItem>
                                                            <asp:ListItem Value="0" Selected="True">否</asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <b>基本信息</b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>姓名：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Xingming" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        编号：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Bianhao" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr class="" id="nextrs23">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        员工相片：</td>
                                                    <td class="newtd2" height="17" width="33%" colspan="3">
                                                        <input id="uploadFile" runat="server" style="width: 658px" type="file" name="uploadFile" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>性别：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:RadioButtonList ID="Xingbie" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="1">男</asp:ListItem>
                                                            <asp:ListItem Value="2">女</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        出生日期：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Chusheng" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                       
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        民族：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Mingzhu" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        籍贯：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Jiguan" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        政治面貌：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Mianmao" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>婚姻状况：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:RadioButtonList ID="Hunyin" runat="server" RepeatDirection="Horizontal">
                                                            <asp:ListItem Selected="True" Value="2">未婚</asp:ListItem>
                                                            <asp:ListItem Value="1">已婚</asp:ListItem>
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        学历：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Xuexi" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        毕业院校：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Yuanxiao" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        专业：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Zhuanye" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        身份证号码：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Shenfenzheng" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <b>联系方式</b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        户口所在地：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Hukou" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        电话：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Jiating" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        电子邮箱：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Youxiang" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        家庭住址：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Dizhi" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        传真：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Chuanzhen" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        手机：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Shouji" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        QQ号：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="QQ" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        MSN：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="MSN" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        内部即时通：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Neibu" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        邮政编码：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="Youbian" runat="server" Width="100%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <b>工作信息</b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>所在部门：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Bumen" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        员工类型：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Leixing" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>职位：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Zhiwei" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        职称：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:DropDownList ID="Zhicheng" runat="server" Width="100%">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        参加工作时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="CjShijian" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                      
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        进入单位时间：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:TextBox ID="JrShijian" runat="server" onClick="WdatePicker()"></asp:TextBox>
                                                     
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <b>其他信息</b>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        社会关系：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="Shehui" runat="server" Width="100%" Height="58px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        工作经历：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="GzJingli" runat="server" Width="100%" Height="58px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        学习经历：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="XxJingli" runat="server" Width="100%" Height="58px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap">
                                                        备注：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="Beizhu" runat="server" Width="100%" Height="58px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="26" width="33%">
                                                        <asp:CheckBox ID="CheckBox2" runat="server" Text="同步录入单位通讯录" Checked="True"></asp:CheckBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                &nbsp; &nbsp;
                                                                <input id="Button2" type="button" value="关 闭" onclick="window.close()" class="button_css" />
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
        <asp:TextBox ID="Jineng" runat="server" Width="100%" Height="58px" TextMode="MultiLine"
            Visible="false"></asp:TextBox>
        <asp:TextBox ID="Tijian" runat="server" Width="100%" Height="58px" TextMode="MultiLine"
            Visible="false"></asp:TextBox>
        <asp:TextBox ID="Jiangcheng" runat="server" Width="100%" Height="58px" TextMode="MultiLine"
            Visible="false"></asp:TextBox>
    </form>
</body>
</html>
