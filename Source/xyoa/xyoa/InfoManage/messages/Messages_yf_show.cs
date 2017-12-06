namespace xyoa.InfoManage.messages
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Messages_yf_show : Page
    {
        protected Label acceptrealname;
        protected Label CkTime;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Label itimes;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Label sendrealname;
        protected Label sendusername;
        protected Label sfck;
        protected Label titles;
        protected Label url;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_Messages where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and (sendusername='", this.Session["username"], "') and tablekey='2'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.titles.Text = list["titles"].ToString().Replace("\n", "<br>").Replace("<微笑>", "<img src=/oaimg/Face/0.gif border=0/>").Replace("<撇嘴>", "<img src=/oaimg/Face/1.gif border=0/>").Replace("<色>", "<img src=/oaimg/Face/2.gif border=0/>").Replace("<发呆>", "<img src=/oaimg/Face/3.gif border=0/>").Replace("<得意>", "<img src=/oaimg/Face/4.gif border=0/>").Replace("<流泪>", "<img src=/oaimg/Face/5.gif border=0/>").Replace("<害羞>", "<img src=/oaimg/Face/6.gif border=0/>").Replace("<闭嘴>", "<img src=/oaimg/Face/7.gif border=0/>").Replace("<睡>", "<img src=/oaimg/Face/8.gif border=0/>").Replace("<大哭>", "<img src=/oaimg/Face/9.gif border=0/>").Replace("<尴尬>", "<img src=/oaimg/Face/10.gif border=0/>").Replace("<发怒>", "<img src=/oaimg/Face/11.gif border=0/>").Replace("<调皮>", "<img src=/oaimg/Face/12.gif border=0/>").Replace("<呲牙>", "<img src=/oaimg/Face/13.gif border=0/>").Replace("<惊呆>", "<img src=/oaimg/Face/14.gif border=0/>").Replace("<难过>", "<img src=/oaimg/Face/15.gif border=0/>").Replace("<酷>", "<img src=/oaimg/Face/16.gif border=0/>").Replace("<冷汗>", "<img src=/oaimg/Face/17.gif border=0/>").Replace("<抓狂>", "<img src=/oaimg/Face/18.gif border=0/>").Replace("<吐>", "<img src=/oaimg/Face/19.gif border=0/>").Replace("<偷笑>", "<img src=/oaimg/Face/20.gif border=0/>").Replace("<可爱>", "<img src=/oaimg/Face/21.gif border=0/>").Replace("<白眼>", "<img src=/oaimg/Face/22.gif border=0/>").Replace("<傲慢>", "<img src=/oaimg/Face/23.gif border=0/>").Replace("<饥饿>", "<img src=/oaimg/Face/24.gif border=0/>").Replace("<困>", "<img src=/oaimg/Face/25.gif border=0/>").Replace("<惊恐>", "<img src=/oaimg/Face/26.gif border=0/>").Replace("<流汗>", "<img src=/oaimg/Face/27.gif border=0/>").Replace("<憨笑>", "<img src=/oaimg/Face/28.gif border=0/>").Replace("<大兵>", "<img src=/oaimg/Face/29.gif border=0/>").Replace("<奋斗>", "<img src=/oaimg/Face/30.gif border=0/>").Replace("<咒骂>", "<img src=/oaimg/Face/31.gif border=0/>").Replace("<疑问>", "<img src=/oaimg/Face/32.gif border=0/>").Replace("<嘘>", "<img src=/oaimg/Face/33.gif border=0/>").Replace("<晕>", "<img src=/oaimg/Face/34.gif border=0/>").Replace("<折磨>", "<img src=/oaimg/Face/35.gif border=0/>").Replace("<衰>", "<img src=/oaimg/Face/36.gif border=0/>").Replace("<骷髅>", "<img src=/oaimg/Face/37.gif border=0/>").Replace("<敲打>", "<img src=/oaimg/Face/38.gif border=0/>").Replace("<再见>", "<img src=/oaimg/Face/39.gif border=0/>").Replace("<插汗>", "<img src=/oaimg/Face/40.gif border=0/>").Replace("<抠鼻>", "<img src=/oaimg/Face/41.gif border=0/>").Replace("<鼓掌>", "<img src=/oaimg/Face/42.gif border=0/>").Replace("<糗大了>", "<img src=/oaimg/Face/43.gif border=0/>").Replace("<坏笑>", "<img src=/oaimg/Face/44.gif border=0/>").Replace("<左哼哼>", "<img src=/oaimg/Face/45.gif border=0/>").Replace("<右哼哼>", "<img src=/oaimg/Face/46.gif border=0/>").Replace("<哈欠>", "<img src=/oaimg/Face/47.gif border=0/>").Replace("<鄙视>", "<img src=/oaimg/Face/48.gif border=0/>").Replace("<委屈>", "<img src=/oaimg/Face/49.gif border=0/>").Replace("<快哭了>", "<img src=/oaimg/Face/50.gif border=0/>").Replace("<阴险>", "<img src=/oaimg/Face/51.gif border=0/>").Replace("<亲亲>", "<img src=/oaimg/Face/52.gif border=0/>").Replace("<吓>", "<img src=/oaimg/Face/53.gif border=0/>").Replace("<可怜>", "<img src=/oaimg/Face/54.gif border=0/>").Replace("<菜刀>", "<img src=/oaimg/Face/55.gif border=0/>").Replace("<OK>", "<img src=/oaimg/Face/55.gif border=0/>");
                    this.itimes.Text = list["itimes"].ToString();
                    this.sendusername.Text = list["sendusername"].ToString();
                    this.sendrealname.Text = list["sendrealname"].ToString();
                    this.acceptrealname.Text = list["acceptrealname"].ToString();
                    this.sfck.Text = this.pulicss.CheckText(list["sfck"].ToString());
                    this.url.Text = list["url"].ToString();
                    this.CkTime.Text = list["CkTime"].ToString().Replace("0:00:00", "").Replace("1900-1-1", "未阅读");
                }
                list.Close();
                this.pulicss.InsertLog("查看消息", "内部消息");
            }
        }
    }
}

