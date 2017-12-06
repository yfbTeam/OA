namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_ProCaiLiao : Page
    {
        protected Button Button4;
        protected HtmlForm Form1;
        protected GridView GridView1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();
        protected TextBox requeststr;
        protected DropDownList Xinyong;

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("open_ProCaiLiao.aspx?key=1&Name=" + this.Name.Text + "&Xinyong=" + this.Xinyong.SelectedValue + "&requeststr=" + base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString()) + "");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (base.Request.QueryString["key"] != null)
            {
                if (base.Request.QueryString["Name"].ToString() != "")
                {
                    str = str + " and Name like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["Name"])) + "%'";
                }
                if (base.Request.QueryString["Xinyong"].ToString() != "")
                {
                    str = str + " and Xinyong = '" + this.pulicss.GetFormatStr(base.Request.QueryString["Xinyong"]) + "'";
                }
            }
            return str;
        }

        public void DataBindToGridview()
        {
            string str4;
            string str = "select * from qp_oa_ProCaiLiao where 1=1";
            string str2 = string.Empty;
            str2 = this.CreateMidSql();
            string str3 = str + str2;
            if (base.Request.QueryString["key"] != null)
            {
                str4 = "" + str3 + " ";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str4);
                this.GridView1.DataBind();
            }
            else
            {
                str4 = "select * from qp_oa_ProCaiLiao where 1=1 ";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str4);
                this.GridView1.DataBind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.DataBindToGridview();
            this.GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.Name.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button4.click(); return false;}";
                this.requeststr.Text = base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString());
            }
            if (!base.IsPostBack)
            {
                string sQL = "select * from qp_ProData where type='5'";
                this.list.Bind_DropDownList_nothing(this.Xinyong, sQL, "id", "name");
            }
            this.DataBindToGridview();
        }
    }
}

