namespace xyoa
{
    using qiupeng.crm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class CountMessageTx : Page
    {
        private qiupeng.crm.divcrm divcrm = new qiupeng.crm.divcrm();
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_username Set lasttime='", DateTime.Now.ToString(), "',onlinetime=onlinetime+10  where username='", this.Session["userName"], "'" });
            this.List.ExeSql(sql);
            string str2 = "select * from qp_oa_Naozhong where username='" + this.Session["userName"] + "' and Iftx='0'  order by id desc";
            SqlDataReader list = this.List.GetList(str2);
            while (list.Read())
            {
                DateTime time;
                DateTime time2;
                TimeSpan span;
                if (list["Types"].ToString() == "2")
                {
                    time = Convert.ToDateTime(DateTime.Parse(list["txtime"].ToString()));
                    time2 = Convert.ToDateTime(DateTime.Now.ToString());
                    span = (TimeSpan) (time - time2);
                    if ((double.Parse(span.TotalMinutes.ToString()) <= 2.0) && (double.Parse(span.TotalMinutes.ToString()) > -15.0))
                    {
                        if (list["NbSms"].ToString() == "1")
                        {
                            this.pulicss.InsertMessage("电子闹钟：" + list["titles"].ToString() + "", this.Session["username"].ToString(), this.Session["realname"].ToString(), list["LjUrl"].ToString());
                        }
                        if (list["SjSms"].ToString() == "1")
                        {
                            this.pulicss.InsertSms(this.Session["MoveTel"].ToString(), "电子闹钟：" + list["titles"].ToString() + "");
                        }
                        string str3 = "Update qp_oa_Naozhong Set Iftx='1' where id='" + list["id"].ToString() + "'";
                        this.List.ExeSql(str3);
                    }
                }
                else
                {
                    string str4 = "select * from qp_oa_NaozhongRz where Dyid='" + list["id"].ToString() + "' and convert(char(10),cast(Settime as datetime),120)=convert(char(10),cast('" + DateTime.Now.ToShortDateString() + "' as datetime),120)  ";
                    SqlDataReader reader2 = this.List.GetList(str4);
                    if (!reader2.Read())
                    {
                        time = Convert.ToDateTime("" + DateTime.Parse(list["txtime"].ToString()).Hour.ToString() + ":" + DateTime.Parse(list["txtime"].ToString()).Minute.ToString() + "");
                        time2 = Convert.ToDateTime("" + DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + "");
                        span = (TimeSpan) (time - time2);
                        if ((double.Parse(span.TotalMinutes.ToString()) <= 2.0) && (double.Parse(span.TotalMinutes.ToString()) > -15.0))
                        {
                            if (list["NbSms"].ToString() == "1")
                            {
                                this.pulicss.InsertMessage("电子闹钟：" + list["titles"].ToString() + "", this.Session["username"].ToString(), this.Session["realname"].ToString(), list["LjUrl"].ToString());
                            }
                            if (list["SjSms"].ToString() == "1")
                            {
                                this.pulicss.InsertSms(this.Session["MoveTel"].ToString(), "电子闹钟：" + list["titles"].ToString() + "");
                            }
                            string str5 = "insert into qp_oa_NaozhongRz  (Dyid,Settime) values ('" + list["id"].ToString() + "','" + DateTime.Now.ToShortDateString() + "')";
                            this.List.ExeSql(str5);
                        }
                    }
                    reader2.Close();
                }
            }
            list.Close();
            list.Dispose();
        }
    }
}

