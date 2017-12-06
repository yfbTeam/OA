namespace xyoa.MyWork.MySet
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class OpenMenu : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected DropDownList UrlName;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_oa_OpenMenu where  Username='" + this.Session["username"] + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = string.Concat(new object[] { "Update qp_oa_OpenMenu  Set Url='", this.UrlName.SelectedValue, "'  where  Username='", this.Session["username"], "' " });
                this.List.ExeSql(str2);
            }
            else
            {
                string str3 = string.Concat(new object[] { "insert into qp_oa_OpenMenu  (Url,Username) values ('", this.UrlName.SelectedValue, "','", this.Session["username"], "') " });
                this.List.ExeSql(str3);
            }
            list.Close();
            this.pulicss.InsertLog("设置默认展开菜单", "默认展开菜单");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='OpenMenu.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select urlname,url from qp_oa_url where CHARINDEX(quanxian,'" + this.Session["perstr"] + "') > 0 order by paixu asc";
                this.list.Bind_DropDownList_nothing(this.UrlName, sQL, "url", "urlname");
                string sql = "select * from qp_oa_OpenMenu where  Username='" + this.Session["username"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.UrlName.SelectedValue = list["Url"].ToString();
                }
                else
                {
                    this.UrlName.SelectedValue = "Main.aspx";
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

