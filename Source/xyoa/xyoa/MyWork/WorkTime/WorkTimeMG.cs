namespace xyoa.MyWork.WorkTime
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkTimeMG : Page
    {
        protected Button Button2;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Starttime;

        public void BindAttribute()
        {
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "hhhh4", this.Session["perstr"].ToString());
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkTimeMG.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if ((this.Starttime.Text != "") && (this.Endtime.Text != ""))
            {
                this.ViewState["SqlKq"] = " and ((Djtime between '" + this.Starttime.Text + "'and  '" + this.Endtime.Text + "') or (convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + this.Starttime.Text + "' as datetime),120)) or (convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120)))";
                this.ViewState["SqlPro"] = " and ((StartTime between '" + this.Starttime.Text + "'and  '" + this.Endtime.Text + "') or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + this.Starttime.Text + "' as datetime),120)) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120)))";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            string str2 = ("select Username,Realname from [qp_oa_username] where ifdel='0' and username='" + this.Session["username"] + "'") + SqlCreate;
            string sql = "" + str2 + " " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("LUser");
                Label label2 = (Label) e.Row.FindControl("Zhengchang");
                Label label3 = (Label) e.Row.FindControl("Chidao");
                Label label4 = (Label) e.Row.FindControl("ZaoTui");
                Label label5 = (Label) e.Row.FindControl("WeiKaoQin");
                Label label6 = (Label) e.Row.FindControl("ChuChai");
                Label label7 = (Label) e.Row.FindControl("JiaBan");
                Label label8 = (Label) e.Row.FindControl("XiuJia");
                label2.Text = null;
                label3.Text = null;
                label4.Text = null;
                label5.Text = null;
                label6.Text = null;
                label7.Text = null;
                label8.Text = null;
                string sql = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_1='正常' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int count = this.List.GetCount(sql);
                string str2 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_2='正常' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num2 = this.List.GetCount(str2);
                string str3 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_3='正常' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num3 = this.List.GetCount(str3);
                string str4 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_4='正常' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num4 = this.List.GetCount(str4);
                string str5 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_5='正常' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num5 = this.List.GetCount(str5);
                string str6 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_6='正常' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num6 = this.List.GetCount(str6);
                int num7 = ((((count + num2) + num3) + num4) + num5) + num6;
                label2.Text = string.Concat(new object[] { "<a href=TjProject_kq.aspx?user=", label.Text, "&type=zc&start=", this.Starttime.Text, "&last=", this.Endtime.Text, "  class=\"LinkLine\">", num7, "</a>" });
                string str7 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_1='迟到' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num8 = this.List.GetCount(str7);
                string str8 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_2='迟到' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num9 = this.List.GetCount(str8);
                string str9 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_3='迟到' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num10 = this.List.GetCount(str9);
                string str10 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_4='迟到' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num11 = this.List.GetCount(str10);
                string str11 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_5='迟到' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num12 = this.List.GetCount(str11);
                string str12 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_6='迟到' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num13 = this.List.GetCount(str12);
                int num14 = ((((num8 + num9) + num10) + num11) + num12) + num13;
                label3.Text = string.Concat(new object[] { "<a href=TjProject_kq.aspx?user=", label.Text, "&type=cd&start=", this.Starttime.Text, "&last=", this.Endtime.Text, "  class=\"LinkLine\">", num14, "</a>" });
                string str13 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_1='早退'and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num15 = this.List.GetCount(str13);
                string str14 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_2='早退' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num16 = this.List.GetCount(str14);
                string str15 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_3='早退' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num17 = this.List.GetCount(str15);
                string str16 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_4='早退' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num18 = this.List.GetCount(str16);
                string str17 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_5='早退'and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num19 = this.List.GetCount(str17);
                string str18 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_6='早退' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num20 = this.List.GetCount(str18);
                int num21 = ((((num15 + num16) + num17) + num18) + num19) + num20;
                label4.Text = string.Concat(new object[] { "<a href=TjProject_kq.aspx?user=", label.Text, "&type=zt&start=", this.Starttime.Text, "&last=", this.Endtime.Text, "  class=\"LinkLine\">", num21, "</a>" });
                string str19 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_1='未考勤' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num22 = this.List.GetCount(str19);
                string str20 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_2='未考勤' and DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num23 = this.List.GetCount(str20);
                string str21 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_3='未考勤' and  DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num24 = this.List.GetCount(str21);
                string str22 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_4='未考勤' and  DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num25 = this.List.GetCount(str22);
                string str23 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_5='未考勤' and  DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num26 = this.List.GetCount(str23);
                string str24 = string.Concat(new object[] { "select count(*) as counts from qp_WorkTimeDj where DjState_6='未考勤' and  DjUsername='", label.Text, "'", this.ViewState["SqlKq"], "" });
                int num27 = this.List.GetCount(str24);
                int num28 = ((((num22 + num23) + num24) + num25) + num26) + num27;
                label5.Text = string.Concat(new object[] { "<a href=TjProject_kq.aspx?user=", label.Text, "&type=wkq&start=", this.Starttime.Text, "&last=", this.Endtime.Text, "  class=\"LinkLine\">", num28, "</a>" });
                string str25 = string.Concat(new object[] { "select sum(DiffTime) as counts from qp_hr_MyAttendance where Username='", label.Text, "' and  LcZhuangtai='3'  and  Type='1'  ", this.ViewState["SqlPro"], "" });
                SqlDataReader list = this.List.GetList(str25);
                if (list.Read())
                {
                    if (list["counts"].ToString() == "")
                    {
                        label6.Text = "<a href=TjProject_xm.aspx?user=" + label.Text + "&type=1&start=" + this.Starttime.Text + "&last=" + this.Endtime.Text + " class=\"LinkLine\">0</a>";
                    }
                    else
                    {
                        label6.Text = string.Concat(new object[] { "<a href=TjProject_xm.aspx?user=", label.Text, "&type=1&start=", this.Starttime.Text, "&last=", this.Endtime.Text, " class=\"LinkLine\">", list["counts"], "</a>" });
                    }
                }
                else
                {
                    label6.Text = "<a href=TjProject_xm.aspx?user=" + label.Text + "&type=1&start=" + this.Starttime.Text + "&last=" + this.Endtime.Text + " class=\"LinkLine\">0</a>";
                }
                list.Close();
                string str26 = string.Concat(new object[] { "select sum(DiffTime) as counts from qp_hr_MyAttendance where Username='", label.Text, "' and  LcZhuangtai='3'  and  Type='2'  ", this.ViewState["SqlPro"], "" });
                SqlDataReader reader2 = this.List.GetList(str26);
                if (reader2.Read())
                {
                    if (reader2["counts"].ToString() == "")
                    {
                        label8.Text = "<a href=TjProject_xm.aspx?user=" + label.Text + "&type=2&start=" + this.Starttime.Text + "&last=" + this.Endtime.Text + " class=\"LinkLine\">0</a>";
                    }
                    else
                    {
                        label8.Text = string.Concat(new object[] { "<a href=TjProject_xm.aspx?user=", label.Text, "&type=2&start=", this.Starttime.Text, "&last=", this.Endtime.Text, " class=\"LinkLine\">", reader2["counts"], "</a>" });
                    }
                }
                else
                {
                    label8.Text = "<a href=TjProject_xm.aspx?user=" + label.Text + "&type=2&start=" + this.Starttime.Text + "&last=" + this.Endtime.Text + " class=\"LinkLine\">0</a>";
                }
                reader2.Close();
                string str27 = string.Concat(new object[] { "select sum(DiffTime) as counts from qp_hr_MyAttendance where Username='", label.Text, "' and  LcZhuangtai='3'  and  Type='3'  ", this.ViewState["SqlPro"], "" });
                SqlDataReader reader3 = this.List.GetList(str27);
                if (reader3.Read())
                {
                    if (reader3["counts"].ToString() == "")
                    {
                        label7.Text = "<a href=TjProject_xm.aspx?user=" + label.Text + "&type=3&start=" + this.Starttime.Text + "&last=" + this.Endtime.Text + " class=\"LinkLine\">0</a>";
                    }
                    else
                    {
                        label7.Text = string.Concat(new object[] { "<a href=TjProject_xm.aspx?user=", label.Text, "&type=3&start=", this.Starttime.Text, "&last=", this.Endtime.Text, " class=\"LinkLine\">", reader3["counts"], "</a>" });
                    }
                }
                else
                {
                    label7.Text = "<a href=TjProject_xm.aspx?user=" + label.Text + "&type=3&start=" + this.Starttime.Text + "&last=" + this.Endtime.Text + " class=\"LinkLine\">0</a>";
                }
                reader3.Close();
            }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            string sqlsort = "";
            if ((this.ViewState["SortDirection"] == null) || (this.ViewState["SortDirection"].ToString().CompareTo("") == 0))
            {
                this.ViewState["SortDirection"] = " desc";
            }
            else
            {
                this.ViewState["SortDirection"] = "";
            }
            sqlsort = " order by " + e.SortExpression + this.ViewState["SortDirection"];
            this.DataBindToGridview(sqlsort, this.CreateMidSql());
            this.SortText.Value = sqlsort;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Starttime.Text = "" + DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01";
                this.Endtime.Text = DateTime.Now.ToShortDateString();
                this.BindAttribute();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                this.Bindquanxian();
            }
        }

        protected void SearchData_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }
    }
}

