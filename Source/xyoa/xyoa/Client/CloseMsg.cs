namespace xyoa.Client
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.Security;
    using System.Web.UI;

    public class CloseMsg : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string str = FormsAuthentication.HashPasswordForStoringInConfigFile(base.Request.QueryString["pwd"].ToString(), "MD5");
            string sql = "select Username,ResponQx from qp_oa_username where Username='" + base.Request.QueryString["user"].ToString() + "' and Password='" + str + "'and Iflogin='1'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str4;
                list.Close();
                if (base.Request.QueryString["type"].ToString() == "1")
                {
                    string str3 = "Update qp_oa_Messages Set sfck='1' where  acceptusername='" + base.Request.QueryString["user"] + "' and sfck='0' and  id in (select top 50 id from qp_oa_Messages where sfck='0' order by id desc)";
                    this.List.ExeSql(str3);
                }
                if (base.Request.QueryString["type"].ToString() == "2")
                {
                    str4 = "  Delete from qp_oa_Messages  where acceptusername='" + base.Request.QueryString["user"] + "' and sfck='0' and  id in (select top 50 id from qp_oa_Messages where sfck='0' order by id desc)";
                    this.List.ExeSql(str4);
                }
                if (base.Request.QueryString["type"].ToString() == "3")
                {
                    str4 = "  Delete from qp_oa_Messages  where acceptusername='" + base.Request.QueryString["user"] + "' and sfck='1' and  id in (select top 50 id from qp_oa_Messages where sfck='1' order by id desc)";
                    this.List.ExeSql(str4);
                }
                if (base.Request.QueryString["type"].ToString() == "4")
                {
                    str4 = "  Delete from qp_oa_Messages  where acceptusername='" + base.Request.QueryString["user"] + "' and  id in (select top 50 id from qp_oa_Messages order by id desc)";
                    this.List.ExeSql(str4);
                }
            }
        }
    }
}

