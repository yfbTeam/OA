namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyAddWorkFlow : Page
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
        protected DropDownList FormName;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();
        protected Button SearchData;
        protected HtmlInputHidden SortText;
        protected TextBox Starttime;
        protected DropDownList State;
        protected TextBox ZbObjectId;
        protected TextBox ZbObjectName;

        public void BindAttribute()
        {
            this.Name.Attributes["onkeydown"] = "if (event.keyCode==13) { document.all.SearchData.click(); return false;}";
            this.SearchData.Attributes["onclick"] = "javascript:return showwait();";
            this.ZbObjectName.Attributes.Add("readonly", "readonly");
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "mmmm2", this.Session["perstr"].ToString());
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
            base.Response.Redirect("MyAddWorkFlow.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty + " and A.FqUsername= '" + this.Session["username"].ToString() + "'";
            if (this.Name.Text != "")
            {
                str = str + " and A.Name like '%" + this.pulicss.GetFormatStr(this.Name.Text) + "%'";
            }
            if (this.FormName.SelectedValue != "")
            {
                str = str + " and A.FormId = '" + this.FormName.SelectedValue + "'";
            }
            if (this.State.SelectedValue != "0")
            {
                str = str + " and A.State = '" + this.State.SelectedValue + "'";
            }
            if (this.ZbObjectId.Text != "")
            {
                str = str + " and (A.ZbObjectId = '" + this.pulicss.GetFormatStr(this.ZbObjectId.Text) + "' or (CHARINDEX('," + this.ZbObjectId.Text + ",',','+JbObjectId+',') > 0))";
            }
            if ((this.Starttime.Text != "") && (this.Endtime.Text != ""))
            {
                str = str + " and ((NowTimes between '" + this.Starttime.Text + "'and  '" + this.Endtime.Text + "') or (convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + this.Starttime.Text + "' as datetime),120)) or (convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + this.Endtime.Text + "' as datetime),120)) ) ";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.NowTimes,A.State,A.ZbObjectId,A.ZbObjectName,A.id,A.Shuxing,A.Number,A.Sequence,A.FormName,A.Name,A.FlowNumber,A.FqUsername,A.FqRealname,A.NodeName,A.UpNodeName,A.UpNodeId,A.FormId from [qp_oa_AddWorkFlow] as [A]  where Ifdel='0' ";
            string str2 = "select count(A.id) from [qp_oa_AddWorkFlow] as [A]  where  Ifdel='0'";
            string str3 = str + SqlCreate;
            string str4 = str2 + SqlCreate;
            string sql = "" + str3 + " group by A.NowTimes,A.State,A.ZbObjectId,A.ZbObjectName,A.id,A.Shuxing,A.Number,A.Sequence,A.FormName,A.Name,A.FlowNumber,A.FqUsername,A.FqRealname,A.NodeName,A.UpNodeName,A.UpNodeId,A.FormId,A.UpTimeSet " + Sqlsort + "";
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
                Label label = (Label) e.Row.FindControl("Lid");
                Label label2 = (Label) e.Row.FindControl("Label2");
                Label label3 = (Label) e.Row.FindControl("Label3");
                Label label4 = (Label) e.Row.FindControl("Label5");
                string sql = "select id,Name,UpNodeId,FlowNumber,FormId,Number,UpNodeName,Shuxing,FormName,UpNodeNum,GlNum,State from qp_oa_AddWorkFlow  where id='" + label.Text + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["Shuxing"].ToString() == "自由流程")
                    {
                        label2.Text = "<a href='javascript:void(0)' onclick='window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>自由流程</a>";
                        label3.Text = "<a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowList_show_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["FormName"].ToString() + "</a>";
                        label4.Text = "<a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowList_show_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["Name"].ToString() + "</a>";
                    }
                    else
                    {
                        string s = null;
                        string str3 = "select StartTime from qp_oa_AddWorkFlowPicRy  where KeyFile='" + list["Number"].ToString() + "' and xuhao='" + list["UpNodeNum"].ToString() + "' and GlNum='" + list["GlNum"].ToString() + "'";
                        SqlDataReader reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            s = reader2["StartTime"].ToString();
                        }
                        else
                        {
                            s = DateTime.Now.ToString();
                        }
                        reader2.Close();
                        if (list["State"].ToString() == "正在办理")
                        {
                            string str4 = "select XbTimes from qp_oa_WorkFlowNode  where id='" + list["UpNodeId"].ToString() + "'";
                            SqlDataReader reader3 = this.List.GetList(str4);
                            if (reader3.Read())
                            {
                                TimeSpan span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(s));
                                if (span.TotalHours < double.Parse(reader3["XbTimes"].ToString()))
                                {
                                    label4.Text = label4.Text + "";
                                }
                                else
                                {
                                    label4.Text = label4.Text + "<img src=\"/oaimg/menu/cs.gif\" />";
                                }
                            }
                            else
                            {
                                label4.Text = label4.Text + "";
                            }
                            reader3.Close();
                        }
                        label2.Text = "<a href='javascript:void(0)' onclick='window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>" + list["UpNodeName"].ToString() + "</a>";
                        label3.Text = "<a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListJk_show.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["FormName"].ToString() + "</a>";
                        string text = label4.Text;
                        label4.Text = text + "<a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListJk_show.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["Name"].ToString() + "</a>";
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
                string sQL = string.Concat(new object[] { "select A.id,FormName  from qp_oa_DIYForm  as [A] inner join [qp_oa_FormType] as [B] on [A].[TypeId] = [B].[Id] where (CHARINDEX(',", this.Session["BuMenId"], ",',','+ZdBumenId+',') > 0 and States='2') or (CHARINDEX(',", this.Session["username"], ",',','+ZdUsername+',') > 0 and States='3') or (States='1')" });
                this.list.Bind_DropDownList_kong(this.FormName, sQL, "id", "FormName");
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

