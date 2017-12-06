namespace xyoa.WorkFlowSysMag
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class AddWorkFlow_show_lc_lb : Page
    {
        protected HtmlForm form1;
        protected TextBox FormId;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void DataBindToGridview()
        {
            string sql = "select * from qp_Pro_WorkFlowNode where  FormId='" + base.Request.QueryString["FormId"] + "'  ";
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
                Label label4 = (Label) e.Row.FindControl("NodeName");
                Label label5 = (Label) e.Row.FindControl("NodeNames");
                Label label6 = (Label) e.Row.FindControl("Label2");
                if (label.Text == "结束")
                {
                    label3.Text = "结束";
                }
                else
                {
                    label3.Text = label2.Text;
                }
                if (label5.Text == base.Request.QueryString["DqNodeId"].ToString())
                {
                    label6.Text = "<b><font color=red>" + label4.Text + "</font></b>";
                }
                else
                {
                    label6.Text = label4.Text;
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
                this.FormId.Text = base.Request.QueryString["FormId"].ToString();
                this.DataBindToGridview();
            }
        }
    }
}

