﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="smsmodle1.aspx.cs" Inherits="xyoa.MyWork.txl.smsmodle1" %>
<html >
<script>
function chknull()
{
    if(document.getElementById('Name').value=='')
    {
    alert('姓名不能为空');
    form1.Name.focus();
    return false;
    }	
    
    
    if(document.getElementById('MoveTel').value=='')
    {
    alert('手机号不能为空');
    form1.MoveTel.focus();
    return false;
    }	


    if(document.getElementById('Msg').value=='')
    {
    alert('发送内容不能为空');
    form1.Msg.focus();
    return false;
    }	
    
    showwait();	
}  

</script>


<head id="Head1" runat="server">
    <title><%=Session["Titles"]%></title>
     <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
     <script src="/js/public.js" type="text/javascript"></script>
</head>
<body class="newbody">
    <form id="form1" runat="server">
<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
  <tr>
    <td valign="top"><table width="100%"  border="0" cellpadding="0" cellspacing="0">
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
                <td width="17"></td>
                <td valign="top"> <table width="100%" height="24" border="0" cellpadding="0" cellspacing="0">
                    <tr> 
                      <td width="3%"><img src="/oaimg/top_3.gif" ></td>
                       <td width="81%" valign="bottom">工作台 >> 单位通讯录 >> 发送手机短信息</td>
                      <td width="81%"></td>
                    </tr>
                  </table>
                  <table width="100%" height="6" border="0" cellpadding="0" cellspacing="0"  class="nexttop">
                    <tr> 
                      <td></td>
                    </tr>
                  </table></td>
                <td width="17"></td>
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
                <td width="17"></td>
                <td valign="top"> 
           <table align="center" background="/<%=Session["yangshi"]%>/bg0003.gif" border="0" cellpadding="0"
                        cellspacing="0" width="100%">
                        <tr>
                            <td width=30% style="height: 26px">
                                <button class="btn4off" 
                                    type="button">
                                    <font class="shadow_but">单位通讯录</font></button></td>
                              <td style="height: 26px" align="right" > </td>
                        </tr>
                    </table>
                </td>
                <td width="17"></td>
              </tr>
            </table>
            </div>
            <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="17">
                        </td>
                    <td valign="top" >
                  
                        <table align="center"  border="0" cellpadding="4" cellspacing="1"
                            width="100%" class="nextpage">
                       <tr>
                                <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                    <b> 基本信息</b></td>
                            </tr>
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    姓名：</td>
                                <td class="newtd2" colspan="3" height="17" width=83%>
                                    <asp:TextBox ID="Name" runat="server" Width="100%" ></asp:TextBox>
                                </td>
                            </tr>
                            
                            
                            <tr>
                                <td align="right" class="newtd1" nowrap="nowrap"
                                    width="17%" style="height: 17px">
                                    手机：</td>
                                <td class="newtd2" colspan="3" style="height: 17px">
                                    <asp:TextBox ID="MoveTel" runat="server" Width="100%"></asp:TextBox></td>
                            </tr>
                            
                            <tr>
                                <td align="right" class="newtd1" height="17" nowrap="nowrap"
                                    width="17%">
                                    发送内容：</td>
                                <td class="newtd2" height="17" colspan="3">
                                    <asp:TextBox ID="Msg" runat="server" TextMode="MultiLine" Width="100%" Height="47px"></asp:TextBox></td>
                            </tr>
                            <tr  id="printshow3">
                                <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                    	<div align="center"><FONT face="宋体">
                                <asp:Button ID="Button1" runat="server" Text="确 定" CssClass="button_css" OnClick="Button1_Click" />
                                &nbsp; &nbsp; &nbsp;<asp:Button ID="Button2" runat="server" Text="关 闭" CssClass="button_css" />
                             
								</FONT>
							</div> </td>
                            </tr>
                          
                        </table>
                        
           
                        
                    </td>
                    <td width="17" >
                        </td>
                </tr>
            </table>
          </td>
        </tr>
      </table></td>
  </tr>
</table>

 
    
    
    </form>
</body>
</html>