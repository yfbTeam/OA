namespace xyoa
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Configuration;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class main : Page
    {
        protected HtmlForm form1;
        protected ImageButton ImageButton1;
        protected Label Label1;
        protected Label Label2;
        protected Label Label3;
        private Db List = new Db();
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected Label strhtml;
        protected TextBox TextBox1;
        protected Label url;

        public string GetInterIDList(string strfile)
        {
            string str = "";
            if (!File.Exists(HttpContext.Current.Server.MapPath(strfile)))
            {
                return str;
            }
            StreamReader reader = new StreamReader(HttpContext.Current.Server.MapPath(strfile), Encoding.Default);
            string str2 = reader.ReadToEnd();
            reader.Close();
            return str2;
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            this.pulicss.InsertLog("退出系统", "退出系统");
            this.Session.Clear();
            base.Response.Redirect("Default.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Redirect("default.aspx");
            }
            else
            {
                string sql = "select * from qp_oa_OpenMenu where  Username='" + this.Session["username"] + "'";
                SqlDataReader reader = this.List.GetList(sql);
                if (reader.Read())
                {
                    if (reader["Url"].ToString() == "Main.aspx")
                    {
                        this.ViewState["mainurl"] = "main_d.aspx";
                        this.ViewState["myurl"] = "MyWorkMenu.aspx";
                    }
                    if (reader["Url"].ToString() == "MyWorkMenu.aspx")
                    {
                        this.ViewState["mainurl"] = "JqMain/menhu.aspx?id=1";
                        this.ViewState["myurl"] = "MyWorkMenu.aspx";
                    }
                    if (reader["Url"].ToString() == "PublicWorkMenu.aspx")
                    {
                        this.ViewState["mainurl"] = "JqMain/menhu.aspx?id=2";
                        this.ViewState["myurl"] = "MyWorkMenu.aspx";
                    }
                    if (reader["Url"].ToString() == "OfficeMenu.aspx")
                    {
                        this.ViewState["mainurl"] = "JqMain/menhu.aspx?id=3";
                        this.ViewState["myurl"] = "OfficeMenu.aspx";
                    }
                    if (reader["Url"].ToString() == "InfoMenu.aspx")
                    {
                        this.ViewState["mainurl"] = "JqMain/menhu.aspx?id=4";
                        this.ViewState["myurl"] = "InfoMenu.aspx";
                    }
                    if (reader["Url"].ToString() == "ResourcesMenu.aspx")
                    {
                        this.ViewState["mainurl"] = "JqMain/menhu.aspx?id=5";
                        this.ViewState["myurl"] = "ResourcesMenu.aspx";
                    }
                    if (reader["Url"].ToString() == "WorkFlowMenu.aspx")
                    {
                        this.ViewState["mainurl"] = "JqMain/menhu.aspx?id=6";
                        this.ViewState["myurl"] = "WorkFlowMenu.aspx";
                    }
                    if (reader["Url"].ToString() == "Projecttable.aspx")
                    {
                        this.ViewState["mainurl"] = "JqMain/menhu.aspx?id=7";
                        this.ViewState["myurl"] = "Projecttable.aspx";
                    }
                    if (reader["Url"].ToString() == "SystemMenu.aspx")
                    {
                        this.ViewState["mainurl"] = "SystemManage/User/username.aspx";
                        this.ViewState["myurl"] = "SystemMenu.aspx";
                    }
                    if (reader["Url"].ToString() == "OtherMenu.aspx")
                    {
                        this.ViewState["mainurl"] = "JqMain/menhu.aspx?id=11";
                        this.ViewState["myurl"] = "OtherMenu.aspx";
                    }
                    if (reader["Url"].ToString() == "CRMtable.aspx")
                    {
                        this.ViewState["mainurl"] = "CRMtable/main.aspx";
                        this.ViewState["myurl"] = "CRMtable.aspx";
                    }
                    if (reader["Url"].ToString() == "HumanResourcestable.aspx")
                    {
                        this.ViewState["mainurl"] = "JqMain/menhu.aspx?id=9";
                        this.ViewState["myurl"] = "HumanResourcestable.aspx";
                    }
                    if (reader["Url"].ToString() == "MenhuMenu.aspx")
                    {
                        this.ViewState["mainurl"] = "JqMain/Mymenhu.aspx?p=12&id=0";
                        this.ViewState["myurl"] = "MenhuMenu.aspx";
                    }
                    if (reader["Url"].ToString() == "daiban.aspx")
                    {
                        this.ViewState["mainurl"] = "main_d.aspx";
                        this.ViewState["myurl"] = "daiban.aspx";
                    }
                }
                else
                {
                    this.ViewState["mainurl"] = "main_d.aspx";
                    this.ViewState["myurl"] = "MyWorkMenu.aspx";
                }
                reader.Close();
                this.strhtml.Text = "</td> </tr> </table> </td></tr> </table> </td></tr> <tr> <td>  <table width=\"100%\" height=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr>  <td valign=\"top\" id=\"td1\" width=\"185\">  <table width=\"100%\" border=\"0\" height=\"100%\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td><iframe name=\"lhead\" marginwidth=\"0\" marginheight=\"0\" src=\"menu/" + this.ViewState["myurl"] + "\"  frameborder=\"0\" width=\"100%\" height=\"100%\" scrolling=\"auto\"></iframe></td> </tr><tr>   <td height=\"25px\"> <table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr> <td height=\"25\" class=\"blueleft\">  <table width=\"100%\" height=\"20\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"> <tr>  <td width=\"100%\" align=\"center\"><b><a href=\"mainpage/mymessage.aspx?type=2\" target=\"lhead\"><font  class=\"lefttd\">内部消息</font></a></b>&nbsp;&nbsp;&nbsp;<b><a href=\"mainpage/jigou.aspx\" target=\"lhead\"><font class=\"lefttd\">组织信息</font></a></b></td></tr>  </table> </td> </tr> </table> </td>  </tr> </table>  </td> <td width=\"1%\"> <table width=\"5\" height=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"> <tr> <td class=\"bluemidd1\" style=\"width: 5px\">  <img onclick=\"visible_click()\" style=\"cursor: hand;\" src=\"/oaimg/left.gif\" id=\"middle_picture\"></td> </tr> </table></td><td id=\"td2\">";
                string str2 = "select * from qp_oa_filemain where reg='0' or reg='1' or reg='2'";
            //    SqlDataReader reader2 = this.List.GetList(str2);
            //    if (reader2.Read())
                {
              //      try
                    {
                 //       string str3 = null;
                 //       str3 = this.pulicss.DESDecrypt(reader2["cdkstr"].ToString(), "5", "6");
                  //      ArrayList list = new ArrayList();
                  //      string[] strArray = str3.Split(new char[] { '^' });
                   //     for (int i = 0; i < strArray.Length; i++)
                        {
                   //         this.Session["cdk1"] = strArray[0];
                   //         this.Session["cdk2"] = strArray[1];
                    //        this.Session["cdk3"] = strArray[2];
                    //        this.Session["cdk4"] = strArray[3];
                     //       this.Session["cdk5"] = strArray[4];
                     //       this.Session["baben"] = strArray[5];
                     //       this.Session["yidong"] = strArray[6];
                     //       this.Session["duanxin"] = strArray[7];
                      //      this.Session["zhushou"] = strArray[8];
                     //       this.Session["zcsj"] = strArray[9];
                      //      this.Session["mokuai"] = strArray[10];
                        }
                    }
               //     catch
                    {
                 //       base.Response.Write("<script language=javascript>alert('您的注册码无效！');window.parent.location = 'reg.aspx'</script>");
                 //       return;
                    }
                    this.ViewState["Label4"] = "<iframe name=\"rform\" marginwidth=\"0\" marginheight=\"0\" src=\"" + this.ViewState["mainurl"] + "\" frameborder=\"0\"  width=\"100%\" height=\"100%\" scrolling=\"auto\"></iframe>";
               //     if (reader2["reg"].ToString() != "2")
                    {
               //         HttpContext.Current.Response.Write("<!--\n如需购买正式版，请联系软件供应商，感谢您的试用！认准联系方式，警惕盗版危害！\n-->");
               //         this.Label1.Text = "</td></tr></table></td> </tr> <tr> <td height=\"20\"><table width=\"100%\" height=\"20\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"> <tr> <td align=\"left\" class=\"bluetail\"> <iframe name=\"txform\" frameborder=\"0\" marginheight=\"0\" marginwidth=\"0\" width=\"100px\" height=\"20px\" src=\"CountMessagejs.aspx\" border=\"0\"></iframe> </td> <td  class=\"bluetail\"><a href=\"javascript:void(0)\" onclick=\"alert('当前版未正式注册，" + this.Session["cdk1"].ToString() + "使用期限：" + this.Session["cdk3"].ToString() + "')\"><font color='#ffffff'>" + this.Session["cdk1"].ToString() + "使用期限：" + this.Session["cdk3"].ToString() + " </font></a></td></tr></table> </td> </tr></table> </td> </tr></table>";
                    }
              //      else
                    {
              //          if (this.Session["cdk3"].ToString() == "1900-01-01")
                        {
                  //          this.ViewState["qixian"] = "无限期";
                        }
                 //       else
                        {
                //            this.ViewState["qixian"] = this.Session["cdk3"].ToString();
                        }
                 //       if (int.Parse(this.Session["cdk4"].ToString()) >= 500)
                        {
                  //          this.ViewState["yonghu"] = "无限制";
                        }
                 //       else
                        {
                    //        this.ViewState["yonghu"] = this.Session["cdk4"].ToString();
                        }
                 //       HttpContext.Current.Response.Write("<!--\n当前合法使用单位：[" + this.Session["cdk1"] + "]，若使用单位名称与您所在单位名称不符合有可能为盗版软件，请立即联系开发商，以免给您和您单位带来不必要的损失。\n-->");
                        this.Label1.Text = string.Concat(new object[] { "</td></tr></table></td> </tr> <tr> <td height=\"20\"><table width=\"100%\" height=\"20\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"> <tr> <td align=\"left\" class=\"bluetail\"> <iframe name=\"txform\" frameborder=\"0\" marginheight=\"0\" marginwidth=\"0\" width=\"100px\" height=\"20px\" src=\"CountMessagejs.aspx\" border=\"0\"></iframe> </td> <td  class=\"bluetail\"><font  color='#ffffff'>合法使用单位：某某单位！</font></a> </td></tr></table> </td> </tr></table> </td> </tr></table>" });
                    }
                }
            //    else
                {
               //     base.Response.Write("<script language=javascript>alert('您的注册码无效，请联系软件供应商！');window.parent.location = 'reg.aspx'</script>");
              //      return;
                }
             //   reader2.Close();
              //  if (("" + this.pulicss.GetMAC() + "") != this.Session["cdk2"].ToString())
                {
               //     base.Response.Write("<script>alert('软件绑定的机器码不正确，请联系软件供应商！');window.location.href='reg.aspx'</Script>");
                }
            //    else
                {
                    string str7;
                    SqlDataReader reader5;
                    object text;
             //       if (this.Session["cdk3"].ToString() != "1900-01-01")
                    {
                 //       TimeSpan span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToShortDateString()) - DateTime.Parse(this.Session["cdk3"].ToString()));
                  //      if (span.TotalDays > 0.0)
                        {
                    //        string str4 = "Update qp_oa_filemain set reg='3'";
                     //       this.List.ExeSql(str4);
                      //      base.Response.Write("<script>alert('您的版本已经过期，请联系软件供应商！');window.location.href='reg.aspx'</Script>");
                       //     return;
                        }
                    }
                    this.ImageButton1.Attributes.Add("onclick", "javascript:return zx();");
                    this.ViewState["showtime"] = "" + DateTime.Now.Year.ToString() + "年" + DateTime.Now.Month.ToString() + "月" + DateTime.Now.Day.ToString() + "日&nbsp;&nbsp;" + this.GetWeekDay() + "";
                    this.Session["yangshi"] = this.pulicss.Getyangshi();
                    string str5 = "select * from qp_oa_FaceMade";
                    SqlDataReader reader3 = this.List.GetList(str5);
                    if (reader3.Read())
                    {
                        this.ViewState["Logos"] = reader3["Logos"].ToString();
                        this.Session["Titles"] = reader3["Titles"].ToString();
                        if (reader3["Geyan"].ToString().Trim() != "")
                        {
                            this.ViewState["Geyan"] = "  -  " + reader3["Geyan"].ToString() + "";
                        }
                    }
                    reader3.Close();
                    string str6 = "select * from qp_oa_FjKey";
                    SqlDataReader reader4 = this.List.GetList(str6);
                    if (reader4.Read())
                    {
                        this.Session["FjKey"] = reader4["content"].ToString();
                    }
                    reader4.Dispose();
                    this.url.Text = "";
                    this.url.Text = this.url.Text + "<table border=\"0\" cellspacing=\"0\" cellpadding=\"0\"> <tr>";
                //    if (this.Session["baben"].ToString() == "4")
                    {
                        str7 = string.Concat(new object[] { "select leixing,urlname,url from qp_oa_AllUrl where (CHARINDEX(''+quanxian+'','", this.Session["perstr"], "')   >   0 ) and ParentNodesID=0 and leixing in (", ConfigurationManager.AppSettings["addurl"].ToString(), ") order by paixu asc" });
                        reader5 = this.List.GetList(str7);
                        while (reader5.Read())
                        {
                            text = this.url.Text;
                            this.url.Text = string.Concat(new object[] { text, " <td width=\"194\" align=\"center\"  height=\"30\"><ul id=\"UL1\"><li class=\"L22\"><a href=\"javascript:void(0)\"   onclick=\"geturl('", reader5["leixing"], "','", reader5["url"], "')\"><span > <b><font class=\"L22\">", reader5["urlname"], "</font></b></span></a></li></ul></td> <td width=\"2\"> <img src=\"bluecss/line.gif\" width=\"2\" height=\"20\"></td>" });
                        }
                        reader5.Close();
                    }
                //    if (this.Session["baben"].ToString() == "5")
                    {
                //        str7 = string.Concat(new object[] { "select leixing,urlname,url from qp_oa_AllUrl where (CHARINDEX(''+quanxian+'','", this.Session["perstr"], "')   >   0 ) and ParentNodesID=0 and leixing in (", this.Session["mokuai"].ToString(), ") order by paixu asc" });
                 //       reader5 = this.List.GetList(str7);
                 //       while (reader5.Read())
                        {
                 //           text = this.url.Text;
                  //          this.url.Text = string.Concat(new object[] { text, " <td width=\"194\" align=\"center\"  height=\"30\"><ul id=\"UL1\"><li class=\"L22\"><a href=\"javascript:void(0)\"   onclick=\"geturl('", reader5["leixing"], "','", reader5["url"], "')\"><span > <b><font class=\"L22\">", reader5["urlname"], "</font></b></span></a></li></ul></td> <td width=\"2\"> <img src=\"bluecss/line.gif\" width=\"2\" height=\"20\"></td>" });
                        }
                 //       reader5.Close();
                    }
                    int num2 = 0;
                    string str8 = "select * from qp_oa_Daibanshiyi  where CHARINDEX(quanxian,'" + this.Session["perstr"] + "') > 0 order by paixu asc";
                    SqlDataReader reader6 = this.List.GetList(str8);
                    while (reader6.Read())
                    {
                        try
                        {
                            num2 += int.Parse(this.pulicss.Daibanshiyi(reader6["Name"].ToString()));
                        }
                        catch
                        {
                            num2 = num2;
                        }
                    }
                    reader6.Close();
                    text = this.url.Text;
                    this.url.Text = string.Concat(new object[] { text, " <td width=\"294\" align=\"center\"  height=\"30\"><ul id=\"UL1\"><li class=\"L22\"><a href='menu/daiban.aspx' target='lhead' ><span > <b><font class=\"L22\">待办事宜(", num2, ")</font></b></span></a></li></ul></td> <td width=\"2\"> <img src=\"bluecss/line.gif\" width=\"2\" height=\"20\"></td>" });
                    this.url.Text = this.url.Text + "</tr></table>";
                    this.Label2.Text = "</td><td width=\"37%\" valign=\"top\" style=\"line-height: 260%\"><table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"> <tr><td align=\"right\" valign=\"top\"><a href=\"index.aspx\"><img src=\"bluecss/topb1.gif\" width=\"65\" height=\"20\" hspace=\"1\" border=\"0\"></a><a href=\"main_d.aspx\"  target=\"rform\"><img src=\"bluecss/topb8.gif\" width=\"55\" height=\"20\" hspace=\"1\" border=\"0\"></a><a href=\"javascript:;;\" onclick=\"openwindows()\"><img src=\"bluecss/topb6.gif\" width=\"55\" height=\"20\" hspace=\"1\" border=\"0\"></a>";
                    this.Label1.Visible = true;
                }
            }
        }
    }
}

