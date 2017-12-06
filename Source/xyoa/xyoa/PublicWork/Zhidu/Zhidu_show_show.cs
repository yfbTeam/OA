namespace xyoa.PublicWork.Zhidu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Zhidu_show_show : Page
    {
        protected Label Contents;
        protected HtmlForm form1;
        protected Label fujian;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label Settime;
        protected Label Titles;
        protected Label TypeId;
        protected Label YdRealname;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_ZhiduMg  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.Titles.Text = list["Titles"].ToString();
                    this.TypeId.Text = this.pulicss.TypeCode("qp_oa_ZhiduLx", list["TypeId"].ToString());
                    this.Contents.Text = list["Content"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.Settime.Text = list["Settime"].ToString();
                    this.YdRealname.Text = list["YdRealname"].ToString();
                }
                list.Close();
                this.pulicss.GetFile(this.Number.Text, this.fujian);
                this.pulicss.InsertLog("查看规章制度", "规章制度");
            }
        }
    }
}

