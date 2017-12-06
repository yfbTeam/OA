namespace xyoa.PublicWork.Tupian
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Tupian_show_show : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Image Image1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected Label PsDidian;
        protected Label PsShijian;
        private publics pulicss = new publics();
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
                string sql = "select * from qp_oa_TupianMg  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.PsShijian.Text = list["PsShijian"].ToString();
                    this.PsDidian.Text = list["PsDidian"].ToString();
                    this.TypeId.Text = this.pulicss.TypeCode("qp_oa_TupianLx", list["TypeId"].ToString());
                    this.Image1.ImageUrl = "/" + list["NewName"].ToString() + "";
                    this.YdRealname.Text = list["YdRealname"].ToString();
                }
                list.Close();
            }
        }
    }
}

