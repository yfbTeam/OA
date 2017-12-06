namespace xyoa
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class zhishitangdown : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.close();</script>");
            }
            else
            {
                string sql = string.Concat(new object[] { "select id from qp_oa_Zst_ziliao where NewName='", base.Server.UrlDecode(base.Request.QueryString["number"]), "' and  CHARINDEX(',", this.Session["username"], ",',','+UsernameXz+',')   >0" });
                SqlDataReader list = this.List.GetList(sql);
                if (!list.Read())
                {
                    string str2 = string.Concat(new object[] { "Update qp_oa_Zst_ziliao   Set UsernameXz=UsernameXz+'", this.Session["username"], ",',RealnameXz=RealnameXz+'", this.Session["realname"], "(", DateTime.Now.ToString(), "),'  where NewName='", base.Server.UrlDecode(base.Request.QueryString["number"]), "' " });
                    this.List.ExeSql(str2);
                }
                list.Close();
                string str3 = "Update qp_oa_Zst_ziliao   Set cishu=cishu+1  where NewName='" + base.Server.UrlDecode(base.Request.QueryString["number"]) + "' ";
                this.List.ExeSql(str3);
                base.Response.Redirect("" + base.Request.QueryString["number"].ToString() + "");
            }
        }
    }
}

