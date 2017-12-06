namespace xyoa.pda.InfoManage.nbemail
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
        protected Button Button1;
        protected Label Content;
        protected HtmlForm form1;
        protected Label FsRealname;
        protected Label FsTime;
        protected Label FsUsername;
        protected Label fujian;
        protected HtmlHead Head1;
        protected ImageButton ImageButton1;
        protected Label JsRealname;
        protected Label JsUsername;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Number;
        private publics pulicss = new publics();
        protected Label Titles;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("NbEmail_fj.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            base.Response.Redirect("NbEmail_add.aspx?FsUsername=" + this.JsUsername.Text + "&FsRealname=" + this.JsRealname.Text + "&backid=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.ImageButton1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                string sql = string.Concat(new object[] { "select * from qp_oa_NbEmail_fj where   id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (JsUsername='", this.Session["username"], "' or FsUsername='", this.Session["username"], "')" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.Titles.Text = list["Titles"].ToString();
                    this.Content.Text = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                    this.FsTime.Text = list["FsTime"].ToString();
                    this.FsRealname.Text = list["FsRealname"].ToString();
                    this.FsUsername.Text = list["FsUsername"].ToString();
                    this.JsRealname.Text = list["JsRealname"].ToString();
                    this.JsUsername.Text = list["JsUsername"].ToString();
                }
                list.Close();
                this.pulicss.GetFileSj(this.Number.Text, this.fujian);
            }
        }
    }
}

