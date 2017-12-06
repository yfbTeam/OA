namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_bumen : Page
    {
        protected Button Button4;
        protected HtmlForm Form1;
        protected GridView GridView1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox name;
        private publics pulicss = new publics();
        protected TextBox requeststr;

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("open_bumen.aspx?key=1&name=" + this.name.Text + "&user=" + base.Request.QueryString["user"].ToString() + "&requeststr=" + base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString()) + "");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if ((base.Request.QueryString["key"] != null) && (base.Request.QueryString["Name"].ToString() != ""))
            {
                str = str + " and Name like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["Name"])) + "%'";
            }
            return str;
        }

        public void DataBindToGridview()
        {
            string str4;
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string str = "";
            if (base.Request.QueryString["user"].ToString() != "")
            {
                str = "select id,Name from  qp_oa_Bumen where id in (" + base.Request.QueryString["user"].ToString() + "0) and 1=1";
            }
            else
            {
                str = "select id,Name from  qp_oa_Bumen where 1=1";
            }
            string str2 = string.Empty;
            str2 = this.CreateMidSql();
            string str3 = str + str2 + " order by id asc";
            if (base.Request.QueryString["key"] != null)
            {
                str4 = "" + str3 + " ";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str4);
                this.GridView1.DataBind();
            }
            else
            {
                str4 = "";
                if (base.Request.QueryString["user"].ToString() != "")
                {
                    str4 = "select id,Name from qp_oa_Bumen where id in (" + base.Request.QueryString["user"].ToString() + "0) and 1=1  order by id asc";
                }
                else
                {
                    str4 = "select id,Name from qp_oa_Bumen where  1=1  order by id asc";
                }
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
                this.name.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button4.click(); return false;}";
                this.requeststr.Text = base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString());
            }
            this.DataBindToGridview();
        }
    }
}

