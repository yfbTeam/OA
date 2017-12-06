namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListXlSearch : Page
    {
        protected Button Button2;
        protected TextBox Endtime;
        protected ListBox FlowId;
        protected HtmlForm form1;
        protected TextBox FqRealname;
        protected TextBox FqUsername;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Starttime;

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = null;
            for (int i = 0; i <= (this.FlowId.Items.Count - 1); i++)
            {
                if (this.FlowId.Items[i].Selected)
                {
                    str = str + "" + this.FlowId.Items[i].Value + ",";
                }
            }
            base.Response.Redirect("WorkFlowListXl.aspx?FlowId=" + str + "0&UserId=" + this.FqUsername.Text + "0&Starttime=" + this.Starttime.Text + "&Endtime=" + this.Endtime.Text + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,FlowName  from qp_oa_WorkFlowName  where ShuXing='固定流程' order by Paixun asc";
                this.list.Bind_DropDownList_ListBox(this.FlowId, sQL, "id", "FlowName");
                this.FqRealname.Attributes.Add("readonly", "readonly");
                this.Button2.Attributes["onclick"] = "javascript:return check_form();";
            }
        }
    }
}

