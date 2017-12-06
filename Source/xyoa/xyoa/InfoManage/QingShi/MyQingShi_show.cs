namespace xyoa.InfoManage.QingShi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyQingShi_show : Page
    {
        protected Button Button2;
        protected Label Contents;
        protected HtmlForm form1;
        protected Label fujian;
        protected HtmlHead Head1;
        protected Label JsRealname;
        protected TextBox JsUsername;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected Label Pizhu;
        private publics pulicss = new publics();
        protected Label PzTime;
        protected Label State;
        protected Label Titles;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyQingShi.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_QingShi  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["username"], "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.Titles.Text = list["Titles"].ToString();
                    this.Contents.Text = list["Content"].ToString();
                    this.JsUsername.Text = list["JsUsername"].ToString();
                    this.JsRealname.Text = list["JsRealname"].ToString();
                    this.State.Text = list["State"].ToString();
                    this.Pizhu.Text = list["Pizhu"].ToString();
                    this.PzTime.Text = list["PzTime"].ToString().Replace("1900-1-1 0:00:00", "未批阅").Replace("1900-01-01 00:00:00", "未批阅");
                }
                list.Close();
                this.pulicss.GetFile(this.Number.Text, this.fujian);
                this.BindAttribute();
            }
        }
    }
}

