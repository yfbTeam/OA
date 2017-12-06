namespace xyoa.WorkFlowSysMag
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
        protected HtmlForm form1;
        protected TextBox FormId;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox NodeNum;
        protected TextBox NodeNumber;
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select * from qp_Pro_WorkFlowNode where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.NodeNum.Text = list["NodeNum"].ToString();
                this.NodeNumber.Text = list["NodeNumber"].ToString();
                this.FormId.Text = list["FormId"].ToString();
            }
            list.Close();
            string str2 = " Delete from qp_Pro_WorkFlowNode where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
            this.List.ExeSql(str2);
            string str3 = " Delete from qp_Pro_WorkFlowNodeLine  where Source='" + this.NodeNum.Text + "' and NodeNumber='" + this.NodeNumber.Text + "' and FormId='" + this.FormId.Text + "'";
            this.List.ExeSql(str3);
            string str4 = " Delete from qp_Pro_WorkFlowNodeLine  where Object='" + this.NodeNum.Text + "' and NodeNumber='" + this.NodeNumber.Text + "' and FormId='" + this.FormId.Text + "'";
            this.List.ExeSql(str4);
            base.Response.Write("<script language=javascript>alert('删除成功！');window.close();</script>");
        }
    }
}

