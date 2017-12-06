namespace xyoa
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class main_d_update : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox LookMuch;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_DIYMould  Set LookMuch='", this.pulicss.GetFormatStr(this.LookMuch.Text), "'  where Username='", this.Session["username"], "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改桌面模块", "桌面模块");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.href='main_d.aspx';window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select top 1 * from qp_oa_DIYMould where Username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.LookMuch.Text = list["LookMuch"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

