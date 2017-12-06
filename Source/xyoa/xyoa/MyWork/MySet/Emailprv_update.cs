namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Emailprv_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox EmailAdd;
        protected TextBox EmailName;
        protected TextBox EmailUserName;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Pop3;
        private publics pulicss = new publics();
        protected TextBox Smtp;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_Emailprv  Set EmailName='", this.EmailName.Text, "',EmailAdd='", this.EmailAdd.Text.Replace("<", "〈").Replace(">", "〉").Replace("'", "’"), "',EmailUserName='", this.EmailUserName.Text.Replace("<", "〈").Replace(">", "〉").Replace("'", "’"), "',Pop3='", this.Pop3.Text.Replace("<", "〈").Replace(">", "〉").Replace("'", "’"), "',Smtp='", this.Smtp.Text.Replace("<", "〈").Replace(">", "〉").Replace("'", "’"), "' where id='", int.Parse(base.Request.QueryString["id"]), "'  and username='", this.Session["username"], "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改邮件参数[" + this.EmailName.Text + "]", "邮件参数设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Emailprv.aspx'</script>");
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
                string sql = string.Concat(new object[] { "select * from qp_oa_Emailprv   where id='", int.Parse(base.Request.QueryString["id"]), "'  and username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.EmailName.Text = list["EmailName"].ToString();
                    this.EmailAdd.Text = list["EmailAdd"].ToString();
                    this.EmailUserName.Text = list["EmailUserName"].ToString();
                    this.Pop3.Text = list["Pop3"].ToString();
                    this.Smtp.Text = list["Smtp"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

