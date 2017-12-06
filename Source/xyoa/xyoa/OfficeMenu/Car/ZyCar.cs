namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ZyCar : Page
    {
        public int a;
        public int b;
        protected Button Button1;
        public int c;
        protected Calendar Calendar1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList months;
        private publics pulicss = new publics();
        private string[,,] SpecialDays = new string[0xbb8, 13, 0x20];
        protected DropDownList typename;
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
                        string sql = "";
                        if (this.typename.SelectedValue == "0")
                        {
                            sql = "select id,LcZhuangtai,Starttime,Endtime,CarId,Realname from qp_oa_CarApply  where datediff(dd,Starttime,'" + e.Day.Date.ToShortDateString() + "')=0";
                        }
                        else
                        {
                            sql = "select id,LcZhuangtai,Starttime,Endtime,CarId,Realname from qp_oa_CarApply  where datediff(dd,Starttime,'" + e.Day.Date.ToShortDateString() + "')=0 and (CarId='" + this.typename.SelectedValue + "')";
                        }
                        SqlDataReader list = this.List.GetList(sql);
                        while (list.Read())
                        {
                            TableCell cell1 = e.Cell;
                            string text = cell1.Text;
                            cell1.Text = text + "<img src=\"/oaimg/zy/" + list["LcZhuangtai"].ToString() + ".gif\" border=0 hspace=2 alt=" + list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批") + ">" + list["Starttime"].ToString() + "至" + list["Endtime"].ToString() + "<font color=#666666>(" + list["Realname"].ToString() + "→" + this.pulicss.TypeCodeAll("CarName", "qp_oa_CarInfo", list["CarId"].ToString()) + ")</font><br>";
                        }
                        list.Close();
                        TableCell cell = e.Cell;
                        cell.Text = cell.Text + "&nbsp;</td></tr></table>";
                        e.Cell.ApplyStyle(s);
                    }
                    else
                    {
                        e.Cell.Text = "<table width=100% height=100 border=0 cellpadding=0 cellspacing=0><tr><td height=20 align=right bgcolor=#DEE7F3>" + e.Day.Date.Day.ToString() + "<img src=\"/oaimg/r/1.gif\" border=0 hspace=2></a></td></tr><tr><td height=80 valign=top>&nbsp;</td></tr></table>";
                    }
                }
                catch (Exception exception)
                {
                    base.Response.Write(exception.ToString());
                }
            }
        }

        public void DataBindToGridview(string StrCheck)
        {
            string str;
            SqlDataReader list;
            if (StrCheck == "0")
            {
                str = "select Starttime from qp_oa_CarApply";
                list = this.List.GetList(str);
                while (list.Read())
                {
                    this.a = int.Parse(DateTime.Parse(list["StartTime"].ToString()).Year.ToString());
                    this.b = int.Parse(DateTime.Parse(list["StartTime"].ToString()).Month.ToString());
                    this.c = int.Parse(DateTime.Parse(list["StartTime"].ToString()).Day.ToString());
                    this.SpecialDays[this.a, this.b, this.c] = "";
                }
                list.Close();
            }
            else
            {
                str = "select Starttime from qp_oa_CarApply where CarId='" + StrCheck + "'";
                list = this.List.GetList(str);
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
                    string sQL = "select id,CarName from qp_oa_CarInfo  order by id asc";
                    this.list.Bind_DropDownListCar(this.typename, sQL, "id", "CarName");
                    this.years.SelectedValue = DateTime.Now.Year.ToString();
                    this.months.SelectedValue = DateTime.Now.Month.ToString();
                    this.Calendar1.VisibleDate = this.Calendar1.TodaysDate;
                    this.typename.Attributes["onchange"] = "javascript:showwait();";
                    if (base.Request.QueryString["HyName"] != null)
                    {
                        this.typename.SelectedValue = base.Request.QueryString["HyName"].ToString();
                    }
                }
                this.DataBindToGridview(this.typename.SelectedValue);
            }
        }

        protected void typename_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataBindToGridview(this.typename.SelectedValue);
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
        }
    }
}

