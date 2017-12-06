﻿namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class AddWorkFlow_show : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Button Button2;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected DropDownList DropDownList1;
        protected TextBox FlowName;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Namefile;
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;

        public void BindAttribute()
        {
            this.FlowName.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
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
            base.Response.Redirect("AddWorkFlow_show.aspx?id=" + base.Request.QueryString["id"] + "");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.FlowName.Text != "")
            {
                str = str + " and FlowName like '%" + this.pulicss.GetFormatStr(this.FlowName.Text) + "%'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = string.Concat(new object[] { "select * from qp_oa_WorkFlowName  where FlowType='正常' and FormId='", base.Request.QueryString["id"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
            string str2 = string.Concat(new object[] { "select count(id) from qp_oa_WorkFlowName where  FlowType='正常' and FormId='", base.Request.QueryString["id"], "' and ((CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1'))" });
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
                Label label = (Label) e.Row.FindControl("FlowNumber");
                Label label2 = (Label) e.Row.FindControl("Label1");
                if (e.Row.Cells[1].Text.ToString() == "自由流程")
                {
                    label2.Text = " <a href=\"javascript:void(0)\" onclick='var num=Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"AddWorkFlow_add_zy.aspx?FlowNumber=" + label.Text + "&FormId=" + base.Request.QueryString["id"] + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>新建工作</a>";
                }
                else
                {
                    label2.Text = " <a href=\"javascript:void(0)\" onclick='var num=Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"AddWorkFlow_add.aspx?FlowNumber=" + label.Text + "&FormId=" + base.Request.QueryString["id"] + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>新建工作</a>";
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
                this.BindAttribute();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                string sql = "select FormName from qp_oa_DIYForm   where id='" + int.Parse(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Namefile.Text = list["FormName"].ToString();
                }
                else
                {
                    this.Namefile.Text = "请点击左边的表单选择";
                }
                list.Close();
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

