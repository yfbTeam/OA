namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Emailprv_Pass : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox EmailAdd;
        protected TextBox EmailName;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox NewPassword;
        protected TextBox Password;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string text = this.Password.Text;
            string str2 = this.NewPassword.Text;
            string sql = string.Concat(new object[] { "select * from qp_oa_Emailprv where id='", int.Parse(base.Request.QueryString["id"]), "' and EmailPassword='", text, "'" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str4 = string.Concat(new object[] { "Update qp_oa_Emailprv Set EmailPassword='", str2, "' where id='", int.Parse(base.Request.QueryString["id"]), "' and EmailPassword='", text, "'" });
                this.List.ExeSql(str4);
                this.pulicss.InsertLog("修改邮件参数[" + this.EmailName.Text + "]", "邮件参数设置");
                base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Emailprv.aspx'</script>");
            }
            else
            {
                base.Response.Write("<script>alert('旧密码输入错误！')</Script>");
                return;
            }
            list.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Emailprv.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_Emailprv   where id='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.EmailName.Text = list["EmailName"].ToString();
                    this.EmailAdd.Text = list["EmailAdd"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

