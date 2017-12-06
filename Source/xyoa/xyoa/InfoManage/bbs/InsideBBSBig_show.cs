namespace xyoa.InfoManage.bbs
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class InsideBBSBig_show : Page
    {
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();
        protected DropDownList State;
        protected TextBox UnitId;
        protected TextBox UnitName;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("InsideBBSBig.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_InsideBBSBig where id='" + base.Request.QueryString["id"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.State.SelectedValue = list["State"].ToString();
                    this.UnitId.Text = list["UnitId"].ToString();
                    this.UnitName.Text = list["UnitName"].ToString();
                }
                list.Close();
            }
        }
    }
}

