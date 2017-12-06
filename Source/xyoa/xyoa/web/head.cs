namespace xyoa.web
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class head : UserControl
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_web_JiejiariDay where  (('" + DateTime.Now.ToShortDateString() + "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + DateTime.Now.ToShortDateString() + "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('" + DateTime.Now.ToShortDateString() + "' as datetime),120)) )";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = "select * from qp_web_Jiejiari";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        if (list["Leixing"].ToString() == "1")
                        {
                            this.ViewState["Dingbu"] = reader2["Yuandan"].ToString();
                        }
                        if (list["Leixing"].ToString() == "2")
                        {
                            this.ViewState["Dingbu"] = reader2["Chunjie"].ToString();
                        }
                        if (list["Leixing"].ToString() == "3")
                        {
                            this.ViewState["Dingbu"] = reader2["Wuyi"].ToString();
                        }
                        if (list["Leixing"].ToString() == "4")
                        {
                            this.ViewState["Dingbu"] = reader2["Qiyi"].ToString();
                        }
                        if (list["Leixing"].ToString() == "5")
                        {
                            this.ViewState["Dingbu"] = reader2["Shiyi"].ToString();
                        }
                    }
                    reader2.Close();
                }
                else
                {
                    string str3 = "select * from qp_web_Dingbu";
                    SqlDataReader reader3 = this.List.GetList(str3);
                    if (reader3.Read())
                    {
                        this.ViewState["Dingbu"] = reader3["Content"].ToString();
                    }
                    reader3.Close();
                }
                list.Close();
            }
        }
    }
}

