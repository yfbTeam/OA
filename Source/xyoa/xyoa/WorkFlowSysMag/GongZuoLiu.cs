namespace xyoa.WorkFlowSysMag
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class GongZuoLiu : Page
    {
        protected Button Button3;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        protected void Button3_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlow.aspx?FormId=" + this.ViewState["FormId"] + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                string sql = "select * from qp_pro_WorkFlow  where id='" + base.Request.QueryString["FormId"].ToString() + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["LeixingName"] = list["Name"].ToString();
                    this.ViewState["FormId"] = list["FormId"].ToString();
                }
                list.Close();
            }
        }
    }
}

