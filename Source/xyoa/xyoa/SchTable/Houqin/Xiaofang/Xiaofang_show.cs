namespace xyoa.SchTable.Houqin.Xiaofang
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xiaofang_show : Page
    {
        protected Label Baoyan;
        protected Label Beizhu;
        protected HtmlForm form1;
        protected Label GmShijian;
        protected Label Guanliren;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Miehuoqi;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label TbShijian;
        protected Label Weizhi;
        protected Label Xiaohuoshan;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Xiaofang where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Weizhi.Text = list["Weizhi"].ToString();
                    this.TbShijian.Text = list["TbShijian"].ToString();
                    this.GmShijian.Text = list["GmShijian"].ToString();
                    this.Miehuoqi.Text = list["Miehuoqi"].ToString();
                    this.Xiaohuoshan.Text = list["Xiaohuoshan"].ToString();
                    this.Guanliren.Text = list["Guanliren"].ToString();
                    this.Baoyan.Text = this.pulicss.TbToLb(list["Baoyan"].ToString());
                    this.Beizhu.Text = this.pulicss.TbToLb(list["Beizhu"].ToString());
                }
                list.Close();
            }
        }
    }
}

