﻿namespace xyoa.SchTable.Xueji.Biangeng
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Richang_Zt : Page
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
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Xingming;

        public void BindAttribute()
        {
            this.Xingming.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "pppp2c", this.Session["perstr"].ToString());
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
            this.Xingming.Text = "";
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Xingming.Text != "")
            {
                str = str + " and C.Xingming like '%" + this.pulicss.GetFormatStr(this.Xingming.Text) + "%'";
            }
            return (str + " and A.BanJi='" + base.Request.QueryString["id"].ToString() + "'");
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select '" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "' as Xueduan,C.id,A.Xueqi,A.BanJi,A.XsId,A.Zhiwu,A.XuejiZhuangtai,C.Xingming,C.Xuejihao,C.Xuehao,C.Xingbie,C.Mingzhu,C.Jiguan,C.Chusheng,C.XuejiZhuangtai,C.HukouLeixing,C.Dianhua,B.[Mingcheng] as BanJiName from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1";
            string str2 = "select count(A.id) from [stu_table_" + this.divsch.GetXueqi() + "_" + this.divsch.GetXueduan().Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [qp_sch_Banji] as [B] on [A].[BanJi] = [B].[Id] where 1=1";
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
                Label label = (Label) e.Row.FindControl("Mingzhu");
                Label label2 = (Label) e.Row.FindControl("LMingzhu");
                Label label3 = (Label) e.Row.FindControl("XuejiZhuangtai");
                Label label4 = (Label) e.Row.FindControl("LXuejiZhuangtai");
                Label label5 = (Label) e.Row.FindControl("HukouLeixing");
                Label label6 = (Label) e.Row.FindControl("LHukouLeixing");
                label2.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", label.Text);
                label4.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", label3.Text);
                label6.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", label5.Text);
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
                if (base.Request.QueryString["id"] != null)
                {
                    if (base.Request.QueryString["id"].ToString() == "0")
                    {
                        this.Panel1.Visible = true;
                        this.Panel2.Visible = false;
                    }
                    else
                    {
                        this.Panel1.Visible = false;
                        this.Panel2.Visible = true;
                        this.BindAttribute();
                        this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                        this.Bindquanxian();
                    }
                }
                else
                {
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
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
    }
}

