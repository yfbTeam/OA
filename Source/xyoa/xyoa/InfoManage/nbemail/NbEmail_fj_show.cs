namespace xyoa.InfoManage.nbemail
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class NbEmail_fj_show : Page
    {
        protected Label Content;
        protected HtmlForm form1;
        protected Label FsRealname;
        protected Label FsTime;
        protected Label fujian;
        protected HtmlHead Head1;
        protected Label JsRealname;
        private Db List = new Db();
        protected Label Number;
        private publics pulicss = new publics();
        protected Label Titles;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_NbEmail_fj where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (JsUsername='", this.Session["username"], "' or FsUsername='", this.Session["username"], "')" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.Titles.Text = list["Titles"].ToString();
                    this.Content.Text = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                    this.FsTime.Text = list["FsTime"].ToString();
                    this.JsRealname.Text = list["JsRealname"].ToString();
                    this.FsRealname.Text = list["FsRealname"].ToString();
                }
                list.Close();
                this.pulicss.GetFile(this.Number.Text, this.fujian);
                this.pulicss.InsertLog("查看邮件", "内部邮件");
            }
        }
    }
}

