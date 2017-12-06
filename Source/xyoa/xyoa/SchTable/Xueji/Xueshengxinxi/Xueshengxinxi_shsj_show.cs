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

    public class Xueshengxinxi_shsj_show : Page
    {
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected Label Dizhi;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Miaoshu;
        private publics pulicss = new publics();
        protected Label Shijian;
        protected Label Xiangmu;
        protected Label XsId;
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
                string sql = "select * from qp_sch_Stu_shsj where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.XsId.Text = this.divsch.TypeCode("Xingming", "qp_sch_Xuesheng", list["XsId"].ToString());
                    this.Xueqi.Text = list["Xueqi"].ToString();
                    this.Xueduan.Text = list["Xueduan"].ToString();
                    this.Xiangmu.Text = list["Xiangmu"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Dizhi.Text = list["Dizhi"].ToString();
                    this.Miaoshu.Text = this.pulicss.TbToLb(list["Miaoshu"].ToString());
                }
                list.Close();
            }
        }
    }
}

