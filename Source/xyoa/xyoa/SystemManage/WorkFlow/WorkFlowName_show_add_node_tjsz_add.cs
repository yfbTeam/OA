namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowName_show_add_node_tjsz_add : Page
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
            string sql = "insert into qp_oa_FlowFormFile (JudgeType,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,KeyID,Number,Name,Type,Conditions,JudgeBasis,NodeId) values ('" + this.JudgeType.SelectedValue + "','" + this.pulicss.GetFormatStr(this.FormId.Text) + "','" + this.pulicss.GetFormatStr(this.FormNumber.Text) + "','" + this.pulicss.GetFormatStr(this.FormName.Text) + "','" + this.pulicss.GetFormatStr(this.FlowId.Text) + "','" + this.pulicss.GetFormatStr(this.FlowNumber.Text) + "','" + this.pulicss.GetFormatStr(this.FlowName.Text) + "','" + this.pulicss.GetFormatStr(this.KeyID.Text) + "','" + this.pulicss.GetFormatStr(this.Number.Text) + "','" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + this.pulicss.GetFormatStr(this.Type.Text) + "','" + this.Conditions.SelectedValue + "','" + this.pulicss.GetFormatStr(this.JudgeBasis.Text) + "','" + base.Request.QueryString["FlowId"] + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增条件设置[" + this.Name.Text + "]", "工作流设置");
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
                string sql = "select  *  from qp_oa_WorkFlowNode where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowId"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.FormNumber.Text = list["FormNumber"].ToString();
                    this.FormId.Text = list["FormId"].ToString();
                    this.FormName.Text = list["FormName"].ToString();
                    this.FlowId.Text = list["FlowId"].ToString();
                    this.FlowNumber.Text = list["FlowNumber"].ToString();
                    this.FlowName.Text = list["FlowName"].ToString();
                }
                this.KeyID.Text = base.Request.QueryString["KeyID"];
                list.Close();
            }
        }
    }
}

