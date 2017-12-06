<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SeadChatPeople.aspx.cs"
    Inherits="xyoa.InfoManage.Taolunzu.SeadChatPeople" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<script>
            var ysuser='<%=Request.QueryString["id"]%>';
			window.setInterval("AjaxMethod.ListPeople('"+ysuser+"',get_chat)",2000);
				
			function get_chat(response)
			{
				AjaxMethod.UpdateListPeople(ysuser);
				if (response.value != null)
				{					
				    var ds = response.value;
				    var htmlstr="<table width=100% border=0 cellpadding=4 cellspacing=0>";　　
				    for(var i=0; i<ds.Tables[0].Rows.length; i++)
　　　　		    {
　　　　			    htmlstr+="<tr>";　
　　　　　　		    var sname_table=ds.Tables[0].Rows[i].Realname;
　　　　　　		    var suser_table=ds.Tables[0].Rows[i].Username;
　　　　　　		    var id=ds.Tables[0].Rows[i].id;
　　　　　　		    var times=ds.Tables[0].Rows[i].times;
                        if(parseInt(times)>3)
                        {
                           htmlstr+="<td><img src=/oaimg/menu/on2.gif><a href=javascript:void(0)  onclick='senduser(\""+suser_table+"\")'><font color=#FF00F7>"+sname_table+"</font></a></td></tr>";
                        }
                        else
                        {
　　　　　　		        htmlstr+="<td><img src=/oaimg/menu/on1.gif><a href=javascript:void(0) onclick='senduser(\""+suser_table+"\")'><font color=#FF00F7>"+sname_table+"</font></a></td></tr>";
　　　　　　		    }
    　　　　　　		
　　　　		    }
　　　　			    htmlstr+="</TABLE>";
　　　　			    document.getElementById('Tables_chat').innerHTML=htmlstr;
　				　	    document.getElementById('show').style.display='none'; 
　　　　		    }
　　　　		
			}
			
			
</script>

<head id="Head1" runat="server">
    <title>网络办公系统</title>
    <link href="/<%=Session["yangshi"]%>/oa.css" type="text/css" rel="stylesheet">
    <link href="/<%=Session["yangshi"]%>/style_oa_30.css" type="text/css" rel="stylesheet">
     <script src="/js/public.js" type="text/javascript"></script>
</head>
<body>
    <form id="Form1" runat="server">
        <div>
            <table cellspacing="0" bordercolordark="#ffffff" cellpadding="0" width="99%" bordercolorlight="#c0c0c0"
                border="0">
                <tbody>
                    <tr>
                        <td valign="top" align="right" width="2%">
                        </td>
                        <td width="98%">
                            <div id="Tables_chat">
                            </div>
                            <div id="show" style="display: none">
                                <font color="#ff0000" size="2">
                                    <br>
                                    <b>数据读取中....</b></font></div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </form>

    <script language="javascript">

            var ysuser='<%=Request.QueryString["id"]%>';
            document.getElementById('show').style.display=''; 
            AjaxMethod.ListPeople('"+yuser+"',get_chat);
    </script>

</body>
</html>
