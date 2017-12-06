<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyResApply_SearchListSy.aspx.cs"
    Inherits="xyoa.Resources.MyRes.MyResApply_SearchListSy" %>


<html>

<script>
function chknull()
{


    if(document.getElementById('Shuliang').value=='')
    {
        alert('申请数量不能为空，没有请填为０');
        form1.Shuliang.focus();
        return false;
    }	
 
 
    if(document.getElementById('Shuliang').value!='')
    {    
        var objRe = /^\d+(\.\d+)?$/;
        if(!objRe.test(document.getElementById('Shuliang').value))
        {
            alert("申请数量只能为正数");
            form1.Shuliang.focus();
            return false;
        }

    }   
    
    
    
    
    showwait();					
}

function _change()
{
   var text=form1.normalcontent.value;
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        物品编号：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="ZyNum" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        物品名称：</td>
                                                    <td class="newtd2" height="17" width="35%">
                                                        <asp:Label ID="ZyName" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        物品型号：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="Xinghao" runat="server"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        物品描述：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:Label ID="ZyIntro" runat="server" Text=""></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        所属仓库：</td>
                                                    <td class="newtd2" width="33%" style="height: 17px">
                                                        <asp:Label ID="Cangku" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        所属区域：</td>
                                                    <td class="newtd2" width="35%" style="height: 17px">
                                                        <asp:Label ID="Quyu" runat="server"></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="17%" style="height: 17px">
                                                        当前库存：
                                                    </td>
                                                    <td class="newtd2" width="83%" style="height: 17px" colspan="3">
                                                        <asp:Label ID="KuCun" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>审批信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        <font color="red">※</font>申请数量：</td>
                                                    <td class="newtd2" height="17" width="83%" colspan="3">
                                                        <asp:TextBox ID="Shuliang" runat="server" Width="100%">1</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        申请理由：</td>
                                                    <td class="newtd2" height="17" colspan="3">
                                                        <asp:TextBox ID="Liyou" runat="server" Width="100%" Height="101px" TextMode="MultiLine"
                                                            MaxLength="2000"></asp:TextBox></td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17" align="center">
                                                        <b>审批转交信息</b></td>
                                                </tr>
                                                            <tr id="Tr1">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>审批流程(<a href="javascript:void(0)" onclick="OpenWfPic(''+document.getElementById('FormId').value+'')">查看</a>)：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="FormId" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="FormId_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>转交步骤：</td>
                                                    <td class="newtd2" height="17" width="85%" colspan="3">
                                                        <asp:RadioButtonList ID="FormName" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="FormName_SelectedIndexChanged"
                                                            AutoPostBack="True">
                                                        </asp:RadioButtonList></td>
                                                </tr>
                                                <tr id="nd1">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        <font color="red">※</font>主办人：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="ZbRealname" runat="server" CssClass="ReadOnlyText" Width="241px"></asp:TextBox><input
                                                            id="Button9" type="button" value="选择主办人" onclick="opengw()" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr class="">
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="17%">
                                                        常用评语：</td>
                                                    <td class="newtd2" colspan="3" height="17" width="83%">
                                                        <asp:DropDownList ID="normalcontent" runat="server" onchange="_change()" Width="100%">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" nowrap="nowrap" width="15%" style="height: 17px">
                                                        办理意见：</td>
                                                    <td class="newtd2" width="85%" colspan="3" style="height: 17px">
                                                        <asp:TextBox ID="Yijian" runat="server" Width="100%" MaxLength="500"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button1" runat="server" Text="提 交" CssClass="button_css" OnClick="Button1_Click" />
                                                                 <input id="Button3" type="button" value="返 回" class="button_css" onclick="history.go(-1)" /></font></div>
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
        <input id="YjbNodeId" type="hidden" runat="server" />
        <input id="NodeName" type="hidden" runat="server" />
        <asp:TextBox ID="ZbUsername" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="Number" runat="server" Style="display: none"></asp:TextBox>
        <asp:TextBox ID="ZyId" runat="server" Style="display: none"></asp:TextBox>
        
   <script>
           var  wName_5;  
            function  opengw()  
            {  
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
         
        </script>
    </form>
</body>
</html>
