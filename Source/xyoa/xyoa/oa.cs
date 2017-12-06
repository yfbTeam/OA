namespace xyoa
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class oa : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select Content from qp_web_Zhuangtai";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                if (list["Content"].ToString() == "0")
                {
                    list.Close();
                    base.Response.Redirect("Login.aspx");
                }
                else
                {
                    list.Close();
                    base.Response.Redirect("web.aspx");
                }
            }
            list.Close();
        }
    }
}

