namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;

    public class MyPage_wt_show_qxtj : Page
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
                string sql = "Update qp_oa_Zst_wenti  Set  tuijian='2' where id='" + int.Parse(base.Request.QueryString["id"]) + "'";
                this.List.ExeSql(sql);
                base.Response.Write("<script language=javascript>alert('取消推荐成功，重新打开页面可看见效果！');window.close();</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('只有管理员才能取消推荐问题！');window.close();</script>");
            }
        }
    }
}

