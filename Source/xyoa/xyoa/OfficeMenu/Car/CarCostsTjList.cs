namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarCostsTjList : Page
    {
        protected Button AddData;
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected HtmlInputHidden SortText;
        protected Label SumLabel;

        protected void AddData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CarCostsTj.aspx");
        }

        public void BindAttribute()
        {
            this.AddData.Attributes["onclick"] = "javascript:return showwait();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

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
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
            catch
            {
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                base.Response.Write("<script language='javascript'>alert('请输入有效的页码字符！');</script>");
            }
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (base.Request.QueryString["CarName"].ToString() != "")
            {
                str = str + " and CarName = '" + base.Request.QueryString["CarName"].ToString() + "'";
            }
            if ((base.Request.QueryString["Starttime"].ToString() != "") && (base.Request.QueryString["Endtime"].ToString() != ""))
            {
                str = str + " and (CostsTime between '" + base.Request.QueryString["Starttime"].ToString() + "'and  '" + base.Request.QueryString["Endtime"].ToString() + "' or convert(char(10),cast(CostsTime as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Starttime"].ToString() + "' as datetime),120) or convert(char(10),cast(CostsTime as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Endtime"].ToString() + "' as datetime),120) ) ";
            }
            if (base.Request.QueryString["BuMenId"].ToString() != "")
            {
                str = str + " and BuMenId = '" + base.Request.QueryString["BuMenId"].ToString() + "'";
            }
            if (base.Request.QueryString["CostsType"].ToString() != "")
            {
                str = str + " and CostsType = '" + base.Request.QueryString["CostsType"].ToString() + "'";
            }
            if (base.Request.QueryString["CostsName"].ToString() != "")
            {
                str = str + " and CostsName like '%" + base.Request.QueryString["CostsName"].ToString() + "%'";
            }
            if ((base.Request.QueryString["Jine1"].ToString() != "") && (base.Request.QueryString["Jine2"].ToString() != ""))
            {
                str = str + " and CostsMoney>=" + base.Request.QueryString["Jine1"].ToString() + " and CostsMoney<=" + base.Request.QueryString["Jine2"].ToString() + "";
            }
            if (base.Request.QueryString["Username"].ToString() != "")
            {
                str = str + " and Username = '" + base.Request.QueryString["Username"].ToString() + "'";
            }
            if (base.Request.QueryString["Description"].ToString() != "")
            {
                str = str + " and Description like '%" + base.Request.QueryString["Description"].ToString() + "%'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.*, C.Name from [qp_oa_CarCosts] as [A] join [qp_oa_Bumen] as [C] on [A].[BuMenId] = [C].id where 1=1";
            string str2 = "select count(id) from qp_oa_CarCosts where  1=1";
            string str3 = "select sum(CostsMoney) as summoney  from qp_oa_CarCosts where 1=1";
            string str4 = str + SqlCreate;
            string str5 = str2 + SqlCreate;
            string sql = str3 + SqlCreate;
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                try
                {
                    this.SumLabel.Text = string.Format("{0:N}", list["summoney"]);
                }
                catch
                {
                    this.SumLabel.Text = "0.00";
                }
            }
            else
            {
                this.SumLabel.Text = "0.00";
            }
            list.Close();
            string str7 = "" + str4 + " " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(str7);
            this.GridView1.DataBind();
            string str8 = str5;
            this.CountsLabel.Text = "" + this.List.GetCount(str8) + "";
            this.AllPageLabel.Text = Convert.ToString(this.GridView1.PageCount);
            this.CurrentlyPageLabel.Text = Convert.ToString((int) (this.GridView1.PageIndex + 1));
            this.btnFirst.CommandName = "1";
            this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
            this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : ((this.GridView1.PageIndex + 2)).ToString();
            this.btnLast.CommandName = this.GridView1.PageCount.ToString();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pulicss.addfenye(this.DropDownList1.SelectedValue);
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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
                this.BindAttribute();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
        }

        protected void PagerButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.GridView1.PageIndex = Convert.ToInt32(((LinkButton) sender).CommandName) - 1;
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
            catch
            {
                base.Response.Write("<script language='javascript'>alert('没有这么多页！');</script>");
            }
        }
    }
}

