namespace xyoa.pda.WorkFlow
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
        protected Button Button5;
        protected CheckBox C1;
        protected CheckBox C2;
        protected CheckBox C3;
        protected CheckBox C4;
        protected CheckBox CheckBox1;
        protected HtmlForm form1;
        protected TextBox GlNum;
        protected TextBox GlNum1;
        protected HtmlHead Head1;
        protected ImageButton ImageButton4;
        protected HtmlImage IMG1;
        protected HtmlImage IMG2;
        protected TextBox JbGuanlianID;
        protected TextBox JbGuanlianName;
        protected TextBox JbRealname;
        protected TextBox JbUsername;
        protected DropDownList JcZhuanjiao;
        protected Label Label1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        protected TextBox OpenBack;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox txtSmsContent;
        protected TextBox ZbGuanlianID;
        protected TextBox ZbGuanlianName;
        protected TextBox ZbRealname;
        protected TextBox ZbUsername;
        protected TextBox ZbUsername6;
        protected DropDownList ZbZhuanjiao;

        protected void Button1_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlowListAll.aspx");
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
            this.showform.AddWorkFlowLog("110", base.Request.QueryString["Number"].ToString(), this.ViewState["FormNames"].ToString(), "自由流程", "结束工作" + this.ViewState["Name"] + "", this.ViewState["IfZb"].ToString());
            base.Response.Write("<script language=javascript>alert('结束成功！');window.location.href='WorkFlowListAll.aspx'</script>");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if (this.JbUsername.Text.Trim() == "")
            {
                this.Label1.Text = "经办人为空，转交失败";
            }
            else
            {
                int num;
                string str15;
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
                        this.pulicss.InsertMessage(string.Concat(new object[] { "", this.txtSmsContent.Text, "，转交人：", this.Session["realname"], "" }), reader["username"].ToString(), reader["realname"].ToString(), "/WorkFlow/WorkFlowList.aspx");
                    }
                    if (this.C2.Checked)
                    {
                        this.pulicss.InsertSms(reader["MoveTel"].ToString(), string.Concat(new object[] { "", this.txtSmsContent.Text, "，转交人：", this.Session["realname"], "" }));
                    }
                }
                reader.Close();
                if (this.C3.Checked)
                {
                    this.pulicss.InsertMessage(string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已转交到：", this.ZbRealname.Text, "" }), this.ViewState["FqUsername"].ToString(), this.ViewState["FqRealname"].ToString(), "#");
                }
                if (this.C4.Checked)
                {
                    string str5 = "select username,realname,Email,MoveTel from qp_oa_Username where  username='" + this.ViewState["FqUsername"].ToString() + "' ";
                    SqlDataReader reader2 = this.List.GetList(str5);
                    if (reader2.Read())
                    {
                        this.pulicss.InsertSms(reader2["MoveTel"].ToString(), string.Concat(new object[] { "您发起的工作[", this.ViewState["Name"], "]已转交到：", this.ZbRealname.Text, "" }));
                    }
                    reader2.Close();
                }
                string str6 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlow where (CHARINDEX(',", this.Session["username"], ",',','+YJBObjectId+',')   >   0 ) and Number='", base.Request.QueryString["Number"], "'" });
                SqlDataReader reader3 = this.List.GetList(str6);
                if (!reader3.Read())
                {
                    string str7 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set YJBObjectId=YJBObjectId+'", this.Session["username"], ",',YJBObjecName=YJBObjecName+'", this.Session["realname"], ",'  where Number='", this.pulicss.GetFormatStr(base.Request.QueryString["Number"]), "'" });
                    this.List.ExeSql(str7);
                }
                reader3.Close();
                string str8 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPic (GlNum,LcNum,KeyFile,XuHao,Jiedian) values ('", this.GlNum.Text, "','", this.Number.Text, "','", base.Request.QueryString["Number"], "','", this.ViewState["UpNodeNum"], "','')" });
                this.List.ExeSql(str8);
                string str9 = "Update qp_oa_AddWorkFlowPicRy  Set States='已办结'   where KeyFile='" + base.Request.QueryString["Number"] + "' and States!='已委托'";
                this.List.ExeSql(str9);
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
                this.showform.AddWorkFlowLog("110", base.Request.QueryString["Number"].ToString(), this.ViewState["FormNames"].ToString(), "自由流程", "转交工作" + this.ViewState["Name"] + "", this.ViewState["IfZb"].ToString());
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
                    string str21 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已委托',EndTime='", DateTime.Now.ToString(), "',WtUsername='", reader5["WtUsername"], "',WtRealname='", reader5["WtRealname"], "'   where id='", reader5["Aid"], "' " });
                    this.List.ExeSql(str21);
                    str15 = string.Concat(new object[] { 
                        "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", reader5["GlNum"], "','", reader5["XuHao"], "','", reader5["LcNum"], "','", reader5["KeyFile"], "','", reader5["WtUsername"], "','", reader5["WtRealname"], "','", DateTime.Now.ToString(), "','','未接收','", reader5["IfZb"], 
                        "')"
                     });
                    this.List.ExeSql(str15);
                }
                reader5.Close();
                string str22 = "select * from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["id"] + "'";
                SqlDataReader reader7 = this.List.GetList(str22);
                if (reader7.Read())
                {
                    string str23 = string.Concat(new object[] { 
                        "insert into qp_oa_AddWorkFlowGc (JinJiChengDu,Shuxing,UpNodeName,Keyid,FormId,FormName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,Username,Realname,NowTimes) values ('", reader7["JinJiChengDu"], "','", reader7["Shuxing"], "','自由流程','", reader7["id"], "','", reader7["FormId"], "','", reader7["FormName"], "','", reader7["Number"], "','", reader7["Sequence"], "','", reader7["Name"], 
                        "','", reader7["FileContent"], "','", reader7["FqUsername"], "','", reader7["FqRealname"], "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "')"
                     });
                    this.List.ExeSql(str23);
                }
                reader7.Close();
                base.Response.Write("<script language=javascript>alert('转交成功！');window.location.href='WorkFlowListAll.aspx'</script>");
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
                this.JbRealname.Attributes.Add("readonly", "readonly");
                this.ZbRealname.Attributes.Add("readonly", "readonly");
                this.Button1.Attributes["onclick"] = "javascript:return LoadingShow();";
                this.ViewState["footulr"] = this.pulicss.pdafoot("" + base.Request.Url.AbsoluteUri + "");
                this.ViewState["pdauer"] = this.pulicss.pdauser();
                Random random = new Random();
                string str = random.Next(0x2710).ToString();
                this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                this.GlNum.Text = "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
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
                    this.GlNum1.Text = list["GlNum"].ToString();
                    this.ViewState["WfNumber"] = list["Number"].ToString();
                    string str3 = "select OverSetConId from qp_oa_WorkFlowName where  id='" + list["FlowId"].ToString() + "'";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    if (reader2.Read())
                    {
                        this.ViewState["OverSetConId"] = reader2["OverSetConId"].ToString();
                    }
                    reader2.Close();
                }
                list.Close();
                string str4 = string.Concat(new object[] { "select  IfZb from qp_oa_AddWorkFlowPicRy  where  KeyFile='", base.Request.QueryString["Number"], "' and xuhao='", this.ViewState["UpNodeNum"], "' and BLusername='", this.Session["username"], "' and GlNum='", this.GlNum1.Text, "' " });
                SqlDataReader reader3 = this.List.GetList(str4);
                if (reader3.Read())
                {
                    this.ViewState["IfZb"] = reader3["IfZb"].ToString();
                }
                reader3.Close();
            }
        }
    }
}

