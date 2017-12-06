namespace xyoa.HumanResources.ZhaoPin.JianLi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class JianLi : Page
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
        protected Button Mianshi;
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected Button UpdateData;
        protected TextBox Xingming;
        protected DropDownList Zhiwei;

        protected void AddData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("JianLi_add.aspx");
        }

        public void BindAttribute()
        {
            this.Xingming.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.AddData.Attributes["onclick"] = "javascript:return showwait();";
            this.UpdateData.Attributes["onclick"] = "javascript:return updatecheck();";
            this.DelData.Attributes["onclick"] = "javascript:return delcheck();";
            this.Mianshi.Attributes["onclick"] = "javascript:return mianshicheck();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.AddData, "eeee1ca", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.UpdateData, "eeee1cc", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.DelData, "eeee1cd", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.Mianshi, "eeee1cc", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.GridView1, "eeee1cb", this.Session["perstr"].ToString());
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
            base.Response.Redirect("JianLi.aspx?Zhuangtai=" + base.Request.QueryString["Zhuangtai"] + "");
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
            if (this.Xingming.Text != "")
            {
                str = str + " and Xingming like '%" + this.pulicss.GetFormatStr(this.Xingming.Text) + "%'";
            }
            if (this.Zhiwei.SelectedValue != "")
            {
                str = str + " and Zhiwei = '" + this.Zhiwei.SelectedValue + "'";
            }
            if (base.Request.QueryString["Zhuangtai"].ToString() != "0")
            {
                str = str + " and Zhuangtai = '" + base.Request.QueryString["Zhuangtai"].ToString() + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.id,A.Xingming,A.Xingbie,A.Zhiwei,A.Lianxi,A.Zhuangtai,A.Username,A.Realname,D.[Name] as ZhiweiName from [qp_hr_JianLi] as [A]  inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiwei] = [D].[Id] where 1=1";
            string str2 = "select count(A.id) from [qp_hr_JianLi] as [A]  inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiwei] = [D].[Id] where 1=1";
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
            string sql = "  Delete from qp_hr_JianLi  where ID in (" + str + ")";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("删除简历管理", "简历管理");
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

        protected void Jieshu_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("JianLi_ms.aspx?id=" + this.CheckCbxUpdate() + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiwei, sQL, "id", "name");
                this.BindAttribute();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                this.Bindquanxian();
                if (base.Request.QueryString["Zhuangtai"].ToString() == "1")
                {
                    this.ViewState["btncss1"] = "btn4on";
                    this.ViewState["btncss2"] = "btn4off";
                    this.ViewState["btncss3"] = "btn4off";
                    this.ViewState["btncss4"] = "btn4off";
                    this.ViewState["btncss5"] = "btn4off";
                }
                if (base.Request.QueryString["Zhuangtai"].ToString() == "2")
                {
                    this.ViewState["btncss1"] = "btn4off";
                    this.ViewState["btncss2"] = "btn4off";
                    this.ViewState["btncss3"] = "btn4off";
                    this.ViewState["btncss4"] = "btn4off";
                    this.ViewState["btncss5"] = "btn4on";
                    this.UpdateData.Visible = false;
                    this.DelData.Visible = false;
                    this.Mianshi.Visible = false;
                }
                if (base.Request.QueryString["Zhuangtai"].ToString() == "3")
                {
                    this.ViewState["btncss1"] = "btn4off";
                    this.ViewState["btncss2"] = "btn4off";
                    this.ViewState["btncss3"] = "btn4on";
                    this.ViewState["btncss4"] = "btn4off";
                    this.ViewState["btncss5"] = "btn4off";
                }
                if (base.Request.QueryString["Zhuangtai"].ToString() == "4")
                {
                    this.ViewState["btncss1"] = "btn4off";
                    this.ViewState["btncss2"] = "btn4off";
                    this.ViewState["btncss3"] = "btn4off";
                    this.ViewState["btncss4"] = "btn4on";
                    this.ViewState["btncss5"] = "btn4off";
                    this.UpdateData.Visible = false;
                    this.DelData.Visible = false;
                    this.Mianshi.Visible = false;
                }
                if (base.Request.QueryString["Zhuangtai"].ToString() == "5")
                {
                    this.ViewState["btncss1"] = "btn4off";
                    this.ViewState["btncss2"] = "btn4on";
                    this.ViewState["btncss3"] = "btn4off";
                    this.ViewState["btncss4"] = "btn4off";
                    this.ViewState["btncss5"] = "btn4off";
                    this.UpdateData.Visible = false;
                    this.DelData.Visible = false;
                    this.Mianshi.Visible = false;
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
            base.Response.Redirect("JianLi_update.aspx?id=" + this.CheckCbxUpdate() + "");
        }
    }
}

