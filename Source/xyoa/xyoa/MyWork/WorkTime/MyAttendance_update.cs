namespace xyoa.MyWork.WorkTime
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyAttendance_update : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected TextBox DiffTime;
        protected TextBox EndTime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected TextBox LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox StartTime;
        protected TextBox Subject;
        protected TextBox TDiffTime;

        public void BindAttribute()
        {
            this.Realname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_MyAttendance  Set  Subject='", this.pulicss.GetFormatStr(this.Subject.Text), "',StartTime='", this.pulicss.GetFormatStr(this.StartTime.Text), "',EndTime='", this.pulicss.GetFormatStr(this.EndTime.Text), "',DiffTime='", this.pulicss.GetFormatStr(this.DiffTime.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), "',NowTimes='", DateTime.Now.ToString(), "'  where id='", int.Parse(base.Request.QueryString["id"]), "' " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改" + this.ViewState["typename"] + "", "个人考勤");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "&Zhuangtai=4'</script>");
        }

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
                string sql = string.Concat(new object[] { "select * from qp_hr_MyAttendance  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "'  and Username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["DqNodeName"] = list["DqNodeName"].ToString();
                    this.ViewState["DqNodeId"] = list["DqNodeId"].ToString();
                    this.ViewState["FormId"] = list["FormId"].ToString();
                    this.Subject.Text = list["Subject"].ToString();
                    this.StartTime.Text = list["StartTime"].ToString();
                    this.EndTime.Text = list["EndTime"].ToString();
                    this.DiffTime.Text = list["DiffTime"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                    this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                    if ((list["LcZhuangtai"].ToString() == "1") || (list["LcZhuangtai"].ToString() == "4"))
                    {
                        this.Button1.Visible = true;
                    }
                    else
                    {
                        this.Label1.Text = "当前状态不允许修改";
                    }
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('无相关数据！');window.location.href='MyAttendance.aspx?type=" + base.Request.QueryString["type"].ToString() + "&Zhuangtai=4'</script>");
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

