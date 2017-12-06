namespace xyoa.OfficeMenu.Rizhi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyRizhi : Page
    {
        public int a;
        protected Button AddData;
        public int b;
        protected Button Button1;
        public int c;
        protected Calendar Calendar1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected DropDownList months;
        private publics pulicss = new publics();
        private string[,,] SpecialDays = new string[0xbb8, 13, 0x20];
        protected DropDownList years;

        protected void AddData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyRizhi_add.aspx");
        }

        public void BindAttribute()
        {
            this.AddData.Attributes["onclick"] = "javascript:return showwait();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.AddData, "kkkk6aa", this.Session["perstr"].ToString());
        }

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
                        e.Cell.Text = "<table width=100% height=100 border=0 cellpadding=0 cellspacing=0><tr><td height=20 align=right bgcolor=#DEE7F3>" + e.Day.Date.Day.ToString() + "<a href=MyRizhi_add.aspx?day=" + e.Day.Date.ToShortDateString() + " class=LinkLine><img src=\"/oaimg/12task.png\" border=0  hspace=2></a></td></tr><tr><td height=80 valign=top>";
                        string sql = string.Concat(new object[] { "select id,titles from qp_oa_MyRizhi where username='", this.Session["username"], "' and datediff(dd,NowTimes,'", e.Day.Date.ToShortDateString(), "')=0" });
                        SqlDataReader list = this.List.GetList(sql);
                        while (list.Read())
                        {
                            TableCell cell1 = e.Cell;
                            string text = cell1.Text;
                            cell1.Text = text + "<a href=MyRizhi_show.aspx?id=" + list["id"].ToString() + "&key=1><img src=\"/oaimg/r/1.gif\" border=0 hspace=2>" + list["titles"].ToString() + "</a><br>";
                        }
                        list.Close();
                        TableCell cell = e.Cell;
                        cell.Text = cell.Text + "&nbsp;</td></tr></table>";
                        e.Cell.ApplyStyle(s);
                    }
                    else
                    {
                        e.Cell.Text = "<table width=100% height=100 border=0 cellpadding=0 cellspacing=0><tr><td height=20 align=right bgcolor=#DEE7F3>" + e.Day.Date.Day.ToString() + "<a href=MyRizhi_add.aspx?day=" + e.Day.Date.ToShortDateString() + " class=LinkLine  title='点击新增日志'><img src=\"/oaimg/12task.png\" border=0 hspace=2></a></td></tr><tr><td height=80 valign=top>&nbsp;</td></tr></table>";
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
                    this.BindAttribute();
                    this.Bindquanxian();
                    this.years.SelectedValue = DateTime.Now.Year.ToString();
                    this.months.SelectedValue = DateTime.Now.Month.ToString();
                    this.Calendar1.VisibleDate = this.Calendar1.TodaysDate;
                }
                string sql = "select NowTimes from qp_oa_MyRizhi where username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    this.a = int.Parse(DateTime.Parse(list["NowTimes"].ToString()).Year.ToString());
                    this.b = int.Parse(DateTime.Parse(list["NowTimes"].ToString()).Month.ToString());
                    this.c = int.Parse(DateTime.Parse(list["NowTimes"].ToString()).Day.ToString());
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

