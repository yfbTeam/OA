<%@ Page Language="C#" AutoEventWireup="true" Codebehind="reg.aspx.cs" Inherits="xyoa.reg" %>

<html>
<head id="Head1" runat="server">
    <title>系统注册 </title>
    <link href="/bluecss/oa.css" type="text/css" rel="stylesheet">
    <link href="/bluecss/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

    <script>
	    function CheckForm()
		{
			if(document.getElementById("TextBox1").value == "")
			{
				alert("序列号不能为空！");
				return (false);
			}
			
			if(!document.form1.UserRead.checked)
           { alert("您必须同意软件使用条款，才能进行软件注册！");
             return (false);
           }
			return true;
		}
		
        function copy_code()
        {
          textRange = document.form1.TextBox2.createTextRange();
          textRange.execCommand("Copy");
          alert('复制成功');
        }
        
        function paste_code()
        {
          textRange = document.form1.TextBox1.createTextRange();
          textRange.execCommand("paste");
          alert('粘贴成功');
        }
    </script>

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
                                                            系统注册</td>
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
                                                <table align="center" background="/bluecss/bg0003.gif" border="0" cellpadding="0"
                                                    cellspacing="0" width="100%">
                                                    <tr>
                                                        <td width="30%" style="height: 26px">
                                                            <button class="btn4off" type="button">
                                                                <font class="shadow_but">系统注册</font></button></td>
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
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        服务器机器码：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="TextBox2" runat="server" Width="90%"></asp:TextBox><input id="Button1"
                                                            type="button" value="复 制" onclick="copy_code()" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        软件加密码：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:TextBox ID="TextBox1" runat="server" Width="90%"></asp:TextBox><input id="Button2"
                                                            type="button" value="粘 贴" onclick="paste_code()" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        服务条款：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%" style="line-height: 215%">
                                                        1、首先，请与软件供应商联系购买事宜，从而获得软件序列号。<br>
                                                        2、注意，软件序列号是软件正版的唯一凭证，凭借软件序列号可享受相关售后服务，如软件销售商不能提供软件序列号，则说明其所销售的软件是盗版。
                                                        <br>
                                                        3、您不得以任何目的，对软件进行破解、反编译、反向工程、修改软件版权信息等操作。
                                                        <br>
                                                        4、如使用未经授权的注册文件注册，或进行软件破解操作，由此产生的一切直接、间接、可能或必然的损失，均由使用者自行承担，并同时承担版权侵权的法律责任。
                                                        <br>
                                                        <input type="checkbox" name="UserRead" size="20" id="UserRead">
                                                        <label for="UserRead" style="cursor: hand">
                                                            <u><b>我已经阅读以上条款，并且完全理解和同意以上条款</b></u></label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="newtd2" colspan="4" height="17" style="text-align: center">
                                                        <asp:Button ID="Button3" runat="server" Text="软件注册" OnClick="Button3_Click1" />
                                                        <asp:Button ID="Button4" runat="server" Text="返回首页" OnClick="Button4_Click" />
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

        <script type="text/javascript">
            try{
                parent.closeAlert('UploadChoose');
            }
            catch(err){
            }
        </script>

    </form>
</body>
</html>
