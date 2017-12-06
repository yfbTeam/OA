namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowNodeGD_add : Page
    {
        protected Button Button1;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        public string LineW;
        public string LineWSta;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Paixun;
        protected DropDownList ParentNodesID;
        private publics pulicss = new publics();
        public string QxString;
        public string QxStringSta;
        protected DropDownList States;
        protected TextBox ZdBumen;
        protected TextBox ZdBumenId;
        protected TextBox ZdRealname;
        protected TextBox ZdUsername;

        public void BindAttribute()
        {
            this.ZdBumen.Attributes.Add("readonly", "readonly");
            this.ZdRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_WorkFlowNodeGD (ParentNodesID,Name,States,ZdBumenId,ZdBumen,ZdUsername,ZdRealname,Paixun) values ('" + this.ParentNodesID.SelectedValue + "','" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + this.States.SelectedValue + "','" + this.pulicss.GetFormatStr(this.ZdBumenId.Text) + "','" + this.pulicss.GetFormatStr(this.ZdBumen.Text) + "','" + this.pulicss.GetFormatStr(this.ZdUsername.Text) + "','" + this.pulicss.GetFormatStr(this.ZdRealname.Text) + "','" + this.pulicss.GetFormatStr(this.Paixun.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增归档目录[" + this.Name.Text + "]", "归档目录");
            if (this.CheckBox1.Checked)
            {
                base.Response.Write("<script language=javascript>alert('提交成功！'); window.location = 'WorkFlowNodeGD_add.aspx?id=" + this.ParentNodesID.SelectedValue + "'</script>");
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('提交成功！'); window.parent.location = 'WorkFlowNodeGD.aspx'</script>");
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
                this.pulicss.BindListBm("qp_oa_WorkFlowNodeGD", this.ParentNodesID, "", "order by Paixun asc");
                if (base.Request.QueryString["id"] != null)
                {
                    this.ParentNodesID.SelectedValue = base.Request.QueryString["id"].ToString();
                }
                this.BindAttribute();
            }
        }
    }
}

