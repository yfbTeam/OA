namespace xyoa.SystemManage.anquan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ipmanage : Page
    {
        protected Button Button1;
        protected TextBox content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_ipmanage  Set content='" + this.content.Text + "'";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("设置登陆IP", "设置登陆IP");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='ipmanage.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_ipmanage";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.content.Text = list["content"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

