namespace xyoa.Resources.ResMg
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ResFp : Page
    {
        protected Button AddData;
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
        protected Button DelData;
        protected DropDownList DropDownList1;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected TextBox JsRealname;
        protected TextBox JsUsername;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected DropDownList Quyu;
        protected Button SearchData;
        protected Button ShowData;
        protected HtmlInputHidden SortText;
        protected TextBox Startime;
        protected Button UpdateData;
        protected TextBox ZyId;
        protected DropDownList ZyLeibie;
        protected TextBox ZyName;
        protected TextBox ZyNum;

        protected void AddData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ResFp_add.aspx");
        }

        public void BindAttribute()
        {
            this.ZyName.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.AddData.Attributes["onclick"] = "javascript:return showwait();";
            this.UpdateData.Attributes["onclick"] = "javascript:return updatecheck();";
            this.DelData.Attributes["onclick"] = "javascript:return delcheck();";
            this.ShowData.Attributes["onclick"] = "javascript:return updatecheck();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.ZyName.Attributes.Add("readonly", "readonly");
            this.Startime.Attributes.Add("readonly", "readonly");
            this.JsRealname.Attributes.Add("readonly", "readonly");
            this.pulicss.QuanXianVis(this.AddData, "bbbb2b", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.UpdateData, "bbbb2b", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.ShowData, "bbbb2b", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.DelData, "bbbb2b", this.Session["perstr"].ToString());
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
            base.Response.Redirect("ResFp.aspx");
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
            if (this.JsUsername.Text != "")
            {
                str = str + " and A.JsUsername = '" + this.pulicss.GetFormatStr(this.JsUsername.Text) + "'";
            }
            if (this.Quyu.SelectedValue != "")
            {
                str = str + " and Quyu = '" + this.Quyu.SelectedValue + "'";
            }
            if (this.Cangku.SelectedValue != "")
            {
                str = str + " and Cangku = '" + this.Cangku.SelectedValue + "'";
            }
            if ((this.Startime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and (GmTime between '" + this.Startime.Text + "'and  '" + this.Endtime.Text + "' or convert(char(10),cast(GmTime as datetime),120)=convert(char(10),cast('" + this.Startime.Text + "' as datetime),120) or convert(char(10),cast(GmTime as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120) ) ";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.id,C.ZyXingzhi,A.JbName,A.GmTime,A.GmNum,A.JsRealname,A.JsUsername,A.States, C.ZyNum, C.ZyName, B.Name as CangkuName, E.Name as QuYuName, D.Name as ZyLeibieName from [qp_oa_ResFp] as [A] inner join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id inner join [qp_oa_ResourcesType] as [D] on [C].[ZyLeibie] = [D].id join [qp_oa_ResourcesCangKu] as [B] on [C].[Cangku] = [B].id join [qp_oa_ResourcesQuyu] as [E] on [C].[Quyu] = [E].id  where username='" + this.Session["username"] + "'";
            string str2 = "select count(A.id) from [qp_oa_ResFp] as [A] inner join [qp_oa_ResourcesAdd] as [C] on [A].[ZyId] = [C].id inner join [qp_oa_ResourcesType] as [D] on [C].[ZyLeibie] = [D].id where username='" + this.Session["username"] + "'";
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

        protected void DelData_Click(object sender, EventArgs e)
        {
            string str = this.CheckCbxDel();
            string sql = "  Delete from qp_oa_ResFp  where ID in (" + str + ")";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("删除物品分配", "物品分配");
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pulicss.addfenye(this.DropDownList1.SelectedValue);
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "jieshu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "select id,ZyId,GmNum from qp_oa_ResFp where id='" + num + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = "  Delete from qp_oa_MyRes  where KeyId='" + list["id"] + "' and  Laiyuan='分配'";
                    this.List.ExeSql(str2);
                    string str3 = "Update qp_oa_ResFp  Set States='已收回'  where id='" + num + "'";
                    this.List.ExeSql(str3);
                    string str4 = string.Concat(new object[] { "Update qp_oa_ResourcesAdd  Set KuCun=KuCun+", list["GmNum"], "  where id='", list["ZyId"], "'" });
                    this.List.ExeSql(str4);
                    this.pulicss.InsertLog("收回物品", "物品分配");
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
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton3");
                if (e.Row.Cells[9].Text.ToString() == "正常")
                {
                    button.Enabled = true;
                    button.Attributes.Add("onclick", "javascript:return confirm('确认收回[" + e.Row.Cells[2].Text.ToString() + "]吗？')");
                }
                else
                {
                    button.Enabled = false;
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
                this.Bindquanxian();
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

        protected void ShowData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ResFp_show.aspx?id=" + this.CheckCbxUpdate() + "");
        }

        protected void UpdateData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("ResFp_update.aspx?id=" + this.CheckCbxUpdate() + "");
        }
    }
}

