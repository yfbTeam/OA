namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class right : UserControl
    {
        private Db List = new Db();
        protected Label paihang;
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            string str2;
            SqlDataReader reader2;
            string sql = "select jifen from qp_oa_username where  username='" + base.Session["username"] + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ViewState["jifen"] = list["jifen"].ToString();
                str2 = string.Concat(new object[] { "select dengji from qp_oa_Zst_dengji where  ", list["jifen"], ">=Fenshu1 and  ", list["jifen"], "<=Fenshu2" });
                reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.ViewState["dengji"] = "<img src='/InfoManage/zhiao/img/d_" + reader2["dengji"] + ".gif' />";
                }
                else
                {
                    this.ViewState["dengji"] = "无等级";
                }
                reader2.Close();
            }
            list.Close();
            this.paihang.Text = null;
            int num = 0;
            this.paihang.Text = this.paihang.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">";
            string str3 = "select top 18 jifen,username,realname from qp_oa_username where ifdel=0 order by jifen desc";
            SqlDataReader reader3 = this.List.GetList(str3);
            while (reader3.Read())
            {
                object text;
                str2 = string.Concat(new object[] { "select dengji from qp_oa_Zst_dengji where  ", reader3["jifen"], ">=Fenshu1 and  ", reader3["jifen"], "<=Fenshu2" });
                reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    num++;
                    text = this.paihang.Text;
                    this.paihang.Text = string.Concat(new object[] { text, "<tr><td width=\"1%\" height=\"29\"></td><td width=\"97%\" background=\"../../oaimg/zst/dd.jpg\"><table width=\"100%\" height=\"23\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td width=\"32%\">", num, ".<a href='javascript:void(0)' onclick='senduser(\"", reader3["username"], "\")'>", reader3["realname"], "</a></td><td width=\"46%\" valign=\"top\"><img src='/InfoManage/zhiao/img/d_", reader2["dengji"], ".gif' /></td> <td width=\"22%\" align=\"right\">", reader3["jifen"], "</td></tr></table></td><td width=\"2%\">&nbsp;</td></tr>" });
                }
                else
                {
                    num++;
                    text = this.paihang.Text;
                    this.paihang.Text = string.Concat(new object[] { text, "<tr><td width=\"1%\" height=\"29\"></td><td width=\"97%\" background=\"../../oaimg/zst/dd.jpg\"><table width=\"100%\" height=\"23\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"><tr><td width=\"32%\">", num, ".<a href='javascript:void(0)' onclick='senduser(\"", reader3["username"], "\")'>", reader3["realname"], "</a></td><td width=\"46%\" valign=\"top\">无等级</td> <td width=\"22%\" align=\"right\">", reader3["jifen"], "</td></tr></table></td><td width=\"2%\">&nbsp;</td></tr>" });
                }
                reader2.Close();
            }
            reader3.Close();
            this.paihang.Text = this.paihang.Text + "</table>";
        }
    }
}

