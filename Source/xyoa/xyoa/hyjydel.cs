namespace xyoa
{
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class hyjydel : Page
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
                string sql = "select * from qp_oa_MettingApplyFj   where NewName='" + base.Server.UrlDecode(base.Request.QueryString["number"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = "Delete from qp_oa_MettingApplyFj where NewName='" + base.Server.UrlDecode(base.Request.QueryString["number"]) + "'";
                    this.List.ExeSql(str2);
                    base.Response.Write("<script language=javascript>alert('删除成功！');window.close();</script>");
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('删除失败！');window.close();</script>");
                }
                list.Close();
            }
        }
    }
}

