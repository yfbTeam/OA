namespace xyoa.web
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Lanmu : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected head Head1;
        private Db List = new Db();
        public string listall;
        public int next;
        public int page;
        public int pageno;
        public int pre;
        private publics pulicss = new publics();
        protected right Right1;
        protected tail Tail1;
        protected TextBox Titles;
        public int totalPage;
        public int totalRows;
        public int yeci;

        protected void Button1_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview();
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Titles.Text != "")
            {
                str = str + " and Titles like '%" + this.pulicss.GetFormatStr(this.Titles.Text) + "%'";
            }
            return str;
        }

        public void DataBindToGridview()
        {
            if (base.Request.QueryString["page"] != null)
            {
                this.yeci = int.Parse(base.Request.QueryString["page"]);
            }
            else
            {
                this.yeci = 1;
            }
            if (base.Request.QueryString["page"] != null)
            {
                this.page = int.Parse(base.Request.QueryString["page"]);
            }
            else
            {
                this.page = 1;
            }
            if (base.Request.QueryString["page"] != null)
            {
                if (int.Parse(base.Request.QueryString["page"]) == 1)
                {
                    this.pre = 1;
                }
                else
                {
                    this.pre = int.Parse(base.Request.QueryString["page"]) - 1;
                }
            }
            else
            {
                this.pre = 1;
            }
            string sql = null;
            sql = string.Concat(new object[] { "select count(id) from   qp_web_Lanmu  where Leibie='", int.Parse(base.Request.QueryString["Leibie"]), "'  ", this.CreateMidSql(), "" });
            this.totalRows = this.List.GetCount(sql);
            if ((this.totalRows % 0x10) == 0)
            {
                this.totalPage = this.totalRows / 0x10;
            }
            else
            {
                this.totalPage = (this.totalRows / 0x10) + 1;
            }
            if (base.Request.QueryString["page"] != null)
            {
                if (int.Parse(base.Request.QueryString["page"]) == this.totalPage)
                {
                    this.next = this.totalPage;
                }
                else
                {
                    this.next = int.Parse(base.Request.QueryString["page"]) + 1;
                }
            }
            else if (this.totalPage == 1)
            {
                this.next = 1;
            }
            else
            {
                this.next = 2;
            }
            if (base.Request.QueryString["page"] != null)
            {
                this.pageno = (int.Parse(base.Request.QueryString["page"]) - 1) * 0x10;
            }
            else
            {
                this.pageno = 0;
            }
            try
            {
                string str2 = null;
                str2 = string.Concat(new object[] { "select top 16 id,Titles,Shijian,Leibie from qp_web_Lanmu  where id not in (select top ", this.pageno, " id  from qp_web_Lanmu where Leibie='", int.Parse(base.Request.QueryString["Leibie"]), "'  ", this.CreateMidSql(), "  order by id desc) and  Leibie='", int.Parse(base.Request.QueryString["Leibie"]), "'  ", this.CreateMidSql(), "  order by id desc" });
                SqlDataReader list = this.List.GetList(str2);
                this.listall = null;
                int num = 0;
                while (list.Read())
                {
                    string listall = this.listall;
                    this.listall = listall + "<tr><td width=\"500\" height=\"36\" align=\"left\" background=\"img/diandian.jpg\"><b>\x00b7</b>&nbsp;<a href=\"Lanmu_view.aspx?id=" + list["id"].ToString() + "&Leibie=" + list["Leibie"].ToString() + "\">" + list["Titles"].ToString() + "</a></td><td width=\"100\" height=\"36\" background=\"img/diandian.jpg\" >[" + DateTime.Parse(list["Shijian"].ToString()).ToShortDateString() + "]</td></tr>";
                    num++;
                    if (num == 1)
                    {
                        num = 0;
                    }
                }
                list.Close();
            }
            catch
            {
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.DataBindToGridview();
                string sql = "select * from qp_web_Biaoti";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Biaoti"] = list["Content"].ToString();
                }
                list.Close();
                string str2 = "select * from qp_web_JiejiariDay where  (('" + DateTime.Now.ToShortDateString() + "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + DateTime.Now.ToShortDateString() + "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('" + DateTime.Now.ToShortDateString() + "' as datetime),120)) )";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.ViewState["RightPic"] = "2";
                }
                else
                {
                    this.ViewState["RightPic"] = "1";
                }
                reader2.Close();
                this.ViewState["LeftName"] = this.pulicss.TypeCodeAll("Name", "qp_web_LanmuLb", this.pulicss.GetFormatStr(base.Request.QueryString["Leibie"].ToString()));
                this.Right1.A_value = this.ViewState["LeftName"].ToString();
            }
        }
    }
}

