namespace xyoa.pda.MyWork.Richeng
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
        protected Button Button1;
        protected Label Content;
        protected Label EndTime;
        protected HtmlForm form1;
        protected Label fujian;
        protected Label Gongkai;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label StartTime;
        protected Label titles;
        protected Label XbRealname;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("RichenggkRi.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                string sql = "select * from qp_oa_MyRicheng  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Gongkai='是'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.titles.Text = list["titles"].ToString();
                    this.StartTime.Text = list["Starttime"].ToString();
                    this.EndTime.Text = list["Endtime"].ToString();
                    this.Content.Text = list["Content"].ToString();
                    this.Gongkai.Text = list["Gongkai"].ToString();
                    this.XbRealname.Text = list["XbRealname"].ToString();
                    list.Close();
                    this.pulicss.GetFileSj(this.Number.Text, this.fujian);
                }
                else
                {
                    list.Close();
                    base.Response.Write("<script language=javascript>alert('无相关信息！');window.location.href='RichenggkRi.aspx'</script>");
                }
            }
        }
    }
}

