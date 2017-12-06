namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class MyPage_wt_show_sc : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.close();</script>");
            }
            else if (this.Session["username"].ToString() == "admin")
            {
                string sql = "select * from qp_oa_Zst_wenti   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = string.Concat(new object[] { "Update qp_oa_username  Set jifen=jifen", this.pulicss.JifenGuize("被删问题"), "  where username='", list["username"], "'" });
                    this.List.ExeSql(str2);
                    string str3 = "  Delete from qp_oa_Zst_wenti  where id='" + int.Parse(base.Request.QueryString["id"]) + "'";
                    this.List.ExeSql(str3);
                    string str4 = "  Delete from qp_oa_Zst_huida  where WentiId='" + int.Parse(base.Request.QueryString["id"]) + "'";
                    this.List.ExeSql(str4);
                }
                list.Close();
                base.Response.Write("<script language=javascript>alert('删除成功，刷新页面可看见效果！');window.close();</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('只有管理员才能删除问题！');window.close();</script>");
            }
        }
    }
}

