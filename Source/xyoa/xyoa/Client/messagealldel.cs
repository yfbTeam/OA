namespace xyoa.Client
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;

    public class messagealldel : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Redirect("LoginMsg.aspx");
            }
            else
            {
                string str;
                if (base.Request.QueryString["delid"] != null)
                {
                    str = string.Concat(new object[] { "  Delete from qp_oa_Messages  where acceptusername='", this.Session["username"], "' and id='", base.Request.QueryString["delid"], "' and tablekey='1'" });
                    this.List.ExeSql(str);
                    base.Response.Redirect("mymessageall.aspx?user=" + base.Request.QueryString["user"] + "&pwd=" + base.Request.QueryString["pwd"] + "");
                }
                if (base.Request.QueryString["yyid"] != null)
                {
                    str = string.Concat(new object[] { "  update  qp_oa_Messages set sfck='1' where acceptusername='", this.Session["username"], "' and id='", base.Request.QueryString["yyid"], "' and tablekey='1'" });
                    this.List.ExeSql(str);
                    base.Response.Redirect("mymessageall.aspx?user=" + base.Request.QueryString["user"] + "&pwd=" + base.Request.QueryString["pwd"] + "");
                }
            }
        }
    }
}

