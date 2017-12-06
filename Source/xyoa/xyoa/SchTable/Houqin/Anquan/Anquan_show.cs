namespace xyoa.SchTable.Houqin.Anquan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Anquan_show : Page
    {
        protected Label Canyu;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Miaosu;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Shijian;
        protected Label Zhuti;
        protected Label Zuzhizhe;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Anquan where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Zuzhizhe.Text = list["Zuzhizhe"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString();
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Canyu.Text = this.pulicss.TbToLb(list["Canyu"].ToString());
                    this.Miaosu.Text = this.pulicss.TbToLb(list["Miaosu"].ToString());
                }
                list.Close();
            }
        }
    }
}

