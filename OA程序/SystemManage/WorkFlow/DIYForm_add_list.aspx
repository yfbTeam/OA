<%@ Page Language="C#" AutoEventWireup="true" Codebehind="DIYForm_add_list.aspx.cs"
    Inherits="xyoa.SystemManage.WorkFlow.DIYForm_add_list" %>

<html>
<head>
    <title>列表控件设定</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">

    <script>

function chknull()
{
    if(document.getElementById('Name').value=='')
    {
        alert('控件名称不能为空');
        form1.Name.focus();
        return false;
    }
    var yKeyFile = document.getElementById('Number').value;
    var yNumber = document.getElementById('TextBox2').value;
    var yName = document.getElementById('Name').value;
    var option_str="";
    for(i=1;i<=12;i++)
    {
      var gongsi_str="gongsi_"+i;
      var item_str="item_"+i;
      if(document.all(item_str).value!="")
      {
        option_str+=""+document.all(gongsi_str).value+"`";
      }
    }
  
    AjaxMethod.InsertLbKj(option_str,yKeyFile,yNumber,yName,'列表');
    my_submit();
   
}  

function my_submit()
{
  var yNumber = document.getElementById('TextBox2').value;
  var option_str="";
  var option_str1="";
  option_str+="<tr>";
  option_str1+="<tr id=\"i"+yNumber+"i1\" name=\"a1\">";
  for(i=1;i<=12;i++)
  {
      var item_str="item_"+i;
      if(document.all(item_str).value!="")
      {
        option_str+="<td  align=\"center\"  bgcolor=\"#FFFFFF\">"+document.all(item_str).value+"</td>";
        option_str1+="<td bgcolor=\"#FFFFFF\"><input disabled=\"disabled\" name=\""+yNumber+"_"+i+"\"></td>";
      }
  }
  option_str+="<td  bgcolor=\"#FFFFFF\">&nbsp;</td></tr>";
  option_str1+="<td  bgcolor=\"#FFFFFF\"><input type=\"button\" value=\"-\" onclick=\"return deleteRow(this,'T"+yNumber+"T')\" id=\"Button1\" name=\""+yNumber+"\"><button onclick=\"add('i"+yNumber+"i')\" name=\""+yNumber+"\">+</button></td></tr>";
  control_html="<table border=\"1\" id=\"T"+yNumber+"T\" name=\"T"+yNumber+"T\" cellpadding=\"1\"  bgcolor=\"#000000\" cellspacing=\"2\">"+option_str+""+option_str1+"</table>";

  window.opener.qiupengmodel(control_html);
  window.close();
}

    </script>

</head>
<body topmargin="0">
    <form id="form1" runat="server">
    </form>
    <table border="1" cellspacing="0" width="100%" cellpadding="3" align="center">
        <tr>
            <td colspan="2" nowrap="nowrap">
            </td>
        </tr>
        <tr>
            <td nowrap colspan="3">
                <input name="ITEM_NAME" type="text" size="20" style="display: none">
                <input type="button" value="确 定" id="Button1" onclick="chknull()">
            </td>
        </tr>
        <tr>
            <td nowrap colspan="3">
                控件名称：<input id="Name" type="text" name="Name" runat="server" size="20">
            </td>
        </tr>
        <tr>
            <td nowrap align="center" bgcolor="#cccccc">
                序号</td>
            <td nowrap align="center" title="Tab键切换输入框">
                表头名称&nbsp;&nbsp;
            </td>
            <td nowrap align="center" title="不设置公式可不填">
                计算公式&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td nowrap align="center">
                1</td>
            <td nowrap align="center" title="Tab键切换输入框">
                <input name="item_1" type="text" size="20">
            </td>
            <td nowrap align="center" title="不设置公式可不填">
                <input name="gongsi_1" type="text" size="20">
            </td>
        </tr>
        <tr>
            <td nowrap align="center">
                2</td>
            <td nowrap align="center" title="Tab键切换输入框">
                <input name="item_2" type="text" size="20"></td>
            <td nowrap align="center" title="不设置公式可不填">
                <input name="gongsi_2" type="text" size="20">
            </td>
        </tr>
        <tr>
            <td nowrap align="center">
                3</td>
            <td nowrap align="center" title="Tab键切换输入框">
                <input name="item_3" type="text" size="20"></td>
            <td nowrap align="center" title="不设置公式可不填">
                <input name="gongsi_3" type="text" size="20">
            </td>
        </tr>
        <tr>
            <td nowrap align="center">
                4</td>
            <td nowrap align="center" title="Tab键切换输入框">
                <input name="item_4" type="text" size="20"></td>
            <td nowrap align="center" title="不设置公式可不填">
                <input name="gongsi_4" type="text" size="20">
            </td>
        </tr>
        <tr>
            <td nowrap align="center">
                5</td>
            <td nowrap align="center" title="Tab键切换输入框">
                <input name="item_5" type="text" size="20"></td>
            <td nowrap align="center" title="不设置公式可不填">
                <input name="gongsi_5" type="text" size="20">
            </td>
        </tr>
        <tr>
            <td nowrap align="center">
                6</td>
            <td nowrap align="center" title="Tab键切换输入框">
                <input name="item_6" type="text" size="20"></td>
            <td nowrap align="center" title="不设置公式可不填">
                <input name="gongsi_6" type="text" size="20">
            </td>
        </tr>
        <tr>
            <td nowrap align="center">
                7</td>
            <td nowrap align="center" title="Tab键切换输入框">
                <input name="item_7" type="text" size="20"></td>
            <td nowrap align="center" title="不设置公式可不填">
                <input name="gongsi_7" type="text" size="20">
            </td>
        </tr>
        <tr>
            <td nowrap align="center">
                8</td>
            <td nowrap align="center" title="Tab键切换输入框">
                <input name="item_8" type="text" size="20"></td>
            <td nowrap align="center" title="不设置公式可不填">
                <input name="gongsi_8" type="text" size="20">
            </td>
        </tr>
        <tr>
            <td nowrap align="center">
                9</td>
            <td nowrap align="center" title="Tab键切换输入框">
                <input name="item_9" type="text" size="20"></td>
            <td nowrap align="center" title="不设置公式可不填">
                <input name="gongsi_9" type="text" size="20">
            </td>
        </tr>
        <tr>
            <td nowrap align="center">
                10</td>
            <td nowrap align="center" title="Tab键切换输入框">
                <input name="item_10" type="text" size="20"></td>
            <td nowrap align="center" title="不设置公式可不填">
                <input name="gongsi_10" type="text" size="20">
            </td>
        </tr>
        <tr>
            <td nowrap align="center">
                11</td>
            <td nowrap align="center" title="Tab键切换输入框">
                <input name="item_11" type="text" size="20"></td>
            <td nowrap align="center" title="不设置公式可不填">
                <input name="gongsi_11" type="text" size="20">
            </td>
        </tr>
        <tr>
            <td nowrap align="center">
                12</td>
            <td nowrap align="center" title="Tab键切换输入框">
                <input name="item_12" type="text" size="20"></td>
            <td nowrap align="center" title="不设置公式可不填">
                <input name="gongsi_12" type="text" size="20">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2" nowrap="nowrap">
                <input type="button" onclick="chknull();" value="确 定">
            </td>
        </tr>
    </table>
    <input id="Number" type="text" name="Number" runat="server" style="display: none">
    <input id="TextBox2" type="text" name="names" runat="server" style="display: none">
</body>
</html>
