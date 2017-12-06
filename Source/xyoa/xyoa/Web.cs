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
    using xyoa.web;

    public class Web : Page
    {
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected head Head2;
        protected ImageButton ImageButton1;
        protected Label Label1;
        protected Label Label2;
        protected Label Label3;
        protected Label Label4;
        private Db List = new Db();
        protected TextBox Password;
        private publics pulicss = new publics();
        public string slinks;
        public string slinks1;
        public string spics;
        public string spics1;
        public string stexts;
        public string stexts1;
        protected tail Tail1;
        protected TextBox Username;

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (!this.pulicss.ipquanstr(HttpContext.Current.Request.UserHostAddress, this.ViewState["ipcontent"].ToString()))
            {
                base.Response.Write("<script language=javascript>alert('您当前的IP为" + HttpContext.Current.Request.UserHostAddress + "，不允许登陆！请联系系统管理员');</script>");
            }
            else
            {
          //      string sql = "select reg from qp_oa_filemain ";
           //     SqlDataReader reader = this.List.GetList(sql);
            //    if (reader.Read())
                {
               //     if (reader["reg"].ToString() == "3")
                    {
                 //       base.Response.Write("<script>alert('经检测您的版本已经过期，请联系软件供应商重新注册！');window.location.href='reg.aspx'</Script>");
                 //       return;
                    }
                 //   if (reader["reg"].ToString() == "10")
                    {
                 //       base.Response.Write("<script>alert('经检测您正在使用盗版软件，有可能对您公司的信息进行危害，请联系正版软件供应商！');window.location.href='reg.aspx'</Script>");
                  //      return;
                    }
                  //  if (reader["reg"].ToString() != "2")
                    {
                    //    if (int.Parse(this.ViewState["IfMain"].ToString()) > 3)
                        {
                     //       base.Response.Write("<script>alert('数据库验证错误，请联系软件供应商修复！');window.location.href='reg.aspx'</Script>");
                     //       return;
                        }
                     //   if (reader["reg"].ToString() == "0")
                        {
                      //      string str2 = this.pulicss.DESEncrypt("感谢您的试用^" + this.pulicss.GetMAC() + "^" + DateTime.Now.AddDays(30.0).ToShortDateString() + "^300^试用版^4^1^1^1^" + DateTime.Now.ToShortDateString() + "^1,2,3,4,5,6,7,8,9,10,11,16,0", "5", "6");
                      //      string str3 = "Update qp_oa_filemain set cdkstr='" + str2 + "',reg='1'";
                       //     this.List.ExeSql(str3);
                       //     string str4 = "Update qp_oa_FaceMade set IfMain=IfMain+1";
                       //     this.List.ExeSql(str4);
                        }
                    }
                //    if (reader["reg"].ToString() == "5")
                    {
                    //    base.Response.Write("<script>alert('由于软件信息出现异常现已对软件信息进行了锁定，请重新获取软件激活码！');window.location.href='jihuo.aspx'</Script>");
                   //     return;
                    }
                }
             //   reader.Close();
                this.pulicss.setCookie("LoginName", this.Username.Text, 0x16d);
                string str5 = FormsAuthentication.HashPasswordForStoringInConfigFile(this.Password.Text, "MD5");
                string str6 = "select Username,Password,Iflogin,Realname,BuMenId,ResponQx,MoveTel,Zhiweiid,JueseId,guanzhu from qp_oa_username where Username='" + this.pulicss.GetFormatStr(this.Username.Text) + "' and Password='" + str5 + "' and Iflogin='1' and StardType='1' and ifdel='0'";
                SqlDataReader reader2 = this.List.GetList(str6);
                if (reader2.Read())
                {
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
                    if (this.DropDownList1.SelectedValue == "标准样式")
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
                }
                reader2.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select top 5  id,Titles,Tupian from qp_web_Tupian order by  id  desc";
                SqlDataReader list = this.List.GetList(sql);
                this.spics = null;
                this.stexts = null;
                this.slinks = null;
                while (list.Read())
                {
                    this.spics = this.spics + "web/Tupian/" + list["Tupian"].ToString() + "|";
                    this.stexts = this.stexts + list["Titles"].ToString() + "|";
                    this.slinks = this.slinks + "web/syTupian_view.aspx?id=" + list["ID"].ToString() + "|";
                }
                this.spics1 = this.spics.Substring(0, this.spics.LastIndexOf("|"));
                this.stexts1 = this.stexts.Substring(0, this.stexts.LastIndexOf("|"));
                this.slinks1 = this.slinks.Substring(0, this.slinks.LastIndexOf("|"));
                list.Close();
            }
            catch
            {
            }
            if (!this.Page.IsPostBack)
            {
                int num;
                string str6;
                SqlDataReader reader6;
                string str7;
                SqlDataReader reader7;
                object text;
                this.ImageButton1.Attributes["onclick"] = "javascript:return checkfrom();";
                string str2 = "select * from qp_oa_ipmanage";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.ViewState["ipcontent"] = reader2["content"].ToString();
                }
                else
                {
                    this.ViewState["ipcontent"] = "*";
                }
                reader2.Close();
                string str3 = "select * from qp_oa_LoginMade";
                SqlDataReader reader3 = this.List.GetList(str3);
                if (reader3.Read())
                {
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
                string str4 = "select IfMain from qp_oa_FaceMade";
                SqlDataReader reader4 = this.List.GetList(str4);
                if (reader4.Read())
                {
                    this.ViewState["IfMain"] = reader4["IfMain"].ToString();
                }
                reader4.Close();
                string str5 = "select * from qp_web_JiejiariDay where  (('" + DateTime.Now.ToShortDateString() + "' between StartTime and  EndTime) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + DateTime.Now.ToShortDateString() + "' as datetime),120)) or (convert(char(10),cast(EndTime as datetime),120)=convert(char(10),cast('" + DateTime.Now.ToShortDateString() + "' as datetime),120)) )";
                SqlDataReader reader5 = this.List.GetList(str5);
                if (reader5.Read())
                {
                    this.ViewState["RightPic"] = "2";
                    this.ImageButton1.ImageUrl = "web/img/denglu_2.jpg";
                    this.Label1.Text = null;
                    num = 0;
                    this.Label1.Text = this.Label1.Text + "<table width=\"100%\"  border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                    this.Label1.Text = this.Label1.Text + "<tr>";
                    str6 = "select * from qp_web_LanmuLb order by Paixu asc";
                    reader6 = this.List.GetList(str6);
                    while (reader6.Read())
                    {
                        num++;
                        this.Label1.Text = this.Label1.Text + "<td width=\"288\" align=\"center\">";
                        this.Label1.Text = this.Label1.Text + "<table width=\"100%\" height=\"204\" border=\"0\" cellpadding=\"0\" cellspacing=\"1\" bgcolor=\"#C7DCEF\">";
                        this.Label1.Text = this.Label1.Text + "<tr>";
                        this.Label1.Text = this.Label1.Text + "<td height=\"28\" valign=\"middle\" background=\"web/img/mid_1.jpg\" bgcolor=\"#FFFFFF\">";
                        this.Label1.Text = this.Label1.Text + "<table width=\"100%\" height=\"28\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                        this.Label1.Text = this.Label1.Text + "<tr>";
                        this.Label1.Text = this.Label1.Text + "<td width=\"148\" align=\"left\" background=\"web/img/er_2.jpg\">";
                        text = this.Label1.Text;
                        this.Label1.Text = string.Concat(new object[] { text, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b><font color=#FFFFFF>", reader6["Name"], "</font></b></td>" });
                        this.Label1.Text = this.Label1.Text + "<td width=\"138\" align=\"right\">";
                        text = this.Label1.Text;
                        this.Label1.Text = string.Concat(new object[] { text, "<a href=\"web/Lanmu.aspx?Leibie=", reader6["id"], "\">" });
                        this.Label1.Text = this.Label1.Text + "<img src=\"web/img/more_1.png\" width=\"44\" height=\"13\" hspace=\"10\" border=\"0\"></a></td>";
                        this.Label1.Text = this.Label1.Text + "</tr></table></td></tr>";
                        this.Label1.Text = this.Label1.Text + "<tr><td valign=\"top\" bgcolor=\"#FFFFFF\">";
                        this.Label1.Text = this.Label1.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                        str7 = "select top 7 id,Titles,Leibie,Shijian  from qp_web_Lanmu where Leibie='" + reader6["id"] + "' order by id desc";
                        reader7 = this.List.GetList(str7);
                        while (reader7.Read())
                        {
                            if (reader7["Titles"].ToString().Length > 0x10)
                            {
                                text = this.Label1.Text;
                                this.Label1.Text = string.Concat(new object[] { text, "<tr><td width=\"3%\" valign=\"top\"><b>\x00b7</b></td><td width=\"76%\"><a href=\"web/Lanmu_view.aspx?Leibie=", reader7["Leibie"], "&id=", reader7["id"], "\">", reader7["Titles"].ToString().Substring(0, 0x10), "...</a></td><td width=\"21%\"><font color=\"#9A9A9A\">[", DateTime.Parse(reader7["Shijian"].ToString()).Month.ToString(), "-", DateTime.Parse(reader7["Shijian"].ToString()).Day.ToString(), "]</font></td></tr>" });
                            }
                            else
                            {
                                text = this.Label1.Text;
                                this.Label1.Text = string.Concat(new object[] { text, "<tr><td width=\"3%\" valign=\"top\"><b>\x00b7</b></td><td width=\"76%\"><a href=\"web/Lanmu_view.aspx?Leibie=", reader7["Leibie"], "&id=", reader7["id"], "\">", reader7["Titles"], "</a></td><td width=\"21%\"><font color=\"#9A9A9A\">[", DateTime.Parse(reader7["Shijian"].ToString()).Month.ToString(), "-", DateTime.Parse(reader7["Shijian"].ToString()).Day.ToString(), "]</font></td></tr>" });
                            }
                        }
                        reader7.Close();
                        this.Label1.Text = this.Label1.Text + " </table>";
                        this.Label1.Text = this.Label1.Text + "</td></tr></table></td>";
                        switch (num)
                        {
                            case 1:
                                this.Label1.Text = this.Label1.Text + "<td width=\"10\" align=\"center\"></td>";
                                break;

                            case 2:
                                this.Label1.Text = this.Label1.Text + " </tr>";
                                this.Label1.Text = this.Label1.Text + " <tr><td height=\"10\" colspan=\"3\" align=\"center\"></td></tr>";
                                this.Label1.Text = this.Label1.Text + " <tr>";
                                num = 0;
                                break;
                        }
                    }
                    reader6.Close();
                    this.Label1.Text = this.Label1.Text + "</table>";
                }
                else
                {
                    this.ViewState["RightPic"] = "1";
                    this.ImageButton1.ImageUrl = "web/img/denglu_1.jpg";
                    this.Label1.Text = null;
                    num = 0;
                    this.Label1.Text = this.Label1.Text + "<table width=\"100%\"  border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                    this.Label1.Text = this.Label1.Text + "<tr>";
                    str6 = "select * from qp_web_LanmuLb order by Paixu asc";
                    reader6 = this.List.GetList(str6);
                    while (reader6.Read())
                    {
                        num++;
                        this.Label1.Text = this.Label1.Text + "<td width=\"288\" align=\"center\">";
                        this.Label1.Text = this.Label1.Text + "<table width=\"100%\" height=\"204\" border=\"0\" cellpadding=\"0\" cellspacing=\"1\" bgcolor=\"#C7DCEF\">";
                        this.Label1.Text = this.Label1.Text + "<tr>";
                        this.Label1.Text = this.Label1.Text + "<td height=\"28\" valign=\"middle\" background=\"web/img/mid_1.jpg\" bgcolor=\"#FFFFFF\">";
                        this.Label1.Text = this.Label1.Text + "<table width=\"100%\" height=\"28\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\">";
                        this.Label1.Text = this.Label1.Text + "<tr>";
                        this.Label1.Text = this.Label1.Text + "<td width=\"148\" align=\"left\" background=\"web/img/er_1.jpg\">";
                        text = this.Label1.Text;
                        this.Label1.Text = string.Concat(new object[] { text, "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>", reader6["Name"], "</b></td>" });
                        this.Label1.Text = this.Label1.Text + "<td width=\"138\" align=\"right\">";
                        text = this.Label1.Text;
                        this.Label1.Text = string.Concat(new object[] { text, "<a href=\"web/Lanmu.aspx?Leibie=", reader6["id"], "\">" });
                        this.Label1.Text = this.Label1.Text + "<img src=\"web/img/more_1.png\" width=\"44\" height=\"13\" hspace=\"10\" border=\"0\"></a></td>";
                        this.Label1.Text = this.Label1.Text + "</tr></table></td></tr>";
                        this.Label1.Text = this.Label1.Text + "<tr><td valign=\"top\" bgcolor=\"#FFFFFF\">";
                        this.Label1.Text = this.Label1.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                        str7 = "select top 7 id,Titles,Leibie,Shijian  from qp_web_Lanmu where Leibie='" + reader6["id"] + "' order by id desc";
                        reader7 = this.List.GetList(str7);
                        while (reader7.Read())
                        {
                            if (reader7["Titles"].ToString().Length > 0x10)
                            {
                                text = this.Label1.Text;
                                this.Label1.Text = string.Concat(new object[] { text, "<tr><td width=\"3%\" valign=\"top\"><b>\x00b7</b></td><td width=\"76%\"><a href=\"web/Lanmu_view.aspx?Leibie=", reader7["Leibie"], "&id=", reader7["id"], "\">", reader7["Titles"].ToString().Substring(0, 0x10), "...</a></td><td width=\"21%\"><font color=\"#9A9A9A\">[", DateTime.Parse(reader7["Shijian"].ToString()).Month.ToString(), "-", DateTime.Parse(reader7["Shijian"].ToString()).Day.ToString(), "]</font></td></tr>" });
                            }
                            else
                            {
                                text = this.Label1.Text;
                                this.Label1.Text = string.Concat(new object[] { text, "<tr><td width=\"3%\" valign=\"top\"><b>\x00b7</b></td><td width=\"76%\"><a href=\"web/Lanmu_view.aspx?Leibie=", reader7["Leibie"], "&id=", reader7["id"], "\">", reader7["Titles"], "</a></td><td width=\"21%\"><font color=\"#9A9A9A\">[", DateTime.Parse(reader7["Shijian"].ToString()).Month.ToString(), "-", DateTime.Parse(reader7["Shijian"].ToString()).Day.ToString(), "]</font></td></tr>" });
                            }
                        }
                        reader7.Close();
                        this.Label1.Text = this.Label1.Text + " </table>";
                        this.Label1.Text = this.Label1.Text + "</td></tr></table></td>";
                        switch (num)
                        {
                            case 1:
                                this.Label1.Text = this.Label1.Text + "<td width=\"10\" align=\"center\"></td>";
                                break;

                            case 2:
                                this.Label1.Text = this.Label1.Text + " </tr>";
                                this.Label1.Text = this.Label1.Text + " <tr><td height=\"10\" colspan=\"3\" align=\"center\"></td></tr>";
                                this.Label1.Text = this.Label1.Text + " <tr>";
                                num = 0;
                                break;
                        }
                    }
                    reader6.Close();
                    this.Label1.Text = this.Label1.Text + "</table>";
                }
                reader5.Close();
                string str8 = "select * from qp_web_Biaoti";
                SqlDataReader reader8 = this.List.GetList(str8);
                if (reader8.Read())
                {
                    this.ViewState["Biaoti"] = reader8["Content"].ToString();
                }
                reader8.Close();
                this.Label2.Text = null;
                this.Label2.Text = this.Label2.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                string str9 = "select top 10 id,Titles,Shijian  from qp_web_Xinwen order by id desc";
                SqlDataReader reader9 = this.List.GetList(str9);
                while (reader9.Read())
                {
                    if (reader9["Titles"].ToString().Length > 0x12)
                    {
                        text = this.Label2.Text;
                        this.Label2.Text = string.Concat(new object[] { text, "<tr><td width=\"5%\" valign=\"top\"><b>\x00b7</b></td><td width=\"95%\"><a href=\"web/Xinwen_view.aspx?id=", reader9["id"], "\">", reader9["Titles"].ToString().Substring(0, 0x12), "...</a></td></tr>" });
                    }
                    else
                    {
                        text = this.Label2.Text;
                        this.Label2.Text = string.Concat(new object[] { text, "<tr><td width=\"5%\" valign=\"top\"><b>\x00b7</b></td><td width=\"95%\"><a href=\"web/Xinwen_view.aspx?id=", reader9["id"], "\">", reader9["Titles"].ToString(), "</a></td></tr>" });
                    }
                }
                reader9.Close();
                this.Label2.Text = this.Label2.Text + "</table>";
                int num2 = 0;
                this.Label3.Text = null;
                this.Label3.Text = this.Label3.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                this.Label3.Text = this.Label3.Text + "<tr>";
                string str10 = "select top 6 id,Name,Tupian  from qp_web_ZhuantiLb order by id desc";
                SqlDataReader reader10 = this.List.GetList(str10);
                while (reader10.Read())
                {
                    num2++;
                    text = this.Label3.Text;
                    this.Label3.Text = string.Concat(new object[] { text, "<td height=\"47\" align=\"center\"><a href=\"web/Zhuangti.aspx?Leibie=", reader10["id"], "\"><img src=\"web/Zhuangti/", reader10["Tupian"], "\" width=\"167\" height=\"47\" border=\"0\"></a></td>" });
                    if (num2 == 2)
                    {
                        this.Label3.Text = this.Label3.Text + " </tr>";
                        this.Label3.Text = this.Label3.Text + " <tr>";
                        num2 = 0;
                    }
                }
                reader10.Close();
                this.Label3.Text = this.Label3.Text + "</table>";
                this.Label4.Text = null;
                this.Label4.Text = this.Label4.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"4\">";
                string str11 = "select top 7 id,Titles,Leibie,Shijian,NewName  from qp_web_Yuandi order by id desc";
                SqlDataReader reader11 = this.List.GetList(str11);
                while (reader11.Read())
                {
                    if (reader11["Titles"].ToString().Length > 0x10)
                    {
                        text = this.Label4.Text;
                        this.Label4.Text = string.Concat(new object[] { text, "<tr><td width=\"3%\" valign=\"top\"><b>\x00b7</b></td><td width=\"76%\"><a href=\"web/Yuandi_down.aspx?NewName=", reader11["NewName"], "\" target=_blank>", reader11["Titles"].ToString().Substring(0, 0x10), "...</a></td><td width=\"21%\"><font color=\"#9A9A9A\">[", DateTime.Parse(reader11["Shijian"].ToString()).Month.ToString(), "-", DateTime.Parse(reader11["Shijian"].ToString()).Day.ToString(), "]</font></td></tr>" });
                    }
                    else
                    {
                        text = this.Label4.Text;
                        this.Label4.Text = string.Concat(new object[] { text, "<tr><td width=\"3%\" valign=\"top\"><b>\x00b7</b></td><td width=\"76%\"><a href=\"web/Yuandi_down.aspx?NewName=", reader11["NewName"], "\" target=_blank>", reader11["Titles"], "</a></td><td width=\"21%\"><font color=\"#9A9A9A\">[", DateTime.Parse(reader11["Shijian"].ToString()).Month.ToString(), "-", DateTime.Parse(reader11["Shijian"].ToString()).Day.ToString(), "]</font></td></tr>" });
                    }
                }
                reader11.Close();
                this.Label4.Text = this.Label4.Text + "</table>";
            }
        }
    }
}

