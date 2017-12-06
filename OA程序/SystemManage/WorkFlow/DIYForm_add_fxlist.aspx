﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DIYForm_add_fxlist.aspx.cs" Inherits="xyoa.SystemManage.WorkFlow.DIYForm_add_fxlist" %>
<html>
<head>
<title>复选框列表设定</title>
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
    
    AjaxMethod.InsertLb(yKeyFile,yNumber,yName,'复选框列表');
    my_submit();
   
}  

function my_submit()
{
  var yNumber = document.getElementById('TextBox2').value;
  var option_str="";
  option_str+="<tr>";
  for(i=1;i<=50;i++)
  {
      var item_str="item_"+i;
      if(document.all(item_str).value!="")
      {
        option_str+="<td  bgcolor=\"#FFFFFF\"><input id=\""+yNumber+"_0\" type=\"checkbox\" name=\""+yNumber+"\" value=\""+document.all(item_str).value+"\" />"+document.all(item_str).value+"</td>";
      }
  }
  control_html="<table  border=\"0\"  name=\""+yNumber+"\">"+option_str+"</table>";

  window.opener.qiupengmodel(control_html);
  window.close();
}

</script>
</head>

<body topmargin="0">
<form id="form1" runat="server"></form>
<table border="1" cellspacing="0" width="100%"  cellpadding="3" align="center">
    <tr>
        <td colspan="2" nowrap="nowrap">
        
        </td>
    </tr>
  <tr >
      <td nowrap colspan="2">
      <Input name="ITEM_NAME" type="text"  size="20"   style="DISPLAY: none">
      <input type="button"  value="确 定" id="Button1" onclick="chknull()">
      </td>
  </tr>
    <tr >
      <td nowrap colspan="2">控件名称：<INPUT id="Name" type="text" name="Name" runat="server" size="20">
   
      </td>
  </tr>
  <tr>
      <td nowrap align="center"　bgcolor="#cccccc">序号</td>
      <td nowrap align="center" title="Tab键切换输入框"　 >输入列表项目&nbsp;&nbsp;
      </td>
  </tr>
  <tr >
      <td nowrap align="center">1</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_1" type="text" size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">2</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_2" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">3</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_3" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">4</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_4" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">5</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_5" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">6</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_6" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">7</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_7" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">8</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_8" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">9</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_9" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">10</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_10" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">11</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_11" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">12</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_12" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">13</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_13" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">14</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_14" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">15</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_15" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">16</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_16" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">17</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_17" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">18</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_18" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">19</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_19" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">20</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_20" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">21</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_21" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">22</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_22" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">23</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_23" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">24</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_24" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">25</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_25" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">26</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_26" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">27</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_27" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">28</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_28" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">29</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_29" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">30</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_30" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">31</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_31" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">32</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_32" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">33</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_33" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">34</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_34" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">35</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_35" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">36</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_36" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">37</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_37" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">38</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_38" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">39</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_39" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">40</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_40" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">41</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_41" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">42</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_42" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">43</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_43" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">44</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_44" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">45</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_45" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">46</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_46" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">47</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_47" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">48</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_48" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">49</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_49" type="text"  size="30"></td>
  </tr>
  <tr >
      <td nowrap align="center">50</td>
      <td nowrap align="center" title="Tab键切换输入框"><Input name="item_50" type="text"  size="30"></td>
  </tr>
    <tr>
        <td align="center" colspan="2" nowrap="nowrap" >
         <input type="button" onclick="chknull();" value="确 定" >
        </td>
    </tr>

  </table>
  <INPUT id="Number" type="text" name="Number" runat="server" Style="display: none">
<INPUT id="TextBox2" type="text" name="names" runat="server" Style="display: none">

</body>
</html>