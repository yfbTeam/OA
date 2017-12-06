namespace xyoa.pda.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarApply_ysp_show : Page
    {
        protected Button Button1;
        protected Label CarId;
        protected Label Carpeople;
        protected TextBox CarpeopleUser;
        protected CheckBox CheckBox1;
        protected Label Destination;
        protected Label DqNodeName1;
        protected Label Drivers;
        protected Label Endtime;
        protected HtmlForm form1;
        protected TextBox GlNum;
        protected HtmlHead Head1;
        protected Label LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        protected HtmlInputHidden NodeName;
        protected Label NowTimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label Remark;
        protected Label Starttime;
        protected Label State;
        protected Label Subject;
        protected Label UnitId;
        protected HtmlInputHidden YjbNodeId;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CarApply_ysp.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                string sql = string.Concat(new object[] { "select * from qp_oa_CarApply  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and CHARINDEX(',", this.Session["username"], ",',','+YjbUser+',')   >0" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.NowTimes.Text = DateTime.Parse(list["NowTimes"].ToString()).ToShortDateString();
                    this.DqNodeName1.Text = list["DqNodeName"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                    this.GlNum.Text = list["GlNum"].ToString();
                    this.ViewState["DqNodeName"] = list["DqNodeName"].ToString();
                    this.ViewState["DqNodeId"] = list["DqNodeId"].ToString();
                    this.ViewState["FormId"] = list["FormId"].ToString();
                    this.CarId.Text = this.pulicss.TypeCodeAll("CarName", "qp_oa_CarInfo", list["CarId"].ToString());
                    this.Drivers.Text = list["Drivers"].ToString();
                    this.Carpeople.Text = list["Carpeople"].ToString();
                    this.UnitId.Text = this.pulicss.TypeCodeAll("Name", "qp_oa_Bumen", list["UnitId"].ToString());
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.Destination.Text = list["Destination"].ToString();
                    this.Subject.Text = list["Subject"].ToString();
                    this.State.Text = list["State"].ToString().Replace("1", "待审批").Replace("2", "已通过").Replace("3", "未通过").Replace("4", "使用中").Replace("5", "已结束");
                    this.Remark.Text = list["Remark"].ToString();
                    this.CarpeopleUser.Text = list["CarpeopleUser"].ToString();
                    this.Carpeople.Text = list["Carpeople"].ToString();
                    this.Number.Text = list["Number"].ToString();
                }
                list.Close();
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

