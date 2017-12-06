namespace xyoa.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListJkSp_Ht : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlInputButton Button3;
        protected HtmlInputButton Button4;
        protected CheckBox C1;
        protected CheckBox C2;
        protected CheckBox C3;
        protected CheckBox C4;
        protected CheckBox C5;
        protected CheckBox C6;
        protected CheckBox CheckBox1;
        protected TextBox FlowId;
        protected HtmlForm form1;
        protected RadioButtonList FormName;
        protected Label GlGuize;
        protected TextBox GlNum;
        protected TextBox GlNum1;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        protected HtmlImage IMG2;
        protected HtmlImage IMG3;
        protected TextBox JbRealname;
        protected TextBox JbUsername;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        protected TextBox Number;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox txtSmsContent;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;
        protected TextBox ZbUsername6;

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.IMG1, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.C2, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.IMG2, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.C4, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.IMG3, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.C6, ",14,", this.pulicss.GetSms());
            this.ZbRealname.Attributes.Add("readonly", "readonly");
            this.JbRealname.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        public void BindDroList()
        {
            string sql = "select  * from qp_oa_AddWorkFlowPic where KeyFile='" + base.Request.QueryString["Number"] + "'  order by id asc";
            SqlDataReader list = this.List.GetList(sql);
            this.Liucheng.Text = null;
            int num = 1;
            this.Liucheng.Text = this.Liucheng.Text + "  <table border=\"0\" cellpadding=\"4\" cellspacing=\"1\" width=\"100%\" class=\"nextpage\">";
            while (list.Read())
            {
                object text;
                string str2 = null;
                if (list["Jiedian"].ToString() == this.ViewState["NodeName"].ToString())
                {
                    text = this.Liucheng.Text;
                    this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>第<font color=red><b>", num, "</b></font>步", list["Jiedian"], "(当前步骤) </td>" });
                }
                else
                {
                    text = this.Liucheng.Text;
                    this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"30%\"><img src=\"/oaimg/menu/arrow_down.gif\" border=0/>第<font color=red><b>", num, "</b></font>步", list["Jiedian"], " </td>" });
                }
                this.Liucheng.Text = this.Liucheng.Text + "<td class=\"newtd2\" width=\"70%\">";
                str2 = "select  * from qp_oa_AddWorkFlowPicRy  where  LcNum='" + list["LcNum"].ToString() + "'  order by id asc";
                SqlDataReader reader2 = this.List.GetList(str2);
                while (reader2.Read())
                {
                    text = this.Liucheng.Text;
                    this.Liucheng.Text = string.Concat(new object[] { text, "<a href=javascript:void(0) onclick=senduser('", reader2["BLusername"].ToString(), "')  title=\"", reader2["IfZb"], "\">", reader2["BLrealname"], "</a>(", reader2["States"], ")&nbsp;" });
                }
                this.Liucheng.Text = this.Liucheng.Text + "</td>";
                reader2.Close();
                this.Liucheng.Text = this.Liucheng.Text + "</tr>";
                num++;
            }
            list.Close();
            this.Liucheng.Text = this.Liucheng.Text + "</table>";
        }

        public void BindLb(string str)
        {
            string sql = "select ZbUsername,ZbRealname,JbUsername,JbRealname,XrGuize,GlGuize from qp_oa_WorkFlowNode where id='" + str + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                if (list["XrGuize"].ToString() == "1")
                {
                    this.ZbUsername.Text = "";
                    this.ZbRealname.Text = "";
                    this.JbUsername.Text = "";
                    this.JbRealname.Text = "";
                }
                else
                {
                    string str3;
                    SqlDataReader reader2;
                    if (list["XrGuize"].ToString() == "2")
                    {
                        str3 = "select FqUsername,FqRealname from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                        reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            this.ZbUsername.Text = reader2["FqUsername"].ToString();
                            this.ZbRealname.Text = reader2["FqRealname"].ToString();
                            this.JbUsername.Text = "" + reader2["FqUsername"].ToString() + ",";
                            this.JbRealname.Text = "" + reader2["FqRealname"].ToString() + ",";
                        }
                        reader2.Close();
                    }
                    else if (list["XrGuize"].ToString() == "7")
                    {
                        this.ZbUsername.Text = this.Session["Username"].ToString();
                        this.ZbRealname.Text = this.Session["Realname"].ToString();
                        this.JbUsername.Text = "" + this.Session["Username"].ToString() + ",";
                        this.JbRealname.Text = "" + this.Session["Realname"].ToString() + ",";
                    }
                    else if (list["XrGuize"].ToString() == "3")
                    {
                        str3 = "select BmUsername,BmRealname from qp_oa_Bumen where  id='" + this.Session["BuMenId"].ToString() + "'";
                        reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            this.ZbUsername.Text = reader2["BmUsername"].ToString();
                            this.ZbRealname.Text = reader2["BmRealname"].ToString();
                            this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                            this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                        }
                        reader2.Close();
                    }
                    else if (list["XrGuize"].ToString() == "4")
                    {
                        str3 = "select ParentNodesID,BmUsername,BmRealname from qp_oa_Bumen where  id='" + this.Session["BuMenId"].ToString() + "'";
                        reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            if (reader2["ParentNodesID"].ToString() == "0")
                            {
                                string str4 = "select BmUsername,BmRealname from qp_oa_Bumen where  id='" + reader2["ParentNodesID"].ToString() + "'";
                                SqlDataReader reader3 = this.List.GetList(str4);
                                if (reader3.Read())
                                {
                                    this.ZbUsername.Text = reader3["BmUsername"].ToString();
                                    this.ZbRealname.Text = reader3["BmRealname"].ToString();
                                    this.JbUsername.Text = "" + reader3["BmUsername"].ToString() + ",";
                                    this.JbRealname.Text = "" + reader3["BmRealname"].ToString() + ",";
                                }
                                reader3.Close();
                            }
                            else
                            {
                                this.ZbUsername.Text = reader2["BmUsername"].ToString();
                                this.ZbRealname.Text = reader2["BmRealname"].ToString();
                                this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                                this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                            }
                        }
                        reader2.Close();
                    }
                    else if (list["XrGuize"].ToString() == "5")
                    {
                        str3 = "select BmUsername,BmRealname from qp_oa_Bumen where   ParentNodesID='0'  and  CHARINDEX(QxString,(select QxString from qp_oa_Bumen where id='" + HttpContext.Current.Session["BuMenId"].ToString() + "')) > 0";
                        reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            this.ZbUsername.Text = reader2["BmUsername"].ToString();
                            this.ZbRealname.Text = reader2["BmRealname"].ToString();
                            this.JbUsername.Text = "" + reader2["BmUsername"].ToString() + ",";
                            this.JbRealname.Text = "" + reader2["BmRealname"].ToString() + ",";
                        }
                        reader2.Close();
                    }
                    else
                    {
                        this.ZbUsername.Text = list["ZbUsername"].ToString();
                        this.ZbUsername6.Text = list["JbUsername"].ToString();
                        this.ZbRealname.Text = list["ZbRealname"].ToString();
                        this.JbUsername.Text = list["JbUsername"].ToString();
                        this.JbRealname.Text = list["JbRealname"].ToString();
                    }
                }
                if (list["GlGuize"].ToString() == "1")
                {
                    this.Button4.Visible = true;
                    this.Button3.Visible = true;
                    this.Button4.Attributes["onclick"] = "javascript:openUser1(" + list["GlGuize"].ToString() + ");";
                    this.Button3.Attributes["onclick"] = "javascript:openUser2(" + list["GlGuize"].ToString() + ");";
                    this.GlGuize.Text = " - 允许自由选择全部人员";
                }
                else if (list["GlGuize"].ToString() == "2")
                {
                    this.Button4.Visible = true;
                    this.Button3.Visible = true;
                    this.Button4.Attributes["onclick"] = "javascript:openUser1(" + list["GlGuize"].ToString() + ");";
                    this.Button3.Attributes["onclick"] = "javascript:openUser2(" + list["GlGuize"].ToString() + ");";
                    this.GlGuize.Text = " - 允许自由选择本部门人员";
                }
                else if (list["GlGuize"].ToString() == "3")
                {
                    this.Button4.Visible = true;
                    this.Button3.Visible = true;
                    this.Button4.Attributes["onclick"] = "javascript:openUser1(" + list["GlGuize"].ToString() + ");";
                    this.Button3.Attributes["onclick"] = "javascript:openUser2(" + list["GlGuize"].ToString() + ");";
                    this.GlGuize.Text = " - 允许自由选择本角色人员";
                }
                else if (list["GlGuize"].ToString() == "4")
                {
                    this.Button4.Visible = true;
                    this.Button3.Visible = true;
                    this.Button4.Attributes["onclick"] = "javascript:openUser1(" + list["GlGuize"].ToString() + ");";
                    this.Button3.Attributes["onclick"] = "javascript:openUser2(" + list["GlGuize"].ToString() + ");";
                    this.GlGuize.Text = " - 允许自由选择本职位人员";
                }
                else if (list["GlGuize"].ToString() == "6")
                {
                    this.Button4.Visible = true;
                    this.Button3.Visible = true;
                    this.Button4.Attributes["onclick"] = "javascript:openUser1(" + list["GlGuize"].ToString() + ");";
                    this.Button3.Attributes["onclick"] = "javascript:openUser2(" + list["GlGuize"].ToString() + ");";
                    this.GlGuize.Text = " - 只允许从默认人员中选择人员";
                }
                else
                {
                    this.Button4.Visible = false;
                    this.Button3.Visible = false;
                    this.Button4.Attributes["onclick"] = "javascript:openUser1(" + list["GlGuize"].ToString() + ");";
                    this.Button3.Attributes["onclick"] = "javascript:openUser2(" + list["GlGuize"].ToString() + ");";
                    this.GlGuize.Text = " - 不允许自由选择人员";
                }
            }
            list.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = null;
            string str2 = null;
            int num;
            str2 = "" + this.JbUsername.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str2.Split(new char[] { ',' });
            for (num = 0; num < strArray.Length; num++)
            {
                str = str + "'" + strArray[num] + "',";
            }
            str = str + "'0'";
            string sql = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str + ") ";
            SqlDataReader reader = this.List.GetList(sql);
            while (reader.Read())
            {
                if (this.C1.Checked)
                {
                    this.pulicss.InsertMessage("" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text + "", reader["username"].ToString(), reader["realname"].ToString(), "/WorkFlow/WorkFlowList.aspx");
                }
                if (this.C2.Checked)
                {
                    this.pulicss.InsertSms(reader["MoveTel"].ToString(), "" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", "") + "");
                }
            }
            reader.Close();
            if (this.C3.Checked)
            {
                this.pulicss.InsertMessage(string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已转交到：", this.FormName.SelectedItem.Text, "" }), this.ViewState["FqUsername"].ToString(), this.ViewState["FqRealname"].ToString(), "#");
            }
            if (this.C4.Checked)
            {
                string str4 = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + this.ViewState["FqUsername"] + "' ";
                SqlDataReader reader2 = this.List.GetList(str4);
                if (reader2.Read())
                {
                    this.pulicss.InsertSms(reader2["MoveTel"].ToString(), string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已转交到：", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "" }));
                }
                reader2.Close();
            }
            string str5 = null;
            string str6 = null;
            str6 = "" + this.ViewState["JbObjectId"] + "";
            ArrayList list2 = new ArrayList();
            string[] strArray2 = str6.Split(new char[] { ',' });
            for (num = 0; num < strArray2.Length; num++)
            {
                str5 = str5 + "'" + strArray2[num] + "',";
            }
            str5 = str5 + "'0'";
            string str7 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str5 + ") ";
            SqlDataReader reader3 = this.List.GetList(str7);
            while (reader3.Read())
            {
                if (this.C5.Checked)
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "等待您办理的工作", this.ViewState["Name"], "已转交到：", this.FormName.SelectedItem.Text, "" }), reader3["username"].ToString(), reader3["realname"].ToString(), "#");
                }
                if (this.C6.Checked)
                {
                    this.pulicss.InsertSms(reader3["MoveTel"].ToString(), string.Concat(new object[] { "等待您办理的工作", this.ViewState["Name"], "已转交到：", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "" }));
                }
            }
            reader3.Close();
            string str8 = "Update qp_oa_AddWorkFlowPicRy  Set States='已办结'   where KeyFile='" + base.Request.QueryString["Number"] + "' and States!='已委托'";
            this.List.ExeSql(str8);
            string str9 = "select * from qp_oa_WorkFlowNode where id='" + this.FormName.SelectedValue + "'";
            SqlDataReader reader4 = this.List.GetList(str9);
            if (reader4.Read())
            {
                string str18;
                string str10 = string.Concat(new object[] { 
                    "Update qp_oa_AddWorkFlow  Set GlNum='", this.GlNum.Text, "',YJBNodeNum=YJBNodeNum+',", this.ViewState["UpNodeNum"], "',State='正在办理',ZbObjectId='", this.ZbUsername.Text, "',ZbObjectName='", this.ZbRealname.Text, "',JbObjectId='", this.JbUsername.Text, "',JbObjectName='", this.JbRealname.Text, "',UpNodeNumber='", reader4["NodeNumber"], "',UpNodeId='", reader4["id"], 
                    "',UpNodeNum='", reader4["NodeNum"], "',UpNodeName='", reader4["NodeName"], "',UpTimeSet='", DateTime.Now.ToString(), "'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'"
                 });
                this.List.ExeSql(str10);
                string str11 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlow where (CHARINDEX(',", this.Session["username"], ",',','+YJBObjectId+',')   >   0 ) and id='", base.Request.QueryString["id"], "'" });
                SqlDataReader reader5 = this.List.GetList(str11);
                if (!reader5.Read())
                {
                    string str12 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set YJBObjectId=YJBObjectId+'", this.Session["username"], ",',YJBObjecName=YJBObjecName+'", this.Session["realname"], ",'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'" });
                    this.List.ExeSql(str12);
                }
                reader5.Close();
                string str13 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPic (GlNum,LcNum,KeyFile,XuHao,Jiedian) values ('", this.GlNum.Text, "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", reader4["NodeNum"], "','", reader4["NodeName"], "')" });
                this.List.ExeSql(str13);
                if (this.ZbUsername.Text != "")
                {
                    string str14 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", this.GlNum.Text, "','", reader4["NodeNum"], "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", this.ZbUsername.Text, "','", this.ZbRealname.Text, "','", DateTime.Now.ToString(), "','','未接收','主办')" });
                    this.List.ExeSql(str14);
                }
                string str15 = null;
                string str16 = null;
                if (this.ZbUsername.Text != "")
                {
                    str16 = "" + this.JbUsername.Text.Replace("" + this.ZbUsername.Text + ",", "") + "";
                }
                else
                {
                    str16 = "" + this.JbUsername.Text + "";
                }
                ArrayList list3 = new ArrayList();
                string[] strArray3 = str16.Split(new char[] { ',' });
                for (num = 0; num < strArray3.Length; num++)
                {
                    str15 = str15 + "'" + strArray3[num] + "',";
                }
                str15 = str15 + "'0'";
                string str17 = "select username,realname from qp_oa_Username where  username in (" + str15 + ") ";
                SqlDataReader reader6 = this.List.GetList(str17);
                while (reader6.Read())
                {
                    str18 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", this.GlNum.Text, "','", reader4["NodeNum"], "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", reader6["username"], "','", reader6["realname"], "','", DateTime.Now.ToString(), "','','未接收','经办')" });
                    this.List.ExeSql(str18);
                }
                reader6.Close();
                string str19 = "select A.id as Aid,A.GlNum,A.IfZb,A.LcNum,A.KeyFile,A.XuHao,A.KeyFile,A.BLusername,A.BLrealname,B.* from [qp_oa_AddWorkFlowPicRy] as [A] inner join [qp_oa_MyWeituo] as [B] on [A].[BLusername] = [B].Username and [B].[States] = '1' and [A].KeyFile='" + base.Request.QueryString["Number"] + "' and [A].GlNum='" + this.GlNum.Text + "' ";
                SqlDataReader reader7 = this.List.GetList(str19);
                while (reader7.Read())
                {
                    string str20 = "select id,Number,UpNodeNum,UpNodeName,FormName,Name from qp_oa_AddWorkFlow where Number='" + reader7["KeyFile"] + "'";
                    SqlDataReader reader8 = this.List.GetList(str20);
                    if (reader8.Read())
                    {
                        string str21;
                        string str22;
                        string str23;
                        if (reader7["IfZb"].ToString() == "主办")
                        {
                            str21 = "" + reader8["JbObjectId"].ToString().Replace("" + reader7["BLusername"].ToString() + ",", "" + reader7["WtUsername"].ToString() + ",") + "";
                            str22 = "" + reader8["JbObjectName"].ToString().Replace("" + reader7["BLusername"].ToString() + ",", "" + reader7["WtRealname"].ToString() + ",") + "";
                            str23 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set ZbObjectId='", reader7["WtUsername"], "',ZbObjectName='", reader7["WtRealname"], "',JbObjectId='", str21, "',JbObjectName='", str22, "'  where id='", reader8["id"].ToString(), "'" });
                            this.List.ExeSql(str23);
                        }
                        else
                        {
                            str21 = "" + reader8["JbObjectId"].ToString().Replace("" + reader7["BLusername"].ToString() + ",", "" + reader7["WtUsername"].ToString() + ",") + "";
                            str22 = "" + reader8["JbObjectName"].ToString().Replace("" + reader7["BLusername"].ToString() + ",", "" + reader7["WtRealname"].ToString() + ",") + "";
                            str23 = "Update qp_oa_AddWorkFlow  Set JbObjectId='" + str21 + "',JbObjectName='" + str22 + "'  where id='" + reader8["id"].ToString() + "'";
                            this.List.ExeSql(str23);
                        }
                    }
                    reader8.Close();
                    if (this.C1.Checked)
                    {
                        this.pulicss.InsertMessage("" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text + "", reader7["WtUsername"].ToString(), reader7["WtRealname"].ToString(), "/WorkFlow/WorkFlowList.aspx");
                    }
                    if (this.C2.Checked)
                    {
                        string str24 = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + reader7["WtUsername"].ToString() + "' ";
                        SqlDataReader reader9 = this.List.GetList(str24);
                        if (reader9.Read())
                        {
                            this.pulicss.InsertSms(reader9["MoveTel"].ToString(), "" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", "") + "");
                        }
                        reader9.Close();
                    }
                    string str25 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已委托',EndTime='", DateTime.Now.ToString(), "',WtUsername='", reader7["WtUsername"], "',WtRealname='", reader7["WtRealname"], "'   where id='", reader7["Aid"], "'" });
                    this.List.ExeSql(str25);
                    str18 = string.Concat(new object[] { 
                        "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", reader7["GlNum"], "','", reader7["XuHao"], "','", reader7["LcNum"], "','", reader7["KeyFile"], "','", reader7["WtUsername"], "','", reader7["WtRealname"], "','", DateTime.Now.ToString(), "','','未接收','", reader7["IfZb"], 
                        "')"
                     });
                    this.List.ExeSql(str18);
                }
                reader7.Close();
                this.showform.AddWorkFlowLog("110", base.Request.QueryString["Number"].ToString(), this.ViewState["FormNames"].ToString(), this.ViewState["NodeName"].ToString(), "回退工作" + this.ViewState["Name"] + "", this.ViewState["IfZb"].ToString());
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('未找到下一步骤！');</script>");
                return;
            }
            reader4.Close();
            base.Response.Write("<script language=javascript>alert('转交成功！');window.close();</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlowListJkSp.aspx?id=" + base.Request.QueryString["id"] + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "");
        }

        protected void FormName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BindLb(this.FormName.SelectedValue);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!base.IsPostBack)
            {
                Random random = new Random();
                string str = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                this.GlNum.Text = "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                this.BindAttribute();
                string sql = "select * from qp_oa_AddWorkFlow where  Number='" + base.Request.QueryString["Number"] + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.ViewState["FormNames"] = list["FormName"].ToString();
                    this.ViewState["Sequence"] = list["Sequence"].ToString();
                    this.ViewState["Name"] = list["Name"].ToString();
                    this.ViewState["NodeName"] = list["UpNodeName"].ToString();
                    this.ViewState["UpNodeNum"] = list["UpNodeNum"].ToString();
                    this.txtSmsContent.Text = "工作流转交提醒：" + list["Name"].ToString() + "";
                    this.ViewState["FqUsername"] = list["FqUsername"].ToString();
                    this.ViewState["FqRealname"] = list["FqRealname"].ToString();
                    this.ViewState["JbObjectId"] = list["JbObjectId"].ToString();
                    this.ViewState["JbObjectName"] = list["JbObjectName"].ToString();
                    this.ViewState["FlowNumber"] = list["FlowNumber"].ToString();
                    this.ViewState["YJBNodeNum"] = list["YJBNodeNum"].ToString();
                    this.GlNum1.Text = list["GlNum"].ToString();
                    this.FlowId.Text = list["FlowId"].ToString();
                }
                list.Close();
                this.BindDroList();
                this.ViewState["IfZb"] = "主办";
                string str3 = "select ZbHuitui from qp_oa_WorkFlowNode where id='" + int.Parse(base.Request.QueryString["UpNodeId"]) + "'";
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    string sQL = string.Concat(new object[] { "select id,'<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>'+NodeName as NodeName  from qp_oa_WorkFlowNode where  NodeNum  in (", this.ViewState["YJBNodeNum"], ")  and FormId='", base.Request.QueryString["FormId"], "'  and FlowId='", this.FlowId.Text, "'  order by NodeNum asc" });
                    this.list.Bind_DropDownList_nothing1(this.FormName, sQL, "id", "NodeName");
                }
                reader2.Close();
                if (this.FormName.Items.Count > 0)
                {
                    this.FormName.Items[0].Selected = true;
                }
                this.BindLb(this.FormName.SelectedValue);
                this.ViewState["ZjBLrealname"] = "";
                string str5 = string.Concat(new object[] { "select  * from qp_oa_AddWorkFlowPicRy  where  KeyFile='", base.Request.QueryString["Number"], "' and xuhao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "'  order by id asc" });
                SqlDataReader reader3 = this.List.GetList(str5);
                while (reader3.Read())
                {
                    StateBag bag = ViewState;
                    object obj2 = bag["ZjBLrealname"];
                    (bag = this.ViewState)["ZjBLrealname"] = string.Concat(new object[] { obj2, "", reader3["BLrealname"], "(", reader3["States"], ")，" });
                }
                reader3.Close();
            }
        }
    }
}

