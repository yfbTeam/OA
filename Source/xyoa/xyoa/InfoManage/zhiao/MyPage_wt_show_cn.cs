namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class MyPage_wt_show_cn : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.close();</script>");
            }
            else
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_Zst_wenti   where id='", this.pulicss.GetFormatStr(base.Request.QueryString["WentiId"]), "' and  Username='", this.Session["Username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = string.Concat(new object[] { "Update qp_oa_Zst_wenti  Set  jiejue='1' where id='", int.Parse(base.Request.QueryString["WentiId"]), "'  and Username='", this.Session["Username"], "'  " });
                    this.List.ExeSql(str2);
                    string str3 = "Update qp_oa_Zst_huida  Set  Zuijia='1' where id='" + int.Parse(base.Request.QueryString["id"]) + "'";
                    this.List.ExeSql(str3);
                    string str4 = "select Username from qp_oa_Zst_huida   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader reader2 = this.List.GetList(str4);
                    if (reader2.Read())
                    {
                        string str5 = string.Concat(new object[] { "Update qp_oa_username  Set jifen=jifen", this.pulicss.JifenGuize("采纳为最佳答案"), "  where username='", reader2["username"], "'" });
                        this.List.ExeSql(str5);
                    }
                    reader2.Close();
                    base.Response.Write("<script language=javascript>alert('采纳成功，重新打开页面可看见效果！');window.close();</script>");
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('采纳失败！');window.close();</script>");
                }
                list.Close();
            }
        }
    }
}

