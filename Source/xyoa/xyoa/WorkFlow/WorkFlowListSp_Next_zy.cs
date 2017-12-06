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

    public class WorkFlowListSp_Next_zy : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected HtmlInputButton Button4;
        protected HtmlInputButton Button6;
        protected CheckBox C1;
        protected CheckBox C2;
        protected CheckBox C3;
        protected CheckBox C4;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected TextBox GlNum;
        protected TextBox GlNum1;
        protected HtmlHead Head1;
        protected HtmlImage IMG1;
        protected HtmlImage IMG2;
        protected TextBox JbRealname;
        protected TextBox JbUsername;
        protected DropDownList JcZhuanjiao;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected Label Liucheng;
        protected TextBox Number;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox txtSmsContent;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;
        protected DropDownList ZbZhuanjiao;

        public void BindAttribute()
        {
            this.pulicss.QuanXianVis(this.IMG1, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.C2, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.IMG2, ",14,", this.pulicss.GetSms());
            this.pulicss.QuanXianVis(this.C4, ",14,", this.pulicss.GetSms());
            this.ZbRealname.Attributes.Add("readonly", "readonly");
            this.JbRealname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button4.Attributes["onclick"] = "javascript:openUser1();";
            this.Button6.Attributes["onclick"] = "javascript:openUser2();";
            this.Button2.Attributes["onclick"] = "javascript:return gd();";
            this.Button3.Attributes["onclick"] = "javascript:return showwait();";
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
                    this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"30%\">第<font color=red><b>", num, "</b></font>步", list["Jiedian"], "(当前步骤) </td>" });
                }
                else
                {
                    text = this.Liucheng.Text;
                    this.Liucheng.Text = string.Concat(new object[] { text, "<tr><td class=\"newtd2\" width=\"30%\">第<font color=red><b>", num, "</b></font>步", list["Jiedian"], " </td>" });
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            int num;
            string str15;
            if (this.C3.Checked)
            {
                this.pulicss.InsertMessage(string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已转交到：", this.ZbRealname.Text, "" }), this.ViewState["FqUsername"].ToString(), this.ViewState["FqRealname"].ToString(), "#");
            }
            if (this.C4.Checked)
            {
                string str = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + this.ViewState["FqUsername"].ToString() + "' ";
                SqlDataReader reader = this.List.GetList(str);
                if (reader.Read())
                {
                    this.pulicss.InsertSms(reader["MoveTel"].ToString(), string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已转交到：", this.ZbRealname.Text, "" }));
                }
                reader.Close();
            }
            string sql = string.Concat(new object[] { "select * from qp_oa_AddWorkFlow where (CHARINDEX(',", this.Session["username"], ",',','+YJBObjectId+',')   >   0 ) and Number='", base.Request.QueryString["Number"], "'" });
            SqlDataReader reader2 = this.List.GetList(sql);
            if (!reader2.Read())
            {
                string str3 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set YJBObjectId=YJBObjectId+'", this.Session["username"], ",',YJBObjecName=YJBObjecName+'", this.Session["realname"], ",'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'" });
                this.List.ExeSql(str3);
            }
            reader2.Close();
            string str4 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPic (GlNum,LcNum,KeyFile,XuHao,Jiedian) values ('", this.GlNum.Text, "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", this.ViewState["UpNodeNum"], "','')" });
            this.List.ExeSql(str4);
            string str5 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已办结' ,EndTime='", DateTime.Now.ToString(), "'  where KeyFile='", this.ViewState["WfNumber"], "' and BLusername='", this.Session["username"], "' and XuHao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "' and States!='已委托'" });
            this.List.ExeSql(str5);
            string str6 = "Update qp_oa_AddWorkFlowPicRy  Set States='已办结'   where KeyFile='" + base.Request.QueryString["Number"] + "' and States!='已委托'";
            this.List.ExeSql(str6);
            string str7 = null;
            string str8 = null;
            str8 = "" + this.JbUsername.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str8.Split(new char[] { ',' });
            for (num = 0; num < strArray.Length; num++)
            {
                str7 = str7 + "'" + strArray[num] + "',";
            }
            str7 = str7 + "'0'";
            string str9 = "select username,realname,Email,MoveTel from qp_oa_Username where  username in (" + str7 + ") ";
            SqlDataReader reader3 = this.List.GetList(str9);
            while (reader3.Read())
            {
                if (this.C1.Checked)
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "", this.txtSmsContent.Text, "，转交人：", this.Session["realname"], "" }), reader3["username"].ToString(), reader3["realname"].ToString(), "/WorkFlow/WorkFlowList.aspx");
                }
                if (this.C2.Checked)
                {
                    this.pulicss.InsertSms(reader3["MoveTel"].ToString(), string.Concat(new object[] { "", this.txtSmsContent.Text, "，转交人：", this.Session["realname"], "" }));
                }
            }
            reader3.Close();
            string str10 = string.Concat(new object[] { 
                "Update qp_oa_AddWorkFlow  Set UpNodeName='", this.ZbZhuanjiao.SelectedValue, "',NodeSite='", this.JcZhuanjiao.SelectedValue, "',GlNum='", this.GlNum.Text, "',UpNodeNum='", this.ViewState["UpNodeNum"], "',State='正在办理',ZbObjectId='", this.ZbUsername.Text, "',ZbObjectName='", this.ZbRealname.Text, "',UpTimeSet='", DateTime.Now.ToString(), "'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), 
                "'"
             });
            this.List.ExeSql(str10);
            if (this.ZbUsername.Text != "")
            {
                string str11 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", this.GlNum.Text, "','", this.ViewState["UpNodeNum"], "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", this.ZbUsername.Text, "','", this.ZbRealname.Text, "','", DateTime.Now.ToString(), "','','未接收','主办')" });
                this.List.ExeSql(str11);
            }
            string str12 = null;
            string str13 = null;
            if (this.ZbUsername.Text != "")
            {
                str13 = "" + this.JbUsername.Text.Replace("" + this.ZbUsername.Text + ",", "") + "";
            }
            else
            {
                str13 = "" + this.JbUsername.Text + "";
            }
            ArrayList list2 = new ArrayList();
            string[] strArray2 = str13.Split(new char[] { ',' });
            for (num = 0; num < strArray2.Length; num++)
            {
                str12 = str12 + "'" + strArray2[num] + "',";
            }
            str12 = str12 + "'0'";
            string str14 = "select username,realname from qp_oa_Username where  username in (" + str12 + ") ";
            SqlDataReader reader4 = this.List.GetList(str14);
            while (reader4.Read())
            {
                str15 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", this.GlNum.Text, "','", this.ViewState["UpNodeNum"], "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", reader4["username"], "','", reader4["realname"], "','", DateTime.Now.ToString(), "','','未接收','经办')" });
                this.List.ExeSql(str15);
            }
            reader4.Close();
            this.showform.AddWorkFlowLog("110", base.Request.QueryString["Number"].ToString(), this.ViewState["FormName"].ToString(), "自由流程", "转交工作" + this.ViewState["Name"] + "", this.ViewState["IfZb"].ToString());
            string str16 = "select A.id as Aid,A.GlNum,A.IfZb,A.LcNum,A.KeyFile,A.XuHao,A.KeyFile,A.BLusername,A.BLrealname,B.* from [qp_oa_AddWorkFlowPicRy] as [A] inner join [qp_oa_MyWeituo] as [B] on [A].[BLusername] = [B].Username and [B].[States] = '1' and [A].KeyFile='" + base.Request.QueryString["Number"] + "' and [A].GlNum='" + this.GlNum.Text + "' ";
            SqlDataReader reader5 = this.List.GetList(str16);
            while (reader5.Read())
            {
                string str17 = "select id,Number,UpNodeNum,UpNodeName,FormName,Name,JbObjectId,JbObjectName from qp_oa_AddWorkFlow where Number='" + reader5["KeyFile"] + "'";
                SqlDataReader reader6 = this.List.GetList(str17);
                if (reader6.Read())
                {
                    string str18;
                    string str19;
                    string str20;
                    if (reader5["IfZb"].ToString() == "主办")
                    {
                        str18 = "" + reader6["JbObjectId"].ToString().Replace("" + reader5["BLusername"].ToString() + ",", "" + reader5["WtUsername"].ToString() + ",") + "";
                        str19 = "" + reader6["JbObjectName"].ToString().Replace("" + reader5["BLrealname"].ToString() + ",", "" + reader5["WtRealname"].ToString() + ",") + "";
                        str20 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set ZbObjectId='", reader5["WtUsername"], "',ZbObjectName='", reader5["WtRealname"], "',JbObjectId='", str18, "',JbObjectName='", str19, "'  where id='", reader6["id"].ToString(), "'" });
                        this.List.ExeSql(str20);
                    }
                    else
                    {
                        str18 = "" + reader6["JbObjectId"].ToString().Replace("" + reader5["BLusername"].ToString() + ",", "" + reader5["WtUsername"].ToString() + ",") + "";
                        str19 = "" + reader6["JbObjectName"].ToString().Replace("" + reader5["BLrealname"].ToString() + ",", "" + reader5["WtRealname"].ToString() + ",") + "";
                        str20 = "Update qp_oa_AddWorkFlow  Set JbObjectId='" + str18 + "',JbObjectName='" + str19 + "'  where id='" + reader6["id"].ToString() + "'";
                        this.List.ExeSql(str20);
                    }
                }
                reader6.Close();
                if (this.C1.Checked)
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "", this.txtSmsContent.Text, "，转交人：", this.Session["realname"], "" }), reader5["WtUsername"].ToString(), reader5["WtRealname"].ToString(), "/WorkFlow/WorkFlowList.aspx");
                }
                if (this.C2.Checked)
                {
                    string str21 = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + reader5["WtUsername"].ToString() + "' ";
                    SqlDataReader reader7 = this.List.GetList(str21);
                    if (reader7.Read())
                    {
                        this.pulicss.InsertSms(reader7["MoveTel"].ToString(), string.Concat(new object[] { "", this.txtSmsContent.Text, "，转交人：", this.Session["realname"], "" }));
                    }
                    reader7.Close();
                }
                string str22 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已委托',EndTime='", DateTime.Now.ToString(), "',WtUsername='", reader5["WtUsername"], "',WtRealname='", reader5["WtRealname"], "'   where id='", reader5["Aid"], "' " });
                this.List.ExeSql(str22);
                str15 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", reader5["GlNum"], "','", reader5["XuHao"], "','", reader5["LcNum"], "','", reader5["KeyFile"], "','", reader5["WtUsername"], "','", reader5["WtRealname"], "','", DateTime.Now.ToString(), "','','未接收','", reader5["IfZb"], 
                    "')"
                 });
                this.List.ExeSql(str15);
            }
            reader5.Close();
            string str23 = "select * from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["id"] + "'";
            SqlDataReader reader8 = this.List.GetList(str23);
            if (reader8.Read())
            {
                string str24 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowGc (JinJiChengDu,Shuxing,UpNodeName,Keyid,FormId,FormName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,Username,Realname,NowTimes) values ('", reader8["JinJiChengDu"], "','", reader8["Shuxing"], "','自由流程','", reader8["id"], "','", reader8["FormId"], "','", reader8["FormName"], "','", reader8["Number"], "','", reader8["Sequence"], "','", reader8["Name"], 
                    "','", reader8["FileContent"], "','", reader8["FqUsername"], "','", reader8["FqRealname"], "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str24);
            }
            reader8.Close();
            base.Response.Write("<script language=javascript>alert('转交成功！');window.opener.location.href='WorkFlowList.aspx';window.close();</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlowListSp_zy.aspx?id=" + base.Request.QueryString["id"] + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "");
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            if (this.C3.Checked)
            {
                this.pulicss.InsertMessage("您发起的工作[" + this.ViewState["Name"] + "]已结束归档", this.ViewState["FqUsername"].ToString(), this.ViewState["FqRealname"].ToString(), "#");
            }
            if (this.C4.Checked)
            {
                string str = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + this.ViewState["FqUsername"].ToString() + "' ";
                SqlDataReader reader = this.List.GetList(str);
                if (reader.Read())
                {
                    this.pulicss.InsertSms(reader["MoveTel"].ToString(), "您发起的工作[" + this.ViewState["Name"] + "]已结束归档");
                }
                reader.Close();
            }
            string sql = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set GlNum='", this.GlNum.Text, "',UpNodeNum='", this.ViewState["UpNodeNum"], "',State='正常结束',ZbObjectId='", this.ZbUsername.Text, "',ZbObjectName='", this.ZbRealname.Text, "',UpTimeSet='", DateTime.Now.ToString(), "'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'" });
            this.List.ExeSql(sql);
            string str3 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已办结' ,EndTime='", DateTime.Now.ToString(), "'  where KeyFile='", this.ViewState["WfNumber"], "' and BLusername='", this.Session["username"], "' and XuHao='", this.ViewState["UpNodeNum"], "' and GlNum='", this.GlNum1.Text, "' and States!='已委托'" });
            this.List.ExeSql(str3);
            string str4 = "Update qp_oa_AddWorkFlowPicRy  Set States='已办结'   where KeyFile='" + base.Request.QueryString["Number"] + "' and States!='已委托'";
            this.List.ExeSql(str4);
            string str5 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlow where (CHARINDEX(',", this.Session["username"], ",',','+YJBObjectId+',')   >   0 ) and Number='", base.Request.QueryString["Number"], "'" });
            SqlDataReader list = this.List.GetList(str5);
            if (!list.Read())
            {
                string str6 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set YJBObjectId=YJBObjectId+'", this.Session["username"], ",',YJBObjecName=YJBObjecName+'", this.Session["realname"], ",'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'" });
                this.List.ExeSql(str6);
            }
            list.Close();
            string str7 = "select * from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["id"] + "'";
            SqlDataReader reader3 = this.List.GetList(str7);
            if (reader3.Read())
            {
                string str8 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowGd (JinJiChengDu,Keyid,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,YJBObjectId,YJBObjecName,Username,Realname,NowTimes,Shuxing,GdId) values ('", reader3["JinJiChengDu"], "','", reader3["id"], "','", reader3["FormId"], "','", reader3["FormNumber"], "','", reader3["FormName"], "','", reader3["FlowId"], "','", reader3["FlowNumber"], "','", reader3["FlowName"], 
                    "','", reader3["Number"], "','", reader3["Sequence"], "','", reader3["Name"], "','", reader3["FileContent"], "','", reader3["FqUsername"], "','", reader3["FqRealname"], "','", reader3["YJBObjectId"], "','", reader3["YJBObjecName"], 
                    "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "','", reader3["Shuxing"], "','", this.ViewState["OverSetConId"], "')"
                 });
                this.List.ExeSql(str8);
            }
            reader3.Close();
            string str9 = "select * from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["id"] + "'";
            SqlDataReader reader4 = this.List.GetList(str9);
            if (reader4.Read())
            {
                string str10 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowGc (JinJiChengDu,Shuxing,UpNodeName,Keyid,FormId,FormName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,Username,Realname,NowTimes) values ('", reader4["JinJiChengDu"], "','", reader4["Shuxing"], "','自由流程','", reader4["id"], "','", reader4["FormId"], "','", reader4["FormName"], "','", reader4["Number"], "','", reader4["Sequence"], "','", reader4["Name"], 
                    "','", reader4["FileContent"], "','", reader4["FqUsername"], "','", reader4["FqRealname"], "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str10);
            }
            reader4.Close();
            this.showform.AddWorkFlowLog("110", base.Request.QueryString["Number"].ToString(), this.ViewState["FormName"].ToString(), "自由流程", "结束工作" + this.ViewState["Name"] + "", this.ViewState["IfZb"].ToString());
            base.Response.Write("<script language=javascript>alert('结束成功！');window.opener.location.href='WorkFlowList.aspx';window.close();</script>");
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
                    this.ViewState["WfNumber"] = list["Number"].ToString();
                    this.ViewState["FormName"] = list["FormName"].ToString();
                    this.ViewState["Sequence"] = list["Sequence"].ToString();
                    this.ViewState["Name"] = list["Name"].ToString();
                    this.ViewState["NodeName"] = list["NodeName"].ToString();
                    this.txtSmsContent.Text = "工作流转交提醒：" + list["Name"].ToString() + "";
                    this.ViewState["FqUsername"] = list["FqUsername"].ToString();
                    this.ViewState["FqRealname"] = list["FqRealname"].ToString();
                    this.ViewState["UpNodeNum"] = int.Parse(list["UpNodeNum"].ToString()) + 1;
                    this.ViewState["JinJiChengDu"] = list["JinJiChengDu"].ToString();
                    this.GlNum1.Text = list["GlNum"].ToString();
                    string str3 = "select OverSetConId from qp_oa_WorkFlowName where  id='" + list["FlowId"].ToString() + "'";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    if (reader2.Read())
                    {
                        this.ViewState["OverSetConId"] = reader2["OverSetConId"].ToString();
                    }
                    reader2.Close();
                    string str4 = string.Concat(new object[] { "select  IfZb from qp_oa_AddWorkFlowPicRy  where  KeyFile='", base.Request.QueryString["Number"], "' and xuhao='", list["UpNodeNum"].ToString(), "' and BLusername='", this.Session["username"], "' and GlNum='", this.GlNum1.Text, "' " });
                    SqlDataReader reader3 = this.List.GetList(str4);
                    if (reader3.Read())
                    {
                        this.ViewState["IfZb"] = reader3["IfZb"].ToString();
                    }
                    reader3.Close();
                }
                list.Close();
                this.BindDroList();
            }
        }
    }
}

