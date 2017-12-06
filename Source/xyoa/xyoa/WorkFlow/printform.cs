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

    public class printform : Page
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
        public string FlowNumber;
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
                string sql = "select * from qp_oa_WorkFlowNode where id='" + int.Parse(base.Request.QueryString["UpNodeId"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.NodeName = list["NodeName"].ToString();
                    this.UpNodeNum = list["UpNodeNum"].ToString();
                    this.NodeId = list["id"].ToString();
                    string str2 = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        string str6;
                        SqlDataReader reader6;
                        string str7;
                        SqlDataReader reader7;
                        StateBag bag = ViewState;
                        this.ViewState["BDNumber"] = reader2["FormNumber"].ToString();
                        this.JinJiChengDu.Text = this.pulicss.SystemCode("10", reader2["JinJiChengDu"].ToString());
                        this.whname1.Text = reader2["Name"].ToString();
                        this.lshid = int.Parse(reader2["Sequence"].ToString());
                        this.Number.Text = reader2["Number"].ToString();
                        this.Numbers = reader2["Number"].ToString();
                        this.UpNodeNums = reader2["UpNodeNum"].ToString();
                        this.ShuXing = reader2["ShuXing"].ToString();
                        this.FlowNumber = reader2["FlowNumber"].ToString();
                        this.ViewState["WriteFileID"] = "" + list["WriteFileID"].ToString() + "0";
                        this.ViewState["SecFileID"] = "" + list["SecFileID"].ToString() + "0";
                        this.ViewState["HongFileID"] = "" + list["HongFileID"].ToString() + "0";
                        string str3 = "select * from qp_oa_FormFile where  type='[关联办理意见]' and KeyFile='" + this.ViewState["BDNumber"] + "'";
                        SqlDataReader reader3 = this.List.GetList(str3);
                        while (reader3.Read())
                        {
                            text = bag["url"];
                            (bag = this.ViewState)["url"] = string.Concat(new object[] { text, "window.L", reader3["Number"], ".location.href='AddWorkFlow_spyj.aspx?Number='+num+'&Buzhou=", reader3["sqlstr"], "&key=1';" });
                        }
                        reader3.Close();
                        this.ViewState["GuolvKxFileID"] = "";
                        string str4 = string.Concat(new object[] { "select * from qp_oa_WorkFlowNodeGuolv where CHARINDEX(',", this.Session["username"], ",',','+KxGuoLvUser+',') > 0 and NodeId='", int.Parse(base.Request.QueryString["UpNodeId"]), "'" });
                        SqlDataReader reader4 = this.List.GetList(str4);
                        while (reader4.Read())
                        {
                            this.ViewState["GuolvKxFileID"] = reader4["GuolvFileID"].ToString() + this.ViewState["GuolvKxFileID"].ToString();
                        }
                        reader4.Close();
                        (bag = this.ViewState)["GuolvKxFileID"] = bag["GuolvKxFileID"] + "0";
                        this.ViewState["GuolvBmFileID"] = "";
                        string str5 = string.Concat(new object[] { "select * from qp_oa_WorkFlowNodeGuolv where CHARINDEX(',", this.Session["username"], ",',','+BmGuoLvUser+',') > 0 and NodeId='", int.Parse(base.Request.QueryString["UpNodeId"]), "'" });
                        SqlDataReader reader5 = this.List.GetList(str5);
                        while (reader5.Read())
                        {
                            this.ViewState["GuolvBmFileID"] = reader5["GuolvFileID"].ToString() + this.ViewState["GuolvBmFileID"].ToString();
                        }
                        reader5.Close();
                        (bag = this.ViewState)["GuolvBmFileID"] = bag["GuolvBmFileID"] + "0";
                        this.ContractContent.Text = this.showform.FormatKjStrZh(reader2["FileContent"].ToString());
                        this.TextBox1.Text = this.showform.FormatKjStrZh(reader2["FileContent"].ToString());
                        if (this.ViewState["GuolvKxFileID"].ToString().Length < 1)
                        {
                            str6 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ")  and KeyFile='", this.ViewState["BDNumber"], "' and Type!='[印章域]'" });
                            reader6 = this.List.GetList(str6);
                            while (reader6.Read())
                            {
                                this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader6["Number"].ToString() + "", "name=" + reader6["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader6["Number"].ToString() + "\"", "name=" + reader6["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                                this.TextBox1.Text = this.ContractContent.Text;
                            }
                            reader6.Close();
                        }
                        else
                        {
                            str6 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ") and id not in (", this.ViewState["GuolvKxFileID"], ") and KeyFile='", this.ViewState["BDNumber"], "' and Type!='[印章域]'" });
                            reader6 = this.List.GetList(str6);
                            while (reader6.Read())
                            {
                                this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader6["Number"].ToString() + "", "name=" + reader6["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader6["Number"].ToString() + "\"", "name=" + reader6["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                                this.TextBox1.Text = this.ContractContent.Text;
                            }
                            reader6.Close();
                        }
                        if (this.ViewState["GuolvBmFileID"].ToString().Length < 1)
                        {
                            str7 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["SecFileID"], ") and  KeyFile='", this.ViewState["BDNumber"], "' and Type!='[印章域]'" });
                            reader7 = this.List.GetList(str7);
                            while (reader7.Read())
                            {
                                this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader7["Number"].ToString() + "", "name=" + reader7["Number"].ToString() + "  style=\"display:none\"").Replace("name=\"" + reader7["Number"].ToString() + "\"", "name=" + reader7["Number"].ToString() + "  style=\"display:none\"");
                                this.TextBox1.Text = this.ContractContent.Text;
                            }
                            reader7.Close();
                        }
                        else
                        {
                            str7 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["SecFileID"], ") and id not in (", this.ViewState["GuolvBmFileID"], ") and  KeyFile='", this.ViewState["BDNumber"], "' and Type!='[印章域]'" });
                            reader7 = this.List.GetList(str7);
                            while (reader7.Read())
                            {
                                this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader7["Number"].ToString() + "", "name=" + reader7["Number"].ToString() + "  style=\"display:none\"").Replace("name=\"" + reader7["Number"].ToString() + "\"", "name=" + reader7["Number"].ToString() + "  style=\"display:none\"");
                                this.TextBox1.Text = this.ContractContent.Text;
                            }
                            reader7.Close();
                        }
                    }
                    reader2.Close();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('未找到此流程，有可能此流程已被删除！');window.close();</script>");
                    return;
                }
                list.Close();
                this.YzSealNumber = this.Number.Text;
                string str8 = "select * from qp_oa_AddWorkFlowLog  where Number='" + this.Number.Text + "' order by id asc";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str8);
                this.GridView1.DataBind();
                string str9 = "select * from qp_oa_AddWorkFlowMessage  where Number='" + this.Number.Text + "' order by id asc";
                this.GridView2.DataSource = this.List.GetGrid_Pages_not(str9);
                this.GridView2.DataBind();
                string str10 = "select * from qp_oa_AddWorkFlowSeal  where Number='" + this.Number.Text + "' order by id asc";
                this.GridView3.DataSource = this.List.GetGrid_Pages_not(str10);
                this.GridView3.DataBind();
                string str11 = "select  * from qp_oa_AddWorkFlowPic where KeyFile='" + this.Number.Text + "'  order by id asc";
                SqlDataReader reader8 = this.List.GetList(str11);
                this.Liucheng.Text = null;
                int num = 1;
                this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"1\" cellpadding=\"4\" cellspacing=\"0\" width=\"100%\" class=\"nextpage\">";
                while (reader8.Read())
                {
                    SqlDataReader reader10;
                    string str14;
                    TimeSpan span;
                    double num2 = 0.0;
                    string str12 = string.Concat(new object[] { "select XbTimes from qp_oa_WorkFlowNode where  FlowNumber='", this.FlowNumber, "' and NodeNum='", reader8["XuHao"], "' and NodeName='", reader8["Jiedian"], "'" });
                    SqlDataReader reader9 = this.List.GetList(str12);
                    if (reader9.Read())
                    {
                        num2 = double.Parse(reader9["XbTimes"].ToString());
                    }
                    reader9.Close();
                    string str13 = null;
                    if (reader8["Jiedian"].ToString() == this.NodeName)
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>序号", reader8["XuHao"], "：", reader8["Jiedian"], "(当前步骤) </td>" });
                    }
                    else
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"10%\">第<font color=red><b>", num, "</b></font>步</td><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>序号", reader8["XuHao"], "：", reader8["Jiedian"], "</td>" });
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "<td class=\"newtd2\" width=\"60%\" style=\"line-height: 150%\">";
                    if (this.ShuXing == "自由流程")
                    {
                        str13 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader8["LcNum"].ToString() + "'  order by id asc";
                        reader10 = this.List.GetList(str13);
                        while (reader10.Read())
                        {
                            str14 = "";
                            if (reader10["States"].ToString() == "未接收")
                            {
                                str14 = "flow_close.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader10["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a><font color=#008000>(", reader10["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader10["StartTime"], "<br>实际结束时间：", reader10["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>"
                                 });
                            }
                            else if (reader10["States"].ToString() == "办理中")
                            {
                                str14 = "flow_open.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader10["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a><font color=#008000>(", reader10["States"], "&nbsp;&nbsp;用时：", 
                                    this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader10["StartTime"], "<br>实际结束时间：", reader10["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>"
                                 });
                            }
                            else if (reader10["States"].ToString() == "已委托")
                            {
                                str14 = "Menu285.gif";
                                span = (TimeSpan) (DateTime.Parse(reader10["EndTime"].ToString()) - DateTime.Parse(reader10["StartTime"].ToString()));
                                text = this.Liucheng.Text;
                                this.Liucheng.Text = string.Concat(new object[] { 
                                    text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a></font><font color=#008000>(", reader10["States"], "&nbsp;→&nbsp;", 
                                    reader10["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader10["StartTime"], "<br>结束于：", reader10["EndTime"], "<br>"
                                 });
                            }
                            else
                            {
                                str14 = "workflow_query.gif";
                                span = (TimeSpan) (DateTime.Parse(reader10["EndTime"].ToString()) - DateTime.Parse(reader10["StartTime"].ToString()));
                                if (((((reader10["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader10["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader10["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader10["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader10["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader10["EndTime"].ToString() == "1900/1/1 00:00:00"))
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a></font><font color=#008000>(", reader10["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader10["StartTime"], "<br>结束于：", reader10["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a></font><font color=#008000>(", reader10["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader10["StartTime"], "<br>结束于：", reader10["EndTime"], "<br>"
                                     });
                                }
                            }
                        }
                        reader10.Close();
                    }
                    else
                    {
                        str13 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + reader8["LcNum"].ToString() + "'  order by id asc";
                        reader10 = this.List.GetList(str13);
                        while (reader10.Read())
                        {
                            TimeSpan span2;
                            string str15;
                            str14 = "";
                            if (reader10["States"].ToString() == "未接收")
                            {
                                str14 = "flow_close.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader10["StartTime"].ToString()));
                                span2 = (TimeSpan) (DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(DateTime.Now.ToString()));
                                str15 = "" + span2.TotalSeconds + "";
                                if (span2.TotalSeconds >= 0.0)
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a><font color=#008000>(", reader10["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader10["StartTime"], "<br>实际结束时间：", reader10["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>限办完成时间：", DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：离限办时间还有 ", this.pulicss.ShowDateTime(double.Parse(str15.Replace("-", ""))), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a><font color=#008000>(", reader10["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader10["StartTime"], "<br>实际结束时间：", reader10["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>限办完成时间：", DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：已超时：", this.pulicss.ShowDateTime(double.Parse(str15.Replace("-", ""))), "<br>"
                                     });
                                }
                            }
                            else if (reader10["States"].ToString() == "办理中")
                            {
                                str14 = "flow_open.gif";
                                span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader10["StartTime"].ToString()));
                                span2 = (TimeSpan) (DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(DateTime.Now.ToString()));
                                str15 = "" + span2.TotalSeconds + "";
                                if (span2.TotalSeconds >= 0.0)
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a><font color=#008000>(", reader10["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader10["StartTime"], "<br>实际结束时间：", reader10["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>限办完成时间：", DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：离限办时间还有 ", this.pulicss.ShowDateTime(double.Parse(str15.Replace("-", ""))), "<br>"
                                     });
                                }
                                else
                                {
                                    text = this.Liucheng.Text;
                                    this.Liucheng.Text = string.Concat(new object[] { 
                                        text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a><font color=#008000>(", reader10["States"], "&nbsp;&nbsp;用时：", 
                                        this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>办理开始时间：", reader10["StartTime"], "<br>实际结束时间：", reader10["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>限办完成时间：", DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：已超时：", this.pulicss.ShowDateTime(double.Parse(str15.Replace("-", ""))), "<br>"
                                     });
                                }
                            }
                            else
                            {
                                string str16;
                                if (reader10["States"].ToString() == "已委托")
                                {
                                    str14 = "Menu285.gif";
                                    span = (TimeSpan) (DateTime.Parse(reader10["EndTime"].ToString()) - DateTime.Parse(reader10["StartTime"].ToString()));
                                    span2 = (TimeSpan) (DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(reader10["EndTime"].ToString()));
                                    str15 = "" + span2.TotalSeconds + "";
                                    str16 = "" + Math.Round((double) (span2.TotalSeconds / 3600.0), 2) + "";
                                    if (span2.TotalSeconds >= 0.0)
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a></font><font color=#008000>(", reader10["States"], "&nbsp;→&nbsp;", 
                                            reader10["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader10["StartTime"], "<br>结束于：", reader10["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：提前： ", this.pulicss.ShowDateTime(double.Parse(str15.Replace("-", ""))), "<br>效率值：", str16, "<br>"
                                         });
                                    }
                                    else
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a></font><font color=#008000>(", reader10["States"], "&nbsp;→&nbsp;", 
                                            reader10["WtRealname"], "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader10["StartTime"], "<br>结束于：", reader10["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：超时： ", this.pulicss.ShowDateTime(double.Parse(str15.Replace("-", ""))), "<br>效率值：", str16, "<br>"
                                         });
                                    }
                                }
                                else
                                {
                                    str14 = "workflow_query.gif";
                                    span = (TimeSpan) (DateTime.Parse(reader10["EndTime"].ToString()) - DateTime.Parse(reader10["StartTime"].ToString()));
                                    span2 = (TimeSpan) (DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2) - DateTime.Parse(reader10["EndTime"].ToString()));
                                    str15 = "" + span2.TotalSeconds + "";
                                    str16 = "" + Math.Round((double) (span2.TotalSeconds / 3600.0), 2) + "";
                                    if (((((reader10["EndTime"].ToString() == "1900-1-1 0:00:00") || (reader10["EndTime"].ToString() == "1900-01-01 00:00:00")) || ((reader10["EndTime"].ToString() == "1900-1-1 00:00:00") || (reader10["EndTime"].ToString() == "1900/1/1 0:00:00"))) || (reader10["EndTime"].ToString() == "1900/01/01 00:00:00")) || (reader10["EndTime"].ToString() == "1900/1/1 00:00:00"))
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a><font color=#008000>(", reader10["States"], "&nbsp;&nbsp;用时：)</font><br>开始于：", 
                                            reader10["StartTime"], "<br>结束于：", reader10["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未办理").Replace("1900-01-01 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理").Replace("1900-1-1 00:00:00", "未办理"), "<br>限办完成时间：", DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：未接收办理，由其他人员直接转交<br>效率值：0<br>"
                                         });
                                    }
                                    else if (span2.TotalSeconds >= 0.0)
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a></font><font color=#008000>(", reader10["States"], "&nbsp;&nbsp;用时：", 
                                            this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader10["StartTime"], "<br>结束于：", reader10["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：提前： ", this.pulicss.ShowDateTime(double.Parse(str15.Replace("-", ""))), "<br>效率值：", str16, "<br>"
                                         });
                                    }
                                    else
                                    {
                                        text = this.Liucheng.Text;
                                        this.Liucheng.Text = string.Concat(new object[] { 
                                            text, "<img src=\"/oaimg/menu/", str14, "\"  title=\"", reader10["IfZb"], "，", reader10["States"].ToString(), "\"/>&nbsp;<a href=javascript:void(0) onclick=senduser('", reader10["BLusername"].ToString(), "')  title=\"", reader10["IfZb"], "\"><b><font color=#FF0000>", reader10["BLrealname"], "</font></b></a></font><font color=#008000>(", reader10["States"], "&nbsp;&nbsp;用时：", 
                                            this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>开始于：", reader10["StartTime"], "<br>结束于：", reader10["EndTime"], "<br>限办完成时间：", DateTime.Parse(reader10["StartTime"].ToString()).AddHours(num2), "<br>步骤办理效率：超时： ", this.pulicss.ShowDateTime(double.Parse(str15.Replace("-", ""))), "<br>效率值：", str16, "<br>"
                                         });
                                    }
                                }
                            }
                        }
                        reader10.Close();
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "</td>";
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                    num++;
                }
                reader8.Close();
                this.Liucheng.Text = this.Liucheng.Text + "</table>";
                this.pulicss.GetFile(this.Number.Text, this.fujian);
            }
        }
    }
}

