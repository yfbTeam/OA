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

    public class Xueshengxinxi_tjxx_show : Page
    {
        protected Label Bibing;
        protected Label Danbai;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected Label Fei;
        protected Label Feiheliang;
        protected HtmlForm form1;
        protected Label Ganzang;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Meibo;
        protected Label Pingjia;
        private publics pulicss = new publics();
        protected Label Qita;
        protected Label Sejue;
        protected Label Shayan1;
        protected Label Shayan2;
        protected Label Shengao;
        protected Label Shijian;
        protected Label Shili1;
        protected Label Shili2;
        protected Label Tizhong;
        protected Label Xinzang;
        protected Label Xiongwei;
        protected Label XsId;
        protected Label Xueduan;
        protected Label Xueqi;
        protected Label Xueya;
        protected Label Zhichi;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Stu_tjxx where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.XsId.Text = this.divsch.TypeCode("Xingming", "qp_sch_Xuesheng", list["XsId"].ToString());
                    this.Xueqi.Text = list["Xueqi"].ToString();
                    this.Xueduan.Text = list["Xueduan"].ToString();
                    this.Pingjia.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", list["Pingjia"].ToString());
                    this.Shijian.Text = list["Shijian"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Shengao.Text = list["Shengao"].ToString();
                    this.Tizhong.Text = list["Tizhong"].ToString();
                    this.Xiongwei.Text = list["Xiongwei"].ToString();
                    this.Feiheliang.Text = list["Feiheliang"].ToString();
                    this.Xueya.Text = list["Xueya"].ToString();
                    this.Meibo.Text = list["Meibo"].ToString();
                    this.Shili1.Text = list["Shili1"].ToString();
                    this.Shili2.Text = list["Shili2"].ToString();
                    this.Shayan1.Text = list["Shayan1"].ToString();
                    this.Shayan2.Text = list["Shayan2"].ToString();
                    this.Sejue.Text = list["Sejue"].ToString();
                    this.Bibing.Text = list["Bibing"].ToString();
                    this.Zhichi.Text = list["Zhichi"].ToString();
                    this.Xinzang.Text = list["Xinzang"].ToString();
                    this.Fei.Text = list["Fei"].ToString();
                    this.Ganzang.Text = list["Ganzang"].ToString();
                    this.Danbai.Text = list["Danbai"].ToString();
                    this.Qita.Text = list["Qita"].ToString();
                }
                list.Close();
            }
        }
    }
}

