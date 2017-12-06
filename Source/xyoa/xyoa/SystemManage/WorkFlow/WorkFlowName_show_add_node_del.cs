namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowName_show_add_node_del : Page
    {
        protected TextBox FlowNumber;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox NodeNum;
        protected TextBox NodeNumber;
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from qp_oa_WorkFlowNode where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.NodeNum.Text = list["NodeNum"].ToString();
                this.NodeNumber.Text = list["NodeNumber"].ToString();
                this.FlowNumber.Text = list["FlowNumber"].ToString();
            }
            list.Close();
            string str2 = " Delete from qp_oa_WorkFlowNode where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(str2);
            string str3 = " Delete from qp_oa_FlowFormFile where KeyID='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(str3);
            string str4 = " Delete from qp_oa_WorkFlowNodeLine where Source='" + this.NodeNum.Text + "' and NodeNumber='" + this.NodeNumber.Text + "' and FlowNumber='" + this.FlowNumber.Text + "'";
            this.List.ExeSql(str4);
            string str5 = " Delete from qp_oa_WorkFlowNodeLine where Object='" + this.NodeNum.Text + "' and NodeNumber='" + this.NodeNumber.Text + "' and FlowNumber='" + this.FlowNumber.Text + "'";
            this.List.ExeSql(str5);
            base.Response.Write("<script language=javascript>alert('删除成功！');window.window.close();</script>");
        }
    }
}

