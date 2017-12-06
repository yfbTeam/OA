﻿namespace xyoa.MyWork.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MynetMettingZc : Page
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
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Button SearchData;
        protected TextBox titles;

        public void BindAttribute()
        {
            this.titles.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "hhhh7b", this.Session["perstr"].ToString());
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
                this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
            }
            catch
            {
                this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
                base.Response.Write("<script language='javascript'>alert('请输入有效的页码字符！');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MynetMettingZc.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.titles.Text != "")
            {
                str = str + " and Name like '%" + this.pulicss.GetFormatStr(this.titles.Text) + "%'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.id,A.Name,A.MettingIp,A.Starttime,A.Endtime,A.State,A.MettingHeader,A.MettingHeaderUser, C.CodeName from [qp_oa_NetMetting] as [A] join [SystemCode] as [C] on [A].[State] = [C].CodeId and [C].FieldName = '8' where  MettingHeaderUser='" + this.Session["Username"] + "'";
            string str2 = "select count(id) from qp_oa_NetMetting where   MettingHeaderUser='" + this.Session["Username"] + "'";
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
            this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "canyu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = string.Concat(new object[] { "select  Name from qp_oa_NetMetting where    CHARINDEX(',", this.Session["Username"], ",',','+CjUsername+',')   >   0  and  id='", num, "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (!list.Read())
                {
                    string str2 = string.Concat(new object[] { "Update qp_oa_NetMetting  Set CjUsername=CjUsername+'", this.Session["username"], ",',  CjRealname=CjRealname+'", this.Session["realname"], ",' where ID='", num, "'" });
                    this.List.ExeSql(str2);
                    this.pulicss.InsertLog("参与会议", "我的会议");
                    list.Close();
                    this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
                }
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
                Label label = (Label) e.Row.FindControl("HyId");
                Label label2 = (Label) e.Row.FindControl("Label3");
                LinkButton button = (LinkButton) e.Row.FindControl("canyu");
                string sql = string.Concat(new object[] { "select  * from qp_oa_NetMetting where   CHARINDEX(',", this.Session["Username"], ",',','+CjUsername+',')   >   0  and  id='", label.Text, "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    label2.Text = "已参与";
                    button.Visible = false;
                }
                else
                {
                    label2.Text = "未参与";
                    button.Visible = true;
                }
                list.Close();
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
                this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
                this.Bindquanxian();
            }
        }

        protected void PagerButtonClick(object sender, EventArgs e)
        {
            try
            {
                this.GridView1.PageIndex = Convert.ToInt32(((LinkButton) sender).CommandName) - 1;
                this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
            }
            catch
            {
                base.Response.Write("<script language='javascript'>alert('没有这么多页！');</script>");
            }
        }

        protected void SearchData_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview("order by A.id desc", this.CreateMidSql());
        }
    }
}

