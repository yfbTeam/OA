namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowName_show_add_yz_add : Page
    {
        protected Button Button1;
        protected TextBox FlowId;
        protected HtmlForm form1;
        protected TextBox FormId;
        protected TextBox FormNumber;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList NodeName;
        private publics pulicss = new publics();
        protected TextBox SyRealname;
        protected TextBox SyUsername;
        protected DropDownList yinzhang;

        public void BindAttribute()
        {
            this.SyRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_WorkFlowNameYz (NodeName,FormId,FlowId,FlowNumber,YzNumber,Name,SyUsername,SyRealname) values ('" + this.NodeName.SelectedValue + "','" + this.pulicss.GetFormatStr(this.FormId.Text) + "','" + this.pulicss.GetFormatStr(this.FlowId.Text) + "','" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowNumber"]) + "','" + this.yinzhang.SelectedValue + "','" + this.yinzhang.SelectedItem.Text + "','" + this.pulicss.GetFormatStr(this.SyUsername.Text) + "','" + this.pulicss.GetFormatStr(this.SyRealname.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增印章域使用[" + this.yinzhang.SelectedItem.Text + "]", "工作流设置");
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
                string sql = "select  *  from qp_oa_WorkFlowName where FlowNumber='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowNumber"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.FormId.Text = list["FormId"].ToString();
                    this.FlowId.Text = list["id"].ToString();
                }
                list.Close();
                string str2 = "select  *  from qp_oa_DIYForm where id='" + this.FormId.Text + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.FormNumber.Text = reader2["Number"].ToString();
                }
                reader2.Close();
                if (!base.IsPostBack)
                {
                    string sQL = "select * from qp_oa_FormFile where KeyFile='" + this.FormNumber.Text + "'and Type='[印章域]'";
                    this.list.Bind_DropDownList(this.yinzhang, sQL, "Number", "Name");
                    string str4 = "select NodeName from qp_oa_WorkFlowNode where FlowNumber='" + this.pulicss.GetFormatStr(base.Request.QueryString["FlowNumber"]) + "'";
                    this.list.Bind_DropDownListNodeName(this.NodeName, str4, "NodeName", "NodeName");
                }
            }
        }
    }
}

