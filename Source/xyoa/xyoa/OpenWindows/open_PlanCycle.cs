namespace xyoa.OpenWindows
{
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_PlanCycle : Page
    {
        protected Button Button4;
        protected HtmlForm Form1;
        protected GridView GridView1;
        private Db List = new Db();
        protected TextBox name;
        protected TextBox requeststr;
        public string type;
        public string typename;

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview("and  name like '%" + this.name.Text + "%'");
        }

        public void DataBindToGridview(string str)
        {
            string sql = "select * from qp_oa_AssetsType  where  1=1 " + str + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.name.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button4.click(); return false;}";
            }
            if (!this.Page.IsPostBack)
            {
                this.type = base.Request.QueryString["type"].ToString();
                this.requeststr.Text = base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString());
                this.typename = "物品类别";
            }
            this.DataBindToGridview("and  name like '%" + this.name.Text + "%'");
        }
    }
}

