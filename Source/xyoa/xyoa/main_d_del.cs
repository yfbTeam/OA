namespace xyoa
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;

    public class main_d_del : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                string sql = string.Concat(new object[] { " Delete from qp_oa_DIYMould where keyid='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["username"], "'" });
                this.List.ExeSql(sql);
                base.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='main_d.aspx';window.close();</script>");
            }
        }
    }
}

