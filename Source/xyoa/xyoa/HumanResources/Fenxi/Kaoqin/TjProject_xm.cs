namespace xyoa.HumanResources.Fenxi.Kaoqin
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class TjProject_xm : Page
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
            this.pulicss.QuanXianBack("eeee8", this.Session["perstr"].ToString());
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (base.Request.QueryString["user"] != "")
            {
                str = str + " and Username='" + base.Request.QueryString["user"] + "'";
            }
            if ((base.Request.QueryString["start"] != "") && (base.Request.QueryString["last"] != ""))
            {
                str = str + " and ((StartTime between '" + base.Request.QueryString["start"] + "'and  '" + base.Request.QueryString["last"] + "') or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["start"] + "' as datetime),120)) or (convert(char(10),cast(StartTime as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["last"] + "' as datetime),120)))";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            string str2 = ("select * from [qp_hr_MyAttendance]  where Zhuangtai='2' and type='" + base.Request.QueryString["type"] + "'") + SqlCreate;
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
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                this.Bindquanxian();
                if (base.Request.QueryString["type"].ToString() == "1")
                {
                    this.ViewState["typename"] = "出差管理";
                }
                if (base.Request.QueryString["type"].ToString() == "2")
                {
                    this.ViewState["typename"] = "休假管理";
                }
                if (base.Request.QueryString["type"].ToString() == "3")
                {
                    this.ViewState["typename"] = "加班管理";
                }
            }
        }
    }
}

