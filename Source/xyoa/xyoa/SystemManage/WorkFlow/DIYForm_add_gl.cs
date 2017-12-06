namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class DIYForm_add_gl : Page
    {
        protected TextBox BmGuoLvName;
        protected TextBox BmGuoLvUser;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox KxGuoLvName;
        protected TextBox KxGuoLvUser;
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Name.Attributes.Add("readonly", "readonly");
            this.KxGuoLvName.Attributes.Add("readonly", "readonly");
            this.BmGuoLvName.Attributes.Add("readonly", "readonly");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_FormFile  Set KxGuoLvUser='" + this.pulicss.GetFormatStr(this.KxGuoLvUser.Text) + "',KxGuoLvName='" + this.pulicss.GetFormatStr(this.KxGuoLvName.Text) + "',BmGuoLvUser='" + this.pulicss.GetFormatStr(this.BmGuoLvUser.Text) + "',BmGuoLvName='" + this.pulicss.GetFormatStr(this.BmGuoLvName.Text) + "'  where Number='" + this.pulicss.GetFormatStr(base.Request.QueryString["Number"]) + "'";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("设置过滤字段[" + this.Name.Text + "]", "表单字段");
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
                    this.KxGuoLvUser.Text = list["KxGuoLvUser"].ToString();
                    this.KxGuoLvName.Text = list["KxGuoLvName"].ToString();
                    this.BmGuoLvUser.Text = list["BmGuoLvUser"].ToString();
                    this.BmGuoLvName.Text = list["BmGuoLvName"].ToString();
                    if (list["Type"].ToString() == "[印章域]")
                    {
                        base.Response.Write("<script language=javascript>alert('[印章域]不允许设置过滤人员。');window.close();</script>");
                        return;
                    }
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

