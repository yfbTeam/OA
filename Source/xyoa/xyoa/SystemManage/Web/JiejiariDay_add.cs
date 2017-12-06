namespace xyoa.SystemManage.Web
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class JiejiariDay_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected TextBox EndTime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Leixing;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox StartTime;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_web_JiejiariDay (StartTime,EndTime,Leixing) values ('" + this.pulicss.GetFormatStr(this.StartTime.Text) + "','" + this.pulicss.GetFormatStr(this.EndTime.Text) + "','" + this.Leixing.SelectedValue + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增节假日设置", "门户网站设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='JiejiariDay.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("JiejiariDay.aspx");
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

