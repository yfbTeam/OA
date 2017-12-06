namespace xyoa.WorkFlowSysMag
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Web.UI;

    public class WorkFlowName_show_add_node_savaps : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = null;
            string str2 = null;
            str2 = "" + base.Request.QueryString["str"].ToString() + "";
            ArrayList list = new ArrayList();
            string[] strArray = str2.Split(new char[] { ';' });
            for (int i = 0; i < strArray.Length; i++)
            {
                sql = "update qp_Pro_WorkFlowNode set " + strArray[i] + "";
                this.List.ExeSql(sql);
            }
            base.Response.Write("<script language=javascript>alert('保存成功！');window.close();</script>");
        }
    }
}

