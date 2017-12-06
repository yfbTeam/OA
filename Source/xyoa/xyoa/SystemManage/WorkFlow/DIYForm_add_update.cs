namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class DIYForm_add_update : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        private Db List = new Db();
        protected TextBox Name;
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected TextBox sqlstr;
        protected DropDownList Type;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_FormFile  Set sqlstr='" + this.pulicss.GetFormatStr(this.sqlstr.Text) + "',Name='" + this.pulicss.GetFormatStr(this.Name.Text) + "',Type='" + this.Type.SelectedValue + "'  where Number='" + this.pulicss.GetFormatStr(base.Request.QueryString["Number"]) + "'";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改表单字段[" + this.Name.Text + "]", "表单字段");
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
                string sql = "select * from qp_oa_FormFile where Number='" + this.pulicss.GetFormatStr(base.Request.QueryString["Number"].ToString()) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["name"].ToString();
                    this.Type.SelectedValue = list["Type"].ToString();
                    this.sqlstr.Text = list["sqlstr"].ToString();
                    if (list["leixing"].ToString() == "1")
                    {
                        this.Panel1.Visible = true;
                        this.Panel2.Visible = true;
                        this.Label1.Text = "算法：";
                    }
                    else if (list["leixing"].ToString() == "2")
                    {
                        this.Panel1.Visible = true;
                        this.Panel2.Visible = false;
                        this.Label1.Text = "列表明细字段编号：";
                    }
                    else if (list["Type"].ToString() == "[列表]")
                    {
                        this.Panel1.Visible = true;
                        this.Panel2.Visible = false;
                        this.Label1.Text = "语法：";
                    }
                    else
                    {
                        this.Panel1.Visible = false;
                        this.Panel2.Visible = false;
                        this.Label1.Text = "算法：";
                    }
                    if (list["Type"].ToString() == "[关联办理意见]")
                    {
                        this.Panel1.Visible = true;
                        this.Panel2.Visible = false;
                        this.Label1.Text = "关联步骤：";
                    }
                }
                list.Close();
            }
        }
    }
}

