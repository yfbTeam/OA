namespace xyoa.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class AddWorkFlow_add_Next : Page
    {
        protected Button Button1;
        protected HtmlInputButton Button3;
        protected HtmlInputButton Button4;
        protected CheckBox C1;
        protected CheckBox C2;
        protected CheckBox C3;
        protected CheckBox C4;
        protected CheckBox C5;
        protected CheckBox C6;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected RadioButtonList FormName;
        protected Label fujian;
        protected Label GlGuize;
        protected TextBox GlNum;
        protected Label guocheng;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        protected HtmlImage IMG2;
        protected HtmlImage IMG3;
        protected TextBox JbGuanlianID;
        protected TextBox JbGuanlianName;
        protected TextBox JbRealname;
        protected TextBox JbUsername;
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
        protected TextBox ZbGuanlianID;
        protected TextBox ZbGuanlianName;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;
        protected TextBox ZbUsername6;

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
            }
            reader6.Close();
            this.showform.AddWorkFlowLog(this.Number.Text, base.Request.QueryString["Number"].ToString(), this.ViewState["FormNames"].ToString(), this.ViewState["NodeName"].ToString(), "传阅：" + this.ViewState["Name"].ToString() + "<br>接收人：" + this.YjRealname.Text + "", "主办");
        }

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.IMG1, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.C2, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.IMG2, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.C4, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.IMG3, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.C6, ",14,", this.pulicss.GetSms());
            this.ZbRealname.Attributes.Add("readonly", "readonly");
            this.JbRealname.Attributes.Add("readonly", "readonly");
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
            string sQL = "select id,'<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>'+NodeName as NodeName  from qp_oa_WorkFlowNode where  NodeNum  in (" + base.Request.QueryString["UpNodeNum"] + "0) and FlowNumber='" + base.Request.QueryString["FlowNumber"] + "' order by NodeNum asc";
            if (!base.IsPostBack)
            {
                this.list.Bind_DropDownList_nothing1(this.FormName, sQL, "id", "NodeName");
            }
        }

        public void BindLb(string str)
        {
            this.ZbUsername.Text = null;
            this.ZbRealname.Text = null;
            this.JbUsername.Text = null;
            this.JbRealname.Text = null;
            string sql = "select ZbUsername,ZbRealname,JbUsername,JbRealname,XrGuize,GlGuize,ZbGuanlianID,ZbGuanlianName,JbGuanlianID,JbGuanlianName from qp_oa_WorkFlowNode where id='" + str + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ZbGuanlianID.Text = list["ZbGuanlianID"].ToString();
                this.ZbGuanlianName.Text = list["ZbGuanlianName"].ToString();
                this.JbGuanlianID.Text = list["JbGuanlianID"].ToString();
                this.JbGuanlianName.Text = list["JbGuanlianName"].ToString();
                if (list["XrGuize"].ToString() == "1")
                {
                    this.ZbUsername.Text = "";
                    this.ZbRealname.Text = "";
                    this.JbUsername.Text = "";
                    this.JbRealname.Text = "";
                }
                else
                {
                    string str3;
                    SqlDataReader reader2;
                    if (list["XrGuize"].ToString() == "2")
                    {
                        str3 = "select FqUsername,FqRealname from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                        reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            this.ZbUsername.Text = reader2["FqUsername"].ToString();
                            this.ZbRealname.Text = reader2["FqRealname"].ToString();
                            this.JbUsername.Text = "" + reader2["FqUsername"].ToString() + ",";
                            this.JbRealname.Text = "" + reader2["FqRealname"].ToString() + ",";
                        }
                        reader2.Close();
                    }
                    else if (list["XrGuize"].ToString() == "7")
                    {
                        this.ZbUsername.Text = this.Session["Username"].ToString();
                        this.ZbRealname.Text = this.Session["Realname"].ToString();
                        this.JbUsername.Text = "" + this.Session["Username"].ToString() + ",";
                        this.JbRealname.Text = "" + this.Session["Realname"].ToString() + ",";
                    }
                    else
                    {
                        string str4;
                        SqlDataReader reader3;
                        string str5;
                        SqlDataReader reader4;
                        if (list["XrGuize"].ToString() == "8")
                        {
                            str4 = "select Username,Realname from qp_oa_username where JueseId='" + this.ZbGuanlianID.Text + "'";
                            reader3 = this.List.GetList(str4);
                            if (reader3.Read())
                            {
                                this.ZbUsername.Text = reader3["Username"].ToString();
                                this.ZbRealname.Text = reader3["Realname"].ToString();
                            }
                            reader3.Close();
                            str5 = "select Username,Realname from qp_oa_username where JueseId in (" + this.JbGuanlianID.Text + "0)";
                            reader4 = this.List.GetList(str5);
                            while (reader4.Read())
                            {
                                this.JbUsername.Text = this.JbUsername.Text + "" + reader4["Username"].ToString() + ",";
                                this.JbRealname.Text = this.JbRealname.Text + "" + reader4["Realname"].ToString() + ",";
                            }
                            reader4.Close();
                        }
                        else if (list["XrGuize"].ToString() == "10")
                        {
                            str4 = "select Username,Realname from qp_oa_username where Zhiweiid='" + this.ZbGuanlianID.Text + "'";
                            reader3 = this.List.GetList(str4);
                            if (reader3.Read())
                            {
                                this.ZbUsername.Text = reader3["Username"].ToString();
                                this.ZbRealname.Text = reader3["Realname"].ToString();
                            }
                            reader3.Close();
                            str5 = "select Username,Realname from qp_oa_username where Zhiweiid in (" + this.JbGuanlianID.Text + "0)";
                            reader4 = this.List.GetList(str5);
                            while (reader4.Read())
                            {
                                this.JbUsername.Text = this.JbUsername.Text + "" + reader4["Username"].ToString() + ",";
                                this.JbRealname.Text = this.JbRealname.Text + "" + reader4["Realname"].ToString() + ",";
                            }
                            reader4.Close();
                        }
                        else if (list["XrGuize"].ToString() == "13")
                        {
                            str4 = "select Username,Realname from qp_oa_username where BuMenId='" + this.ZbGuanlianID.Text + "'";
                            reader3 = this.List.GetList(str4);
                            if (reader3.Read())
                            {
                                this.ZbUsername.Text = reader3["Username"].ToString();
                                this.ZbRealname.Text = reader3["Realname"].ToString();
                            }
                            reader3.Close();
                            str5 = "select Username,Realname from qp_oa_username where BuMenId in (" + this.JbGuanlianID.Text + "0)";
                            reader4 = this.List.GetList(str5);
                            while (reader4.Read())
                            {
                                this.JbUsername.Text = this.JbUsername.Text + "" + reader4["Username"].ToString() + ",";
                                this.JbRealname.Text = this.JbRealname.Text + "" + reader4["Realname"].ToString() + ",";
                            }
                            reader4.Close();
                        }
                        else if (list["XrGuize"].ToString() == "3")
                        {
                            str3 = "select BmUsername,BmRealname from qp_oa_Bumen where  id='" + this.Session["BuMenId"].ToString() + "'";
                            reader2 = this.List.GetList(str3);
                            if (reader2.Read())
                            {
                                this.ZbUsername.Text = reader2["BmUsername"].ToString();
                                this.ZbRealname.Text = reader2["BmRealname"].ToString();
                                if (reader2["BmUsername"].ToString() != "")
                                {
                                    this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                                    this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                                }
                                else
                                {
                                    this.JbUsername.Text = "";
                                    this.JbRealname.Text = "";
                                }
                            }
                            reader2.Close();
                        }
                        else
                        {
                            string str6;
                            SqlDataReader reader5;
                            if (list["XrGuize"].ToString() == "4")
                            {
                                str3 = "select ParentNodesID,BmUsername,BmRealname from qp_oa_Bumen where  id='" + this.Session["BuMenId"].ToString() + "'";
                                reader2 = this.List.GetList(str3);
                                if (reader2.Read())
                                {
                                    if (reader2["ParentNodesID"].ToString() != "0")
                                    {
                                        str6 = "select BmUsername,BmRealname from qp_oa_Bumen where  id='" + reader2["ParentNodesID"].ToString() + "'";
                                        reader5 = this.List.GetList(str6);
                                        if (reader5.Read())
                                        {
                                            this.ZbUsername.Text = reader5["BmUsername"].ToString();
                                            this.ZbRealname.Text = reader5["BmRealname"].ToString();
                                            if (reader5["BmUsername"].ToString() != "")
                                            {
                                                this.JbUsername.Text = "" + reader5["BmUsername"].ToString() + ",";
                                                this.JbRealname.Text = "" + reader5["BmRealname"].ToString() + ",";
                                            }
                                            else
                                            {
                                                this.JbUsername.Text = "";
                                                this.JbRealname.Text = "";
                                            }
                                        }
                                        reader5.Close();
                                    }
                                    else
                                    {
                                        this.ZbUsername.Text = reader2["BmUsername"].ToString();
                                        this.ZbRealname.Text = reader2["BmRealname"].ToString();
                                        if (reader2["BmUsername"].ToString() != "")
                                        {
                                            this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                                            this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                                        }
                                        else
                                        {
                                            this.JbUsername.Text = "";
                                            this.JbRealname.Text = "";
                                        }
                                    }
                                }
                                reader2.Close();
                            }
                            else if (list["XrGuize"].ToString() == "5")
                            {
                                str3 = "select BmUsername,BmRealname from qp_oa_Bumen where   ParentNodesID='0'  and  CHARINDEX(QxString,(select QxString from qp_oa_Bumen where id='" + HttpContext.Current.Session["BuMenId"].ToString() + "')) > 0";
                                reader2 = this.List.GetList(str3);
                                if (reader2.Read())
                                {
                                    this.ZbUsername.Text = reader2["BmUsername"].ToString();
                                    this.ZbRealname.Text = reader2["BmRealname"].ToString();
                                    if (reader2["BmUsername"].ToString() != "")
                                    {
                                        this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                                        this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                                    }
                                    else
                                    {
                                        this.JbUsername.Text = "";
                                        this.JbRealname.Text = "";
                                    }
                                }
                                reader2.Close();
                            }
                            else if (list["XrGuize"].ToString() == "11")
                            {
                                str3 = "select BmUsername,BmRealname from qp_oa_Bumen where   id=(select BuMenId from qp_oa_username where username='" + HttpContext.Current.Session["username"].ToString() + "')";
                                reader2 = this.List.GetList(str3);
                                if (reader2.Read())
                                {
                                    this.ZbUsername.Text = reader2["BmUsername"].ToString();
                                    this.ZbRealname.Text = reader2["BmRealname"].ToString();
                                    if (reader2["BmUsername"].ToString() != "")
                                    {
                                        this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                                        this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                                    }
                                    else
                                    {
                                        this.JbUsername.Text = "";
                                        this.JbRealname.Text = "";
                                    }
                                }
                                reader2.Close();
                            }
                            else if (list["XrGuize"].ToString() == "12")
                            {
                                str3 = "select ParentNodesID,BmUsername,BmRealname from qp_oa_Bumen where  id=(select BuMenId from qp_oa_username where username='" + HttpContext.Current.Session["username"].ToString() + "')";
                                reader2 = this.List.GetList(str3);
                                if (reader2.Read())
                                {
                                    if (reader2["ParentNodesID"].ToString() != "0")
                                    {
                                        str6 = "select BmUsername,BmRealname from qp_oa_Bumen where  id='" + reader2["ParentNodesID"].ToString() + "'";
                                        reader5 = this.List.GetList(str6);
                                        if (reader5.Read())
                                        {
                                            this.ZbUsername.Text = reader5["BmUsername"].ToString();
                                            this.ZbRealname.Text = reader5["BmRealname"].ToString();
                                            if (reader5["BmUsername"].ToString() != "")
                                            {
                                                this.JbUsername.Text = "" + reader5["BmUsername"].ToString() + ",";
                                                this.JbRealname.Text = "" + reader5["BmRealname"].ToString() + ",";
                                            }
                                            else
                                            {
                                                this.JbUsername.Text = "";
                                                this.JbRealname.Text = "";
                                            }
                                        }
                                        reader5.Close();
                                    }
                                    else
                                    {
                                        this.ZbUsername.Text = reader2["BmUsername"].ToString();
                                        this.ZbRealname.Text = reader2["BmRealname"].ToString();
                                        if (reader2["BmUsername"].ToString() != "")
                                        {
                                            this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                                            this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                                        }
                                        else
                                        {
                                            this.JbUsername.Text = "";
                                            this.JbRealname.Text = "";
                                        }
                                    }
                                }
                                reader2.Close();
                            }
                            else
                            {
                                this.ZbUsername.Text = list["ZbUsername"].ToString();
                                this.ZbUsername6.Text = list["JbUsername"].ToString();
                                this.ZbRealname.Text = list["ZbRealname"].ToString();
                                this.JbUsername.Text = list["JbUsername"].ToString();
                                this.JbRealname.Text = list["JbRealname"].ToString();
                            }
                        }
                    }
                }
                if (list["GlGuize"].ToString() == "1")
                {
                    this.Button4.Visible = true;
                    this.Button3.Visible = true;
                    this.Button4.Attributes["onclick"] = "javascript:openUser1(" + list["GlGuize"].ToString() + ");";
                    this.Button3.Attributes["onclick"] = "javascript:openUser2(" + list["GlGuize"].ToString() + ");";
                    this.GlGuize.Text = " - 允许自由选择全部人员";
                }
                else if (list["GlGuize"].ToString() == "2")
                {
                    this.Button4.Visible = true;
                    this.Button3.Visible = true;
                    this.Button4.Attributes["onclick"] = "javascript:openUser1(" + list["GlGuize"].ToString() + ");";
                    this.Button3.Attributes["onclick"] = "javascript:openUser2(" + list["GlGuize"].ToString() + ");";
                    this.GlGuize.Text = " - 允许自由选择本部门人员";
                }
                else if (list["GlGuize"].ToString() == "3")
                {
                    this.Button4.Visible = true;
                    this.Button3.Visible = true;
                    this.Button4.Attributes["onclick"] = "javascript:openUser1(" + list["GlGuize"].ToString() + ");";
                    this.Button3.Attributes["onclick"] = "javascript:openUser2(" + list["GlGuize"].ToString() + ");";
                    this.GlGuize.Text = " - 允许自由选择本角色人员";
                }
                else if (list["GlGuize"].ToString() == "4")
                {
                    this.Button4.Visible = true;
                    this.Button3.Visible = true;
                    this.Button4.Attributes["onclick"] = "javascript:openUser1(" + list["GlGuize"].ToString() + ");";
                    this.Button3.Attributes["onclick"] = "javascript:openUser2(" + list["GlGuize"].ToString() + ");";
                    this.GlGuize.Text = " - 允许自由选择本职位人员";
                }
                else if (list["GlGuize"].ToString() == "6")
                {
                    this.Button4.Visible = true;
                    this.Button3.Visible = true;
                    this.Button4.Attributes["onclick"] = "javascript:openUser1(" + list["GlGuize"].ToString() + ");";
                    this.Button3.Attributes["onclick"] = "javascript:openUser2(" + list["GlGuize"].ToString() + ");";
                    this.GlGuize.Text = " - 只允许从默认人员中选择人员";
                }
                else
                {
                    this.Button4.Visible = false;
                    this.Button3.Visible = false;
                    this.Button4.Attributes["onclick"] = "javascript:openUser1(" + list["GlGuize"].ToString() + ");";
                    this.Button3.Attributes["onclick"] = "javascript:openUser2(" + list["GlGuize"].ToString() + ");";
                    this.GlGuize.Text = " - 不允许自由选择人员";
                }
            }
            list.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int num;
            string sql = "select id from qp_oa_WorkFlowNode where id='" + this.FormName.SelectedValue + "'";
            SqlDataReader reader = this.List.GetList(sql);
            if (reader.Read())
            {
                this.ViewState["UpNodeId"] = reader["id"].ToString();
            }
            reader.Close();
            string str2 = null;
            string str3 = null;
            str3 = "" + this.JbUsername.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str3.Split(new char[] { ',' });
            for (num = 0; num < strArray.Length; num++)
            {
                str2 = str2 + "'" + strArray[num] + "',";
            }
            str2 = str2 + "'0'";
            string str4 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str2 + ") ";
            SqlDataReader reader2 = this.List.GetList(str4);
            while (reader2.Read())
            {
                if (this.C1.Checked)
                {
                    this.pulicss.InsertMessage("" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text + "", reader2["username"].ToString(), reader2["realname"].ToString(), "/WorkFlow/WorkFlowList.aspx");
                }
                if (this.C2.Checked)
                {
                    this.pulicss.InsertSms(reader2["MoveTel"].ToString(), "" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", "") + "");
                }
            }
            reader2.Close();
            if (this.C3.Checked)
            {
                this.pulicss.InsertMessage(string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已转交到：", this.FormName.SelectedItem.Text, "" }), this.ViewState["FqUsername"].ToString(), this.ViewState["FqRealname"].ToString(), "#");
            }
            if (this.C4.Checked)
            {
                string str5 = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + this.ViewState["FqUsername"] + "' ";
                SqlDataReader reader3 = this.List.GetList(str5);
                if (reader3.Read())
                {
                    this.pulicss.InsertSms(reader3["MoveTel"].ToString(), string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已转交到：", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "" }));
                }
                reader3.Close();
            }
            string str6 = null;
            string str7 = null;
            str7 = "" + this.ViewState["JbObjectId"] + "";
            ArrayList list2 = new ArrayList();
            string[] strArray2 = str7.Split(new char[] { ',' });
            for (num = 0; num < strArray2.Length; num++)
            {
                str6 = str6 + "'" + strArray2[num] + "',";
            }
            str6 = str6 + "'0'";
            string str8 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str6 + ") ";
            SqlDataReader reader4 = this.List.GetList(str8);
            while (reader4.Read())
            {
                if (this.C5.Checked)
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "等待您办理的工作[", this.ViewState["Name"], "]已转交到：", this.FormName.SelectedItem.Text, "" }), reader4["username"].ToString(), reader4["realname"].ToString(), "#");
                }
                if (this.C6.Checked)
                {
                    this.pulicss.InsertSms(reader4["MoveTel"].ToString(), string.Concat(new object[] { "等待您办理的工作[", this.ViewState["Name"], "]已转交到：", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "" }));
                }
            }
            reader4.Close();
            string str9 = "Update qp_oa_AddWorkFlowPicRy  Set States='已办结'   where KeyFile='" + base.Request.QueryString["Number"] + "'";
            this.List.ExeSql(str9);
            string str10 = "Update qp_oa_AddWorkFlowPicRy  Set EndTime='" + DateTime.Now.ToString() + "'   where KeyFile='" + base.Request.QueryString["Number"] + "'";
            this.List.ExeSql(str10);
            string str11 = "select * from qp_oa_WorkFlowNode where id='" + this.FormName.SelectedValue + "'";
            SqlDataReader reader5 = this.List.GetList(str11);
            if (reader5.Read())
            {
                string str20;
                string str12 = string.Concat(new object[] { 
                    "Update qp_oa_AddWorkFlow  Set GlNum='", this.GlNum.Text, "',YJBNodeNum=YJBNodeNum+',", this.ViewState["NodeNum"], "',State='正在办理',ZbObjectId='", this.ZbUsername.Text, "',ZbObjectName='", this.ZbRealname.Text, "',JbObjectId='", this.JbUsername.Text, "',JbObjectName='", this.JbRealname.Text, "',UpNodeNumber='", reader5["NodeNumber"], "',UpNodeId='", reader5["id"], 
                    "',UpNodeNum='", reader5["NodeNum"], "',UpNodeName='", reader5["NodeName"], "',UpTimeSet='", DateTime.Now.ToString(), "'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'"
                 });
                this.List.ExeSql(str12);
                string str13 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlow where (CHARINDEX(',", this.Session["username"], ",',','+YJBObjectId+',')   >   0 ) and Number='", base.Request.QueryString["Number"], "'" });
                SqlDataReader reader6 = this.List.GetList(str13);
                if (!reader6.Read())
                {
                    string str14 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set YJBObjectId=YJBObjectId+'", this.Session["username"], ",',YJBObjecName=YJBObjecName+'", this.Session["realname"], ",'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'" });
                    this.List.ExeSql(str14);
                }
                reader6.Close();
                string str15 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPic (GlNum,LcNum,KeyFile,XuHao,Jiedian) values ('", this.GlNum.Text, "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", reader5["NodeNum"], "','", reader5["NodeName"], "')" });
                this.List.ExeSql(str15);
                if (this.ZbUsername.Text != "")
                {
                    string str16 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", this.GlNum.Text, "','", reader5["NodeNum"], "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", this.ZbUsername.Text, "','", this.ZbRealname.Text, "','", DateTime.Now.ToString(), "','','未接收','主办')" });
                    this.List.ExeSql(str16);
                }
                string str17 = null;
                string str18 = null;
                if (this.ZbUsername.Text != "")
                {
                    str18 = "" + this.JbUsername.Text.Replace("" + this.ZbUsername.Text + ",", "") + "";
                }
                else
                {
                    str18 = "" + this.JbUsername.Text + "";
                }
                ArrayList list3 = new ArrayList();
                string[] strArray3 = str18.Split(new char[] { ',' });
                for (num = 0; num < strArray3.Length; num++)
                {
                    str17 = str17 + "'" + strArray3[num] + "',";
                }
                str17 = str17 + "'0'";
                string str19 = "select username,realname from qp_oa_Username where  username in (" + str17 + ") ";
                SqlDataReader reader7 = this.List.GetList(str19);
                while (reader7.Read())
                {
                    str20 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", this.GlNum.Text, "','", reader5["NodeNum"], "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", reader7["username"], "','", reader7["realname"], "','", DateTime.Now.ToString(), "','','未接收','经办')" });
                    this.List.ExeSql(str20);
                }
                reader7.Close();
                string str21 = "select A.id as Aid,A.GlNum,A.IfZb,A.LcNum,A.KeyFile,A.XuHao,A.KeyFile,A.BLusername,A.BLrealname,B.* from [qp_oa_AddWorkFlowPicRy] as [A] inner join [qp_oa_MyWeituo] as [B] on [A].[BLusername] = [B].Username and [B].[States] = '1' and [A].KeyFile='" + base.Request.QueryString["Number"] + "' and [A].GlNum='" + this.GlNum.Text + "' ";
                SqlDataReader reader8 = this.List.GetList(str21);
                while (reader8.Read())
                {
                    string str22 = "select id,Number,UpNodeNum,UpNodeName,FormName,Name,JbObjectId,JbObjectName from qp_oa_AddWorkFlow where Number='" + reader8["KeyFile"] + "'";
                    SqlDataReader reader9 = this.List.GetList(str22);
                    if (reader9.Read())
                    {
                        string str23;
                        string str24;
                        string str25;
                        if (reader8["IfZb"].ToString() == "主办")
                        {
                            str23 = "" + reader9["JbObjectId"].ToString().Replace("" + reader8["BLusername"].ToString() + ",", "" + reader8["WtUsername"].ToString() + ",") + "";
                            str24 = "" + reader9["JbObjectName"].ToString().Replace("" + reader8["BLrealname"].ToString() + ",", "" + reader8["WtRealname"].ToString() + ",") + "";
                            str25 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set ZbObjectId='", reader8["WtUsername"], "',ZbObjectName='", reader8["WtRealname"], "',JbObjectId='", str23, "',JbObjectName='", str24, "'  where id='", reader9["id"].ToString(), "'" });
                            this.List.ExeSql(str25);
                        }
                        else
                        {
                            str23 = "" + reader9["JbObjectId"].ToString().Replace("" + reader8["BLusername"].ToString() + ",", "" + reader8["WtUsername"].ToString() + ",") + "";
                            str24 = "" + reader9["JbObjectName"].ToString().Replace("" + reader8["BLrealname"].ToString() + ",", "" + reader8["WtRealname"].ToString() + ",") + "";
                            str25 = "Update qp_oa_AddWorkFlow  Set JbObjectId='" + str23 + "',JbObjectName='" + str24 + "'  where id='" + reader9["id"].ToString() + "'";
                            this.List.ExeSql(str25);
                        }
                    }
                    reader9.Close();
                    if (this.C1.Checked)
                    {
                        this.pulicss.InsertMessage("" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text + "", reader8["WtUsername"].ToString(), reader8["WtRealname"].ToString(), "/WorkFlow/WorkFlowList.aspx");
                    }
                    if (this.C2.Checked)
                    {
                        string str26 = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + reader8["WtUsername"].ToString() + "' ";
                        SqlDataReader reader10 = this.List.GetList(str26);
                        if (reader10.Read())
                        {
                            this.pulicss.InsertSms(reader10["MoveTel"].ToString(), "" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", "") + "");
                        }
                        reader10.Close();
                    }
                    string str27 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已委托',EndTime='", DateTime.Now.ToString(), "',WtUsername='", reader8["WtUsername"], "',WtRealname='", reader8["WtRealname"], "'   where id='", reader8["Aid"], "'" });
                    this.List.ExeSql(str27);
                    str20 = string.Concat(new object[] { 
                        "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", reader8["GlNum"], "','", reader8["XuHao"], "','", reader8["LcNum"], "','", reader8["KeyFile"], "','", reader8["WtUsername"], "','", reader8["WtRealname"], "','", DateTime.Now.ToString(), "','','未接收','", reader8["IfZb"], 
                        "')"
                     });
                    this.List.ExeSql(str20);
                }
                reader8.Close();
                this.showform.AddWorkFlowLog("110", base.Request.QueryString["Number"].ToString(), this.ViewState["FormNames"].ToString(), this.ViewState["NodeName"].ToString(), "转交工作" + this.ViewState["Name"].ToString() + "", "主办");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('未找到下一步骤！');</script>");
                return;
            }
            reader5.Close();
            if (this.ViewState["Chuanyue"].ToString() == "1")
            {
                this.AddEmail();
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close()</script>");
        }

        public void chuangyue()
        {
            string sql = "select Chuanyue,YjUsername,YjRealname,YoujianXm,YjXiugai from qp_oa_WorkFlowNode where id='" + this.ViewState["UpNodeId"].ToString() + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ViewState["Chuanyue"] = list["Chuanyue"].ToString();
                if (list["Chuanyue"].ToString() == "1")
                {
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

        protected void FormName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindLb(this.FormName.SelectedValue);
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
                Random random = new Random();
                string str = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                string sql = "select * from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["FormNames"] = list["FormName"].ToString();
                    this.ViewState["Sequence"] = list["Sequence"].ToString();
                    this.ViewState["Name"] = list["Name"].ToString();
                    this.ViewState["NodeName"] = list["NodeName"].ToString();
                    this.txtSmsContent.Text = "工作流转交提醒：" + list["Name"].ToString() + "";
                    this.ViewState["FqUsername"] = list["FqUsername"].ToString();
                    this.ViewState["FqRealname"] = list["FqRealname"].ToString();
                    this.ViewState["JbObjectId"] = list["JbObjectId"].ToString();
                    this.ViewState["JbObjectName"] = list["JbObjectName"].ToString();
                    this.ViewState["FlowNumber"] = list["FlowNumber"].ToString();
                    this.ViewState["NodeNum"] = list["NodeNum"].ToString();
                    this.ViewState["id"] = list["id"].ToString();
                    this.ViewState["FormId"] = list["FormId"].ToString();
                    this.ViewState["UpNodeId"] = list["UpNodeId"].ToString();
                    this.ViewState["FileContent"] = list["FileContent"].ToString();
                    this.ViewState["WfNumber"] = list["Number"].ToString();
                    this.ViewState["ShuXing"] = list["ShuXing"].ToString();
                    this.ViewState["FormNumber"] = list["FormNumber"].ToString();
                }
                list.Close();
                this.BindDroList();
                if (this.FormName.Items.Count > 0)
                {
                    this.FormName.Items[0].Selected = true;
                }
                this.BindLb(this.FormName.SelectedValue);
                this.GlNum.Text = "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                this.BindAttribute();
                this.chuangyue();
            }
        }
    }
}

