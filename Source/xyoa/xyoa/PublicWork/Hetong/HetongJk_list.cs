namespace xyoa.PublicWork.Hetong
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongJk_list : Page
    {
        protected Label AllMoney;
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Button Button2;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected TextBox Danwei;
        protected DropDownList DropDownList1;
        protected DropDownList Fenlei;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "jjjj8e", this.Session["perstr"].ToString());
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("HetongJk_list.aspx?user=" + base.Request.QueryString["user"] + "");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Zhuti.Text != "")
            {
                str = str + " and A.Zhuti like '%" + this.pulicss.GetFormatStr(this.Zhuti.Text) + "%'";
            }
            if (this.Danwei.Text != "")
            {
                str = str + " and A.Danwei like '%" + this.pulicss.GetFormatStr(this.Danwei.Text) + "%'";
            }
            if (this.LcZhuangtai.SelectedValue != "")
            {
                str = str + " and A.LcZhuangtai = '" + this.LcZhuangtai.SelectedValue + "'";
            }
            if (this.Fenlei.SelectedValue != "")
            {
                str = str + " and A.Fenlei = '" + this.Fenlei.SelectedValue + "'";
            }
            if (base.Request.QueryString["user"] != null)
            {
                str = str + " and A.Username = '" + base.Request.QueryString["user"] + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str2 = ("select A.Username as AUsername,A.Realname as ARealname,A.id,A.LcZhuangtai,A.DqBlXinming,A.DqBlUsername,A.Zhuti,A.Hetonghao,A.Fenlei,A.Zhuangtai,A.Danwei,A.Jine,B.Name as FenleiName from [qp_oa_HeTong] as [A] inner join [qp_oa_HetongLb] as [B] on [A].[Fenlei] = [B].id where CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_HetongSz where ZgUsername='" + this.Session["username"] + "')+',') > 0") + SqlCreate;
            string sql = string.Concat(new object[] { "select sum(A.Jine) as AllShuliang from  [qp_oa_HeTong] as [A] inner join [qp_oa_HetongLb] as [B] on [A].[Fenlei] = [B].id where CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_HetongSz where ZgUsername='", this.Session["username"], "')+',') > 0 ", SqlCreate, " " });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                if (list["AllShuliang"].ToString() == "")
                {
                    this.AllMoney.Text = "0.00";
                }
                else
                {
                    this.AllMoney.Text = string.Format("{0:N}", list["AllShuliang"]);
                }
            }
            else
            {
                this.AllMoney.Text = "0.00";
            }
            list.Close();
            string str4 = "" + str2 + " " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(str4);
            this.GridView1.DataBind();
            string str6 = ("select count(A.id) from [qp_oa_HeTong] as [A] inner join [qp_oa_HetongLb] as [B] on [A].[Fenlei] = [B].id where CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_HetongSz where ZgUsername='" + this.Session["username"] + "')+',') > 0") + SqlCreate;
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
                this.Bindquanxian();
                string sQL = "select * from qp_oa_HetongLb";
                this.list.Bind_DropDownList_kong(this.Fenlei, sQL, "id", "Name");
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

        protected void SearchData_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }
    }
}

