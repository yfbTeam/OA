namespace xyoa.SchTable.Houqin.Sifang
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Sifang_show : Page
    {
        protected Label Beizhu;
        protected Label Buwei;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Qingkuan;
        protected Label Renyuan;
        protected Label Shijian;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Sifang where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Shijian.Text = list["Shijian"].ToString();
                    this.Buwei.Text = this.pulicss.TbToLb(list["Buwei"].ToString());
                    this.Qingkuan.Text = this.pulicss.TbToLb(list["Qingkuan"].ToString());
                    this.Renyuan.Text = this.pulicss.TbToLb(list["Renyuan"].ToString());
                    this.Beizhu.Text = this.pulicss.TbToLb(list["Beizhu"].ToString());
                }
                list.Close();
            }
        }
    }
}

