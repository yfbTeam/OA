namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class xiaolei_wt : UserControl
    {
        protected Label dalei;
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                string sql = "select Name from qp_oa_Zst_leibie_wt  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["ParentNodesID"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Name"] = list["Name"].ToString();
                }
                list.Close();
                this.dalei.Text = null;
                int num = 0;
                this.dalei.Text = this.dalei.Text + "<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"6\"><tr>";
                string str2 = string.Concat(new object[] { "select id,Name,Paixun,ParentNodesID from qp_oa_Zst_leibie_wt where ParentNodesID='", this.pulicss.GetFormatStr(base.Request.QueryString["ParentNodesID"]), "' and  ((CHARINDEX(',", base.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", base.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')) order by Paixun asc" });
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    string str3 = "select count(id) from qp_oa_Zst_wenti  where Leibie='" + reader2["id"] + "'";
                    string str4 = "" + this.List.GetCount(str3) + "";
                    object text = this.dalei.Text;
                    this.dalei.Text = string.Concat(new object[] { text, "<td width=\"20%\"> <img src=\"/oaimg/JianTou.gif\" width=\"13\" height=\"13\" border=\"0\"><a href=\"wenti_xiaolei.aspx?ParentNodesID=", reader2["ParentNodesID"], "&id=", reader2["id"], "\"><font color=\"#261CDC\" style=\"font-size: 14px;\">", reader2["name"], "</font></a><font color=\"#393939\" style=\"font-size: 14px;\">(", str4, ")</font></td>" });
                    num++;
                    if (num == 5)
                    {
                        this.dalei.Text = this.dalei.Text + "</tr><tr>";
                        num = 0;
                    }
                }
                reader2.Close();
                this.dalei.Text = this.dalei.Text + " </table>";
            }
        }
    }
}

