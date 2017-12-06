namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class open_FormFile : Page
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
            base.Response.Redirect("open_FormFile.aspx?str=" + this.name.Text + "&requeststr=" + base.Server.UrlDecode(base.Request.QueryString["requeststr"].ToString()) + "&FlowId=" + base.Request.QueryString["FlowId"] + "&FormNumber=" + base.Request.QueryString["FormNumber"] + "");
        }

        public void DataBindToGridview()
        {
            string str;
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            if (base.Request.QueryString["str"] != null)
            {
                str = string.Concat(new object[] { "select * from qp_oa_FormFile  where KeyFile='", base.Request.QueryString["FormNumber"], "' and  name like '%", base.Server.UrlDecode(base.Request.QueryString["str"]), "%' and type!='[印章域]' and id  in (", this.ViewState["Kexie"], ")  order by id desc" });
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
                this.GridView1.DataBind();
            }
            else
            {
                str = string.Concat(new object[] { "select * from qp_oa_FormFile  where  KeyFile='", base.Request.QueryString["FormNumber"], "' and type!='[印章域]' and id  in (", this.ViewState["Kexie"], ")  order by id desc" });
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
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
                string sql = "select  *  from qp_oa_WorkFlowNode where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowId"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Kexie"] = "" + list["WriteFileID"].ToString() + "0";
                }
                list.Close();
            }
            this.DataBindToGridview();
        }
    }
}

