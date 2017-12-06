namespace xyoa.PublicWork.BumenPage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;

    public class BumenSz_del : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "  Delete from qp_oa_BumenZy  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(sql);
            string str2 = "  Delete from qp_oa_BumenWz  where ZhuyeId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(str2);
            this.pulicss.InsertLog("删除部门主页", "部门主页");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='BumenSz.aspx'</script>");
        }
    }
}

