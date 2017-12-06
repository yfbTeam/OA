namespace xyoa.SchTable.JiaoShi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Beike_show : Page
    {
        protected Label Content;
        public string fjkey;
        protected HtmlForm form1;
        protected Label fujian;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label titles;
        protected Label Xueduan;
        protected Label Xueqi;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_sch_Beike  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["Username"], "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.titles.Text = list["titles"].ToString();
                    this.Content.Text = this.pulicss.TbToLb(list["Content"].ToString());
                    this.Xueduan.Text = list["Xueduan"].ToString();
                    this.Xueqi.Text = list["Xueqi"].ToString();
                }
                list.Close();
                this.pulicss.GetFile(this.Number.Text, this.fujian);
            }
        }
    }
}

