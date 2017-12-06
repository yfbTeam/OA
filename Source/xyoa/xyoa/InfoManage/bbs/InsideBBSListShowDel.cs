namespace xyoa.InfoManage.bbs
{
    using qiupeng.sql;
    using System;
    using System.Web.UI;

    public class InsideBBSListShowDel : Page
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
                string sql = " Delete from qp_oa_InsideBBS where id='" + base.Request.QueryString["id"] + "'";
                this.List.ExeSql(sql);
                base.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='InsideBBSListShow.aspx?id=" + base.Request.QueryString["Backid"] + "&BigId=" + base.Request.QueryString["BigId"] + "';window.close();</script>");
            }
        }
    }
}

