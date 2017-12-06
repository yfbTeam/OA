namespace xyoa.Resources.MyRes
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyResData : Page
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
        protected TextBox JsUsername;
        protected DropDownList Laiyuan;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected DropDownList Quyu;
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox ZyId;
        protected DropDownList ZyLeibie;
        protected TextBox ZyName;
        protected TextBox ZyNum;

        public void BindAttribute()
        {
            this.ZyName.Attributes.Add("readonly", "readonly");
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
            base.Response.Redirect("MyResData.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.ZyNum.Text != "")
            {
                str = str + " and C.ZyNum like '%" + this.pulicss.GetFormatStr(this.ZyNum.Text) + "%'";
            }
            if (this.ZyId.Text != "")
            {
                str = str + " and ZyId = '" + this.ZyId.Text + "'";
            }
            if (this.ZyLeibie.SelectedValue != "")
            {
                str = str + " and D.id = '" + this.ZyLeibie.SelectedValue + "'";
            }
            if (this.Laiyuan.SelectedValue != "")
            {
                str = str + " and A.Laiyuan = '" + this.Laiyuan.SelectedValue + "'";
            }
            if (this.Quyu.SelectedValue != "")
            {
                str = str + " and Quyu = '" + this.Quyu.SelectedValue + "'";
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
            string str = "select A.id,A.shuliang,A.Laiyuan,C.ZyNum, C.ZyName, B.Name as CangkuName, E.Name as QuYuName,D.Name as ZyLeibieName from [qp_oa_MyRes] as [A] inner join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id inner join [qp_oa_ResourcesType] as [D] on [C].[ZyLeibie] = [D].id join [qp_oa_ResourcesCangKu] as [B] on [C].[Cangku] = [B].id join [qp_oa_ResourcesQuyu] as [E] on [C].[Quyu] = [E].id  where username='" + this.Session["username"] + "'";
            string str2 = "select count(A.id) from [qp_oa_MyRes] as [A] inner join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id inner join [qp_oa_ResourcesType] as [D] on [C].[ZyLeibie] = [D].id  join [qp_oa_ResourcesCangKu] as [B] on [C].[Cangku] = [B].id join [qp_oa_ResourcesQuyu] as [E] on [C].[Quyu] = [E].id where username='" + this.Session["username"] + "'";
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int num;
            string str;
            SqlDataReader list;
            string str2;
            string str3;
            string str4;
            SqlDataReader reader2;
            string str5;
            if (e.CommandName == "syguihuan")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select id,ZyId,shuliang,KeyId from qp_oa_MyRes where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    str2 = "Update qp_oa_ResAppJy  Set WpStates='3'  where id='" + list["KeyId"] + "'";
                    this.List.ExeSql(str2);
                    str3 = string.Concat(new object[] { "Update qp_oa_ResourcesAdd  Set KuCun=KuCun+", list["shuliang"], "  where id='", list["ZyId"], "'" });
                    this.List.ExeSql(str3);
                    str4 = "select ZyName from qp_oa_ResourcesAdd where id='" + list["ZyId"] + "'";
                    reader2 = this.List.GetList(str4);
                    if (reader2.Read())
                    {
                        this.pulicss.InsertLog("归还借用物品" + reader2["ZyName"] + " ", "我拥有的物品");
                    }
                    reader2.Close();
                    str5 = "  Delete from qp_oa_MyRes  where id='" + num + "' ";
                    this.List.ExeSql(str5);
                }
                list.Close();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
            if (e.CommandName == "baofei")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select id,ZyId,KeyId,Shuliang from qp_oa_MyRes where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    string sql = string.Concat(new object[] { "Update qp_oa_ResourcesAdd   Set BfKuCun=BfKuCun+", list["Shuliang"], " where id='", list["ZyId"], "'" });
                    this.List.ExeSql(sql);
                    str2 = "Update qp_oa_ResAppSy  Set WpStates='3'  where id='" + list["KeyId"] + "'";
                    this.List.ExeSql(str2);
                    str4 = "select ZyName from qp_oa_ResourcesAdd where id='" + list["ZyId"] + "'";
                    reader2 = this.List.GetList(str4);
                    if (reader2.Read())
                    {
                        this.pulicss.InsertLog("报废物品" + reader2["ZyName"] + " ", "我拥有的物品");
                    }
                    reader2.Close();
                    str5 = "  Delete from qp_oa_MyRes  where id='" + num + "' ";
                    this.List.ExeSql(str5);
                }
                list.Close();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
            if (e.CommandName == "fbguihuan")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select id,ZyId,shuliang,KeyId from qp_oa_MyRes where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    str2 = "Update qp_oa_ResFp  Set States='已归还'  where id='" + list["KeyId"] + "'";
                    this.List.ExeSql(str2);
                    str3 = string.Concat(new object[] { "Update qp_oa_ResourcesAdd  Set KuCun=KuCun+", list["shuliang"], "  where id='", list["ZyId"], "'" });
                    this.List.ExeSql(str3);
                    str4 = "select ZyName from qp_oa_ResourcesAdd where id='" + list["ZyId"] + "'";
                    reader2 = this.List.GetList(str4);
                    if (reader2.Read())
                    {
                        this.pulicss.InsertLog("归还分配物品" + reader2["ZyName"] + " ", "我拥有的物品");
                    }
                    reader2.Close();
                    str5 = "  Delete from qp_oa_MyRes  where id='" + num + "' ";
                    this.List.ExeSql(str5);
                }
                list.Close();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                LinkButton button2 = (LinkButton) e.Row.FindControl("LinkButton2");
                LinkButton button3 = (LinkButton) e.Row.FindControl("LinkButton3");
                if (e.Row.Cells[6].Text.ToString() == "借用")
                {
                    button.Visible = true;
                    button2.Visible = false;
                    button3.Visible = false;
                    button.Attributes.Add("onclick", "javascript:return confirm('确认归还[" + e.Row.Cells[1].Text.ToString() + "]吗？')");
                }
                if (e.Row.Cells[6].Text.ToString() == "使用")
                {
                    button.Visible = false;
                    button2.Visible = true;
                    button3.Visible = false;
                    button2.Attributes.Add("onclick", "javascript:return confirm('确认报废[" + e.Row.Cells[1].Text.ToString() + "]吗？')");
                }
                if (e.Row.Cells[6].Text.ToString() == "分配")
                {
                    button.Visible = false;
                    button2.Visible = false;
                    button3.Visible = true;
                    button3.Attributes.Add("onclick", "javascript:return confirm('确认归还[" + e.Row.Cells[1].Text.ToString() + "]吗？')");
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
                string sQL = "select *  from qp_oa_ResourcesType";
                this.list.Bind_DropDownList_kong(this.ZyLeibie, sQL, "id", "Name");
                string str2 = "select *  from qp_oa_ResourcesCangKu";
                this.list.Bind_DropDownList_kong(this.Cangku, str2, "id", "Name");
                string str3 = "select *  from qp_oa_ResourcesQuyu";
                this.list.Bind_DropDownList_kong(this.Quyu, str3, "id", "Name");
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

