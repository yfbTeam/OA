<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SeadChat.aspx.cs" Inherits="xyoa.InfoManage.messages.SeadChat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script>
            var ysuser='<%=Request.QueryString["user"]%>';
			window.setInterval("AjaxMethod.Getchat('"+ysuser+"',get_chat)",2000);
				

			function get_chat(response)
			{

				if (response.value != null)
				{					
				
				    var ds = response.value;
    　　　　		
				    var htmlstr="<table width=450px border=0 cellpadding=4 cellspacing=0>";
				    //alert(ds.Tables[0].Rows.length);
				    for(var i=0; i<ds.Tables[0].Rows.length; i++)
　　　　		    {
　　　　			    htmlstr+="<tr>";　
　　　　			    var titles_table=ds.Tables[0].Rows[i].titles.replace(/\n/g,'<br>').replace(/<微笑>/g,'<img src=/oaimg/Face/0.gif border=0/>').replace(/<撇嘴>/g,'<img src=/oaimg/Face/1.gif border=0/>').replace(/<色>/g,'<img src=/oaimg/Face/2.gif border=0/>').replace(/<发呆>/g,'<img src=/oaimg/Face/3.gif border=0/>').replace(/<得意>/g,'<img src=/oaimg/Face/4.gif border=0/>').replace(/<流泪>/g,'<img src=/oaimg/Face/5.gif border=0/>').replace(/<害羞>/g,'<img src=/oaimg/Face/6.gif border=0/>').replace(/<闭嘴>/g,'<img src=/oaimg/Face/7.gif border=0/>').replace(/<睡>/g,'<img src=/oaimg/Face/8.gif border=0/>').replace(/<大哭>/g,'<img src=/oaimg/Face/9.gif border=0/>').replace(/<尴尬>/g,'<img src=/oaimg/Face/10.gif border=0/>').replace(/<发怒>/g,'<img src=/oaimg/Face/11.gif border=0/>').replace(/<调皮>/g,'<img src=/oaimg/Face/12.gif border=0/>').replace(/<呲牙>/g,'<img src=/oaimg/Face/13.gif border=0/>').replace(/<惊呆>/g,'<img src=/oaimg/Face/14.gif border=0/>').replace(/<难过>/g,'<img src=/oaimg/Face/15.gif border=0/>').replace(/<酷>/g,'<img src=/oaimg/Face/16.gif border=0/>').replace(/<冷汗>/g,'<img src=/oaimg/Face/17.gif border=0/>').replace(/<抓狂>/g,'<img src=/oaimg/Face/18.gif border=0/>').replace(/<吐>/g,'<img src=/oaimg/Face/19.gif border=0/>').replace(/<偷笑>/g,'<img src=/oaimg/Face/20.gif border=0/>').replace(/<可爱>/g,'<img src=/oaimg/Face/21.gif border=0/>').replace(/<白眼>/g,'<img src=/oaimg/Face/22.gif border=0/>').replace(/<傲慢>/g,'<img src=/oaimg/Face/23.gif border=0/>').replace(/<饥饿>/g,'<img src=/oaimg/Face/24.gif border=0/>').replace(/<困>/g,'<img src=/oaimg/Face/25.gif border=0/>').replace(/<惊恐>/g,'<img src=/oaimg/Face/26.gif border=0/>').replace(/<流汗>/g,'<img src=/oaimg/Face/27.gif border=0/>').replace(/<憨笑>/g,'<img src=/oaimg/Face/28.gif border=0/>').replace(/<大兵>/g,'<img src=/oaimg/Face/29.gif border=0/>').replace(/<奋斗>/g,'<img src=/oaimg/Face/30.gif border=0/>').replace(/<咒骂>/g,'<img src=/oaimg/Face/31.gif border=0/>').replace(/<疑问>/g,'<img src=/oaimg/Face/32.gif border=0/>').replace(/<嘘>/g,'<img src=/oaimg/Face/33.gif border=0/>').replace(/<晕>/g,'<img src=/oaimg/Face/34.gif border=0/>').replace(/<折磨>/g,'<img src=/oaimg/Face/35.gif border=0/>').replace(/<衰>/g,'<img src=/oaimg/Face/36.gif border=0/>').replace(/<骷髅>/g,'<img src=/oaimg/Face/37.gif border=0/>').replace(/<敲打>/g,'<img src=/oaimg/Face/38.gif border=0/>').replace(/<再见>/g,'<img src=/oaimg/Face/39.gif border=0/>').replace(/<插汗>/g,'<img src=/oaimg/Face/40.gif border=0/>').replace(/<抠鼻>/g,'<img src=/oaimg/Face/41.gif border=0/>').replace(/<鼓掌>/g,'<img src=/oaimg/Face/42.gif border=0/>').replace(/<糗大了>/g,'<img src=/oaimg/Face/43.gif border=0/>').replace(/<坏笑>/g,'<img src=/oaimg/Face/44.gif border=0/>').replace(/<左哼哼>/g,'<img src=/oaimg/Face/45.gif border=0/>').replace(/<右哼哼>/g,'<img src=/oaimg/Face/46.gif border=0/>').replace(/<哈欠>/g,'<img src=/oaimg/Face/47.gif border=0/>').replace(/<鄙视>/g,'<img src=/oaimg/Face/48.gif border=0/>').replace(/<委屈>/g,'<img src=/oaimg/Face/49.gif border=0/>').replace(/<快哭了>/g,'<img src=/oaimg/Face/50.gif border=0/>').replace(/<阴险>/g,'<img src=/oaimg/Face/51.gif border=0/>').replace(/<亲亲>/g,'<img src=/oaimg/Face/52.gif border=0/>').replace(/<吓>/g,'<img src=/oaimg/Face/53.gif border=0/>').replace(/<可怜>/g,'<img src=/oaimg/Face/54.gif border=0/>').replace(/<菜刀>/g,'<img src=/oaimg/Face/55.gif border=0/>').replace(/<OK>/g,'<img src=/oaimg/Face/56.gif border=0/>');
　　　　　　		    var sendrealname_table=ds.Tables[0].Rows[i].sendrealname;
　　　　　　		    var acceptusername_table=ds.Tables[0].Rows[i].acceptusername;
　　　　　　		    var itimes_table=ds.Tables[0].Rows[i].itimes;
　　　　　　		    var tablekey_table=ds.Tables[0].Rows[i].tablekey;
    　　　　　　		
//　　　　　　		    var titles_tableB=ds.Tables[0].Rows[i].Btitles.replace(/\n/g,'<br>').replace(/ /g,'&nbsp;').replace(/<微笑>/g,'<img src=/oaimg/Face/0.gif />').replace(/<撇嘴>/g,'<img src=/oaimg/Face/1.gif />').replace(/<色>/g,'<img src=/oaimg/Face/2.gif />').replace(/<发呆>/g,'<img src=/oaimg/Face/3.gif />').replace(/<得意>/g,'<img src=/oaimg/Face/4.gif />').replace(/<流泪>/g,'<img src=/oaimg/Face/5.gif />').replace(/<害羞>/g,'<img src=/oaimg/Face/6.gif />').replace(/<闭嘴>/g,'<img src=/oaimg/Face/7.gif />').replace(/<睡>/g,'<img src=/oaimg/Face/8.gif />').replace(/<大哭>/g,'<img src=/oaimg/Face/9.gif />').replace(/<尴尬>/g,'<img src=/oaimg/Face/10.gif />').replace(/<发怒>/g,'<img src=/oaimg/Face/11.gif />').replace(/<调皮>/g,'<img src=/oaimg/Face/12.gif />').replace(/<呲牙>/g,'<img src=/oaimg/Face/13.gif />').replace(/<惊呆>/g,'<img src=/oaimg/Face/14.gif />').replace(/<难过>/g,'<img src=/oaimg/Face/15.gif />').replace(/<酷>/g,'<img src=/oaimg/Face/16.gif />').replace(/<冷汗>/g,'<img src=/oaimg/Face/17.gif />').replace(/<抓狂>/g,'<img src=/oaimg/Face/18.gif />').replace(/<吐>/g,'<img src=/oaimg/Face/19.gif />').replace(/<偷笑>/g,'<img src=/oaimg/Face/20.gif />').replace(/<可爱>/g,'<img src=/oaimg/Face/21.gif />').replace(/<白眼>/g,'<img src=/oaimg/Face/22.gif />').replace(/<傲慢>/g,'<img src=/oaimg/Face/23.gif />').replace(/<饥饿>/g,'<img src=/oaimg/Face/24.gif />').replace(/<困>/g,'<img src=/oaimg/Face/25.gif />').replace(/<惊恐>/g,'<img src=/oaimg/Face/26.gif />').replace(/<流汗>/g,'<img src=/oaimg/Face/27.gif />').replace(/<憨笑>/g,'<img src=/oaimg/Face/28.gif />').replace(/<大兵>/g,'<img src=/oaimg/Face/29.gif />').replace(/<奋斗>/g,'<img src=/oaimg/Face/30.gif />').replace(/<咒骂>/g,'<img src=/oaimg/Face/31.gif />').replace(/<疑问>/g,'<img src=/oaimg/Face/32.gif />').replace(/<嘘>/g,'<img src=/oaimg/Face/33.gif />').replace(/<晕>/g,'<img src=/oaimg/Face/34.gif />').replace(/<折磨>/g,'<img src=/oaimg/Face/35.gif />').replace(/<衰>/g,'<img src=/oaimg/Face/36.gif />').replace(/<骷髅>/g,'<img src=/oaimg/Face/37.gif />').replace(/<敲打>/g,'<img src=/oaimg/Face/38.gif />').replace(/<再见>/g,'<img src=/oaimg/Face/39.gif />').replace(/<插汗>/g,'<img src=/oaimg/Face/40.gif />').replace(/<抠鼻>/g,'<img src=/oaimg/Face/41.gif />').replace(/<鼓掌>/g,'<img src=/oaimg/Face/42.gif />').replace(/<糗大了>/g,'<img src=/oaimg/Face/43.gif />').replace(/<坏笑>/g,'<img src=/oaimg/Face/44.gif />').replace(/<左哼哼>/g,'<img src=/oaimg/Face/45.gif />').replace(/<右哼哼>/g,'<img src=/oaimg/Face/46.gif />').replace(/<哈欠>/g,'<img src=/oaimg/Face/47.gif />').replace(/<鄙视>/g,'<img src=/oaimg/Face/48.gif />').replace(/<委屈>/g,'<img src=/oaimg/Face/49.gif />').replace(/<快哭了>/g,'<img src=/oaimg/Face/50.gif />').replace(/<阴险>/g,'<img src=/oaimg/Face/51.gif />').replace(/<亲亲>/g,'<img src=/oaimg/Face/52.gif />').replace(/<吓>/g,'<img src=/oaimg/Face/53.gif />').replace(/<可怜>/g,'<img src=/oaimg/Face/54.gif />').replace(/<菜刀>/g,'<img src=/oaimg/Face/55.gif />').replace(/<OK>/g,'<img src=/oaimg/Face/56.gif />');
//　　　　　　		    var sendrealname_tableB=ds.Tables[0].Rows[i].Bsendrealname;
//　　　　　　		    var acceptusername_tableB=ds.Tables[0].Rows[i].Bacceptusername;
//　　　　　　		    var itimes_tableB=ds.Tables[0].Rows[i].Bitimes;
    　　　　　　		
    　　　　　　		
　　　　　　		    if(acceptusername_table=='<%=Session["username"]%>')
　　　　　　		    {
　　　　　　		      htmlstr+="<td><font color=#0000FF>"+sendrealname_table+"</font>&nbsp;&nbsp;<font color=#0000FF>"+itimes_table+"</font><br><font color=#000000>"+titles_table+"</font></td></tr>";
　　　　　　		    }
　　　　　　		    else
　　　　　　		    {
　　　　　　		      htmlstr+="<td><font color=#008040>"+sendrealname_table+"</font>&nbsp;&nbsp;<font color=#008040>"+itimes_table+"</font><br><font color=#000000>"+titles_table+"</font></td></tr>";
　　　　　　		    }
    　　　　　　		
　　　　　　		    //htmlstr=htmlstr+"</tr>";
　　　　		    }
　　　　			htmlstr+="</TABLE>";
　　　　			document.getElementById('Tables_chat').innerHTML=htmlstr;
　　　　		    document.getElementById('show').style.display='none'; 
　　　　			parent.form1.btn_AddCity.value='发 送';
　				    parent.form1.btn_AddCity.disabled=false;
　				　
　　　　		}
　　　　	   
             
               var ysuser='<%=Request.QueryString["user"]%>';
		      AjaxMethod.UpdateMessagesForJs(ysuser);
		       
             // parent.rform.scroll(0,100000000);
　　　　	   
			}

        function scrolldowm()
        {
          parent.rform.scroll(0,100000000);
        }

</script>

<head id="Head1" runat="server">
    <title>交谈</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table cellspacing="0" cellpadding="0" width="450px" border="0" style="word-break: break-all">
                <tr>
                    <td>
                        <div id="Tables_chat">
                        </div>
                        <div id="show" style="">
                            <font color="#ff0000" size="2">
                                <br>
                                <b>聊天记录读取中 .......</b></font></div>
                    </td>
                </tr>
            </table>
        </div>
    </form>

    <script language="javascript">

            var ysuser='<%=Request.QueryString["user"]%>';
            AjaxMethod.Getchat('"+ysuser+"',get_chat);
         
    </script>

</body>
</html>
