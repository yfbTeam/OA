namespace xyoa.HumanResources.Employee.YuangongLL
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyAttendance_show : Page
    {
        protected Label Beizhu;
        protected Label DiffTime;
        protected Label EndTime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label NowTimes;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label SpRealname;
        protected Label SpRemark;
        protected Label StartTime;
        protected Label Subject;
        protected TextBox TDiffTime;
        protected Label Zhuangtai;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                if (base.Request.QueryString["type"].ToString() == "1")
                {
                    this.ViewState["typename"] = "出差管理";
                    this.ViewState["diffname"] = "出差天数";
                    this.TDiffTime.Text = "出差天数";
                }
                if (base.Request.QueryString["type"].ToString() == "2")
                {
                    this.ViewState["typename"] = "休假管理";
                    this.ViewState["diffname"] = "休假天数";
                    this.TDiffTime.Text = "休假天数";
                }
                if (base.Request.QueryString["type"].ToString() == "3")
                {
                    this.ViewState["typename"] = "加班管理";
                    this.ViewState["diffname"] = "加班小时";
                    this.TDiffTime.Text = "加班小时";
                }
                string sql = "select * from qp_hr_MyAttendance  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Subject.Text = list["Subject"].ToString();
                    this.StartTime.Text = list["StartTime"].ToString();
                    this.EndTime.Text = list["EndTime"].ToString();
                    this.DiffTime.Text = list["DiffTime"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.Beizhu.Text = this.pulicss.TbToLb(list["Beizhu"].ToString());
                    this.SpRemark.Text = list["SpRemark"].ToString();
                    this.Zhuangtai.Text = list["Zhuangtai"].ToString().Replace("1", "正在审批").Replace("2", "通过审批").Replace("3", "拒绝审批").Replace("4", "等待审批");
                    this.NowTimes.Text = list["NowTimes"].ToString();
                    this.SpRealname.Text = list["SpRealname"].ToString();
                }
                list.Close();
            }
        }
    }
}

