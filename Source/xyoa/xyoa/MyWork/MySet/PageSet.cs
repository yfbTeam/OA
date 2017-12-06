namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class PageSet : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected DropDownList Name;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_yangshi  Set Name='", this.Name.SelectedValue, "'  where  Username='", this.Session["username"], "' " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("设置界面主题", "界面主题");
            this.Session["yangshi"] = this.pulicss.Getyangshi();
            base.Response.Write("<script language=javascript>alert('提交成功，你可以刷新页面浏览效果！');window.location.href='PageSet.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_yangshi where  Username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.SelectedValue = list["Name"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

