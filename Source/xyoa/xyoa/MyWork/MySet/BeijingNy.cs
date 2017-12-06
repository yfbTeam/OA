namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BeijingNy : Page
    {
        protected Button Button4;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected RadioButtonList Name;
        protected TextBox Number;
        private publics pulicss = new publics();

        protected void Button4_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_yangshi  Set Name='", this.Name.SelectedValue, "'  where  Username='", this.Session["username"], "' " });
            this.List.ExeSql(sql);
            this.Session["yangshi"] = this.pulicss.Getyangshi();
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='BeijingNy.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_yangshi where  Username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.SelectedValue = list["Name"].ToString();
                }
                list.Close();
            }
        }
    }
}

