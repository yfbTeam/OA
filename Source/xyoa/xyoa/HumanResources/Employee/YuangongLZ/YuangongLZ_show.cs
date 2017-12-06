namespace xyoa.HumanResources.Employee.YuangongLZ
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongLZ_show : Page
    {
        protected Label Beizhu;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Leixing;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label Quxiang;
        protected Label RealnameYG;
        protected Label Riqi;
        protected TextBox UsernameYG;
        protected Label Yuanying;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("eeee4fb", this.Session["perstr"].ToString());
                string sql = "select * from qp_hr_YuangongLZ  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.UsernameYG.Text = list["UsernameYG"].ToString();
                    this.RealnameYG.Text = list["RealnameYG"].ToString();
                    this.Riqi.Text = list["Riqi"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Leixing.Text = this.divhr.TypeCode("Name", "qp_hr_YuangongLx", list["Leixing"].ToString());
                    this.Quxiang.Text = this.pulicss.TbToLb(list["Quxiang"].ToString());
                    this.Yuanying.Text = this.pulicss.TbToLb(list["Yuanying"].ToString());
                    this.Beizhu.Text = this.pulicss.TbToLb(list["Beizhu"].ToString());
                }
                list.Close();
            }
        }
    }
}

