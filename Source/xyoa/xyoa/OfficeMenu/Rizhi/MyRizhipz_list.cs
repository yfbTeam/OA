namespace xyoa.OfficeMenu.Rizhi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyRizhipz_list : Page
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
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList LeiBie;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Pizhu;
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Startime;
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
            this.pulicss.QuanXianVis(this.GridView1, "kkkk6b", this.Session["perstr"].ToString());
            this.Startime.Attributes.Add("readonly", "readonly");
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
            if (base.Request.QueryString["user"] != null)
            {
                base.Response.Redirect("MyRizhipz_list.aspx?user=" + base.Request.QueryString["user"] + "");
            }
            if (base.Request.QueryString["StartTime"] != null)
            {
                base.Response.Redirect("MyRizhipz_list.aspx?StartTime=" + base.Request.QueryString["StartTime"] + "&EndTime=" + base.Request.QueryString["EndTime"] + "");
            }
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.titles.Text != "")
            {
                str = str + " and A.titles like '%" + this.pulicss.GetFormatStr(this.titles.Text) + "%'";
            }
            if ((this.Startime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and (NowTimes between '" + this.Startime.Text + "'and  '" + this.Endtime.Text + "' or convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + this.Startime.Text + "' as datetime),120) or convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120) ) ";
            }
            if (this.LeiBie.SelectedValue != "")
            {
                str = str + " and A.LeiBie = '" + this.LeiBie.SelectedValue + "'";
            }
            if (base.Request.QueryString["user"] != null)
            {
                str = str + " and A.Username = '" + base.Request.QueryString["user"] + "'";
            }
            if (!(this.Pizhu.SelectedValue != ""))
            {
                return str;
            }
            if (this.Pizhu.SelectedValue == "未阅读")
            {
                return string.Concat(new object[] { str, " and CHARINDEX(',", this.Session["username"], ",',','+YdUsername+',')   =0" });
            }
            return string.Concat(new object[] { str, " and CHARINDEX(',", this.Session["username"], ",',','+YdUsername+',')   >0" });
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.id,A.titles,A.NowTimes,A.Username,A.Realname,A.LeiBie, B.[name] as LeiBieName from [qp_oa_MyRizhi] as [A] inner join [qp_oa_RizhiLx] as [B] on [A].[LeiBie] = [B].[Id]  where 1=1 and CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_Rizhisz where ZgUsername='" + this.Session["username"] + "')+',') > 0";
            string str2 = "select count(A.id) from [qp_oa_MyRizhi] as [A] inner join [qp_oa_RizhiLx] as [B] on [A].[LeiBie] = [B].[Id] where 1=1 and CHARINDEX(','+Username+',',','+(select RyUsername from qp_oa_Rizhisz where ZgUsername='" + this.Session["username"] + "')+',') > 0";
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
                Label label = (Label) e.Row.FindControl("StringId");
                Label label2 = (Label) e.Row.FindControl("Label2");
                string sql = "select titles from qp_oa_MyRizhi where id='" + label.Text + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (base.Request.QueryString["user"] != null)
                    {
                        label2.Text = string.Concat(new object[] { "<a href='MyRizhipz_show.aspx?id=", label.Text, "&user=", base.Request.QueryString["user"], "' class=\"LinkLine\">", list["titles"], "</a>" });
                    }
                    else if (base.Request.QueryString["StartTime"] != null)
                    {
                        label2.Text = string.Concat(new object[] { "<a href='MyRizhipz_show.aspx?id=", label.Text, "&StartTime=", base.Request.QueryString["StartTime"], "&EndTime=", base.Request.QueryString["EndTime"], "' class=\"LinkLine\">", list["titles"], "</a>" });
                    }
                    else
                    {
                        label2.Text = string.Concat(new object[] { "<a href='MyRizhipz_show.aspx?id=", label.Text, "' class=\"LinkLine\">", list["titles"], "</a>" });
                    }
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
                if (base.Request.QueryString["StartTime"] != null)
                {
                    this.Startime.Text = base.Request.QueryString["StartTime"];
                    this.Endtime.Text = base.Request.QueryString["EndTime"];
                }
                string sQL = "select id,name  from qp_oa_RizhiLx order by id asc";
                this.list.Bind_DropDownList_kong(this.LeiBie, sQL, "id", "name");
                if (base.Request.QueryString["LeiBie"] != null)
                {
                    this.LeiBie.SelectedValue = base.Request.QueryString["LeiBie"];
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

        protected void SearchData_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }
    }
}

