namespace xyoa.pda.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowList_blz : Page
    {
        protected Button btnFirst;
        protected Button btnLast;
        protected Button btnNext;
        protected Button btnPrev;
        protected Button Button1;
        protected Button Button4;
        protected HtmlForm form1;
        protected DropDownList FormName;
        protected TextBox FqRealname;
        protected GridView GridView1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();
        private divform showform = new divform();

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            try
            {
                this.GridView1.PageIndex = Convert.ToInt32(((Button) sender).CommandName) - 1;
                this.DataBindToGridview();
            }
            catch
            {
                base.Response.Write("<script language='javascript'>alert('没有这么多页！');</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("/pda/Main.aspx?leixing=1");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            this.DataBindToGridview();
        }

        public string CreateMidSql()
        {
            string str = string.Empty;
            if (this.Name.Text != "")
            {
                str = str + " and A.Name like '%" + this.pulicss.GetFormatStr(this.Name.Text) + "%'";
            }
            if (this.FqRealname.Text != "")
            {
                str = str + " and A.FqRealname like '%" + this.pulicss.GetFormatStr(this.FqRealname.Text) + "%'";
            }
            if (this.FormName.SelectedValue != "")
            {
                str = str + " and A.FormId = '" + this.FormName.SelectedValue + "'";
            }
            return str;
        }

        public void DataBindToGridview()
        {
            string sql = string.Concat(new object[] { "select A.id,A.UpTimeSet,A.Shuxing,A.Number,A.JinJiChengDu,A.Sequence,A.FormName,A.Name,A.FlowNumber,A.FqUsername,A.FqRealname,A.NodeName,A.UpNodeName,A.UpNodeId,A.FormId,C.StartTime as SjStartTime,States  from [qp_oa_AddWorkFlow] as [A] inner join [qp_oa_AddWorkFlowPicRy] as [C] on [A].[Number] = [C].KeyFile and [A].[UpNodeNum] = [C].xuhao and [A].[GlNum] = [C].GlNum where BLusername='", this.Session["username"], "' and States='办理中' and State='正在办理' and Ifdel='0' ", this.CreateMidSql(), " order by UpTimeSet desc" });
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
            this.btnFirst.CommandName = "1";
            this.btnPrev.CommandName = (this.GridView1.PageIndex == 0) ? "1" : this.GridView1.PageIndex.ToString();
            this.btnNext.CommandName = (this.GridView1.PageCount == 1) ? this.GridView1.PageCount.ToString() : ((this.GridView1.PageIndex + 2)).ToString();
            this.btnLast.CommandName = this.GridView1.PageCount.ToString();
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
                this.DataBindToGridview();
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
                this.DataBindToGridview();
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
                Label label6 = (Label) e.Row.FindControl("Label6");
                Label label7 = (Label) e.Row.FindControl("Label7");
                Label label8 = (Label) e.Row.FindControl("Label5");
                Label label9 = (Label) e.Row.FindControl("Label8");
                Label label10 = (Label) e.Row.FindControl("SjStartTime");
                Label label11 = (Label) e.Row.FindControl("States");
                Label label12 = (Label) e.Row.FindControl("UpNodeId");
                Label label13 = (Label) e.Row.FindControl("Number");
                Label label14 = (Label) e.Row.FindControl("fujian");
                Button button = (Button) e.Row.FindControl("LinkButton1");
                button.Attributes.Add("onclick", "javascript:return confirm('确认收回工作，重新办理吗？');LoadingShow();");
                Button button2 = (Button) e.Row.FindControl("LinkButton2");
                button2.Attributes.Add("onclick", "javascript:return confirm('确定取消委托，收回工作，重新办理吗？');LoadingShow();");
                label2.Text = "";
                label3.Text = "";
                label4.Text = "";
                label5.Text = "";
                label8.Text = "";
                label6.Text = "";
                label7.Text = "";
                label9.Text = "";
                button.Visible = false;
                button2.Visible = false;
                this.pulicss.GetFileSj(label13.Text, label14);
                string sql = "select id,name,UpNodeId,FlowNumber,FormId,Number,UpNodeName,Shuxing,FormName,UpNodeNum,GlNum from qp_oa_AddWorkFlow  where id='" + label.Text + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    string str2;
                    string str3;
                    SqlDataReader reader2;
                    string str4;
                    SqlDataReader reader3;
                    if (list["Shuxing"].ToString() == "自由流程")
                    {
                        str2 = "";
                        str3 = string.Concat(new object[] { "select IfZb from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername='", this.Session["username"], "'  and XuHao='", list["UpNodeNum"], "' and GlNum='", list["GlNum"].ToString(), "'" });
                        reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            str2 = reader2["IfZb"].ToString();
                        }
                        reader2.Close();
                        if (str2 == "主办")
                        {
                            str4 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername!='", this.Session["username"], "' and XuHao='", list["UpNodeNum"], "' and  (States!='已办结' and States!='已委托') and GlNum='", list["GlNum"].ToString(), "'" });
                            reader3 = this.List.GetList(str4);
                            if (reader3.Read())
                            {
                                if (list["UpNodeName"].ToString() == "1")
                                {
                                    label2.Visible = true;
                                }
                                else
                                {
                                    label2.Visible = false;
                                }
                            }
                            else
                            {
                                label5.Visible = false;
                                label2.Visible = true;
                            }
                            reader3.Close();
                        }
                        else if (list["NodeSite"].ToString() == "1")
                        {
                            label2.Visible = true;
                        }
                        else if (list["NodeSite"].ToString() == "2")
                        {
                            str4 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername!='", this.Session["username"], "' and XuHao='", list["UpNodeNum"], "' and  (States!='已办结' and States!='已委托') and GlNum='", list["GlNum"].ToString(), "'" });
                            reader3 = this.List.GetList(str4);
                            if (reader3.Read())
                            {
                                label2.Visible = false;
                            }
                            else
                            {
                                label2.Visible = true;
                                label5.Visible = false;
                            }
                            reader3.Close();
                        }
                        else if (str2 == "经办")
                        {
                            label2.Visible = false;
                        }
                        label2.Text = "<input id=\"Button1\" type=\"button\" value=\"转交下一步\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListSp_zj_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        label4.Text = "<input id=\"Button1\" type=\"button\" value=\"意见\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListYj_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        label5.Text = "<input id=\"Button1\" type=\"button\" value=\"办理完毕\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListSp_wb_zy.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        label6.Text = "<input id=\"Button1\" type=\"button\" value=\"表单\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListBd.aspx?id=" + list["id"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        label3.Text = "自由流程";
                        label8.Text = "<input id=\"Button1\" type=\"button\" value=\"委托\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListWt.aspx?id=" + list["id"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        label9.Text = "<input id=\"Button1\" type=\"button\" value=\"流程图\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListLct.aspx?id=" + list["id"].ToString() + "&Number=" + list["Number"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        button.Visible = false;
                        button2.Visible = false;
                    }
                    else
                    {
                        str2 = "";
                        string str5 = "";
                        string str6 = "";
                        string str7 = "";
                        string str8 = "";
                        string str9 = "select * from qp_oa_WorkFlowNode where id='" + label12.Text + "'";
                        SqlDataReader reader4 = this.List.GetList(str9);
                        if (reader4.Read())
                        {
                            str6 = reader4["JcZhuanjiao"].ToString();
                            str5 = reader4["ZbZhuanjiao"].ToString();
                            str7 = reader4["ZbHuitui"].ToString();
                            str8 = reader4["JbHuitui"].ToString();
                        }
                        reader4.Close();
                        str3 = string.Concat(new object[] { "select IfZb from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername='", this.Session["username"], "'  and XuHao='", list["UpNodeNum"], "' and GlNum='", list["GlNum"].ToString(), "'" });
                        reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            str2 = reader2["IfZb"].ToString();
                        }
                        reader2.Close();
                        if (str2 == "主办")
                        {
                            str4 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername!='", this.Session["username"], "' and XuHao='", list["UpNodeNum"], "' and  (States!='已办结' and States!='已委托') and GlNum='", list["GlNum"].ToString(), "'" });
                            reader3 = this.List.GetList(str4);
                            if (reader3.Read())
                            {
                                if (str5 == "1")
                                {
                                    label2.Visible = true;
                                }
                                else
                                {
                                    label2.Visible = false;
                                }
                            }
                            else
                            {
                                label5.Visible = false;
                                label2.Visible = true;
                            }
                            reader3.Close();
                            if (str7 == "1")
                            {
                                label7.Visible = false;
                            }
                            else
                            {
                                label7.Visible = true;
                            }
                        }
                        else
                        {
                            switch (str6)
                            {
                                case "1":
                                    label2.Visible = true;
                                    break;

                                case "2":
                                    str4 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowPicRy where KeyFile='", list["Number"].ToString(), "' and BLusername!='", this.Session["username"], "' and XuHao='", list["UpNodeNum"], "' and  (States!='已办结' and States!='已委托') and GlNum='", list["GlNum"].ToString(), "'" });
                                    reader3 = this.List.GetList(str4);
                                    if (reader3.Read())
                                    {
                                        label2.Visible = false;
                                    }
                                    else
                                    {
                                        label2.Visible = true;
                                        label5.Visible = false;
                                    }
                                    reader3.Close();
                                    break;

                                default:
                                    if (str2 == "经办")
                                    {
                                        label2.Visible = false;
                                    }
                                    break;
                            }
                            if (str8 == "1")
                            {
                                label7.Visible = false;
                            }
                            else
                            {
                                label7.Visible = true;
                            }
                        }
                        label2.Text = "<input id=\"Button1\" type=\"button\" value=\"转交下一步\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListSp_zj.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        label3.Text = "" + list["UpNodeName"].ToString() + "";
                        label4.Text = "<input id=\"Button1\" type=\"button\" value=\"意见\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListYj.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        label5.Text = "<input id=\"Button1\" type=\"button\" value=\"办理完毕\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListSp_wb.aspx?id=" + list["id"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        label6.Text = "<input id=\"Button1\" type=\"button\" value=\"表单\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListBd.aspx?id=" + list["id"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        label7.Text = "<input id=\"Button1\" type=\"button\" value=\"回退\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListSp_ht.aspx?id=" + list["id"].ToString() + "&Number=" + list["Number"].ToString() + "&UpNodeId=" + list["UpNodeId"].ToString() + "&FlowNumber=" + list["FlowNumber"].ToString() + "&FormId=" + list["FormId"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        label9.Text = "<input id=\"Button1\" type=\"button\" value=\"流程图\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListLct.aspx?id=" + list["id"].ToString() + "&Number=" + list["Number"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        label8.Text = "<input id=\"Button1\" type=\"button\" value=\"委托\" onclick=\"LoadingShow();var num = Math.random();location.href='WorkFlowListWt.aspx?id=" + list["id"].ToString() + "&tmp=' + num + '';\" class=\"form_wf\"/>";
                        button.Visible = false;
                        button2.Visible = false;
                    }
                }
                list.Close();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/pda/default.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sQL = "select id,FormName  from qp_oa_DIYForm";
                this.list.Bind_DropDownList_kong(this.FormName, sQL, "id", "FormName");
                this.btnFirst.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnPrev.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnNext.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.btnLast.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.Button4.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                this.DataBindToGridview();
            }
        }
    }
}

