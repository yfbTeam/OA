namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class AddWorkFlow_bl_lc : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Liucheng;
        protected TextBox Number;
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                object text;
                string sql = "select NodeName,FlowNumber,Shuxing from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["NodeName"] = list["NodeName"].ToString();
                    this.ViewState["FlowNumber"] = list["FlowNumber"].ToString();
                    this.ViewState["Shuxing"] = list["Shuxing"].ToString();
                }
                list.Close();
                this.ViewState["CbUser"] = "";
                this.ViewState["CbName"] = "";
                string str2 = "select  BLusername,BLrealname from qp_oa_AddWorkFlowPicRy  where  KeyFile='" + base.Request.QueryString["Number"] + "' and (States='未接收' or States='办理中') order by id asc";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    StateBag bag = ViewState;
                    text = bag["CbUser"];
                    (bag = this.ViewState)["CbUser"] = string.Concat(new object[] { text, "", reader2["BLusername"].ToString(), "," });
                    text = bag["CbName"];
                    (bag = this.ViewState)["CbName"] = string.Concat(new object[] { text, "", reader2["BLrealname"].ToString(), "," });
                }
                reader2.Close();
                string str3 = "select  * from qp_oa_AddWorkFlowPic where KeyFile='" + base.Request.QueryString["Number"] + "'  order by id asc";
                SqlDataReader reader3 = this.List.GetList(str3);
                this.Liucheng.Text = null;
                int num = 1;
                this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"0\" cellpadding=\"4\" cellspacing=\"1\" width=\"100%\" class=\"nextpage\">";
                while (reader3.Read())
                {
                    string str4 = null;
                    if (reader3["Jiedian"].ToString() == this.ViewState["NodeName"].ToString())
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>序号", reader3["XuHao"], "：", reader3["Jiedian"], "(当前步骤) </td>" });
                    }
                    else
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>序号", reader3["XuHao"], "：", reader3["Jiedian"], "</td>" });
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "<td class=\"newtd2\" width=\"60%\">";
                    str4 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader3["LcNum"].ToString() + "'  order by id asc";
                    SqlDataReader reader4 = this.List.GetList(str4);
                    while (reader4.Read())
                    {
                        TimeSpan span;
                        string str5 = "";
                        if (reader4["States"].ToString() == "未接收")
                        {
                            str5 = "flow_close.gif";
                        }
                        else if (reader4["States"].ToString() == "办理中")
                        {
                            str5 = "flow_open.gif";
                        }
                        else
                        {
                            str5 = "workflow_query.gif";
                        }
                        if (((((reader4["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader4["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader4["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader4["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader4["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader4["EndTime"].ToString() == "1900/1/1 00:00:00"))
                        {
                            span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", 
                                this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>"
                             });
                        }
                        else
                        {
                            span = (TimeSpan) (DateTime.Parse(reader4["EndTime"].ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a></font><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", 
                                this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"], "<br>"
                             });
                        }
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "</td>";
                    reader4.Close();
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                    num++;
                }
                reader3.Close();
                this.Liucheng.Text = this.Liucheng.Text + "</table>";
            }
        }
    }
}

