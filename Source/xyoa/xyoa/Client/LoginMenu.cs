namespace xyoa.Client
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.IO;
    using System.Management;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class LoginMenu : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        public static string ipcontent;
        public static string JmBg;
        public static string JmText;
        private static string Key = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static byte[] Keys = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
        private Db List = new Db();
        protected TextBox Password;
        private publics pulicss = new publics();
        protected TextBox Username;
        public static string yzmcontent;

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (!this.pulicss.ipquanstr(HttpContext.Current.Request.UserHostAddress, ipcontent))
            {
                base.Response.Write("<script language=javascript>alert('您当前的IP为" + HttpContext.Current.Request.UserHostAddress + "，不允许登陆！请联系系统管理员');</script>");
            }
            else
            {
            //    string sql = "select reg from qp_oa_filemain ";
            //    SqlDataReader reader = this.List.GetList(sql);
            //    if (reader.Read() && (reader["reg"].ToString() == "0"))
                {
             //       string str2 = DESEncrypt("如需购买正式版，请联系开发商，感谢您的试用！^" + this.GetCPU() + "" + this.GetMAC().Replace(":", "") + "^" + DateTime.Now.AddDays(30.0).ToShortDateString() + "^30", "5", "6");
              //      string str3 = "Update qp_oa_filemain set cdkstr='" + str2 + "',reg='1'";
              //      this.List.ExeSql(str3);
                }
            //    reader.Close();
                string str4 = FormsAuthentication.HashPasswordForStoringInConfigFile(this.Password.Text, "MD5");
                string str5 = "select Username,Realname,guanzhu from qp_oa_username where Username='" + this.pulicss.GetFormatStr(this.Username.Text) + "' and Password='" + str4 + "'and Iflogin='1'  ";
                SqlDataReader reader2 = this.List.GetList(str5);
                if (reader2.Read())
                {
                    this.Session["Username"] = reader2["Username"].ToString();
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
                        this.pulicss.InsertMessage("" + reader2["Realname"].ToString() + "已上线！", reader3["username"].ToString(), reader3["realname"].ToString(), "#");
                    }
                    reader3.Close();
                    this.pulicss.InsertLog("登陆系统[" + reader2["Realname"].ToString() + "]", "登陆系统");
                    base.Response.Redirect("mymeunclient.aspx?user=" + this.Username.Text + "&pwd=" + this.Password.Text + "");
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('登陆失败!(1)请检查用户名,密码是否正确(2)确认帐号未被禁用');</script>");
                    return;
                }
                reader2.Close();
            }
        }

        public static string DESEncrypt(string encryptStr, string key, string IV)
        {
            key = key + "12345678";
            IV = IV + "12345678";
            key = key.Substring(0, 8);
            IV = IV.Substring(0, 8);
            SymmetricAlgorithm algorithm = new DESCryptoServiceProvider();
            algorithm.Key = Encoding.UTF8.GetBytes(key);
            algorithm.IV = Encoding.UTF8.GetBytes(IV);
            ICryptoTransform transform = algorithm.CreateEncryptor();
            byte[] bytes = Encoding.UTF8.GetBytes(encryptStr);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            string str = Convert.ToBase64String(stream.ToArray());
            Random random = new Random();
            for (int i = 0; i < 3; i++)
            {
                str = str.Substring(0, (2 * i) + 1) + Convert.ToChar((int) (random.Next(0x24) + 0x41)).ToString() + str.Substring((2 * i) + 1);
            }
            return str;
        }

        private string GetCPU()
        {
            string str = null;
            ManagementObjectCollection instances = new ManagementClass("Win32_Processor").GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                str = obj2["ProcessorId"].ToString();
            }
            return str;
        }

        private string GetMAC()
        {
            string str = null;
            ManagementObjectCollection instances = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
            foreach (ManagementObject obj2 in instances)
            {
                if ((bool) obj2["IPEnabled"])
                {
                    str = obj2["MacAddress"].ToString();
                }
            }
            return str;
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
                string str2 = "select * from qp_WorkTimeDj  where convert(varchar(10),Djtime,121)=convert(char(10),'" + DateTime.Now.ToShortDateString() + "',120) ";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (!reader2.Read())
                {
                    string str3 = "select username,realname from qp_oa_username";
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
            string sql = "select * from qp_oa_ipmanage";
            SqlDataReader reader = this.List.GetList(sql);
            if (reader.Read())
            {
                ipcontent = reader["content"].ToString();
            }
            else
            {
                ipcontent = "*";
            }
            reader.Close();
            if (!base.IsPostBack)
            {
                this.KaoQin();
                this.Button1.Attributes["onclick"] = "javascript:return showwait();";
                if ((base.Request.QueryString["user"] != null) && (base.Request.QueryString["pwd"] != null))
                {
                    if (!this.pulicss.ipquanstr(HttpContext.Current.Request.UserHostAddress, ipcontent))
                    {
                        base.Response.Write("<script language=javascript>alert('您当前的IP为" + HttpContext.Current.Request.UserHostAddress + "，不允许登陆！请联系系统管理员');</script>");
                    }
                    else
                    {
                  //      string str2 = "select reg from qp_oa_filemain ";
                  //      SqlDataReader reader2 = this.List.GetList(str2);
                    //    if (reader2.Read() && (reader2["reg"].ToString() == "0"))
                        {
                    //        string str3 = DESEncrypt("如需购买正式版，请联系开发商，感谢您的试用！^" + this.GetCPU() + "" + this.GetMAC().Replace(":", "") + "^" + DateTime.Now.AddDays(30.0).ToShortDateString() + "^30", "5", "6");
                    //        string str4 = "Update qp_oa_filemain set cdkstr='" + str3 + "',reg='1'";
                    //        this.List.ExeSql(str4);
                        }
                   //     reader2.Close();
                        string str5 = FormsAuthentication.HashPasswordForStoringInConfigFile(base.Request.QueryString["pwd"].ToString(), "MD5");
                        string str6 = "select Username,Realname,guanzhu from qp_oa_username where Username='" + this.pulicss.GetFormatStr(base.Request.QueryString["user"]) + "' and Password='" + str5 + "'and Iflogin='1'  ";
                        SqlDataReader reader3 = this.List.GetList(str6);
                        if (reader3.Read())
                        {
                            this.Session["Username"] = reader3["Username"].ToString();
                            string str7 = null;
                            string str8 = null;
                            str8 = "" + reader3["guanzhu"].ToString() + "";
                            ArrayList list = new ArrayList();
                            string[] strArray = str8.Split(new char[] { ',' });
                            for (int i = 0; i < strArray.Length; i++)
                            {
                                str7 = str7 + "'" + strArray[i] + "',";
                            }
                            str7 = str7 + "'0'";
                            string str9 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str7 + ") ";
                            SqlDataReader reader4 = this.List.GetList(str9);
                            while (reader4.Read())
                            {
                                this.pulicss.InsertMessage("" + reader3["Realname"].ToString() + "已上线！", reader4["username"].ToString(), reader4["realname"].ToString(), "#");
                            }
                            reader4.Close();
                            this.pulicss.InsertLog("登陆系统[" + reader3["Realname"].ToString() + "]", "登陆系统");
                            base.Response.Redirect("mymeunclient.aspx?user=" + base.Request.QueryString["user"] + "&pwd=" + base.Request.QueryString["pwd"] + "");
                            reader3.Close();
                        }
                        else
                        {
                            base.Response.Write("<script language=javascript>alert('登陆失败!(1)请检查用户名,密码是否正确(2)确认帐号未被禁用');</script>");
                        }
                    }
                }
            }
        }
    }
}

