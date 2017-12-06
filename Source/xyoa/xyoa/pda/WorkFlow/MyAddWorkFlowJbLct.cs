namespace xyoa.pda.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyAddWorkFlowJbLct : Page
    {
        protected Button Button1;
        public string CbName;
        public string CbUser;
        public string FlowNumber;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        public string NodeName;
        public string NodeNames;
        protected TextBox Number;
        private publics pulicss = new publics();
        private divform showform = new divform();
        public string Shuxing;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyAddWorkFlowJb.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                this.NodeName = base.Request.QueryString["GlNum"].ToString();
                string sql = "select UpNodeName,FlowNumber,Shuxing from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.NodeNames = list["UpNodeName"].ToString();
                    this.FlowNumber = list["FlowNumber"].ToString();
                    this.Shuxing = list["Shuxing"].ToString();
                }
                list.Close();
                string str2 = "select  * from qp_oa_AddWorkFlowPic where KeyFile='" + base.Request.QueryString["Number"] + "'  order by id asc";
                SqlDataReader reader2 = this.List.GetList(str2);
                this.Liucheng.Text = null;
                int num = 1;
                this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"0\" cellpadding=\"4\" cellspacing=\"1\" width=\"100%\" class=\"nextpage\">";
                while (reader2.Read())
                {
                    SqlDataReader reader4;
                    string str5;
                    TimeSpan span;
                    object text;
                    double num2 = 0.0;
                    string str3 = string.Concat(new object[] { "select XbTimes from qp_oa_WorkFlowNode where  FlowNumber='", this.FlowNumber, "' and NodeNum='", reader2["XuHao"], "' and NodeName='", reader2["Jiedian"], "'" });
                    SqlDataReader reader3 = this.List.GetList(str3);
                    if (reader3.Read())
                    {
                        num2 = double.Parse(reader3["XbTimes"].ToString());
                    }
                    reader3.Close();
                    string str4 = null;
                    if (reader2["GlNum"].ToString() == this.NodeName)
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/><font color=red>序号", reader2["XuHao"], "：", reader2["Jiedian"], "(办理的步骤)</font></td>" });
                    }
                    else
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>序号", reader2["XuHao"], "：", reader2["Jiedian"], "</td>" });
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "<td class=\"newtd2\" width=\"60%\" style=\"line-height: 150%\">";
                    if (this.Shuxing == "自由流程")
                    {
                        str4 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader2["LcNum"].ToString() + "'  order by id asc";
                        reader4 = this.List.GetList(str4);
                        while (reader4.Read())
                        {
                            str5 = "";
                            if (reader4["States"].ToString() == "未接收")
                            {
                                str5 = "flow_close.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader4["StartTime"], "<br>实际结束时间：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>"
                                 });
                            }
                            else if (reader4["States"].ToString() == "办理中")
                            {
                                str5 = "flow_open.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader4["StartTime"], "<br>实际结束时间：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>"
                                 });
                            }
                            else if (reader4["States"].ToString() == "已委托")
                            {
                                str5 = "Menu285.gif";
                                span = (TimeSpan) (DateTime.Parse(reader4["EndTime"].ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a></font><font color=#008000>(", reader4["States"], "&nbsp;→&nbsp;", 
                                    reader4["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"], "<br>"
                                 });
                            }
                            else
                            {
                                str5 = "workflow_query.gif";
                                span = (TimeSpan) (DateTime.Parse(reader4["EndTime"].ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                if (((((reader4["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader4["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader4["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader4["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader4["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader4["EndTime"].ToString() == "1900/1/1 00:00:00"))
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a></font><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a></font><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"], "<br>"
                                     });
                                }
                            }
                        }
                        reader4.Close();
                    }
                    else
                    {
                        str4 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader2["LcNum"].ToString() + "'  order by id asc";
                        reader4 = this.List.GetList(str4);
                        while (reader4.Read())
                        {
                            TimeSpan span2;
                            string str6;
                            str5 = "";
                            if (reader4["States"].ToString() == "未接收")
                            {
                                str5 = "flow_close.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                span2 = (TimeSpan) (DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(DateTime.Now.ToString()));
                                str6 = "" + span2.TotalSeconds + "";
                                if (span2.TotalSeconds >= 0.0)
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader4["StartTime"], "<br>实际结束时间：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>限办完成时间：", DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：离限办时间还有 ", this.pulicss.ShowDateTime(double.Parse(str6.Replace("-", ""))), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader4["StartTime"], "<br>实际结束时间：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>限办完成时间：", DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：已超时：", this.pulicss.ShowDateTime(double.Parse(str6.Replace("-", ""))), "<br>"
                                     });
                                }
                            }
                            else if (reader4["States"].ToString() == "办理中")
                            {
                                str5 = "flow_open.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                span2 = (TimeSpan) (DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(DateTime.Now.ToString()));
                                str6 = "" + span2.TotalSeconds + "";
                                if (span2.TotalSeconds >= 0.0)
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader4["StartTime"], "<br>实际结束时间：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>限办完成时间：", DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：离限办时间还有 ", this.pulicss.ShowDateTime(double.Parse(str6.Replace("-", ""))), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader4["StartTime"], "<br>实际结束时间：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>限办完成时间：", DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：已超时：", this.pulicss.ShowDateTime(double.Parse(str6.Replace("-", ""))), "<br>"
                                     });
                                }
                            }
                            else
                            {
                                string str7;
                                if (reader4["States"].ToString() == "已委托")
                                {
                                    str5 = "Menu285.gif";
                                    span = (TimeSpan) (DateTime.Parse(reader4["EndTime"].ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                    span2 = (TimeSpan) (DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(reader4["EndTime"].ToString()));
                                    str6 = "" + span2.TotalSeconds + "";
                                    str7 = "" + Math.Round((double) (span2.TotalSeconds / 3600.0), 2) + "";
                                    if (span2.TotalSeconds >= 0.0)
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a></font><font color=#008000>(", reader4["States"], "&nbsp;→&nbsp;", 
                                            reader4["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：提前： ", this.pulicss.ShowDateTime(double.Parse(str6.Replace("-", ""))), "<br>效率值：", str7, "<br>"
                                         });
                                    }
                                    else
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a></font><font color=#008000>(", reader4["States"], "&nbsp;→&nbsp;", 
                                            reader4["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：超时： ", this.pulicss.ShowDateTime(double.Parse(str6.Replace("-", ""))), "<br>效率值：", str7, "<br>"
                                         });
                                    }
                                }
                                else
                                {
                                    str5 = "workflow_query.gif";
                                    span = (TimeSpan) (DateTime.Parse(reader4["EndTime"].ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                                    span2 = (TimeSpan) (DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(reader4["EndTime"].ToString()));
                                    str6 = "" + span2.TotalSeconds + "";
                                    str7 = "" + Math.Round((double) (span2.TotalSeconds / 3600.0), 2) + "";
                                    if (((((reader4["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader4["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader4["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader4["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader4["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader4["EndTime"].ToString() == "1900/1/1 00:00:00"))
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：)</font><br>开始于：", 
                                            reader4["StartTime"], "<br>结束于：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>限办完成时间：", DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：未接收办理，由其他人员直接转交<br>效率值：0<br>"
                                         });
                                    }
                                    else if (span2.TotalSeconds >= 0.0)
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a></font><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", 
                                            this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：提前： ", this.pulicss.ShowDateTime(double.Parse(str6.Replace("-", ""))), "<br>效率值：", str7, "<br>"
                                         });
                                    }
                                    else
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["IfZb"], "，", reader4["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader4["BLusername"].ToString(), "')  title=\"", reader4["IfZb"], "\"><b><font color=#FF0000>", reader4["BLrealname"], "</font></b></a></font><font color=#008000>(", reader4["States"], "&nbsp;&nbsp;用时：", 
                                            this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader4["StartTime"], "<br>结束于：", reader4["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader4["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：超时： ", this.pulicss.ShowDateTime(double.Parse(str6.Replace("-", ""))), "<br>效率值：", str7, "<br>"
                                         });
                                    }
                                }
                            }
                        }
                        reader4.Close();
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "</td>";
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                    num++;
                }
                reader2.Close();
                this.Liucheng.Text = this.Liucheng.Text + "</table>";
            }
        }
    }
}

