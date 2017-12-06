namespace xyoa.WorkFlow
{
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

    public class WorkFlowListJkSp : Page
    {
        protected Button BaoCun;
        protected Button Button1;
        protected HtmlInputButton Button10;
        protected HtmlInputButton Button14;
        protected HtmlInputButton Button16;
        protected Button Button17;
        protected HtmlInputButton Button2;
        protected Button Button3;
        protected Button Button4;
        protected HtmlInputButton Button5;
        protected Button Button6;
        protected HtmlInputButton Button7;
        protected HtmlInputButton Button8;
        protected HtmlInputButton Button9;
        protected TextBox ContractContent;
        protected HtmlInputFile File1;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected RadioButtonList fujian;
        protected TextBox GlNum;
        protected TextBox GqUpNodeNumKey;
        protected HtmlHead Head1;
        protected Button HuiTui;
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
        protected TextBox whendname;
        protected TextBox whname;
        protected Label whname1;
        protected TextBox whstartname;

        protected void BaoCun_Click(object sender, EventArgs e)
        {
            string str8;
            string str = base.Server.MapPath("file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.File1.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.File1.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str6 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                if (!this.pulicss.scquanstr(extension, str6))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                Random random = new Random();
                string str7 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                this.File1.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                str8 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", this.SpContent.Text, "','", fileName, "','", str2, "','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str8);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if (this.SpContent.Text != "")
            {
                str8 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')" });
                this.List.ExeSql(str8);
            }
            try
            {
                string str12 = null;
                str12 = "" + this.ViewState["UpNodeNum"] + "0";
                ArrayList list = new ArrayList();
                string[] strArray = str12.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    object obj2;
                    string str10 = null;
                    string str9 = null;
                    string expression = null;
                    expression = "1 == 1";
                    string str13 = string.Concat(new object[] { "select * from qp_oa_FlowFormFile where KeyID=(select id from qp_oa_WorkFlowNode where NodeNum='", strArray[i], "' and FlowNumber='", base.Request.QueryString["FlowNumber"], "') and NodeId='", this.ViewState["NodeId"], "' and  Type='[常规型]'" });
                    SqlDataReader reader = this.List.GetList(str13);
                    while (reader.Read())
                    {
                        if (reader["Conditions"].ToString() == "包含")
                        {
                            obj2 = str10;
                            str10 = string.Concat(new object[] { obj2, "&&", base.Request.Form["" + reader["Number"] + ""].IndexOf(reader["JudgeBasis"].ToString()), ">= 0 " });
                        }
                        else if (reader["Conditions"].ToString() == "不包含")
                        {
                            obj2 = str10;
                            str10 = string.Concat(new object[] { obj2, "&&", base.Request.Form["" + reader["Number"] + ""].IndexOf(reader["JudgeBasis"].ToString()), "< 0 " });
                        }
                    }
                    reader.Close();
                    string str14 = string.Concat(new object[] { "select * from qp_oa_FlowFormFile where  KeyID=(select id from qp_oa_WorkFlowNode where NodeNum='", strArray[i], "' and FlowNumber='", base.Request.QueryString["FlowNumber"], "') and  NodeId='", this.ViewState["NodeId"], "' and  Type='[数字型]'" });
                    SqlDataReader reader2 = this.List.GetList(str14);
                    while (reader2.Read())
                    {
                        obj2 = str9;
                        str9 = string.Concat(new object[] { obj2, "&&", int.Parse(base.Request.Form["" + reader2["Number"] + ""]), " ", reader2["Conditions"], " ", reader2["JudgeBasis"], "  " });
                    }
                    reader2.Close();
                    expression = expression + str10 + str9;
                    ScriptControl control = new ScriptControlClass();
                    control.Language = "javascript";
                    if (!((bool) control.Eval(expression)))
                    {
                        this.ViewState["UpNodeNumKey"] = this.ViewState["UpNodeNumKey"].ToString().Replace("" + strArray[i] + ",", "");
                        this.GqUpNodeNumKey.Text = this.GqUpNodeNumKey.Text.Replace("" + strArray[i] + ",", "");
                    }
                }
                string sql = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowYbl (NodeName,Number,Sequence,Name,FileContent,Username,Realname,Nowtimes) values ('", this.ViewState["NodeName"].ToString(), "','", this.Number.Text, "','", this.ViewState["lshid"], "','", this.whstartname.Text, "", this.whname.Text, "", this.whendname.Text, "','", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "','", this.Session["username"], 
                    "','", this.Session["realname"], "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(sql);
                string str16 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  Name='", this.whstartname.Text, "", this.whname.Text, "", this.whendname.Text, "',State='正在办理', FileContent='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str16);
                this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), this.ViewState["NodeName"].ToString(), "保存工作" + this.whstartname.Text + "" + this.whname.Text + "" + this.whendname.Text + "", this.ViewState["IfZb"].ToString());
                base.Response.Write("<script language=javascript>alert('保存成功！');window.opener.location.href='WorkFlowList_blz.aspx';window.close();</script>");
            }
            catch
            {
                base.Response.Write("<script language=javascript>alert('保存失败，请检查是否有必填项未填写或可写字段设置错误！');</script>");
            }
        }

        public void BindAttribute()
        {
            this.Button6.Attributes["onclick"] = "javascript:return AddFile();";
            this.Wanbi.Attributes["onclick"] = "javascript:return showwait();";
            this.BaoCun.Attributes["onclick"] = "javascript:return showwait();";
            this.HuiTui.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return showwait();";
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
            string str8;
            string str = base.Server.MapPath("file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.File1.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.File1.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str6 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                if (!this.pulicss.scquanstr(extension, str6))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                Random random = new Random();
                string str7 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                this.File1.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                str8 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", this.SpContent.Text, "','", fileName, "','", str2, "','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str8);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if (this.SpContent.Text != "")
            {
                str8 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')" });
                this.List.ExeSql(str8);
            }
            try
            {
                string str12 = null;
                str12 = "" + this.ViewState["UpNodeNum"] + "0";
                ArrayList list = new ArrayList();
                string[] strArray = str12.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    object obj2;
                    string str10 = null;
                    string str9 = null;
                    string expression = null;
                    expression = "1 == 1";
                    string str13 = string.Concat(new object[] { "select * from qp_oa_FlowFormFile where KeyID=(select id from qp_oa_WorkFlowNode where NodeNum='", strArray[i], "' and FlowNumber='", base.Request.QueryString["FlowNumber"], "') and NodeId='", this.ViewState["NodeId"], "' and  Type='[常规型]'" });
                    SqlDataReader reader = this.List.GetList(str13);
                    while (reader.Read())
                    {
                        if (reader["Conditions"].ToString() == "包含")
                        {
                            obj2 = str10;
                            str10 = string.Concat(new object[] { obj2, "&&", base.Request.Form["" + reader["Number"] + ""].IndexOf(reader["JudgeBasis"].ToString()), ">= 0 " });
                        }
                        else if (reader["Conditions"].ToString() == "不包含")
                        {
                            obj2 = str10;
                            str10 = string.Concat(new object[] { obj2, "&&", base.Request.Form["" + reader["Number"] + ""].IndexOf(reader["JudgeBasis"].ToString()), "< 0 " });
                        }
                    }
                    reader.Close();
                    string str14 = string.Concat(new object[] { "select * from qp_oa_FlowFormFile where  KeyID=(select id from qp_oa_WorkFlowNode where NodeNum='", strArray[i], "' and FlowNumber='", base.Request.QueryString["FlowNumber"], "') and  NodeId='", this.ViewState["NodeId"], "' and  Type='[数字型]'" });
                    SqlDataReader reader2 = this.List.GetList(str14);
                    while (reader2.Read())
                    {
                        obj2 = str9;
                        str9 = string.Concat(new object[] { obj2, "&&", int.Parse(base.Request.Form["" + reader2["Number"] + ""]), " ", reader2["Conditions"], " ", reader2["JudgeBasis"], "  " });
                    }
                    reader2.Close();
                    expression = expression + str10 + str9;
                    ScriptControl control = new ScriptControlClass();
                    control.Language = "javascript";
                    if (!((bool) control.Eval(expression)))
                    {
                        this.ViewState["UpNodeNumKey"] = this.ViewState["UpNodeNumKey"].ToString().Replace("" + strArray[i] + ",", "");
                        this.GqUpNodeNumKey.Text = this.GqUpNodeNumKey.Text.Replace("" + strArray[i] + ",", "");
                    }
                }
                string sql = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowYbl (NodeName,Number,Sequence,Name,FileContent,Username,Realname,Nowtimes) values ('", this.ViewState["NodeName"].ToString(), "','", this.Number.Text, "','", this.ViewState["lshid"], "','", this.whstartname.Text, "", this.whname.Text, "", this.whendname.Text, "','", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "','", this.Session["username"], 
                    "','", this.Session["realname"], "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(sql);
                string str16 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  Name='", this.whstartname.Text, "", this.whname.Text, "", this.whendname.Text, "',State='正在办理', FileContent='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str16);
                this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), this.ViewState["NodeName"].ToString(), "办理工作" + this.whstartname.Text + "" + this.whname.Text + "" + this.whendname.Text + "", this.ViewState["IfZb"].ToString());
                string str17 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已办结' ,EndTime='", DateTime.Now.ToString(), "'  where KeyFile='", this.Number.Text, "' and BLusername='", this.Session["username"], "' and XuHao='", this.ViewState["UpNodeNums"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
                this.List.ExeSql(str17);
                if (this.ViewState["NodeSite"].ToString() == "结束")
                {
                    base.Response.Redirect("WorkFlowListSp_NextJs.aspx?UpNodeNum=" + this.GqUpNodeNumKey.Text + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "&id=" + base.Request.QueryString["id"] + "&Number=" + this.Number.Text + "");
                }
                else
                {
                    base.Response.Redirect("WorkFlowListSp_Next.aspx?UpNodeNum=" + this.GqUpNodeNumKey.Text + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "&id=" + base.Request.QueryString["id"] + "&Number=" + this.Number.Text + "");
                }
            }
            catch
            {
                base.Response.Write("<script language=javascript>alert('保存失败，请检查是否有必填项未填写或可写字段设置错误！');</script>");
            }
        }

        protected void Button15_Click(object sender, EventArgs e)
        {
            string str8;
            string str = base.Server.MapPath("file/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.File1.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.File1.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str6 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                if (!this.pulicss.scquanstr(extension, str6))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                Random random = new Random();
                string str7 = random.Next(0x2710).ToString();
                str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str7;
                this.File1.PostedFile.SaveAs(str + str3 + extension);
                str2 = str3 + extension;
                str8 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", this.SpContent.Text, "','", fileName, "','", str2, "','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str8);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if (this.SpContent.Text != "")
            {
                str8 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','", this.ViewState["NodeName"].ToString(), "','", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')" });
                this.List.ExeSql(str8);
            }
            try
            {
                string str12 = null;
                str12 = "" + this.ViewState["UpNodeNum"] + "0";
                ArrayList list = new ArrayList();
                string[] strArray = str12.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    object obj2;
                    string str10 = null;
                    string str9 = null;
                    string expression = null;
                    expression = "1 == 1";
                    string str13 = string.Concat(new object[] { "select * from qp_oa_FlowFormFile where KeyID=(select id from qp_oa_WorkFlowNode where NodeNum='", strArray[i], "' and FlowNumber='", base.Request.QueryString["FlowNumber"], "') and NodeId='", this.ViewState["NodeId"], "' and  Type='[常规型]'" });
                    SqlDataReader reader = this.List.GetList(str13);
                    while (reader.Read())
                    {
                        if (reader["Conditions"].ToString() == "包含")
                        {
                            obj2 = str10;
                            str10 = string.Concat(new object[] { obj2, "&&", base.Request.Form["" + reader["Number"] + ""].IndexOf(reader["JudgeBasis"].ToString()), ">= 0 " });
                        }
                        else if (reader["Conditions"].ToString() == "不包含")
                        {
                            obj2 = str10;
                            str10 = string.Concat(new object[] { obj2, "&&", base.Request.Form["" + reader["Number"] + ""].IndexOf(reader["JudgeBasis"].ToString()), "< 0 " });
                        }
                    }
                    reader.Close();
                    string str14 = string.Concat(new object[] { "select * from qp_oa_FlowFormFile where  KeyID=(select id from qp_oa_WorkFlowNode where NodeNum='", strArray[i], "' and FlowNumber='", base.Request.QueryString["FlowNumber"], "') and  NodeId='", this.ViewState["NodeId"], "' and  Type='[数字型]'" });
                    SqlDataReader reader2 = this.List.GetList(str14);
                    while (reader2.Read())
                    {
                        obj2 = str9;
                        str9 = string.Concat(new object[] { obj2, "&&", int.Parse(base.Request.Form["" + reader2["Number"] + ""]), " ", reader2["Conditions"], " ", reader2["JudgeBasis"], "  " });
                    }
                    reader2.Close();
                    expression = expression + str10 + str9;
                    ScriptControl control = new ScriptControlClass();
                    control.Language = "javascript";
                    if (!((bool) control.Eval(expression)))
                    {
                        this.ViewState["UpNodeNumKey"] = this.ViewState["UpNodeNumKey"].ToString().Replace("" + strArray[i] + ",", "");
                        this.GqUpNodeNumKey.Text = this.GqUpNodeNumKey.Text.Replace("" + strArray[i] + ",", "");
                    }
                }
                string sql = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowYbl (NodeName,Number,Sequence,Name,FileContent,Username,Realname,Nowtimes) values ('", this.ViewState["NodeName"].ToString(), "','", this.Number.Text, "','", this.ViewState["lshid"], "','", this.whstartname.Text, "", this.whname.Text, "", this.whendname.Text, "','", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "','", this.Session["username"], 
                    "','", this.Session["realname"], "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(sql);
                string str16 = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  Name='", this.whstartname.Text, "", this.whname.Text, "", this.whendname.Text, "',State='正在办理', FileContent='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
                this.List.ExeSql(str16);
                this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), this.ViewState["NodeName"].ToString(), "办理完毕工作" + this.whstartname.Text + "" + this.whname.Text + "" + this.whendname.Text + "", this.ViewState["IfZb"].ToString());
                string str17 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已办结',EndTime='", DateTime.Now.ToString(), "'   where KeyFile='", this.Number.Text, "' and BLusername='", this.Session["username"], "' and XuHao='", this.ViewState["UpNodeNums"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
                this.List.ExeSql(str17);
                base.Response.Write("<script language=javascript>alert('办理完毕！');window.opener.location.href='WorkFlowList_ybj.aspx';window.close();</script>");
            }
            catch
            {
                base.Response.Write("<script language=javascript>alert('保存失败，请检查是否有必填项未填写或可写字段设置错误！');</script>");
            }
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

        protected void HuiTui_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("WorkFlowListJkSp_Ht.aspx?UpNodeNum=" + this.GqUpNodeNumKey.Text + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "&id=" + base.Request.QueryString["id"] + "&Number=" + this.Number.Text + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else
            {
                if (!this.Page.IsPostBack)
                {
                    this.BindAttribute();
                    string sql = "select * from qp_oa_WorkFlowNode where id='" + int.Parse(base.Request.QueryString["UpNodeId"]) + "'";
                    SqlDataReader list = this.List.GetList(sql);
                    if (list.Read())
                    {
                        this.ViewState["NodeSite"] = list["NodeSite"].ToString();
                        this.ViewState["ZbQuanxian"] = list["ZbQuanxian"].ToString();
                        this.ViewState["JbQuanxian"] = list["JbQuanxian"].ToString();
                        this.ViewState["YijianZb"] = list["YijianZb"].ToString();
                        this.ViewState["YijianJb"] = list["YijianJb"].ToString();
                        this.ViewState["ZbHuitui"] = list["ZbHuitui"].ToString();
                        this.ViewState["JbHuitui"] = list["JbHuitui"].ToString();
                        this.ViewState["JcZhuanjiao"] = list["JcZhuanjiao"].ToString();
                        this.ViewState["ZbZhuanjiao"] = list["ZbZhuanjiao"].ToString();
                        this.ViewState["NodeName"] = list["NodeName"].ToString();
                        this.ViewState["UpNodeNum"] = list["UpNodeNum"].ToString();
                        this.ViewState["UpNodeNumKey"] = list["UpNodeNum"].ToString();
                        this.GqUpNodeNumKey.Text = list["UpNodeNum"].ToString();
                        this.ViewState["NodeId"] = list["id"].ToString();
                        this.ViewState["WriteFileID"] = "" + list["WriteFileID"].ToString() + "0";
                        this.ViewState["SecFileID"] = "" + list["SecFileID"].ToString() + "0";
                        string str2 = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                        SqlDataReader reader2 = this.List.GetList(str2);
                        if (reader2.Read())
                        {
                            this.GlNum.Text = reader2["GlNum"].ToString();
                            string str3 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='办理中'   where KeyFile='", reader2["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", reader2["UpNodeNum"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
                            this.List.ExeSql(str3);
                            this.ViewState["IfZb"] = "主办";
                            this.whname1.Text = reader2["Name"].ToString();
                            this.whname.Text = reader2["Name"].ToString();
                            this.ViewState["ShuXing"] = reader2["ShuXing"].ToString();
                            this.ViewState["lshid"] = int.Parse(reader2["Sequence"].ToString());
                            this.Number.Text = reader2["Number"].ToString();
                            this.ViewState["Numbers"] = reader2["Number"].ToString();
                            this.ViewState["UpNodeNums"] = reader2["UpNodeNum"].ToString();
                            if (this.ViewState["IfZb"].ToString() == "主办")
                            {
                                this.whname1.Visible = false;
                                this.whname.ReadOnly = false;
                                this.whname.CssClass = "Twhname2";
                                this.whstartname.Visible = false;
                                this.whendname.Visible = false;
                                this.ViewState["FormName"] = reader2["FormName"].ToString();
                                this.ViewState["FormNumber"] = reader2["FormNumber"].ToString();
                                string aStr = "";
                                this.ContractContent.Text = this.showform.FormatKjStrZh(reader2["FileContent"].ToString());
                                this.TextBox1.Text = reader2["FileContent"].ToString();
                                string str5 = "select * from qp_oa_FormFile where  id  in (" + this.ViewState["WriteFileID"] + ")";
                                SqlDataReader reader3 = this.List.GetList(str5);
                                while (reader3.Read())
                                {
                                    string str6 = "";
                                    aStr = this.ContractContent.Text;
                                    str6 = this.pulicss.GetFormatStrbjq_show(this.showform.FormatKjStrH(reader3["Number"].ToString(), base.Request.QueryString["id"].ToString(), aStr, this.ViewState["FormName"].ToString(), "" + this.whname1.Text + "", DateTime.Now.ToShortDateString(), DateTime.Now.ToString(), int.Parse(this.ViewState["lshid"].ToString())));
                                    this.ContractContent.Text = str6;
                                    this.TextBox1.Text = str6;
                                }
                                reader3.Close();
                                string str7 = "select * from qp_oa_FormFile where  id not in (" + this.ViewState["WriteFileID"] + ") and Type!='[印章域]'";
                                SqlDataReader reader4 = this.List.GetList(str7);
                                while (reader4.Read())
                                {
                                    this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader4["Number"].ToString() + "", "name=" + reader4["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader4["Number"].ToString() + "\"", "name=" + reader4["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                                    this.TextBox1.Text = this.ContractContent.Text;
                                }
                                reader4.Close();
                                string str8 = "select * from qp_oa_FormFile where  id  in (" + this.ViewState["SecFileID"] + ") and Type!='[印章域]'";
                                SqlDataReader reader5 = this.List.GetList(str8);
                                while (reader5.Read())
                                {
                                    this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader5["Number"].ToString() + "", "name=" + reader5["Number"].ToString() + "  style=\"display:none\"").Replace("name=\"" + reader5["Number"].ToString() + "\"", "name=" + reader5["Number"].ToString() + "  style=\"display:none\"");
                                    this.TextBox1.Text = this.ContractContent.Text;
                                }
                                reader5.Close();
                            }
                            this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), this.ViewState["NodeName"].ToString(), "查看工作" + this.whstartname.Text + "" + this.whname.Text + "" + this.whendname.Text + "", this.ViewState["IfZb"].ToString());
                        }
                        reader2.Close();
                    }
                    else
                    {
                        base.Response.Write("<script language=javascript>alert('未找到此流程，有可能此流程已被删除！');window.close();</script>");
                        return;
                    }
                    list.Close();
                    this.ViewState["YzSealNumber"] = this.Number.Text;
                    string sQL = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id asc";
                    this.list.Bind_DropDownList(this.normalcontent, sQL, "Content", "Content");
                }
                this.BindFjlbList();
            }
        }
    }
}

