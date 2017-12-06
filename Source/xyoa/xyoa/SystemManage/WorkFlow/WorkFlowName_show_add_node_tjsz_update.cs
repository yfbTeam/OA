namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowName_show_add_node_tjsz_update : Page
    {
        protected Button Button1;
        protected DropDownList Conditions;
        protected TextBox FlowId;
        protected TextBox FlowName;
        protected TextBox FlowNumber;
        protected HtmlForm form1;
        protected TextBox FormId;
        protected TextBox FormName;
        protected TextBox FormNumber;
        protected HtmlHead Head1;
        protected TextBox JudgeBasis;
        protected DropDownList JudgeType;
        protected TextBox KeyID;
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Type;

        public void BindAttribute()
        {
            this.Name.Attributes.Add("readonly", "readonly");
            this.Type.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_FlowFormFile    Set JudgeType='", this.JudgeType.SelectedValue, "',Number='", this.Number.Text, "',Name='", this.Name.Text, "',Type='", this.pulicss.GetFormatStr(this.Type.Text), "',Conditions='", this.Conditions.SelectedValue, "' ,JudgeBasis='", this.pulicss.GetFormatStr(this.JudgeBasis.Text), "'   where id='", int.Parse(base.Request.QueryString["id"]), "' " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改条件设置[" + this.Name.Text + "]", "工作流设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
                string sql = "select  *  from qp_oa_FlowFormFile  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.FormId.Text = list["FormId"].ToString();
                    this.FormNumber.Text = list["FormNumber"].ToString();
                    this.FormName.Text = list["FormName"].ToString();
                    this.FlowId.Text = list["FlowId"].ToString();
                    this.FlowNumber.Text = list["FlowNumber"].ToString();
                    this.FlowName.Text = list["FlowName"].ToString();
                    this.Number.Text = list["Number"].ToString();
                    this.Name.Text = list["Name"].ToString();
                    this.Type.Text = list["Type"].ToString();
                    this.Conditions.SelectedValue = list["Conditions"].ToString();
                    this.JudgeBasis.Text = list["JudgeBasis"].ToString();
                    this.JudgeType.SelectedValue = list["JudgeType"].ToString();
                }
                list.Close();
            }
        }
    }
}

