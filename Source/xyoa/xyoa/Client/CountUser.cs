namespace xyoa.Client
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class CountUser : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from qp_useronline where username='" + base.Request.QueryString["username"] + "' ";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = "Update qp_useronline Set lasttime='" + DateTime.Now.ToString() + "',ipaddress='" + this.Page.Request.UserHostAddress + "'  where username='" + base.Request.QueryString["username"] + "'";
                this.List.ExeSql(str2);
            }
            else
            {
                string str3 = null;
                string str4 = "select realname from qp_oa_username where Username='" + base.Request.QueryString["user"].ToString() + "'";
                SqlDataReader reader2 = this.List.GetList(str4);
                if (reader2.Read())
                {
                    str3 = reader2["realname"].ToString();
                }
                reader2.Close();
                string str5 = "insert into qp_useronline values('" + base.Request.QueryString["username"] + "','" + str3 + "','" + DateTime.Now.ToString() + "','" + DateTime.Now.ToString() + "','" + this.Page.Request.UserHostAddress + "'  )";
                this.List.ExeSql(str5);
            }
            list.Close();
            list.Dispose();
        }
    }
}

