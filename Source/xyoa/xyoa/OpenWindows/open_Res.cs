namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_Res : Page
    {
        protected Button Button4;
        protected HtmlForm Form1;
        protected GridView GridView1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox requeststr;
        protected DropDownList ZyLeibie;
        protected TextBox ZyName;

        protected void Button4_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("open_Res.aspx?key=1&ZyName=" + this.ZyName.Text + "&ZyLeibie=" + this.ZyLeibie.SelectedValue + "&requeststr=" + base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString()) + "");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (base.Request.QueryString["key"] != null)
            {
                if (base.Request.QueryString["ZyName"].ToString() != "")
                {
                    str = str + " and A.ZyName like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["ZyName"])) + "%'";
                }
                if (base.Request.QueryString["ZyLeibie"].ToString() != "")
                {
                    str = str + " and A.ZyLeibie = '" + this.pulicss.GetFormatStr(base.Request.QueryString["ZyLeibie"]) + "'";
                }
            }
            return str;
        }

        public void DataBindToGridview()
        {
            string str4;
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string str = "select A.*, C.Name as ZyLeibies from [qp_oa_ResourcesAdd] as [A] join [qp_oa_ResourcesType] as [C] on [A].[ZyLeibie] = [C].id where 1=1";
            string str2 = string.Empty;
            str2 = this.CreateMidSql();
            string str3 = str + str2;
            if (base.Request.QueryString["key"] != null)
            {
                str4 = "" + str3 + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str4);
                this.GridView1.DataBind();
            }
            else
            {
                str4 = "select A.*, C.Name as ZyLeibies from [qp_oa_ResourcesAdd] as [A] join [qp_oa_ResourcesType] as [C] on [A].[ZyLeibie] = [C].id where 1=1 ";
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

        protected void ListChangedBind(object sender, EventArgs e)
        {
            this.DataBindToGridview();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.ZyName.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.Button4.click(); return false;}";
                this.requeststr.Text = base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString());
            }
            if (!base.IsPostBack)
            {
                string sQL = "select *  from qp_oa_ResourcesType";
                this.list.Bind_DropDownList_kong(this.ZyLeibie, sQL, "id", "Name");
            }
            this.DataBindToGridview();
        }
    }
}

