﻿namespace xyoa.HumanResources.Fenxi.Hetong
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class HetongCX_SearchList : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
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
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianBack("eeee8", this.Session["perstr"].ToString());
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

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (base.Request.QueryString["LeibieID"] != "0")
            {
                str = str + " and A.LeibieID = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["LeibieID"])) + "'";
            }
            if (base.Request.QueryString["Zhuangtai"] != "0")
            {
                str = str + " and A.Zhuangtai = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["Zhuangtai"])) + "'";
            }
            if (base.Request.QueryString["QyUsername"] != "")
            {
                str = str + " and A.QyUsername = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["QyUsername"])) + "'";
            }
            if (base.Request.QueryString["DQtime"] != "")
            {
                str = str + " and datediff(dd,getdate(),A.Endtime)<=" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["DQtime"])) + " and datediff(dd,getdate(),A.Endtime)>=0";
            }
            if ((base.Request.QueryString["Starttime"] != "") && (base.Request.QueryString["Endtime"] != ""))
            {
                str = str + " and ((A.QdTime between '" + base.Request.QueryString["Starttime"] + "'and  '" + base.Request.QueryString["Endtime"] + "') or (convert(char(10),cast(A.QdTime as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Starttime"] + "' as datetime),120)) or (convert(char(10),cast(A.QdTime as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Endtime"] + "' as datetime),120)) ) ";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.QdTime,A.id,A.LeibieID,A.QyUsername,A.QyRealname,A.Starttime,A.Endtime,A.Zhuangtai,D.[Mingcheng] as LeibieName,B.[Name] as BuMenName from [qp_hr_HetongMg] as [A]  inner join [qp_hr_HetongMB] as [D] on [A].[LeibieID] = [D].[Id] inner join [qp_oa_username] as [C] on [A].[QyUsername] = [C].[Username] inner join [qp_oa_Bumen] as [B] on [B].[id] = [C].[BuMenId] " + this.ViewState["strurl1"] + " where 1=1";
            string str2 = "select count(A.id) from [qp_hr_HetongMg] as [A]  inner join [qp_hr_HetongMB] as [D] on [A].[LeibieID] = [D].[Id] inner join [qp_oa_username] as [C] on [A].[QyUsername] = [C].[Username] inner join [qp_oa_Bumen] as [B] on [B].[id] = [C].[BuMenId] " + this.ViewState["strurl1"] + " where 1=1";
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
                if ((this.Session["searchurl"] != null) && (this.Session["searchurl"].ToString() != ""))
                {
                    this.ViewState["strurl1"] = "inner join [qp_hr_HetongMgFile] as [E] on" + this.Session["searchurl"].ToString() + "";
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

