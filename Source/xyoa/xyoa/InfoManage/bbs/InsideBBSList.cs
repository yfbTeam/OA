namespace xyoa.InfoManage.bbs
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class InsideBBSList : Page
    {
        protected Button AddData;
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox titles;

        protected void AddData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("InsideBBSListAdd.aspx?id=" + base.Request.QueryString["id"] + "");
        }

        public void BindAttribute()
        {
            this.titles.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
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
                this.DataBindToGridview(this.SortText.Value);
            }
            catch
            {
                this.DataBindToGridview(this.SortText.Value);
                base.Response.Write("<script language='javascript'>alert('请输入有效的页码字符！');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("InsideBBSList.aspx?id=" + base.Request.QueryString["id"] + "");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("InsideBBS.aspx");
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
            if ((base.Request.QueryString["key"] != null) && (base.Request.QueryString["titles"] != ""))
            {
                str = str + " and Titles like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["titles"])) + "%'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort)
        {
            string str6;
            string str7;
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select * from qp_oa_InsideBBS where BigId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and ParentNodesID='0'";
            string str2 = "select count(id) from qp_oa_InsideBBS where  BigId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and ParentNodesID='0'";
            string str3 = string.Empty;
            str3 = this.CreateMidSql();
            string str4 = str + str3;
            string str5 = str2 + str3;
            if (base.Request.QueryString["key"] != null)
            {
                str6 = "" + str4 + " " + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str6);
                this.GridView1.DataBind();
                str7 = str5;
                this.CountsLabel.Text = "" + this.List.GetCount(str7) + "";
            }
            else
            {
                str7 = "select count(id) from  qp_oa_InsideBBS where BigId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and ParentNodesID='0'";
                this.CountsLabel.Text = "" + this.List.GetCount(str7) + "";
                str6 = "select *  from qp_oa_InsideBBS where BigId='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "' and ParentNodesID='0' " + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str6);
                this.GridView1.DataBind();
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
            this.DataBindToGridview(this.SortText.Value);
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
                Label label = (Label) e.Row.FindControl("Lid1");
                Label label2 = (Label) e.Row.FindControl("Lid2");
                Label label3 = (Label) e.Row.FindControl("Label1");
                Label label4 = (Label) e.Row.FindControl("Label2");
                Label label5 = (Label) e.Row.FindControl("Label3");
                label3.Text = null;
                label4.Text = null;
                string sql = "select * from qp_oa_InsideBBS where id='" + label.Text + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2 = "select count(id) from qp_oa_InsideBBS where  ParentNodesID='" + label.Text + "'";
                    label3.Text = string.Concat(new object[] { "", this.List.GetCount(str2), "/", list["PointNum"].ToString(), "" });
                }
                list.Close();
                string str3 = "select top 1 * from qp_oa_InsideBBS where ParentNodesID='" + label.Text + "' order by Settime desc";
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    label4.Text = "" + reader2["Settime"].ToString() + "";
                    label5.Text = "" + reader2["Realname"].ToString() + "";
                }
                reader2.Close();
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
            this.DataBindToGridview(sqlsort);
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
                string sql = "select Name from qp_oa_InsideBBSBig where id='" + base.Request.QueryString["id"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["Name"] = list["Name"].ToString();
                }
                list.Close();
                this.BindAttribute();
                this.DataBindToGridview(this.SortText.Value);
            }
        }

        protected void PagerButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.GridView1.PageIndex = Convert.ToInt32(((LinkButton) sender).CommandName) - 1;
                this.DataBindToGridview(this.SortText.Value);
            }
            catch
            {
                base.Response.Write("<script language='javascript'>alert('没有这么多页！');</script>");
            }
        }

        protected void SearchData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("InsideBBSList.aspx?key=1&titles=" + this.titles.Text + "&id=" + base.Request.QueryString["id"] + "");
        }
    }
}

