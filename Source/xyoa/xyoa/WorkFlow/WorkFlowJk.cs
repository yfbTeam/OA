namespace xyoa.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowJk : Page
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
        protected TextBox FqRealname;
        protected TextBox FqUsername;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();
        protected Button SearchData;
        private divform showform = new divform();
        protected HtmlInputHidden SortText;
        protected TextBox Starttime;
        protected DropDownList State;
        protected TextBox ZbObjectId;
        protected TextBox ZbObjectName;

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
            this.ZbObjectName.Attributes.Add("readonly", "readonly");
            this.FqRealname.Attributes.Add("readonly", "readonly");
            this.pulicss.QuanXianVis(this.GridView1, "mmmm5", this.Session["perstr"].ToString());
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
            base.Response.Redirect("WorkFlowJk.aspx");
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Name.Text != "")
            {
                str = str + " and A.Name like '%" + this.pulicss.GetFormatStr(this.Name.Text) + "%'";
            }
            if (this.FormName.SelectedValue != "")
            {
                str = str + " and A.FormId = '" + this.FormName.SelectedValue + "'";
            }
            if (this.FqUsername.Text != "")
            {
                str = str + " and A.FqUsername = '" + this.pulicss.GetFormatStr(this.FqUsername.Text) + "'";
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
            string str = "select A.NowTimes,A.State,A.ZbObjectId,A.ZbObjectName,A.id,A.Shuxing,A.Number,A.Sequence,A.FormName,A.Name,A.FlowNumber,A.FqUsername,A.FqRealname,A.NodeName,A.UpNodeName,A.UpNodeId,A.FormId from [qp_oa_AddWorkFlow] as [A]  where Ifdel='0' and ((CHARINDEX('," + this.Session["username"] + ",',','+JkUsername+',') > 0) or JkUsername='0')";
            string str2 = "select count(A.id) from [qp_oa_AddWorkFlow] as [A]  where  Ifdel='0' and ((CHARINDEX('," + this.Session["username"] + ",',','+JkUsername+',') > 0) or JkUsername='0')";
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int num;
            string str;
            SqlDataReader list;
            string str2;
            if (e.CommandName == "Jieshu")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select Number,FormName,Name,FqUsername,FqRealname from qp_oa_AddWorkFlow   where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "您发起的工作：", list["Name"].ToString(), "，已强制结束，操作人：", this.Session["realname"], "" }), list["FqUsername"].ToString(), list["FqRealname"].ToString(), "/WorkFlow/WorkFlowSearch.aspx");
                    this.showform.AddWorkFlowLog("110", list["Number"].ToString(), list["FormName"].ToString(), "结束", "强制结束工作" + list["Name"].ToString() + "", "流程监控");
                }
                list.Close();
                str2 = "Update qp_oa_AddWorkFlow  Set State='强制结束'  where ID='" + num + "'";
                this.List.ExeSql(str2);
            }
            if (e.CommandName == "ShanChu")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select Number,FormName,Name,FqUsername,FqRealname from qp_oa_AddWorkFlow   where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "您发起的工作：", list["Name"].ToString(), "，已删除，操作人：", this.Session["realname"], "" }), list["FqUsername"].ToString(), list["FqRealname"].ToString(), "/WorkFlow/WorkFlowSearch.aspx");
                    this.showform.AddWorkFlowLog("110", list["Number"].ToString(), list["FormName"].ToString(), "已删除", "删除工作" + list["Name"].ToString() + "", "流程监控");
                }
                list.Close();
                str2 = "Update qp_oa_AddWorkFlow  Set Ifdel='1'  where ID='" + num + "'";
                this.List.ExeSql(str2);
            }
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
                LinkButton button;
                Label label = (Label) e.Row.FindControl("Lid");
                Label label2 = (Label) e.Row.FindControl("Label1");
                Label label3 = (Label) e.Row.FindControl("Label2");
                Label label4 = (Label) e.Row.FindControl("Label3");
                Label label5 = (Label) e.Row.FindControl("Label4");
                Label label6 = (Label) e.Row.FindControl("Label5");
                Label label7 = (Label) e.Row.FindControl("Daochu");
                string sql = "select id,Name,UpNodeId,FlowNumber,FormId,Number,UpNodeName,Shuxing,FormName,UpNodeNum,GlNum,State from qp_oa_AddWorkFlow  where id='" + label.Text + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["Shuxing"].ToString() == "自由流程")
                    {
                        label3.Text = "<a href='javascript:void(0)' onclick='window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>自由流程</a>";
                        label4.Text = "<a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowList_show_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["FormName"].ToString() + "</a>";
                        label6.Text = "<a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowList_show_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["Name"].ToString() + "</a>";
                        label5.Text = "<a href='WorkFlowJkWt.aspx?id=" + label.Text + "' onclick=\"showwait();\">委托</a>";
                        label7.Text = "<a href='javascript:void(0)' onclick='window.open (\"MyWorkFlow_dc.aspx?id=" + list["id"].ToString() + "\", \"_blank\", \"height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=1,left=1\")'>导出</a>";
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
                                    label6.Text = label6.Text + "";
                                }
                                else
                                {
                                    label6.Text = label6.Text + "<img src=\"/oaimg/menu/cs.gif\" />";
                                }
                            }
                            else
                            {
                                label6.Text = label6.Text + "";
                            }
                            reader3.Close();
                        }
                        label7.Text = "<a href='javascript:void(0)' onclick='window.open (\"MyWorkFlow_dc.aspx?id=" + list["id"].ToString() + "\", \"_blank\", \"height=1, width=1,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=1,left=1\")'>导出</a>";
                        label3.Text = "<a href='javascript:void(0)' onclick='window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>" + list["UpNodeName"].ToString() + "</a>";
                        label4.Text = "<a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListJk_show.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["FormName"].ToString() + "</a>";
                        string text = label6.Text;
                        label6.Text = text + "<a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListJk_show.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["Name"].ToString() + "</a>";
                        label5.Text = "<a href='WorkFlowJkWt.aspx?id=" + label.Text + "' onclick=\"showwait();\">委托</a>";
                    }
                }
                list.Close();
                if (e.Row.Cells[5].Text.ToString() == "正在办理")
                {
                    button = (LinkButton) e.Row.FindControl("LinkButton1");
                    button.Attributes.Add("onclick", "javascript:return confirm('确定结束此工作吗？流水号：[" + e.Row.Cells[0].Text.ToString() + "]')");
                    button.Visible = true;
                    label2.Visible = true;
                    label5.Visible = true;
                }
                else
                {
                    button = (LinkButton) e.Row.FindControl("LinkButton1");
                    button.Visible = false;
                    label2.Visible = false;
                    label5.Visible = false;
                }
                LinkButton button2 = (LinkButton) e.Row.FindControl("LinkButton2");
                button2.Attributes.Add("onclick", "javascript:return confirm('确定删除此工作吗？流水号：[" + e.Row.Cells[0].Text.ToString() + "]')");
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
                string sQL = "select id,FormName  from qp_oa_DIYForm";
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

