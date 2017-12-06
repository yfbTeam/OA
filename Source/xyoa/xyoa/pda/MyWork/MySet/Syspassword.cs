namespace xyoa.pda.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Syspassword : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox NewPassword;
        protected TextBox NewPassword_c;
        protected TextBox Password;
        private publics pulicss = new publics();
        protected Label Username;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("main.aspx?leixing=1");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = FormsAuthentication.HashPasswordForStoringInConfigFile(this.Password.Text, "MD5");
            string str2 = FormsAuthentication.HashPasswordForStoringInConfigFile(this.NewPassword.Text, "MD5");
            string sql = "select * from qp_oa_username where Username='" + this.pulicss.GetFormatStr(this.Username.Text) + "' and Password='" + str + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str4 = "Update qp_oa_username Set Password='" + str2 + "' where Username='" + this.pulicss.GetFormatStr(this.Username.Text) + "' and Password='" + str + "'";
                this.List.ExeSql(str4);
                this.pulicss.InsertLog("修改密码", "修改密码");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Syspassword.aspx'</script>");
            }
            else
            {
                base.Response.Write("<script>alert('旧密码输入错误！')</Script>");
            }
            list.Close();
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
                this.Username.Text = this.Session["username"].ToString();
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
            }
        }
    }
}

