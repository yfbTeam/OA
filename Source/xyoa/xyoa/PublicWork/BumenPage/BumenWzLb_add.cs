namespace xyoa.PublicWork.BumenPage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BumenWzLb_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Leixing;
        private Db List = new Db();
        protected TextBox paixun;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_BumenWzLb (LeibieId,Leixing,paixun) values ('" + this.pulicss.GetFormatStr(base.Request.QueryString["LeibieId"]) + "','" + this.pulicss.GetFormatStr(this.Leixing.Text) + "','" + this.pulicss.GetFormatStr(this.paixun.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增文章类别[" + this.pulicss.GetFormatStr(this.Leixing.Text) + "]", "部门主页");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='BumenWzLb.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["LeibieId"]) + "'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("BumenWzLb.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["LeibieId"]) + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
            }
        }
    }
}

