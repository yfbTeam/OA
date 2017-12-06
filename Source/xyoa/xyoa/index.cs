namespace xyoa
{
    using Ajax;
    using qiupeng.form;
    using qiupeng.pm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class index : Page
    {
        protected Label daibanshiyi;
        private qiupeng.pm.divpm divpm = new qiupeng.pm.divpm();
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label Label1;
        protected Label Label2;
        protected Label Label3;
        private Db List = new Db();
        protected TextBox menhuid;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox TextBox1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Redirect("default.aspx");
            }
            else
            {
                Utility.RegisterTypeForAjax(typeof(AjaxMethod));
                this.showform.BindListDz(this.Label3, this.Session["BuMenId"].ToString());
                this.Session["BuMenLone"] = this.Label3.Text;
            //    string sql = "select * from qp_oa_filemain where reg='0' or reg='1' or reg='2'";
            //    SqlDataReader reader = this.List.GetList(sql);
             //   if (reader.Read())
                {
               //     try
                    {
                 //       string str2 = null;
                  //      str2 = this.pulicss.DESDecrypt(reader["cdkstr"].ToString(), "5", "6");
                  //      ArrayList list = new ArrayList();
                 //       string[] strArray = str2.Split(new char[] { '^' });
                 //       for (int i = 0; i < strArray.Length; i++)
                        {
                     //       this.Session["cdk1"] = strArray[0];
                    //        this.Session["cdk2"] = strArray[1];
                      //      this.Session["cdk3"] = strArray[2];
                     //       this.Session["cdk4"] = strArray[3];
                      //      this.Session["cdk5"] = strArray[4];
                      //      this.Session["baben"] = strArray[5];
                     //       this.Session["yidong"] = strArray[6];
                     //       this.Session["duanxin"] = strArray[7];
                      //      this.Session["zhushou"] = strArray[8];
                        //    this.Session["zcsj"] = strArray[9];
                        }
                    }
              //      catch
                    {
                  //      base.Response.Write("<script language=javascript>alert('您的注册码无效！');window.parent.location = 'reg.aspx'</script>");
                  //      return;
                    }
               //     if (reader["reg"].ToString() != "2")
                    {
                  //      this.ViewState["reginfo"] = "2";
                    }
                //    else
                    {
                   //     this.ViewState["reginfo"] = "3";
                    //    if (this.Session["cdk3"].ToString() == "1900-01-01")
                        {
                    //        this.ViewState["qixian"] = "无限期";
                        }
                    //    else
                        {
                     //       this.ViewState["qixian"] = this.Session["cdk3"].ToString();
                        }
                    //    if (int.Parse(this.Session["cdk4"].ToString()) >= 500)
                        {
                    //        this.ViewState["yonghu"] = "无限制";
                        }
                    //    else
                        {
                     //       this.ViewState["yonghu"] = this.Session["cdk4"].ToString();
                        }
                    }
                }
           //     else
                {
              //      base.Response.Write("<script language=javascript>alert('您的注册码无效，请联系软件供应商！');window.parent.location = 'reg.aspx'</script>");
               //     return;
                }
             //   reader.Close();
            //    if (("" + this.pulicss.GetMAC() + "") != this.Session["cdk2"].ToString())
                {
               //     base.Response.Write("<script>alert('软件绑定的机器码不正确，请联系软件供应商！');window.location.href='reg.aspx'</Script>");
                }
            //    else
                {
                    StateBag bag = ViewState;
                    object obj2;
              //      if (this.Session["cdk3"].ToString() != "1900-01-01")
                    {
                   //     TimeSpan span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToShortDateString()) - DateTime.Parse(this.Session["cdk3"].ToString()));
                   //     if (span.TotalDays > 0.0)
                        {
                    //        string str3 = "Update qp_oa_filemain set reg='3'";
                     //       this.List.ExeSql(str3);
                    //        base.Response.Write("<script>alert('您的版本已经过期，请联系软件供应商！');window.location.href='reg.aspx'</Script>");
                     //       return;
                        }
                    }
                    HttpBrowserCapabilities capabilities = new HttpBrowserCapabilities();
                    if (decimal.Parse(base.Request.Browser.Version) < 7M)
                    {
                        this.ViewState["css1"] = "";
                        this.ViewState["css2"] = "";
                        this.ViewState["css3"] = "color: #000000;";
                        this.ViewState["css4"] = "left: 60%;";
                    }
                    else
                    {
                        this.ViewState["css1"] = "background: url('/images/icon_text_l.png') 0px 0px no-repeat;";
                        this.ViewState["css2"] = "background: url('/images/icon_text_r.png') right center no-repeat;";
                        this.ViewState["css3"] = "color: #fff;";
                        this.ViewState["css4"] = "left: 50%;";
                    }
                    string str4 = this.Session["perstr"].ToString() + this.divpm.ChlidQX();
                    string str5 = "select Biaotilan from qp_oa_yangshi where  Username='" + this.Session["username"] + "'";
                    SqlDataReader reader2 = this.List.GetList(str5);
                    if (reader2.Read())
                    {
                        this.ViewState["btlstl"] = reader2["Biaotilan"].ToString();
                    }
                    reader2.Close();
                    string str6 = "select top 1 id from qp_oa_DaibanshiyiKey where username='" + this.Session["username"] + "'";
                    SqlDataReader reader3 = this.List.GetList(str6);
                    if (reader3.Read())
                    {
                        this.ViewState["dbsystl"] = "";
                    }
                    else
                    {
                        this.ViewState["dbsystl"] = " Style=\"display: none\"";
                    }
                    reader3.Close();
                    this.daibanshiyi.Text = null;
                    this.daibanshiyi.Text = "<div id=\"dbsykey\" " + this.ViewState["dbsystl"] + "><div class=\"shiyi\" id=\"shiyi\" onmousedown=\"dreag('shiyi')\"><table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" background=\"/Images/shiyi.png\" style=\"cursor: move;_*behavior: url(/Script/ie6pan/iepngfix.htc);\"><tr><td width=\"25\"  height=\"25\" align=\"center\"><img src=\"oaimg/menu/Menu4.gif\" /></td><td width=\"220\"  height=\"25\"><strong>待办事宜</strong></td><td width=\"40\"  height=\"25\"><a href=\"JqMain/index_if.aspx\" target=if_dbsy><img src=\"/oaimg/sx.png\" boder=0 title=\"刷新\" style=\"_*behavior: url(/Script/ie6pan/iepngfix.htc);\"/></a>&nbsp;&nbsp;<img src=\"/oaimg/sc.png\" onclick=\"dbsyset()\" style=\"cursor: pointer;_*behavior: url(/Script/ie6pan/iepngfix.htc);\" title=\"关闭\"/></td></tr></table>";
                    this.daibanshiyi.Text = this.daibanshiyi.Text + "<table width=\"285\" border=\"0\" cellspacing=\"0\" cellpadding=\"1\" style=\"border:1px solid #666666;\"><tr>";
                    this.daibanshiyi.Text = this.daibanshiyi.Text + "<td><iframe  name=\"if_dbsy\"  bgcolor=white width=\"100%\" height=\"388\" src=\"JqMain/index_if.aspx\" frameborder=\"no\" scrolling=\"yes\"></iframe></td></tr>";
                    this.daibanshiyi.Text = this.daibanshiyi.Text + "</table>";
                    this.daibanshiyi.Text = this.daibanshiyi.Text + " </div></div>";
                    this.ViewState["myurl"] = "";
                    this.ViewState["myurl2"] = "";
                    this.ViewState["myurl3"] = "";
                    this.ViewState["myurl4"] = "";
                    this.ViewState["myurl5"] = "";
                    string str7 = "select A.* from [qp_oa_MyUrl] as [A] where Username='" + this.Session["username"] + "' and menhu='1'  order by A.paixun desc";
                    SqlDataReader reader4 = this.List.GetList(str7);
                    while (reader4.Read())
                    {
                        if (reader4["leixing"].ToString() == "1")
                        {
                            string str8 = string.Concat(new object[] { "select B.[urlname], B.[url], B.[chuangzhi], B.[bigpic], B.[openkey], B.[id] as Bid from qp_oa_AllUrl as [B] where  [B].[Id]='", reader4["keyid"], "' and (CHARINDEX(''+B.quanxian+'','", str4, "')   >   0 )   and B.xianshi='1'" });
                            SqlDataReader reader5 = this.List.GetList(str8);
                            if (reader5.Read())
                            {
                                if (reader5["chuangzhi"].ToString() == "0")
                                {
                                    obj2 = bag["myurl"];
                                    (bag = this.ViewState)["myurl"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader5["urlname"], "\" id=\"keyid", reader5["Bid"], "\" onclick=\"showWin('", reader4["keyid"], "','", reader5["urlname"], "','", reader5["url"], "?p=", reader4["keyid"], "','", reader5["openkey"], "')\"><img src=\"/Images/desktopIOC/", 
                                        reader5["bigpic"], "\" /><br /><div  class=\"icon-text\"><span>", reader5["urlname"], "</span></div></li>"
                                     });
                                }
                                else
                                {
                                    obj2 = bag["myurl"];
                                    (bag = this.ViewState)["myurl"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader5["urlname"], "\" id=\"keyid", reader5["Bid"], "\" onclick=\"showWin('", reader4["keyid"], "','", reader5["urlname"], "','", reader5["url"], "','", reader5["openkey"], "')\"><img src=\"/Images/desktopIOC/", reader5["bigpic"], "\" /><br /><div  class=\"icon-text\"><span>", 
                                        reader5["urlname"], "</span></div></li>"
                                     });
                                }
                            }
                            reader5.Close();
                            reader5.Dispose();
                        }
                        else if (reader4["leixing"].ToString() == "2")
                        {
                            string str9 = string.Concat(new object[] { "select B.[name], B.[urlname], B.[pic], B.[id] as Bid from qp_oa_OtherMenu as [B] where  [B].[Id]='", reader4["keyid"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                            SqlDataReader reader6 = this.List.GetList(str9);
                            if (reader6.Read())
                            {
                                if (reader6["urlname"].ToString().IndexOf("?") > 0)
                                {
                                    obj2 = bag["myurl"];
                                    (bag = this.ViewState)["myurl"] = string.Concat(new object[] { obj2, "<li title=\"", reader6["name"], "\" id=\"kzkeyid", reader6["Bid"], "5322\" onclick=\"showWin('", reader4["keyid"], "5322','", reader6["name"], "','", reader6["urlname"], "','0')\"><img src=\"/Images/desktopIOC/", reader6["pic"], "\" /><br /><div  class=\"icon-text\"><span>", reader6["name"], "</span></div></li>" });
                                }
                                else
                                {
                                    obj2 = bag["myurl"];
                                    (bag = this.ViewState)["myurl"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader6["name"], "\" id=\"kzkeyid", reader6["Bid"], "5322\" onclick=\"showWin('", reader4["keyid"], "5322','", reader6["name"], "','", reader6["urlname"], "?p=", reader4["keyid"], "5322','0')\"><img src=\"/Images/desktopIOC/", reader6["pic"], "\" /><br /><div  class=\"icon-text\"><span>", 
                                        reader6["name"], "</span></div></li>"
                                     });
                                }
                            }
                            reader6.Close();
                            reader6.Dispose();
                        }
                        else if (reader4["leixing"].ToString() == "3")
                        {
                            string str10 = string.Concat(new object[] { "select B.[name], B.[pic], B.[id] as Bid from qp_oa_Menhu as [B] where  [B].[Id]='", reader4["keyid"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                            SqlDataReader reader7 = this.List.GetList(str10);
                            if (reader7.Read())
                            {
                                obj2 = bag["myurl"];
                                (bag = this.ViewState)["myurl"] = string.Concat(new object[] { obj2, "<li title=\"", reader7["name"], "\" id=\"mhkeyid", reader7["Bid"], "91221\" onclick=\"showWin('", reader4["keyid"], "91221','", reader7["name"], "','JqMain/Main.aspx?p=12&id=", reader7["Bid"], "','0')\"><img src=\"/Images/desktopIOC/", reader7["pic"], "\" /><br /><div  class=\"icon-text\"><span>", reader7["name"], "</span></div></li>" });
                            }
                            reader7.Close();
                            reader7.Dispose();
                        }
                    }
                    reader4.Close();
                    reader4.Dispose();
                    (bag = this.ViewState)["myurl"] = bag["myurl"] + "<li onclick=\"addli()\"><img src=\"/Images/desktopIOC/add.png\" /><br /><div class=\"icon-text\"><span>添加</span></div></li>";
                    string str11 = "select A.* from [qp_oa_MyUrl] as [A] where Username='" + this.Session["username"] + "' and menhu='2'  order by A.paixun desc";
                    SqlDataReader reader8 = this.List.GetList(str11);
                    while (reader8.Read())
                    {
                        if (reader8["leixing"].ToString() == "1")
                        {
                            string str12 = string.Concat(new object[] { "select B.[urlname], B.[url], B.[chuangzhi], B.[bigpic], B.[openkey], B.[id] as Bid from qp_oa_AllUrl as [B] where  [B].[Id]='", reader8["keyid"], "' and (CHARINDEX(''+B.quanxian+'','", str4, "')   >   0 )   and B.xianshi='1'" });
                            SqlDataReader reader9 = this.List.GetList(str12);
                            if (reader9.Read())
                            {
                                if (reader9["chuangzhi"].ToString() == "0")
                                {
                                    obj2 = bag["myurl2"];
                                    (bag = this.ViewState)["myurl2"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader9["urlname"], "\" id=\"keyid", reader9["Bid"], "\" onclick=\"showWin('", reader8["keyid"], "','", reader9["urlname"], "','", reader9["url"], "?p=", reader8["keyid"], "','", reader9["openkey"], "')\"><img src=\"/Images/desktopIOC/", 
                                        reader9["bigpic"], "\" /><br /><div  class=\"icon-text\"><span>", reader9["urlname"], "</span></div></li>"
                                     });
                                }
                                else
                                {
                                    obj2 = bag["myurl2"];
                                    (bag = this.ViewState)["myurl2"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader9["urlname"], "\" id=\"keyid", reader9["Bid"], "\" onclick=\"showWin('", reader8["keyid"], "','", reader9["urlname"], "','", reader9["url"], "','", reader9["openkey"], "')\"><img src=\"/Images/desktopIOC/", reader9["bigpic"], "\" /><br /><div  class=\"icon-text\"><span>", 
                                        reader9["urlname"], "</span></div></li>"
                                     });
                                }
                            }
                            reader9.Close();
                            reader9.Dispose();
                        }
                        else if (reader8["leixing"].ToString() == "2")
                        {
                            string str13 = string.Concat(new object[] { "select B.[name], B.[urlname], B.[pic], B.[id] as Bid from qp_oa_OtherMenu as [B] where  [B].[Id]='", reader8["keyid"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                            SqlDataReader reader10 = this.List.GetList(str13);
                            if (reader10.Read())
                            {
                                if (reader10["urlname"].ToString().IndexOf("?") > 0)
                                {
                                    obj2 = bag["myurl2"];
                                    (bag = this.ViewState)["myurl2"] = string.Concat(new object[] { obj2, "<li title=\"", reader10["name"], "\" id=\"kzkeyid", reader10["Bid"], "5322\" onclick=\"showWin('", reader8["keyid"], "5322','", reader10["name"], "','", reader10["urlname"], "','0')\"><img src=\"/Images/desktopIOC/", reader10["pic"], "\" /><br /><div  class=\"icon-text\"><span>", reader10["name"], "</span></div></li>" });
                                }
                                else
                                {
                                    obj2 = bag["myurl2"];
                                    (bag = this.ViewState)["myurl2"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader10["name"], "\" id=\"kzkeyid", reader10["Bid"], "5322\" onclick=\"showWin('", reader8["keyid"], "5322','", reader10["name"], "','", reader10["urlname"], "?p=", reader8["keyid"], "5322','0')\"><img src=\"/Images/desktopIOC/", reader10["pic"], "\" /><br /><div  class=\"icon-text\"><span>", 
                                        reader10["name"], "</span></div></li>"
                                     });
                                }
                            }
                            reader10.Close();
                            reader10.Dispose();
                        }
                        else if (reader8["leixing"].ToString() == "3")
                        {
                            string str14 = string.Concat(new object[] { "select B.[name], B.[pic], B.[id] as Bid from qp_oa_Menhu as [B] where  [B].[Id]='", reader8["keyid"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                            SqlDataReader reader11 = this.List.GetList(str14);
                            if (reader11.Read())
                            {
                                obj2 = bag["myurl2"];
                                (bag = this.ViewState)["myurl2"] = string.Concat(new object[] { obj2, "<li title=\"", reader11["name"], "\" id=\"mhkeyid", reader11["Bid"], "92222\" onclick=\"showWin('", reader8["keyid"], "92222','", reader11["name"], "','JqMain/Main.aspx?p=12&id=", reader11["Bid"], "','0')\"><img src=\"/Images/desktopIOC/", reader11["pic"], "\" /><br /><div  class=\"icon-text\"><span>", reader11["name"], "</span></div></li>" });
                            }
                            reader11.Close();
                            reader11.Dispose();
                        }
                    }
                    reader8.Close();
                    reader8.Dispose();
                    (bag = this.ViewState)["myurl2"] = bag["myurl2"] + "<li onclick=\"addli()\"><img src=\"/Images/desktopIOC/add.png\" /><br /><div class=\"icon-text\"><span>添加</span></div></li>";
                    string str15 = "select A.* from [qp_oa_MyUrl] as [A] where Username='" + this.Session["username"] + "' and menhu='3'  order by A.paixun desc";
                    SqlDataReader reader12 = this.List.GetList(str15);
                    while (reader12.Read())
                    {
                        if (reader12["leixing"].ToString() == "1")
                        {
                            string str16 = string.Concat(new object[] { "select B.[urlname], B.[url], B.[chuangzhi], B.[bigpic], B.[openkey], B.[id] as Bid from qp_oa_AllUrl as [B] where  [B].[Id]='", reader12["keyid"], "' and (CHARINDEX(''+B.quanxian+'','", str4, "')   >   0 )   and B.xianshi='1'" });
                            SqlDataReader reader13 = this.List.GetList(str16);
                            if (reader13.Read())
                            {
                                if (reader13["chuangzhi"].ToString() == "0")
                                {
                                    obj2 = bag["myurl3"];
                                    (bag = this.ViewState)["myurl3"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader13["urlname"], "\" id=\"keyid", reader13["Bid"], "\" onclick=\"showWin('", reader12["keyid"], "','", reader13["urlname"], "','", reader13["url"], "?p=", reader12["keyid"], "','", reader13["openkey"], "')\"><img src=\"/Images/desktopIOC/", 
                                        reader13["bigpic"], "\" /><br /><div  class=\"icon-text\"><span>", reader13["urlname"], "</span></div></li>"
                                     });
                                }
                                else
                                {
                                    obj2 = bag["myurl3"];
                                    (bag = this.ViewState)["myurl3"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader13["urlname"], "\" id=\"keyid", reader13["Bid"], "\" onclick=\"showWin('", reader12["keyid"], "','", reader13["urlname"], "','", reader13["url"], "','", reader13["openkey"], "')\"><img src=\"/Images/desktopIOC/", reader13["bigpic"], "\" /><br /><div  class=\"icon-text\"><span>", 
                                        reader13["urlname"], "</span></div></li>"
                                     });
                                }
                            }
                            reader13.Close();
                            reader13.Dispose();
                        }
                        else if (reader12["leixing"].ToString() == "2")
                        {
                            string str17 = string.Concat(new object[] { "select B.[name], B.[urlname], B.[pic], B.[id] as Bid from qp_oa_OtherMenu as [B] where  [B].[Id]='", reader12["keyid"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                            SqlDataReader reader14 = this.List.GetList(str17);
                            if (reader14.Read())
                            {
                                if (reader14["urlname"].ToString().IndexOf("?") > 0)
                                {
                                    obj2 = bag["myurl3"];
                                    (bag = this.ViewState)["myurl3"] = string.Concat(new object[] { obj2, "<li title=\"", reader14["name"], "\" id=\"kzkeyid", reader14["Bid"], "5322\" onclick=\"showWin('", reader12["keyid"], "5322','", reader14["name"], "','", reader14["urlname"], "','0')\"><img src=\"/Images/desktopIOC/", reader14["pic"], "\" /><br /><div  class=\"icon-text\"><span>", reader14["name"], "</span></div></li>" });
                                }
                                else
                                {
                                    obj2 = bag["myurl3"];
                                    (bag = this.ViewState)["myurl3"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader14["name"], "\" id=\"kzkeyid", reader14["Bid"], "5322\" onclick=\"showWin('", reader12["keyid"], "5322','", reader14["name"], "','", reader14["urlname"], "?p=", reader12["keyid"], "5322','0')\"><img src=\"/Images/desktopIOC/", reader14["pic"], "\" /><br /><div  class=\"icon-text\"><span>", 
                                        reader14["name"], "</span></div></li>"
                                     });
                                }
                            }
                            reader14.Close();
                            reader14.Dispose();
                        }
                        else if (reader12["leixing"].ToString() == "3")
                        {
                            string str18 = string.Concat(new object[] { "select B.[name], B.[pic], B.[id] as Bid from qp_oa_Menhu as [B] where  [B].[Id]='", reader12["keyid"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                            SqlDataReader reader15 = this.List.GetList(str18);
                            if (reader15.Read())
                            {
                                obj2 = bag["myurl3"];
                                (bag = this.ViewState)["myurl3"] = string.Concat(new object[] { obj2, "<li title=\"", reader15["name"], "\" id=\"mhkeyid", reader15["Bid"], "92222\" onclick=\"showWin('", reader12["keyid"], "92222','", reader15["name"], "','JqMain/Main.aspx?p=12&id=", reader15["Bid"], "','0')\"><img src=\"/Images/desktopIOC/", reader15["pic"], "\" /><br /><div  class=\"icon-text\"><span>", reader15["name"], "</span></div></li>" });
                            }
                            reader15.Close();
                            reader15.Dispose();
                        }
                    }
                    reader12.Close();
                    reader12.Dispose();
                    (bag = this.ViewState)["myurl3"] = bag["myurl3"] + "<li onclick=\"addli()\"><img src=\"/Images/desktopIOC/add.png\" /><br /><div class=\"icon-text\"><span>添加</span></div></li>";
                    string str19 = "select A.* from [qp_oa_MyUrl] as [A] where Username='" + this.Session["username"] + "' and menhu='4'  order by A.paixun desc";
                    SqlDataReader reader16 = this.List.GetList(str19);
                    while (reader16.Read())
                    {
                        if (reader16["leixing"].ToString() == "1")
                        {
                            string str20 = string.Concat(new object[] { "select B.[urlname], B.[url], B.[chuangzhi], B.[bigpic], B.[openkey], B.[id] as Bid from qp_oa_AllUrl as [B] where  [B].[Id]='", reader16["keyid"], "' and (CHARINDEX(''+B.quanxian+'','", str4, "')   >   0 )   and B.xianshi='1'" });
                            SqlDataReader reader17 = this.List.GetList(str20);
                            if (reader17.Read())
                            {
                                if (reader17["chuangzhi"].ToString() == "0")
                                {
                                    obj2 = bag["myurl4"];
                                    (bag = this.ViewState)["myurl4"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader17["urlname"], "\" id=\"keyid", reader17["Bid"], "\" onclick=\"showWin('", reader16["keyid"], "','", reader17["urlname"], "','", reader17["url"], "?p=", reader16["keyid"], "','", reader17["openkey"], "')\"><img src=\"/Images/desktopIOC/", 
                                        reader17["bigpic"], "\" /><br /><div  class=\"icon-text\"><span>", reader17["urlname"], "</span></div></li>"
                                     });
                                }
                                else
                                {
                                    obj2 = bag["myurl4"];
                                    (bag = this.ViewState)["myurl4"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader17["urlname"], "\" id=\"keyid", reader17["Bid"], "\" onclick=\"showWin('", reader16["keyid"], "','", reader17["urlname"], "','", reader17["url"], "','", reader17["openkey"], "')\"><img src=\"/Images/desktopIOC/", reader17["bigpic"], "\" /><br /><div  class=\"icon-text\"><span>", 
                                        reader17["urlname"], "</span></div></li>"
                                     });
                                }
                            }
                            reader17.Close();
                            reader17.Dispose();
                        }
                        else if (reader16["leixing"].ToString() == "2")
                        {
                            string str21 = string.Concat(new object[] { "select B.[name], B.[urlname], B.[pic], B.[id] as Bid from qp_oa_OtherMenu as [B] where  [B].[Id]='", reader16["keyid"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                            SqlDataReader reader18 = this.List.GetList(str21);
                            if (reader18.Read())
                            {
                                if (reader18["urlname"].ToString().IndexOf("?") > 0)
                                {
                                    obj2 = bag["myurl4"];
                                    (bag = this.ViewState)["myurl4"] = string.Concat(new object[] { obj2, "<li title=\"", reader18["name"], "\" id=\"kzkeyid", reader18["Bid"], "5322\" onclick=\"showWin('", reader16["keyid"], "5322','", reader18["name"], "','", reader18["urlname"], "','0')\"><img src=\"/Images/desktopIOC/", reader18["pic"], "\" /><br /><div  class=\"icon-text\"><span>", reader18["name"], "</span></div></li>" });
                                }
                                else
                                {
                                    obj2 = bag["myurl4"];
                                    (bag = this.ViewState)["myurl4"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader18["name"], "\" id=\"kzkeyid", reader18["Bid"], "5322\" onclick=\"showWin('", reader16["keyid"], "5322','", reader18["name"], "','", reader18["urlname"], "?p=", reader16["keyid"], "5322','0')\"><img src=\"/Images/desktopIOC/", reader18["pic"], "\" /><br /><div  class=\"icon-text\"><span>", 
                                        reader18["name"], "</span></div></li>"
                                     });
                                }
                            }
                            reader18.Close();
                            reader18.Dispose();
                        }
                        else if (reader16["leixing"].ToString() == "3")
                        {
                            string str22 = string.Concat(new object[] { "select B.[name], B.[pic], B.[id] as Bid from qp_oa_Menhu as [B] where  [B].[Id]='", reader16["keyid"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                            SqlDataReader reader19 = this.List.GetList(str22);
                            if (reader19.Read())
                            {
                                obj2 = bag["myurl4"];
                                (bag = this.ViewState)["myurl4"] = string.Concat(new object[] { obj2, "<li title=\"", reader19["name"], "\" id=\"mhkeyid", reader19["Bid"], "92222\" onclick=\"showWin('", reader16["keyid"], "92222','", reader19["name"], "','JqMain/Main.aspx?p=12&id=", reader19["Bid"], "','0')\"><img src=\"/Images/desktopIOC/", reader19["pic"], "\" /><br /><div  class=\"icon-text\"><span>", reader19["name"], "</span></div></li>" });
                            }
                            reader19.Close();
                            reader19.Dispose();
                        }
                    }
                    reader16.Close();
                    reader16.Dispose();
                    (bag = this.ViewState)["myurl4"] = bag["myurl4"] + "<li onclick=\"addli()\"><img src=\"/Images/desktopIOC/add.png\" /><br /><div class=\"icon-text\"><span>添加</span></div></li>";
                    string str23 = "select A.* from [qp_oa_MyUrl] as [A] where Username='" + this.Session["username"] + "' and menhu='5'  order by A.paixun desc";
                    SqlDataReader reader20 = this.List.GetList(str23);
                    while (reader20.Read())
                    {
                        if (reader20["leixing"].ToString() == "1")
                        {
                            string str24 = string.Concat(new object[] { "select B.[urlname], B.[url], B.[chuangzhi], B.[bigpic], B.[openkey], B.[id] as Bid from qp_oa_AllUrl as [B] where  [B].[Id]='", reader20["keyid"], "' and (CHARINDEX(''+B.quanxian+'','", str4, "')   >   0 )   and B.xianshi='1'" });
                            SqlDataReader reader21 = this.List.GetList(str24);
                            if (reader21.Read())
                            {
                                if (reader21["chuangzhi"].ToString() == "0")
                                {
                                    obj2 = bag["myurl5"];
                                    (bag = this.ViewState)["myurl5"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader21["urlname"], "\" id=\"keyid", reader21["Bid"], "\" onclick=\"showWin('", reader20["keyid"], "','", reader21["urlname"], "','", reader21["url"], "?p=", reader20["keyid"], "','", reader21["openkey"], "')\"><img src=\"/Images/desktopIOC/", 
                                        reader21["bigpic"], "\" /><br /><div  class=\"icon-text\"><span>", reader21["urlname"], "</span></div></li>"
                                     });
                                }
                                else
                                {
                                    obj2 = bag["myurl5"];
                                    (bag = this.ViewState)["myurl5"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader21["urlname"], "\" id=\"keyid", reader21["Bid"], "\" onclick=\"showWin('", reader20["keyid"], "','", reader21["urlname"], "','", reader21["url"], "','", reader21["openkey"], "')\"><img src=\"/Images/desktopIOC/", reader21["bigpic"], "\" /><br /><div  class=\"icon-text\"><span>", 
                                        reader21["urlname"], "</span></div></li>"
                                     });
                                }
                            }
                            reader21.Close();
                            reader21.Dispose();
                        }
                        else if (reader20["leixing"].ToString() == "2")
                        {
                            string str25 = string.Concat(new object[] { "select B.[name], B.[urlname], B.[pic], B.[id] as Bid from qp_oa_OtherMenu as [B] where  [B].[Id]='", reader20["keyid"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                            SqlDataReader reader22 = this.List.GetList(str25);
                            if (reader22.Read())
                            {
                                if (reader22["urlname"].ToString().IndexOf("?") > 0)
                                {
                                    obj2 = bag["myurl5"];
                                    (bag = this.ViewState)["myurl5"] = string.Concat(new object[] { obj2, "<li title=\"", reader22["name"], "\" id=\"kzkeyid", reader22["Bid"], "5322\" onclick=\"showWin('", reader20["keyid"], "5322','", reader22["name"], "','", reader22["urlname"], "','0')\"><img src=\"/Images/desktopIOC/", reader22["pic"], "\" /><br /><div  class=\"icon-text\"><span>", reader22["name"], "</span></div></li>" });
                                }
                                else
                                {
                                    obj2 = bag["myurl5"];
                                    (bag = this.ViewState)["myurl5"] = string.Concat(new object[] { 
                                        obj2, "<li title=\"", reader22["name"], "\" id=\"kzkeyid", reader22["Bid"], "5322\" onclick=\"showWin('", reader20["keyid"], "5322','", reader22["name"], "','", reader22["urlname"], "?p=", reader20["keyid"], "5322','0')\"><img src=\"/Images/desktopIOC/", reader22["pic"], "\" /><br /><div  class=\"icon-text\"><span>", 
                                        reader22["name"], "</span></div></li>"
                                     });
                                }
                            }
                            reader22.Close();
                            reader22.Dispose();
                        }
                        else if (reader20["leixing"].ToString() == "3")
                        {
                            string str26 = string.Concat(new object[] { "select B.[name], B.[pic], B.[id] as Bid from qp_oa_Menhu as [B] where  [B].[Id]='", reader20["keyid"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
                            SqlDataReader reader23 = this.List.GetList(str26);
                            if (reader23.Read())
                            {
                                obj2 = bag["myurl5"];
                                (bag = this.ViewState)["myurl5"] = string.Concat(new object[] { obj2, "<li title=\"", reader23["name"], "\" id=\"mhkeyid", reader23["Bid"], "92222\" onclick=\"showWin('", reader20["keyid"], "92222','", reader23["name"], "','JqMain/Main.aspx?p=12&id=", reader23["Bid"], "','0')\"><img src=\"/Images/desktopIOC/", reader23["pic"], "\" /><br /><div  class=\"icon-text\"><span>", reader23["name"], "</span></div></li>" });
                            }
                            reader23.Close();
                            reader23.Dispose();
                        }
                    }
                    reader20.Close();
                    reader20.Dispose();
                    (bag = this.ViewState)["myurl5"] = bag["myurl5"] + "<li onclick=\"addli()\"><img src=\"/Images/desktopIOC/add.png\" /><br /><div class=\"icon-text\"><span>添加</span></div></li>";
                    this.ViewState["dburl"] = "";
                    string str27 = "select leixing,urlname,Class,openkey from qp_oa_AllUrl where (CHARINDEX(''+quanxian+'','" + this.Session["perstr"] + "')   >   0 ) and ParentNodesID=0 order by paixu asc";
                    SqlDataReader reader24 = this.List.GetList(str27);
                    while (reader24.Read())
                    {
                        obj2 = bag["dburl"];
                        (bag = this.ViewState)["dburl"] = string.Concat(new object[] { obj2, "<li class=\"", reader24["Class"], "\" onclick=\"showWin('", reader24["leixing"], "','", reader24["urlname"], "','JqMain/Main.aspx?p=", reader24["leixing"], "','", reader24["openkey"], "')\">", reader24["urlname"], "</li>" });
                    }
                    reader24.Close();
                    reader24.Dispose();
                    (bag = this.ViewState)["dburl"] = bag["dburl"] + "<li class=\"fgx\"></li>";
                    this.Session["yangshi"] = this.pulicss.Getyangshi();
                    string str28 = "select Logos,Titles,Geyan from qp_oa_FaceMade";
                    SqlDataReader reader25 = this.List.GetList(str28);
                    if (reader25.Read())
                    {
                        this.ViewState["Logos"] = reader25["Logos"].ToString();
                        this.Session["Titles"] = reader25["Titles"].ToString();
                        if (reader25["Geyan"].ToString().Trim() != "")
                        {
                            this.ViewState["Geyan"] = "  -  " + reader25["Geyan"].ToString() + "";
                        }
                    }
                    reader25.Close();
                    reader25.Dispose();
                    string str29 = "select * from qp_oa_FjKey";
                    SqlDataReader reader26 = this.List.GetList(str29);
                    if (reader26.Read())
                    {
                        this.Session["FjKey"] = reader26["content"].ToString();
                    }
                    reader26.Dispose();
                    reader26.Close();
                    this.Label1.Text = "<iframe marginwidth=\"0\" marginheight=\"0\" src=\"CountMessageNew.aspx\" frameborder=\"0\" width=\"0\" height=\"0\" scrolling=\"auto\"></iframe><div id=\"bg_DIV_img\"></div><div id=\"bg_DIV_img_zhe\"></div><div class=\"tixing\" id=\"msgtx\" onmousedown=\"dreag('msgtx')\"><img src=\"/oaimg/sc.png\" onclick=\"msgdel('1')\" style=\"cursor: pointer;\" title=\"删除全部未读消息\"/>&nbsp;&nbsp;<img src=\"/oaimg/yy.png\" onclick=\"msgdel('0')\" style=\"cursor: pointer;\" title=\"已阅全部未读消息\"/>&nbsp;&nbsp;<a onclick=\"showWin('14','内部消息','JqMain/Main.aspx?p=14','0')\" style=\"cursor: pointer;\"><font color=\"#ffffff\">提醒：有新短息，点击查看！</font></a></div>";
                  //  if (this.ViewState["reginfo"].ToString() == "2")
                    {
                   //     this.Label2.Text = string.Concat(new object[] { 
                    //        "<div id=\"winParent\" class=\"zod\"><div class=\"toppng\" id=\"menhupic\" onmousedown=\"dreag('menhupic')\"><img src=\"/Images/topurl1a.png\" id=\"Menhu1\" onclick=\"menhu('1')\" style=\"cursor: pointer;_*behavior: url(/Script/ie6pan/iepngfix.htc);\" /><img src=\"/Images/topurl2b.png\" id=\"Menhu2\" onclick=\"menhu('2')\" style=\"cursor: pointer;_*behavior: url(/Script/ie6pan/iepngfix.htc);\" /><img src=\"/Images/topurl3b.png\" id=\"Menhu3\" onclick=\"menhu('3')\" style=\"cursor: pointer;_*behavior: url(/Script/ie6pan/iepngfix.htc);\" /><img src=\"/Images/topurl4b.png\" id=\"Menhu4\" onclick=\"menhu('4')\" style=\"cursor: pointer;_*behavior: url(/Script/ie6pan/iepngfix.htc);\" /><img src=\"/Images/topurl5b.png\" id=\"Menhu5\" onclick=\"menhu('5')\" style=\"cursor: pointer;_*behavior: url(/Script/ie6pan/iepngfix.htc);\" /><img src=\"/Images/bj.png\" id=\"Img1\" onclick=\"addli()\" style=\"cursor: pointer;_*behavior: url(/Script/ie6pan/iepngfix.htc);\" title=\"桌面栏目\"/><img src=\"/Images/add.png\" id=\"Img1\" onclick=\"showWin('5432185','主题设置','MyWork/MySet/BeijingXt.aspx?p=5432185','0')\" style=\"cursor: pointer;_*behavior: url(/Script/ie6pan/iepngfix.htc);\" title=\"主题设置\"/><img src=\"/Images/db.png\" id=\"Img1\" onclick=\"dbsyset()\" style=\"cursor: pointer;_*behavior: url(/Script/ie6pan/iepngfix.htc);\" title=\"待办事宜\" /></div><div class=\"footpng\" id=\"Div1\"><ul class=\"foot_caidan\" id=\"Ul1\"><li onclick=\"window.location.href = 'main.aspx'\"><img src=\"/Images/desktopIOC/OM.png\" width=\"65px\" height=\"65px\" /><br />切换风格</li><li onclick=\"showWin('532291221','组织机构','JqMain/Main.aspx?p=13','0')\"><img src=\"/Images/desktopIOC/wdkh.png\" width=\"65px\" height=\"65px\" /><br />组织架构</li><li onclick=\"showWin('553423','内部消息','JqMain/Main.aspx?p=15','0')\"><img src=\"/Images/desktopIOC/bbs.png\" width=\"65px\" height=\"65px\" /><br />内部消息</li><li onclick=\"showWin('547894','修改密码','MyWork/MySet/Syspassword.aspx?p=547894','0')\"><img src=\"/Images/desktopIOC/sys.png\" width=\"65px\" height=\"65px\" /><br />修改密码</li><li onclick=\"showWin('1123421','在线帮助','help/help.aspx?p=1123421','0')\"><img src=\"/Images/desktopIOC/contract.png\" width=\"65px\" height=\"65px\" /><br />在线帮助</li><li onclick=\"location.href = location.href;\"><img src=\"/Images/desktopIOC/FM.png\" width=\"65px\" height=\"65px\" /><br />刷新页面</li><li onclick=\"loginout()\"><img src=\"/Images/desktopIOC/sjdx.png\" width=\"65px\" height=\"65px\" /><br />退出系统</li></ul></div><ul class=\"zm_caidan\" id=\"desk1\">", this.ViewState["myurl"].ToString(), "</ul><ul class=\"zm_caidan\" id=\"desk2\" style=\"display: none;\">", this.ViewState["myurl2"].ToString(), "</ul> <ul class=\"zm_caidan\" id=\"desk3\" style=\"display: none;\">", this.ViewState["myurl3"].ToString(), "</ul><ul class=\"zm_caidan\" id=\"desk4\" style=\"display: none;\">", this.ViewState["myurl4"].ToString(), "</ul><ul class=\"zm_caidan\" id=\"desk5\" style=\"display: none;\">", this.ViewState["myurl5"].ToString(), "</ul></div><div id=\"taskbarDiv\"><div id=\"Start\" style=\"cursor: pointer;_*behavior: url(/Script/ie6pan/iepngfix.htc);\"><b>功能菜单</b></div><div id=\"delcin\" class=\"kjfs\"><ul>", this.ViewState["dburl"], "<li class=\"zmlm\" onclick=\"dbsyset()\">待办事宜</li><li class=\"zmmh\" onclick=\"addli()\">桌面栏目</li><li class=\"zmbj\" onclick=\"showWin('5432185','个性背景','MyWork/MySet/BeijingXt.aspx?p=5432185','0')\">主题设置</li><li class=\"fgx\"></li><li class=\"cpwd\" onclick=\"showWin('547894','修改密码','MyWork/MySet/Syspassword.aspx?p=547894','0')\">修改密码</li><li class=\"help\" onclick=\"showWin('1123421','在线帮助','help/help.aspx?p=1123421','0')\">在线帮助</li><li class=\"qiehuan\" onclick=\"window.location.href = 'main.aspx'\">切换为经典界面</li><li class=\"aexit\" onclick=\"loginout()\">退出系统</li><li class=\"zhuce\" onclick=\"alert('当前版未正式注册，", this.Session["cdk1"].ToString(), "使用期限：", this.Session["cdk3"].ToString(), 
                    //        "')\">注册信息</li></ul></div><div id=\"sumian\" title=\"显示桌面\" style=\"cursor: pointer; background-image: url(/Images/desktop.png);background-repeat: no-repeat; background-position: center center;_*behavior: url(/Script/ie6pan/iepngfix.htc);\" onclick=\"saa()\"></div><div id=\"zhuzhi\" title=\"组织机构\" style=\"cursor: pointer; background-image: url(/Images/zxjg.png);background-repeat: no-repeat; background-position: center center;_*behavior: url(/Script/ie6pan/iepngfix.htc);\" onclick=\"showWin('532291221','组织机构','JqMain/Main.aspx?p=13','0')\"></div><div id=\"xiaoxi\" title=\"内部消息\" style=\"cursor: pointer; background-image: url(/Images/nbxx.png);background-repeat: no-repeat; background-position: center center;_*behavior: url(/Script/ie6pan/iepngfix.htc);\" onclick=\"showWin('553423','内部消息','JqMain/Main.aspx?p=15','0')\"></div><div id=\"Ctaskbar\"></div><div id=\"otherMenu\"><iframe marginwidth=\"0\" id=\"infotx\" marginheight=\"0\" src=\"CountMessageJq.aspx\" frameborder=\"0\" width=\"0\" height=\"0\" scrolling=\"auto\"></iframe> </div></div><noscript><iframe src=\"*.htm\"></iframe></noscript>"
                    //     });
                    }
                //    else
                    {
                        this.Label2.Text = string.Concat(new object[] { 
                            "<div id=\"winParent\" class=\"zod\"><div class=\"toppng\" id=\"menhupic\" onmousedown=\"dreag('menhupic')\"><img src=\"/Images/topurl1a.png\" id=\"Menhu1\" onclick=\"menhu('1')\" style=\"cursor: pointer;\" /><img src=\"/Images/topurl2b.png\" id=\"Menhu2\" onclick=\"menhu('2')\" style=\"cursor: pointer;\" /><img src=\"/Images/topurl3b.png\" id=\"Menhu3\" onclick=\"menhu('3')\" style=\"cursor: pointer;\" /><img src=\"/Images/topurl4b.png\" id=\"Menhu4\" onclick=\"menhu('4')\" style=\"cursor: pointer;\" /><img src=\"/Images/topurl5b.png\" id=\"Menhu5\" onclick=\"menhu('5')\" style=\"cursor: pointer;\" /><img src=\"/Images/bj.png\" id=\"Img1\" onclick=\"addli()\" style=\"cursor: pointer;\" title=\"桌面栏目\"/><img src=\"/Images/add.png\" id=\"Img1\" onclick=\"showWin('5432185','主题设置','MyWork/MySet/BeijingXt.aspx?p=5432185','0')\" style=\"cursor: pointer;\" title=\"主题设置\"/><img src=\"/Images/db.png\" id=\"Img1\" onclick=\"dbsyset()\" style=\"cursor: pointer;\" title=\"待办事宜\" /></div><div class=\"footpng\" id=\"Div1\"><ul class=\"foot_caidan\" id=\"Ul1\"><li onclick=\"window.location.href = 'main.aspx'\"><img src=\"/Images/desktopIOC/OM.png\" width=\"65px\" height=\"65px\" /><br />切换风格</li><li onclick=\"showWin('532291221','组织机构','JqMain/Main.aspx?p=13','0')\"><img src=\"/Images/desktopIOC/wdkh.png\" width=\"65px\" height=\"65px\" /><br />组织架构</li><li onclick=\"showWin('553423','内部消息','JqMain/Main.aspx?p=15','0')\"><img src=\"/Images/desktopIOC/bbs.png\" width=\"65px\" height=\"65px\" /><br />内部消息</li><li onclick=\"showWin('547894','修改密码','MyWork/MySet/Syspassword.aspx?p=547894','0')\"><img src=\"/Images/desktopIOC/sys.png\" width=\"65px\" height=\"65px\" /><br />修改密码</li><li onclick=\"showWin('1123421','在线帮助','help/help.aspx?p=1123421','0')\"><img src=\"/Images/desktopIOC/contract.png\" width=\"65px\" height=\"65px\" /><br />在线帮助</li><li onclick=\"location.href = location.href;\"><img src=\"/Images/desktopIOC/FM.png\" width=\"65px\" height=\"65px\" /><br />刷新页面</li><li onclick=\"loginout()\"><img src=\"/Images/desktopIOC/sjdx.png\" width=\"65px\" height=\"65px\" /><br />退出系统</li></ul></div><ul class=\"zm_caidan\" id=\"desk1\">", this.ViewState["myurl"].ToString(), "</ul><ul class=\"zm_caidan\" id=\"desk2\" style=\"display: none;\">", this.ViewState["myurl2"].ToString(), "</ul> <ul class=\"zm_caidan\" id=\"desk3\" style=\"display: none;\">", this.ViewState["myurl3"].ToString(), "</ul><ul class=\"zm_caidan\" id=\"desk4\" style=\"display: none;\">", this.ViewState["myurl4"].ToString(), "</ul><ul class=\"zm_caidan\" id=\"desk5\" style=\"display: none;\">", this.ViewState["myurl5"].ToString(), "</ul></div><div id=\"taskbarDiv\"><div id=\"Start\" style=\"cursor: pointer;_*behavior: url(/Script/ie6pan/iepngfix.htc);\"><b>功能菜单</b></div><div id=\"delcin\" class=\"kjfs\"><ul>", this.ViewState["dburl"], "<li class=\"zmlm\" onclick=\"dbsyset()\">待办事宜</li><li class=\"zmmh\" onclick=\"addli()\">桌面栏目</li><li class=\"zmbj\" onclick=\"showWin('5432185','个性背景','MyWork/MySet/BeijingXt.aspx?p=5432185','0')\">主题设置</li><li class=\"fgx\"></li><li class=\"cpwd\" onclick=\"showWin('547894','修改密码','MyWork/MySet/Syspassword.aspx?p=547894','0')\">修改密码</li><li class=\"help\" onclick=\"showWin('1123421','在线帮助','help/help.aspx?p=1123421','0')\">在线帮助</li><li class=\"qiehuan\" onclick=\"window.location.href = 'main.aspx'\">切换为经典界面</li><li class=\"aexit\" onclick=\"loginout()\">退出系统</li></ul></div><div id=\"sumian\" title=\"显示桌面\" style=\"cursor: pointer; background-image: url(/Images/desktop.png);background-repeat: no-repeat; background-position: center center;\" onclick=\"saa()\"></div><div id=\"zhuzhi\" title=\"组织机构\" style=\"cursor: pointer; background-image: url(/Images/zxjg.png);background-repeat: no-repeat; background-position: center center;\" onclick=\"showWin('532291221','组织机构','JqMain/Main.aspx?p=13','0')\"></div><div id=\"xiaoxi\" title=\"内部消息\" style=\"cursor: pointer; background-image: url(/Images/nbxx.png);background-repeat: no-repeat; background-position: center center;\" onclick=\"showWin('553423','内部消息','JqMain/Main.aspx?p=15','0')\"></div><div id=\"Ctaskbar\"></div><div id=\"otherMenu\"><iframe marginwidth=\"0\" id=\"infotx\" marginheight=\"0\" src=\"CountMessagejs.aspx\" frameborder=\"0\" width=\"0\" height=\"0\" scrolling=\"auto\"></iframe> </div></div><noscript><iframe src=\"*.htm\"></iframe></noscript>"
                         });
                    }
                    this.ViewState["js"] = "<script type=\"text/javascript\"> alie(); hoverUlLi(); msgdel('2');var loadingjs_sf = true; </script>";
                }
            }
        }
    }
}

