<%@ Page Language="C#" AutoEventWireup="true" Codebehind="MyWebDisk_add.aspx.cs"
    Inherits="xyoa.PublicWork.WebDisk.MyWebDisk_add" %>

<html>
<head id="Head1" runat="server">
    <title>
        <%=Session["Titles"]%>
    </title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script src="/js/public.js" type="text/javascript"></script>

   <script type="text/javascript" src="/js/jquery.js"></script>

    <script>
function chknull()
{
    if(document.getElementById('TypeId').value=='')
    {
    alert('请选择目录');
    form1.TypeId.focus();
    return false;
    }	

    showwait();	
}  


    </script>

    <script type="text/javascript">
        $(document).ready(function(){
           $("#btnAddFile").bind("click",function(){
              $(this).before("<div><input type='file' id='file'  name='file' /><input  type='button' value='移除' onclick='RemoveFile(this)'/></div>"); 
           });
        });
        function RemoveFile(obj){
           $(obj).parent().remove(); 
        }
    </script>
</head>
<body class="newbody">
      <form id="form1" runat="server" enctype="multipart/form-data">
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
                                <table width="100%" height="35" border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="17">
                                            </td>
                                        <td valign="top">
                                            <table align="center" border="0" cellpadding="4" cellspacing="1" width="100%" class="nextpage">
                                                <tr>
                                                    <td align="center" class="newtd2" colspan="4" width="33%" style="height: 26px">
                                                        <b>文件信息</b></td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                         <font color="red">※</font>所属目录：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <asp:DropDownList ID="TypeId" runat="server" Width="100%">
                                                        </asp:DropDownList></td>
                                                </tr>
                                                  <tr>
                                                    <td align="right" class="newtd1" height="17" nowrap="nowrap" width="15%">
                                                        附件：</td>
                                                    <td class="newtd2" height="17" colspan="3" width="85%">
                                                        <div>
                                                            <input type='file' id='file' name='file' /></div>
                                                        <input type="button" value="添加上传框" id="btnAddFile" />
                                                        <asp:Label ID="lblMessage" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="printshow3">
                                                    <td align="center" class="newtd2" colspan="4" height="26" width="33%">
                                                        <div align="center">
                                                            <font face="宋体">
                                                                <asp:Button ID="Button2" runat="server" Text="提 交" CssClass="button_css" OnClick="Button2_Click" />
                                                                <asp:Button ID="Button1" runat="server" CssClass="button_css" OnClick="Button1_Click"
                                                                    Text="返 回" /></font></div>
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
    </form>
</body>
</html>
