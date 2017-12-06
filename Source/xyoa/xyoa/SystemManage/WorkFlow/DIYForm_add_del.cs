namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class DIYForm_add_del : Page
    {
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = " Delete from qp_oa_FormFile where Number='" + this.pulicss.GetFormatStr(base.Request.QueryString["Number"]) + "'";
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }
    }
}

