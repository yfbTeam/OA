namespace xyoa.mainpage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;

    public class mymessagedel : Page
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
                string str2;
                if (base.Request.QueryString["delid"] != null)
                {
                    str = string.Concat(new object[] { "  Delete from qp_oa_Messages  where acceptusername='", this.Session["username"], "' and id='", base.Request.QueryString["delid"], "' and tablekey='1'" });
                    this.List.ExeSql(str);
                    str2 = string.Concat(new object[] { "Update qp_oa_Messages  Set sfck='1' , CkTime='", DateTime.Now.ToString(), "' where acceptusername='", this.Session["username"], "' and number='", base.Request.QueryString["number"], "' and tablekey='2'" });
                    this.List.ExeSql(str2);
                    if (base.Request.QueryString["type"] != null)
                    {
                        if (base.Request.QueryString["type"].ToString() == "2")
                        {
                            base.Response.Redirect("mymessage.aspx?type=" + base.Request.QueryString["type"].ToString() + "");
                        }
                        else
                        {
                            base.Response.Redirect("mymessage.aspx?type=" + base.Request.QueryString["type"].ToString() + "");
                        }
                    }
                    else
                    {
                        base.Response.Redirect("mymessage.aspx");
                    }
                }
                if (base.Request.QueryString["yyid"] != null)
                {
                    str = string.Concat(new object[] { "  update  qp_oa_Messages set sfck='1', CkTime='", DateTime.Now.ToString(), "' where acceptusername='", this.Session["username"], "' and id='", base.Request.QueryString["yyid"], "' and tablekey='1'" });
                    this.List.ExeSql(str);
                    str2 = string.Concat(new object[] { "Update qp_oa_Messages  Set sfck='1' , CkTime='", DateTime.Now.ToString(), "' where acceptusername='", this.Session["username"], "' and number='", base.Request.QueryString["number"], "' and tablekey='2'" });
                    this.List.ExeSql(str2);
                    if (base.Request.QueryString["type"] != null)
                    {
                        if (base.Request.QueryString["type"].ToString() == "2")
                        {
                            base.Response.Redirect("mymessage.aspx?type=" + base.Request.QueryString["type"].ToString() + "");
                        }
                        else
                        {
                            base.Response.Redirect("mymessage.aspx?type=" + base.Request.QueryString["type"].ToString() + "");
                        }
                    }
                    else
                    {
                        base.Response.Redirect("mymessage.aspx");
                    }
                }
            }
        }
    }
}

