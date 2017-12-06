namespace xyoa.Resources.MyRes
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyResApply_SearchList : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Button Button2;
        protected DropDownList Cangku;
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
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected DropDownList ZyLeibie;
        protected TextBox ZyName;
        protected TextBox ZyNum;

        public void BindAttribute()
        {
            this.ZyName.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyResApply_SearchList.aspx");
        }

        private string CheckCbxDel()
        {
            string str = "0";
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("CheckSelect");
                Label label = (Label) row.FindControl("LabVisible");
                if (box.Checked)
                {
                    if (str == "")
                    {
                        str = label.Text.ToString();
                    }
                    else
                    {
                        str = str + "," + label.Text.ToString();
                    }
                }
            }
            return str;
        }

        private string CheckCbxNameDel()
        {
            string str = string.Empty;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("CheckSelect");
                Label label = (Label) row.FindControl("LabNameVisible");
                if (box.Checked)
                {
                    if (str == "")
                    {
                        str = label.Text.ToString();
                    }
                    else
                    {
                        str = str + "," + label.Text.ToString();
                    }
                }
            }
            return str;
        }

        private string CheckCbxUpdate()
        {
            string str = string.Empty;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("CheckSelect");
                Label label = (Label) row.FindControl("LabVisible");
                if (box.Checked)
                {
                    if (str == "")
                    {
                        str = label.Text.ToString();
                    }
                    else
                    {
                        str = str + "," + label.Text.ToString();
                    }
                }
            }
            return str;
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.ZyNum.Text != "")
            {
                str = str + " and ZyNum like '%" + this.pulicss.GetFormatStr(this.ZyNum.Text) + "%'";
            }
            if (this.ZyName.Text != "")
            {
                str = str + " and ZyName like '%" + this.pulicss.GetFormatStr(this.ZyName.Text) + "%'";
            }
            if (this.ZyLeibie.SelectedValue != "")
            {
                str = str + " and ZyLeibie = '" + this.ZyLeibie.SelectedValue + "'";
            }
            if (this.Cangku.SelectedValue != "")
            {
                str = str + " and Cangku = '" + this.Cangku.SelectedValue + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = string.Concat(new object[] { "select A.*, B.Name as CangkuName, C.Name as QuYuName, D.Name as ZyLeibieName from [qp_oa_ResourcesAdd] as [A] join [qp_oa_ResourcesCangKu] as [B] on [A].[Cangku] = [B].id join [qp_oa_ResourcesQuyu] as [C] on [A].[Quyu] = [C].id join [qp_oa_ResourcesType] as [D] on [A].[ZyLeibie] = [D].id where 1=1 and ((B.States='1') or (CHARINDEX(',", this.Session["BuMenId"], ",',','+B.ZdBumenId+',') > 0 and B.States='2') or (CHARINDEX(',", this.Session["username"], ",',','+B.ZdUsername+',') > 0 and B.States='3'))  and A.Zhuangtai='1'" });
            string str2 = string.Concat(new object[] { "select count(A.id) from [qp_oa_ResourcesAdd] as [A] join [qp_oa_ResourcesCangKu] as [B] on [A].[Cangku] = [B].id join [qp_oa_ResourcesQuyu] as [C] on [A].[Quyu] = [C].id join [qp_oa_ResourcesType] as [D] on [A].[ZyLeibie] = [D].id where 1=1 and ((B.States='1') or (CHARINDEX(',", this.Session["BuMenId"], ",',','+B.ZdBumenId+',') > 0 and B.States='2') or (CHARINDEX(',", this.Session["username"], ",',','+B.ZdUsername+',') > 0 and B.States='3'))  and A.Zhuangtai='1'" });
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("StringId");
                Label label2 = (Label) e.Row.FindControl("Label2");
                Label label3 = (Label) e.Row.FindControl("ZyXingzhi");
                if (label3.Text.ToString() == "2")
                {
                    label2.Text = "<a href='MyResApply_SearchListJy.aspx?id=" + label.Text + "'>申请借用</a>";
                }
                else
                {
                    label2.Text = "<a href='MyResApply_SearchListSy.aspx?id=" + label.Text + "'>申请使用</a>";
                }
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
                if (base.Request.QueryString["ZyNum"] != null)
                {
                    this.ZyNum.Text = this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["ZyNum"]));
                }
                else
                {
                    this.ZyNum.Text = "";
                }
                if (base.Request.QueryString["ZyName"] != null)
                {
                    this.ZyName.Text = this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["ZyName"]));
                }
                else
                {
                    this.ZyName.Text = "";
                }
                if ((base.Request.QueryString["ZyLeibie"] != null) && (base.Request.QueryString["ZyLeibie"] != ""))
                {
                    this.ZyLeibie.SelectedValue = this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["ZyLeibie"]));
                }
                if ((base.Request.QueryString["Cangku"] != null) && (base.Request.QueryString["Cangku"] != ""))
                {
                    this.Cangku.SelectedValue = this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["Cangku"]));
                }
                string sQL = "select *  from qp_oa_ResourcesType";
                this.list.Bind_DropDownList_kong(this.ZyLeibie, sQL, "id", "Name");
                string str2 = string.Concat(new object[] { "select *  from qp_oa_ResourcesCangKu where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1') order by Paixun asc" });
                this.list.Bind_DropDownList_kong(this.Cangku, str2, "id", "Name");
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

        protected void SearchData_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }
    }
}

