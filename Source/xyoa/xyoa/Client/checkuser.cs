namespace xyoa.Client
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.Security;
    using System.Web.UI;

    public class checkuser : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
         //   string sql = "select * from qp_oa_filemain where reg='0' or reg='1' or reg='2'";
         //   SqlDataReader reader = this.List.GetList(sql);
         //   if (reader.Read())
            {
           //     try
                {
            //        string str2 = null;
             //       str2 = this.pulicss.DESDecrypt(reader["cdkstr"].ToString(), "5", "6");
             //       ArrayList list = new ArrayList();
             //       string[] strArray = str2.Split(new char[] { '^' });
              //      for (int i = 0; i < strArray.Length; i++)
                    {
              //          this.Session["cdk1"] = strArray[0];
              //          this.Session["cdk2"] = strArray[1];
               //         this.Session["cdk3"] = strArray[2];
                //        this.Session["cdk4"] = strArray[3];
                //        this.Session["cdk5"] = strArray[4];
                    }
                }
            //    catch
                {
           //         return;
                }
            //    reader.Close();
            //    if (("" + this.pulicss.GetMAC() + "") != this.Session["cdk2"].ToString())
                {
           //         base.Response.Write("<script>alert('软件绑定的机器码不正确，请联系软件供应商！');window.location.href='Default.aspx'</Script>");
                }
            //    else
                {
                //    if (this.Session["cdk3"].ToString() != "1900-01-01")
                    {
                //        TimeSpan span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToShortDateString()) - DateTime.Parse(this.Session["cdk3"].ToString()));
                 //       if (span.TotalDays > 0.0)
                        {
                  //          return;
                        }
                    }
                    if ((base.Request.QueryString["user"] != null) && (base.Request.QueryString["pwd"] != null))
                    {
                        string str3 = FormsAuthentication.HashPasswordForStoringInConfigFile(base.Request.QueryString["pwd"].ToString(), "MD5");
                        string str4 = "select id from qp_oa_username where Username='" + base.Request.QueryString["user"] + "' and Password='" + str3 + "'and Iflogin='1' and ifdel='0'";
                        SqlDataReader reader2 = this.List.GetList(str4);
                        if (reader2.Read())
                        {
                            string str5 = "Update qp_oa_username Set lasttime='" + DateTime.Now.ToString() + "',onlinetime=onlinetime+10  where username='" + base.Request.QueryString["user"] + "'";
                            this.List.ExeSql(str5);
                            base.Response.Write("1");
                        }
                        else
                        {
                            base.Response.Write("0");
                        }
                        reader2.Close();
                    }
                }
            }
        }
    }
}

