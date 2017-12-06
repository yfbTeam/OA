﻿namespace xyoa.HumanResources.ZhaoPin.ZhaopinJhMG
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ZhaopinJhMG : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected DropDownList Bumen;
        protected Button Button1;
        protected Button Button2;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected DropDownList DropDownList1;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Starttime;
        protected DropDownList Zhiwei;
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.Zhuti.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "eeee1i", this.Session["perstr"].ToString());
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
            base.Response.Redirect("ZhaopinJhMG.aspx?Zhuangtai=" + base.Request.QueryString["Zhuangtai"] + "");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Zhuti.Text != "")
            {
                str = str + " and Zhuti like '%" + this.pulicss.GetFormatStr(this.Zhuti.Text) + "%'";
            }
            if ((this.Starttime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and ((Qixian between '" + this.Starttime.Text + "'and  '" + this.Endtime.Text + "') or (convert(char(10),cast(Qixian as datetime),120)=convert(char(10),cast('" + this.Starttime.Text + "' as datetime),120)) or (convert(char(10),cast(Qixian as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120)))";
            }
            if (this.Bumen.SelectedValue != "")
            {
                str = str + " and Bumen = '" + this.Bumen.SelectedValue + "'";
            }
            if (this.Zhiwei.SelectedValue != "")
            {
                str = str + " and Zhiwei = '" + this.Zhiwei.SelectedValue + "'";
            }
            return str;
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
            if (base.Request.QueryString["Zhuangtai"].ToString() == "1")
            {
                str = "select A.Jieshu,A.id,A.Zhuti,A.Bumen,A.Zhiwei,A.Renshu,A.Qixian,A.Zhuangtai,A.Username,A.Realname, B.[Name] as BuMenName,  D.[Name] as ZhiweiName from [qp_hr_ZhaopinJh] as [A] inner join [qp_oa_Bumen] as [B] on [A].[Bumen] = [B].[Id]  inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiwei] = [D].[Id] where (SpUsername='" + this.Session["username"] + "' and (A.Zhuangtai='1' or A.Zhuangtai='4'))";
                str2 = "select count(id) from qp_hr_ZhaopinJh as [A] where (SpUsername='" + this.Session["username"] + "' and (A.Zhuangtai='1' or A.Zhuangtai='4'))";
                str3 = str + SqlCreate;
                str4 = str2 + SqlCreate;
                str5 = "" + str3 + " " + Sqlsort + "";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str5);
                this.GridView1.DataBind();
                str6 = str4;
                this.CountsLabel.Text = "" + this.List.GetCount(str6) + "";
            }
            if (base.Request.QueryString["Zhuangtai"].ToString() == "2")
            {
                str = string.Concat(new object[] { "select A.Jieshu,A.id,A.Zhuti,A.Bumen,A.Zhiwei,A.Renshu,A.Qixian,A.Zhuangtai,A.Username,A.Realname, B.[Name] as BuMenName,  D.[Name] as ZhiweiName from [qp_hr_ZhaopinJh] as [A] inner join [qp_oa_Bumen] as [B] on [A].[Bumen] = [B].[Id]  inner join [qp_oa_Zhiwei] as [D] on [A].[Zhiwei] = [D].[Id] where (SpUsername!='", this.Session["username"], "' and (CHARINDEX(',", this.Session["username"], ",',','+YspUsername+',')   >   0 ))" });
                str2 = string.Concat(new object[] { "select count(id) from qp_hr_ZhaopinJh as [A] where (SpUsername!='", this.Session["username"], "' and (CHARINDEX(',", this.Session["username"], ",',','+YspUsername+',')   >   0 ))" });
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
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label label = (Label) e.Row.FindControl("LabVisible");
                Label label2 = (Label) e.Row.FindControl("LabNameVisible");
                Label label3 = (Label) e.Row.FindControl("Label1");
                if (base.Request.QueryString["Zhuangtai"].ToString() == "1")
                {
                    label3.Text = " <a href='ZhaopinJhMG_show.aspx?id=" + label.Text + "' class=\"LinkLine\">" + label2.Text + "</a>";
                }
                if (base.Request.QueryString["Zhuangtai"].ToString() == "2")
                {
                    label3.Text = " <a href='ZhaopinJhMG_showYsp.aspx?id=" + label.Text + "' class=\"LinkLine\">" + label2.Text + "</a>";
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
                this.pulicss.BindListkong("qp_oa_Bumen", this.Bumen, "", "order by Bianhao asc");
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiwei, sQL, "id", "name");
                this.BindAttribute();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                this.Bindquanxian();
                if (base.Request.QueryString["Zhuangtai"].ToString() == "1")
                {
                    this.ViewState["btncss1"] = "btn4on";
                    this.ViewState["btncss2"] = "btn4off";
                }
                if (base.Request.QueryString["Zhuangtai"].ToString() == "2")
                {
                    this.ViewState["btncss1"] = "btn4off";
                    this.ViewState["btncss2"] = "btn4on";
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

