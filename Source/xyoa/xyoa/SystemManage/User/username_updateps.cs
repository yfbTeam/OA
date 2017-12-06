namespace xyoa.SystemManage.User
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class username_updateps : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        protected TextBox oldPassword;
        protected TextBox Password;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label Username;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = FormsAuthentication.HashPasswordForStoringInConfigFile(this.Password.Text, "MD5");
            string sql = string.Concat(new object[] { "Update qp_oa_username  Set Password='", str, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改用户密码[" + this.Realname.Text + "]", "用户管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='username.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("username.aspx");
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
                string sql = "select username,realname from qp_oa_username where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Username.Text = list["username"].ToString();
                    this.Realname.Text = list["realname"].ToString();
                }
                list.Close();
            }
        }
    }
}

