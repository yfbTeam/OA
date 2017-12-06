namespace xyoa.SchTable.Houqin.Yinhuan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Yinhuan_show : Page
    {
        protected Label Didian;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Renyuan;
        protected Label Shijian;
        protected Label Zuzhizhe;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Yinhuan where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Zuzhizhe.Text = list["Zuzhizhe"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString();
                    this.Renyuan.Text = this.pulicss.TbToLb(list["Renyuan"].ToString());
                    this.Neirong.Text = this.pulicss.TbToLb(list["Neirong"].ToString());
                    this.Didian.Text = list["Didian"].ToString();
                }
                list.Close();
            }
        }
    }
}

