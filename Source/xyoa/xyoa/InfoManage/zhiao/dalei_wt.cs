namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class dalei_wt : UserControl
    {
        protected Label dalei;
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.dalei.Text = null;
            int num = 0;
            this.dalei.Text = this.dalei.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"6\"><tr>";
            string sql = string.Concat(new object[] { "select id,Name,Paixun from qp_oa_Zst_leibie_wt where ParentNodesID=0 and  ((CHARINDEX(',", base.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", base.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')) order by Paixun asc" });
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                object text;
                string str2 = null;
                string str3 = "select id from qp_oa_Zst_leibie_wt where ParentNodesID='" + list["id"] + "'";
                SqlDataReader reader2 = this.List.GetList(str3);
                while (reader2.Read())
                {
                    text = str2;
                    str2 = string.Concat(new object[] { text, "", reader2["id"], "," });
                }
                reader2.Close();
                string str4 = "select count(id) from qp_oa_Zst_wenti  where Leibie in (" + str2 + "0)";
                string str5 = "" + this.List.GetCount(str4) + "";
                text = this.dalei.Text;
                this.dalei.Text = string.Concat(new object[] { text, "<td width=\"20%\"> <img src=\"/oaimg/JianTou.gif\" width=\"13\" height=\"13\" border=\"0\"><a href=\"wenti_xiaolei.aspx?ParentNodesID=", list["id"], "&id=0\"><font color=\"#261CDC\" style=\"font-size: 14px;\">", list["name"], "</font></a><font color=\"#393939\" style=\"font-size: 14px;\">(", str5, ")</font></td>" });
                num++;
                if (num == 5)
                {
                    this.dalei.Text = this.dalei.Text + "</tr><tr>";
                    num = 0;
                }
            }
            list.Close();
            this.dalei.Text = this.dalei.Text + " </table>";
        }
    }
}

