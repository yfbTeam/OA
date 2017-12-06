namespace xyoa.HumanResources.Employee.YuangongLL
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongLL_kq : Page
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
            this.pulicss.QuanXianVis(this.GridView1, "eeee4g", this.Session["perstr"].ToString());
        }

        public string CreateMidSql()
        {
            return string.Empty;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            string str2 = ("select * from [qp_WorkTimeDj] where  DjUsername='" + this.ViewState["Username"] + "'") + SqlCreate;
            string sql = "" + str2 + " " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
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
                string sql = "select Username from qp_hr_Yuangong  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Username"] = list["Username"].ToString();
                }
                list.Close();
                string str2 = "select * from qp_WorkTime   where QyType='启用' and  (CHARINDEX('," + this.ViewState["Username"] + ",',','+SyUsername+',')   >   0 ) ";
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    this.ViewState["DjType_1"] = reader2["DjType_1"].ToString();
                    this.ViewState["DjType_2"] = reader2["DjType_2"].ToString();
                    this.ViewState["DjType_3"] = reader2["DjType_3"].ToString();
                    this.ViewState["DjType_4"] = reader2["DjType_4"].ToString();
                    this.ViewState["DjType_5"] = reader2["DjType_5"].ToString();
                    this.ViewState["DjType_6"] = reader2["DjType_6"].ToString();
                    this.ViewState["DjTime_1"] = reader2["DjTime_1"].ToString();
                    this.ViewState["DjTime_2"] = reader2["DjTime_2"].ToString();
                    this.ViewState["DjTime_3"] = reader2["DjTime_3"].ToString();
                    this.ViewState["DjTime_4"] = reader2["DjTime_4"].ToString();
                    this.ViewState["DjTime_5"] = reader2["DjTime_5"].ToString();
                    this.ViewState["DjTime_6"] = reader2["DjTime_6"].ToString();
                }
                reader2.Close();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                this.Bindquanxian();
            }
        }
    }
}

