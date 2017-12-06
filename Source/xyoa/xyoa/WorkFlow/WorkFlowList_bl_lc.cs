namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowList_bl_lc : Page
    {
        public string CbName;
        public string CbUser;
        public string FlowNumber;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Liucheng;
        public string NodeName;
        protected TextBox Number;
        private publics pulicss = new publics();
        public string Shuxing;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                string sql = "select UpNodeName,FlowNumber,Shuxing from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.NodeName = list["UpNodeName"].ToString();
                    this.FlowNumber = list["FlowNumber"].ToString();
                    this.Shuxing = list["Shuxing"].ToString();
                }
                list.Close();
                this.CbUser = "";
                this.CbName = "";
                string str2 = "select  BLusername,BLrealname from qp_oa_AddWorkFlowPicRy  where  KeyFile='" + base.Request.QueryString["Number"] + "' and (States='未接收' or States='办理中') order by id asc";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    this.CbUser = this.CbUser + "" + reader2["BLusername"].ToString() + ",";
                    this.CbName = this.CbName + "" + reader2["BLrealname"].ToString() + ",";
                }
                reader2.Close();
                string str3 = "select  * from qp_oa_AddWorkFlowPic where KeyFile='" + base.Request.QueryString["Number"] + "'  order by id asc";
                SqlDataReader reader3 = this.List.GetList(str3);
                this.Liucheng.Text = null;
                int num = 1;
                this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"0\" cellpadding=\"4\" cellspacing=\"1\" width=\"100%\" class=\"nextpage\">";
                while (reader3.Read())
                {
                    SqlDataReader reader5;
                    string str6;
                    TimeSpan span;
                    object text;
                    double num2 = 0.0;
                    string str4 = string.Concat(new object[] { "select XbTimes from qp_oa_WorkFlowNode where  FlowNumber='", this.FlowNumber, "' and NodeNum='", reader3["XuHao"], "' and NodeName='", reader3["Jiedian"], "'" });
                    SqlDataReader reader4 = this.List.GetList(str4);
                    if (reader4.Read())
                    {
                        num2 = double.Parse(reader4["XbTimes"].ToString());
                    }
                    reader4.Close();
                    string str5 = null;
                    if (reader3["Jiedian"].ToString() == this.NodeName)
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>序号", reader3["XuHao"], "：", reader3["Jiedian"], "(当前步骤) </td>" });
                    }
                    else
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>序号", reader3["XuHao"], "：", reader3["Jiedian"], "</td>" });
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "<td class=\"newtd2\" width=\"60%\" style=\"line-height: 150%\">";
                    if (this.Shuxing == "自由流程")
                    {
                        str5 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader3["LcNum"].ToString() + "'  order by id asc";
                        reader5 = this.List.GetList(str5);
                        while (reader5.Read())
                        {
                            str6 = "";
                            if (reader5["States"].ToString() == "未接收")
                            {
                                str6 = "flow_close.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader5["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a><font color=#008000>(", reader5["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader5["StartTime"], "<br>实际结束时间：", reader5["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>"
                                 });
                            }
                            else if (reader5["States"].ToString() == "办理中")
                            {
                                str6 = "flow_open.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader5["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a><font color=#008000>(", reader5["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader5["StartTime"], "<br>实际结束时间：", reader5["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>"
                                 });
                            }
                            else if (reader5["States"].ToString() == "已委托")
                            {
                                str6 = "Menu285.gif";
                                span = (TimeSpan) (DateTime.Parse(reader5["EndTime"].ToString()) - DateTime.Parse(reader5["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a></font><font color=#008000>(", reader5["States"], "&nbsp;→&nbsp;", 
                                    reader5["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader5["StartTime"], "<br>结束于：", reader5["EndTime"], "<br>"
                                 });
                            }
                            else
                            {
                                str6 = "workflow_query.gif";
                                span = (TimeSpan) (DateTime.Parse(reader5["EndTime"].ToString()) - DateTime.Parse(reader5["StartTime"].ToString()));
                                if (((((reader5["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader5["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader5["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader5["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader5["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader5["EndTime"].ToString() == "1900/1/1 00:00:00"))
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a></font><font color=#008000>(", reader5["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader5["StartTime"], "<br>结束于：", reader5["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a></font><font color=#008000>(", reader5["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader5["StartTime"], "<br>结束于：", reader5["EndTime"], "<br>"
                                     });
                                }
                            }
                        }
                        reader5.Close();
                    }
                    else
                    {
                        str5 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader3["LcNum"].ToString() + "'  order by id asc";
                        reader5 = this.List.GetList(str5);
                        while (reader5.Read())
                        {
                            TimeSpan span2;
                            string str7;
                            str6 = "";
                            if (reader5["States"].ToString() == "未接收")
                            {
                                str6 = "flow_close.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader5["StartTime"].ToString()));
                                span2 = (TimeSpan) (DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(DateTime.Now.ToString()));
                                str7 = "" + span2.TotalSeconds + "";
                                if (span2.TotalSeconds >= 0.0)
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a><font color=#008000>(", reader5["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader5["StartTime"], "<br>实际结束时间：", reader5["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>限办完成时间：", DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：离限办时间还有 ", this.pulicss.ShowDateTime(double.Parse(str7.Replace("-", ""))), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a><font color=#008000>(", reader5["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader5["StartTime"], "<br>实际结束时间：", reader5["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>限办完成时间：", DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：已超时：", this.pulicss.ShowDateTime(double.Parse(str7.Replace("-", ""))), "<br>"
                                     });
                                }
                            }
                            else if (reader5["States"].ToString() == "办理中")
                            {
                                str6 = "flow_open.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader5["StartTime"].ToString()));
                                span2 = (TimeSpan) (DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(DateTime.Now.ToString()));
                                str7 = "" + span2.TotalSeconds + "";
                                if (span2.TotalSeconds >= 0.0)
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a><font color=#008000>(", reader5["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader5["StartTime"], "<br>实际结束时间：", reader5["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>限办完成时间：", DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：离限办时间还有 ", this.pulicss.ShowDateTime(double.Parse(str7.Replace("-", ""))), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a><font color=#008000>(", reader5["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader5["StartTime"], "<br>实际结束时间：", reader5["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>限办完成时间：", DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：已超时：", this.pulicss.ShowDateTime(double.Parse(str7.Replace("-", ""))), "<br>"
                                     });
                                }
                            }
                            else
                            {
                                string str8;
                                if (reader5["States"].ToString() == "已委托")
                                {
                                    str6 = "Menu285.gif";
                                    span = (TimeSpan) (DateTime.Parse(reader5["EndTime"].ToString()) - DateTime.Parse(reader5["StartTime"].ToString()));
                                    span2 = (TimeSpan) (DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(reader5["EndTime"].ToString()));
                                    str7 = "" + span2.TotalSeconds + "";
                                    str8 = "" + Math.Round((double) (span2.TotalSeconds / 3600.0), 2) + "";
                                    if (span2.TotalSeconds >= 0.0)
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a></font><font color=#008000>(", reader5["States"], "&nbsp;→&nbsp;", 
                                            reader5["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader5["StartTime"], "<br>结束于：", reader5["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：提前： ", this.pulicss.ShowDateTime(double.Parse(str7.Replace("-", ""))), "<br>效率值：", str8, "<br>"
                                         });
                                    }
                                    else
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a></font><font color=#008000>(", reader5["States"], "&nbsp;→&nbsp;", 
                                            reader5["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader5["StartTime"], "<br>结束于：", reader5["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：超时： ", this.pulicss.ShowDateTime(double.Parse(str7.Replace("-", ""))), "<br>效率值：", str8, "<br>"
                                         });
                                    }
                                }
                                else
                                {
                                    str6 = "workflow_query.gif";
                                    span = (TimeSpan) (DateTime.Parse(reader5["EndTime"].ToString()) - DateTime.Parse(reader5["StartTime"].ToString()));
                                    span2 = (TimeSpan) (DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(reader5["EndTime"].ToString()));
                                    str7 = "" + span2.TotalSeconds + "";
                                    str8 = "" + Math.Round((double) (span2.TotalSeconds / 3600.0), 2) + "";
                                    if (((((reader5["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader5["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader5["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader5["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader5["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader5["EndTime"].ToString() == "1900/1/1 00:00:00"))
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a><font color=#008000>(", reader5["States"], "&nbsp;&nbsp;用时：)</font><br>开始于：", 
                                            reader5["StartTime"], "<br>结束于：", reader5["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>限办完成时间：", DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：未接收办理，由其他人员直接转交<br>效率值：0<br>"
                                         });
                                    }
                                    else if (span2.TotalSeconds >= 0.0)
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a></font><font color=#008000>(", reader5["States"], "&nbsp;&nbsp;用时：", 
                                            this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader5["StartTime"], "<br>结束于：", reader5["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：提前： ", this.pulicss.ShowDateTime(double.Parse(str7.Replace("-", ""))), "<br>效率值：", str8, "<br>"
                                         });
                                    }
                                    else
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str6, "\"  title=\"", reader5["IfZb"], "，", reader5["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader5["BLusername"].ToString(), "')  title=\"", reader5["IfZb"], "\"><b><font color=#FF0000>", reader5["BLrealname"], "</font></b></a></font><font color=#008000>(", reader5["States"], "&nbsp;&nbsp;用时：", 
                                            this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader5["StartTime"], "<br>结束于：", reader5["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader5["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：超时： ", this.pulicss.ShowDateTime(double.Parse(str7.Replace("-", ""))), "<br>效率值：", str8, "<br>"
                                         });
                                    }
                                }
                            }
                        }
                        reader5.Close();
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "</td>";
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                    num++;
                }
                reader3.Close();
                this.Liucheng.Text = this.Liucheng.Text + "</table>";
            }
        }
    }
}

