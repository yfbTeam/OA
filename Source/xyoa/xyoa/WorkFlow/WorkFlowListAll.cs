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

    public class WorkFlowListAll : Page
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
            this.FqRealname.Attributes.Add("readonly", "readonly");
            this.pulicss.QuanXianVis(this.GridView1, "mmmm3", this.Session["perstr"].ToString());
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
            base.Response.Redirect("WorkFlowListAll.aspx");
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
            return str;
        }

        public void DataBindToGridview(string Sqlsort, string SqlCreate)
        {
            this.GridView1.HeaderStyle.ForeColor = Color.FromName("" + this.pulicss.GetHeadBackColor() + "");
            this.DropDownList1.SelectedValue = this.pulicss.fenye();
            this.GridView1.PageSize = int.Parse(this.DropDownList1.SelectedValue);
            string str = "select A.id,A.UpTimeSet,A.Shuxing,A.Number,A.JinJiChengDu,A.Sequence,A.FormName,A.Name,A.FlowNumber,A.FqUsername,A.FqRealname,A.NodeName,A.UpNodeName,A.UpNodeId,A.FormId,C.StartTime as SjStartTime,States  from [qp_oa_AddWorkFlow] as [A] inner join [qp_oa_AddWorkFlowPicRy] as [C] on [A].[Number] = [C].KeyFile and [A].[UpNodeNum] = [C].xuhao and [A].[GlNum] = [C].GlNum where BLusername='" + this.Session["username"] + "' and ((States='未接收' and State='正在办理') or (States='办理中' and State='正在办理') or (States='已办结' and State='正在办理') or (States='已委托' and State='正在办理')) and Ifdel='0'";
            string str2 = "select count(A.id)  from [qp_oa_AddWorkFlow] as [A] inner join [qp_oa_AddWorkFlowPicRy] as [C] on [A].[Number] = [C].KeyFile and [A].[UpNodeNum] = [C].xuhao and [A].[GlNum] = [C].GlNum where BLusername='" + this.Session["username"] + "' and ((States='未接收' and State='正在办理') or (States='办理中' and State='正在办理') or (States='已办结' and State='正在办理') or (States='已委托' and State='正在办理')) and Ifdel='0'";
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
            string str2;
            SqlDataReader reader2;
            string str3;
            if (e.CommandName == "ShouhuiBj")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select Number,UpNodeNum,UpNodeName,FormName,Name,GlNum from qp_oa_AddWorkFlow where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    str2 = string.Concat(new object[] { "select id,IfZb from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", list["UpNodeNum"], "' and GlNum='", list["GlNum"], "'" });
                    reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        str3 = "Update qp_oa_AddWorkFlowPicRy  Set States='办理中',EndTime=''  where id='" + reader2["id"].ToString() + "'";
                        this.List.ExeSql(str3);
                        this.showform.AddWorkFlowLog("110", list["Number"].ToString(), list["FormName"].ToString(), list["UpNodeName"].ToString(), "收回工作" + list["Name"].ToString() + "", reader2["IfZb"].ToString());
                    }
                    reader2.Close();
                }
                list.Close();
                this.DataBindToGridview(this.SortText.Value, this.CreateMidSql());
            }
            if (e.CommandName == "ShanChuWt")
            {
                num = Convert.ToInt32(e.CommandArgument);
                str = "select Number,UpNodeNum,UpNodeName,FormName,Name from qp_oa_AddWorkFlow where id='" + num + "'";
                list = this.List.GetList(str);
                if (list.Read())
                {
                    str2 = string.Concat(new object[] { "select id,IfZb,WtUsername from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", list["UpNodeNum"], "'" });
                    reader2 = this.List.GetList(str2);
                    if (reader2.Read())
                    {
                        string sql = string.Concat(new object[] { "  Delete from qp_oa_AddWorkFlowPicRy  where KeyFile='", list["Number"].ToString(), "' and BLusername='", reader2["WtUsername"].ToString(), "' and XuHao='", list["UpNodeNum"], "'" });
                        this.List.ExeSql(sql);
                        str3 = "Update qp_oa_AddWorkFlowPicRy  Set States='办理中',EndTime='',WtUsername='',WtRealname=''  where id='" + reader2["id"].ToString() + "'";
                        this.List.ExeSql(str3);
                        this.showform.AddWorkFlowLog("110", list["Number"].ToString(), list["FormName"].ToString(), list["UpNodeName"].ToString(), "取消委托，收回工作" + list["Name"].ToString() + "", reader2["IfZb"].ToString());
                    }
                    reader2.Close();
                }
                list.Close();
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
                Label label2 = (Label) e.Row.FindControl("Label1");
                Label label3 = (Label) e.Row.FindControl("Label2");
                Label label4 = (Label) e.Row.FindControl("Label3");
                Label label5 = (Label) e.Row.FindControl("Label4");
                Label label6 = (Label) e.Row.FindControl("Label5");
                Label label7 = (Label) e.Row.FindControl("SjStartTime");
                LinkButton button = (LinkButton) e.Row.FindControl("LinkButton1");
                button.Attributes.Add("onclick", "javascript:return confirm('确认收回工作[" + e.Row.Cells[0].Text.ToString() + "]，重新办理吗？')");
                LinkButton button2 = (LinkButton) e.Row.FindControl("LinkButton2");
                button2.Attributes.Add("onclick", "javascript:return confirm('确定取消委托，收回工作[" + e.Row.Cells[0].Text.ToString() + "]，重新办理吗？')");
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";
                label6.Text = "";
                button.Visible = false;
                button2.Visible = false;
                string sql = "select id,name,UpNodeId,FlowNumber,FormId,Number,UpNodeName,Shuxing,FormName from qp_oa_AddWorkFlow  where id='" + label.Text + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    if (list["Shuxing"].ToString() == "自由流程")
                    {
                        if ((e.Row.Cells[5].Text.ToString() == "办理中") || (e.Row.Cells[5].Text.ToString() == "未接收"))
                        {
                            label2.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListSp_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>办理</a>";
                            label3.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>自由流程</a>";
                            label4.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListSp_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["FormName"].ToString() + "</a>";
                            label5.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListSp_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["Name"].ToString() + "</a>";
                            label6.Text = "<a href='WorkFlowListWt.aspx?id=" + list["id"].ToString() + "' onclick=\"showwait();\">委托</a>";
                            button.Visible = false;
                            button2.Visible = false;
                        }
                        else if (e.Row.Cells[5].Text.ToString() == "已办结")
                        {
                            label2.Text = "";
                            label3.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>自由流程</a>";
                            label4.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowList_show_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["FormName"].ToString() + "</a>";
                            label5.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowList_show_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["Name"].ToString() + "</a>";
                            label6.Text = "";
                            button.Visible = true;
                            button2.Visible = false;
                        }
                        else
                        {
                            label2.Text = "";
                            label3.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>自由流程</a>";
                            label4.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListSp_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["FormName"].ToString() + "</a>";
                            label5.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListSp_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["Name"].ToString() + "</a>";
                            label6.Text = "";
                            button.Visible = false;
                            button2.Visible = true;
                        }
                    }
                    else
                    {
                        string text;
                        string str2 = "select XbTimes from qp_oa_WorkFlowNode  where id='" + list["UpNodeId"].ToString() + "'";
                        SqlDataReader reader2 = this.List.GetList(str2);
                        if (reader2.Read())
                        {
                            TimeSpan span = (TimeSpan) (DateTime.Parse(DateTime.Now.ToString()) - DateTime.Parse(label7.Text));
                            if (span.TotalHours < double.Parse(reader2["XbTimes"].ToString()))
                            {
                                label5.Text = label5.Text + "";
                            }
                            else
                            {
                                label5.Text = label5.Text + "<img src=\"/oaimg/menu/cs.gif\" />";
                            }
                        }
                        reader2.Close();
                        if ((e.Row.Cells[5].Text.ToString() == "办理中") || (e.Row.Cells[5].Text.ToString() == "未接收"))
                        {
                            label2.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListSp.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0,top=\" + loc_y + \",left=\" + loc_x + \"\")'>办理</a>";
                            label3.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>" + list["UpNodeName"].ToString() + "</a>";
                            label4.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListSp.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["FormName"].ToString() + "</a>";
                            text = label5.Text;
                            label5.Text = text + "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowListSp.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["Name"].ToString() + "</a>";
                            label6.Text = "<a href='WorkFlowListWt.aspx?id=" + list["id"].ToString() + "' onclick=\"showwait();\">委托</a>";
                            button.Visible = false;
                            button2.Visible = false;
                        }
                        else if (e.Row.Cells[5].Text.ToString() == "已办结")
                        {
                            label2.Text = "";
                            label3.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>" + list["UpNodeName"].ToString() + "</a>";
                            label4.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowList_show.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["FormName"].ToString() + "</a>";
                            text = label5.Text;
                            label5.Text = text + "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowList_show.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["Name"].ToString() + "</a>";
                            label6.Text = "";
                            button.Visible = true;
                            button2.Visible = false;
                        }
                        else
                        {
                            label2.Text = "";
                            label3.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();window.open (\"WorkFlowList_bl_lc.aspx?Number=" + list["Number"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=660, width=800,toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=0,left=0\")'>" + list["UpNodeName"].ToString() + "</a>";
                            label4.Text = "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowList_show.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["FormName"].ToString() + "</a>";
                            text = label5.Text;
                            label5.Text = text + "<a href='javascript:void(0)' onclick='var num = Math.random();var aw = screen.width-300;var ah = screen.height-100;loc_x=(screen.availWidth-aw)/2;loc_y=(screen.availHeight-ah)/2;window.open (\"WorkFlowList_show.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=\" + num + \"\", \"_blank\", \"height=\" + ah + \", width=\" + aw + \",toolbar=no, menubar=no, scrollbars=yes,resizable=yes,location=no, status=no,top=\" + loc_y + \",left=\" + loc_x + \"\")'>" + list["Name"].ToString() + "</a>";
                            label6.Text = "";
                            button.Visible = false;
                            button2.Visible = true;
                        }
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

