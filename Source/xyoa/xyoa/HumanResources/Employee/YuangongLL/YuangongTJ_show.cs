namespace xyoa.HumanResources.Employee.YuangongLL
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongTJ_show : Page
    {
        protected Label Beizhu;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Jieguo;
        private Db List = new Db();
        protected Label Miaoshu;
        private publics pulicss = new publics();
        protected Label RealnameYG;
        protected Label Shijian;
        protected TextBox UsernameYG;
        protected Label Zhuti;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_hr_YuangongTJ  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.UsernameYG.Text = list["UsernameYG"].ToString();
                    this.RealnameYG.Text = list["RealnameYG"].ToString();
                    this.Jieguo.Text = this.divhr.TypeCode("Name", "qp_hr_YuangongLx", list["Jieguo"].ToString());
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Miaoshu.Text = this.pulicss.TbToLb(list["Miaoshu"].ToString());
                    this.Beizhu.Text = this.pulicss.TbToLb(list["Beizhu"].ToString());
                }
                list.Close();
            }
        }
    }
}

