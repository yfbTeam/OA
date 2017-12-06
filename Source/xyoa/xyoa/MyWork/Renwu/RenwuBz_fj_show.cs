namespace xyoa.MyWork.Renwu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class RenwuBz_fj_show : Page
    {
        protected Button Button2;
        protected Label Content;
        protected Label Endtime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox JbUsername;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label SetTime;
        protected Label Starttime;
        protected Label State;
        protected Label titles;
        protected TextBox ZbUsername;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:window.close();";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_RenwuFj  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.titles.Text = list["titles"].ToString();
                    this.Starttime.Text = DateTime.Parse(list["Starttime"].ToString()).ToShortDateString();
                    this.Endtime.Text = DateTime.Parse(list["Endtime"].ToString()).ToShortDateString();
                    this.State.Text = list["State"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.Content.Text = list["Content"].ToString();
                    this.SetTime.Text = list["SetTime"].ToString();
                }
                list.Close();
                this.pulicss.InsertLog("查看分解任务", "任务布置");
                this.BindAttribute();
            }
        }
    }
}

