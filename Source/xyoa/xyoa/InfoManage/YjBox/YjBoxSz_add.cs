namespace xyoa.InfoManage.YjBox
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YjBoxSz_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox Username;

        public void BindAttribute()
        {
            this.Realname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_YjBoxSz  (Name,Username,Realname) values ('" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + this.pulicss.GetFormatStr(this.Username.Text) + "','" + this.pulicss.GetFormatStr(this.Realname.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增意见箱", "意见箱维护");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='YjBoxSz.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("YjBoxSz.aspx");
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

