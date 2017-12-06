namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;

    public class MyPage_wt_show_yc : Page
    {
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.close();</script>");
            }
            else if (this.Session["username"].ToString() == "admin")
            {
                string sql = "select * from qp_oa_Zst_huida   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str3;
                    string str2 = string.Concat(new object[] { "Update qp_oa_username  Set jifen=jifen", this.pulicss.JifenGuize("被隐藏回答"), "  where username='", list["username"], "'" });
                    this.List.ExeSql(str2);
                    if (list["Yincang"].ToString() == "1")
                    {
                        str3 = "Update qp_oa_Zst_huida  Set  Yincang='2' where id='" + int.Parse(base.Request.QueryString["id"]) + "'";
                        this.List.ExeSql(str3);
                        base.Response.Write("<script language=javascript>alert('隐藏成功，重新打开页面可看见效果！');window.close();</script>");
                    }
                    else
                    {
                        str3 = "Update qp_oa_Zst_huida  Set  Yincang='1' where id='" + int.Parse(base.Request.QueryString["id"]) + "'";
                        this.List.ExeSql(str3);
                        base.Response.Write("<script language=javascript>alert('显示成功，重新打开页面可看见效果！');window.close();</script>");
                    }
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('隐藏失败！');window.close();</script>");
                }
                list.Close();
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('只有管理员才能隐藏回答！');window.close();</script>");
            }
        }
    }
}

