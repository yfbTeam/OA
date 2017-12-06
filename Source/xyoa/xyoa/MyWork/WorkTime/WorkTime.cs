namespace xyoa.MyWork.WorkTime
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkTime : Page
    {
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button5;
        protected Button Button6;
        protected Button Button7;
        protected TextBox DjTime_1;
        protected TextBox DjTime_2;
        protected TextBox DjTime_3;
        protected TextBox DjTime_4;
        protected TextBox DjTime_5;
        protected TextBox DjTime_6;
        protected Label DjType_1;
        protected Label DjType_1_u;
        protected Label DjType_2;
        protected Label DjType_2_u;
        protected Label DjType_3;
        protected Label DjType_3_u;
        protected Label DjType_4;
        protected Label DjType_4_u;
        protected Label DjType_5;
        protected Label DjType_5_u;
        protected Label DjType_6;
        protected Label DjType_6_u;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label jxtime;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button2.Attributes.Add("onclick", "javascript:return dj();");
            this.Button3.Attributes.Add("onclick", "javascript:return dj();");
            this.Button4.Attributes.Add("onclick", "javascript:return dj();");
            this.Button5.Attributes.Add("onclick", "javascript:return dj();");
            this.Button6.Attributes.Add("onclick", "javascript:return dj();");
            this.Button7.Attributes.Add("onclick", "javascript:return dj();");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "select * from qp_WorkTimeDj where DjUsername='", this.Session["username"], "' and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read() && (list["DjState_1"].ToString() != "未考勤"))
            {
                base.Response.Write("<script language=javascript>alert('已经考勤完成，请勿重复操作');</script>");
            }
            else
            {
                TimeSpan span = new TimeSpan();
                DateTime now = DateTime.Now;
                DateTime time2 = DateTime.Parse(this.DjTime_1.Text);
                span = (TimeSpan) (now - time2);
                if (span.TotalSeconds > 0.0)
                {
                    if (this.DjType_1.Text == "上班")
                    {
                        this.DjType_1_u.Text = "迟到";
                    }
                    else
                    {
                        this.DjType_1_u.Text = "正常";
                    }
                }
                else if (span.TotalSeconds == 0.0)
                {
                    if (this.DjType_1.Text == "上班")
                    {
                        this.DjType_1_u.Text = "正常";
                    }
                    else
                    {
                        this.DjType_1_u.Text = "正常";
                    }
                }
                else if (this.DjType_1.Text == "上班")
                {
                    this.DjType_1_u.Text = "正常";
                }
                else
                {
                    this.DjType_1_u.Text = "早退";
                }
                string str2 = string.Concat(new object[] { "Update qp_WorkTimeDj Set DjState_1='", this.DjType_1_u.Text, "',DjTime_1='", DateTime.Now.Hour.ToString(), ":", DateTime.Now.Minute.ToString(), ":", DateTime.Now.Second.ToString(), "',FDjtime='", DateTime.Now.ToString(), "' where DjUsername='", this.Session["username"], "' and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
                this.List.ExeSql(str2);
                base.Response.Write(@"<script language=javascript>alert('登记成功！\n当前登记状态：[" + this.DjType_1_u.Text + "]');window.location.href='WorkTime.aspx'</script>");
                list.Close();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            TimeSpan span = new TimeSpan();
            DateTime now = DateTime.Now;
            DateTime time2 = DateTime.Parse(this.DjTime_1.Text);
            span = (TimeSpan) (now - time2);
            if (span.TotalSeconds < 0.0)
            {
                base.Response.Write("<script language=javascript>alert('未经过【第一次】考勤的时间，不能进行【第二次】考勤');</script>");
            }
            else
            {
                string sql = string.Concat(new object[] { "select * from qp_WorkTimeDj where DjUsername='", this.Session["username"], "'  and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["DjState_2"].ToString() != "未考勤")
                    {
                        base.Response.Write("<script language=javascript>alert('已经考勤完成，请勿重复操作');</script>");
                        return;
                    }
                    TimeSpan span2 = new TimeSpan();
                    DateTime time3 = DateTime.Now;
                    DateTime time4 = DateTime.Parse(list["FDjtime"].ToString());
                    span2 = (TimeSpan) (time3 - time4);
                    if (span2.Minutes < int.Parse(this.jxtime.Text))
                    {
                        base.Response.Write("<script language=javascript>alert('当前时间小于登记间歇时间：[" + this.jxtime.Text + "]分');</script>");
                        return;
                    }
                }
                TimeSpan span3 = new TimeSpan();
                DateTime time5 = DateTime.Now;
                DateTime time6 = DateTime.Parse(this.DjTime_2.Text);
                span3 = (TimeSpan) (time5 - time6);
                if (span3.TotalSeconds > 0.0)
                {
                    if (this.DjType_2.Text == "上班")
                    {
                        this.DjType_2_u.Text = "迟到";
                    }
                    else
                    {
                        this.DjType_2_u.Text = "正常";
                    }
                }
                else if (span3.TotalSeconds == 0.0)
                {
                    if (this.DjType_2.Text == "上班")
                    {
                        this.DjType_2_u.Text = "正常";
                    }
                    else
                    {
                        this.DjType_2_u.Text = "正常";
                    }
                }
                else if (this.DjType_2.Text == "上班")
                {
                    this.DjType_2_u.Text = "正常";
                }
                else
                {
                    this.DjType_2_u.Text = "早退";
                }
                string str2 = string.Concat(new object[] { "Update qp_WorkTimeDj Set DjState_2='", this.DjType_2_u.Text, "',DjTime_2='", DateTime.Now.Hour.ToString(), ":", DateTime.Now.Minute.ToString(), ":", DateTime.Now.Second.ToString(), "',FDjtime='", DateTime.Now.ToString(), "' where DjUsername='", this.Session["username"], "' and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
                this.List.ExeSql(str2);
                base.Response.Write(@"<script language=javascript>alert('登记成功！\n当前登记状态：[" + this.DjType_2_u.Text + "]');window.location.href='WorkTime.aspx'</script>");
                list.Close();
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TimeSpan span = new TimeSpan();
            DateTime now = DateTime.Now;
            DateTime time2 = DateTime.Parse(this.DjTime_2.Text);
            span = (TimeSpan) (now - time2);
            if (span.TotalSeconds < 0.0)
            {
                base.Response.Write("<script language=javascript>alert('未经过【第二次】考勤的时间，不能进行【第三次】考勤');</script>");
            }
            else
            {
                string sql = string.Concat(new object[] { "select * from qp_WorkTimeDj where DjUsername='", this.Session["username"], "' and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["DjState_3"].ToString() != "未考勤")
                    {
                        base.Response.Write("<script language=javascript>alert('已经考勤完成，请勿重复操作');window.location.href='WorkTime.aspx'</script>");
                        return;
                    }
                    TimeSpan span2 = new TimeSpan();
                    DateTime time3 = DateTime.Now;
                    DateTime time4 = DateTime.Parse(list["FDjtime"].ToString());
                    span2 = (TimeSpan) (time3 - time4);
                    if (span2.Minutes < int.Parse(this.jxtime.Text))
                    {
                        base.Response.Write("<script language=javascript>alert('当前时间小于登记间歇时间：[" + this.jxtime.Text + "]分');window.location.href='WorkTime.aspx'</script>");
                        return;
                    }
                }
                TimeSpan span3 = new TimeSpan();
                DateTime time5 = DateTime.Now;
                DateTime time6 = DateTime.Parse(this.DjTime_3.Text);
                span3 = (TimeSpan) (time5 - time6);
                if (span3.TotalSeconds > 0.0)
                {
                    if (this.DjType_3.Text == "上班")
                    {
                        this.DjType_3_u.Text = "迟到";
                    }
                    else
                    {
                        this.DjType_3_u.Text = "正常";
                    }
                }
                else if (span3.TotalSeconds == 0.0)
                {
                    if (this.DjType_3.Text == "上班")
                    {
                        this.DjType_3_u.Text = "正常";
                    }
                    else
                    {
                        this.DjType_3_u.Text = "正常";
                    }
                }
                else if (this.DjType_3.Text == "上班")
                {
                    this.DjType_3_u.Text = "正常";
                }
                else
                {
                    this.DjType_3_u.Text = "早退";
                }
                string str2 = string.Concat(new object[] { "Update qp_WorkTimeDj Set DjState_3='", this.DjType_3_u.Text, "',DjTime_3='", DateTime.Now.Hour.ToString(), ":", DateTime.Now.Minute.ToString(), ":", DateTime.Now.Second.ToString(), "',FDjtime='", DateTime.Now.ToString(), "' where DjUsername='", this.Session["username"], "' and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
                this.List.ExeSql(str2);
                base.Response.Write(@"<script language=javascript>alert('登记成功！\n当前登记状态：[" + this.DjType_3_u.Text + "]');window.location.href='WorkTime.aspx'</script>");
                list.Close();
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            TimeSpan span = new TimeSpan();
            DateTime now = DateTime.Now;
            DateTime time2 = DateTime.Parse(this.DjTime_3.Text);
            span = (TimeSpan) (now - time2);
            if (span.TotalSeconds < 0.0)
            {
                base.Response.Write("<script language=javascript>alert('未经过【第三次】考勤的时间，不能进行【第四次】考勤');</script>");
            }
            else
            {
                string sql = string.Concat(new object[] { "select * from qp_WorkTimeDj where DjUsername='", this.Session["username"], "' and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["DjState_4"].ToString() != "未考勤")
                    {
                        base.Response.Write("<script language=javascript>alert('已经考勤完成，请勿重复操作');window.location.href='WorkTime.aspx'</script>");
                        return;
                    }
                    TimeSpan span2 = new TimeSpan();
                    DateTime time3 = DateTime.Now;
                    DateTime time4 = DateTime.Parse(list["FDjtime"].ToString());
                    span2 = (TimeSpan) (time3 - time4);
                    if (span2.Minutes < int.Parse(this.jxtime.Text))
                    {
                        base.Response.Write("<script language=javascript>alert('当前时间小于登记间歇时间：[" + this.jxtime.Text + "]分');window.location.href='WorkTime.aspx'</script>");
                        return;
                    }
                }
                TimeSpan span3 = new TimeSpan();
                DateTime time5 = DateTime.Now;
                DateTime time6 = DateTime.Parse(this.DjTime_4.Text);
                span3 = (TimeSpan) (time5 - time6);
                if (span3.TotalSeconds > 0.0)
                {
                    if (this.DjType_4.Text == "上班")
                    {
                        this.DjType_4_u.Text = "迟到";
                    }
                    else
                    {
                        this.DjType_4_u.Text = "正常";
                    }
                }
                else if (span3.TotalSeconds == 0.0)
                {
                    if (this.DjType_4.Text == "上班")
                    {
                        this.DjType_4_u.Text = "正常";
                    }
                    else
                    {
                        this.DjType_4_u.Text = "正常";
                    }
                }
                else if (this.DjType_4.Text == "上班")
                {
                    this.DjType_4_u.Text = "正常";
                }
                else
                {
                    this.DjType_4_u.Text = "早退";
                }
                string str2 = string.Concat(new object[] { "Update qp_WorkTimeDj Set DjState_4='", this.DjType_4_u.Text, "',DjTime_4='", DateTime.Now.Hour.ToString(), ":", DateTime.Now.Minute.ToString(), ":", DateTime.Now.Second.ToString(), "',FDjtime='", DateTime.Now.ToString(), "' where DjUsername='", this.Session["username"], "' and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
                this.List.ExeSql(str2);
                base.Response.Write(@"<script language=javascript>alert('登记成功！\n当前登记状态：[" + this.DjType_4_u.Text + "]');window.location.href='WorkTime.aspx'</script>");
                list.Close();
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            TimeSpan span = new TimeSpan();
            DateTime now = DateTime.Now;
            DateTime time2 = DateTime.Parse(this.DjTime_4.Text);
            span = (TimeSpan) (now - time2);
            if (span.TotalSeconds < 0.0)
            {
                base.Response.Write("<script language=javascript>alert('未经过【第四次】考勤的时间，不能进行【第五次】考勤');</script>");
            }
            else
            {
                string sql = string.Concat(new object[] { "select * from qp_WorkTimeDj where DjUsername='", this.Session["username"], "' and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["DjState_5"].ToString() != "未考勤")
                    {
                        base.Response.Write("<script language=javascript>alert('已经考勤完成，请勿重复操作');window.location.href='WorkTime.aspx'</script>");
                        return;
                    }
                    TimeSpan span2 = new TimeSpan();
                    DateTime time3 = DateTime.Now;
                    DateTime time4 = DateTime.Parse(list["FDjtime"].ToString());
                    span2 = (TimeSpan) (time3 - time4);
                    if (span2.Minutes < int.Parse(this.jxtime.Text))
                    {
                        base.Response.Write("<script language=javascript>alert('当前时间小于登记间歇时间：[" + this.jxtime.Text + "]分');window.location.href='WorkTime.aspx'</script>");
                        return;
                    }
                }
                TimeSpan span3 = new TimeSpan();
                DateTime time5 = DateTime.Now;
                DateTime time6 = DateTime.Parse(this.DjTime_5.Text);
                span3 = (TimeSpan) (time5 - time6);
                if (span3.TotalSeconds > 0.0)
                {
                    if (this.DjType_5.Text == "上班")
                    {
                        this.DjType_5_u.Text = "迟到";
                    }
                    else
                    {
                        this.DjType_5_u.Text = "正常";
                    }
                }
                else if (span3.TotalSeconds == 0.0)
                {
                    if (this.DjType_5.Text == "上班")
                    {
                        this.DjType_5_u.Text = "正常";
                    }
                    else
                    {
                        this.DjType_5_u.Text = "正常";
                    }
                }
                else if (this.DjType_5.Text == "上班")
                {
                    this.DjType_5_u.Text = "正常";
                }
                else
                {
                    this.DjType_5_u.Text = "早退";
                }
                string str2 = string.Concat(new object[] { "Update qp_WorkTimeDj Set DjState_5='", this.DjType_5_u.Text, "',DjTime_5='", DateTime.Now.Hour.ToString(), ":", DateTime.Now.Minute.ToString(), ":", DateTime.Now.Second.ToString(), "',FDjtime='", DateTime.Now.ToString(), "' where DjUsername='", this.Session["username"], "' and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
                this.List.ExeSql(str2);
                base.Response.Write(@"<script language=javascript>alert('登记成功！\n当前登记状态：[" + this.DjType_5_u.Text + "]');window.location.href='WorkTime.aspx'</script>");
                list.Close();
            }
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            TimeSpan span = new TimeSpan();
            DateTime now = DateTime.Now;
            DateTime time2 = DateTime.Parse(this.DjTime_5.Text);
            span = (TimeSpan) (now - time2);
            if (span.TotalSeconds < 0.0)
            {
                base.Response.Write("<script language=javascript>alert('未经过【第五次】考勤的时间，不能进行【第六次】考勤');</script>");
            }
            else
            {
                string sql = string.Concat(new object[] { "select * from qp_WorkTimeDj where DjUsername='", this.Session["username"], "' and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["DjState_6"].ToString() != "未考勤")
                    {
                        base.Response.Write("<script language=javascript>alert('已经考勤完成，请勿重复操作');window.location.href='WorkTime.aspx'</script>");
                        return;
                    }
                    TimeSpan span2 = new TimeSpan();
                    DateTime time3 = DateTime.Now;
                    DateTime time4 = DateTime.Parse(list["FDjtime"].ToString());
                    span2 = (TimeSpan) (time3 - time4);
                    if (span2.Minutes < int.Parse(this.jxtime.Text))
                    {
                        base.Response.Write("<script language=javascript>alert('当前时间小于登记间歇时间：[" + this.jxtime.Text + "]分');window.location.href='WorkTime.aspx'</script>");
                        return;
                    }
                }
                TimeSpan span3 = new TimeSpan();
                DateTime time5 = DateTime.Now;
                DateTime time6 = DateTime.Parse(this.DjTime_6.Text);
                span3 = (TimeSpan) (time5 - time6);
                if (span3.TotalSeconds > 0.0)
                {
                    if (this.DjType_6.Text == "上班")
                    {
                        this.DjType_6_u.Text = "迟到";
                    }
                    else
                    {
                        this.DjType_6_u.Text = "正常";
                    }
                }
                else if (span3.TotalSeconds == 0.0)
                {
                    if (this.DjType_6.Text == "上班")
                    {
                        this.DjType_6_u.Text = "正常";
                    }
                    else
                    {
                        this.DjType_6_u.Text = "正常";
                    }
                }
                else if (this.DjType_6.Text == "上班")
                {
                    this.DjType_6_u.Text = "正常";
                }
                else
                {
                    this.DjType_6_u.Text = "早退";
                }
                string str2 = string.Concat(new object[] { "Update qp_WorkTimeDj Set DjState_6='", this.DjType_6_u.Text, "',DjTime_6='", DateTime.Now.Hour.ToString(), ":", DateTime.Now.Minute.ToString(), ":", DateTime.Now.Second.ToString(), "',FDjtime='", DateTime.Now.ToString(), "' where DjUsername='", this.Session["username"], "' and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
                this.List.ExeSql(str2);
                base.Response.Write(@"<script language=javascript>alert('登记成功！\n当前登记状态：[" + this.DjType_6_u.Text + "]');window.location.href='WorkTime.aspx'</script>");
                list.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_WorkTime  where QyType='启用'   and  (CHARINDEX('," + this.Session["username"] + ",',','+SyUsername+',')   >   0 )";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.DjType_1.Text = list["DjType_1"].ToString();
                    this.DjType_2.Text = list["DjType_2"].ToString();
                    this.DjType_3.Text = list["DjType_3"].ToString();
                    this.DjType_4.Text = list["DjType_4"].ToString();
                    this.DjType_5.Text = list["DjType_5"].ToString();
                    this.DjType_6.Text = list["DjType_6"].ToString();
                    this.DjTime_1.Text = list["DjTime_1"].ToString();
                    this.DjTime_2.Text = list["DjTime_2"].ToString();
                    this.DjTime_3.Text = list["DjTime_3"].ToString();
                    this.DjTime_4.Text = list["DjTime_4"].ToString();
                    this.DjTime_5.Text = list["DjTime_5"].ToString();
                    this.DjTime_6.Text = list["DjTime_6"].ToString();
                    list.Close();
                    if (this.DjType_1.Text == "未启用")
                    {
                        this.Button2.Text = "未启用";
                        this.Button2.Enabled = false;
                        this.ViewState["css1"] = "display: none";
                    }
                    if (this.DjType_2.Text == "未启用")
                    {
                        this.Button3.Text = "未启用";
                        this.Button3.Enabled = false;
                        this.ViewState["css2"] = "display: none";
                    }
                    if (this.DjType_3.Text == "未启用")
                    {
                        this.Button4.Text = "未启用";
                        this.Button4.Enabled = false;
                        this.ViewState["css3"] = "display: none";
                    }
                    if (this.DjType_4.Text == "未启用")
                    {
                        this.Button5.Text = "未启用";
                        this.Button5.Enabled = false;
                        this.ViewState["css4"] = "display: none";
                    }
                    if (this.DjType_5.Text == "未启用")
                    {
                        this.Button6.Text = "未启用";
                        this.Button6.Enabled = false;
                        this.ViewState["css5"] = "display: none";
                    }
                    if (this.DjType_6.Text == "未启用")
                    {
                        this.Button7.Text = "未启用";
                        this.Button7.Enabled = false;
                        this.ViewState["css6"] = "display: none";
                    }
                    string str2 = "select * from qp_WorkTimeJx";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.jxtime.Text = reader2["jxtime"].ToString();
                    }
                    reader2.Close();
                    string str3 = string.Concat(new object[] { "select * from qp_WorkTimeDj where DjUsername='", this.Session["username"], "' and convert(varchar(10),Djtime,121)=convert(char(10),'", DateTime.Now.ToShortDateString(), "',120)" });
                    SqlDataReader reader3 = this.List.GetList(str3);
                    if (reader3.Read())
                    {
                        if ((reader3["DjState_1"].ToString() != "未考勤") && (reader3["DjState_1"].ToString() != "未启用"))
                        {
                            this.Button2.Text = "已登记(" + reader3["DjState_1"].ToString() + ")";
                            this.Button2.Enabled = false;
                        }
                        if ((reader3["DjState_2"].ToString() != "未考勤") && (reader3["DjState_2"].ToString() != "未启用"))
                        {
                            this.Button3.Text = "已登记(" + reader3["DjState_2"].ToString() + ")";
                            this.Button3.Enabled = false;
                        }
                        if ((reader3["DjState_3"].ToString() != "未考勤") && (reader3["DjState_3"].ToString() != "未启用"))
                        {
                            this.Button4.Text = "已登记(" + reader3["DjState_3"].ToString() + ")";
                            this.Button4.Enabled = false;
                        }
                        if ((reader3["DjState_4"].ToString() != "未考勤") && (reader3["DjState_4"].ToString() != "未启用"))
                        {
                            this.Button5.Text = "已登记(" + reader3["DjState_4"].ToString() + ")";
                            this.Button5.Enabled = false;
                        }
                        if ((reader3["DjState_5"].ToString() != "未考勤") && (reader3["DjState_5"].ToString() != ""))
                        {
                            this.Button6.Text = "已登记(" + reader3["DjState_5"].ToString() + ")";
                            this.Button6.Enabled = false;
                        }
                        if ((reader3["DjState_6"].ToString() != "未考勤") && (reader3["DjState_6"].ToString() != ""))
                        {
                            this.Button7.Text = "已登记(" + reader3["DjState_6"].ToString() + ")";
                            this.Button7.Enabled = false;
                        }
                    }
                    reader3.Close();
                    this.BindAttribute();
                }
                else
                {
                    this.Button2.Text = "未启用";
                    this.Button2.Enabled = false;
                    this.Button3.Text = "未启用";
                    this.Button3.Enabled = false;
                    this.Button4.Text = "未启用";
                    this.Button4.Enabled = false;
                    this.Button5.Text = "未启用";
                    this.Button5.Enabled = false;
                    this.Button6.Text = "未启用";
                    this.Button6.Enabled = false;
                    this.Button7.Text = "未启用";
                    this.Button7.Enabled = false;
                    base.Response.Write(@"<script language=javascript>alert('未找到已启用上下班时间，操作失败\n请在[人力资源--上下班时间]中设置');window.top.winClose('7');</script>");
                }
            }
        }
    }
}

