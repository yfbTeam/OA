namespace xyoa
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;

    public class CountMessage : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select count(*) as counts from qp_oa_Messages where acceptusername='" + this.Session["username"] + "' and sfck='0' and tablekey='1'";
            if (this.List.GetCount(sql) > 0)
            {
                base.Response.Write("1");
            }
            else
            {
                base.Response.Write("0");
            }
        }
    }
}

