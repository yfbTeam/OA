namespace xyoa.HumanResources.Hetong.HetongLb
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongLb_add : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Mingcheng;
        protected TextBox Number;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_hr_HetongLb  (Mingcheng) values ('" + this.pulicss.GetFormatStr(this.Mingcheng.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增合同类别", "合同类别");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='HetongLb.aspx'</script>");
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

