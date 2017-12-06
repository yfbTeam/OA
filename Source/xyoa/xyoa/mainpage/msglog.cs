namespace xyoa.mainpage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class msglog : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Button1_Click1(object sender, EventArgs e)
        {
            try
            {
                if (this.GoPage.Text.Trim().ToString() == "")
                {
                    base.Response.Write("<script language='javascript'>alert('页码不可以为空!');</script>");
                }
                else if ((this.GoPage.Text.Trim().ToString() == "0") || (Convert.ToInt32(this.GoPage.Text.Trim().ToString()) > this.GridView1.PageCount))
                {
                    base.Response.Write("<script language='javascript'>alert('页码不是一个有效值!');</script>");
                }
                else if (this.GoPage.Text.Trim() != "")
                {
                    int num = int.Parse(this.GoPage.Text.Trim()) - 1;
                    if ((num >= 0) && (num < this.GridView1.PageCount))
                    {
                        this.GridView1.PageIndex = num;
                    }
                }
                this.DataBindToGridview(this.CreateMidSql());
            }
            catch
            {
                this.DataBindToGridview(this.CreateMidSql());
                base.Response.Write("<script language='javascript'>alert('请输入有效的页码字符！');</script>");
            }
        }

        private string CheckCbxDel()
        {
            string str = "0";
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("CheckSelect");
                Label label = (Label) row.FindControl("LabVisible");
                if (box.Checked)
                {
                    if (str == "")
                    {
                        str = label.Text.ToString();
                    }
                    else
                    {
                        str = str + "," + label.Text.ToString();
                    }
                }
            }
            return str;
        }

        public string CreateMidSql()
        {
            return string.Empty;
        }

        public void DataBindToGridview(string SqlCreate)
        {
            string str = string.Concat(new object[] { "select  *  from qp_oa_Messages where (acceptusername='", base.Request.QueryString["user"], "' and sendusername='", HttpContext.Current.Session["username"], "' and tablekey='2') or (acceptusername='", HttpContext.Current.Session["username"], "' and sendusername='", base.Request.QueryString["user"], "' and tablekey='1') " });
            string str2 = string.Concat(new object[] { "select  count(id)  from qp_oa_Messages where (acceptusername='", base.Request.QueryString["user"], "' and sendusername='", HttpContext.Current.Session["username"], "' and tablekey='2') or (acceptusername='", HttpContext.Current.Session["username"], "' and sendusername='", base.Request.QueryString["user"], "' and tablekey='1') " });
            string str3 = str + SqlCreate;
            string str4 = str2 + SqlCreate;
            string sql = "" + str3 + "  order by id asc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            string str6 = str4;
            this.CountsLabel.Text = "" + this.List.GetCount(str6) + "";
            this.AllPageLabel.Text = Convert.ToString(this.GridView1.PageCount);
            this.CurrentlyPageLabel.Text = Convert.ToString((int) (this.GridView1.PageIndex + 1));
            this.btnFirst.CommandName = "1";
            this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
            this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : ((this.GridView1.PageIndex + 2)).ToString();
            this.btnLast.CommandName = this.GridView1.PageCount.ToString();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Lid");
                Label label2 = (Label) e.Row.FindControl("Label1");
                Label label3 = (Label) e.Row.FindControl("acceptusername");
                Label label4 = (Label) e.Row.FindControl("sendrealname");
                Label label5 = (Label) e.Row.FindControl("itimes");
                Label label6 = (Label) e.Row.FindControl("titles");
                if (label3.Text == this.Session["username"].ToString())
                {
                    label2.Text = "<table  width=\"100%\" cellspacing=\"0\" cellpadding=\"0\"><tr><td><font color=\"#0000FF\">" + label4.Text + "&nbsp;&nbsp; </font><font color=\"#0000FF\">" + label5.Text + "</font></td></tr><tr><td><font color=\"#000000\">" + label6.Text.Replace("\n", "<br>").Replace("<微笑>", "<img src=/oaimg/Face/0.gif border=0/>").Replace("<撇嘴>", "<img src=/oaimg/Face/1.gif border=0/>").Replace("<色>", "<img src=/oaimg/Face/2.gif border=0/>").Replace("<发呆>", "<img src=/oaimg/Face/3.gif border=0/>").Replace("<得意>", "<img src=/oaimg/Face/4.gif border=0/>").Replace("<流泪>", "<img src=/oaimg/Face/5.gif border=0/>").Replace("<害羞>", "<img src=/oaimg/Face/6.gif border=0/>").Replace("<闭嘴>", "<img src=/oaimg/Face/7.gif border=0/>").Replace("<睡>", "<img src=/oaimg/Face/8.gif border=0/>").Replace("<大哭>", "<img src=/oaimg/Face/9.gif border=0/>").Replace("<尴尬>", "<img src=/oaimg/Face/10.gif border=0/>").Replace("<发怒>", "<img src=/oaimg/Face/11.gif border=0/>").Replace("<调皮>", "<img src=/oaimg/Face/12.gif border=0/>").Replace("<呲牙>", "<img src=/oaimg/Face/13.gif border=0/>").Replace("<惊呆>", "<img src=/oaimg/Face/14.gif border=0/>").Replace("<难过>", "<img src=/oaimg/Face/15.gif border=0/>").Replace("<酷>", "<img src=/oaimg/Face/16.gif border=0/>").Replace("<冷汗>", "<img src=/oaimg/Face/17.gif border=0/>").Replace("<抓狂>", "<img src=/oaimg/Face/18.gif border=0/>").Replace("<吐>", "<img src=/oaimg/Face/19.gif border=0/>").Replace("<偷笑>", "<img src=/oaimg/Face/20.gif border=0/>").Replace("<可爱>", "<img src=/oaimg/Face/21.gif border=0/>").Replace("<白眼>", "<img src=/oaimg/Face/22.gif border=0/>").Replace("<傲慢>", "<img src=/oaimg/Face/23.gif border=0/>").Replace("<饥饿>", "<img src=/oaimg/Face/24.gif border=0/>").Replace("<困>", "<img src=/oaimg/Face/25.gif border=0/>").Replace("<惊恐>", "<img src=/oaimg/Face/26.gif border=0/>").Replace("<流汗>", "<img src=/oaimg/Face/27.gif border=0/>").Replace("<憨笑>", "<img src=/oaimg/Face/28.gif border=0/>").Replace("<大兵>", "<img src=/oaimg/Face/29.gif border=0/>").Replace("<奋斗>", "<img src=/oaimg/Face/30.gif border=0/>").Replace("<咒骂>", "<img src=/oaimg/Face/31.gif border=0/>").Replace("<疑问>", "<img src=/oaimg/Face/32.gif border=0/>").Replace("<嘘>", "<img src=/oaimg/Face/33.gif border=0/>").Replace("<晕>", "<img src=/oaimg/Face/34.gif border=0/>").Replace("<折磨>", "<img src=/oaimg/Face/35.gif border=0/>").Replace("<衰>", "<img src=/oaimg/Face/36.gif border=0/>").Replace("<骷髅>", "<img src=/oaimg/Face/37.gif border=0/>").Replace("<敲打>", "<img src=/oaimg/Face/38.gif border=0/>").Replace("<再见>", "<img src=/oaimg/Face/39.gif border=0/>").Replace("<插汗>", "<img src=/oaimg/Face/40.gif border=0/>").Replace("<抠鼻>", "<img src=/oaimg/Face/41.gif border=0/>").Replace("<鼓掌>", "<img src=/oaimg/Face/42.gif border=0/>").Replace("<糗大了>", "<img src=/oaimg/Face/43.gif border=0/>").Replace("<坏笑>", "<img src=/oaimg/Face/44.gif border=0/>").Replace("<左哼哼>", "<img src=/oaimg/Face/45.gif border=0/>").Replace("<右哼哼>", "<img src=/oaimg/Face/46.gif border=0/>").Replace("<哈欠>", "<img src=/oaimg/Face/47.gif border=0/>").Replace("<鄙视>", "<img src=/oaimg/Face/48.gif border=0/>").Replace("<委屈>", "<img src=/oaimg/Face/49.gif border=0/>").Replace("<快哭了>", "<img src=/oaimg/Face/50.gif border=0/>").Replace("<阴险>", "<img src=/oaimg/Face/51.gif border=0/>").Replace("<亲亲>", "<img src=/oaimg/Face/52.gif border=0/>").Replace("<吓>", "<img src=/oaimg/Face/53.gif border=0/>").Replace("<可怜>", "<img src=/oaimg/Face/54.gif border=0/>").Replace("<菜刀>", "<img src=/oaimg/Face/55.gif border=0/>").Replace("<OK>", "<img src=/oaimg/Face/55.gif border=0/>") + "</font></td> </tr></table>";
                }
                else
                {
                    label2.Text = "<table  width=\"100%\" cellspacing=\"0\" cellpadding=\"0\"><tr><td><font color=\"#008040\">" + label4.Text + "&nbsp;&nbsp;</font><font color=\"#008040\">" + label5.Text + "</font></td></tr><tr><td><font color=\"#000000\">" + label6.Text.Replace("\n", "<br>").Replace("<微笑>", "<img src=/oaimg/Face/0.gif border=0/>").Replace("<撇嘴>", "<img src=/oaimg/Face/1.gif border=0/>").Replace("<色>", "<img src=/oaimg/Face/2.gif border=0/>").Replace("<发呆>", "<img src=/oaimg/Face/3.gif border=0/>").Replace("<得意>", "<img src=/oaimg/Face/4.gif border=0/>").Replace("<流泪>", "<img src=/oaimg/Face/5.gif border=0/>").Replace("<害羞>", "<img src=/oaimg/Face/6.gif border=0/>").Replace("<闭嘴>", "<img src=/oaimg/Face/7.gif border=0/>").Replace("<睡>", "<img src=/oaimg/Face/8.gif border=0/>").Replace("<大哭>", "<img src=/oaimg/Face/9.gif border=0/>").Replace("<尴尬>", "<img src=/oaimg/Face/10.gif border=0/>").Replace("<发怒>", "<img src=/oaimg/Face/11.gif border=0/>").Replace("<调皮>", "<img src=/oaimg/Face/12.gif border=0/>").Replace("<呲牙>", "<img src=/oaimg/Face/13.gif border=0/>").Replace("<惊呆>", "<img src=/oaimg/Face/14.gif border=0/>").Replace("<难过>", "<img src=/oaimg/Face/15.gif border=0/>").Replace("<酷>", "<img src=/oaimg/Face/16.gif border=0/>").Replace("<冷汗>", "<img src=/oaimg/Face/17.gif border=0/>").Replace("<抓狂>", "<img src=/oaimg/Face/18.gif border=0/>").Replace("<吐>", "<img src=/oaimg/Face/19.gif border=0/>").Replace("<偷笑>", "<img src=/oaimg/Face/20.gif border=0/>").Replace("<可爱>", "<img src=/oaimg/Face/21.gif border=0/>").Replace("<白眼>", "<img src=/oaimg/Face/22.gif border=0/>").Replace("<傲慢>", "<img src=/oaimg/Face/23.gif border=0/>").Replace("<饥饿>", "<img src=/oaimg/Face/24.gif border=0/>").Replace("<困>", "<img src=/oaimg/Face/25.gif border=0/>").Replace("<惊恐>", "<img src=/oaimg/Face/26.gif border=0/>").Replace("<流汗>", "<img src=/oaimg/Face/27.gif border=0/>").Replace("<憨笑>", "<img src=/oaimg/Face/28.gif border=0/>").Replace("<大兵>", "<img src=/oaimg/Face/29.gif border=0/>").Replace("<奋斗>", "<img src=/oaimg/Face/30.gif border=0/>").Replace("<咒骂>", "<img src=/oaimg/Face/31.gif border=0/>").Replace("<疑问>", "<img src=/oaimg/Face/32.gif border=0/>").Replace("<嘘>", "<img src=/oaimg/Face/33.gif border=0/>").Replace("<晕>", "<img src=/oaimg/Face/34.gif border=0/>").Replace("<折磨>", "<img src=/oaimg/Face/35.gif border=0/>").Replace("<衰>", "<img src=/oaimg/Face/36.gif border=0/>").Replace("<骷髅>", "<img src=/oaimg/Face/37.gif border=0/>").Replace("<敲打>", "<img src=/oaimg/Face/38.gif border=0/>").Replace("<再见>", "<img src=/oaimg/Face/39.gif border=0/>").Replace("<插汗>", "<img src=/oaimg/Face/40.gif border=0/>").Replace("<抠鼻>", "<img src=/oaimg/Face/41.gif border=0/>").Replace("<鼓掌>", "<img src=/oaimg/Face/42.gif border=0/>").Replace("<糗大了>", "<img src=/oaimg/Face/43.gif border=0/>").Replace("<坏笑>", "<img src=/oaimg/Face/44.gif border=0/>").Replace("<左哼哼>", "<img src=/oaimg/Face/45.gif border=0/>").Replace("<右哼哼>", "<img src=/oaimg/Face/46.gif border=0/>").Replace("<哈欠>", "<img src=/oaimg/Face/47.gif border=0/>").Replace("<鄙视>", "<img src=/oaimg/Face/48.gif border=0/>").Replace("<委屈>", "<img src=/oaimg/Face/49.gif border=0/>").Replace("<快哭了>", "<img src=/oaimg/Face/50.gif border=0/>").Replace("<阴险>", "<img src=/oaimg/Face/51.gif border=0/>").Replace("<亲亲>", "<img src=/oaimg/Face/52.gif border=0/>").Replace("<吓>", "<img src=/oaimg/Face/53.gif border=0/>").Replace("<可怜>", "<img src=/oaimg/Face/54.gif border=0/>").Replace("<菜刀>", "<img src=/oaimg/Face/55.gif border=0/>").Replace("<OK>", "<img src=/oaimg/Face/55.gif border=0/>") + "</font></td> </tr></table>";
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                string sql = "select Realname from qp_oa_MyData where Username='" + base.Request.QueryString["user"].ToString() + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Realname"] = list["Realname"].ToString();
                }
                list.Close();
                try
                {
                    this.GridView1.PageIndex = this.GridView1.PageCount + 1;
                }
                catch
                {
                }
                this.DataBindToGridview(this.CreateMidSql());
            }
        }

        protected void PagerButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.GridView1.PageIndex = Convert.ToInt32(((LinkButton) sender).CommandName) - 1;
                this.DataBindToGridview(this.CreateMidSql());
            }
            catch
            {
                base.Response.Write("<script language='javascript'>alert('没有这么多页！');</script>");
            }
        }
    }
}

