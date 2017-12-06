namespace xyoa.MyWork.Quxiang
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Quxian_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Nowtimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "insert into qp_oa_Quxian  (Zhuti,Username,Realname,Nowtimes) values ('", this.pulicss.GetFormatStr(this.Zhuti.Text), "','", this.Session["username"], "','", this.Session["realname"], "','", this.Nowtimes.Text, "')" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增我的去向", "人员去向");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyQuxiang.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyQuxiang.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Nowtimes.Text = DateTime.Now.ToString();
                this.BindAttribute();
            }
        }
    }
}

