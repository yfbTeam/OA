namespace xyoa.OfficeMenu.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MettingCxList_show : Page
    {
        protected Label _Label;
        protected Button Button1;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected Label CjRealname;
        protected Label DqNodeName1;
        protected Label Endtime;
        protected HtmlForm form1;
        protected Label fujian;
        protected TextBox GlNum;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Introduction;
        protected Label LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        protected Label MettingName;
        protected Label Name;
        protected Label NbPeopleName;
        protected TextBox NbPeopleUser;
        protected Label NowTimes;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected Label Realname;
        protected Label Remark;
        protected Label Starttime;
        protected TextBox taolun;
        protected Label WbPeople;
        protected HtmlInputHidden YjbNodeId;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Taolun  (Fenlei,HyId,Content,Username,Realname,Settime) values ('6','" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "','" + this.pulicss.GetFormatStrbjq(this.taolun.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.DataBindToGridview();
            this.taolun.Text = null;
        }

        public void DataBindToGridview()
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            string sql = "select count(id) from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='6'";
            this.ViewState["GridViewCount"] = this.List.GetCount(sql);
            string str2 = "select * from qp_oa_Taolun  where HyId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and Fenlei='6' order by id desc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(str2);
            this.GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            this.DataBindToGridview();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "Delete from qp_oa_Taolun where ID='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                Label label = (Label) e.Row.FindControl("FTUsername");
                if ((label.Text == this.Session["username"].ToString()) || (this.Session["username"].ToString() == "admin"))
                {
                    button.Visible = true;
                    button.Attributes.Add("onclick", "javascript:return confirm('确认删除此条讨论记录吗？')");
                }
                else
                {
                    button.Visible = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return chknull();";
                string sql = "select * from qp_oa_MettingApply   where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.CjRealname.Text = list["CjRealname"].ToString();
                    this.NowTimes.Text = DateTime.Parse(list["NowTimes"].ToString()).ToShortDateString();
                    this.DqNodeName1.Text = list["DqNodeName"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                    this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                    this.ViewState["DqNodeName"] = list["DqNodeName"].ToString();
                    this.ViewState["DqNodeId"] = list["DqNodeId"].ToString();
                    this.ViewState["FormId"] = list["FormId"].ToString();
                    this.Number.Text = list["Number"].ToString();
                    this.Name.Text = list["Name"].ToString();
                    this.Introduction.Text = this.pulicss.TbToLb(list["Introduction"].ToString());
                    this.WbPeople.Text = list["WbPeople"].ToString();
                    this.NbPeopleUser.Text = list["NbPeopleUser"].ToString();
                    this.NbPeopleName.Text = list["NbPeopleName"].ToString();
                    this.MettingName.Text = list["MettingName"].ToString();
                    this.Starttime.Text = list["Starttime"].ToString();
                    this.Endtime.Text = list["Endtime"].ToString();
                    this.Remark.Text = list["Remark"].ToString();
                    this.LcZhuangtai.Text = list["LcZhuangtai"].ToString().Replace("1", "等待办理").Replace("2", "正在办理").Replace("3", "通过审批").Replace("4", "终止审批");
                    this.GlNum.Text = list["GlNum"].ToString();
                    this.pulicss.GetFile(this.Number.Text, this.fujian);
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
                this.DataBindToGridview();
                string str5 = "select  * from qp_oa_MettingApplyJy where Keyid='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' order by id asc";
                SqlDataReader reader4 = this.List.GetList(str5);
                this._Label.Text = null;
                int num2 = 0;
                this._Label.Text = this._Label.Text + "<table width=100% border=0 cellspacing=0 cellpadding=4>";
                this._Label.Text = this._Label.Text + "<tr>";
                while (reader4.Read())
                {
                    string str6 = this._Label.Text;
                    this._Label.Text = str6 + " <td width=100% ><img src=\"/oaimg/filetype/" + reader4["filetype"].ToString() + ".gif\" align=\"baseline\"/> <a href=/huiyi_down.aspx?number=" + reader4["NewName"].ToString() + "  target=_blank>" + reader4["Name"].ToString() + "</a>&nbsp;&nbsp;&nbsp;(" + reader4["realname"].ToString() + "→" + reader4["settime"].ToString() + ")</td>";
                    num2++;
                    if (num2 == 1)
                    {
                        this._Label.Text = this._Label.Text + "</tr><TR>";
                        num2 = 0;
                    }
                }
                this._Label.Text = this._Label.Text + " </table>";
                reader4.Close();
            }
        }
    }
}

