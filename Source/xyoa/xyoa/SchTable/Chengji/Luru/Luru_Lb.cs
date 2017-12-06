namespace xyoa.SchTable.Chengji.Luru
{
    using qiupeng.publiccs;
    using qiupeng.sch;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Luru_Lb : Page
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
        protected Button DelData;
        private qiupeng.sch.divsch divsch = new qiupeng.sch.divsch();
        protected DropDownList DropDownList1;
        protected DropDownList DXingming;
        protected TextBox Endtime;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected DropDownList Kemu;
        protected Label Label1;
        protected DropDownList Leixing;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Panel Panel1;
        protected Panel Panel2;
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Startime;
        protected TextBox Xingming;
        protected DropDownList Xueduan;
        protected DropDownList Xueqi;

        public void Bindquanxian()
        {
            this.DelData.Attributes["onclick"] = "javascript:return delcheck();";
            this.pulicss.QuanXianVis(this.GridView1, "pppp3ab", this.Session["perstr"].ToString());
            this.pulicss.QuanXianVis(this.DelData, "pppp3ad", this.Session["perstr"].ToString());
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
            base.Response.Redirect("Luru_Lb.aspx?id=" + base.Request.QueryString["id"] + "");
        }

        private string CheckCbxDel()
        {
            string str = "0";
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("CheckSelect");
                Label label = (Label) row.FindControl("LabVisible");
                if (box.Checked)
                {
                    if (str == "")
                    {
                        str = label.Text.ToString();
                    }
                    else
                    {
                        str = str + "," + label.Text.ToString();
                    }
                }
            }
            return str;
        }

        private string CheckCbxNameDel()
        {
            string str = string.Empty;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("CheckSelect");
                Label label = (Label) row.FindControl("LabNameVisible");
                if (box.Checked)
                {
                    if (str == "")
                    {
                        str = label.Text.ToString();
                    }
                    else
                    {
                        str = str + "," + label.Text.ToString();
                    }
                }
            }
            return str;
        }

        private string CheckCbxUpdate()
        {
            string str = string.Empty;
            for (int i = 0; i < this.GridView1.Rows.Count; i++)
            {
                GridViewRow row = this.GridView1.Rows[i];
                CheckBox box = (CheckBox) row.FindControl("CheckSelect");
                Label label = (Label) row.FindControl("LabVisible");
                if (box.Checked)
                {
                    if (str == "")
                    {
                        str = label.Text.ToString();
                    }
                    else
                    {
                        str = str + "," + label.Text.ToString();
                    }
                }
            }
            return str;
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Xingming.Text != "")
            {
                str = str + " and C.Xingming like '%" + this.pulicss.GetFormatStr(this.Xingming.Text) + "%'";
            }
            if (this.Xueqi.SelectedValue != "")
            {
                str = str + " and A.Xueqi = '" + this.Xueqi.SelectedValue + "'";
            }
            if (this.Xueduan.SelectedValue != "")
            {
                str = str + " and A.Xueduan = '" + this.Xueduan.SelectedValue + "'";
            }
            if (this.Leixing.SelectedValue != "")
            {
                str = str + " and A.Leixing = '" + this.Leixing.SelectedValue + "'";
            }
            if (this.Kemu.SelectedValue != "")
            {
                str = str + " and A.Kemu = '" + this.Kemu.SelectedValue + "'";
            }
            if (this.DXingming.SelectedValue != "")
            {
                str = str + " and C.id = '" + this.DXingming.SelectedValue + "'";
            }
            if ((this.Startime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and (A.Riqi between '" + this.Startime.Text + "'and  '" + this.Endtime.Text + "' or convert(char(10),cast(A.Riqi as datetime),120)=convert(char(10),cast('" + this.Startime.Text + "' as datetime),120) or convert(char(10),cast(A.Riqi as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120) ) ";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.*,C.Xingming from qp_sch_Chengji as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [B] on [B].[XsId] = [C].[Id] where B.BanJi='" + base.Request.QueryString["id"] + "'";
            string str2 = "select count(A.id) from qp_sch_Chengji as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] inner join [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [B] on [B].[XsId] = [C].[Id] where B.BanJi='" + base.Request.QueryString["id"] + "'";
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

        protected void DelData_Click(object sender, EventArgs e)
        {
            string str = this.CheckCbxDel();
            string sql = "  Delete from qp_sch_Chengji  where ID in (" + str + ")";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("删除成绩录入", "成绩录入");
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pulicss.addfenye(this.DropDownList1.SelectedValue);
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        protected void DXingming_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "XiuGai")
            {
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "delete from qp_sch_Chengji where id='" + num + "'";
                this.List.ExeSql(sql);
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
                Label label = (Label) e.Row.FindControl("Leixing");
                Label label2 = (Label) e.Row.FindControl("LLeixing");
                Label label3 = (Label) e.Row.FindControl("Kemu");
                Label label4 = (Label) e.Row.FindControl("LKemu");
                label2.Text = this.divsch.TypeCode("Name", "qp_sch_DataFile", label.Text);
                label4.Text = this.divsch.TypeCode("Name", "qp_sch_Kecheng", label3.Text);
                LinkButton ctl = (LinkButton) e.Row.FindControl("ShanChu");
                ctl.Attributes.Add("onclick", "javascript:return confirm('确认删除吗')");
                LinkButton button2 = (LinkButton) e.Row.FindControl("XiuGai");
                button2.Attributes.Add("onclick", "var num=Math.random();window.showModalDialog('Luru_PlSdlt_update.aspx?tmp=' + num + '&id=" + button2.CommandArgument + "&Njid=" + base.Request.QueryString["id"] + "','window','dialogWidth:680px;DialogHeight=380px;status:no;help=no;scroll=no');window.location='#'");
                this.pulicss.QuanXianVis(ctl, "pppp3ad", this.Session["perstr"].ToString());
                this.pulicss.QuanXianVis(button2, "pppp3ac", this.Session["perstr"].ToString());
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
                this.Button1.Attributes["onclick"] = "javascript:return chknull();";
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
                        string sQL = "select id,Mingcheng  from qp_sch_Xueqi  order by Mingcheng asc";
                        this.list.Bind_DropDownList_nothing(this.Xueqi, sQL, "Mingcheng", "Mingcheng");
                        this.Xueqi.SelectedValue = this.divsch.GetXueqi();
                        this.Xueduan.SelectedValue = this.divsch.GetXueduan();
                        string sql = "select * from qp_sch_Nianji where  NianjiMc='" + this.divsch.TypeCode("Nianji", "qp_sch_Banji", this.pulicss.GetFormatStr(base.Request.QueryString["Id"])) + "' and Xueqi='" + this.Xueqi.SelectedValue + "'";
                        SqlDataReader list = this.List.GetList(sql);
                        if (list.Read())
                        {
                            string str3;
                            if (this.Xueduan.SelectedValue == "上学期")
                            {
                                str3 = "select id,Name  from qp_sch_Kecheng where id in (" + list["Kecheng"].ToString() + ") order by id asc";
                                this.list.Bind_DropDownList_kong(this.Kemu, str3, "id", "Name");
                            }
                            else
                            {
                                str3 = "select id,Name  from qp_sch_Kecheng where id in (" + list["KechengX"].ToString() + ") order by id asc";
                                this.list.Bind_DropDownList_kong(this.Kemu, str3, "id", "Name");
                            }
                            string str4 = "select id,name  from qp_sch_DataFile where type='19' and ifdel=0 and id in (" + list["Kaoshilx"].ToString() + ") order by id asc";
                            this.list.Bind_DropDownList_kong(this.Leixing, str4, "id", "name");
                        }
                        list.Close();
                        string str5 = "select C.id,C.Xingming  from [stu_table_" + this.Xueqi.SelectedValue + "_" + this.Xueduan.SelectedValue.Replace("上学期", "1").Replace("下学期", "2") + "] as [A] inner join [qp_sch_Xuesheng] as [C] on [A].[XsId] = [C].[Id] where  A.BanJi='" + base.Request.QueryString["id"] + "' order by A.id asc";
                        this.list.Bind_DropDownList_kong(this.DXingming, str5, "id", "Xingming");
                        this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
                    }
                }
                else
                {
                    this.Panel1.Visible = true;
                    this.Panel2.Visible = false;
                }
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

