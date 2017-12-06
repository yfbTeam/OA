namespace xyoa.PublicWork.Hetong
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyHetong : Page
    {
        protected Button AddData;
        protected Label AllMoney;
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Button Button2;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected TextBox Danwei;
        protected DropDownList DropDownList1;
        protected DropDownList Fenlei;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected TextBox Hetonghao;
        protected DropDownList LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected DropDownList Zhuangtai;
        protected TextBox Zhuti;

        protected void AddData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyHeTong_add.aspx");
        }

        public void BindAttribute()
        {
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.AddData.Attributes["onclick"] = "javascript:return showwait();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.AddData, "jjjj8a", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.GridView1, "jjjj8a", this.Session["perstr"].ToString());
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
            base.Response.Redirect("MyHetong.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Zhuti.Text != "")
            {
                str = str + " and A.Zhuti like '%" + this.pulicss.GetFormatStr(this.Zhuti.Text) + "%'";
            }
            if (this.Hetonghao.Text != "")
            {
                str = str + " and A.Hetonghao like '%" + this.pulicss.GetFormatStr(this.Hetonghao.Text) + "%'";
            }
            if (this.Danwei.Text != "")
            {
                str = str + " and A.Danwei like '%" + this.pulicss.GetFormatStr(this.Danwei.Text) + "%'";
            }
            if (this.Zhuangtai.SelectedValue != "")
            {
                str = str + " and A.Zhuangtai = '" + this.Zhuangtai.SelectedValue + "'";
            }
            if (this.LcZhuangtai.SelectedValue != "")
            {
                str = str + " and A.LcZhuangtai = '" + this.LcZhuangtai.SelectedValue + "'";
            }
            if (this.Fenlei.SelectedValue != "")
            {
                str = str + " and A.Fenlei = '" + this.Fenlei.SelectedValue + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str2 = ("select A.Username as AUsername,A.Realname as ARealname,A.id,A.LcZhuangtai,A.DqBlXinming,A.DqBlUsername,A.Zhuti,A.Hetonghao,A.Fenlei,A.Zhuangtai,A.Danwei,A.Jine,B.Name as FenleiName from [qp_oa_HeTong] as [A] inner join [qp_oa_HetongLb] as [B] on [A].[Fenlei] = [B].id where A.Username='" + this.Session["username"] + "'") + SqlCreate;
            string sql = string.Concat(new object[] { "select sum(A.Jine) as AllShuliang from  [qp_oa_HeTong] as [A] inner join [qp_oa_HetongLb] as [B] on [A].[Fenlei] = [B].id where A.Username='", this.Session["username"], "' ", SqlCreate, " " });
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                if (list["AllShuliang"].ToString() == "")
                {
                    this.AllMoney.Text = "0.00";
                }
                else
                {
                    this.AllMoney.Text = string.Format("{0:N}", list["AllShuliang"]);
                }
            }
            else
            {
                this.AllMoney.Text = "0.00";
            }
            list.Close();
            string str4 = "" + str2 + " " + Sqlsort + "";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(str4);
            this.GridView1.DataBind();
            string str6 = ("select count(A.id) from [qp_oa_HeTong] as [A] inner join [qp_oa_HetongLb] as [B] on [A].[Fenlei] = [B].id where A.Username='" + this.Session["username"] + "'") + SqlCreate;
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int num;
            if (e.CommandName == "ShanChu")
            {
                num = Convert.ToInt32(e.CommandArgument);
                string sql = "delete from qp_oa_HeTong where id='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
            if (e.CommandName == "Zhongzhi")
            {
                num = Convert.ToInt32(e.CommandArgument);
                string str2 = "Update qp_oa_HeTong  Set LcZhuangtai='4'  where id='" + num + "'";
                this.List.ExeSql(str2);
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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
                Label label = (Label) e.Row.FindControl("Lid");
                Label label2 = (Label) e.Row.FindControl("Label2");
                LinkButton button = (LinkButton) e.Row.FindControl("ShanChu");
                button.Attributes.Add("onclick", "javascript:return confirm('确认删除此合同吗')");
                LinkButton button2 = (LinkButton) e.Row.FindControl("Zhongzhi");
                button2.Attributes.Add("onclick", "javascript:return confirm('确认终止此合同吗')");
                Label label3 = (Label) e.Row.FindControl("Lzt");
                Label label4 = (Label) e.Row.FindControl("Label3");
                if (label3.Text == "1")
                {
                    label4.Text = "<a href='MyHeTong_update.aspx?id=" + label.Text + "'>修改</a>";
                    button.Visible = true;
                    button2.Visible = true;
                }
                else if (label3.Text == "2")
                {
                    label4.Text = "";
                    button.Visible = false;
                    button2.Visible = true;
                }
                else if (label3.Text == "3")
                {
                    label4.Text = "<font color=#666666>不允许操作</font>";
                    button.Visible = false;
                    button2.Visible = false;
                }
                else
                {
                    label4.Text = "";
                    button.Visible = true;
                    button2.Visible = false;
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
                this.Bindquanxian();
                string sQL = "select * from qp_oa_HetongLb";
                this.list.Bind_DropDownList_kong(this.Fenlei, sQL, "id", "Name");
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

