namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Emailprv_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox EmailAdd;
        protected TextBox EmailName;
        protected TextBox EmailPassword;
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
            string sql = string.Concat(new object[] { "insert into qp_oa_Emailprv   (EmailName,EmailAdd,EmailUserName,EmailPassword,Pop3,Smtp,ServerEmail,MainNet,Username) values ('", this.pulicss.GetFormatStr(this.EmailName.Text), "','", this.pulicss.GetFormatStr(this.EmailAdd.Text), "','", this.pulicss.GetFormatStr(this.EmailUserName.Text), "','", this.pulicss.GetFormatStr(this.EmailPassword.Text), "','", this.pulicss.GetFormatStr(this.Pop3.Text), "','", this.pulicss.GetFormatStr(this.Smtp.Text), "','是','','", this.Session["username"], "')" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增邮件参数[" + this.EmailName.Text + "]", "邮件参数设置");
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
                this.BindAttribute();
            }
        }
    }
}

