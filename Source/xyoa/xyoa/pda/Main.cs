namespace xyoa.pda
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;

    public class Main : Page
    {
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Redirect("/pda/default.aspx");
            }
            if (!this.Page.IsPostBack)
            {
             //   string sql = "select * from qp_oa_filemain where reg='0' or reg='1' or reg='2'";
             //   SqlDataReader reader = this.List.GetList(sql);
             //   if (reader.Read())
                {
              //      try
                    {
                //        string str2 = null;
                 //       str2 = this.pulicss.DESDecrypt(reader["cdkstr"].ToString(), "5", "6");
                 //       ArrayList list = new ArrayList();
                  //      string[] strArray = str2.Split(new char[] { '^' });
                  //      for (int i = 0; i < strArray.Length; i++)
                        {
                   //         this.Session["cdk1"] = strArray[0];
                   //         this.Session["cdk2"] = strArray[1];
                   //         this.Session["cdk3"] = strArray[2];
                   //         this.Session["cdk4"] = strArray[3];
                   //         this.Session["cdk5"] = strArray[4];
                   //         this.Session["baben"] = strArray[5];
                    //        this.Session["yidong"] = strArray[6];
                   //         this.Session["duanxin"] = strArray[7];
                        }
                    }
                 //   catch
                    {
                 //       base.Response.Redirect("log.aspx?str=您的注册码无效！");
                 //       return;
                    }
                //    if (reader["reg"].ToString() == "2")
                    {
                  //      if (this.Session["cdk3"].ToString() == "1900-01-01")
                        {
                  //          this.ViewState["qixian"] = "无限期";
                        }
                 //       else
                        {
                    //        this.ViewState["qixian"] = this.Session["cdk3"].ToString();
                        }
                   //     if (int.Parse(this.Session["cdk4"].ToString()) >= 500)
                        {
                    //        this.ViewState["yonghu"] = "无限制";
                        }
                   //     else
                        {
                    //        this.ViewState["yonghu"] = this.Session["cdk4"].ToString();
                        }
                    }
                 //   reader.Close();
                    this.ViewState["HeadName"] = base.Request.QueryString["leixing"].ToString().Replace("1", "OA移动平台").Replace("2", "销售移动平台").Replace("3", "工程移动平台");
                    this.ViewState["footulr"] = this.pulicss.pdafoot("Main.aspx?leixing=" + base.Request.QueryString["leixing"] + "");
               //     if (this.Session["yidong"].ToString() == "1")
                    {
                        string str3 = string.Concat(new object[] { "select * from qp_pda_url where leixing='", base.Request.QueryString["leixing"], "'  and id in (", this.pulicss.pdamain("" + base.Request.QueryString["leixing"].ToString().Replace("1", "OALm").Replace("2", "CRMLm").Replace("3", "PMLm") + ""), ")  and CHARINDEX(quanxian,'", this.Session["perstr"], "') > 0  order by paixu asc" });
                        SqlDataReader reader2 = this.List.GetList(str3);
                        while (reader2.Read())
                        {
                            StateBag bag = ViewState;
                            object obj2;
                            if (this.pulicss.Daibanshiyi(reader2["TjName"].ToString()) != "0")
                            {
                                obj2 = bag["pdaurl"];
                                (bag = this.ViewState)["pdaurl"] = string.Concat(new object[] { obj2, "<li><span>", this.pulicss.Daibanshiyi(reader2["TjName"].ToString()), "</span><a href=\"javascript:void(0)\" onclick=\"LoadingShow();location.href='", reader2["Url"], "';\"><img title=\"", reader2["Name"], "\" border=\"0\" alt=\"", reader2["Name"], "\" src=\"images/", reader2["tupian"], "\">", reader2["Name"], "</a></li>" });
                            }
                            else
                            {
                                obj2 = bag["pdaurl"];
                                (bag = this.ViewState)["pdaurl"] = string.Concat(new object[] { obj2, "<li><a href=\"javascript:void(0)\" onclick=\"LoadingShow();location.href='", reader2["Url"], "';\"><img title=\"", reader2["Name"], "\" border=\"0\" alt=\"", reader2["Name"], "\" src=\"images/", reader2["tupian"], "\">", reader2["Name"], "</a></li>" });
                            }
                        }
                        reader2.Close();
                    }
                //    else
                    {
                //        this.ViewState["pdaurl"] = "未开通移动平台";
                    }
                }
            //    else
                {
             //       reader.Close();
             //       base.Response.Redirect("log.aspx?str=您的注册码无效！");
                }
            }
        }
    }
}

