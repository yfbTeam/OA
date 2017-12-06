namespace xyoa.WorkFlow
{
    using Ajax;
    using MSScriptControl;
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using xyoa;

    public class WorkFlowListSp : Page
    {
        protected Button BaoCun;
        protected Button Button1;
        protected HtmlInputButton Button10;
        protected HtmlInputButton Button14;
        protected Button Button15;
        protected HtmlInputButton Button16;
        protected Button Button17;
        protected HtmlInputButton Button18;
        protected HtmlInputButton Button2;
        protected Button Button3;
        protected Button Button4;
        protected HtmlInputButton Button5;
        protected Button Button6;
        protected HtmlInputButton Button7;
        protected HtmlInputButton Button9;
        protected CheckBox CheckBox1;
        protected TextBox ContractContent;
        protected HtmlInputFile File1;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected RadioButtonList fujian;
        protected TextBox GlNum;
        protected TextBox GqUpNodeNumKey;
        protected GridView GridView1;
        protected HtmlHead Head1;
        protected Button HuiTui;
        protected Label JinJiChengDu;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList normalcontent;
        protected TextBox Number;
        protected Panel Panel1;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox SpContent;
        protected TextBox TextBox1;
        protected HtmlInputFile uploadFile;
        protected Button Wanbi;
        protected TextBox wdname;
        protected TextBox whname;
        protected Label whname1;
        protected DropDownList Yinzhang;

        protected void BaoCun_Click(object sender, EventArgs e)
        {
            string str11;
            string str = "";
            if (this.Yinzhang.SelectedValue != "请选择")
            {
                str = "<img src=\"/seal/" + this.Yinzhang.SelectedValue + "\" width=\"140px\" height=\"100px\"  hspace=\"10\">";
                string str2 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowSeal (YzNum,MkName,Number,Name,Newname,Username,Realname,IpAddress,Settime) values ('", this.Number.Text, "','", this.ViewState["NodeName"], "','", this.ViewState["YzSealNumber"], "','", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.Page.Request.UserHostAddress, 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str2);
                string str3 = string.Concat(new object[] { "insert into qp_oa_SealUseLog (Name,Newname,Username,Realname,MkName,Usetime,Ip) values ('", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.ViewState["NodeName"], "','", DateTime.Now.ToString(), "','", this.Page.Request.UserHostAddress, "')" });
                this.List.ExeSql(str3);
            }
            string str4 = base.Server.MapPath("file/");
            string str5 = string.Empty;
            string str6 = string.Empty;
            if (this.File1.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.File1.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str9 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                if (!this.pulicss.scquanstr(extension, str9))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                Random random = new Random();
                string str10 = random.Next(0x2710).ToString();
                str6 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str10;
                this.File1.PostedFile.SaveAs(str4 + str6 + extension);
                str5 = str6 + extension;
                str11 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", str, "", this.SpContent.Text, "','", fileName, "','", str5, 
                    "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if ((this.SpContent.Text != "") || (this.Yinzhang.SelectedValue != "请选择"))
            {
                str11 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", str, "", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
            }
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_AddWorkFlowYbl (NodeName,Number,Sequence,Name,FileContent,Username,Realname,Nowtimes) values ('", this.ViewState["NodeName"].ToString(), "','", this.Number.Text, "','", int.Parse(this.ViewState["lshid"].ToString()), "','", this.whname.Text, "','", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                "')"
             });
            this.List.ExeSql(sql);
            string str13 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  Name='", this.whname.Text, "',State='正在办理', FileContent='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(str13);
            this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), this.ViewState["NodeName"].ToString(), "保存工作" + this.whname.Text + "", this.ViewState["IfZb"].ToString());
            string str14 = "select  * from qp_oa_FormFile where id  in (" + this.ViewState["WriteFileID"] + ") and (type='[常规型]' or type='[数字型]')   order by id asc";
            SqlDataReader list = this.List.GetList(str14);
            while (list.Read())
            {
                string str15 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowFileKey  Set  Content='", base.Request.Form["" + list["Number"] + ""], "'  where AddNumber='", this.Number.Text, "' and Number='", list["Number"], "'" });
                this.List.ExeSql(str15);
            }
            list.Close();
            string str16 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='办理中',EndTime='' where KeyFile='", this.Number.Text, "' and BLusername='", this.Session["username"], "' and XuHao='", this.ViewState["UpNodeNums"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
            this.List.ExeSql(str16);
            base.Response.Write("<script language=javascript>alert('保存成功！');window.opener.location.href='WorkFlowList_blz.aspx';window.close();</script>");
        }

        public void BindAttribute()
        {
            this.Button6.Attributes["onclick"] = "javascript:return AddFile();";
            this.Wanbi.Attributes["onclick"] = "javascript:return ConFile();";
            this.BaoCun.Attributes["onclick"] = "javascript:return ConFile();";
            this.HuiTui.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return ConFile();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button17.Attributes["onclick"] = "javascript:return openfile();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str11;
            string str = "";
            if (this.Yinzhang.SelectedValue != "请选择")
            {
                str = "<img src=\"/seal/" + this.Yinzhang.SelectedValue + "\" width=\"140px\" height=\"100px\"  hspace=\"10\">";
                string sql = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowSeal (YzNum,MkName,Number,Name,Newname,Username,Realname,IpAddress,Settime) values ('", this.Number.Text, "','", this.ViewState["NodeName"], "','", this.ViewState["YzSealNumber"], "','", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.Page.Request.UserHostAddress, 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(sql);
                string str3 = string.Concat(new object[] { "insert into qp_oa_SealUseLog (Name,Newname,Username,Realname,MkName,Usetime,Ip) values ('", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.ViewState["NodeName"], "','", DateTime.Now.ToString(), "','", this.Page.Request.UserHostAddress, "')" });
                this.List.ExeSql(str3);
            }
            string str4 = base.Server.MapPath("file/");
            string str5 = string.Empty;
            string str6 = string.Empty;
            if (this.File1.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.File1.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str9 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                if (!this.pulicss.scquanstr(extension, str9))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                Random random = new Random();
                string str10 = random.Next(0x2710).ToString();
                str6 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str10;
                this.File1.PostedFile.SaveAs(str4 + str6 + extension);
                str5 = str6 + extension;
                str11 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", str, "", this.SpContent.Text, "','", fileName, "','", str5, 
                    "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if ((this.SpContent.Text != "") || (this.Yinzhang.SelectedValue != "请选择"))
            {
                str11 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", str, "", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
            }
            try
            {
                string str12 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowYbl (NodeName,Number,Sequence,Name,FileContent,Username,Realname,Nowtimes) values ('", this.ViewState["NodeName"].ToString(), "','", this.Number.Text, "','", int.Parse(this.ViewState["lshid"].ToString()), "','", this.whname.Text, "','", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                    "')"
                 });
                this.List.ExeSql(str12);
                string str13 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  Name='", this.whname.Text, "',State='正在办理', FileContent='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str13);
                this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), this.ViewState["NodeName"].ToString(), "办理工作" + this.whname.Text + "", this.ViewState["IfZb"].ToString());
                string str14 = "select  * from qp_oa_FormFile where id  in (" + this.ViewState["WriteFileID"] + ") and (type='[常规型]' or type='[数字型]')   order by id asc";
                SqlDataReader reader = this.List.GetList(str14);
                while (reader.Read())
                {
                    string str15 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowFileKey  Set  Content='", base.Request.Form["" + reader["Number"] + ""], "'  where AddNumber='", this.Number.Text, "' and Number='", reader["Number"], "'" });
                    this.List.ExeSql(str15);
                }
                reader.Close();
                string str19 = null;
                str19 = "" + this.ViewState["UpNodeNum"] + "0";
                ArrayList list = new ArrayList();
                string[] strArray = str19.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    object obj2;
                    string str17 = null;
                    string str16 = null;
                    string expression = null;
                    string str20 = string.Concat(new object[] { "select * from qp_oa_FlowFormFile where KeyID=(select id from qp_oa_WorkFlowNode where NodeNum='", strArray[i], "' and FlowNumber='", base.Request.QueryString["FlowNumber"], "') and NodeId='", this.ViewState["NodeId"], "' and  Type='[常规型]'" });
                    SqlDataReader reader2 = this.List.GetList(str20);
                    while (reader2.Read())
                    {
                        string str21;
                        SqlDataReader reader3;
                        if (reader2["Conditions"].ToString() == "包含")
                        {
                            str21 = string.Concat(new object[] { "select  * from qp_oa_AddWorkFlowFileKey where AddNumber='", this.Number.Text, "' and Number='", reader2["Number"], "'  order by id asc" });
                            reader3 = this.List.GetList(str21);
                            if (reader3.Read())
                            {
                                obj2 = str17;
                                str17 = string.Concat(new object[] { obj2, "", reader3["Content"].ToString().IndexOf(reader2["JudgeBasis"].ToString()), ">= 0", reader2["JudgeType"].ToString(), "" });
                            }
                            reader3.Close();
                        }
                        else if (reader2["Conditions"].ToString() == "不包含")
                        {
                            str21 = string.Concat(new object[] { "select  * from qp_oa_AddWorkFlowFileKey where AddNumber='", this.Number.Text, "' and Number='", reader2["Number"], "'  order by id asc" });
                            reader3 = this.List.GetList(str21);
                            if (reader3.Read())
                            {
                                obj2 = str17;
                                str17 = string.Concat(new object[] { obj2, "", reader3["Content"].ToString().IndexOf(reader2["JudgeBasis"].ToString()), "< 0", reader2["JudgeType"].ToString(), "" });
                            }
                            reader3.Close();
                        }
                    }
                    reader2.Close();
                    string str22 = string.Concat(new object[] { "select * from qp_oa_FlowFormFile where  KeyID=(select id from qp_oa_WorkFlowNode where NodeNum='", strArray[i], "' and FlowNumber='", base.Request.QueryString["FlowNumber"], "') and  NodeId='", this.ViewState["NodeId"], "' and  Type='[数字型]'" });
                    SqlDataReader reader4 = this.List.GetList(str22);
                    while (reader4.Read())
                    {
                        try
                        {
                            string str23 = string.Concat(new object[] { "select  * from qp_oa_AddWorkFlowFileKey where AddNumber='", this.Number.Text, "' and Number='", reader4["Number"], "'  order by id asc" });
                            base.Response.Write("" + str23 + "<br>");
                            SqlDataReader reader5 = this.List.GetList(str23);
                            if (reader5.Read())
                            {
                                obj2 = str16;
                                str16 = string.Concat(new object[] { obj2, "", decimal.Parse(reader5["Content"].ToString()), " ", reader4["Conditions"], " ", reader4["JudgeBasis"], "", reader4["JudgeType"].ToString(), "" });
                            }
                            reader5.Close();
                        }
                        catch
                        {
                        }
                    }
                    reader4.Close();
                    expression = str17 + str16;
                    if ((((expression != "") && (expression != " ")) && (expression != "  ")) && (expression != null))
                    {
                        ScriptControl control = new ScriptControlClass();
                        control.Language = "javascript";
                        if (!((bool) control.Eval(expression)))
                        {
                            this.ViewState["UpNodeNumKey"] = this.ViewState["UpNodeNumKey"].ToString().Replace("" + strArray[i] + ",", "");
                            this.GqUpNodeNumKey.Text = this.GqUpNodeNumKey.Text.Replace("" + strArray[i] + ",", "");
                        }
                    }
                }
                string str24 = "select * from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["id"] + "'";
                SqlDataReader reader6 = this.List.GetList(str24);
                if (reader6.Read())
                {
                    string str25 = string.Concat(new object[] { "select id from qp_oa_AddWorkFlowGc where Keyid='", reader6["id"], "' and GlNum='", reader6["GlNum"], "' and username='", this.Session["username"], "'" });
                    SqlDataReader reader7 = this.List.GetList(str25);
                    if (reader7.Read())
                    {
                        string str26 = string.Concat(new object[] { 
                            "Update qp_oa_AddWorkFlowGc  Set JinJiChengDu='", reader6["JinJiChengDu"], "',Shuxing='", reader6["Shuxing"], "',UpNodeName='", reader6["UpNodeName"], "',NowTimes='", DateTime.Now.ToString(), "',FormName='", reader6["FormName"], "',Number='", reader6["Number"], "',Sequence='", reader6["Sequence"], "',Name='", reader6["Name"], 
                            "',FileContent='", reader6["FileContent"], "'  where Keyid='", reader6["id"], "' and GlNum='", reader6["GlNum"], "' and username='", this.Session["username"], "'"
                         });
                        this.List.ExeSql(str26);
                    }
                    else
                    {
                        string str27 = string.Concat(new object[] { 
                            "insert into qp_oa_AddWorkFlowGc (GlNum,JinJiChengDu,Shuxing,UpNodeName,Keyid,FormId,FormName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,Username,Realname,NowTimes) values ('", reader6["GlNum"], "','", reader6["JinJiChengDu"], "','", reader6["Shuxing"], "','", reader6["UpNodeName"], "','", reader6["id"], "','", reader6["FormId"], "','", reader6["FormName"], "','", reader6["Number"], 
                            "','", reader6["Sequence"], "','", reader6["Name"], "','", reader6["FileContent"], "','", reader6["FqUsername"], "','", reader6["FqRealname"], "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                            "')"
                         });
                        this.List.ExeSql(str27);
                    }
                    reader7.Close();
                }
                reader6.Close();
                if (this.ViewState["NodeSite"].ToString() == "结束")
                {
                    base.Response.Redirect("WorkFlowListSp_NextJs.aspx?tmp=" + base.Request.QueryString["tmp"] + "&UpNodeNum=" + this.GqUpNodeNumKey.Text + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "&id=" + base.Request.QueryString["id"] + "&Number=" + this.Number.Text + "");
                }
                else
                {
                    base.Response.Redirect("WorkFlowListSp_Next.aspx?tmp=" + base.Request.QueryString["tmp"] + "&UpNodeNum=" + this.GqUpNodeNumKey.Text + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "&id=" + base.Request.QueryString["id"] + "&Number=" + this.Number.Text + "");
                }
            }
            catch
            {
                base.Response.Write("<script language=javascript>alert('保存失败，请检查是否有必填项未填写或字段设置错误！');</script>");
            }
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            string str11;
            string str = "";
            if (this.Yinzhang.SelectedValue != "请选择")
            {
                str = "<img src=\"/seal/" + this.Yinzhang.SelectedValue + "\" width=\"140px\" height=\"100px\"  hspace=\"10\">";
                string sql = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowSeal (YzNum,MkName,Number,Name,Newname,Username,Realname,IpAddress,Settime) values ('", this.Number.Text, "','", this.ViewState["NodeName"], "','", this.ViewState["YzSealNumber"], "','", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.Page.Request.UserHostAddress, 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(sql);
                string str3 = string.Concat(new object[] { "insert into qp_oa_SealUseLog (Name,Newname,Username,Realname,MkName,Usetime,Ip) values ('", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.ViewState["NodeName"], "','", DateTime.Now.ToString(), "','", this.Page.Request.UserHostAddress, "')" });
                this.List.ExeSql(str3);
            }
            string str4 = base.Server.MapPath("file/");
            string str5 = string.Empty;
            string str6 = string.Empty;
            if (this.File1.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.File1.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str9 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                if (!this.pulicss.scquanstr(extension, str9))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                Random random = new Random();
                string str10 = random.Next(0x2710).ToString();
                str6 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str10;
                this.File1.PostedFile.SaveAs(str4 + str6 + extension);
                str5 = str6 + extension;
                str11 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", str, "", this.SpContent.Text, "','", fileName, "','", str5, 
                    "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if (this.SpContent.Text != "")
            {
                str11 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", str, "", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
            }
            try
            {
                string str12 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowYbl (NodeName,Number,Sequence,Name,FileContent,Username,Realname,Nowtimes) values ('", this.ViewState["NodeName"].ToString(), "','", this.Number.Text, "','", int.Parse(this.ViewState["lshid"].ToString()), "','", this.whname.Text, "','", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                    "')"
                 });
                this.List.ExeSql(str12);
                string str13 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  Name='", this.whname.Text, "',State='正在办理', FileContent='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str13);
                this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), this.ViewState["NodeName"].ToString(), "办理完毕工作" + this.whname.Text + "", this.ViewState["IfZb"].ToString());
                string str14 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已办结',EndTime='", DateTime.Now.ToString(), "'   where KeyFile='", this.Number.Text, "' and BLusername='", this.Session["username"], "' and XuHao='", this.ViewState["UpNodeNums"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
                this.List.ExeSql(str14);
                string str15 = "select  * from qp_oa_FormFile where id  in (" + this.ViewState["WriteFileID"] + ") and (type='[常规型]' or type='[数字型]')   order by id asc";
                SqlDataReader list = this.List.GetList(str15);
                while (list.Read())
                {
                    string str16 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowFileKey  Set  Content='", base.Request.Form["" + list["Number"] + ""], "'  where AddNumber='", this.Number.Text, "' and Number='", list["Number"], "'" });
                    this.List.ExeSql(str16);
                }
                list.Close();
                string str17 = "select * from qp_oa_AddWorkFlow where id='" + base.Request.QueryString["id"] + "'";
                SqlDataReader reader2 = this.List.GetList(str17);
                if (reader2.Read())
                {
                    string str18 = string.Concat(new object[] { "select id from qp_oa_AddWorkFlowGc where Keyid='", reader2["id"], "' and GlNum='", reader2["GlNum"], "' and username='", this.Session["username"], "'" });
                    SqlDataReader reader3 = this.List.GetList(str18);
                    if (reader3.Read())
                    {
                        string str19 = string.Concat(new object[] { 
                            "Update qp_oa_AddWorkFlowGc  Set JinJiChengDu='", reader2["JinJiChengDu"], "',Shuxing='", reader2["Shuxing"], "',UpNodeName='", reader2["UpNodeName"], "',NowTimes='", DateTime.Now.ToString(), "',FormName='", reader2["FormName"], "',Number='", reader2["Number"], "',Sequence='", reader2["Sequence"], "',Name='", reader2["Name"], 
                            "',FileContent='", reader2["FileContent"], "'  where Keyid='", reader2["id"], "' and GlNum='", reader2["GlNum"], "' and username='", this.Session["username"], "'"
                         });
                        this.List.ExeSql(str19);
                    }
                    else
                    {
                        string str20 = string.Concat(new object[] { 
                            "insert into qp_oa_AddWorkFlowGc (GlNum,JinJiChengDu,Shuxing,UpNodeName,Keyid,FormId,FormName,Number,Sequence,Name,FileContent,FqUsername,FqRealname,Username,Realname,NowTimes) values ('", reader2["GlNum"], "','", reader2["JinJiChengDu"], "','", reader2["Shuxing"], "','", reader2["UpNodeName"], "','", reader2["id"], "','", reader2["FormId"], "','", reader2["FormName"], "','", reader2["Number"], 
                            "','", reader2["Sequence"], "','", reader2["Name"], "','", reader2["FileContent"], "','", reader2["FqUsername"], "','", reader2["FqRealname"], "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                            "')"
                         });
                        this.List.ExeSql(str20);
                    }
                    reader3.Close();
                }
                reader2.Close();
                base.Response.Write("<script language=javascript>alert('办理完毕！');window.opener.location.href='WorkFlowList_ybj.aspx';window.close();</script>");
            }
            catch
            {
                base.Response.Write("<script language=javascript>alert('保存失败，请检查是否有必填项未填写或字段设置错误！');</script>");
            }
        }

        protected void Button15_Click1(object sender, EventArgs e)
        {
            string str11;
            string str = "";
            if (this.Yinzhang.SelectedValue != "请选择")
            {
                str = "<img src=\"/seal/" + this.Yinzhang.SelectedValue + "\" width=\"140px\" height=\"100px\"  hspace=\"10\">";
                string sql = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowSeal (YzNum,MkName,Number,Name,Newname,Username,Realname,IpAddress,Settime) values ('", this.Number.Text, "','", this.ViewState["NodeName"], "','", this.ViewState["YzSealNumber"], "','", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.Page.Request.UserHostAddress, 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(sql);
                string str3 = string.Concat(new object[] { "insert into qp_oa_SealUseLog (Name,Newname,Username,Realname,MkName,Usetime,Ip) values ('", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.ViewState["NodeName"], "','", DateTime.Now.ToString(), "','", this.Page.Request.UserHostAddress, "')" });
                this.List.ExeSql(str3);
            }
            string str4 = base.Server.MapPath("file/");
            string str5 = string.Empty;
            string str6 = string.Empty;
            if (this.File1.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.File1.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str9 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                if (!this.pulicss.scquanstr(extension, str9))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                Random random = new Random();
                string str10 = random.Next(0x2710).ToString();
                str6 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str10;
                this.File1.PostedFile.SaveAs(str4 + str6 + extension);
                str5 = str6 + extension;
                str11 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", str, "", this.SpContent.Text, "','", fileName, "','", str5, 
                    "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if ((this.SpContent.Text != "") || (this.Yinzhang.SelectedValue != "请选择"))
            {
                str11 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", str, "", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
            }
            this.SpContent.Text = null;
            this.DataBindToGridview();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.uploadFile.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str6 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                }
                else if (!this.pulicss.scquanstr(extension, str6))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                }
                else
                {
                    Random random = new Random();
                    string str7 = random.Next(0x2710).ToString();
                    str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                    this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string filetype = this.pulicss.Getfiletype(extension);
                    this.pulicss.Insertfile(fileName, "WorkFlow/file/" + str2 + "", this.Number.Text, filetype);
                    this.pulicss.InsertLog("上传附件[" + fileName + "]", "通知公告");
                    this.BindFjlbList();
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            Random random = new Random();
            string str2 = random.Next(0x2710).ToString();
            str = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str2;
            if (this.fujian.SelectedValue == "1")
            {
                File.Copy(base.Server.MapPath("//WorkFlow//file//1.doc"), base.Server.MapPath("//WorkFlow//file//" + str + ".doc"), false);
                this.pulicss.Insertfile("" + this.wdname.Text + ".doc", "WorkFlow/file/" + str + ".doc", this.Number.Text, "doc");
            }
            if (this.fujian.SelectedValue == "2")
            {
                File.Copy(base.Server.MapPath("//WorkFlow//file//2.xls"), base.Server.MapPath("//WorkFlow//file//" + str + ".xls"), false);
                this.pulicss.Insertfile("" + this.wdname.Text + ".xls", "WorkFlow/file/" + str + ".xls", this.Number.Text, "xls");
            }
            if (this.fujian.SelectedValue == "3")
            {
                File.Copy(base.Server.MapPath("//WorkFlow//file//3.ppt"), base.Server.MapPath("//WorkFlow//file//" + str + ".ppt"), false);
                this.pulicss.Insertfile("" + this.wdname.Text + ".ppt", "WorkFlow/file/" + str + ".ppt", this.Number.Text, "ppt");
            }
            this.wdname.Text = "";
            this.BindFjlbList();
        }

        public void DataBindToGridview()
        {
            string str;
            if (this.ViewState["YijianZb"].ToString() == "1")
            {
                str = "select * from qp_oa_AddWorkFlowMessage  where Number='" + this.Number.Text + "' order by id asc";
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
                this.GridView1.DataBind();
            }
            else if (this.ViewState["YijianZb"].ToString() == "2")
            {
                str = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowMessage  where Number='", this.Number.Text, "' and Buzhou='", this.ViewState["NodeName"], "' order by id asc" });
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
                this.GridView1.DataBind();
            }
            else
            {
                str = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowMessage  where Number='", this.Number.Text, "' and username='", this.Session["Username"], "' order by id asc" });
                this.GridView1.DataSource = this.List.GetGrid_Pages_not(str);
                this.GridView1.DataBind();
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Xiugai")
            {
                this.DataBindToGridview();
            }
            if (e.CommandName == "ShanChu")
            {
                int num = Convert.ToInt32(e.CommandArgument);
                string sql = "delete from qp_oa_AddWorkFlowMessage where ID='" + num + "'";
                this.List.ExeSql(sql);
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
                LinkButton button = (LinkButton) e.Row.FindControl("Xiugai");
                button.Attributes.Add("onclick", "javascript:openxg(" + button.CommandArgument + ")");
                LinkButton button2 = (LinkButton) e.Row.FindControl("Shanchu");
                button2.Attributes.Add("onclick", "javascript:return confirm('确定删除此吗')");
                Label label = (Label) e.Row.FindControl("Buzhou");
                Label label2 = (Label) e.Row.FindControl("Username");
                if ((label2.Text == this.Session["Username"].ToString()) && (label.Text == this.ViewState["NodeName"].ToString()))
                {
                    button.Visible = true;
                    button2.Visible = true;
                }
                else
                {
                    button.Visible = false;
                    button2.Visible = false;
                }
            }
        }

        protected void HuiTui_Click(object sender, EventArgs e)
        {
            string str11;
            string str = "";
            if (this.Yinzhang.SelectedValue != "请选择")
            {
                str = "<img src=\"/seal/" + this.Yinzhang.SelectedValue + "\" width=\"140px\" height=\"100px\"  hspace=\"10\">";
                string str2 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowSeal (YzNum,MkName,Number,Name,Newname,Username,Realname,IpAddress,Settime) values ('", this.Number.Text, "','", this.ViewState["NodeName"], "','", this.ViewState["YzSealNumber"], "','", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.Page.Request.UserHostAddress, 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str2);
                string str3 = string.Concat(new object[] { "insert into qp_oa_SealUseLog (Name,Newname,Username,Realname,MkName,Usetime,Ip) values ('", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.ViewState["NodeName"], "','", DateTime.Now.ToString(), "','", this.Page.Request.UserHostAddress, "')" });
                this.List.ExeSql(str3);
            }
            string str4 = base.Server.MapPath("file/");
            string str5 = string.Empty;
            string str6 = string.Empty;
            if (this.File1.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.File1.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str9 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                if (!this.pulicss.scquanstr(extension, str9))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                Random random = new Random();
                string str10 = random.Next(0x2710).ToString();
                str6 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str10;
                this.File1.PostedFile.SaveAs(str4 + str6 + extension);
                str5 = str6 + extension;
                str11 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", str, "", this.SpContent.Text, "','", fileName, "','", str5, 
                    "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if ((this.SpContent.Text != "") || (this.Yinzhang.SelectedValue != "请选择"))
            {
                str11 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", str, "", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
            }
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_AddWorkFlowYbl (NodeName,Number,Sequence,Name,FileContent,Username,Realname,Nowtimes) values ('", this.ViewState["NodeName"].ToString(), "','", this.Number.Text, "','", int.Parse(this.ViewState["lshid"].ToString()), "','", this.whname.Text, "','", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                "')"
             });
            this.List.ExeSql(sql);
            string str13 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  Name='", this.whname.Text, "',State='正在办理', FileContent='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(str13);
            string str14 = "select  * from qp_oa_FormFile where id  in (" + this.ViewState["WriteFileID"] + ") and (type='[常规型]' or type='[数字型]')   order by id asc";
            SqlDataReader list = this.List.GetList(str14);
            while (list.Read())
            {
                string str15 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowFileKey  Set  Content='", base.Request.Form["" + list["Number"] + ""], "'  where AddNumber='", this.Number.Text, "' and Number='", list["Number"], "'" });
                this.List.ExeSql(str15);
            }
            list.Close();
            base.Response.Redirect("WorkFlowListSp_Ht.aspx?tmp=" + base.Request.QueryString["tmp"] + "&UpNodeNum=" + this.GqUpNodeNumKey.Text + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "&id=" + base.Request.QueryString["id"] + "&Number=" + this.Number.Text + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                Utility.RegisterTypeForAjax(typeof(AjaxMethod));
                if (!this.Page.IsPostBack)
                {
                    string sQL = "select Newname,Name+'('+YxType+')' as Name  from qp_oa_YinZhang where Username='" + this.Session["Username"] + "' and  State='正常' ";
                    this.list.Bind_DropDownList(this.Yinzhang, sQL, "Newname", "Name");
                    this.BindAttribute();
                    string sql = "select * from qp_oa_WorkFlowNode where id='" + int.Parse(base.Request.QueryString["UpNodeId"]) + "'";
                    SqlDataReader reader = this.List.GetList(sql);
                    if (reader.Read())
                    {
                        StateBag bag = ViewState;
                        object obj2;
                        this.ViewState["Jiankong"] = reader["Jiankong"].ToString();
                        if (reader["Jiankong"].ToString() == "2")
                        {
                            this.Button18.Visible = false;
                        }
                        else
                        {
                            this.Button18.Visible = true;
                        }
                        this.ViewState["tiaojian"] = reader["tiaojian"].ToString();
                        this.ViewState["NodeSite"] = reader["NodeSite"].ToString();
                        this.ViewState["ZbQuanxian"] = "," + reader["ZbQuanxian"].ToString() + ",";
                        this.ViewState["JbQuanxian"] = "," + reader["JbQuanxian"].ToString() + ",";
                        this.ViewState["YijianZb"] = reader["YijianZb"].ToString();
                        this.ViewState["YijianJb"] = reader["YijianJb"].ToString();
                        this.ViewState["ZbHuitui"] = reader["ZbHuitui"].ToString();
                        this.ViewState["JbHuitui"] = reader["JbHuitui"].ToString();
                        this.ViewState["JcZhuanjiao"] = reader["JcZhuanjiao"].ToString();
                        this.ViewState["ZbZhuanjiao"] = reader["ZbZhuanjiao"].ToString();
                        this.ViewState["NodeNum"] = reader["NodeNum"].ToString();
                        this.ViewState["NodeName"] = reader["NodeName"].ToString();
                        this.ViewState["UpNodeNum"] = reader["UpNodeNum"].ToString();
                        this.ViewState["UpNodeNumKey"] = reader["UpNodeNum"].ToString();
                        this.GqUpNodeNumKey.Text = reader["UpNodeNum"].ToString();
                        this.ViewState["NodeId"] = reader["id"].ToString();
                        this.ViewState["WriteFileID"] = "" + reader["WriteFileID"].ToString() + "0";
                        this.ViewState["SecFileID"] = "" + reader["SecFileID"].ToString() + "0";
                        this.ViewState["HongFileID"] = "" + reader["HongFileID"].ToString() + "0";
                        this.ViewState["CouFileID"] = "" + reader["CouFileID"].ToString() + "0";
                        this.ViewState["YzFileID"] = "" + reader["YzFileID"].ToString() + "0";
                        this.ViewState["YzTiaojian"] = reader["YzTiaojian"].ToString();
                        if (this.ViewState["YzTiaojian"].ToString() != "0")
                        {
                            string str3;
                            SqlDataReader reader2;
                            if (this.ViewState["YzTiaojian"].ToString() == "1")
                            {
                                (bag = this.ViewState)["YzKongzhi"] = bag["YzKongzhi"] + "if(";
                                str3 = "select YzNumber from qp_oa_WorkFlowNameYz where  id  in (" + this.ViewState["YzFileID"] + ")";
                                reader2 = this.List.GetList(str3);
                                while (reader2.Read())
                                {
                                    obj2 = bag["YzKongzhi"];
                                    (bag = this.ViewState)["YzKongzhi"] = string.Concat(new object[] { obj2, "document.getElementById('", reader2["YzNumber"].ToString(), "').src.indexOf(\"yz.gif\")>0&&" });
                                }
                                reader2.Close();
                                this.ViewState["YzKongzhi"] = this.ViewState["YzKongzhi"].ToString().Remove(this.ViewState["YzKongzhi"].ToString().Length - 2, 2);
                                (bag = this.ViewState)["YzKongzhi"] = bag["YzKongzhi"] + ")";
                                (bag = this.ViewState)["YzKongzhi"] = bag["YzKongzhi"] + "{alert('请选择印章');return false;}";
                            }
                            if (this.ViewState["YzTiaojian"].ToString() == "2")
                            {
                                (bag = this.ViewState)["YzKongzhi"] = bag["YzKongzhi"] + "if(";
                                str3 = "select YzNumber from qp_oa_WorkFlowNameYz where  id  in (" + this.ViewState["YzFileID"] + ")";
                                reader2 = this.List.GetList(str3);
                                while (reader2.Read())
                                {
                                    obj2 = bag["YzKongzhi"];
                                    (bag = this.ViewState)["YzKongzhi"] = string.Concat(new object[] { obj2, "document.getElementById('", reader2["YzNumber"].ToString(), "').src.indexOf(\"yz.gif\")>0||" });
                                }
                                reader2.Close();
                                this.ViewState["YzKongzhi"] = this.ViewState["YzKongzhi"].ToString().Remove(this.ViewState["YzKongzhi"].ToString().Length - 2, 2);
                                (bag = this.ViewState)["YzKongzhi"] = bag["YzKongzhi"] + ")";
                                (bag = this.ViewState)["YzKongzhi"] = bag["YzKongzhi"] + "{alert('请选择印章');return false;}";
                            }
                        }
                        string str4 = "select * from qp_oa_FormFile where  id  in (" + this.ViewState["CouFileID"] + ")";
                        SqlDataReader reader3 = this.List.GetList(str4);
                        while (reader3.Read())
                        {
                            obj2 = bag["bitian"];
                            (bag = this.ViewState)["bitian"] = string.Concat(new object[] { obj2, "try{if(document.getElementById('", reader3["Number"].ToString(), "').value==''){alert('【", reader3["Name"].ToString(), "】不能为空');return false;}}catch(err){}" });
                        }
                        reader3.Close();
                        this.ViewState["GuolvKxFileID"] = "";
                        string str5 = string.Concat(new object[] { "select * from qp_oa_WorkFlowNodeGuolv where CHARINDEX(',", this.Session["username"], ",',','+KxGuoLvUser+',') > 0 and NodeId='", int.Parse(base.Request.QueryString["UpNodeId"]), "'" });
                        SqlDataReader reader4 = this.List.GetList(str5);
                        while (reader4.Read())
                        {
                            this.ViewState["GuolvKxFileID"] = reader4["GuolvFileID"].ToString() + this.ViewState["GuolvKxFileID"].ToString();
                        }
                        reader4.Close();
                        (bag = this.ViewState)["GuolvKxFileID"] = bag["GuolvKxFileID"] + "0";
                        this.ViewState["GuolvBmFileID"] = "";
                        string str6 = string.Concat(new object[] { "select * from qp_oa_WorkFlowNodeGuolv where CHARINDEX(',", this.Session["username"], ",',','+BmGuoLvUser+',') > 0 and NodeId='", int.Parse(base.Request.QueryString["UpNodeId"]), "'" });
                        SqlDataReader reader5 = this.List.GetList(str6);
                        while (reader5.Read())
                        {
                            this.ViewState["GuolvBmFileID"] = reader5["GuolvFileID"].ToString() + this.ViewState["GuolvBmFileID"].ToString();
                        }
                        reader5.Close();
                        (bag = this.ViewState)["GuolvBmFileID"] = bag["GuolvBmFileID"] + "0";
                        string str7 = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                        SqlDataReader reader6 = this.List.GetList(str7);
                        if (reader6.Read())
                        {
                            string str16;
                            SqlDataReader reader11;
                            string str17;
                            SqlDataReader reader12;
                            string str18;
                            SqlDataReader reader13;
                            string text;
                            string str20;
                            SqlDataReader reader14;
                            string str21;
                            string str22;
                            string str23;
                            SqlDataReader reader15;
                            string str24;
                            string str25;
                            SqlDataReader reader16;
                            string str26;
                            SqlDataReader reader17;
                            string str28;
                            this.JinJiChengDu.Text = this.pulicss.SystemCode("10", reader6["JinJiChengDu"].ToString());
                            this.GlNum.Text = reader6["GlNum"].ToString();
                            string str8 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='办理中'   where KeyFile='", reader6["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", reader6["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
                            this.List.ExeSql(str8);
                            string str9 = string.Concat(new object[] { "select IfZb from qp_oa_AddWorkFlowPicRy where KeyFile='", reader6["Number"].ToString(), "' and BLusername='", this.Session["username"], "'  and XuHao='", reader6["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "'" });
                            SqlDataReader reader7 = this.List.GetList(str9);
                            if (reader7.Read())
                            {
                                this.ViewState["IfZb"] = reader7["IfZb"].ToString();
                            }
                            else
                            {
                                reader6.Close();
                                reader7.Close();
                                base.Response.Write("<script language=javascript>alert('没有操作权限！');window.location = '/main_d.aspx'</script>");
                                return;
                            }
                            reader7.Close();
                            this.ViewState["BDNumber"] = reader6["FormNumber"].ToString();
                            this.whname1.Text = reader6["Name"].ToString();
                            this.whname.Text = reader6["Name"].ToString();
                            this.ViewState["ShuXing"] = reader6["ShuXing"].ToString();
                            this.ViewState["lshid"] = int.Parse(reader6["Sequence"].ToString());
                            this.Number.Text = reader6["Number"].ToString();
                            this.ViewState["Numbers"] = reader6["Number"].ToString();
                            this.ViewState["UpNodeNums"] = reader6["UpNodeNum"].ToString();
                            string str10 = null;
                            string str11 = "select * from qp_oa_FormFile where  leixing='1' and KeyFile='" + this.ViewState["BDNumber"] + "'";
                            SqlDataReader reader8 = this.List.GetList(str11);
                            while (reader8.Read())
                            {
                                str10 = (str10 + "<script>function js" + reader8["Number"].ToString() + "(){myvalue=") + reader8["sqlstr"].ToString();
                                string str12 = null;
                                str12 = "" + reader8["sqlstr"].ToString().Replace("(", "").Replace(")", "").Replace("+", ",").Replace("-", ",").Replace("*", ",").Replace("/", ",") + "";
                                ArrayList list = new ArrayList();
                                string[] strArray = str12.Split(new char[] { ',' });
                                for (int i = 0; i < strArray.Length; i++)
                                {
                                    string str13 = string.Concat(new object[] { "select Number,Name from qp_oa_FormFile where  KeyFile='", this.ViewState["BDNumber"], "' and Name='", strArray[i], "'" });
                                    SqlDataReader reader9 = this.List.GetList(str13);
                                    if (reader9.Read())
                                    {
                                        str10 = str10.Replace(reader9["Name"].ToString(), "parseFloat(document.getElementById(\"" + reader9["Number"].ToString() + "\").value)");
                                    }
                                    reader9.Close();
                                }
                                str28 = str10;
                                str10 = str28 + ";if(!isNaN(myvalue))document.getElementById(\"" + reader8["Number"].ToString() + "\").value=Math.round(myvalue * 100)/100;else document.getElementById(\"" + reader8["Number"].ToString() + "\").value=\"\";}</script>";
                            }
                            reader8.Close();
                            this.ViewState["jisuan"] = str10;
                            string str14 = null;
                            string str15 = "select * from qp_oa_FormFile where  Type='[列表]' and KeyFile='" + this.ViewState["BDNumber"] + "'";
                            SqlDataReader reader10 = this.List.GetList(str15);
                            while (reader10.Read())
                            {
                                str28 = str14;
                                str14 = str28 + "<SCRIPT>setInterval(\"tb_cal('T" + reader10["Number"].ToString() + "T','" + reader10["sqlstr"].ToString() + "')\",1000);</SCRIPT>";
                            }
                            reader10.Close();
                            this.ViewState["liebiao"] = str14;
                            if (this.ViewState["IfZb"].ToString() == "主办")
                            {
                                str16 = "select * from qp_oa_FormFile where  type='[关联办理意见]' and KeyFile='" + this.ViewState["BDNumber"] + "'";
                                reader11 = this.List.GetList(str16);
                                while (reader11.Read())
                                {
                                    obj2 = bag["url"];
                                    (bag = this.ViewState)["url"] = string.Concat(new object[] { obj2, "try{window.L", reader11["Number"], ".location.href='AddWorkFlow_spyj.aspx?Number='+num+'&Buzhou=", reader11["sqlstr"], "&key=", this.ViewState["YijianZb"], "';}catch(err){}" });
                                }
                                reader11.Close();
                                if (reader["WhZbSet"].ToString() == "1")
                                {
                                    this.whname1.Visible = false;
                                    this.whname.CssClass = "Twhname2";
                                }
                                else
                                {
                                    this.whname.Attributes.Add("readonly", "readonly");
                                }
                                str17 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowPicRy where KeyFile='", reader6["Number"].ToString(), "' and BLusername!='", this.Session["username"], "' and XuHao='", reader6["UpNodeNum"], "' and  (States!='已办结' and States!='已委托') and GlNum='", this.GlNum.Text, "'" });
                                reader12 = this.List.GetList(str17);
                                if (reader12.Read())
                                {
                                    if (this.ViewState["ZbZhuanjiao"].ToString() == "1")
                                    {
                                        this.Button1.Visible = true;
                                    }
                                    else
                                    {
                                        this.Button1.Visible = false;
                                    }
                                }
                                else
                                {
                                    this.Wanbi.Visible = false;
                                    this.Button1.Visible = true;
                                }
                                reader12.Close();
                                if (this.ViewState["ZbHuitui"].ToString() == "1")
                                {
                                    this.HuiTui.Visible = false;
                                }
                                else
                                {
                                    this.HuiTui.Visible = true;
                                }
                                this.pulicss.QuanXianVis(this.Panel1, ",13,", this.ViewState["ZbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button4, ",13,", this.ViewState["ZbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button17, ",13,", this.ViewState["ZbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button5, ",2,", this.ViewState["ZbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button9, ",3,", this.ViewState["ZbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button3, ",4,", this.ViewState["ZbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button7, ",12,", this.ViewState["ZbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button10, ",7,", this.ViewState["ZbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button2, ",14,", this.ViewState["ZbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button16, ",15,", this.ViewState["ZbQuanxian"].ToString());
                                if (this.ViewState["ZbQuanxian"].ToString().IndexOf(",8,") < 0)
                                {
                                    this.ViewState["FormName"] = reader6["FormName"].ToString();
                                    this.ViewState["FormNumber"] = reader6["FormNumber"].ToString();
                                    this.ContractContent.Text = reader6["FileContent"].ToString();
                                    this.TextBox1.Text = reader6["FileContent"].ToString();
                                    str18 = "select * from qp_oa_FormFile where  KeyFile='" + reader6["FormNumber"].ToString() + "'";
                                    reader13 = this.List.GetList(str18);
                                    while (reader13.Read())
                                    {
                                        this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader13["Number"].ToString() + "", "name=" + reader13["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader13["Number"].ToString() + "\"", "name=" + reader13["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                                        this.TextBox1.Text = this.ContractContent.Text;
                                    }
                                    reader13.Close();
                                }
                                else
                                {
                                    this.ViewState["FormName"] = reader6["FormName"].ToString();
                                    this.ViewState["FormNumber"] = reader6["FormNumber"].ToString();
                                    text = "";
                                    this.ContractContent.Text = this.showform.FormatKjStrZh(reader6["FileContent"].ToString());
                                    this.TextBox1.Text = this.showform.FormatKjStrZh(reader6["FileContent"].ToString());
                                    str20 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["HongFileID"], ") and KeyFile='", this.ViewState["BDNumber"], "'" });
                                    reader14 = this.List.GetList(str20);
                                    while (reader14.Read())
                                    {
                                        str21 = "";
                                        text = this.ContractContent.Text;
                                        str21 = this.pulicss.GetFormatStrbjq_show(this.showform.FormatKjStrH(reader14["Number"].ToString(), base.Request.QueryString["id"].ToString(), text, this.ViewState["FormName"].ToString(), "" + this.whname1.Text + "", DateTime.Now.ToShortDateString(), DateTime.Now.ToString(), int.Parse(this.ViewState["lshid"].ToString())));
                                        this.ContractContent.Text = str21;
                                        this.TextBox1.Text = str21;
                                    }
                                    reader14.Close();
                                    if (this.ViewState["GuolvKxFileID"].ToString().Length < 1)
                                    {
                                        str18 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ")  and KeyFile='", this.ViewState["BDNumber"], "' and Type!='[印章域]'" });
                                        reader13 = this.List.GetList(str18);
                                        while (reader13.Read())
                                        {
                                            this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader13["Number"].ToString() + "", "name=" + reader13["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader13["Number"].ToString() + "\"", "name=" + reader13["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                                            this.TextBox1.Text = this.ContractContent.Text;
                                        }
                                        reader13.Close();
                                        str22 = null;
                                        str23 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id in (", this.ViewState["WriteFileID"], ")  and  leixing='2' and KeyFile='", this.ViewState["BDNumber"], "'" });
                                        reader15 = this.List.GetList(str23);
                                        while (reader15.Read())
                                        {
                                            str28 = str22;
                                            str22 = str28 + "<SCRIPT>setInterval(\"sum('" + reader15["sqlstr"].ToString() + "','" + reader15["Number"].ToString() + "')\",1000);</SCRIPT>";
                                        }
                                        reader15.Close();
                                        this.ViewState["liebiaoqh"] = str22;
                                        str24 = null;
                                        str25 = string.Concat(new object[] { "select Number from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ") and Type='[列表]' and KeyFile='", this.ViewState["BDNumber"], "'" });
                                        reader16 = this.List.GetList(str25);
                                        while (reader16.Read())
                                        {
                                            str24 = str24 + "disable('T" + reader16["Number"].ToString() + "T');";
                                        }
                                        reader16.Close();
                                        this.ViewState["liebiaobkx"] = str24;
                                    }
                                    else
                                    {
                                        str18 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ") and id not in (", this.ViewState["GuolvKxFileID"], ") and KeyFile='", this.ViewState["BDNumber"], "' and Type!='[印章域]'" });
                                        reader13 = this.List.GetList(str18);
                                        while (reader13.Read())
                                        {
                                            this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader13["Number"].ToString() + "", "name=" + reader13["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader13["Number"].ToString() + "\"", "name=" + reader13["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                                            this.TextBox1.Text = this.ContractContent.Text;
                                        }
                                        reader13.Close();
                                        str22 = null;
                                        str23 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id in (", this.ViewState["WriteFileID"], ",", this.ViewState["GuolvKxFileID"], ")  and  leixing='2' and KeyFile='", this.ViewState["BDNumber"], "'" });
                                        reader15 = this.List.GetList(str23);
                                        while (reader15.Read())
                                        {
                                            str28 = str22;
                                            str22 = str28 + "<SCRIPT>setInterval(\"sum('" + reader15["sqlstr"].ToString() + "','" + reader15["Number"].ToString() + "')\",1000);</SCRIPT>";
                                        }
                                        reader15.Close();
                                        this.ViewState["liebiaoqh"] = str22;
                                        str24 = null;
                                        str25 = string.Concat(new object[] { "select Number from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ") and id not in (", this.ViewState["GuolvKxFileID"], ") and Type='[列表]' and KeyFile='", this.ViewState["BDNumber"], "'" });
                                        reader16 = this.List.GetList(str25);
                                        while (reader16.Read())
                                        {
                                            str24 = str24 + "disable('T" + reader16["Number"].ToString() + "T');";
                                        }
                                        reader16.Close();
                                        this.ViewState["liebiaobkx"] = str24;
                                    }
                                    if (this.ViewState["GuolvBmFileID"].ToString().Length < 1)
                                    {
                                        str26 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["SecFileID"], ") and  KeyFile='", this.ViewState["BDNumber"], "' and Type!='[印章域]'" });
                                        reader17 = this.List.GetList(str26);
                                        while (reader17.Read())
                                        {
                                            this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader17["Number"].ToString() + "", "name=" + reader17["Number"].ToString() + "  style=\"display:none\"").Replace("name=\"" + reader17["Number"].ToString() + "\"", "name=" + reader17["Number"].ToString() + "  style=\"display:none\"");
                                            this.TextBox1.Text = this.ContractContent.Text;
                                        }
                                        reader17.Close();
                                    }
                                    else
                                    {
                                        str26 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["SecFileID"], ") and id not in (", this.ViewState["GuolvBmFileID"], ") and  KeyFile='", this.ViewState["BDNumber"], "' and Type!='[印章域]'" });
                                        reader17 = this.List.GetList(str26);
                                        while (reader17.Read())
                                        {
                                            this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader17["Number"].ToString() + "", "name=" + reader17["Number"].ToString() + "  style=\"display:none\"").Replace("name=\"" + reader17["Number"].ToString() + "\"", "name=" + reader17["Number"].ToString() + "  style=\"display:none\"");
                                            this.TextBox1.Text = this.ContractContent.Text;
                                        }
                                        reader17.Close();
                                    }
                                }
                            }
                            else
                            {
                                str16 = "select * from qp_oa_FormFile where  type='[关联办理意见]' and KeyFile='" + this.ViewState["BDNumber"] + "'";
                                reader11 = this.List.GetList(str16);
                                while (reader11.Read())
                                {
                                    obj2 = bag["url"];
                                    (bag = this.ViewState)["url"] = string.Concat(new object[] { obj2, "try{window.L", reader11["Number"], ".location.href='AddWorkFlow_spyj.aspx?Number='+num+'&Buzhou=", reader11["sqlstr"], "&key=1';}catch(err){}" });
                                }
                                reader11.Close();
                                if (reader["WhJbSet"].ToString() == "1")
                                {
                                    this.whname1.Visible = false;
                                    this.whname.CssClass = "Twhname2";
                                }
                                else
                                {
                                    this.whname.Attributes.Add("readonly", "readonly");
                                }
                                if (this.ViewState["JcZhuanjiao"].ToString() == "1")
                                {
                                    this.Button1.Visible = true;
                                }
                                else if (this.ViewState["JcZhuanjiao"].ToString() == "2")
                                {
                                    str17 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowPicRy where KeyFile='", reader6["Number"].ToString(), "' and BLusername!='", this.Session["username"], "' and XuHao='", reader6["UpNodeNum"], "' and  (States!='已办结' and States!='已委托') and GlNum='", this.GlNum.Text, "'" });
                                    reader12 = this.List.GetList(str17);
                                    if (reader12.Read())
                                    {
                                        this.Button1.Visible = false;
                                    }
                                    else
                                    {
                                        this.Button1.Visible = true;
                                        this.Wanbi.Visible = false;
                                    }
                                    reader12.Close();
                                }
                                else if (this.ViewState["IfZb"].ToString() == "经办")
                                {
                                    this.Button1.Visible = false;
                                }
                                if (this.ViewState["JbHuitui"].ToString() == "1")
                                {
                                    this.HuiTui.Visible = false;
                                }
                                else
                                {
                                    this.HuiTui.Visible = true;
                                }
                                if (this.ViewState["YijianJb"].ToString() == "4")
                                {
                                    this.CheckBox1.Visible = false;
                                }
                                else
                                {
                                    this.CheckBox1.Visible = true;
                                }
                                this.pulicss.QuanXianVis(this.Panel1, ",13,", this.ViewState["JbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button4, ",13,", this.ViewState["JbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button17, ",13,", this.ViewState["JbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button5, ",2,", this.ViewState["JbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button9, ",3,", this.ViewState["JbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button3, ",4,", this.ViewState["JbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button7, ",12,", this.ViewState["JbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button10, ",7,", this.ViewState["JbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button2, ",14,", this.ViewState["JbQuanxian"].ToString());
                                this.pulicss.QuanXianVis(this.Button16, ",15,", this.ViewState["JbQuanxian"].ToString());
                                if (this.ViewState["JbQuanxian"].ToString().IndexOf(",8,") < 0)
                                {
                                    this.ViewState["FormName"] = reader6["FormName"].ToString();
                                    this.ViewState["FormNumber"] = reader6["FormNumber"].ToString();
                                    this.ContractContent.Text = reader6["FileContent"].ToString();
                                    this.TextBox1.Text = reader6["FileContent"].ToString();
                                    str18 = "select * from qp_oa_FormFile where  KeyFile='" + reader6["FormNumber"].ToString() + "'";
                                    reader13 = this.List.GetList(str18);
                                    while (reader13.Read())
                                    {
                                        this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader13["Number"].ToString() + "", "name=" + reader13["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader13["Number"].ToString() + "\"", "name=" + reader13["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                                        this.TextBox1.Text = this.ContractContent.Text;
                                    }
                                    reader13.Close();
                                }
                                else
                                {
                                    this.ViewState["FormName"] = reader6["FormName"].ToString();
                                    this.ViewState["FormNumber"] = reader6["FormNumber"].ToString();
                                    text = "";
                                    this.ContractContent.Text = this.showform.FormatKjStrZh(reader6["FileContent"].ToString());
                                    this.TextBox1.Text = this.showform.FormatKjStrZh(reader6["FileContent"].ToString());
                                    str20 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["HongFileID"], ") and KeyFile='", this.ViewState["BDNumber"], "'" });
                                    reader14 = this.List.GetList(str20);
                                    while (reader14.Read())
                                    {
                                        str21 = "";
                                        text = this.ContractContent.Text;
                                        str21 = this.pulicss.GetFormatStrbjq_show(this.showform.FormatKjStrH(reader14["Number"].ToString(), base.Request.QueryString["id"].ToString(), text, this.ViewState["FormName"].ToString(), "" + this.whname1.Text + "", DateTime.Now.ToShortDateString(), DateTime.Now.ToString(), int.Parse(this.ViewState["lshid"].ToString())));
                                        this.ContractContent.Text = str21;
                                        this.TextBox1.Text = str21;
                                    }
                                    reader14.Close();
                                    if (this.ViewState["GuolvKxFileID"].ToString().Length < 2)
                                    {
                                        str18 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ")  and KeyFile='", this.ViewState["BDNumber"], "' and Type!='[印章域]'" });
                                        reader13 = this.List.GetList(str18);
                                        while (reader13.Read())
                                        {
                                            this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader13["Number"].ToString() + "", "name=" + reader13["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader13["Number"].ToString() + "\"", "name=" + reader13["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                                            this.TextBox1.Text = this.ContractContent.Text;
                                        }
                                        reader13.Close();
                                        str22 = null;
                                        str23 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id in (", this.ViewState["WriteFileID"], ")  and  leixing='2' and KeyFile='", this.ViewState["BDNumber"], "'" });
                                        reader15 = this.List.GetList(str23);
                                        while (reader15.Read())
                                        {
                                            str28 = str22;
                                            str22 = str28 + "<SCRIPT>setInterval(\"sum('" + reader15["sqlstr"].ToString() + "','" + reader15["Number"].ToString() + "')\",1000);</SCRIPT>";
                                        }
                                        reader15.Close();
                                        this.ViewState["liebiaoqh"] = str22;
                                        str24 = null;
                                        str25 = string.Concat(new object[] { "select Number from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ") and Type='[列表]' and KeyFile='", this.ViewState["BDNumber"], "'" });
                                        reader16 = this.List.GetList(str25);
                                        while (reader16.Read())
                                        {
                                            str24 = str24 + "disable('T" + reader16["Number"].ToString() + "T');";
                                        }
                                        reader16.Close();
                                        this.ViewState["liebiaobkx"] = str24;
                                    }
                                    else
                                    {
                                        str18 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ") and id not in (", this.ViewState["GuolvKxFileID"], ")  and KeyFile='", this.ViewState["BDNumber"], "' and Type!='[印章域]'" });
                                        reader13 = this.List.GetList(str18);
                                        while (reader13.Read())
                                        {
                                            this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader13["Number"].ToString() + "", "name=" + reader13["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader13["Number"].ToString() + "\"", "name=" + reader13["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                                            this.TextBox1.Text = this.ContractContent.Text;
                                        }
                                        reader13.Close();
                                        str22 = null;
                                        str23 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id in (", this.ViewState["WriteFileID"], ",", this.ViewState["GuolvKxFileID"], ")  and  leixing='2' and KeyFile='", this.ViewState["BDNumber"], "'" });
                                        reader15 = this.List.GetList(str23);
                                        while (reader15.Read())
                                        {
                                            str28 = str22;
                                            str22 = str28 + "<SCRIPT>setInterval(\"sum('" + reader15["sqlstr"].ToString() + "','" + reader15["Number"].ToString() + "')\",1000);</SCRIPT>";
                                        }
                                        reader15.Close();
                                        this.ViewState["liebiaoqh"] = str22;
                                        str24 = null;
                                        str25 = string.Concat(new object[] { "select Number from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ") and id not in (", this.ViewState["GuolvKxFileID"], ") and Type='[列表]' and KeyFile='", this.ViewState["BDNumber"], "'" });
                                        reader16 = this.List.GetList(str25);
                                        while (reader16.Read())
                                        {
                                            str24 = str24 + "disable('T" + reader16["Number"].ToString() + "T');";
                                        }
                                        reader16.Close();
                                        this.ViewState["liebiaobkx"] = str24;
                                    }
                                    if (this.ViewState["GuolvBmFileID"].ToString().Length < 2)
                                    {
                                        str26 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["SecFileID"], ")  and KeyFile='", this.ViewState["BDNumber"], "' and Type!='[印章域]'" });
                                        reader17 = this.List.GetList(str26);
                                        while (reader17.Read())
                                        {
                                            this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader17["Number"].ToString() + "", "name=" + reader17["Number"].ToString() + "  style=\"display:none\"").Replace("name=\"" + reader17["Number"].ToString() + "\"", "name=" + reader17["Number"].ToString() + "  style=\"display:none\"");
                                            this.TextBox1.Text = this.ContractContent.Text;
                                        }
                                        reader17.Close();
                                    }
                                    else
                                    {
                                        str26 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["SecFileID"], ") and id not in (", this.ViewState["GuolvBmFileID"], ")  and KeyFile='", this.ViewState["BDNumber"], "' and Type!='[印章域]'" });
                                        reader17 = this.List.GetList(str26);
                                        while (reader17.Read())
                                        {
                                            this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader17["Number"].ToString() + "", "name=" + reader17["Number"].ToString() + "  style=\"display:none\"").Replace("name=\"" + reader17["Number"].ToString() + "\"", "name=" + reader17["Number"].ToString() + "  style=\"display:none\"");
                                            this.TextBox1.Text = this.ContractContent.Text;
                                        }
                                        reader17.Close();
                                    }
                                }
                            }
                            this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), this.ViewState["NodeName"].ToString(), "查看工作" + this.whname.Text + "", this.ViewState["IfZb"].ToString());
                        }
                        reader6.Close();
                    }
                    else
                    {
                        base.Response.Write("<script language=javascript>alert('未找到此流程，有可能此流程已被删除！');window.close();</script>");
                        return;
                    }
                    reader.Close();
                    this.ViewState["YzSealNumber"] = this.Number.Text;
                    string str27 = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id asc";
                    this.list.Bind_DropDownList(this.normalcontent, str27, "Content", "Content");
                    if (this.ViewState["NodeSite"].ToString() == "开始")
                    {
                        this.Wanbi.Visible = false;
                        this.BaoCun.Visible = false;
                        this.HuiTui.Visible = false;
                    }
                    this.DataBindToGridview();
                }
                this.BindFjlbList();
            }
        }
    }
}

