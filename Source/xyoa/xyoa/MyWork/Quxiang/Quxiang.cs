namespace xyoa.MyWork.Quxiang
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Quxiang : Page
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
        protected Label Label1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Startime;
        protected TextBox Username;
        protected TextBox Zhuti;

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
            base.Response.Redirect("Quxiang.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Zhuti.Text != "")
            {
                str = str + " and Zhuti like '%" + this.pulicss.GetFormatStr(this.Zhuti.Text) + "%'";
            }
            if (this.Realname.Text != "")
            {
                str = str + " and A.Username = '" + this.pulicss.GetFormatStr(this.Username.Text) + "'";
            }
            if ((this.Startime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and (Nowtimes between '" + this.Startime.Text + "'and  '" + this.Endtime.Text + "' or convert(char(10),cast(Nowtimes as datetime),120)=convert(char(10),cast('" + this.Startime.Text + "' as datetime),120) or convert(char(10),cast(Nowtimes as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120) ) ";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string sql = "select * from qp_oa_QuxianQj";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str2;
                string str3;
                string str4;
                string str5;
                string str6;
                string str7;
                int num;
                if (list["Leixing"].ToString() == "1")
                {
                    str2 = "select A.* from qp_oa_Quxian as [A]  inner join [qp_oa_username] as [B] on [A].[username] = [B].[username] where BuMenId='" + this.Session["BuMenId"].ToString() + "'";
                    str3 = "select count(A.id) from qp_oa_Quxian as [A]  inner join [qp_oa_username] as [B] on [A].[username] = [B].[username] where BuMenId='" + this.Session["BuMenId"].ToString() + "'";
                    str4 = str2 + SqlCreate;
                    str5 = str3 + SqlCreate;
                    str6 = "" + str4 + " " + Sqlsort + "";
                    this.GridView1.DataSource = this.List.GetGrid_Pages_not(str6);
                    this.GridView1.DataBind();
                    str7 = str5;
                    this.CountsLabel.Text = "" + this.List.GetCount(str7) + "";
                    this.AllPageLabel.Text = Convert.ToString(this.GridView1.PageCount);
                    this.CurrentlyPageLabel.Text = Convert.ToString((int) (this.GridView1.PageIndex + 1));
                    this.btnFirst.CommandName = "1";
                    this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
                    this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : (num = this.GridView1.PageIndex + 2).ToString();
                    this.btnLast.CommandName = this.GridView1.PageCount.ToString();
                }
                else if (list["Leixing"].ToString() == "3")
                {
                    this.Label1.Text = "不允许查看他人去向";
                }
                else
                {
                    str2 = "select A.* from qp_oa_Quxian as [A]  inner join [qp_oa_username] as [B] on [A].[username] = [B].[username] where 1=1";
                    str3 = "select count(A.id) from qp_oa_Quxian as [A]  inner join [qp_oa_username] as [B] on [A].[username] = [B].[username] where 1=1";
                    str4 = str2 + SqlCreate;
                    str5 = str3 + SqlCreate;
                    str6 = "" + str4 + " " + Sqlsort + "";
                    this.GridView1.DataSource = this.List.GetGrid_Pages_not(str6);
                    this.GridView1.DataBind();
                    str7 = str5;
                    this.CountsLabel.Text = "" + this.List.GetCount(str7) + "";
                    this.AllPageLabel.Text = Convert.ToString(this.GridView1.PageCount);
                    this.CurrentlyPageLabel.Text = Convert.ToString((int) (this.GridView1.PageIndex + 1));
                    this.btnFirst.CommandName = "1";
                    this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
                    this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : (num = this.GridView1.PageIndex + 2).ToString();
                    this.btnLast.CommandName = this.GridView1.PageCount.ToString();
                }
            }
            list.Close();
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
                this.Realname.Attributes.Add("readonly", "readonly");
                this.Startime.Attributes.Add("readonly", "readonly");
                this.Realname.Attributes.Add("readonly", "readonly");
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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

