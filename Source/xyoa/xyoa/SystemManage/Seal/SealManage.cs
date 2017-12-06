namespace xyoa.SystemManage.Seal
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class SealManage : Page
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
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Nowtimes;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected Button SearchData;
        protected HtmlInputHidden SortText;

        public void BindAttribute()
        {
            this.Name.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "iiii3", this.Session["perstr"].ToString());
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
            base.Response.Redirect("SealManage.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Name.Text != "")
            {
                str = str + " and Name like '%" + this.pulicss.GetFormatStr(this.Name.Text) + "%'";
            }
            if (this.Nowtimes.Text != "")
            {
                str = str + " and convert(char(10),cast(Nowtimes as datetime),120)=convert(char(10),cast('" + this.pulicss.GetFormatStr(this.Nowtimes.Text) + "' as datetime),120) ";
            }
            if (this.Realname.Text != "")
            {
                str = str + " and Realname like '%" + this.pulicss.GetFormatStr(this.Realname.Text) + "%'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select * from qp_oa_YinZhang   where YxType='私章'";
            string str2 = "select count(id) from qp_oa_YinZhang  where  YxType='私章'";
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int num;
            string str;
            SqlDataReader list;
            string str3;
            if (e.CommandName == "ShanChu")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select * from qp_oa_YinZhang where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "您的印章[", list["Name"], "]被删除，操作人[", this.Session["realname"], "]请注意查看！" }), list["username"].ToString(), list["realname"].ToString(), "/MyWork/YinZhang/MyYinZhang.aspx");
                    string sql = "  Delete from qp_oa_YinZhang where ID='" + num + "'";
                    this.List.ExeSql(sql);
                    this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                    this.pulicss.InsertLog("删除印章[" + list["Name"] + "]", "私章维护");
                }
                list.Close();
            }
            if (e.CommandName == "Tingzhi")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select * from qp_oa_YinZhang where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    if (list["State"].ToString() == "停止")
                    {
                        this.pulicss.InsertMessage(string.Concat(new object[] { "您的印章[", list["Name"], "]被重新启用，重新启用后需要通过审批才能正式生效，操作人[", this.Session["realname"], "]请注意查看！" }), list["username"].ToString(), list["realname"].ToString(), "/MyWork/YinZhang/MyYinZhang.aspx");
                        str3 = "Update qp_oa_YinZhang    Set State='等待审批' where id='" + num + "'";
                        this.List.ExeSql(str3);
                        this.pulicss.InsertLog("启用印章[" + list["Name"] + "]", "私章维护");
                    }
                    else
                    {
                        this.pulicss.InsertMessage(string.Concat(new object[] { "您的印章[", list["Name"], "]被停止使用，操作人[", this.Session["realname"], "]请注意查看！" }), list["username"].ToString(), list["realname"].ToString(), "/MyWork/YinZhang/MyYinZhang.aspx");
                        str3 = "Update qp_oa_YinZhang    Set State='停止' where id='" + num + "'";
                        this.List.ExeSql(str3);
                        this.pulicss.InsertLog("停止印章[" + list["Name"] + "]", "私章维护");
                    }
                    this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                }
                list.Close();
            }
            if (e.CommandName == "Chongzhi")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select * from qp_oa_YinZhang where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "您的印章[", list["Name"], "]密码被重置，重置后密码为：666666。操作人[", this.Session["realname"], "]请注意查看！" }), list["username"].ToString(), list["realname"].ToString(), "/MyWork/YinZhang/MyYinZhang.aspx");
                    string str4 = FormsAuthentication.HashPasswordForStoringInConfigFile("666666", "MD5");
                    str3 = string.Concat(new object[] { "Update qp_oa_YinZhang  Set Password='", str4, "' where id='", num, "'" });
                    this.List.ExeSql(str3);
                    this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                    this.pulicss.InsertLog("印章密码重置[" + list["Name"] + "]", "私章维护");
                }
                list.Close();
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
                LinkButton button2;
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                button.Attributes.Add("onclick", "javascript:return confirm('确认删除印章[" + e.Row.Cells[0].Text.ToString() + "]吗？')");
                if (e.Row.Cells[1].Text.ToString() == "停止")
                {
                    button2 = (LinkButton) e.Row.FindControl("LinkButton2");
                    button2.Text = "启用";
                    button2.Attributes.Add("onclick", "javascript:return confirm('确认启用印章[" + e.Row.Cells[0].Text.ToString() + "]吗？重新启用后需要通过审批才能正式生效！')");
                }
                else
                {
                    button2 = (LinkButton) e.Row.FindControl("LinkButton2");
                    button2.Text = "停止";
                    button2.Attributes.Add("onclick", "javascript:return confirm('确认停止印章[" + e.Row.Cells[0].Text.ToString() + "]吗？')");
                }
                LinkButton button3 = (LinkButton) e.Row.FindControl("LinkButton3");
                button3.Attributes.Add("onclick", "javascript:return confirm('确认密码重置印章[" + e.Row.Cells[0].Text.ToString() + "]吗？重置后面密码为：666666')");
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

