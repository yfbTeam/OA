namespace xyoa.MyWork.Metting
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyMetting : Page
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
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList MettingName;
        protected TextBox Name;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Starttime;
        protected TextBox Username;

        public void BindAttribute()
        {
            this.Name.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.Realname.Attributes.Add("readonly", "readonly");
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "hhhh7a", this.Session["perstr"].ToString());
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
            base.Response.Redirect("MyMetting.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Name.Text != "")
            {
                str = str + " and Name like '%" + this.pulicss.GetFormatStr(this.Name.Text) + "%'";
            }
            if (this.MettingName.SelectedValue != "")
            {
                str = str + " and MettingId = '" + this.MettingName.SelectedValue + "'";
            }
            if (this.Username.Text != "")
            {
                str = str + " and Username = '" + this.pulicss.GetFormatStr(this.Username.Text) + "'";
            }
            if ((this.Starttime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and ((Starttime between '" + this.Starttime.Text + "'and  '" + this.Endtime.Text + "') or (convert(char(10),cast(Starttime as datetime),120)=convert(char(10),cast('" + this.Starttime.Text + "' as datetime),120)) or (convert(char(10),cast(Starttime as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120)) )";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.* from [qp_oa_MettingApply] as [A]  where  (State='2' or State='3'  or State='4' or State='5' ) and   CHARINDEX('," + this.Session["Username"] + ",',','+NbPeopleUser+',')   >   0  ";
            string str2 = "select count(id) from qp_oa_MettingApply where  (State='2' or State='3'  or State='4' or State='5' ) and   CHARINDEX('," + this.Session["Username"] + ",',','+NbPeopleUser+',')   >   0 ";
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
            if (e.CommandName == "canyu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = string.Concat(new object[] { "select  Name from qp_oa_MettingApply where    CHARINDEX(',", this.Session["Username"], ",',','+CjUsername+',')   >   0  and  id='", num, "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (!list.Read())
                {
                    string str2 = string.Concat(new object[] { "Update qp_oa_MettingApply  Set CjUsername=CjUsername+'", this.Session["username"], ",',  CjRealname=CjRealname+'", this.Session["realname"], ",' where ID='", num, "'" });
                    this.List.ExeSql(str2);
                    this.pulicss.InsertLog("参与会议", "我的会议");
                    list.Close();
                    this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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
                Label label3 = (Label) e.Row.FindControl("daili");
                Label label4 = (Label) e.Row.FindControl("dailiren1");
                Label label5 = (Label) e.Row.FindControl("dailiren2");
                string sql = string.Concat(new object[] { "select  id,DlRealname from qp_oa_MettingApply_Daili where  Hyid='", label.Text, "' and Username='", this.Session["Username"], "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    label4.Visible = false;
                    label5.Visible = true;
                    label5.Text = "<a href='javascript:QxDaili(" + label.Text + ")'>取消代理人</a>";
                    label3.Text = "<font color=red>代理人：" + list["DlRealname"] + "</font>";
                }
                else
                {
                    label4.Visible = true;
                    label5.Visible = false;
                    label4.Text = "<a href='javascript:SzDaili(" + label.Text + ")'>设置代理人</a>";
                }
                list.Close();
                string str2 = string.Concat(new object[] { "select  * from qp_oa_MettingApply where   CHARINDEX(',", this.Session["Username"], ",',','+CjUsername+',')   >   0  and  id='", label.Text, "' " });
                SqlDataReader reader2 = this.List.GetList(str2);
                if (reader2.Read())
                {
                    label2.Text = "已确认参与";
                    button.Visible = false;
                }
                else
                {
                    label2.Text = "未确认参与";
                    button.Visible = true;
                }
                reader2.Close();
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
                string sql = "Update qp_oa_MettingApply  Set State='3' where datediff(ss,Starttime,'" + DateTime.Now.ToString() + "')>0 and (State=6 or State=2)";
                this.List.ExeSql(sql);
                string str2 = "Update qp_oa_MettingApply  Set State='4' where datediff(ss,Endtime,'" + DateTime.Now.ToString() + "')>0 and (State=6 or State=2 or State=3)";
                this.List.ExeSql(str2);
                string sQL = "select id,name  from qp_oa_MettingHouse order by id asc";
                this.list.Bind_DropDownList_kong(this.MettingName, sQL, "id", "name");
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

