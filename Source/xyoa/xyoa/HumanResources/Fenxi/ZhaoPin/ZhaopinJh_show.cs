namespace xyoa.HumanResources.Fenxi.ZhaoPin
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ZhaopinJh_show : Page
    {
        protected Label Bumen;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Neirong;
        private publics pulicss = new publics();
        protected Label Qixian;
        protected Label Renshu;
        protected Label SetTimes;
        protected Label SpRealname;
        protected Label SpRemark;
        protected Label Zhiwei;
        protected Label Zhuangtai;
        protected Label Zhuti;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("eeee8", this.Session["perstr"].ToString());
                string sql = "select * from qp_hr_ZhaopinJh where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Bumen.Text = this.pulicss.TypeCode("qp_oa_Bumen", list["Bumen"].ToString());
                    this.Zhiwei.Text = this.pulicss.TypeCode("qp_oa_Zhiwei", list["Zhiwei"].ToString());
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Renshu.Text = list["Renshu"].ToString();
                    this.Qixian.Text = DateTime.Parse(list["Qixian"].ToString()).ToShortDateString();
                    this.Neirong.Text = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                    this.SpRemark.Text = list["SpRemark"].ToString();
                    this.Zhuangtai.Text = list["Zhuangtai"].ToString().Replace("1", "正在审批").Replace("2", "通过审批").Replace("3", "拒绝审批").Replace("4", "等待审批");
                    this.SetTimes.Text = list["SetTimes"].ToString();
                    this.SpRealname.Text = list["SpRealname"].ToString();
                }
                list.Close();
            }
        }
    }
}

