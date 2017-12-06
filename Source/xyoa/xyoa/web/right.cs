namespace xyoa.web
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class right : UserControl
    {
        private string _A_value = string.Empty;
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                StateBag bag = ViewState;
                object obj2;
                string sql = "select * from qp_web_Biaoti";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Biaoti"] = list["Content"].ToString();
                }
                list.Close();
                string str2 = "select * from qp_web_JiejiariDay where  (('" + DateTime.Now.ToShortDateString() + "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + DateTime.Now.ToShortDateString() + "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('" + DateTime.Now.ToShortDateString() + "' as datetime),120)) )";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.ViewState["RightPic"] = "2";
                }
                else
                {
                    this.ViewState["RightPic"] = "1";
                }
                reader2.Close();
                this.ViewState["LeftUrl"] = "";
                string str3 = "select * from qp_web_LanmuLb order by Paixu asc";
                SqlDataReader reader3 = this.List.GetList(str3);
                while (reader3.Read())
                {
                    obj2 = bag["LeftUrl"];
                    (bag = this.ViewState)["LeftUrl"] = string.Concat(new object[] { obj2, " <tr><td align=\"center\" background=\"img/diandian.jpg\"><img src=\"img/ndian_", this.ViewState["RightPic"], ".jpg\" width=\"15\" height=\"14\"></td><td height=\"36\" background=\"img/diandian.jpg\"><a href=\"/web/Lanmu.aspx?Leibie=", reader3["id"], "\">", reader3["name"], "</a></td></tr>" });
                }
                reader3.Close();
                this.ViewState["ZtUrl"] = "";
                string str4 = "select * from qp_web_ZhuantiLb order by id desc";
                SqlDataReader reader4 = this.List.GetList(str4);
                while (reader4.Read())
                {
                    obj2 = bag["ZtUrl"];
                    (bag = this.ViewState)["ZtUrl"] = string.Concat(new object[] { obj2, " <tr><td align=\"center\" background=\"img/diandian.jpg\">&nbsp;</td><td height=\"36\" background=\"img/diandian.jpg\"> &nbsp;&nbsp;<strong>-</strong>&nbsp;&nbsp;<a href=\"/web/Zhuangti.aspx?Leibie=", reader4["id"], "\">", reader4["name"], "</a></td></tr>" });
                }
                reader4.Close();
                this.ViewState["XxUrl"] = "";
                string str5 = "select * from qp_web_YuandiLb order by id desc";
                SqlDataReader reader5 = this.List.GetList(str5);
                while (reader5.Read())
                {
                    obj2 = bag["XxUrl"];
                    (bag = this.ViewState)["XxUrl"] = string.Concat(new object[] { obj2, "<tr><td align=\"center\" background=\"img/diandian.jpg\">&nbsp;</td><td height=\"36\" background=\"img/diandian.jpg\"> &nbsp;&nbsp;<strong>-</strong>&nbsp;&nbsp;<a href=\"/web/Yuandi.aspx?Leibie=", reader5["id"], "\">", reader5["name"], "</a></td></tr>" });
                }
                reader5.Close();
                this.ViewState["str"] = this.A_value;
            }
        }

        public string A_value
        {
            get
            {
                return this._A_value;
            }
            set
            {
                this._A_value = value;
            }
        }
    }
}

