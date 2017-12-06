namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class jifen : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected GridView GridView4;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.GridView4.Rows)
            {
                int num = int.Parse(((Label) row.FindControl("Label8")).Text);
                string sql = string.Concat(new object[] { "Update qp_oa_Zst_guize  Set Fenshu='", ((TextBox) row.FindControl("Fenshu")).Text.Trim(), "' where id='", num, "'" });
                this.List.ExeSql(sql);
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='jifen.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianVis(this.GridView4, "aaaa1a4", this.Session["perstr"].ToString());
                string sql = "select * from [qp_oa_Zst_guize]";
                this.GridView4.DataSource = this.List.GetGrid_Pages_not(sql);
                this.GridView4.DataBind();
            }
        }
    }
}

