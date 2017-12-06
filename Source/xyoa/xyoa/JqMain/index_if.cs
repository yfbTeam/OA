namespace xyoa.JqMain
{
    using qiupeng.form;
    using qiupeng.pm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class index_if : Page
    {
        protected Label daibanshiyi;
        private qiupeng.pm.divpm divpm = new qiupeng.pm.divpm();
        protected HtmlForm form1;
        private Db List = new Db();
        private publics pulicss = new publics();
        private divform showform = new divform();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.daibanshiyi.Text = null;
            this.daibanshiyi.Text = this.daibanshiyi.Text + "<table width=\"265\" border=\"0\" cellspacing=\"0\" cellpadding=\"1\" ><tr>";
            int num = 0;
            string sql = "select * from qp_oa_Daibanshiyi  where CHARINDEX(quanxian,'" + this.Session["perstr"] + "') > 0 order by paixu asc";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                object text;
                try
                {
                    if (int.Parse(this.pulicss.Daibanshiyi(list["Name"].ToString())) > 0)
                    {
                        if (list["chuangzhi"].ToString() == "0")
                        {
                            text = this.daibanshiyi.Text;
                            this.daibanshiyi.Text = string.Concat(new object[] { 
                                text, "<td align=\"center\" height=\"30\" width=\"15\" background=\"/oaimg/zst/dd.png\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\"></td><td background=\"/oaimg/zst/dd.png\" width=\"232\"><a onclick=\"window.top.showWin('", list["keyid"], "','", list["name"], "','", list["url"], "?p=", list["keyid"], "','0')\" style=\"cursor: pointer;\"><font  color=\"#0000FF\">", list["Name"].ToString(), "</font></a>（<a onclick=\"window.top.showWin('", list["keyid"], "','", list["name"], "','", 
                                list["url"], "?p=", list["keyid"], "','0')\" style=\"cursor: pointer;\"><font  color=\"red\">", this.pulicss.Daibanshiyi(list["Name"].ToString()), "</font></a>）</td>"
                             });
                        }
                        else
                        {
                            text = this.daibanshiyi.Text;
                            this.daibanshiyi.Text = string.Concat(new object[] { 
                                text, "<td align=\"center\" height=\"30\" width=\"15\" background=\"/oaimg/zst/dd.png\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\"></td><td background=\"/oaimg/zst/dd.png\" width=\"232\"><a onclick=\"window.top.showWin('", list["keyid"], "','", list["name"], "','", list["url"], "','0')\" style=\"cursor: pointer;\"><font  color=\"#0000FF\">", list["Name"].ToString(), "</font></a>（<a onclick=\"window.top.showWin('", list["keyid"], "','", list["name"], "','", list["url"], "?p=", 
                                list["keyid"], "','0')\" style=\"cursor: pointer;\"><font  color=\"red\">", this.pulicss.Daibanshiyi(list["Name"].ToString()), "</font></a>）</td>"
                             });
                        }
                    }
                    else if (list["chuangzhi"].ToString() == "0")
                    {
                        text = this.daibanshiyi.Text;
                        this.daibanshiyi.Text = string.Concat(new object[] { 
                            text, "<td align=\"center\" height=\"30\" width=\"15\" background=\"/oaimg/zst/dd.png\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\"></td><td background=\"/oaimg/zst/dd.png\" width=\"232\"><a onclick=\"window.top.showWin('", list["keyid"], "','", list["name"], "','", list["url"], "?p=", list["keyid"], "','0')\" style=\"cursor: pointer;\"><font  color=\"#000000\">", list["Name"].ToString(), "</font></a>（<a onclick=\"window.top.showWin('", list["keyid"], "','", list["name"], "','", 
                            list["url"], "?p=", list["keyid"], "','0')\" style=\"cursor: pointer;\"><font  color=\"#000000\">", this.pulicss.Daibanshiyi(list["Name"].ToString()), "</font></a>）</td>"
                         });
                    }
                    else
                    {
                        text = this.daibanshiyi.Text;
                        this.daibanshiyi.Text = string.Concat(new object[] { 
                            text, "<td align=\"center\" height=\"30\" width=\"15\" background=\"/oaimg/zst/dd.png\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\"></td><td background=\"/oaimg/zst/dd.png\" width=\"232\"><a onclick=\"window.top.showWin('", list["keyid"], "','", list["name"], "','", list["url"], "','0')\" style=\"cursor: pointer;\"><font  color=\"#000000\">", list["Name"].ToString(), "</font></a>（<a onclick=\"window.top.showWin('", list["keyid"], "','", list["name"], "','", list["url"], "?p=", 
                            list["keyid"], "','0')\" style=\"cursor: pointer;\"><font  color=\"#000000\">", this.pulicss.Daibanshiyi(list["Name"].ToString()), "</font></a>）</td>"
                         });
                    }
                }
                catch
                {
                    if (list["chuangzhi"].ToString() == "0")
                    {
                        text = this.daibanshiyi.Text;
                        this.daibanshiyi.Text = string.Concat(new object[] { 
                            text, "<td align=\"center\" height=\"30\" width=\"15\" background=\"/oaimg/zst/dd.png\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\"></td><td background=\"/oaimg/zst/dd.png\" width=\"232\"><a onclick=\"window.top.showWin('", list["keyid"], "','", list["name"], "','", list["url"], "?p=", list["keyid"], "','0')\" style=\"cursor: pointer;\"><font  color=\"#000000\">", list["Name"].ToString(), "</font></a>（<a onclick=\"window.top.showWin('", list["keyid"], "','", list["name"], "','", 
                            list["url"], "?p=", list["keyid"], "','0')\" style=\"cursor: pointer;\"><font  color=\"#000000\">", this.pulicss.Daibanshiyi(list["Name"].ToString()), "</font></a>）</td>"
                         });
                    }
                    else
                    {
                        text = this.daibanshiyi.Text;
                        this.daibanshiyi.Text = string.Concat(new object[] { 
                            text, "<td align=\"center\" height=\"30\" width=\"15\" background=\"/oaimg/zst/dd.png\"><img src=\"/oaimg/news.gif\" width=\"15\" height=\"10\"></td><td background=\"/oaimg/zst/dd.png\" width=\"232\"><a onclick=\"window.top.showWin('", list["keyid"], "','", list["name"], "','", list["url"], "','0')\" style=\"cursor: pointer;\"><font  color=\"#000000\">", list["Name"].ToString(), "</font></a>（<a onclick=\"window.top.showWin('", list["keyid"], "','", list["name"], "','", list["url"], "?p=", 
                            list["keyid"], "','0')\" style=\"cursor: pointer;\"><font  color=\"#000000\">", this.pulicss.Daibanshiyi(list["Name"].ToString()), "</font></a>）</td>"
                         });
                    }
                }
                num++;
                if (num == 2)
                {
                    this.daibanshiyi.Text = this.daibanshiyi.Text + " </tr><tr>";
                    num = 0;
                }
            }
            list.Close();
            list.Dispose();
            this.daibanshiyi.Text = this.daibanshiyi.Text + "</table>";
        }
    }
}

