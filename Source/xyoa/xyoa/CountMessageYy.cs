namespace xyoa
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;

    public class CountMessageYy : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Redirect("/");
            }
            else
            {
                string str;
                string str2;
                if (base.Request.QueryString["allyyid"] != null)
                {
                    str = string.Concat(new object[] { "  update  qp_oa_Messages set sfck='1', CkTime='", DateTime.Now.ToString(), "' where acceptusername='", this.Session["username"], "' and sfck='0' and tablekey='1'" });
                    this.List.ExeSql(str);
                    str2 = string.Concat(new object[] { "Update qp_oa_Messages  Set sfck='1' , CkTime='", DateTime.Now.ToString(), "' where acceptusername='", this.Session["username"], "' and sfck='0' and tablekey='2'" });
                    this.List.ExeSql(str2);
                    base.Response.Redirect("CountMessagejs.aspx");
                }
                if (base.Request.QueryString["alldelid"] != null)
                {
                    str2 = string.Concat(new object[] { "Update qp_oa_Messages  Set sfck='1' , CkTime='", DateTime.Now.ToString(), "' where acceptusername='", this.Session["username"], "' and sfck='0' and tablekey='2'" });
                    this.List.ExeSql(str2);
                    str = "  Delete from qp_oa_Messages  where acceptusername='" + this.Session["username"] + "' and sfck='0' and tablekey='1'";
                    this.List.ExeSql(str);
                    base.Response.Redirect("CountMessagejs.aspx");
                }
            }
        }
    }
}

