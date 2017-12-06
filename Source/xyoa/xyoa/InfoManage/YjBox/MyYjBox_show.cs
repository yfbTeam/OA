namespace xyoa.InfoManage.YjBox
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyYjBox_show : Page
    {
        protected Label BoxId;
        protected Button Button2;
        protected Label Content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label HfCotent;
        protected Label HfRealname;
        protected Label HfTimes;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label Titles;
        protected Label TxRealname;
        protected Label TxTime;
        protected Label YdRealname;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyYjBox.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_YjBox   where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.BoxId.Text = this.pulicss.TypeCode("qp_oa_YjBoxSz", list["BoxId"].ToString());
                    this.Titles.Text = list["Titles"].ToString();
                    this.Content.Text = this.pulicss.TbToLb(list["Content"].ToString());
                    this.TxRealname.Text = list["TxRealname"].ToString();
                    this.TxTime.Text = list["TxRealname"].ToString();
                    this.YdRealname.Text = list["YdRealname"].ToString();
                    this.HfCotent.Text = list["HfCotent"].ToString();
                    this.HfRealname.Text = list["HfRealname"].ToString();
                    this.HfTimes.Text = list["HfTimes"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

