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

    public class printformzy : Page
    {
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected CheckBox CheckBox3;
        protected CheckBox CheckBox4;
        protected CheckBox CheckBox5;
        protected CheckBox CheckBox6;
        protected CheckBox CheckBox7;
        protected TextBox ContractContent;
        public string ddstr;
        public string fjkey;
        protected HtmlForm form1;
        public string FormName;
        public string FormNumber;
        protected Label fujian;
        protected TextBox GqUpNodeNumKey;
        protected GridView GridView1;
        protected GridView GridView2;
        protected GridView GridView3;
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
        protected Panel Panel4;
        protected Panel Panel5;
        protected Panel Panel6;
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
                if (this.CheckBox4.Checked)
                {
                    this.Panel4.Visible = true;
                }
                else
                {
                    this.Panel4.Visible = false;
                }
                if (this.CheckBox5.Checked)
                {
                    this.Panel5.Visible = true;
                }
                else
                {
                    this.Panel5.Visible = false;
                }
                if (this.CheckBox6.Checked)
                {
                    this.Panel6.Visible = true;
                }
                else
                {
                    this.Panel6.Visible = false;
                }
                if (this.CheckBox7.Checked)
                {
                    this.Panel7.Visible = true;
                }
                else
                {
                    this.Panel7.Visible = false;
                }
                string sql = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.JinJiChengDu.Text = this.pulicss.SystemCode("10", list["JinJiChengDu"].ToString());
                    this.whname1.Text = list["Name"].ToString();
                    this.lshid = int.Parse(list["Sequence"].ToString());
                    this.Number.Text = list["Number"].ToString();
                    this.Numbers = list["Number"].ToString();
                    this.UpNodeNums = list["UpNodeNum"].ToString();
                    this.ContractContent.Text = this.showform.FormatKjStrZh(list["FileContent"].ToString());
                    this.TextBox1.Text = this.showform.FormatKjStrZh(list["FileContent"].ToString());
                }
                list.Close();
                string str2 = "select * from qp_oa_AddWorkFlowLog  where Number='" + this.Number.Text + "' order by id asc";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
                this.GridView1.DataBind();
                string str3 = "select * from qp_oa_AddWorkFlowMessage  where Number='" + this.Number.Text + "' order by id asc";
                this.GridView2.DataSource = this.List.GetGrid_Pages_not(str3);
                this.GridView2.DataBind();
                string str4 = "select * from qp_oa_AddWorkFlowSeal  where Number='" + this.Number.Text + "' order by id asc";
                this.GridView3.DataSource = this.List.GetGrid_Pages_not(str4);
                this.GridView3.DataBind();
                string str5 = "select  * from qp_oa_AddWorkFlowPic where KeyFile='" + this.Number.Text + "'  order by id asc";
                SqlDataReader reader2 = this.List.GetList(str5);
                this.Liucheng.Text = null;
                int num = 1;
                this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"1\" cellpadding=\"4\" cellspacing=\"0\" width=\"100%\" class=\"nextpage\">";
                while (reader2.Read())
                {
                    object text;
                    string str6 = null;
                    if (reader2["Jiedian"].ToString() == this.NodeName)
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>序号", reader2["XuHao"], "：", reader2["Jiedian"], "(当前步骤) </td>" });
                    }
                    else
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>序号", reader2["XuHao"], "：", reader2["Jiedian"], "</td>" });
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "<td class=\"newtd2\" width=\"60%\">";
                    str6 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader2["LcNum"].ToString() + "'  order by id asc";
                    SqlDataReader reader3 = this.List.GetList(str6);
                    while (reader3.Read())
                    {
                        TimeSpan span;
                        string str7 = "";
                        if (reader3["States"].ToString() == "未接收")
                        {
                            str7 = "flow_close.gif";
                            if (((((reader3["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader3["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader3["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader3["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader3["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader3["EndTime"].ToString() == "1900/1/1 00:00:00"))
                            {
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>"
                                 });
                            }
                            else
                            {
                                span = (TimeSpan) (DateTime.Parse(reader3["EndTime"].ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a></font><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"], "<br>"
                                 });
                            }
                        }
                        else if (reader3["States"].ToString() == "办理中")
                        {
                            str7 = "flow_open.gif";
                            span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>"
                             });
                        }
                        else if (reader3["States"].ToString() == "已委托")
                        {
                            str7 = "Menu285.gif";
                            if (((((reader3["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader3["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader3["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader3["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader3["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader3["EndTime"].ToString() == "1900/1/1 00:00:00"))
                            {
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a><font color=#008000>(", reader3["States"], "&nbsp;→&nbsp;", 
                                    reader3["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>"
                                 });
                            }
                            else
                            {
                                span = (TimeSpan) (DateTime.Parse(reader3["EndTime"].ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a></font><font color=#008000>(", reader3["States"], "&nbsp;→&nbsp;", 
                                    reader3["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"], "<br>"
                                 });
                            }
                        }
                        else
                        {
                            str7 = "workflow_query.gif";
                            if (((((reader3["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader3["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader3["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader3["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader3["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader3["EndTime"].ToString() == "1900/1/1 00:00:00"))
                            {
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：)</font><br>开始于：", 
                                    reader3["StartTime"], "<br>结束于：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>"
                                 });
                            }
                            else
                            {
                                span = (TimeSpan) (DateTime.Parse(reader3["EndTime"].ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str7, "\"  title=\"", reader3["IfZb"], "，", reader3["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader3["BLusername"].ToString(), "')  title=\"", reader3["IfZb"], "\"><b><font color=#FF0000>", reader3["BLrealname"], "</font></b></a></font><font color=#008000>(", reader3["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader3["StartTime"], "<br>结束于：", reader3["EndTime"], "<br>"
                                 });
                            }
                        }
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "</td>";
                    reader3.Close();
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                    num++;
                }
                reader2.Close();
                this.Liucheng.Text = this.Liucheng.Text + "</table>";
                this.pulicss.GetFile(this.Number.Text, this.fujian);
            }
        }
    }
}

