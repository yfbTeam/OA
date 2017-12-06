namespace xyoa.MyWork.Richeng
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Richenggk_show : Page
    {
        protected Label Content;
        protected Label EndTime;
        public string fjkey;
        protected HtmlForm form1;
        protected Label fujian;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label StartTime;
        protected Label titles;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_MyRicheng  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Gongkai='是' ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.titles.Text = list["titles"].ToString();
                    this.StartTime.Text = list["Starttime"].ToString();
                    this.EndTime.Text = list["Endtime"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.Content.Text = list["Content"].ToString();
                }
                list.Close();
                this.pulicss.GetFile(this.Number.Text, this.fujian);
            }
        }
    }
}

