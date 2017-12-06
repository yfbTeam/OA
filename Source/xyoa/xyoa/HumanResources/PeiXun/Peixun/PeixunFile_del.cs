namespace xyoa.HumanResources.PeiXun.Peixun
{
    using qiupeng.sql;
    using System;
    using System.Web.UI;

    public class PeixunFile_del : Page
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
                string sql = "Delete from qp_hr_PeixunFile where NewName='" + base.Server.UrlDecode(base.Request.QueryString["number"]) + "'";
                this.List.ExeSql(sql);
                base.Response.Write("<script language=javascript>alert('删除成功！');window.close();</script>");
            }
        }
    }
}

