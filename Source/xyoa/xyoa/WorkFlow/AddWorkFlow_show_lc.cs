namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class AddWorkFlow_show_lc : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
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
                string sql = "select ShuXing from qp_oa_WorkFlowName  where FlowNumber='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowNumber"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read() && (list["ShuXing"].ToString() == "自由流程"))
                {
                    base.Response.Write("<script language=javascript>alert('当前流程为[自由流程]无固定流程结构');window.close()</script>");
                }
                else
                {
                    list.Close();
                }
            }
        }
    }
}

