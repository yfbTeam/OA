namespace xyoa.WorkFlow
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListSp_Ht : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox C1;
        protected CheckBox C2;
        protected CheckBox C3;
        protected CheckBox C4;
        protected CheckBox C5;
        protected CheckBox C6;
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
        protected TextBox JbGuanlianID;
        protected TextBox JbGuanlianName;
        protected TextBox JbRealname;
        protected TextBox JbUsername;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        protected TextBox NodeId;
        protected TextBox Number;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox txtSmsContent;
        protected TextBox ZbGuanlianID;
        protected TextBox ZbGuanlianName;
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
                if (list["GlNum"].ToString() == this.GlNum1.Text)
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
            this.ZbUsername.Text = null;
            this.ZbRealname.Text = null;
            this.JbUsername.Text = null;
            this.JbRealname.Text = null;
            this.zidong(str);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int num;
            string sql = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已办结' ,EndTime='", DateTime.Now.ToString(), "'  where KeyFile='", this.ViewState["WfNumber"], "' and BLusername='", this.Session["username"], "' and XuHao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "' and States!='已委托'" });
            this.List.ExeSql(sql);
            string str2 = null;
            string str3 = null;
            str3 = "" + this.JbUsername.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str3.Split(new char[] { ',' });
            for (num = 0; num < strArray.Length; num++)
            {
                str2 = str2 + "'" + strArray[num] + "',";
            }
            str2 = str2 + "'0'";
            string str4 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str2 + ") ";
            SqlDataReader reader = this.List.GetList(str4);
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
                string str5 = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + this.ViewState["FqUsername"].ToString() + "' ";
                SqlDataReader reader2 = this.List.GetList(str5);
                if (reader2.Read())
                {
                    this.pulicss.InsertSms(reader2["MoveTel"].ToString(), string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已转交到：", this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", ""), "" }));
                }
                reader2.Close();
            }
            string str6 = null;
            string str7 = null;
            str7 = "" + this.ViewState["JbObjectId"] + "";
            ArrayList list2 = new ArrayList();
            string[] strArray2 = str7.Split(new char[] { ',' });
            for (num = 0; num < strArray2.Length; num++)
            {
                str6 = str6 + "'" + strArray2[num] + "',";
            }
            str6 = str6 + "'0'";
            string str8 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str6 + ") ";
            SqlDataReader reader3 = this.List.GetList(str8);
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
            string str9 = "Update qp_oa_AddWorkFlowPicRy  Set States='已办结'   where KeyFile='" + base.Request.QueryString["Number"] + "' and States!='已委托'";
            this.List.ExeSql(str9);
            string str10 = "select * from qp_oa_WorkFlowNode where id='" + this.NodeId.Text + "'";
            SqlDataReader reader4 = this.List.GetList(str10);
            if (reader4.Read())
            {
                string str19;
                string str11 = string.Concat(new object[] { 
                    "Update qp_oa_AddWorkFlow  Set GlNum='", this.GlNum.Text, "',YJBNodeNum=YJBNodeNum+',", this.ViewState["UpNodeNum"], "',State='正在办理',ZbObjectId='", this.ZbUsername.Text, "',ZbObjectName='", this.ZbRealname.Text, "',JbObjectId='", this.JbUsername.Text, "',JbObjectName='", this.JbRealname.Text, "',UpNodeNumber='", reader4["NodeNumber"], "',UpNodeId='", reader4["id"], 
                    "',UpNodeNum='", reader4["NodeNum"], "',UpNodeName='", reader4["NodeName"], "',UpTimeSet='", DateTime.Now.ToString(), "'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'"
                 });
                this.List.ExeSql(str11);
                string str12 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlow where (CHARINDEX(',", this.Session["username"], ",',','+YJBObjectId+',')   >   0 ) and id='", base.Request.QueryString["id"], "'" });
                SqlDataReader reader5 = this.List.GetList(str12);
                if (!reader5.Read())
                {
                    string str13 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set YJBObjectId=YJBObjectId+'", this.Session["username"], ",',YJBObjecName=YJBObjecName+'", this.Session["realname"], ",'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'" });
                    this.List.ExeSql(str13);
                }
                reader5.Close();
                string str14 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPic (GlNum,LcNum,KeyFile,XuHao,Jiedian) values ('", this.GlNum.Text, "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", reader4["NodeNum"], "','", reader4["NodeName"], "')" });
                this.List.ExeSql(str14);
                if (this.ZbUsername.Text != "")
                {
                    string str15 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", this.GlNum.Text, "','", reader4["NodeNum"], "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", this.ZbUsername.Text, "','", this.ZbRealname.Text, "','", DateTime.Now.ToString(), "','','未接收','主办')" });
                    this.List.ExeSql(str15);
                }
                string str16 = null;
                string str17 = null;
                if (this.ZbUsername.Text != "")
                {
                    str17 = "" + this.JbUsername.Text.Replace("" + this.ZbUsername.Text + ",", "") + "";
                }
                else
                {
                    str17 = "" + this.JbUsername.Text + "";
                }
                ArrayList list3 = new ArrayList();
                string[] strArray3 = str17.Split(new char[] { ',' });
                for (num = 0; num < strArray3.Length; num++)
                {
                    str16 = str16 + "'" + strArray3[num] + "',";
                }
                str16 = str16 + "'0'";
                string str18 = "select username,realname from qp_oa_Username where  username in (" + str16 + ") ";
                SqlDataReader reader6 = this.List.GetList(str18);
                while (reader6.Read())
                {
                    str19 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", this.GlNum.Text, "','", reader4["NodeNum"], "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", reader6["username"], "','", reader6["realname"], "','", DateTime.Now.ToString(), "','','未接收','经办')" });
                    this.List.ExeSql(str19);
                }
                reader6.Close();
                string str20 = "select A.id as Aid,A.GlNum,A.IfZb,A.LcNum,A.KeyFile,A.XuHao,A.KeyFile,A.BLusername,A.BLrealname,B.* from [qp_oa_AddWorkFlowPicRy] as [A] inner join [qp_oa_MyWeituo] as [B] on [A].[BLusername] = [B].Username and [B].[States] = '1' and [A].KeyFile='" + base.Request.QueryString["Number"] + "' and [A].GlNum='" + this.GlNum.Text + "' ";
                SqlDataReader reader7 = this.List.GetList(str20);
                while (reader7.Read())
                {
                    string str21 = "select id,Number,UpNodeNum,UpNodeName,FormName,Name from qp_oa_AddWorkFlow where Number='" + reader7["KeyFile"] + "'";
                    SqlDataReader reader8 = this.List.GetList(str21);
                    if (reader8.Read())
                    {
                        string str22;
                        string str23;
                        string str24;
                        if (reader7["IfZb"].ToString() == "主办")
                        {
                            str22 = "" + reader8["JbObjectId"].ToString().Replace("" + reader7["BLusername"].ToString() + ",", "" + reader7["WtUsername"].ToString() + ",") + "";
                            str23 = "" + reader8["JbObjectName"].ToString().Replace("" + reader7["BLusername"].ToString() + ",", "" + reader7["WtRealname"].ToString() + ",") + "";
                            str24 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set ZbObjectId='", reader7["WtUsername"], "',ZbObjectName='", reader7["WtRealname"], "',JbObjectId='", str22, "',JbObjectName='", str23, "'  where id='", reader8["id"].ToString(), "'" });
                            this.List.ExeSql(str24);
                        }
                        else
                        {
                            str22 = "" + reader8["JbObjectId"].ToString().Replace("" + reader7["BLusername"].ToString() + ",", "" + reader7["WtUsername"].ToString() + ",") + "";
                            str23 = "" + reader8["JbObjectName"].ToString().Replace("" + reader7["BLusername"].ToString() + ",", "" + reader7["WtRealname"].ToString() + ",") + "";
                            str24 = "Update qp_oa_AddWorkFlow  Set JbObjectId='" + str22 + "',JbObjectName='" + str23 + "'  where id='" + reader8["id"].ToString() + "'";
                            this.List.ExeSql(str24);
                        }
                    }
                    reader8.Close();
                    if (this.C1.Checked)
                    {
                        this.pulicss.InsertMessage("" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text + "", reader7["WtUsername"].ToString(), reader7["WtRealname"].ToString(), "/WorkFlow/WorkFlowList.aspx");
                    }
                    if (this.C2.Checked)
                    {
                        string str25 = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + reader7["WtUsername"].ToString() + "' ";
                        SqlDataReader reader9 = this.List.GetList(str25);
                        if (reader9.Read())
                        {
                            this.pulicss.InsertSms(reader9["MoveTel"].ToString(), "" + this.txtSmsContent.Text + "，办理步骤：" + this.FormName.SelectedItem.Text.Replace("<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>", "") + "");
                        }
                        reader9.Close();
                    }
                    string str26 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已委托',EndTime='", DateTime.Now.ToString(), "',WtUsername='", reader7["WtUsername"], "',WtRealname='", reader7["WtRealname"], "'   where id='", reader7["Aid"], "'" });
                    this.List.ExeSql(str26);
                    str19 = string.Concat(new object[] { 
                        "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", reader7["GlNum"], "','", reader7["XuHao"], "','", reader7["LcNum"], "','", reader7["KeyFile"], "','", reader7["WtUsername"], "','", reader7["WtRealname"], "','", DateTime.Now.ToString(), "','','未接收','", reader7["IfZb"], 
                        "')"
                     });
                    this.List.ExeSql(str19);
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
            base.Response.Write("<script language=javascript>alert('转交成功！');window.opener.location.href='WorkFlowList.aspx';window.close();</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlowListSp.aspx?id=" + base.Request.QueryString["id"] + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "");
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
                    this.ViewState["FormNumber"] = list["FormNumber"].ToString();
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
                    this.ViewState["WfNumber"] = list["Number"].ToString();
                    this.ViewState["YJBNodeNum"] = ("" + list["YJBNodeNum"].ToString() + ",0").Replace(",,", ",");
                    this.GlNum1.Text = list["GlNum"].ToString();
                    this.FlowId.Text = list["FlowId"].ToString();
                }
                list.Close();
                this.BindDroList();
                string str4 = string.Concat(new object[] { "select  IfZb from qp_oa_AddWorkFlowPicRy  where  KeyFile='", base.Request.QueryString["Number"], "' and xuhao='", this.ViewState["UpNodeNum"], "' and BLusername='", this.Session["username"], "' and GlNum='", this.GlNum1.Text, "' " });
                SqlDataReader reader2 = this.List.GetList(str4);
                if (reader2.Read())
                {
                    string str5;
                    SqlDataReader reader3;
                    string str6;
                    SqlDataReader reader4;
                    string str7;
                    this.ViewState["IfZb"] = reader2["IfZb"].ToString();
                    if (this.ViewState["IfZb"].ToString() == "主办")
                    {
                        str5 = "select ZbHuitui from qp_oa_WorkFlowNode where id='" + int.Parse(base.Request.QueryString["UpNodeId"]) + "'";
                        reader3 = this.List.GetList(str5);
                        if (reader3.Read())
                        {
                            if (reader3["ZbHuitui"].ToString() == "1")
                            {
                                base.Response.Write("<script language=javascript>alert('不允许回退！');window.close();</script>");
                            }
                            if (reader3["ZbHuitui"].ToString() == "2")
                            {
                                str6 = string.Concat(new object[] { "select top 1 id from qp_oa_AddWorkFlowPic where  XuHao  in (", this.ViewState["YJBNodeNum"], ")  and KeyFile='", base.Request.QueryString["Number"], "'  and GlNum!='", this.GlNum1.Text, "' order by id desc" });
                                reader4 = this.List.GetList(str6);
                                if (reader4.Read())
                                {
                                    str7 = "select id,'<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>'+Jiedian as Jiedian  from qp_oa_AddWorkFlowPic where id='" + reader4["id"].ToString() + "'";
                                    this.list.Bind_DropDownList_nothing1(this.FormName, str7, "id", "Jiedian");
                                }
                                reader4.Close();
                            }
                            if (reader3["ZbHuitui"].ToString() == "3")
                            {
                                str7 = string.Concat(new object[] { "select id,'<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>'+Jiedian as Jiedian  from qp_oa_AddWorkFlowPic where  XuHao  in (", this.ViewState["YJBNodeNum"], ")  and KeyFile='", base.Request.QueryString["Number"], "'  and GlNum!='", this.GlNum1.Text, "' order by id asc" });
                                this.list.Bind_DropDownList_nothing1(this.FormName, str7, "id", "Jiedian");
                            }
                        }
                        reader3.Close();
                    }
                    else
                    {
                        str5 = "select JbHuitui from qp_oa_WorkFlowNode where id='" + int.Parse(base.Request.QueryString["UpNodeId"]) + "'";
                        reader3 = this.List.GetList(str5);
                        if (reader3.Read())
                        {
                            if (reader3["JbHuitui"].ToString() == "1")
                            {
                                base.Response.Write("<script language=javascript>alert('不允许回退！');window.close();</script>");
                            }
                            if (reader3["JbHuitui"].ToString() == "2")
                            {
                                str6 = string.Concat(new object[] { "select top 1 id from qp_oa_AddWorkFlowPic where  XuHao  in (", this.ViewState["YJBNodeNum"], ")  and KeyFile='", base.Request.QueryString["Number"], "'  and GlNum!='", this.GlNum1.Text, "' order by id desc" });
                                reader4 = this.List.GetList(str6);
                                if (reader4.Read())
                                {
                                    str7 = "select id,'<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>'+Jiedian as Jiedian  from qp_oa_AddWorkFlowPic where id='" + reader4["id"].ToString() + "'";
                                    this.list.Bind_DropDownList_nothing1(this.FormName, str7, "id", "Jiedian");
                                }
                                reader4.Close();
                            }
                            if (reader3["JbHuitui"].ToString() == "3")
                            {
                                str7 = string.Concat(new object[] { "select id,'<img src=\"/oaimg/menu/arrow_down.gif\" border=0/>'+Jiedian as Jiedian  from qp_oa_AddWorkFlowPic where  XuHao  in (", this.ViewState["YJBNodeNum"], ")  and KeyFile='", base.Request.QueryString["Number"], "'  and GlNum!='", this.GlNum1.Text, "' order by id asc" });
                                this.list.Bind_DropDownList_nothing1(this.FormName, str7, "id", "Jiedian");
                            }
                        }
                        reader3.Close();
                    }
                }
                reader2.Close();
                if (this.FormName.Items.Count > 0)
                {
                    this.FormName.Items[0].Selected = true;
                }
                this.BindLb(this.FormName.SelectedValue);
                this.ViewState["ZjBLrealname"] = "";
                string str8 = string.Concat(new object[] { "select  * from qp_oa_AddWorkFlowPicRy  where  KeyFile='", base.Request.QueryString["Number"], "' and xuhao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "'  order by id asc" });
                SqlDataReader reader5 = this.List.GetList(str8);
                while (reader5.Read())
                {
                    StateBag bag = ViewState;
                    object obj2 = bag["ZjBLrealname"];
                    (bag = this.ViewState)["ZjBLrealname"] = string.Concat(new object[] { obj2, "", reader5["BLrealname"], "(", reader5["States"], ")，" });
                }
                reader5.Close();
            }
        }

        public void zidong(string str)
        {
            string sql = "select LcNum,XuHao from qp_oa_AddWorkFlowPic where id='" + str + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                string str3 = string.Concat(new object[] { "select  id from qp_oa_WorkFlowNode where NodeNum='", list["XuHao"].ToString(), "' and FormNumber='", this.ViewState["FormNumber"], "' and FlowNumber='", this.ViewState["FlowNumber"], "'  order by id asc" });
                SqlDataReader reader2 = this.List.GetList(str3);
                if (reader2.Read())
                {
                    this.NodeId.Text = reader2["id"].ToString();
                }
                reader2.Close();
                string str4 = "select  top 1 BLusername,BLrealname from qp_oa_AddWorkFlowPicRy where LcNum='" + list["LcNum"].ToString() + "' and IfZb='主办'  order by id desc";
                SqlDataReader reader3 = this.List.GetList(str4);
                if (reader3.Read())
                {
                    this.ZbUsername.Text = reader3["BLusername"].ToString();
                    this.ZbRealname.Text = reader3["BLrealname"].ToString();
                    this.JbUsername.Text = this.JbUsername.Text + "" + reader3["BLusername"].ToString() + ",";
                    this.JbRealname.Text = this.JbRealname.Text + "" + reader3["BLrealname"].ToString() + ",";
                    this.Label1.Text = "";
                }
                else
                {
                    this.Label1.Text = "未指定主办人。";
                }
                reader3.Close();
                string str5 = "select  BLusername,BLrealname from qp_oa_AddWorkFlowPicRy where LcNum='" + list["LcNum"].ToString() + "' and IfZb='经办'  order by id asc";
                SqlDataReader reader4 = this.List.GetList(str5);
                while (reader4.Read())
                {
                    this.JbUsername.Text = this.JbUsername.Text + "" + reader4["BLusername"].ToString() + ",";
                    this.JbRealname.Text = this.JbRealname.Text + "" + reader4["BLrealname"].ToString() + ",";
                }
                reader4.Close();
            }
            list.Close();
        }
    }
}

