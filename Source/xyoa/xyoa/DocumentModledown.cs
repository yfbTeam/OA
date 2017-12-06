namespace xyoa
{
    using qiupeng.sql;
    using System;
    using System.Web.UI;

    public class DocumentModledown : Page
    {
        private Db List = new Db();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.close();</script>");
            }
            else
            {
                base.Response.Redirect("/SystemManage/DocumentModle/file/" + base.Request.QueryString["number"].ToString() + "");
            }
        }
    }
}

