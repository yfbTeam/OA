namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowName_show_add_yz_update : Page
    {
        protected Button Button1;
        protected TextBox FlowId;
        protected HtmlForm form1;
        protected TextBox FormId;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected DropDownList NodeName;
        private publics pulicss = new publics();
        protected TextBox SyRealname;
        protected TextBox SyUsername;

        public void BindAttribute()
        {
            this.SyRealname.Attributes.Add("readonly", "readonly");
            this.Name.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_WorkFlowNameYz    Set NodeName='", this.NodeName.SelectedValue, "',SyUsername='", this.pulicss.GetFormatStr(this.SyUsername.Text), "',SyRealname='", this.pulicss.GetFormatStr(this.SyRealname.Text), "'   where id='", int.Parse(base.Request.QueryString["id"]), "' " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改印章域使用[" + this.Name.Text + "]", "工作流设置");
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
                string sql = "select  *  from qp_oa_WorkFlowNameYz where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string sQL = "select NodeName from qp_oa_WorkFlowNode where FlowNumber='" + list["FlowNumber"].ToString() + "'";
                    this.list.Bind_DropDownListNodeName(this.NodeName, sQL, "NodeName", "NodeName");
                    this.NodeName.SelectedValue = list["NodeName"].ToString();
                    this.Name.Text = list["Name"].ToString();
                    this.SyUsername.Text = list["SyUsername"].ToString();
                    this.SyRealname.Text = list["SyRealname"].ToString();
                }
                list.Close();
            }
        }
    }
}

