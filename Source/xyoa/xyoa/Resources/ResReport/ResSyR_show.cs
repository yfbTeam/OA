namespace xyoa.Resources.ResReport
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ResSyR_show : Page
    {
        protected Label Cangku;
        protected CheckBox CheckBox1;
        protected Label DqNodeName1;
        protected HtmlForm form1;
        protected TextBox GlNum;
        protected HtmlHead Head1;
        protected Label KuCun;
        protected Label LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        protected Label Liyou;
        protected Label NowTimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Quyu;
        protected Label Realname;
        protected Label Shuliang;
        protected Label Xinghao;
        protected TextBox ZyId;
        protected Label ZyIntro;
        protected Label ZyName;
        protected Label ZyNum;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_ResAppSy  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Shuliang.Text = list["Shuliang"].ToString();
                    this.Liyou.Text = this.pulicss.TbToLb(list["Liyou"].ToString());
                    this.NowTimes.Text = DateTime.Parse(list["NowTimes"].ToString()).ToShortDateString();
                    this.DqNodeName1.Text = list["DqNodeName"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.Number.Text = list["Number"].ToString();
                    this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                    this.GlNum.Text = list["GlNum"].ToString();
                    this.ViewState["DqNodeName"] = list["DqNodeName"].ToString();
                    this.ViewState["DqNodeId"] = list["DqNodeId"].ToString();
                    this.ViewState["YjbNodeId"] = list["YjbNodeId"].ToString();
                    string str2 = "select * from qp_oa_ResourcesAdd  where id='" + list["ZyId"].ToString() + "'  ";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.ZyNum.Text = reader2["ZyNum"].ToString();
                        this.Xinghao.Text = reader2["Xinghao"].ToString();
                        this.ZyId.Text = reader2["id"].ToString();
                        this.ZyName.Text = reader2["ZyName"].ToString();
                        this.ZyIntro.Text = this.pulicss.TbToLb(reader2["ZyIntro"].ToString());
                        this.KuCun.Text = reader2["KuCun"].ToString();
                        this.Cangku.Text = this.pulicss.TypeCode("qp_oa_ResourcesCangku", reader2["Cangku"].ToString());
                        this.Quyu.Text = this.pulicss.TypeCode("qp_oa_ResourcesQuyu", reader2["Quyu"].ToString());
                    }
                    reader2.Close();
                }
                list.Close();
                string str3 = "select  * from qp_Pro_WorkFlowMsg where GlNumber='" + this.Number.Text + "'  order by id asc";
                SqlDataReader reader3 = this.List.GetList(str3);
                this.Liucheng.Text = null;
                int num = 1;
                this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"0\" cellpadding=\"4\" cellspacing=\"1\" width=\"100%\" class=\"nextpage\">";
                while (reader3.Read())
                {
                    object text;
                    string str4 = null;
                    if (reader3["GlNum"].ToString() == this.GlNum.Text)
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"18%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>第<font color=red><b>", num, "</b></font>步(当前步骤)</td>" });
                    }
                    else
                    {
                        text = this.Liucheng.Text;
                        this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"18%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>第<font color=red><b>", num, "</b></font>步</td>" });
                    }
                    this.Liucheng.Text = this.Liucheng.Text + "<td class=\"newtd2\" width=\"42%\" style=\"line-height: 150%\">";
                    str4 = "select  * from qp_Pro_WorkFlowMsg  where  GlNum='" + reader3["GlNum"].ToString() + "'  order by id asc";
                    SqlDataReader reader4 = this.List.GetList(str4);
                    while (reader4.Read())
                    {
                        TimeSpan span;
                        string str5 = "";
                        if (reader4["Zhuangtai"].ToString() == "1")
                        {
                            str5 = "flow_close.gif";
                            span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "\"/>&nbsp;<b><font color=#FF0000>", reader4["BuZhouName"], "</font></b><font color=#008000>(", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>当前状态：", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "<br>办理操作：", reader4["CaoZuo"].ToString().Replace("1", "未操作").Replace("2", "起草拟稿").Replace("3", "通过审批").Replace("4", "拒绝审批"), "<br>开始于：", 
                                reader4["StartTime"], "<br>结束于：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>意见备注：", reader4["Yijian"], "<br>操作人员：", reader4["Realname"], "<br>"
                             });
                        }
                        else if (reader4["Zhuangtai"].ToString() == "2")
                        {
                            str5 = "flow_open.gif";
                            span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "\"/>&nbsp;<b><font color=#FF0000>", reader4["BuZhouName"], "</font></b><font color=#008000>(", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>当前状态：", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "<br>办理操作：", reader4["CaoZuo"].ToString().Replace("1", "未操作").Replace("2", "起草拟稿").Replace("3", "通过审批").Replace("4", "拒绝审批"), "<br>开始于：", 
                                reader4["StartTime"], "<br>结束于：", reader4["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>意见备注：", reader4["Yijian"], "<br>操作人员：", reader4["Realname"], "<br>"
                             });
                        }
                        else
                        {
                            str5 = "workflow_query.gif";
                            span = (TimeSpan) (DateTime.Parse(reader4["EndTime"].ToString()) - DateTime.Parse(reader4["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str5, "\"  title=\"", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "\"/>&nbsp;<b><font color=#FF0000>", reader4["BuZhouName"], "</font></b></font><font color=#008000>(", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>当前状态：", reader4["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "<br>办理操作：", reader4["CaoZuo"].ToString().Replace("1", "未操作").Replace("2", "起草拟稿").Replace("3", "通过审批").Replace("4", "拒绝审批"), "<br>开始于：", 
                                reader4["StartTime"], "<br>结束于：", reader4["EndTime"], "<br>意见备注：", reader4["Yijian"], "<br>操作人员：", reader4["Realname"], "<br>"
                             });
                        }
                    }
                    reader4.Close();
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                    num++;
                }
                reader3.Close();
                if (this.LcZhuangtai.Text == "通过审批")
                {
                    this.Liucheng.Text = this.Liucheng.Text + "<tr><td class=\"newtd2\" width=\"100%\" colspan=\"3\" align=\"center\"><font color=red><b>已通过审批</b></font></td>";
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                }
                if (this.LcZhuangtai.Text == "终止审批")
                {
                    this.Liucheng.Text = this.Liucheng.Text + "<tr><td class=\"newtd2\" width=\"100%\" colspan=\"3\" align=\"center\"><font color=red><b>已终止审批</b></font></td>";
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                }
                this.Liucheng.Text = this.Liucheng.Text + "</table>";
            }
        }
    }
}

