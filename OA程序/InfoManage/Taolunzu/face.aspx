<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="face.aspx.cs" Inherits="xyoa.InfoManage.Taolunzu.face" %>

<html>
<head id="Head1" runat="server">
    <title>选择表情</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">

    <script>
        function face(urlstr)
        {
          //parent.opener.document.getElementById('content').value='11';
          //window.close();
          
          window.returnValue=urlstr;  
          window.close();  
        }
        
        window.onbeforeunload = function()  
        {
            var n = window.event.screenX - window.screenLeft;
            var b = n > document.documentElement.scrollWidth-20;
            if(b && window.event.clientY < 0 || window.event.altKey)
            {
               window.returnValue="";
            }
        }   
    </script>

</head>
<body>
    <br>
    <table width="336" border="0" align="center" cellpadding="2" cellspacing="1" bgcolor="#999999">
        <tr>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<微笑>')">
                    <img src="/oaimg/Face/0.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<撇嘴>')">
                    <img src="/oaimg/Face/1.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<色>')">
                    <img src="/oaimg/Face/2.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<发呆>')">
                    <img src="/oaimg/Face/3.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<得意>')">
                    <img src="/oaimg/Face/4.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<流泪>')">
                    <img src="/oaimg/Face/5.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<害羞>')">
                    <img src="/oaimg/Face/6.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<闭嘴>')">
                    <img src="/oaimg/Face/7.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<睡>')">
                    <img src="/oaimg/Face/8.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<大哭>')">
                    <img src="/oaimg/Face/9.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<尴尬>')">
                    <img src="/oaimg/Face/10.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<发怒>')">
                    <img src="/oaimg/Face/11.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<调皮>')">
                    <img src="/oaimg/Face/12.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<呲牙>')">
                    <img src="/oaimg/Face/13.gif" width="24" height="24" border="0"></a></td>
        </tr>
        <tr>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<惊呆>')">
                    <img src="/oaimg/Face/14.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<难过>')">
                    <img src="/oaimg/Face/15.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<酷>')">
                    <img src="/oaimg/Face/16.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<冷汗>')">
                    <img src="/oaimg/Face/17.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<抓狂>')">
                    <img src="/oaimg/Face/18.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<吐>')">
                    <img src="/oaimg/Face/19.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<偷笑>')">
                    <img src="/oaimg/Face/20.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<可爱>')">
                    <img src="/oaimg/Face/21.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<白眼>')">
                    <img src="/oaimg/Face/22.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<傲慢>')">
                    <img src="/oaimg/Face/23.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<饥饿>')">
                    <img src="/oaimg/Face/24.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<困>')">
                    <img src="/oaimg/Face/25.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<惊恐>')">
                    <img src="/oaimg/Face/26.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<流汗>')">
                    <img src="/oaimg/Face/27.gif" width="24" height="24" border="0"></a></td>
        </tr>
        <tr>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<憨笑>')">
                    <img src="/oaimg/Face/28.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<大兵>')">
                    <img src="/oaimg/Face/29.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<奋斗>')">
                    <img src="/oaimg/Face/30.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<咒骂>')">
                    <img src="/oaimg/Face/31.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<疑问>')">
                    <img src="/oaimg/Face/32.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<嘘>')">
                    <img src="/oaimg/Face/33.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<晕>')">
                    <img src="/oaimg/Face/34.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<折磨>')">
                    <img src="/oaimg/Face/35.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<衰>')">
                    <img src="/oaimg/Face/36.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<骷髅>')">
                    <img src="/oaimg/Face/37.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<敲打>')">
                    <img src="/oaimg/Face/38.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<再见>')">
                    <img src="/oaimg/Face/39.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<插汗>')">
                    <img src="/oaimg/Face/40.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<抠鼻>')">
                    <img src="/oaimg/Face/41.gif" width="24" height="24" border="0"></a></td>
        </tr>
        <tr>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<鼓掌>')">
                    <img src="/oaimg/Face/42.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<糗大了>')">
                    <img src="/oaimg/Face/43.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<坏笑>')">
                    <img src="/oaimg/Face/44.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<左哼哼>')">
                    <img src="/oaimg/Face/45.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<右哼哼>')">
                    <img src="/oaimg/Face/46.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<哈欠>')">
                    <img src="/oaimg/Face/47.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<鄙视>')">
                    <img src="/oaimg/Face/48.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<委屈>')">
                    <img src="/oaimg/Face/49.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<快哭了>')">
                    <img src="/oaimg/Face/50.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<阴险>')">
                    <img src="/oaimg/Face/51.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<亲亲>')">
                    <img src="/oaimg/Face/52.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<吓>')">
                    <img src="/oaimg/Face/53.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<可怜>')">
                    <img src="/oaimg/Face/54.gif" width="24" height="24" border="0"></a></td>
            <td width="24" align="center" bgcolor="#FFFFFF">
                <a href="#" onclick="face('<菜刀>')">
                    <img src="/oaimg/Face/55.gif" width="24" height="24" border="0"></a></td>
        </tr>
    </table>
</body>
</html>
