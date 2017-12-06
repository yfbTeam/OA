namespace xyoa.pda.InfoManage.nbemail
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class NbEmail_sj_show : Page
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
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Number;
        private publics pulicss = new publics();
        protected Label Titles;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("NbEmail_sj.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            base.Response.Redirect("NbEmail_add.aspx?FsUsername=" + this.FsUsername.Text + "&FsRealname=" + this.FsRealname.Text + "&backid=" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "");
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
                string sql = string.Concat(new object[] { "select * from qp_oa_NbEmail_sj where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (JsUsername='", this.Session["username"], "')" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.Titles.Text = list["Titles"].ToString();
                    this.Content.Text = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                    this.FsTime.Text = list["FsTime"].ToString();
                    this.FsRealname.Text = list["FsRealname"].ToString();
                    this.FsUsername.Text = list["FsUsername"].ToString();
                    if (list["IfRead"].ToString() != "True")
                    {
                        string str2 = "Update qp_oa_NbEmail_fj Set JsRealname=replace(JsRealname,'," + this.Session["realname"].ToString() + ",',',<font color=\"blue\">" + this.Session["realname"].ToString() + "(" + DateTime.Now.ToString() + ")</font>,')  where  Number='" + this.Number.Text + "'";
                        this.List.ExeSql(str2);
                    }
                    string str3 = "select * from qp_oa_NbEmail_fj where Number='" + this.Number.Text + "'";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    if (reader2.Read())
                    {
                        this.JsRealname.Text = reader2["JsRealname"].ToString();
                    }
                    reader2.Close();
                    string str4 = string.Concat(new object[] { "Update qp_oa_NbEmail_sj Set IfRead='1'  where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (JsUsername='", this.Session["username"], "' or FsUsername='", this.Session["username"], "')" });
                    this.List.ExeSql(str4);
                }
                list.Close();
                this.pulicss.GetFileSj(this.Number.Text, this.fujian);
            }
        }
    }
}

