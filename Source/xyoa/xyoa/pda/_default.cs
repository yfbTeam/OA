namespace xyoa.pda
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class _default : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected Label Label1;
        private Db List = new Db();
        protected TextBox Password;
        private publics pulicss = new publics();
        protected TextBox Username;

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!this.pulicss.ipquanstr(HttpContext.Current.Request.UserHostAddress, this.ViewState["ipcontent"].ToString()))
            {
                this.Label1.Text = "您当前的IP为" + HttpContext.Current.Request.UserHostAddress + "，不允许登陆！请联系系统管理员";
            }
         //   string sql = "select reg from qp_oa_filemain ";
         //   SqlDataReader reader = this.List.GetList(sql);
         //   if (reader.Read())
            {
           //     if (reader["reg"].ToString() == "3")
                {
           //         this.Label1.Text = "经检测您的版本已经过期，请联系软件供应商重新注册！";
                }
           //     if (reader["reg"].ToString() == "10")
                {
           //         this.Label1.Text = "经检测您正在使用盗版软件，有可能对您公司的信息进行危害，请联系正版软件供应商！";
                }
            //    if (reader["reg"].ToString() == "0")
                {
            //        string str2 = this.pulicss.DESEncrypt("感谢您的试用^" + this.pulicss.GetMAC() + "^" + DateTime.Now.AddDays(30.0).ToShortDateString() + "^300^试用版^4^1^1^1^" + DateTime.Now.ToShortDateString() + "^1,2,3,4,5,6,7,8,9,10,11,16,0", "5", "6");
            //        string str3 = "Update qp_oa_filemain set cdkstr='" + str2 + "',reg='1'";
           //         this.List.ExeSql(str3);
                }
            }
         //   reader.Close();
            this.pulicss.setCookie("LoginName", this.Username.Text, 0x16d);
            string str4 = FormsAuthentication.HashPasswordForStoringInConfigFile(this.Password.Text, "MD5");
            string str5 = "select Username,Password,Iflogin,Realname,BuMenId,ResponQx,MoveTel,Zhiweiid,JueseId,guanzhu from qp_oa_username where Username='" + this.pulicss.GetFormatStr(this.Username.Text) + "' and Password='" + str4 + "' and Iflogin='1' and StardType='1' and ifdel='0'";
            SqlDataReader reader2 = this.List.GetList(str5);
            if (reader2.Read())
            {
                this.Session["Username"] = reader2["Username"].ToString();
                this.Session["Realname"] = reader2["Realname"].ToString();
                this.Session["Zhiweiid"] = reader2["Zhiweiid"].ToString();
                this.Session["JueseId"] = reader2["JueseId"].ToString();
                this.Session["BuMenId"] = reader2["BuMenId"].ToString();
                this.Session["perstr"] = reader2["ResponQx"].ToString();
                this.Session["MoveTel"] = reader2["MoveTel"].ToString();
                string str6 = null;
                string str7 = null;
                str7 = "" + reader2["guanzhu"].ToString() + "";
                ArrayList list = new ArrayList();
                string[] strArray = str7.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    str6 = str6 + "'" + strArray[i] + "',";
                }
                str6 = str6 + "'0'";
                string str8 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str6 + ") ";
                SqlDataReader reader3 = this.List.GetList(str8);
                while (reader3.Read())
                {
                    this.pulicss.InsertMessage("" + this.Session["Realname"] + "已上线！", reader3["username"].ToString(), reader3["realname"].ToString(), "#");
                }
                reader3.Close();
                this.pulicss.InsertLog("登陆系统[" + this.Session["realname"] + "]", "登陆系统");
                reader2.Close();
                base.Response.Redirect("main.aspx?leixing=1");
            }
            else
            {
                this.Label1.Text = "登陆失败!(1)请检查用户名,密码是否正确(2)确认帐号未被禁用(3)确认员工是否在职";
            }
            reader2.Close();
        }

        private string GetWeekDay()
        {
            switch (DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    return "星期日";

                case DayOfWeek.Monday:
                    return "星期一";

                case DayOfWeek.Tuesday:
                    return "星期二";

                case DayOfWeek.Wednesday:
                    return "星期三";

                case DayOfWeek.Thursday:
                    return "星期四";

                case DayOfWeek.Friday:
                    return "星期五";

                case DayOfWeek.Saturday:
                    return "星期六";
            }
            return "";
        }

        public void KaoQin()
        {
            string sql = "select * from qp_WorkTimeQy  where qiyong=1";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2 = "select * from qp_WorkTimeDj  where convert(varchar(10),Djtime,121)=convert(char(10),'" + DateTime.Now.ToShortDateString() + "',120)";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (!reader2.Read())
                {
                    string str3 = "select username,realname from qp_oa_username where  1=1 and ifdel='0' and StardType='1' and Iflogin='1'";
                    SqlDataReader reader3 = this.List.GetList(str3);
                    while (reader3.Read())
                    {
                        string str4 = "";
                        string str5 = "";
                        string str6 = "";
                        string str7 = "";
                        string str8 = "";
                        string str9 = "";
                        string str10 = "";
                        string str11 = "select * from qp_WorkTime   where QyType='启用'   and  (CHARINDEX('," + reader3["username"] + ",',','+SyUsername+',')   >   0 ) ";
                        SqlDataReader reader4 = this.List.GetList(str11);
                        if (reader4.Read() && (!this.pulicss.scquanstr(this.GetWeekDay(), reader4["Xingqi"].ToString()) && !this.pulicss.scquanstr(DateTime.Now.ToShortDateString(), reader4["Riqi"].ToString())))
                        {
                            str10 = reader4["PbType"].ToString();
                            if (reader4["DjType_1"].ToString() != "未启用")
                            {
                                str4 = "未考勤";
                            }
                            if (reader4["DjType_2"].ToString() != "未启用")
                            {
                                str5 = "未考勤";
                            }
                            if (reader4["DjType_3"].ToString() != "未启用")
                            {
                                str6 = "未考勤";
                            }
                            if (reader4["DjType_4"].ToString() != "未启用")
                            {
                                str7 = "未考勤";
                            }
                            if (reader4["DjType_5"].ToString() != "未启用")
                            {
                                str8 = "未考勤";
                            }
                            if (reader4["DjType_6"].ToString() != "未启用")
                            {
                                str9 = "未考勤";
                            }
                            string str12 = string.Concat(new object[] { 
                                "insert into qp_WorkTimeDj  values( '", str10, "','", reader4["DjType_1"].ToString(), "','0:0:0','", str4, "','", reader4["DjType_2"].ToString(), "','0:0:0','", str5, "','", reader4["DjType_3"].ToString(), "','0:0:0','", str6, "','", reader4["DjType_4"].ToString(), 
                                "','0:0:0','", str7, "','", reader4["DjType_5"].ToString(), "','0:0:0','", str8, "','", reader4["DjType_6"].ToString(), "','0:0:0','", str9, "','", DateTime.Now.ToShortDateString(), "','", DateTime.Now.ToShortDateString(), " 0:0:0','", reader3["Username"], 
                                "','", reader3["Realname"], "')"
                             });
                            this.List.ExeSql(str12);
                            string str13 = "insert into qp_oa_Messages  (titles,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number) values ('请注意考勤登记','" + DateTime.Now.ToString() + "','" + reader3["username"].ToString() + "','" + reader3["realname"].ToString() + "','系统消息','系统消息','0','/MyWork/WorkTime/WorkTime.aspx','" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "')";
                            this.List.ExeSql(str13);
                        }
                        reader4.Close();
                    }
                    reader3.Close();
                }
                reader2.Close();
            }
            list.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string sql = "select * from qp_oa_ipmanage";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["ipcontent"] = list["content"].ToString();
                }
                else
                {
                    this.ViewState["ipcontent"] = "*";
                }
                list.Close();
                string str2 = "select Titles from qp_oa_FaceMade";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.ViewState["Titles"] = reader2["Titles"].ToString();
                }
                reader2.Close();
            }
        }
    }
}

