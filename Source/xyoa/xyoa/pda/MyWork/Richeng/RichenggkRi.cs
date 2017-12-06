namespace xyoa.pda.MyWork.Richeng
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class RichenggkRi : Page
    {
        protected Button btnFirst;
        protected Button btnLast;
        protected Button btnNext;
        protected Button btnPrev;
        protected Button Button1;
        protected Button Button4;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected ImageButton ImageButton1;
        protected ImageButton ImageButton2;
        protected ImageButton ImageButton3;
        protected ImageButton ImageButton4;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Starttime;
        protected TextBox titles;

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                this.GridView1.PageIndex = Convert.ToInt32(((Button) sender).CommandName) - 1;
                this.DataBindToGridview();
            }
            catch
            {
                base.Response.Write("<script language='javascript'>alert('没有这么多页！');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("/pda/Main.aspx?leixing=1");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview();
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.titles.Text != "")
            {
                str = str + " and titles like '%" + this.pulicss.GetFormatStr(this.titles.Text) + "%'";
            }
            if ((this.Starttime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and ((StartTime between '" + this.Starttime.Text + "'and  '" + this.Endtime.Text + "') or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + this.Starttime.Text + "' as datetime),120)) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120)) ) ";
            }
            return str;
        }

        public void DataBindToGridview()
        {
            string sql = "select id,titles,StartTime,EndTime,Username,Gongkai,Realname from qp_oa_MyRicheng  where Gongkai='是' " + this.CreateMidSql() + " order by id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            this.btnFirst.CommandName = "1";
            this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
            this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : ((this.GridView1.PageIndex + 2)).ToString();
            this.btnLast.CommandName = this.GridView1.PageCount.ToString();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime time2 = time.AddMonths(1).AddDays(-1.0);
            this.Starttime.Text = "" + time.ToShortDateString() + "";
            this.Endtime.Text = "" + time2.ToShortDateString() + "";
            this.DataBindToGridview();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            base.Response.Redirect("RichenggkRi.aspx");
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            this.Starttime.Text = DateTime.Now.ToShortDateString();
            this.Endtime.Text = DateTime.Now.ToShortDateString();
            this.DataBindToGridview();
        }

        protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
        {
            DateTime time = DateTime.Parse(DateTime.Now.Year.ToString() + "-01-01");
            int num = Convert.ToInt32(time.DayOfWeek);
            int num2 = (-1 * num) + 1;
            string s = time.AddDays((double) num2).ToString("yyyy-MM-dd");
            TimeSpan span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(s));
            int num3 = (span.Days / 7) + 1;
            int num4 = 7 * (num3 - 1);
            string str2 = DateTime.Parse(s).AddDays((double) num4).ToShortDateString();
            string str3 = DateTime.Parse(str2).AddDays(6.0).ToShortDateString();
            this.Starttime.Text = "" + str2 + "";
            this.Endtime.Text = "" + str3 + "";
            this.DataBindToGridview();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Starttime.Attributes.Add("readonly", "readonly");
                this.Endtime.Attributes.Add("readonly", "readonly");
                this.ImageButton1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ImageButton2.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ImageButton3.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ImageButton4.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnFirst.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnPrev.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnNext.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnLast.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button4.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                this.DataBindToGridview();
            }
        }
    }
}

