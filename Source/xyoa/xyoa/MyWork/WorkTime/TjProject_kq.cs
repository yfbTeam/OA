namespace xyoa.MyWork.WorkTime
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class TjProject_kq : Page
    {
        protected HtmlForm form1;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected HtmlInputHidden SortText;

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "hhhh4", this.Session["perstr"].ToString());
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            str = string.Concat(new object[] { str, " and DjUsername='", this.Session["username"], "'" });
            if ((base.Request.QueryString["start"] != "") && (base.Request.QueryString["last"] != ""))
            {
                str = str + " and ((Djtime between '" + base.Request.QueryString["start"] + "'and  '" + base.Request.QueryString["last"] + "') or (convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["start"] + "' as datetime),120)) or (convert(char(10),cast(Djtime as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["last"] + "' as datetime),120)))";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            string str;
            string str2;
            string str3;
            if (base.Request.QueryString["type"] == "zc")
            {
                str = "select * from [qp_WorkTimeDj] where (DjState_1='正常' or DjState_2='正常' or DjState_3='正常' or DjState_4='正常' or DjState_5='正常' or DjState_6='正常')";
                str2 = str + SqlCreate;
                str3 = "" + str2 + " " + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str3);
                this.GridView1.DataBind();
            }
            if (base.Request.QueryString["type"] == "cd")
            {
                str = "select * from [qp_WorkTimeDj] where (DjState_1='迟到' or DjState_2='迟到' or DjState_3='迟到' or DjState_4='迟到' or DjState_5='迟到' or DjState_6='迟到')";
                str2 = str + SqlCreate;
                str3 = "" + str2 + " " + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str3);
                this.GridView1.DataBind();
            }
            if (base.Request.QueryString["type"] == "zt")
            {
                str = "select * from [qp_WorkTimeDj] where (DjState_1='早退' or DjState_2='早退' or DjState_3='早退' or DjState_4='早退' or DjState_5='早退' or DjState_6='早退')";
                str2 = str + SqlCreate;
                str3 = "" + str2 + " " + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str3);
                this.GridView1.DataBind();
            }
            if (base.Request.QueryString["type"] == "wkq")
            {
                str = "select * from [qp_WorkTimeDj] where (DjState_1='未考勤' or DjState_2='未考勤' or DjState_3='未考勤' or DjState_4='未考勤' or DjState_5='未考勤' or DjState_6='未考勤')";
                str2 = str + SqlCreate;
                str3 = "" + str2 + " " + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str3);
                this.GridView1.DataBind();
            }
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (this.ViewState["DjType_1"].ToString() == "未启用")
                {
                    e.Row.Cells[1].Visible = false;
                }
                if (this.ViewState["DjType_2"].ToString() == "未启用")
                {
                    e.Row.Cells[2].Visible = false;
                }
                if (this.ViewState["DjType_3"].ToString() == "未启用")
                {
                    e.Row.Cells[3].Visible = false;
                }
                if (this.ViewState["DjType_4"].ToString() == "未启用")
                {
                    e.Row.Cells[4].Visible = false;
                }
                if (this.ViewState["DjType_5"].ToString() == "未启用")
                {
                    e.Row.Cells[5].Visible = false;
                }
                if (this.ViewState["DjType_6"].ToString() == "未启用")
                {
                    e.Row.Cells[6].Visible = false;
                }
            }
            catch
            {
            }
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
                Label label = (Label) e.Row.FindControl("L_DjState_1");
                label.Text = label.Text.Replace(this.ViewState["leixing"].ToString(), "<b><font color=red>" + this.ViewState["leixing"].ToString() + "</font></b>");
                Label label2 = (Label) e.Row.FindControl("L_DjState_2");
                label2.Text = label2.Text.Replace(this.ViewState["leixing"].ToString(), "<b><font color=red>" + this.ViewState["leixing"].ToString() + "</font></b>");
                Label label3 = (Label) e.Row.FindControl("L_DjState_3");
                label3.Text = label3.Text.Replace(this.ViewState["leixing"].ToString(), "<b><font color=red>" + this.ViewState["leixing"].ToString() + "</font></b>");
                Label label4 = (Label) e.Row.FindControl("L_DjState_4");
                label4.Text = label4.Text.Replace(this.ViewState["leixing"].ToString(), "<b><font color=red>" + this.ViewState["leixing"].ToString() + "</font></b>");
                Label label5 = (Label) e.Row.FindControl("L_DjState_5");
                label5.Text = label5.Text.Replace(this.ViewState["leixing"].ToString(), "<b><font color=red>" + this.ViewState["leixing"].ToString() + "</font></b>");
                Label label6 = (Label) e.Row.FindControl("L_DjState_6");
                label6.Text = label6.Text.Replace(this.ViewState["leixing"].ToString(), "<b><font color=red>" + this.ViewState["leixing"].ToString() + "</font></b>");
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
                if (base.Request.QueryString["type"] == "zc")
                {
                    this.ViewState["leixing"] = "正常";
                }
                if (base.Request.QueryString["type"] == "cd")
                {
                    this.ViewState["leixing"] = "迟到";
                }
                if (base.Request.QueryString["type"] == "zt")
                {
                    this.ViewState["leixing"] = "早退";
                }
                if (base.Request.QueryString["type"] == "wkq")
                {
                    this.ViewState["leixing"] = "未考勤";
                }
                string sql = "select * from qp_WorkTime   where QyType='启用' and  (CHARINDEX('," + this.Session["username"] + ",',','+SyUsername+',')   >   0 ) ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["DjType_1"] = list["DjType_1"].ToString();
                    this.ViewState["DjType_2"] = list["DjType_2"].ToString();
                    this.ViewState["DjType_3"] = list["DjType_3"].ToString();
                    this.ViewState["DjType_4"] = list["DjType_4"].ToString();
                    this.ViewState["DjType_5"] = list["DjType_5"].ToString();
                    this.ViewState["DjType_6"] = list["DjType_6"].ToString();
                    this.ViewState["DjTime_1"] = list["DjTime_1"].ToString();
                    this.ViewState["DjTime_2"] = list["DjTime_2"].ToString();
                    this.ViewState["DjTime_3"] = list["DjTime_3"].ToString();
                    this.ViewState["DjTime_4"] = list["DjTime_4"].ToString();
                    this.ViewState["DjTime_5"] = list["DjTime_5"].ToString();
                    this.ViewState["DjTime_6"] = list["DjTime_6"].ToString();
                }
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                this.Bindquanxian();
            }
        }
    }
}

