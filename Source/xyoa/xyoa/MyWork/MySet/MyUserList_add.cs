namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyUserList_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected TextBox GlRealname;
        protected TextBox GlUsername;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Paixun;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.GlRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "insert into qp_oa_MyUserList (Name,GlUsername,GlRealname,Username,Paixun) values ('", this.pulicss.GetFormatStr(this.Name.Text), "','", this.GlUsername.Text, "','", this.pulicss.GetFormatStr(this.GlRealname.Text), "','", this.Session["Username"], "','", this.pulicss.GetFormatStr(this.Paixun.Text), "')" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增自定义用户组", "自定义用户组");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyUserList.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyUserList.aspx");
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

