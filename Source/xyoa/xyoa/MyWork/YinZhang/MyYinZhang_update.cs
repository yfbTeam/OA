namespace xyoa.MyWork.YinZhang
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyYinZhang_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Name;
        protected Image Newname;
        protected TextBox NewPassword;
        protected TextBox NewPassword_c;
        protected TextBox Number;
        protected TextBox Password;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return checkForm();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = FormsAuthentication.HashPasswordForStoringInConfigFile(this.Password.Text, "MD5");
            string str2 = FormsAuthentication.HashPasswordForStoringInConfigFile(this.NewPassword.Text, "MD5");
            string sql = string.Concat(new object[] { "select * from qp_oa_YinZhang where Username='", this.Session["username"], "' and Password='", str, "'  and  id='", base.Request.QueryString["id"], "'" });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str4 = "Update qp_oa_YinZhang Set Password='" + str2 + "' where id='" + base.Request.QueryString["id"] + "' and Password='" + str + "'";
                this.List.ExeSql(str4);
            }
            else
            {
                base.Response.Write("<script>alert('旧密码输入错误！')</Script>");
                return;
            }
            list.Close();
            this.pulicss.InsertLog("修改密码[" + this.Name.Text + "]", "我的印章");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyYinZhang.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyYinZhang.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_YinZhang where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Newname.ImageUrl = "/seal/" + list["Newname"].ToString() + "";
                    this.Name.Text = list["Name"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

