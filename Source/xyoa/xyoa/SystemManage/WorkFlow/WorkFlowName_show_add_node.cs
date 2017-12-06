namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowName_show_add_node : Page
    {
        protected Button Button6;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        protected void Button5_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("FlowMg_list.aspx?FormId=" + this.ViewState["FormId"] + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!base.IsPostBack)
            {
                string sql = "select FormId from qp_oa_WorkFlowName   where  FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                while (list.Read())
                {
                    this.ViewState["FormId"] = list["FormId"].ToString();
                }
                list.Close();
                Random random = new Random();
                string str2 = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str2 + "";
            }
        }
    }
}

