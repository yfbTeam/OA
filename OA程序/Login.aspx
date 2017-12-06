<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="xyoa.Login" %>

<html>
<head id="Head1" runat="server">
    <title><%=ViewState["Titles"] %></title>
    <style>.STYLE1 {
	COLOR: #666; FONT-SIZE: 16px
}
.STYLE1 A {
	FONT-SIZE: 12px
}
.ieold 
{
	width:530px;
	height:30px;
	line-height:25px;
	color:#333333;
	text-align:center;
	position: absolute;
	left: 42%;
	top:90%;
	z-index:10000;
	border:1px solid #FFD685;
	background-color:#FFFFEE;
}
</style>
    <link rel="stylesheet" type="text/css" href="Css/css.css">

    <script type="text/javascript" src="js/jquery_select.js"></script>

    <script type="text/javascript" src="js/jquery-1.4.2.min.js"></script>

    <script src="/js/public.js" type="text/javascript"></script>
<SCRIPT language=javascript>
if (top.location != self.location){top.location=self.location; }
</SCRIPT>
<script>
function checkfrom()
{
    if(document.getElementById('Username').value=='')
    {
        alert('用户名不能为空');
        form1.Username.focus();
        return false;
    }	

    showwait();	
}  

function ieli()
{
document.getElementById('localeCode').value='main';
}  

function msgieli()
{ 
var ver=navigator.appVersion.substring(navigator.appVersion.indexOf("MSIE ")+5,navigator.appVersion.indexOf("MSIE ")+8);
if ( ver<7 ){
document.getElementById('ieli').style.display="";
}
else
{
document.getElementById('ieli').style.display="none";
}
}
</script>
</head>
<body onLoad="msgieli();">
    <form id="form1" runat="server">
        <table style="background-image: url(LoginBg/<%=ViewState["JmBg"] %>); background-position: center center"
            border="0" cellspacing="0" cellpadding="0" width="100%" align="center" height="100%">
            <tr>
                <td style="background-image: url(LoginBg/<%=ViewState["JmText"] %>); background-repeat: no-repeat;
                    background-position: center 50%" align="center">
                    <table border="0" cellspacing="0" cellpadding="0" width="829" height="242">
                        <tr>
                          <td height="242" width="456">&nbsp;                          </td>
                            <td valign="top" width="373" align="center">
                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                    <tr>
                                        <td height="60" valign="bottom" align="center">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="113">
                                            <table border="0" cellspacing="0" cellpadding="0" height="97">
                                                <tr>
                                                    <td class="STYLE1" height="42" nowrap>
                                                        &nbsp;&nbsp;&nbsp;&nbsp;账&nbsp;号：</td>
                                                    <td align="left">
                                                        <asp:TextBox ID="Username" runat="server" CssClass="TextBox"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 42px">
                                                        <span class="STYLE1">&nbsp;&nbsp;&nbsp;&nbsp;密&nbsp;码：</span></td>
                                                    <td align="left" style="height: 42px">
                                                        <asp:TextBox ID="Password" runat="server" CssClass="TextBox" TextMode="Password"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="38">
                                                        <span class="STYLE1">&nbsp;&nbsp;&nbsp;&nbsp;风&nbsp;格：</span></td>
                                                    <td nowrap align="left">
                                                        <table border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td>
                                                                    <div class="select">
                                                                        <select style="display: none" id="localeCode" name="localeCode"
                                                                            runat="server">
                                                                            <option  value="index">个性风格</option>
                                                                            <option selected value="main">标准风格</option>
                                                                        </select>
                                                                    </div>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                        </table>

                                                        <script type="text/javascript" src="js/jQselect.js"></script>

                                                        <script type="text/javascript">
	$(document).ready(function() {
		$("#localeCode").selectbox();
	});
                                                        </script>

                                                    </td>
                                                </tr>
                                                <tr <%=ViewState["yzmcss"] %>>
                                                    <td style="height: 42px">
                                                        &nbsp;&nbsp;&nbsp;&nbsp;<span class="STYLE1"><asp:Label ID="Label1" runat="server"
                                                            Text="验证码："></asp:Label></span></td>
                                                    <td align="left" style="height: 42px">
                                                        <asp:TextBox ID="codenum" runat="server" CssClass="TextBox"></asp:TextBox>
                                                        <asp:Image ID="Image1" runat="server" ImageUrl="CreateCheckCode.aspx" onclick="Change();"
                                                            Style="cursor: pointer" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td height="50">&nbsp;
                                                  </td>
                                                    <td valign="bottom" align="left">
                                                        <asp:Button ID="Button1" runat="server" CssClass="loginBtn" OnClick="Button1_Click"  />
                                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                                        <button class="resetBtn" onClick="javascript:myReset();">
                                                            </button>
                                                        &nbsp;</td>
                                                </tr>
                                            </table>
                                             <div class="ieold" id="ieli"  style="display: none;">
           提醒：当前IE版本过低，影响网页性能及软件美观，建议您切换为<a href="javascript:void(0)" onClick="ieli()"><font color="#0000FF">标准风格</font></a>或<a href="http://windows.microsoft.com/zh-CN/internet-explorer/downloads/ie" target=_blank><font color="#0000FF">升级IE版本</font></a></div>
                                        </td>
                                    </tr>
                                </table>
                          </td>
                        </tr>
                  </table>
                </td>
            </tr>
        </table>

        <script>
        function myReset(){
    document.all.Username.value = "";
    document.all.Password.value = "";
}
    	function Change()
			{
			  var strImg;
			  var obj = document.form1.Image1;
			  var strMath = Math.random();
			  obj.src = "CreateCheckCode.aspx?id"+strMath;
			}
        </script>

    </form>
</body>
</html>