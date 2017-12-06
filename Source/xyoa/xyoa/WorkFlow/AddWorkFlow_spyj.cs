namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class AddWorkFlow_spyj : Page
    {
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        public void DataBindToGridview(string str)
        {
            string str2;
            if (base.Request.QueryString["Buzhou"] != null)
            {
                if (base.Request.QueryString["key"].ToString() == "1")
                {
                    if (base.Request.QueryString["Buzhou"].ToString() != "")
                    {
                        str2 = "select * from qp_oa_AddWorkFlowMessage  where Number='" + base.Request.QueryString["Number"] + "' and CHARINDEX(','+Xuhao+',','," + base.Request.QueryString["Buzhou"] + ",') > 0 order by id asc";
                        this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
                        this.GridView1.DataBind();
                    }
                    else
                    {
                        str2 = "select * from qp_oa_AddWorkFlowMessage  where Number='" + base.Request.QueryString["Number"] + "' order by id asc";
                        this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
                        this.GridView1.DataBind();
                    }
                }
                else if (base.Request.QueryString["Buzhou"].ToString() != "")
                {
                    str2 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowMessage  where Number='", base.Request.QueryString["Number"], "' and CHARINDEX(','+Xuhao+',',',", base.Request.QueryString["Buzhou"], ",') > 0 and username='", this.Session["Username"], "' order by id asc" });
                    this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
                    this.GridView1.DataBind();
                }
                else
                {
                    str2 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowMessage  where Number='", base.Request.QueryString["Number"], "' and username='", this.Session["Username"], "' order by id asc" });
                    this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
                    this.GridView1.DataBind();
                }
            }
            else if (base.Request.QueryString["key"].ToString() == "1")
            {
                str2 = "select * from qp_oa_AddWorkFlowMessage  where Number='" + base.Request.QueryString["Number"] + "' order by id asc";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
                this.GridView1.DataBind();
            }
            else
            {
                str2 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowMessage  where Number='", base.Request.QueryString["Number"], "' and username='", this.Session["Username"], "' order by id asc" });
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
                this.GridView1.DataBind();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.DataBindToGridview("");
            }
        }
    }
}

