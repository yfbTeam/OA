namespace xyoa.HumanResources.Gongzi.GongziSB
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class GongziSB : Page
    {
        protected Button AddData;
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Button Button2;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected Button DelData;
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
        protected Button UpdateData;
        protected DropDownList Zhangtao;
        protected TextBox Zhuti;

        protected void AddData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("GongziSB_add.aspx");
        }

        public void BindAttribute()
        {
            this.Zhuti.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.AddData.Attributes["onclick"] = "javascript:return showwait();";
            this.UpdateData.Attributes["onclick"] = "javascript:return updatecheck();";
            this.DelData.Attributes["onclick"] = "javascript:return delcheck();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.AddData, "eeee7b", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.UpdateData, "eeee7b", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.DelData, "eeee7b", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.GridView1, "eeee7b", this.Session["perstr"].ToString());
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
            base.Response.Redirect("GongziSB.aspx?Zhuangtai=" + base.Request.QueryString["Zhuangtai"] + "");
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
            if (this.Zhuti.Text != "")
            {
                str = str + " and A.Zhuti like '%" + this.pulicss.GetFormatStr(this.Zhuti.Text) + "%'";
            }
            if (this.Zhangtao.SelectedValue != "")
            {
                str = str + " and A.Zhangtao = '" + this.Zhangtao.SelectedValue + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = string.Concat(new object[] { "select A.NowTimes,A.Id,A.Zhangtao,A.StartTime,A.EndTime,A.Zhuti,A.Zhuangtai,A.SpUsername,A.SpRealname,B.Name as ZhangtaoName from [qp_hr_GongziSB] as [A]  inner join [qp_hr_GongziSZ] as [B] on [A].[Zhangtao] = [B].[Id]  where A.Zhuangtai='", base.Request.QueryString["Zhuangtai"].ToString(), "' and A.Username='", this.Session["username"], "'" });
            string str2 = string.Concat(new object[] { "select count(A.id) from [qp_hr_GongziSB] as [A]  inner join [qp_hr_GongziSZ] as [B] on [A].[Zhangtao] = [B].[Id]  where A.Zhuangtai='", base.Request.QueryString["Zhuangtai"].ToString(), "' and A.Username='", this.Session["username"], "'" });
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
            string sql = "select id,Number from qp_hr_GongziSB  where  ID in (" + str + ")";
            SqlDataReader list = this.List.GetList(sql);
            while (list.Read())
            {
                string str3 = "drop table hr_" + list["Number"].ToString() + "";
                this.List.ExeSql(str3);
                string str4 = "Delete from qp_hr_GongziSB  where ID ='" + list["id"].ToString() + "'";
                this.List.ExeSql(str4);
            }
            list.Close();
            this.pulicss.InsertLog("删除薪资上报", "薪资上报");
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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
                string sQL = "select id,Name from qp_hr_GongziSZ order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhangtao, sQL, "id", "Name");
                this.BindAttribute();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                this.Bindquanxian();
                if (base.Request.QueryString["Zhuangtai"].ToString() == "4")
                {
                    this.ViewState["btncss1"] = "btn4off";
                    this.ViewState["btncss2"] = "btn4off";
                    this.ViewState["btncss3"] = "btn4off";
                    this.ViewState["btncss4"] = "btn4on";
                }
                if (base.Request.QueryString["Zhuangtai"].ToString() == "1")
                {
                    this.ViewState["btncss1"] = "btn4on";
                    this.ViewState["btncss2"] = "btn4off";
                    this.ViewState["btncss3"] = "btn4off";
                    this.ViewState["btncss4"] = "btn4off";
                    this.UpdateData.Visible = false;
                    this.DelData.Visible = false;
                }
                if (base.Request.QueryString["Zhuangtai"].ToString() == "2")
                {
                    this.ViewState["btncss1"] = "btn4off";
                    this.ViewState["btncss2"] = "btn4on";
                    this.ViewState["btncss3"] = "btn4off";
                    this.ViewState["btncss4"] = "btn4off";
                    this.UpdateData.Visible = false;
                    this.DelData.Visible = false;
                }
                if (base.Request.QueryString["Zhuangtai"].ToString() == "3")
                {
                    this.ViewState["btncss1"] = "btn4off";
                    this.ViewState["btncss2"] = "btn4off";
                    this.ViewState["btncss3"] = "btn4on";
                    this.ViewState["btncss4"] = "btn4off";
                    this.UpdateData.Visible = false;
                }
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

        protected void UpdateData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("GongziSB_update.aspx?id=" + this.CheckCbxUpdate() + "");
        }
    }
}

