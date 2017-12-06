namespace xyoa.MyWork.Richeng
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class RichengjkZhou : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected DropDownList years;
        protected DropDownList zhou;

        public void BindList()
        {
            object obj2;
            DateTime time = DateTime.Parse(this.years.SelectedValue + "-01-01");
            int num = Convert.ToInt32(time.DayOfWeek);
            int num2 = (-1 * num) + 1;
            string s = time.AddDays((double) num2).ToString("yyyy-MM-dd");
            int num3 = 7 * (int.Parse(this.zhou.SelectedValue) - 1);
            string days = DateTime.Parse(s).AddDays((double) num3).ToShortDateString();
            this.Label1.Text = null;
            this.Label1.Text = this.Label1.Text + "<table class=\"TableList\" width=\"100%\" align=\"center\" cellspacing=\"0\" cellpadding=\"0\">";
            this.Label1.Text = this.Label1.Text + "<tr align=\"center\" class=\"TableHeader\">";
            this.Label1.Text = this.Label1.Text + "<td width=\"5%\" class=\"TableCorner\"><a href=\"javascript:display_front();\"><font color=white>0-6点</font></a></td>";
            string text = this.Label1.Text;
            this.Label1.Text = text + "<td width=\"15%\">" + days + "<br>(" + this.GetWeekDay(days) + ")</td>";
            text = this.Label1.Text;
            this.Label1.Text = text + "<td width=\"15%\">" + DateTime.Parse(days).AddDays(1.0).ToShortDateString() + "<br>(" + this.GetWeekDay(DateTime.Parse(days).AddDays(1.0).ToShortDateString()) + ")</td>";
            text = this.Label1.Text;
            this.Label1.Text = text + "<td width=\"15%\">" + DateTime.Parse(days).AddDays(2.0).ToShortDateString() + "<br>(" + this.GetWeekDay(DateTime.Parse(days).AddDays(2.0).ToShortDateString()) + ")</td>";
            text = this.Label1.Text;
            this.Label1.Text = text + "<td width=\"15%\">" + DateTime.Parse(days).AddDays(3.0).ToShortDateString() + "<br>(" + this.GetWeekDay(DateTime.Parse(days).AddDays(3.0).ToShortDateString()) + ")</td>";
            text = this.Label1.Text;
            this.Label1.Text = text + "<td width=\"15%\">" + DateTime.Parse(days).AddDays(4.0).ToShortDateString() + "<br>(" + this.GetWeekDay(DateTime.Parse(days).AddDays(4.0).ToShortDateString()) + ")</td>";
            text = this.Label1.Text;
            this.Label1.Text = text + "<td width=\"10%\">" + DateTime.Parse(days).AddDays(5.0).ToShortDateString() + "<br>(" + this.GetWeekDay(DateTime.Parse(days).AddDays(5.0).ToShortDateString()) + ")</td>";
            text = this.Label1.Text;
            this.Label1.Text = text + "<td width=\"10%\">" + DateTime.Parse(days).AddDays(6.0).ToShortDateString() + "<br>(" + this.GetWeekDay(DateTime.Parse(days).AddDays(6.0).ToShortDateString()) + ")</td>";
            this.Label1.Text = this.Label1.Text + "</tr>";
            string str3 = null;
            string str4 = "select id,titles,StartTime,Realname,username,EndTime from qp_oa_MyRicheng where  CHARINDEX(','+Username+',',','+(select Glusername from qp_oa_Richengsz where Username='" + this.Session["username"] + "')+',') > 0 and ";
            string str5 = "((('" + days + "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + days + "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('" + days + "' as datetime),120)) ) and (datediff(dd,StartTime,'" + days + "')!=0 or datediff(dd,EndTime,'" + days + "')!=0)";
            string str6 = " or (('" + DateTime.Parse(days).AddDays(1.0).ToShortDateString() + "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + DateTime.Parse(days).AddDays(1.0).ToShortDateString() + "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('" + DateTime.Parse(days).AddDays(1.0).ToShortDateString() + "' as datetime),120)) ) and (datediff(dd,StartTime,'" + DateTime.Parse(days).AddDays(1.0).ToShortDateString() + "')!=0 or datediff(dd,EndTime,'" + DateTime.Parse(days).AddDays(1.0).ToShortDateString() + "')!=0)";
            string str7 = " or (('" + DateTime.Parse(days).AddDays(2.0).ToShortDateString() + "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + DateTime.Parse(days).AddDays(2.0).ToShortDateString() + "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('" + DateTime.Parse(days).AddDays(2.0).ToShortDateString() + "' as datetime),120)) ) and (datediff(dd,StartTime,'" + DateTime.Parse(days).AddDays(2.0).ToShortDateString() + "')!=0 or datediff(dd,EndTime,'" + DateTime.Parse(days).AddDays(2.0).ToShortDateString() + "')!=0)";
            string str8 = " or (('" + DateTime.Parse(days).AddDays(3.0).ToShortDateString() + "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + DateTime.Parse(days).AddDays(3.0).ToShortDateString() + "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('" + DateTime.Parse(days).AddDays(3.0).ToShortDateString() + "' as datetime),120)) ) and (datediff(dd,StartTime,'" + DateTime.Parse(days).AddDays(3.0).ToShortDateString() + "')!=0 or datediff(dd,EndTime,'" + DateTime.Parse(days).AddDays(3.0).ToShortDateString() + "')!=0)";
            string str9 = " or (('" + DateTime.Parse(days).AddDays(4.0).ToShortDateString() + "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + DateTime.Parse(days).AddDays(4.0).ToShortDateString() + "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('" + DateTime.Parse(days).AddDays(4.0).ToShortDateString() + "' as datetime),120)) ) and (datediff(dd,StartTime,'" + DateTime.Parse(days).AddDays(4.0).ToShortDateString() + "')!=0 or datediff(dd,EndTime,'" + DateTime.Parse(days).AddDays(4.0).ToShortDateString() + "')!=0)";
            string str10 = " or (('" + DateTime.Parse(days).AddDays(5.0).ToShortDateString() + "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + DateTime.Parse(days).AddDays(5.0).ToShortDateString() + "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('" + DateTime.Parse(days).AddDays(5.0).ToShortDateString() + "' as datetime),120)) ) and (datediff(dd,StartTime,'" + DateTime.Parse(days).AddDays(5.0).ToShortDateString() + "')!=0 or datediff(dd,EndTime,'" + DateTime.Parse(days).AddDays(5.0).ToShortDateString() + "')!=0)";
            string str11 = " or (('" + DateTime.Parse(days).AddDays(6.0).ToShortDateString() + "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + DateTime.Parse(days).AddDays(6.0).ToShortDateString() + "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('" + DateTime.Parse(days).AddDays(6.0).ToShortDateString() + "' as datetime),120)) ) and (datediff(dd,StartTime,'" + DateTime.Parse(days).AddDays(6.0).ToShortDateString() + "')!=0 or datediff(dd,EndTime,'" + DateTime.Parse(days).AddDays(6.0).ToShortDateString() + "')!=0))";
            string sql = str4 + str5 + str6 + str7 + str8 + str9 + str10 + str11;
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                obj2 = str3;
                str3 = string.Concat(new object[] { obj2, "<div class=Celldiv>", list["StartTime"].ToString(), "&nbsp;&nbsp;-&nbsp;&nbsp;", list["EndTime"].ToString(), "<img src=\"/oaimg/r/1.gif\" border=0 hspace=2><a href='javascript:void(0)' onclick='senduser(\"", list["username"], "\")'><font color=#000000>", list["realname"], "：</font></a><a href=Richengjk_show.aspx?id=", list["id"].ToString(), "> <font color=blue>", list["titles"].ToString(), "</font></a><br></div>" });
            }
            list.Close();
            this.Label1.Text = this.Label1.Text + "<tr  height=\"30\"><td class=\"TableLeft\" align=\"center\" width=\"5%\">跨周</td><td class=\"TableRight\"  colspan=\"7\">" + str3 + "</td></tr>";
            this.Label1.Text = this.Label1.Text + " <tbody id=\"front\" style=\"display:none;\">";
            for (int i = 0; i < 0x18; i++)
            {
                obj2 = this.Label1.Text;
                this.Label1.Text = string.Concat(new object[] { obj2, "<tr  height=\"30\"  class=\"TableBody\"><td class=\"TableLeft\" align=\"center\" width=\"5%\">", i, ":00</td>" });
                for (int j = 0; j < 7; j++)
                {
                    string str13 = null;
                    str13 = string.Concat(new object[] { "", DateTime.Parse(days).AddDays((double) j).ToShortDateString(), " ", i, ":00" });
                    string str14 = null;
                    string str15 = string.Concat(new object[] { "select id,titles,StartTime,Realname,username,EndTime from qp_oa_MyRicheng  where CHARINDEX(','+Username+',',','+(select Glusername from qp_oa_Richengsz where Username='", this.Session["username"], "')+',') > 0 and datediff(hh,StartTime,'", str13, "')=0 and datediff(hh,EndTime,'", str13, "')=0" });
                    SqlDataReader reader2 = this.List.GetList(str15);
                    while (reader2.Read())
                    {
                        obj2 = str14;
                        str14 = string.Concat(new object[] { 
                            obj2, "<div class=Celldiv><img src=\"/oaimg/r/1.gif\" border=0 hspace=2><a href='javascript:void(0)' onclick='senduser(\"", reader2["username"], "\")'><font color=#000000>", reader2["realname"], "：</font></a>", DateTime.Parse(reader2["StartTime"].ToString()).Hour.ToString(), ":", DateTime.Parse(reader2["StartTime"].ToString()).Minute.ToString(), "&nbsp;&nbsp;-&nbsp;&nbsp;", DateTime.Parse(reader2["EndTime"].ToString()).Hour.ToString(), ":", DateTime.Parse(reader2["EndTime"].ToString()).Minute.ToString(), "<a href=Richengjk_show.aspx?id=", reader2["id"].ToString(), "> <font color=blue>", 
                            reader2["titles"].ToString(), "</font></a><br></div>"
                         });
                    }
                    reader2.Close();
                    this.Label1.Text = this.Label1.Text + "<td class=\"TableRight\">" + str14 + "</td>";
                }
                this.Label1.Text = this.Label1.Text + "</tr>";
                if (i == 6)
                {
                    this.Label1.Text = this.Label1.Text + "</tbody>";
                }
            }
            this.Label1.Text = this.Label1.Text + "</table>";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (this.zhou.SelectedValue == "1")
            {
                int num = int.Parse(this.years.SelectedValue) - 1;
                this.years.SelectedValue = "" + num + "";
                this.zhou.SelectedValue = "53";
            }
            else
            {
                int num2 = int.Parse(this.zhou.SelectedValue) - 1;
                this.zhou.SelectedValue = "" + num2 + "";
            }
            this.BindList();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.years.SelectedValue = DateTime.Now.Year.ToString();
            this.list.Bind_DropDownList_YearForSa(this.zhou, 1, 0x35);
            DateTime time = DateTime.Parse(this.years.SelectedValue + "-01-01");
            int num = Convert.ToInt32(time.DayOfWeek);
            int num2 = (-1 * num) + 1;
            string s = time.AddDays((double) num2).ToString("yyyy-MM-dd");
            TimeSpan span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(s));
            int num3 = (span.Days / 7) + 1;
            this.zhou.SelectedValue = "" + num3 + "";
            this.BindList();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (this.zhou.SelectedValue == "53")
            {
                int num = int.Parse(this.years.SelectedValue) + 1;
                this.years.SelectedValue = "" + num + "";
                this.zhou.SelectedValue = "1";
            }
            else
            {
                int num2 = int.Parse(this.zhou.SelectedValue) + 1;
                this.zhou.SelectedValue = "" + num2 + "";
            }
            this.BindList();
        }

        private string GetWeekDay(string days)
        {
            string s = days;
            switch (DateTime.Parse(s).DayOfWeek)
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.years.SelectedValue = DateTime.Now.Year.ToString();
                this.list.Bind_DropDownList_YearForSa(this.zhou, 1, 0x35);
                DateTime time = DateTime.Parse(this.years.SelectedValue + "-01-01");
                int num = Convert.ToInt32(time.DayOfWeek);
                int num2 = (-1 * num) + 1;
                string s = time.AddDays((double) num2).ToString("yyyy-MM-dd");
                TimeSpan span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(s));
                int num3 = (span.Days / 7) + 1;
                this.zhou.SelectedValue = "" + num3 + "";
                this.BindList();
            }
        }

        protected void years_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.list.Bind_DropDownList_YearForSa(this.zhou, 1, 0x35);
            this.BindList();
        }

        protected void zhou_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindList();
        }
    }
}

