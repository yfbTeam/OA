namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarApply : Page
    {
        protected Button AddData;
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Button Button2;
        protected DropDownList CarId;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected DropDownList Driver;
        protected DropDownList DropDownList1;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList LcZhuangtai;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Starttime;
        protected DropDownList State;

        protected void AddData_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CarApply_add.aspx");
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
            this.pulicss.QuanXianVis(this.AddData, "kkkk3b", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.GridView1, "kkkk3b", this.Session["perstr"].ToString());
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
            base.Response.Redirect("CarApply.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.CarId.SelectedValue != "")
            {
                str = str + " and CarId = '" + this.CarId.SelectedValue + "'";
            }
            if (this.Driver.SelectedValue != "")
            {
                str = str + " and Drivers = '" + this.Driver.SelectedValue + "'";
            }
            if ((this.Starttime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and ((Starttime between '" + this.Starttime.Text + "'and  '" + this.Endtime.Text + "') or (convert(char(10),cast(Starttime as datetime),120)=convert(char(10),cast('" + this.Starttime.Text + "' as datetime),120)) or (convert(char(10),cast(Starttime as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120)) )";
            }
            if (this.State.SelectedValue != "")
            {
                str = str + " and State = '" + this.State.SelectedValue + "'";
            }
            if (this.LcZhuangtai.SelectedValue != "")
            {
                str = str + " and LcZhuangtai = '" + this.LcZhuangtai.SelectedValue + "'";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.*, C.CarName from [qp_oa_CarApply] as [A] join [qp_oa_CarInfo] as [C] on [A].[CarId] = [C].id where (A.Username='" + this.Session["username"] + "') ";
            string str2 = "select count(A.id) from [qp_oa_CarApply] as [A] join [qp_oa_CarInfo] as [C] on [A].[CarId] = [C].id where (A.Username='" + this.Session["username"] + "')";
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
            if (e.CommandName == "ShanChu")
            {
                num = Convert.ToInt32(e.CommandArgument);
                string sql = "  Delete from qp_oa_CarApply where ID='" + num + "'";
                this.List.ExeSql(sql);
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                this.pulicss.InsertLog("删除用车申请", "用车申请");
            }
            if (e.CommandName == "Zhongzhi")
            {
                num = Convert.ToInt32(e.CommandArgument);
                string str2 = "Update qp_oa_CarApply  Set LcZhuangtai='4',State='6'  where id='" + num + "'";
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
                button.Attributes.Add("onclick", "javascript:return confirm('确认删除此车辆申请吗')");
                LinkButton button2 = (LinkButton) e.Row.FindControl("Zhongzhi");
                button2.Attributes.Add("onclick", "javascript:return confirm('确认终止此车辆审批吗')");
                Label label3 = (Label) e.Row.FindControl("Lzt");
                Label label4 = (Label) e.Row.FindControl("Label3");
                Label label5 = (Label) e.Row.FindControl("Zhuangtai");
                if (label3.Text == "1")
                {
                    label4.Text = "<a href='CarApply_update.aspx?id=" + label.Text + "'>修改</a>";
                    button.Visible = true;
                    button2.Visible = true;
                    label5.Text = "";
                }
                else if (label3.Text == "2")
                {
                    label4.Text = "";
                    button.Visible = false;
                    button2.Visible = false;
                    label5.Text = "<a href='javascript:SzDaili(" + label.Text + ")'>更新车辆状态</a>";
                }
                else if (label3.Text == "3")
                {
                    label4.Text = "";
                    button.Visible = true;
                    button2.Visible = false;
                    label5.Text = "";
                }
                else if (label3.Text == "4")
                {
                    label4.Text = "";
                    button.Visible = false;
                    button2.Visible = false;
                    label5.Text = "<a href='javascript:SzDaili(" + label.Text + ")'>更新车辆状态</a>";
                }
                else if (label3.Text == "6")
                {
                    label4.Text = "";
                    button.Visible = true;
                    button2.Visible = false;
                    label5.Text = "";
                }
                else
                {
                    label4.Text = "";
                    button.Visible = false;
                    button2.Visible = false;
                    label5.Text = "已结束";
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
                string sQL = "select id,CarName from qp_oa_CarInfo order by id asc";
                this.list.Bind_DropDownList_kong(this.CarId, sQL, "id", "CarName");
                string str2 = "select Realname from qp_oa_DriverManager order by id asc";
                this.list.Bind_DropDownList_kong(this.Driver, str2, "Realname", "Realname");
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

