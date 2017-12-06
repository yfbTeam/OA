namespace xyoa.Resources.ResReport
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Zichang_list : Page
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
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected HtmlInputHidden SortText;

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
            string str = string.Empty;
            if (base.Request.QueryString["ZyLeibie"] != null)
            {
                str = str + " and ZyLeibie = '" + this.pulicss.GetFormatStr(base.Request.QueryString["ZyLeibie"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>物品类别分析，</font><font color=blue>类别：" + this.pulicss.TypeCode("qp_oa_ResourcesType", base.Request.QueryString["ZyLeibie"].ToString()) + "，</font>";
            }
            if (base.Request.QueryString["Quyu"] != null)
            {
                str = str + " and Quyu = '" + this.pulicss.GetFormatStr(base.Request.QueryString["Quyu"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>按所在区域分析，</font><font color=blue>区域：" + this.pulicss.TypeCode("qp_oa_ResourcesQuyu", base.Request.QueryString["Quyu"].ToString()) + "，</font>";
            }
            if (base.Request.QueryString["Cangku"] != null)
            {
                str = str + " and Cangku = '" + this.pulicss.GetFormatStr(base.Request.QueryString["Cangku"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>按所在仓库分析，</font><font color=blue>仓库：" + this.pulicss.TypeCode("qp_oa_ResourcesCangku", base.Request.QueryString["Cangku"].ToString()) + "，</font>";
            }
            if (base.Request.QueryString["Zhuangtai"] != null)
            {
                str = str + " and Zhuangtai = '" + this.pulicss.GetFormatStr(base.Request.QueryString["Zhuangtai"].ToString()) + "'";
                this.ViewState["Title"] = "<font color=red>按物品状态分析，</font><font color=blue>状态：" + base.Request.QueryString["Zhuangtai"].ToString().Replace("1", "正常").Replace("2", "丢失").Replace("3", "停用").Replace("4", "维修") + "，</font>";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.*, B.Name as CangkuName, C.Name as QuYuName, D.Name as ZyLeibieName from [qp_oa_ResourcesAdd] as [A] join [qp_oa_ResourcesCangKu] as [B] on [A].[Cangku] = [B].id join [qp_oa_ResourcesQuyu] as [C] on [A].[Quyu] = [C].id join [qp_oa_ResourcesType] as [D] on [A].[ZyLeibie] = [D].id where 1=1";
            string str2 = "select count(A.id) from [qp_oa_ResourcesAdd] as [A] join [qp_oa_ResourcesCangKu] as [B] on [A].[Cangku] = [B].id join [qp_oa_ResourcesQuyu] as [C] on [A].[Quyu] = [C].id join [qp_oa_ResourcesType] as [D] on [A].[ZyLeibie] = [D].id where 1=1";
            string str3 = str + SqlCreate;
            string str4 = str2 + SqlCreate;
            string sql = "" + str3 + " " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            string str6 = str4;
            this.CountsLabel.Text = "" + this.List.GetCount(str6) + "";
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

