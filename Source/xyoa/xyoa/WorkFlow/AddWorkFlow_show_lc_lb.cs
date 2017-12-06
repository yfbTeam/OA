namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class AddWorkFlow_show_lc_lb : Page
    {
        protected TextBox FlowNumber;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void DataBindToGridview()
        {
            string sql = "select * from qp_oa_WorkFlowNode where  FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'  ";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("NodeSite");
                Label label2 = (Label) e.Row.FindControl("UpNodeNum");
                Label label3 = (Label) e.Row.FindControl("Label1");
                Label label4 = (Label) e.Row.FindControl("NodeNames");
                Label label5 = (Label) e.Row.FindControl("Label2");
                if (label.Text == "结束")
                {
                    label3.Text = "结束";
                }
                else
                {
                    label3.Text = label2.Text;
                }
                if (label4.Text == base.Request.QueryString["NodeName"].ToString())
                {
                    label5.Text = "<b><font color=red>" + label4.Text + "</font></b>";
                }
                else
                {
                    label5.Text = label4.Text;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.FlowNumber.Text = base.Request.QueryString["FlowNumber"].ToString();
                this.DataBindToGridview();
            }
        }
    }
}

