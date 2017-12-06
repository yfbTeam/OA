namespace xyoa.HumanResources.KaoPing.KaoPingMg
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class KaoPingMg_show : Page
    {
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected Label Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label LeixingID;
        private Db List = new Db();
        protected Label Miaoshu;
        private publics pulicss = new publics();
        protected Label RealnameCy;
        protected Label Starttime;
        protected TextBox UsernameCy;
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
                string sql = "select * from qp_hr_KaoPingMg where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.LeixingID.Text = this.divhr.TypeCode("Leixing", "qp_hr_KaoPingSz", list["LeixingID"].ToString());
                    this.UsernameCy.Text = list["UsernameCy"].ToString();
                    this.RealnameCy.Text = list["RealnameCy"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.Miaoshu.Text = this.pulicss.TbToLb(list["Miaoshu"].ToString());
                    this.Zhuangtai.Text = list["Zhuangtai"].ToString().Replace("1", "正常").Replace("2", "停用");
                }
                list.Close();
                this.pulicss.QuanXianBack("eeee6fb", this.Session["perstr"].ToString());
            }
        }
    }
}

