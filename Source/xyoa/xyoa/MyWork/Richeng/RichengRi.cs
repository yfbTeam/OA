namespace xyoa.MyWork.Richeng
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class RichengRi : Page
    {
        protected Button AddData;
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected Label Day;
        protected DropDownList days;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList months;
        private publics pulicss = new publics();
        protected DropDownList years;

        protected void AddData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("RichengmyList_add.aspx");
        }

        public void BindAttribute()
        {
            this.AddData.Attributes["onclick"] = "javascript:return showwait();";
        }

        public void BindList()
        {
            object text;
            string str = "" + this.years.SelectedValue + "-" + this.months.SelectedValue + "-" + this.days.SelectedValue + "";
            string str2 = null;
            string sql = string.Concat(new object[] { "select id,titles,StartTime,Realname,username,EndTime from qp_oa_MyRicheng where  username='", this.Session["username"], "' and (('", str, "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('", str, "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('", str, "' as datetime),120)) ) and (datediff(dd,StartTime,'", str, "')!=0 or datediff(dd,EndTime,'", str, "')!=0)" });
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                text = str2;
                str2 = string.Concat(new object[] { text, "<div class=Celldiv>", list["StartTime"].ToString(), "&nbsp;&nbsp;-&nbsp;&nbsp;", list["EndTime"].ToString(), "<img src=\"/oaimg/r/1.gif\" border=0 hspace=2><a href='javascript:void(0)' onclick='senduser(\"", list["username"], "\")'><font color=#000000>", list["realname"], "：</font></a><a href=RichengmyList_show.aspx?id=", list["id"].ToString(), "> <font color=blue>", list["titles"].ToString(), "</font></a><br></div>" });
            }
            list.Close();
            this.Day.Text = "" + this.years.SelectedValue + "年" + this.months.SelectedValue + "月" + this.days.SelectedValue + "日(" + this.GetWeekDay() + ")";
            this.Label1.Text = null;
            this.Label1.Text = this.Label1.Text + "<tr  height=\"30\"><td class=\"TableLeft\" align=\"center\" width=\"9%\">跨天</td><td class=\"TableRight\">" + str2 + "</td></tr>";
            this.Label1.Text = this.Label1.Text + " <tbody id=\"front\" style=\"display:none;\">";
            for (int i = 0; i < 0x18; i++)
            {
                string str4 = null;
                str4 = string.Concat(new object[] { "", this.years.SelectedValue, "-", this.months.SelectedValue, "-", this.days.SelectedValue, " ", i, ":00" });
                string str5 = null;
                string str6 = string.Concat(new object[] { "select id,titles,StartTime,Realname,username,EndTime from qp_oa_MyRicheng  where username='", this.Session["username"], "' and datediff(hh,StartTime,'", str4, "')=0 and datediff(hh,EndTime,'", str4, "')=0" });
                SqlDataReader reader2 = this.List.GetList(str6);
                while (reader2.Read())
                {
                    text = str5;
                    str5 = string.Concat(new object[] { 
                        text, "<div class=Celldiv><img src=\"/oaimg/r/1.gif\" border=0 hspace=2><a href='javascript:void(0)' onclick='senduser(\"", reader2["username"], "\")'><font color=#000000>", reader2["realname"], "：</font></a>", DateTime.Parse(reader2["StartTime"].ToString()).Hour.ToString(), ":", DateTime.Parse(reader2["StartTime"].ToString()).Minute.ToString(), "&nbsp;&nbsp;-&nbsp;&nbsp;", DateTime.Parse(reader2["EndTime"].ToString()).Hour.ToString(), ":", DateTime.Parse(reader2["EndTime"].ToString()).Minute.ToString(), "<a href=RichengmyList_show.aspx?id=", reader2["id"].ToString(), "> <font color=blue>", 
                        reader2["titles"].ToString(), "</font></a><br></div>"
                     });
                }
                reader2.Close();
                text = this.Label1.Text;
                this.Label1.Text = string.Concat(new object[] { text, "<tr  height=\"30\"><td class=\"TableLeft\" align=\"center\" width=\"9%\">", i, ":00</td><td class=\"TableRight\">", str5, "</td></tr>" });
                if (i == 6)
                {
                    this.Label1.Text = this.Label1.Text + "</tbody>";
                }
            }
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.Label1, "hhhh8aa", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.AddData, "hhhh8aa", this.Session["perstr"].ToString());
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = DateTime.Parse("" + this.years.SelectedValue + "-" + this.months.SelectedValue + "-" + this.days.SelectedValue + "").AddDays(-1.0).ToShortDateString();
            this.years.SelectedValue = DateTime.Parse(s).Year.ToString();
            this.months.SelectedValue = DateTime.Parse(s).Month.ToString();
            this.days.SelectedValue = DateTime.Parse(s).Day.ToString();
            this.BindList();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.years.SelectedValue = DateTime.Now.Year.ToString();
            this.months.SelectedValue = DateTime.Now.Month.ToString();
            this.list.Bind_DropDownList_YearForSa(this.days, 1, DateTime.DaysInMonth(int.Parse(this.years.SelectedValue), int.Parse(this.months.SelectedValue)));
            this.days.SelectedValue = DateTime.Now.Day.ToString();
            this.BindList();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string s = DateTime.Parse("" + this.years.SelectedValue + "-" + this.months.SelectedValue + "-" + this.days.SelectedValue + "").AddDays(1.0).ToShortDateString();
            this.years.SelectedValue = DateTime.Parse(s).Year.ToString();
            this.months.SelectedValue = DateTime.Parse(s).Month.ToString();
            this.days.SelectedValue = DateTime.Parse(s).Day.ToString();
            this.BindList();
        }

        protected void days_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindList();
        }

        private string GetWeekDay()
        {
            switch (DateTime.Parse("" + this.years.SelectedValue + "-" + this.months.SelectedValue + "-" + this.days.SelectedValue + "").DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "星期日";

                case DayOfWeek.Monday:
                    return "星期一";

                case DayOfWeek.Tuesday:
                    return "星期二";

                case DayOfWeek.Wednesday:
                    return "星期三";

                case DayOfWeek.Thursday:
                    return "星期四";

                case DayOfWeek.Friday:
                    return "星期五";

                case DayOfWeek.Saturday:
                    return "星期六";
            }
            return "";
        }

        protected void months_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.list.Bind_DropDownList_YearForSa(this.days, 1, DateTime.DaysInMonth(int.Parse(this.years.SelectedValue), int.Parse(this.months.SelectedValue)));
            this.BindList();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
                this.Bindquanxian();
                this.years.SelectedValue = DateTime.Now.Year.ToString();
                this.months.SelectedValue = DateTime.Now.Month.ToString();
                this.list.Bind_DropDownList_YearForSa(this.days, 1, DateTime.DaysInMonth(int.Parse(this.years.SelectedValue), int.Parse(this.months.SelectedValue)));
                this.days.SelectedValue = DateTime.Now.Day.ToString();
                this.BindList();
            }
        }

        protected void years_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.list.Bind_DropDownList_YearForSa(this.days, 1, DateTime.DaysInMonth(int.Parse(this.years.SelectedValue), int.Parse(this.months.SelectedValue)));
            this.BindList();
        }
    }
}

