namespace xyoa.InfoManage.zhiao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ziliao_xiaolei_tj : Page
    {
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
        private Db List = new Db();
        private publics pulicss = new publics();
        protected right Right1;
        protected HtmlInputHidden SortText;
        protected taitou Taitou1;
        protected xiaolei_zl Xiaolei_zl1;

        public void BindAttribute()
        {
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
            return string.Empty;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            string str;
            string str2;
            string str3;
            string str4;
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            if (base.Request.QueryString["id"].ToString() != "0")
            {
                str = string.Concat(new object[] { "select A.id,A.cishu,A.Leibie, A.Name, A.NewName,A.Filetype, A.Settimes,A.Username,A.Realname, B.[Name] as LeibieName from [qp_oa_Zst_ziliao] as [A] inner join [qp_oa_Zst_leibie_zl] as [B] on [A].[Leibie] = [B].[Id] where  tuijian='1' and Leibie='", base.Request.QueryString["id"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+A.ZdBumenId+',') > 0 and A.States='2') or (CHARINDEX(',", this.Session["username"], ",',','+A.ZdUsername+',') > 0 and A.States='3') or (A.States='1'))" });
                str2 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Zst_ziliao] as [A] inner join [qp_oa_Zst_leibie_zl] as [B] on [A].[Leibie] = [B].[Id] where  tuijian='1' and Leibie='", base.Request.QueryString["id"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+A.ZdBumenId+',') > 0 and A.States='2') or (CHARINDEX(',", this.Session["username"], ",',','+A.ZdUsername+',') > 0 and A.States='3') or (A.States='1'))" });
                str3 = "" + str + " " + SqlCreate + "" + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str3);
                this.GridView1.DataBind();
                str4 = str2 + SqlCreate;
                this.CountsLabel.Text = "" + this.List.GetCount(str4) + "";
            }
            else
            {
                str = string.Concat(new object[] { "select A.id,A.cishu,A.Leibie, A.Name, A.NewName,A.Filetype, A.Settimes,A.Username,A.Realname, B.[Name] as LeibieName from [qp_oa_Zst_ziliao] as [A] inner join [qp_oa_Zst_leibie_zl] as [B] on [A].[Leibie] = [B].[Id] where  tuijian='1' and Leibie in (", this.ViewState["leibieid"], "0) and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+A.ZdBumenId+',') > 0 and A.States='2') or (CHARINDEX(',", this.Session["username"], ",',','+A.ZdUsername+',') > 0 and A.States='3') or (A.States='1'))" });
                str2 = string.Concat(new object[] { "select count(A.id)  from [qp_oa_Zst_ziliao] as [A] inner join [qp_oa_Zst_leibie_zl] as [B] on [A].[Leibie] = [B].[Id] where   tuijian='1' and Leibie in (", this.ViewState["leibieid"], "0) and  ((CHARINDEX(',", this.Session["BuMenId"], ",',','+A.ZdBumenId+',') > 0 and A.States='2') or (CHARINDEX(',", this.Session["username"], ",',','+A.ZdUsername+',') > 0 and A.States='3') or (A.States='1'))" });
                str3 = "" + str + " " + SqlCreate + "" + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str3);
                this.GridView1.DataBind();
                str4 = str2 + SqlCreate;
                this.CountsLabel.Text = "" + this.List.GetCount(str4) + "";
            }
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
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor1(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("Leibie");
                Label label2 = (Label) e.Row.FindControl("LeibieName");
                label2.Text = null;
                string sql = "select id,Name,ParentNodesID from qp_oa_Zst_leibie_zl where  id='" + label.Text + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    label2.Text = string.Concat(new object[] { "<a href=\"ziliao_xiaolei.aspx?ParentNodesID=", list["ParentNodesID"], "&id=", list["id"], "\" title=\"", this.pulicss.TypeCode("qp_oa_Zst_leibie_zl", list["ParentNodesID"].ToString()), " >> ", list["Name"], "\">", list["Name"], "</a>" });
                }
                list.Close();
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
                string sql = "select Name from qp_oa_Zst_leibie_zl  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["ParentNodesID"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Name"] = list["Name"].ToString();
                }
                list.Close();
                if (base.Request.QueryString["id"].ToString() != "0")
                {
                    string str2 = "select Name from qp_oa_Zst_leibie_zl  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        this.ViewState["XName"] = "" + reader2["Name"].ToString() + " >> ";
                    }
                    reader2.Close();
                }
                this.ViewState["leibieid"] = null;
                string str3 = "select id from qp_oa_Zst_leibie_zl  where ParentNodesID='" + this.pulicss.GetFormatStr(base.Request.QueryString["ParentNodesID"]) + "'";
                SqlDataReader reader3 = this.List.GetList(str3);
                while (reader3.Read())
                {
                    StateBag bag = ViewState;
                    object obj2 = bag["leibieid"];
                    (bag = this.ViewState)["leibieid"] = string.Concat(new object[] { obj2, "", reader3["id"].ToString(), "," });
                }
                reader3.Close();
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

