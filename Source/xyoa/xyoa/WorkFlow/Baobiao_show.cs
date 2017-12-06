namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Baobiao_show : Page
    {
        protected Button Button1;
        protected TextBox Endtime;
        protected DropDownList FlowId;
        protected HtmlForm form1;
        protected TextBox FqRealname;
        protected TextBox FqUsername;
        protected HtmlHead Head1;
        protected Label Label2;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected Panel Panel1;
        private publics pulicss = new publics();
        protected TextBox Starttime;
        protected DropDownList State;

        public void BindAttribute()
        {
            this.FqRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Write("<script language=javascript>window.parent.location.href='BaobiaoList.aspx?id=" + base.Request.QueryString["id"].ToString() + "&FlowId=" + this.FlowId.SelectedValue + "&State=" + this.State.SelectedValue + "&FqUsername=" + this.FqUsername.Text + "&Name=" + this.Name.Text + "&Starttime=" + this.Starttime.Text + "&Endtime=" + this.Endtime.Text + "'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                if (base.Request.QueryString["BiaodanId"] != null)
                {
                    this.Panel1.Visible = true;
                    string sQL = "select *  from qp_oa_WorkFlowName where FormId in (" + base.Request.QueryString["BiaodanId"].ToString() + "0) order by Paixun asc";
                    this.list.Bind_DropDownListLiuCheng(this.FlowId, sQL, "id", "FlowName");
                    this.Panel1.Visible = true;
                    this.BindAttribute();
                }
                else
                {
                    this.Panel1.Visible = false;
                    this.Label2.Text = "未选择报表，点击右边列表进行选择";
                }
            }
        }
    }
}

