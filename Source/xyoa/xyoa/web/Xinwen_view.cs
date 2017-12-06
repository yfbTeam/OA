namespace xyoa.web
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class Xinwen_view : Page
    {
        public string content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected head Head2;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected right Right1;
        public string settime;
        protected tail Tail1;
        public string title;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_web_JiejiariDay where  (('" + DateTime.Now.ToShortDateString() + "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + DateTime.Now.ToShortDateString() + "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('" + DateTime.Now.ToShortDateString() + "' as datetime),120)) )";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["RightPic"] = "2";
                }
                else
                {
                    this.ViewState["RightPic"] = "1";
                }
                list.Close();
                string str2 = "select * from qp_web_Xinwen where id='" + int.Parse(this.pulicss.GetFormatStr(base.Request.QueryString["id"])) + "'";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.settime = reader2["Shijian"].ToString();
                    this.title = reader2["Titles"].ToString();
                    this.content = reader2["content"].ToString();
                }
                reader2.Close();
                this.ViewState["LeftName"] = "单位新闻";
                this.Right1.A_value = this.ViewState["LeftName"].ToString();
            }
        }
    }
}

