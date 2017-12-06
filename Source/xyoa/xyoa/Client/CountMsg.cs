namespace xyoa.Client
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;

    public class CountMsg : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select count(*) as counts from qp_oa_Messages where acceptusername='" + base.Request.QueryString["username"] + "' and sfck='0' and tablekey='1'";
            int count = this.List.GetCount(sql);
            base.Response.Write(count);
            string str2 = "Update qp_oa_username Set lasttime='" + DateTime.Now.ToString() + "',onlinetime=onlinetime+10  where username='" + base.Request.QueryString["username"] + "'";
            this.List.ExeSql(str2);
        }
    }
}

