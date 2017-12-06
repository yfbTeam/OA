namespace xyoa.PublicWork.Hetong
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongSz_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox RyRealname;
        protected TextBox RyUsername;
        protected TextBox ZgRealname;
        protected TextBox ZgUsername;

        public void BindAttribute()
        {
            this.ZgRealname.Attributes.Add("readonly", "readonly");
            this.RyRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_HetongSz  Set RyUsername='", this.pulicss.GetFormatStr(this.RyUsername.Text), "',RyRealname='", this.pulicss.GetFormatStr(this.RyRealname.Text), "'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改合同监控设置", "合同监控设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='HetongSz.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("HetongSz.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_HetongSz  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ZgRealname.Text = list["ZgRealname"].ToString();
                    this.RyUsername.Text = list["RyUsername"].ToString();
                    this.RyRealname.Text = list["RyRealname"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

