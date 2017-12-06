namespace xyoa.HumanResources.Employee.YuangongJC
{
    using qiupeng.hr;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongJC_show : Page
    {
        protected Label Beizhu;
        private qiupeng.hr.divhr divhr = new qiupeng.hr.divhr();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label JianchengYy;
        protected Label JiangchengSj;
        protected Label Leibie;
        private Db List = new Db();
        protected Label Neirong;
        private publics pulicss = new publics();
        protected Label RealnameYG;
        protected TextBox UsernameYG;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.ViewState["Jiangcheng"] = base.Request.QueryString["Jiangcheng"].ToString().Replace("1", "奖励").Replace("2", "惩罚");
                string sql = "select * from qp_hr_YuangongJC  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.UsernameYG.Text = list["UsernameYG"].ToString();
                    this.RealnameYG.Text = list["RealnameYG"].ToString();
                    this.Leibie.Text = this.divhr.TypeCode("Name", "qp_hr_YuangongLx", list["Leibie"].ToString());
                    this.JiangchengSj.Text = list["JiangchengSj"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.JianchengYy.Text = this.pulicss.TbToLb(list["JianchengYy"].ToString());
                    this.Neirong.Text = this.pulicss.TbToLb(list["Neirong"].ToString());
                    this.Beizhu.Text = this.pulicss.TbToLb(list["Beizhu"].ToString());
                }
                list.Close();
            }
        }
    }
}

