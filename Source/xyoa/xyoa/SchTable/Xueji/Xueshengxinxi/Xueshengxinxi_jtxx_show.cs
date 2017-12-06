namespace xyoa.SchTable.Xueji.Xueshengxinxi
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xueshengxinxi_jtxx_show : Page
    {
        protected Label Danwei;
        protected Label Dianhua;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected Label Dizhi;
        protected Label DwDizhi;
        protected HtmlForm form1;
        protected Label Guanxi;
        protected HtmlHead Head1;
        protected Label Jilu;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label Techang;
        protected Label Xingming;
        protected Label Xinxiang;
        protected Label Xiuxiri;
        protected Label XsId;
        protected Label Yixiang;
        protected Label Youzheng;
        protected Label Zhiwu;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Stu_jtxx where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.XsId.Text = this.divsch.TypeCode("Xingming", "qp_sch_Xuesheng", list["XsId"].ToString());
                    this.Xingming.Text = list["Xingming"].ToString();
                    this.Guanxi.Text = list["Guanxi"].ToString();
                    this.Dianhua.Text = list["Dianhua"].ToString();
                    this.Youzheng.Text = list["Youzheng"].ToString();
                    this.Xinxiang.Text = list["Xinxiang"].ToString();
                    this.Dizhi.Text = list["Dizhi"].ToString();
                    this.Danwei.Text = list["Danwei"].ToString();
                    this.DwDizhi.Text = list["DwDizhi"].ToString();
                    this.Zhiwu.Text = list["Zhiwu"].ToString();
                    this.Xiuxiri.Text = list["Xiuxiri"].ToString();
                    this.Techang.Text = list["Techang"].ToString();
                    this.Yixiang.Text = list["Yixiang"].ToString();
                    this.Jilu.Text = list["Jilu"].ToString();
                }
                list.Close();
            }
        }
    }
}

