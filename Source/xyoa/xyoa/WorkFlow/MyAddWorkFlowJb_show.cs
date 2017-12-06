namespace xyoa.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyAddWorkFlowJb_show : Page
    {
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected CheckBox CheckBox3;
        protected CheckBox CheckBox7;
        protected TextBox ContractContent;
        public string ddstr;
        public string fjkey;
        public string FlowNumber;
        protected HtmlForm form1;
        public string FormName;
        public string FormNumber;
        protected Label fujian;
        protected TextBox GqUpNodeNumKey;
        protected HtmlHead Head1;
        public string IfZb;
        public string JbHuitui;
        public string JbQuanxian;
        public string JcZhuanjiao;
        protected Label JinJiChengDu;
        public int LcNameId;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        public int lshid;
        public string NodeId;
        public string NodeName;
        protected TextBox Number;
        public string Numbers;
        protected Panel Panel1;
        protected Panel Panel2;
        protected Panel Panel3;
        protected Panel Panel7;
        private publics pulicss = new publics();
        public string SecFileID;
        private divform showform = new divform();
        public string ShuXing;
        protected TextBox TextBox1;
        public string UpNodeNum;
        public string UpNodeNumKey;
        public string UpNodeNums;
        protected Label whname1;
        public string WriteFileID;
        public string YijianJb;
        public string YijianZb;
        public string YzSealNumber;
        public string ZbHuitui;
        public string ZbQuanxian;
        public string ZbZhuanjiao;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                object text;
                if (this.CheckBox2.Checked)
                {
                    this.Panel1.Visible = true;
                }
                else
                {
                    this.Panel1.Visible = false;
                }
                if (this.CheckBox1.Checked)
                {
                    this.Panel2.Visible = true;
                }
                else
                {
                    this.Panel2.Visible = false;
                }
                if (this.CheckBox3.Checked)
                {
                    this.Panel3.Visible = true;
                }
                else
                {
                    this.Panel3.Visible = false;
                }
                if (this.CheckBox7.Checked)
                {
                    this.Panel7.Visible = true;
                }
                else
                {
                    this.Panel7.Visible = false;
                }
                string sql = "select UpNodeName,FlowNumber,Shuxing,FormNumber from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.NodeName = base.Request.QueryString["GlNum"].ToString();
                    this.FlowNumber = list["FlowNumber"].ToString();
                    this.ShuXing = list["Shuxing"].ToString();
                    this.ViewState["BDNumber"] = list["FormNumber"].ToString();
                    string str2 = "select * from qp_oa_FormFile where  type='[关联办理意见]' and KeyFile='" + this.ViewState["BDNumber"] + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    while (reader2.Read())
                    {
                        StateBag bag = ViewState;
                        text = bag["url"];
                        (bag = this.ViewState)["url"] = string.Concat(new object[] { text, "try{window.L", reader2["Number"], ".location.href='AddWorkFlow_spyj.aspx?Number='+num+'&Buzhou=", reader2["sqlstr"], "&key=1';}catch(err){}" });
                    }
                    reader2.Close();
                }
                list.Close();
                string str3 = "select * from qp_oa_AddWorkFlowGc where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader reader3 = this.List.GetList(str3);
                if (reader3.Read())
                {
                    this.JinJiChengDu.Text = this.pulicss.SystemCode("10", reader3["JinJiChengDu"].ToString());
                    this.whname1.Text = reader3["Name"].ToString();
                    this.lshid = int.Parse(reader3["Sequence"].ToString());
                    this.Number.Text = reader3["Number"].ToString();
                    this.Numbers = reader3["Number"].ToString();
                    this.ContractContent.Text = reader3["FileContent"].ToString();
                    this.TextBox1.Text = reader3["FileContent"].ToString();
                }
                reader3.Close();
                this.YzSealNumber = this.Number.Text;
                string str4 = "select  * from qp_oa_AddWorkFlowPic where KeyFile='" + this.Number.Text + "'  order by id asc";
                SqlDataReader reader4 = this.List.GetList(str4);
                this.Liucheng.Text = null;
                int num = 1;
                this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"1\" cellpadding=\"4\" cellspacing=\"0\" width=\"100%\" class=\"nextpage\">";
                while (reader4.Read())
                {
                    SqlDataReader reader6;
                    string str7;
                    TimeSpan span;
                    double num2 = 0.0;
                    string str5 = string.Concat(new object[] { "select XbTimes from qp_oa_WorkFlowNode where  FlowNumber='", this.FlowNumber, "' and NodeNum='", reader4["XuHao"], "' and NodeName='", reader4["Jiedian"], "'" });
                    SqlDataReader reader5 = this.List.GetList(str5);
                    if (reader5.Read())
                    {
                        num2 = double.Parse(reader5["XbTimes"].ToString());
                    }
                    reader5.Close();
                    string str6 = null;
                    if (reader4["GlNum"].ToString() == this.NodeName)
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/><font color=red>序号", reader4["XuHao"], "：", reader4["Jiedian"], "(办理步骤)</font></td>" });
                    }
                    else
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>序号", reader4["XuHao"], "：", reader4["Jiedian"], "</td>" });
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "<td class=\"newtd2\" width=\"60%\" style=\"line-height: 150%\">";
                    if (this.ShuXing == "自由流程")
                    {
                        str6 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader4["LcNum"].ToString() + "'  order by id asc";
                        reader6 = this.List.GetList(str6);
                        while (reader6.Read())
                        {
                            str7 = "";
                            if (reader6["States"].ToString() == "未接收")
                            {
                                str7 = "flow_close.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader6["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a><font color=#008000>(", reader6["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader6["StartTime"], "<br>实际结束时间：", reader6["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>"
                                 });
                            }
                            else if (reader6["States"].ToString() == "办理中")
                            {
                                str7 = "flow_open.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader6["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a><font color=#008000>(", reader6["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader6["StartTime"], "<br>实际结束时间：", reader6["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>"
                                 });
                            }
                            else if (reader6["States"].ToString() == "已委托")
                            {
                                str7 = "Menu285.gif";
                                span = (TimeSpan) (DateTime.Parse(reader6["EndTime"].ToString()) - DateTime.Parse(reader6["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a></font><font color=#008000>(", reader6["States"], "&nbsp;→&nbsp;", 
                                    reader6["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader6["StartTime"], "<br>结束于：", reader6["EndTime"], "<br>"
                                 });
                            }
                            else
                            {
                                str7 = "workflow_query.gif";
                                span = (TimeSpan) (DateTime.Parse(reader6["EndTime"].ToString()) - DateTime.Parse(reader6["StartTime"].ToString()));
                                if (((((reader6["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader6["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader6["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader6["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader6["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader6["EndTime"].ToString() == "1900/1/1 00:00:00"))
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a></font><font color=#008000>(", reader6["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader6["StartTime"], "<br>结束于：", reader6["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a></font><font color=#008000>(", reader6["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader6["StartTime"], "<br>结束于：", reader6["EndTime"], "<br>"
                                     });
                                }
                            }
                        }
                        reader6.Close();
                    }
                    else
                    {
                        str6 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader4["LcNum"].ToString() + "'  order by id asc";
                        reader6 = this.List.GetList(str6);
                        while (reader6.Read())
                        {
                            TimeSpan span2;
                            string str8;
                            str7 = "";
                            if (reader6["States"].ToString() == "未接收")
                            {
                                str7 = "flow_close.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader6["StartTime"].ToString()));
                                span2 = (TimeSpan) (DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(DateTime.Now.ToString()));
                                str8 = "" + span2.TotalSeconds + "";
                                if (span2.TotalSeconds >= 0.0)
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a><font color=#008000>(", reader6["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader6["StartTime"], "<br>实际结束时间：", reader6["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>限办完成时间：", DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：离限办时间还有 ", this.pulicss.ShowDateTime(double.Parse(str8.Replace("-", ""))), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a><font color=#008000>(", reader6["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader6["StartTime"], "<br>实际结束时间：", reader6["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>限办完成时间：", DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：已超时：", this.pulicss.ShowDateTime(double.Parse(str8.Replace("-", ""))), "<br>"
                                     });
                                }
                            }
                            else if (reader6["States"].ToString() == "办理中")
                            {
                                str7 = "flow_open.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader6["StartTime"].ToString()));
                                span2 = (TimeSpan) (DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(DateTime.Now.ToString()));
                                str8 = "" + span2.TotalSeconds + "";
                                if (span2.TotalSeconds >= 0.0)
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a><font color=#008000>(", reader6["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader6["StartTime"], "<br>实际结束时间：", reader6["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>限办完成时间：", DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：离限办时间还有 ", this.pulicss.ShowDateTime(double.Parse(str8.Replace("-", ""))), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a><font color=#008000>(", reader6["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader6["StartTime"], "<br>实际结束时间：", reader6["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>限办完成时间：", DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：已超时：", this.pulicss.ShowDateTime(double.Parse(str8.Replace("-", ""))), "<br>"
                                     });
                                }
                            }
                            else
                            {
                                string str9;
                                if (reader6["States"].ToString() == "已委托")
                                {
                                    str7 = "Menu285.gif";
                                    span = (TimeSpan) (DateTime.Parse(reader6["EndTime"].ToString()) - DateTime.Parse(reader6["StartTime"].ToString()));
                                    span2 = (TimeSpan) (DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(reader6["EndTime"].ToString()));
                                    str8 = "" + span2.TotalSeconds + "";
                                    str9 = "" + Math.Round((double) (span2.TotalSeconds / 3600.0), 2) + "";
                                    if (span2.TotalSeconds >= 0.0)
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a></font><font color=#008000>(", reader6["States"], "&nbsp;→&nbsp;", 
                                            reader6["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader6["StartTime"], "<br>结束于：", reader6["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：提前： ", this.pulicss.ShowDateTime(double.Parse(str8.Replace("-", ""))), "<br>效率值：", str9, "<br>"
                                         });
                                    }
                                    else
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a></font><font color=#008000>(", reader6["States"], "&nbsp;→&nbsp;", 
                                            reader6["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader6["StartTime"], "<br>结束于：", reader6["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：超时： ", this.pulicss.ShowDateTime(double.Parse(str8.Replace("-", ""))), "<br>效率值：", str9, "<br>"
                                         });
                                    }
                                }
                                else
                                {
                                    str7 = "workflow_query.gif";
                                    span = (TimeSpan) (DateTime.Parse(reader6["EndTime"].ToString()) - DateTime.Parse(reader6["StartTime"].ToString()));
                                    span2 = (TimeSpan) (DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(reader6["EndTime"].ToString()));
                                    str8 = "" + span2.TotalSeconds + "";
                                    str9 = "" + Math.Round((double) (span2.TotalSeconds / 3600.0), 2) + "";
                                    if (((((reader6["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader6["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader6["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader6["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader6["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader6["EndTime"].ToString() == "1900/1/1 00:00:00"))
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a><font color=#008000>(", reader6["States"], "&nbsp;&nbsp;用时：)</font><br>开始于：", 
                                            reader6["StartTime"], "<br>结束于：", reader6["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>限办完成时间：", DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：未接收办理，由其他人员直接转交<br>效率值：0<br>"
                                         });
                                    }
                                    else if (span2.TotalSeconds >= 0.0)
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a></font><font color=#008000>(", reader6["States"], "&nbsp;&nbsp;用时：", 
                                            this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader6["StartTime"], "<br>结束于：", reader6["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：提前： ", this.pulicss.ShowDateTime(double.Parse(str8.Replace("-", ""))), "<br>效率值：", str9, "<br>"
                                         });
                                    }
                                    else
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader6["IfZb"], "，", reader6["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader6["BLusername"].ToString(), "')  title=\"", reader6["IfZb"], "\"><b><font color=#FF0000>", reader6["BLrealname"], "</font></b></a></font><font color=#008000>(", reader6["States"], "&nbsp;&nbsp;用时：", 
                                            this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader6["StartTime"], "<br>结束于：", reader6["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader6["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：超时： ", this.pulicss.ShowDateTime(double.Parse(str8.Replace("-", ""))), "<br>效率值：", str9, "<br>"
                                         });
                                    }
                                }
                            }
                        }
                        reader6.Close();
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "</td>";
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                    num++;
                }
                reader4.Close();
                this.Liucheng.Text = this.Liucheng.Text + "</table>";
                this.pulicss.GetFile(this.Number.Text, this.fujian);
            }
        }
    }
}

