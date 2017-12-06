namespace xyoa.PublicWork.Hetong
{
    using qiupeng.crm;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongCxList_show : Page
    {
        protected CheckBox CheckBox1;
        protected Label Danwei;
        protected Label Daoqi;
        private qiupeng.crm.divcrm divcrm = new qiupeng.crm.divcrm();
        protected Label Fenlei;
        protected HtmlForm form1;
        protected Label fujian;
        protected TextBox GlNum;
        protected HtmlHead Head1;
        protected Label Hetonghao;
        protected Label Jine;
        protected Label LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        protected Label Neirong;
        protected TextBox Number;
        protected Panel Panel1;
        private publics pulicss = new publics();
        protected Label Qianyue;
        protected Label Qixian;
        protected Label Zhuangtai;
        protected Label Zhuti;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_HeTong   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Number.Text = list["Number"].ToString();
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Neirong.Text = list["Neirong"].ToString();
                    this.Hetonghao.Text = list["Hetonghao"].ToString();
                    this.Jine.Text = list["Jine"].ToString();
                    this.Danwei.Text = list["Danwei"].ToString();
                    this.Fenlei.Text = this.pulicss.TypeCode("qp_oa_HetongLb", list["Fenlei"].ToString());
                    this.Zhuangtai.Text = list["Zhuangtai"].ToString().Replace("1", "执行中").Replace("2", "结束").Replace("3", "意外终止");
                    this.Qianyue.Text = DateTime.Parse(list["Qianyue"].ToString()).ToShortDateString();
                    this.Qixian.Text = list["Qixian"].ToString().Replace("1", "有期限").Replace("2", "无期限");
                    this.GlNum.Text = list["GlNum"].ToString();
                    if (list["Qixian"].ToString() == "1")
                    {
                        this.Qixian.Text = "有";
                        this.Panel1.Visible = true;
                    }
                    else
                    {
                        this.Qixian.Text = "无";
                        this.Panel1.Visible = false;
                    }
                    this.Daoqi.Text = DateTime.Parse(list["Daoqi"].ToString()).ToShortDateString();
                    this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                }
                list.Close();
                this.pulicss.GetFile(this.Number.Text, this.fujian);
                this.pulicss.InsertLog("查看合同", "我的合同");
                string str2 = "select  * from qp_Pro_WorkFlowMsg where GlNumber='" + this.Number.Text + "'  order by id asc";
                SqlDataReader reader2 = this.List.GetList(str2);
                this.Liucheng.Text = null;
                int num = 1;
                this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"0\" cellpadding=\"4\" cellspacing=\"1\" width=\"100%\" class=\"nextpage\">";
                while (reader2.Read())
                {
                    object text;
                    string str3 = null;
                    if (reader2["GlNum"].ToString() == this.GlNum.Text)
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
                    str3 = "select  * from qp_Pro_WorkFlowMsg  where  GlNum='" + reader2["GlNum"].ToString() + "'  order by id asc";
                    SqlDataReader reader3 = this.List.GetList(str3);
                    while (reader3.Read())
                    {
                        TimeSpan span;
                        string str4 = "";
                        if (reader3["Zhuangtai"].ToString() == "1")
                        {
                            str4 = "flow_close.gif";
                            span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str4, "\"  title=\"", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "\"/>&nbsp;<b><font color=#FF0000>", reader3["BuZhouName"], "</font></b><font color=#008000>(", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>当前状态：", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "<br>办理操作：", reader3["CaoZuo"].ToString().Replace("1", "未操作").Replace("2", "起草拟稿").Replace("3", "通过审批").Replace("4", "拒绝审批"), "<br>开始于：", 
                                reader3["StartTime"], "<br>结束于：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "未接收").Replace("1900-01-01 00:00:00", "未接收").Replace("1900-1-1 00:00:00", "未接收").Replace("1900/1/1 0:00:00", "未接收").Replace("1900/01/01 00:00:00", "未接收").Replace("1900/1/1 00:00:00", "未接收"), "<br>意见备注：", reader3["Yijian"], "<br>操作人员：", reader3["Realname"], "<br>"
                             });
                        }
                        else if (reader3["Zhuangtai"].ToString() == "2")
                        {
                            str4 = "flow_open.gif";
                            span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str4, "\"  title=\"", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "\"/>&nbsp;<b><font color=#FF0000>", reader3["BuZhouName"], "</font></b><font color=#008000>(", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>当前状态：", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "<br>办理操作：", reader3["CaoZuo"].ToString().Replace("1", "未操作").Replace("2", "起草拟稿").Replace("3", "通过审批").Replace("4", "拒绝审批"), "<br>开始于：", 
                                reader3["StartTime"], "<br>结束于：", reader3["EndTime"].ToString().Replace("1900-1-1 0:00:00", "办理中").Replace("1900-01-01 00:00:00", "办理中").Replace("1900-1-1 00:00:00", "办理中").Replace("1900/1/1 0:00:00", "办理中").Replace("1900/01/01 00:00:00", "办理中").Replace("1900/1/1 00:00:00", "办理中"), "<br>意见备注：", reader3["Yijian"], "<br>操作人员：", reader3["Realname"], "<br>"
                             });
                        }
                        else
                        {
                            str4 = "workflow_query.gif";
                            span = (TimeSpan) (DateTime.Parse(reader3["EndTime"].ToString()) - DateTime.Parse(reader3["StartTime"].ToString()));
                            text = this.Liucheng.Text;
                            this.Liucheng.Text = string.Concat(new object[] { 
                                text, "<img src=\"/oaimg/menu/", str4, "\"  title=\"", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "\"/>&nbsp;<b><font color=#FF0000>", reader3["BuZhouName"], "</font></b></font><font color=#008000>(", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "&nbsp;&nbsp;用时：", this.pulicss.ShowDateTime(span.TotalSeconds), ")</font><br>当前状态：", reader3["Zhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "办理完成"), "<br>办理操作：", reader3["CaoZuo"].ToString().Replace("1", "未操作").Replace("2", "起草拟稿").Replace("3", "通过审批").Replace("4", "拒绝审批"), "<br>开始于：", 
                                reader3["StartTime"], "<br>结束于：", reader3["EndTime"], "<br>意见备注：", reader3["Yijian"], "<br>操作人员：", reader3["Realname"], "<br>"
                             });
                        }
                    }
                    reader3.Close();
                    this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                    num++;
                }
                reader2.Close();
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

