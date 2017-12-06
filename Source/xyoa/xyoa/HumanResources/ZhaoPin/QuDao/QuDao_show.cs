namespace xyoa.HumanResources.ZhaoPin.QuDao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class QuDao_show : Page
    {
        protected Label Beizhu;
        protected Label Chengshi;
        protected Label Dianhua;
        protected Label Dizhi;
        protected Label Email;
        protected HtmlForm form1;
        protected Label Fuzeren;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Mingcheng;
        private publics pulicss = new publics();
        protected Label Youbian;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_hr_QuDao where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Mingcheng.Text = list["Mingcheng"].ToString();
                    this.Fuzeren.Text = list["Fuzeren"].ToString();
                    this.Dianhua.Text = list["Dianhua"].ToString();
                    this.Email.Text = list["Email"].ToString();
                    this.Chengshi.Text = list["Chengshi"].ToString();
                    this.Youbian.Text = list["Youbian"].ToString();
                    this.Dizhi.Text = list["Dizhi"].ToString();
                    this.Beizhu.Text = this.pulicss.TbToLb(list["Beizhu"].ToString());
                }
                list.Close();
            }
        }
    }
}

