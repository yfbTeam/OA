namespace xyoa.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListSp_NextJs : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox C3;
        protected CheckBox C4;
        protected CheckBox C5;
        protected CheckBox C6;
        protected HtmlForm form1;
        protected RadioButtonList FormName;
        protected Label fujian;
        protected TextBox GlNum1;
        protected Label guocheng;
        protected HtmlHead Head1;
        protected HtmlImage IMG2;
        protected HtmlImage IMG3;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        protected TextBox Number;
        protected HtmlImage opency;
        protected Panel Panel1;
        private publics pulicss = new publics();
        protected Label rizhi;
        private divform showform = new divform();
        protected TextBox txtSmsContent;
        protected Label yijian;
        protected TextBox YjRealname;
        protected TextBox YjUsername;
        protected CheckBoxList YoujianXm;

        public void AddEmail()
        {
            object text;
            this.ViewState["xm0"] = "" + this.ViewState["Name"].ToString() + "";
            this.ViewState["xm1"] = "";
            this.ViewState["xm2"] = "";
            this.ViewState["xm3"] = "";
            this.ViewState["xm4"] = "";
            this.ViewState["xm5"] = "";
            string str = this.pulicss.GetChecked(this.YoujianXm);
            string str2 = "1";
            string str3 = "2";
            string str4 = "3";
            string str5 = "4";
            string str6 = "5";
            if (str.IndexOf(str2) > 0)
            {
                this.ViewState["xm1"] = "<hr  width=\"100%\" ><div align=\"center\" ><b>办理表单</b></div><hr  width=\"100%\" >" + this.ViewState["FileContent"].ToString() + "<br>";
            }
            if (str.IndexOf(str3) > 0)
            {
                this.pulicss.GetFile(this.ViewState["WfNumber"].ToString(), this.fujian);
                this.ViewState["xm2"] = "<hr  width=\"100%\" ><div align=\"center\" ><b>公共附件</b></div><hr  width=\"100%\" >" + this.fujian.Text + "<br>";
            }
            if (str.IndexOf(str4) > 0)
            {
                string str7 = "select  * from qp_oa_AddWorkFlowPic where KeyFile='" + this.ViewState["WfNumber"].ToString() + "'  order by id asc";
                SqlDataReader reader = this.List.GetList(str7);
                this.guocheng.Text = null;
                int num = 1;
                this.guocheng.Text = this.guocheng.Text + "  <table border=\"1\" cellpadding=\"4\" cellspacing=\"0\" width=\"100%\" class=\"nextpage\">";
                while (reader.Read())
                {
                    SqlDataReader reader3;
                    string str10;
                    TimeSpan span;
                    double num2 = 0.0;
                    string str8 = string.Concat(new object[] { "select XbTimes from qp_oa_WorkFlowNode where  FlowNumber='", this.ViewState["FlowNumber"].ToString(), "' and NodeNum='", reader["XuHao"], "' and NodeName='", reader["Jiedian"], "'" });
                    SqlDataReader reader2 = this.List.GetList(str8);
                    if (reader2.Read())
                    {
                        num2 = double.Parse(reader2["XbTimes"].ToString());
                    }
                    reader2.Close();
                    string str9 = null;
                    if (reader["Jiedian"].ToString() == this.ViewState["NodeName"].ToString())
                    {
                        text = this.guocheng.Text;
                        this.guocheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>序号", reader["XuHao"], "：", reader["Jiedian"], "(当前步骤) </td>" });
                    }
                    else
                    {
                        text = this.guocheng.Text;
                        this.guocheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>序号", reader["XuHao"], "：", reader["Jiedian"], "</td>" });
                    }
                    this.guocheng.Text = this.guocheng.Text + "<td class=\"newtd2\" width=\"60%\" style=\"line-height: 150%\">";
                    if (this.ViewState["ShuXing"].ToString() == "自由流程")
                    {
                        str9 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader["LcNum"].ToString() + "'  order by id asc";
                        reader3 = this.List.GetList(str9);
                        while (reader3.Read())
                        {
                            str10 = "";
                            if (reader3["States"].ToString() == "未接收")
                            {
                                str10 = "flow_close.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                text = this.guocheng.Text;
                                this.guocheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader3["StartTime"], "<br>实际结束时间：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>"
                                 });
                            }
                            else if (reader3["States"].ToString() == "办理中")
                            {
                                str10 = "flow_open.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                text = this.guocheng.Text;
                                this.guocheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader3["StartTime"], "<br>实际结束时间：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>"
                                 });
                            }
                            else if (reader3["States"].ToString() == "已委托")
                            {
                                str10 = "Menu285.gif";
                                span = (TimeSpan) (DateTime.Parse(reader3["EndTime"].ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                text = this.guocheng.Text;
                                this.guocheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a></font><font color=#008000>(", reader3["States"], "&nbsp;→&nbsp;", 
                                    reader3["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"], "<br>"
                                 });
                            }
                            else
                            {
                                str10 = "workflow_query.gif";
                                span = (TimeSpan) (DateTime.Parse(reader3["EndTime"].ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                if (((((reader3["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader3["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader3["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader3["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader3["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader3["EndTime"].ToString() == "1900/1/1 00:00:00"))
                                {
                                    text = this.guocheng.Text;
                                    this.guocheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a></font><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.guocheng.Text;
                                    this.guocheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a></font><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"], "<br>"
                                     });
                                }
                            }
                        }
                        reader3.Close();
                    }
                    else
                    {
                        str9 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader["LcNum"].ToString() + "'  order by id asc";
                        reader3 = this.List.GetList(str9);
                        while (reader3.Read())
                        {
                            TimeSpan span2;
                            string str11;
                            str10 = "";
                            if (reader3["States"].ToString() == "未接收")
                            {
                                str10 = "flow_close.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                span2 = (TimeSpan) (DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(DateTime.Now.ToString()));
                                str11 = "" + span2.TotalSeconds + "";
                                if (span2.TotalSeconds >= 0.0)
                                {
                                    text = this.guocheng.Text;
                                    this.guocheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader3["StartTime"], "<br>实际结束时间：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>限办完成时间：", DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：离限办时间还有 ", this.pulicss.ShowDateTime(double.Parse(str11.Replace("-", ""))), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.guocheng.Text;
                                    this.guocheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader3["StartTime"], "<br>实际结束时间：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>限办完成时间：", DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：已超时：", this.pulicss.ShowDateTime(double.Parse(str11.Replace("-", ""))), "<br>"
                                     });
                                }
                            }
                            else if (reader3["States"].ToString() == "办理中")
                            {
                                str10 = "flow_open.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                span2 = (TimeSpan) (DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(DateTime.Now.ToString()));
                                str11 = "" + span2.TotalSeconds + "";
                                if (span2.TotalSeconds >= 0.0)
                                {
                                    text = this.guocheng.Text;
                                    this.guocheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader3["StartTime"], "<br>实际结束时间：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>限办完成时间：", DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：离限办时间还有 ", this.pulicss.ShowDateTime(double.Parse(str11.Replace("-", ""))), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.guocheng.Text;
                                    this.guocheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader3["StartTime"], "<br>实际结束时间：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>限办完成时间：", DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：已超时：", this.pulicss.ShowDateTime(double.Parse(str11.Replace("-", ""))), "<br>"
                                     });
                                }
                            }
                            else
                            {
                                string str12;
                                if (reader3["States"].ToString() == "已委托")
                                {
                                    str10 = "Menu285.gif";
                                    span = (TimeSpan) (DateTime.Parse(reader3["EndTime"].ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                    span2 = (TimeSpan) (DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(reader3["EndTime"].ToString()));
                                    str11 = "" + span2.TotalSeconds + "";
                                    str12 = "" + Math.Round((double) (span2.TotalSeconds / 3600.0), 2) + "";
                                    if (span2.TotalSeconds >= 0.0)
                                    {
                                        text = this.guocheng.Text;
                                        this.guocheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a></font><font color=#008000>(", reader3["States"], "&nbsp;→&nbsp;", 
                                            reader3["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：提前： ", this.pulicss.ShowDateTime(double.Parse(str11.Replace("-", ""))), "<br>效率值：", str12, "<br>"
                                         });
                                    }
                                    else
                                    {
                                        text = this.guocheng.Text;
                                        this.guocheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a></font><font color=#008000>(", reader3["States"], "&nbsp;→&nbsp;", 
                                            reader3["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：超时： ", this.pulicss.ShowDateTime(double.Parse(str11.Replace("-", ""))), "<br>效率值：", str12, "<br>"
                                         });
                                    }
                                }
                                else
                                {
                                    str10 = "workflow_query.gif";
                                    span = (TimeSpan) (DateTime.Parse(reader3["EndTime"].ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                    span2 = (TimeSpan) (DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(reader3["EndTime"].ToString()));
                                    str11 = "" + span2.TotalSeconds + "";
                                    str12 = "" + Math.Round((double) (span2.TotalSeconds / 3600.0), 2) + "";
                                    if (((((reader3["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader3["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader3["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader3["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader3["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader3["EndTime"].ToString() == "1900/1/1 00:00:00"))
                                    {
                                        text = this.guocheng.Text;
                                        this.guocheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：)</font><br>开始于：", 
                                            reader3["StartTime"], "<br>结束于：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>限办完成时间：", DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：未接收办理，由其他人员直接转交<br>效率值：0<br>"
                                         });
                                    }
                                    else if (span2.TotalSeconds >= 0.0)
                                    {
                                        text = this.guocheng.Text;
                                        this.guocheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a></font><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                            this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：提前： ", this.pulicss.ShowDateTime(double.Parse(str11.Replace("-", ""))), "<br>效率值：", str12, "<br>"
                                         });
                                    }
                                    else
                                    {
                                        text = this.guocheng.Text;
                                        this.guocheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str10, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a></font><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                            this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader3["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：超时： ", this.pulicss.ShowDateTime(double.Parse(str11.Replace("-", ""))), "<br>效率值：", str12, "<br>"
                                         });
                                    }
                                }
                            }
                        }
                        reader3.Close();
                    }
                    this.guocheng.Text = this.guocheng.Text + "</td>";
                    this.guocheng.Text = this.guocheng.Text + "</tr>";
                    num++;
                }
                reader.Close();
                this.guocheng.Text = this.guocheng.Text + "</table>";
                this.ViewState["xm3"] = "<hr  width=\"100%\" ><div align=\"center\" ><b>办理过程</b></div><hr  width=\"100%\" >" + this.guocheng.Text + "<br>";
            }
            if (str.IndexOf(str5) > 0)
            {
                string str13 = "select  * from qp_oa_AddWorkFlowLog where Number='" + this.ViewState["WfNumber"].ToString() + "'  order by id asc";
                SqlDataReader reader4 = this.List.GetList(str13);
                this.rizhi.Text = null;
                this.rizhi.Text = this.rizhi.Text + "  <table border=\"1\" cellpadding=\"4\" cellspacing=\"0\" width=\"100%\">";
                while (reader4.Read())
                {
                    this.rizhi.Text = this.rizhi.Text + "<tr><td>";
                    text = this.rizhi.Text;
                    this.rizhi.Text = string.Concat(new object[] { text, " <table border=\"1\" cellpadding=\"4\" cellspacing=\"0\"><tr><td style=\"width: 100%\"><b>表单名称：</b>", reader4["FormName"], "<b>操作人：</b>", reader4["Realname"], "(", reader4["ZbOrJb"], ")<b>时间：</b>", reader4["SetTime"], "</td></tr><tr><td style=\"width: 100%\"><b>内容：</b>", reader4["Contents"], "</td></tr></table>" });
                    this.rizhi.Text = this.rizhi.Text + "</td></tr>";
                }
                reader4.Close();
                this.rizhi.Text = this.rizhi.Text + "</table>";
                this.ViewState["xm4"] = "<hr  width=\"100%\" ><div align=\"center\" ><b>办理日志</b></div><hr  width=\"100%\" >" + this.rizhi.Text + "<br>";
            }
            if (str.IndexOf(str6) > 0)
            {
                string str14 = "select  * from qp_oa_AddWorkFlowMessage where Number='" + this.ViewState["WfNumber"].ToString() + "'  order by id asc";
                SqlDataReader reader5 = this.List.GetList(str14);
                this.yijian.Text = null;
                this.yijian.Text = this.yijian.Text + "  <table border=\"1\" cellpadding=\"4\" cellspacing=\"0\" width=\"100%\">";
                while (reader5.Read())
                {
                    this.yijian.Text = this.yijian.Text + "<tr><td>";
                    text = this.yijian.Text;
                    this.yijian.Text = string.Concat(new object[] { text, " <table border=\"0\" cellpadding=\"4\" cellspacing=\"0\"><tr><td style=\"width: 100%\"><b>步骤名称：</b>", reader5["Buzhou"], "<b>办理人：</b>", reader5["Realname"], "(", reader5["ZbOrJb"], ")<b>时间：</b>", reader5["SetTime"], "</td></tr><tr><td style=\"width: 100%\">", reader5["Content"], "<br><br><a href=\"/AddWorkFlow_add_down.aspx?number=", reader5["NewName"], "\" target=\"_blank\">", reader5["OldName"], "</a></td></tr></table>" });
                    this.yijian.Text = this.yijian.Text + "</td></tr>";
                }
                reader5.Close();
                this.yijian.Text = this.yijian.Text + "</table>";
                this.ViewState["xm5"] = "<hr  width=\"100%\" ><div align=\"center\" ><b>办理意见</b></div><hr  width=\"100%\" >" + this.yijian.Text + "<br>";
            }
            string str15 = null;
            string str16 = null;
            str16 = "" + this.YjUsername.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str16.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str15 = str15 + "'" + strArray[i] + "',";
            }
            str15 = str15 + "'0'";
            string sql = "select username,realname from qp_oa_Username where  username in (" + str15 + ") ";
            SqlDataReader reader6 = this.List.GetList(sql);
            while (reader6.Read())
            {
                string str18 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowFF  (FormNumber,WfNumber,Number,Titles,Content,JsUsername,JsRealname,IfRead,IfDel,FsUsername,FsRealname,FsTime) values ('", this.ViewState["FormNumber"], "','", this.ViewState["WfNumber"], "','", this.Number.Text, "','工作流传阅：", this.pulicss.GetFormatStr(this.ViewState["xm0"].ToString()), "','", this.pulicss.GetFormatStrbjq(this.ViewState["xm1"].ToString() + this.ViewState["xm2"].ToString() + this.ViewState["xm3"].ToString() + this.ViewState["xm5"].ToString() + this.ViewState["xm4"].ToString()), "','", reader6["username"], "','", reader6["realname"], "','0','0','", this.Session["username"], 
                    "','", this.Session["realname"], "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str18);
                this.pulicss.InsertMessage(string.Concat(new object[] { "您有内部邮件需要接收，工作流传阅：", this.pulicss.GetFormatStr(this.ViewState["xm0"].ToString()), "，发送人：", this.Session["realname"], "" }), reader6["username"].ToString(), reader6["realname"].ToString(), "/InfoManage/nbemail/NbEmail_sj.aspx");
            }
            reader6.Close();
            string str19 = string.Concat(new object[] { 
                "insert into qp_oa_NbEmail_fj  (Number,Titles,Content,JsUsername,JsRealname,FsUsername,FsRealname,FsTime) values ('", this.Number.Text, "','工作流传阅：", this.pulicss.GetFormatStr(this.ViewState["xm0"].ToString()), "','", this.pulicss.GetFormatStrbjq(this.ViewState["xm1"].ToString() + this.ViewState["xm2"].ToString() + this.ViewState["xm3"].ToString() + this.ViewState["xm4"].ToString() + this.ViewState["xm5"].ToString()), "','", this.YjUsername.Text, "','", this.YjRealname.Text, "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                "')"
             });
            this.List.ExeSql(str19);
        }

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.IMG2, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.C4, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.IMG3, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.C6, ",14,", this.pulicss.GetSms());
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        public void BindDroList()
        {
            string sql = "select  * from qp_oa_AddWorkFlowPic where KeyFile='" + base.Request.QueryString["Number"] + "'  order by id asc";
            SqlDataReader list = this.List.GetList(sql);
            this.Liucheng.Text = null;
            int num = 1;
            this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"0\" cellpadding=\"4\" cellspacing=\"1\" width=\"100%\" class=\"nextpage\">";
            while (list.Read())
            {
                object text;
                string str2 = null;
                if (list["Jiedian"].ToString() == this.ViewState["NodeName"].ToString())
                {
                    text = this.Liucheng.Text;
                    this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>第<font color=red><b>", num, "</b></font>步", list["Jiedian"], "(当前步骤) </td>" });
                }
                else
                {
                    text = this.Liucheng.Text;
                    this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>第<font color=red><b>", num, "</b></font>步", list["Jiedian"], " </td>" });
                }
                this.Liucheng.Text = this.Liucheng.Text + "<td class=\"newtd2\" width=\"70%\">";
                str2 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + list["LcNum"].ToString() + "'  order by id asc";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    text = this.Liucheng.Text;
                    this.Liucheng.Text = string.Concat(new object[] { text, "<a href=javascript:void(0) onclick=senduser('", reader2["BLusername"].ToString(), "')  title=\"", reader2["IfZb"], "\">", reader2["BLrealname"], "</a>(", reader2["States"], ")&nbsp;" });
                }
                this.Liucheng.Text = this.Liucheng.Text + "</td>";
                reader2.Close();
                this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                num++;
            }
            list.Close();
            this.Liucheng.Text = this.Liucheng.Text + "</table>";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已办结' ,EndTime='", DateTime.Now.ToString(), "'  where KeyFile='", this.ViewState["WfNumber"], "' and BLusername='", this.Session["username"], "' and XuHao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "' and States!='已委托'" });
            this.List.ExeSql(sql);
            string str2 = "Update qp_oa_AddWorkFlowPicRy  Set States='已办结'   where KeyFile='" + base.Request.QueryString["Number"] + "' and States!='已委托'";
            this.List.ExeSql(str2);
            if (this.C3.Checked)
            {
                this.pulicss.InsertMessage(string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已结束，结束时间", DateTime.Now.ToString(), "" }), this.ViewState["FqUsername"].ToString(), this.ViewState["FqRealname"].ToString(), "#");
            }
            if (this.C4.Checked)
            {
                string str3 = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + this.ViewState["FqUsername"].ToString() + "' ";
                SqlDataReader reader = this.List.GetList(str3);
                if (reader.Read())
                {
                    this.pulicss.InsertSms(reader["MoveTel"].ToString(), string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已结束，结束时间", DateTime.Now.ToString(), "" }));
                }
                reader.Close();
            }
            string str4 = null;
            string str5 = null;
            str5 = "" + this.ViewState["JbObjectId"] + "";
            ArrayList list = new ArrayList();
            string[] strArray = str5.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str4 = str4 + "'" + strArray[i] + "',";
            }
            str4 = str4 + "'0'";
            string str6 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str4 + ") ";
            SqlDataReader reader2 = this.List.GetList(str6);
            while (reader2.Read())
            {
                if (this.C5.Checked)
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "等待您办理的工作[", this.ViewState["Name"], "]已结束，结束时间", DateTime.Now.ToString(), "" }), reader2["username"].ToString(), reader2["realname"].ToString(), "#");
                }
                if (this.C6.Checked)
                {
                    this.pulicss.InsertSms(reader2["MoveTel"].ToString(), string.Concat(new object[] { "等待您办理的工作[", this.ViewState["Name"], "]已结束，结束时间", DateTime.Now.ToString(), "" }));
                }
            }
            reader2.Close();
            string str7 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlow where (CHARINDEX(',", this.Session["username"], ",',','+YJBObjectId+',')   >   0 ) and id='", base.Request.QueryString["id"], "'" });
            SqlDataReader reader3 = this.List.GetList(str7);
            if (!reader3.Read())
            {
                string str8 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set YJBObjectId=YJBObjectId+'", this.Session["username"], ",',YJBObjecName=YJBObjecName+'", this.Session["realname"], ",'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'" });
                this.List.ExeSql(str8);
            }
            reader3.Close();
            string str9 = "Update qp_oa_AddWorkFlow  Set State='正常结束',NodeName='正常结束',UpNodeName='正常结束'  where id='" + base.Request.QueryString["id"] + "'";
            this.List.ExeSql(str9);
            string str10 = "select * from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["id"] + "'";
            SqlDataReader reader4 = this.List.GetList(str10);
            if (reader4.Read())
            {
                string str11 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowGd (JinJiChengDu,Keyid,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,YJBObjectId,YJBObjecName,Username,Realname,NowTimes,Shuxing,GdId) values ('", reader4["JinJiChengDu"], "','", reader4["id"], "','", reader4["FormId"], "','", reader4["FormNumber"], "','", reader4["FormName"], "','", reader4["FlowId"], "','", reader4["FlowNumber"], "','", reader4["FlowName"], 
                    "','", reader4["Number"], "','", reader4["Sequence"], "','", reader4["Name"], "','", reader4["FileContent"], "','", reader4["FqUsername"], "','", reader4["FqRealname"], "','", reader4["YJBObjectId"], "','", reader4["YJBObjecName"], 
                    "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "','", reader4["Shuxing"], "','", this.ViewState["OverSetConId"], "')"
                 });
                this.List.ExeSql(str11);
            }
            reader4.Close();
            this.AddEmail();
            base.Response.Write("<script language=javascript>alert('结束成功！');window.opener.location.href='WorkFlowList.aspx';window.close();</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlowListSp.aspx?id=" + base.Request.QueryString["id"] + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "");
        }

        public void chuangyue()
        {
            string sql = "select Chuanyue,YjUsername,YjRealname,YoujianXm,YjXiugai from qp_oa_WorkFlowNode where id='" + this.ViewState["UpNodeId"].ToString() + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                if (list["Chuanyue"].ToString() == "1")
                {
                    this.ViewState["Chuanyue"] = list["Chuanyue"].ToString();
                    this.YjRealname.Text = list["YjRealname"].ToString();
                    this.YjUsername.Text = list["YjUsername"].ToString();
                    this.pulicss.SetChecked(this.YoujianXm, "," + list["YoujianXm"].ToString() + ",");
                    if (list["YjXiugai"].ToString() == "1")
                    {
                        this.YoujianXm.Enabled = true;
                        this.opency.Visible = true;
                    }
                    else
                    {
                        this.YoujianXm.Enabled = false;
                        this.opency.Visible = false;
                    }
                    this.Panel1.Visible = true;
                }
                else
                {
                    this.Panel1.Visible = false;
                }
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!base.IsPostBack)
            {
                this.YjRealname.Attributes.Add("readonly", "readonly");
                this.BindAttribute();
                string sql = "select * from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["FormNames"] = list["FormName"].ToString();
                    this.ViewState["Sequence"] = list["Sequence"].ToString();
                    this.ViewState["Name"] = list["Name"].ToString();
                    this.ViewState["NodeName"] = list["UpNodeName"].ToString();
                    this.ViewState["UpNodeNum"] = list["UpNodeNum"].ToString();
                    this.txtSmsContent.Text = "工作流结束提醒：" + list["Name"].ToString() + "";
                    this.ViewState["FqUsername"] = list["FqUsername"].ToString();
                    this.ViewState["FqRealname"] = list["FqRealname"].ToString();
                    this.ViewState["JbObjectId"] = list["JbObjectId"].ToString();
                    this.ViewState["JbObjectName"] = list["JbObjectName"].ToString();
                    this.ViewState["FlowNumber"] = list["FlowNumber"].ToString();
                    string str2 = "select OverSetConId from qp_oa_WorkFlowName where  id='" + list["FlowId"].ToString() + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.ViewState["OverSetConId"] = reader2["OverSetConId"].ToString();
                    }
                    reader2.Close();
                    this.GlNum1.Text = list["GlNum"].ToString();
                    this.ViewState["UpNodeId"] = list["UpNodeId"].ToString();
                    this.ViewState["FileContent"] = list["FileContent"].ToString();
                    this.ViewState["WfNumber"] = list["Number"].ToString();
                    this.ViewState["ShuXing"] = list["ShuXing"].ToString();
                    this.ViewState["FormNumber"] = list["FormNumber"].ToString();
                }
                list.Close();
                this.BindDroList();
                this.ViewState["ZjBLrealname"] = "";
                string str3 = string.Concat(new object[] { "select  * from qp_oa_AddWorkFlowPicRy  where  KeyFile='", base.Request.QueryString["Number"], "' and xuhao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "' order by id asc" });
                SqlDataReader reader3 = this.List.GetList(str3);
                while (reader3.Read())
                {
                    StateBag bag = ViewState;
                    object obj2 = bag["ZjBLrealname"];
                    (bag = this.ViewState)["ZjBLrealname"] = string.Concat(new object[] { obj2, "", reader3["BLrealname"], "(", reader3["States"], ")，" });
                }
                reader3.Close();
                string str4 = string.Concat(new object[] { "select  * from qp_oa_AddWorkFlowPicRy  where  KeyFile='", base.Request.QueryString["Number"], "' and xuhao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "' order by id asc" });
                SqlDataReader reader4 = this.List.GetList(str4);
                while (reader4.Read())
                {
                    this.ViewState["IfZb"] = reader4["BLrealname"].ToString();
                }
                reader4.Close();
                this.chuangyue();
            }
        }
    }
}

