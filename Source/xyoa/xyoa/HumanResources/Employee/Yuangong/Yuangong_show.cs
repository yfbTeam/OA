namespace xyoa.HumanResources.Employee.Yuangong
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Yuangong_show : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected HtmlInputButton Button2;
        protected Button Button4;
        protected Button Button5;
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
            this.Button5.Attributes["onclick"] = "javascript:return delcheck();";
            this.Button4.Attributes["onclick"] = "javascript:return updatecheck();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.Button2, "eeee4aa", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.Button4, "eeee4ac", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.Button5, "eeee4ad", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.GridView1, "eeee4ab", this.Session["perstr"].ToString());
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

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (this.CheckCbxDel() == "0")
            {
                base.Response.Write("<script language='javascript'>alert('请选择需要修改的员工档案');</script>");
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(base.GetType(), "starup", "<script language= 'javascript'>updatefrom1('" + this.CheckCbxUpdate() + "');</script>");
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string str = this.CheckCbxDel();
            string sql = "  Delete from qp_hr_Yuangong  where ID in (" + str + ")";
            this.List.ExeSql(sql);
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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
            return string.Empty;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            string str;
            string str2;
            string str3;
            string str4;
            string str5;
            string str6;
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            if (base.Request.QueryString["bmid"].ToString() == "0")
            {
                str = "select A.id,A.Xingming,A.Xingbie,A.Zhiwei,A.Chusheng,A.Xuexi,A.Zaizhi,D.[Name] as ZhiweiName from [qp_hr_Yuangong] as [A]  inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiwei] = [D].[Id]  where 1=1";
                str2 = "select count(A.id) from [qp_hr_Yuangong] as [A]  inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiwei] = [D].[Id]  where 1=1";
                str3 = str + SqlCreate;
                str4 = str2 + SqlCreate;
                str5 = "" + str3 + " " + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str5);
                this.GridView1.DataBind();
                str6 = str4;
                this.CountsLabel.Text = "" + this.List.GetCount(str6) + "";
            }
            else
            {
                str = "select A.id,A.Xingming,A.Xingbie,A.Zhiwei,A.Chusheng,A.Xuexi,A.Zaizhi,D.[Name] as ZhiweiName from [qp_hr_Yuangong] as [A]  inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiwei] = [D].[Id]  where Bumen='" + base.Request.QueryString["bmid"].ToString() + "'";
                str2 = "select count(A.id) from [qp_hr_Yuangong] as [A]  inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiwei] = [D].[Id]  where Bumen='" + base.Request.QueryString["bmid"].ToString() + "'";
                str3 = str + SqlCreate;
                str4 = str2 + SqlCreate;
                str5 = "" + str3 + " " + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str5);
                this.GridView1.DataBind();
                str6 = str4;
                this.CountsLabel.Text = "" + this.List.GetCount(str6) + "";
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
                if (base.Request.QueryString["bmid"].ToString() == "0")
                {
                    this.ViewState["Bumen"] = "请点击左边部门筛选";
                }
                else
                {
                    this.ViewState["Bumen"] = this.pulicss.TypeCode("qp_oa_Bumen", base.Request.QueryString["bmid"].ToString());
                }
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
    }
}

