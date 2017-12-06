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

    public class WorkFlowSearch_SearchList : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected DropDownList DropDownList1;
        protected HtmlForm form1;
        protected TextBox GoPage;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        private publics pulicss = new publics();
        protected HtmlInputHidden SortText;

        public void BindAttribute()
        {
            this.btnFirst.Attributes["onclick"] = "javascript:return showwait();";
            this.btnPrev.Attributes["onclick"] = "javascript:return showwait();";
            this.btnNext.Attributes["onclick"] = "javascript:return showwait();";
            this.btnLast.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chkyema();";
        }

        public void Bindquanxian()
        {
            this.pulicss.QuanXianVis(this.GridView1, "mmmm4", this.Session["perstr"].ToString());
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

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (base.Request.QueryString["FlowId"] != "0")
            {
                str = str + " and A.FlowId = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["FlowId"])) + "'";
            }
            if (base.Request.QueryString["State"] != "0")
            {
                str = str + " and A.State = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["State"])) + "'";
            }
            if (base.Request.QueryString["Fangwei"] != "0")
            {
                if (base.Request.QueryString["Fangwei"] == "1")
                {
                    str = str + " and A.FqUsername= '" + this.Session["username"].ToString() + "'";
                }
                if (base.Request.QueryString["Fangwei"] == "3")
                {
                    str = string.Concat(new object[] { str, " and ((CHARINDEX(',", this.Session["username"], ",',','+JkUsername+',') > 0) or JkUsername='0')" });
                }
            }
            else
            {
                str = string.Concat(new object[] { str, " and (A.FqUsername= '", this.Session["username"].ToString(), "' or ((CHARINDEX(',", this.Session["username"], ",',','+JkUsername+',') > 0) or JkUsername='0'))" });
            }
            if (base.Request.QueryString["FqUsername"] != "")
            {
                str = str + " and FqUsername = '" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["FqUsername"])) + "'";
            }
            if (base.Request.QueryString["Name"] != "")
            {
                str = str + " and Name like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["Name"])) + "%'";
            }
            if ((base.Request.QueryString["Starttime"] != "") && (base.Request.QueryString["Endtime"] != ""))
            {
                str = str + " and ((NowTimes between '" + base.Request.QueryString["Starttime"] + "'and  '" + base.Request.QueryString["Endtime"] + "') or (convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Starttime"] + "' as datetime),120)) or (convert(char(10),cast(NowTimes as datetime),120)=convert(char(10),cast('" + base.Request.QueryString["Endtime"] + "' as datetime),120)) ) ";
            }
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = string.Concat(new object[] { "select distinct A.id,A.Shuxing,A.State,A.Number,A.Sequence,A.FormName,A.Name,A.FlowNumber,A.FqUsername,A.FqRealname,A.NodeName,A.UpNodeName,A.UpNodeId,A.FormId from [qp_oa_AddWorkFlow] as [A] ", this.ViewState["strurl"], "", this.ViewState["strurl1"], " where Ifdel='0'" });
            string str2 = string.Concat(new object[] { "select count(distinct A.id) from [qp_oa_AddWorkFlow] as [A] ", this.ViewState["strurl"], "", this.ViewState["strurl1"], "  where Ifdel='0'" });
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
                Label label = (Label) e.Row.FindControl("Lid");
                Label label2 = (Label) e.Row.FindControl("Label2");
                Label label3 = (Label) e.Row.FindControl("Label3");
                Label label4 = (Label) e.Row.FindControl("Label4");
                string sql = "select id,name,UpNodeId,FlowNumber,FormId,Number,UpNodeName,Shuxing,FormName,UpNodeNum,GlNum,State from qp_oa_AddWorkFlow  where id='" + label.Text + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["Shuxing"].ToString() == "自由流程")
                    {
                        label2.Text = "<a href='javascript:void(0)' onclick='window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>自由流程</a>";
                        label3.Text = "<a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowList_show_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=no,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["FormName"].ToString() + "</a>";
                        label4.Text = "<a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowList_show_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=no,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["Name"].ToString() + "</a>";
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
                        label3.Text = "<a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListJk_show.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=no,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["FormName"].ToString() + "</a>";
                        string text = label4.Text;
                        label4.Text = text + "<a href='javascript:void(0)' onclick='var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListJk_show.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=no,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["Name"].ToString() + "</a>";
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
                if (base.Request.QueryString["Fujian"] != "")
                {
                    this.ViewState["strurl"] = " inner join [qp_oa_fileupload] as [C] on [A].[Number] = [C].KeyField and [C].Name like '%" + this.pulicss.GetFormatStr(base.Server.UrlDecode(base.Request.QueryString["Fujian"])) + "%'";
                }
                else
                {
                    this.ViewState["strurl"] = "";
                }
                this.ViewState["strurl1"] = "";
                if ((this.Session["searchurl"] != null) && (this.Session["searchurl"].ToString() != ""))
                {
                    this.ViewState["strurl1"] = "inner join [qp_oa_AddWorkFlowFileKey] as [B] on" + this.Session["searchurl"].ToString() + "";
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

