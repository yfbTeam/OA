namespace xyoa.MyWork.Richeng
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Richengjk : Page
    {
        public int a;
        public int b;
        public int c;
        protected Calendar Calendar1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected DropDownList months;
        private publics pulicss = new publics();
        private string[,,] SpecialDays = new string[0xbb8, 13, 0x20];
        protected DropDownList years;

        protected void Button1_Click(object sender, EventArgs e)
        {
            DateTime time;
            int year = Convert.ToInt32(this.years.SelectedValue);
            int month = Convert.ToInt32(this.months.SelectedValue);
            try
            {
                time = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            }
            catch
            {
                time = new DateTime(year, month, DateTime.DaysInMonth(year, month));
            }
            this.Calendar1.VisibleDate = time;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsOtherMonth)
            {
                e.Cell.Controls.Clear();
            }
            else
            {
                Style s = new Style();
                s.BackColor = Color.OldLace;
                s.Font.Size = FontUnit.Parse("11pt");
                try
                {
                    string str = this.SpecialDays[e.Day.Date.Year, e.Day.Date.Month, e.Day.Date.Day];
                    if (str != null)
                    {
                        e.Cell.Text = "<table width=100% height=100 border=0 cellpadding=0 cellspacing=0><tr><td height=20 align=right bgcolor=#DEE7F3>" + e.Day.Date.Day.ToString() + "</td></tr><tr><td height=80 valign=top>";
                        string sql = string.Concat(new object[] { "select id,titles,StartTime,EndTime,Username,Realname from qp_oa_MyRicheng  where CHARINDEX(','+Username+',',','+(select Glusername from qp_oa_Richengsz where Username='", this.Session["username"], "')+',') > 0 and datediff(dd,StartTime,'", e.Day.Date.ToShortDateString(), "')=0" });
                        SqlDataReader list = this.List.GetList(sql);
                        while (list.Read())
                        {
                            TableCell cell1 = e.Cell;
                            object text = cell1.Text;
                            cell1.Text = string.Concat(new object[] { text, "<img src=\"/oaimg/r/1.gif\" border=0 hspace=2><font color=#666666>", list["StartTime"].ToString(), "&nbsp;&nbsp;-&nbsp;&nbsp;", list["EndTime"].ToString(), "</font><a href=Richengjk_show.aspx?id=", list["id"].ToString(), "><font color=#000000>", list["realname"], "：</font><font color=blue>", list["titles"].ToString(), "</font></a><br><br>" });
                        }
                        list.Close();
                        TableCell cell = e.Cell;
                        cell.Text = cell.Text + "&nbsp;</td></tr></table>";
                        e.Cell.ApplyStyle(s);
                    }
                    else
                    {
                        e.Cell.Text = "<table width=100% height=100 border=0 cellpadding=0 cellspacing=0><tr><td height=20 align=right bgcolor=#DEE7F3>" + e.Day.Date.Day.ToString() + "</td></tr><tr><td height=80 valign=top>&nbsp;</td></tr></table>";
                    }
                }
                catch (Exception exception)
                {
                    base.Response.Write(exception.ToString());
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    this.years.SelectedValue = DateTime.Now.Year.ToString();
                    this.months.SelectedValue = DateTime.Now.Month.ToString();
                    this.Calendar1.VisibleDate = this.Calendar1.TodaysDate;
                }
                string sql = "select id,titles,StartTime,EndTime,Username,Realname from qp_oa_MyRicheng  where CHARINDEX(','+Username+',',','+(select Glusername from qp_oa_Richengsz where Username='" + this.Session["username"] + "')+',') > 0";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    this.a = int.Parse(DateTime.Parse(list["StartTime"].ToString()).Year.ToString());
                    this.b = int.Parse(DateTime.Parse(list["StartTime"].ToString()).Month.ToString());
                    this.c = int.Parse(DateTime.Parse(list["StartTime"].ToString()).Day.ToString());
                    this.SpecialDays[this.a, this.b, this.c] = "";
                }
                list.Close();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}

