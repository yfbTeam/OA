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

    public class WorkFlowDel : Page
    {
        protected Label AllPageLabel;
        protected LinkButton btnFirst;
        protected LinkButton btnLast;
        protected LinkButton btnNext;
        protected LinkButton btnPrev;
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected Label CountsLabel;
        protected Label CurrentlyPageLabel;
        protected Button DelData;
        protected DropDownList DropDownList1;
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
        protected HtmlInputHidden SortText;
        protected DropDownList State;

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
            this.DelData.Attributes["onclick"] = "javascript:return delcheck();";
            this.Button3.Attributes["onclick"] = "javascript:return hfcheck();";
            this.FqRealname.Attributes.Add("readonly", "readonly");
            this.pulicss.QuanXianVis(this.GridView1, "mmmm6", this.Session["perstr"].ToString());
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
            base.Response.Redirect("WorkFlowDel.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string str = this.CheckCbxDel();
            string sql = "Update qp_oa_AddWorkFlow  Set Ifdel='0'  where ID in (" + str + ")";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("恢复工作销毁", "工作销毁");
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
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
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.State,A.ZbObjectId,A.ZbObjectName,A.id,A.Shuxing,A.Number,A.Sequence,A.FormName,A.Name,A.FlowNumber,A.FqUsername,A.FqRealname,A.NodeName,A.UpNodeName,A.UpNodeId,A.FormId from [qp_oa_AddWorkFlow] as [A]  where Ifdel='1' ";
            string str2 = "select count(A.id) from [qp_oa_AddWorkFlow] as [A]  where  Ifdel='1' ";
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
            string sql = "  Delete from qp_oa_AddWorkFlow  where ID in (" + str + ")";
            this.List.ExeSql(sql);
            string str3 = "  Delete from qp_oa_AddWorkFlowGc  where Keyid in (" + str + ")";
            this.List.ExeSql(str3);
            this.pulicss.InsertLog("删除工作销毁", "工作销毁");
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pulicss.addfenye(this.DropDownList1.SelectedValue);
            this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int num;
            if (e.CommandName == "Huifu")
            {
                num = Convert.ToInt32(e.CommandArgument);
                string sql = "Update qp_oa_AddWorkFlow  Set Ifdel='0'  where ID='" + num + "'";
                this.List.ExeSql(sql);
            }
            if (e.CommandName == "ShanChu")
            {
                num = Convert.ToInt32(e.CommandArgument);
                string str2 = "select Number from qp_oa_AddWorkFlow  where id='" + num + "'  ";
                SqlDataReader list = this.List.GetList(str2);
                if (list.Read())
                {
                    string str3 = "  Delete from qp_oa_AddWorkFlowFileKey  where AddNumber='" + list["Number"] + "'";
                    this.List.ExeSql(str3);
                }
                list.Close();
                string str4 = "  Delete from qp_oa_AddWorkFlow  where ID='" + num + "'";
                this.List.ExeSql(str4);
                string str5 = "  Delete from qp_oa_AddWorkFlowGc  where Keyid='" + num + "'";
                this.List.ExeSql(str5);
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
                Label label = (Label) e.Row.FindControl("Lid");
                Label label2 = (Label) e.Row.FindControl("Label2");
                Label label3 = (Label) e.Row.FindControl("Label3");
                Label label4 = (Label) e.Row.FindControl("Label4");
                string sql = "select id,UpNodeId,Name,FlowNumber,FormId,Number,UpNodeName,Shuxing,FormName from qp_oa_AddWorkFlow  where id='" + label.Text + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["Shuxing"].ToString() == "自由流程")
                    {
                        label2.Text = "<a href='javascript:void(0)' onclick='window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>自由流程</a>";
                        label3.Text = "<a href='javascript:void(0)' onclick='window.open (\"WorkFlowList_show_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=660, width=920,toolbar=no, menubar=no, scrollbars=yes,resizable=no,location=no, status=no,top=0,left=0\")'>" + list["FormName"].ToString() + "</a>";
                        label4.Text = "<a href='javascript:void(0)' onclick='window.open (\"WorkFlowList_show_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=660, width=920,toolbar=no, menubar=no, scrollbars=yes,resizable=no,location=no, status=no,top=0,left=0\")'>" + list["Name"].ToString() + "</a>";
                    }
                    else
                    {
                        label2.Text = "<a href='javascript:void(0)' onclick='window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>" + list["UpNodeName"].ToString() + "</a>";
                        label3.Text = "<a href='javascript:void(0)' onclick='window.open (\"WorkFlowListJk_show.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=660, width=920,toolbar=no, menubar=no, scrollbars=yes,resizable=no,location=no, status=no,top=0,left=0\")'>" + list["FormName"].ToString() + "</a>";
                        label4.Text = "<a href='javascript:void(0)' onclick='window.open (\"WorkFlowListJk_show.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "\", \"_blank\", \"height=660, width=920,toolbar=no, menubar=no, scrollbars=yes,resizable=no,location=no, status=no,top=0,left=0\")'>" + list["Name"].ToString() + "</a>";
                    }
                }
                list.Close();
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                button.Attributes.Add("onclick", "javascript:return confirm('确定恢复此工作吗？流水号：[" + e.Row.Cells[1].Text.ToString() + "]')");
                LinkButton button2 = (LinkButton) e.Row.FindControl("LinkButton2");
                button2.Attributes.Add("onclick", "javascript:return confirm('确定彻底删除此工作吗？流水号：[" + e.Row.Cells[1].Text.ToString() + "]')");
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

