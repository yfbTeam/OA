namespace xyoa.Client
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class GetUser : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                string sql = "select Realname from qp_oa_username where Username='" + base.Request.QueryString["user"].ToString() + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    base.Response.Write(list["Realname"].ToString());
                }
                list.Close();
            }
        }
    }
}

