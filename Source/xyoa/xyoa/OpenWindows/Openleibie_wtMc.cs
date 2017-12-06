namespace xyoa.OpenWindows
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Openleibie_wtMc : Page
    {
        protected HtmlForm form1;
        protected TextBox gncdid;
        protected HtmlHead Head1;
        protected Label Label1;
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();
        protected TextBox States;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                this.Name.Attributes.Add("readonly", "readonly");
                string sql = "select * from qp_oa_Zst_leibie_wt where id='" + base.Request.QueryString["id"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.gncdid.Text = list["id"].ToString();
                    this.ZdBumenId.Text = list["ZdBumenId"].ToString();
                    this.ZdBumen.Text = list["ZdBumen"].ToString();
                    this.ZdUsername.Text = list["ZdUsername"].ToString();
                    this.ZdRealname.Text = list["ZdRealname"].ToString();
                    this.States.Text = list["States"].ToString();
                }
                else
                {
                    this.Label1.Text = "请在左边的树形菜单中选择问题分类";
                }
                list.Close();
            }
        }
    }
}

