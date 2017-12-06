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

    public class AddWorkFlow_add : Page
    {
        protected Button Button1;
        protected Button Button11;
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button6;
        protected Button Button8;
        protected HtmlInputButton Button9;
        protected TextBox ContractContent;
        protected HtmlInputFile File1;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected RadioButtonList fujian;
        protected TextBox GlNum;
        protected TextBox GqUpNodeNumKey;
        protected HtmlHead Head1;
        protected DropDownList JinJiChengDu;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList Muban;
        protected DropDownList normalcontent;
        protected TextBox Number;
        protected Panel PMuban;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox SpContent;
        protected TextBox TextBox1;
        protected HtmlInputFile uploadFile;
        protected TextBox wdname;
        protected TextBox whname;
        protected Label whname1;
        protected DropDownList Yinzhang;

        public void BindAttribute()
        {
            this.Button11.Attributes["onclick"] = "javascript:return daoru();";
            this.Button6.Attributes["onclick"] = "javascript:return AddFile();";
            this.Button8.Attributes["onclick"] = "javascript:return BaocunMB();";
            this.Button12.Attributes["onclick"] = "javascript:return ShanchuMB();";
            this.Button1.Attributes["onclick"] = "javascript:return ConFile();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button2.Attributes["onclick"] = "javascript:return openfile();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Random random;
            string str11;
            string str12;
            string sql = "select top 1 Sequence from qp_oa_AddWorkFlow order by id desc";
            SqlDataReader reader = this.List.GetList(sql);
            if (reader.Read())
            {
                this.ViewState["lshid"] = int.Parse(reader["Sequence"].ToString()) + 1;
            }
            else
            {
                this.ViewState["lshid"] = 1;
            }
            reader.Close();
            string str2 = "";
            if (this.Yinzhang.SelectedValue != "请选择")
            {
                str2 = "<img src=\"/seal/" + this.Yinzhang.SelectedValue + "\" width=\"140px\" height=\"100px\"  hspace=\"10\">";
                string str3 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowSeal (YzNum,MkName,Number,Name,Newname,Username,Realname,IpAddress,Settime) values ('", this.Number.Text, "','", this.ViewState["NodeName"], "','", this.ViewState["YzSealNumber"], "','", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.Page.Request.UserHostAddress, 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str3);
                string str4 = string.Concat(new object[] { "insert into qp_oa_SealUseLog (Name,Newname,Username,Realname,MkName,Usetime,Ip) values ('", this.Yinzhang.SelectedItem.Text, "','", this.Yinzhang.SelectedValue, "','", this.Session["username"], "','", this.Session["realname"], "','", this.ViewState["NodeName"], "','", DateTime.Now.ToString(), "','", this.Page.Request.UserHostAddress, "')" });
                this.List.ExeSql(str4);
            }
            string str5 = base.Server.MapPath("file/");
            string str6 = string.Empty;
            string str7 = string.Empty;
            if (this.File1.PostedFile.ContentLength != 0)
            {
                string fileName = Path.GetFileName(this.File1.PostedFile.FileName);
                string extension = Path.GetExtension(fileName);
                string str10 = this.Session["FjKey"].ToString();
                if (!this.pulicss.StrCheckRight(extension))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！任何时候都不允许上传可执行文件！');</script>");
                    return;
                }
                if (!this.pulicss.scquanstr(extension, str10))
                {
                    base.Response.Write("<script language=javascript>alert('上传文件错误！允许上传格式为" + this.Session["FjKey"].ToString() + "');</script>");
                    return;
                }
                random = new Random();
                str11 = random.Next(0x2710).ToString();
                str7 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str11;
                this.File1.PostedFile.SaveAs(str5 + str7 + extension);
                str6 = str7 + extension;
                str12 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','主办','", this.Number.Text, "','", this.ViewState["NodeName"], "','", str2, "", this.SpContent.Text, "','", fileName, "','", str6, "','", this.Session["Username"], 
                    "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str12);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if ((this.SpContent.Text != "") || (this.Yinzhang.SelectedValue != "请选择"))
            {
                str12 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (Xuhao,ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["NodeNum"], "','主办','", this.Number.Text, "','", this.ViewState["NodeName"], "','", str2, "", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), 
                    "')"
                 });
                this.List.ExeSql(str12);
            }
            try
            {
                string str16 = null;
                str16 = "" + this.ViewState["UpNodeNum"] + "0";
                ArrayList list = new ArrayList();
                string[] strArray = str16.Split(new char[] { ',' });
                for (int i = 0; i < strArray.Length; i++)
                {
                    object obj2;
                    string str14 = null;
                    string str13 = null;
                    string str15 = null;
                    string str17 = string.Concat(new object[] { "select * from qp_oa_FlowFormFile where KeyID=(select id from qp_oa_WorkFlowNode where NodeNum='", strArray[i], "' and FlowNumber='", base.Request.QueryString["FlowNumber"], "') and NodeId='", this.ViewState["NodeId"], "' and  Type='[常规型]'" });
                    SqlDataReader reader2 = this.List.GetList(str17);
                    while (reader2.Read())
                    {
                        if (reader2["Conditions"].ToString() == "包含")
                        {
                            obj2 = str14;
                            str14 = string.Concat(new object[] { obj2, "", base.Request.Form["" + reader2["Number"] + ""].IndexOf(reader2["JudgeBasis"].ToString()), ">= 0", reader2["JudgeType"].ToString(), "" });
                        }
                        else if (reader2["Conditions"].ToString() == "不包含")
                        {
                            obj2 = str14;
                            str14 = string.Concat(new object[] { obj2, "", base.Request.Form["" + reader2["Number"] + ""].IndexOf(reader2["JudgeBasis"].ToString()), "< 0", reader2["JudgeType"].ToString(), "" });
                        }
                    }
                    reader2.Close();
                    string str18 = string.Concat(new object[] { "select * from qp_oa_FlowFormFile where  KeyID=(select id from qp_oa_WorkFlowNode where NodeNum='", strArray[i], "' and FlowNumber='", base.Request.QueryString["FlowNumber"], "') and  NodeId='", this.ViewState["NodeId"], "' and  Type='[数字型]'" });
                    SqlDataReader reader3 = this.List.GetList(str18);
                    while (reader3.Read())
                    {
                        obj2 = str13;
                        str13 = string.Concat(new object[] { obj2, "", decimal.Parse(base.Request.Form["" + reader3["Number"] + ""]), " ", reader3["Conditions"], " ", reader3["JudgeBasis"], "", reader3["JudgeType"].ToString(), "" });
                    }
                    reader3.Close();
                    str15 = str14 + str13;
                    if ((((str15 != "") && (str15 != " ")) && (str15 != "  ")) && (str15 != null))
                    {
                        ScriptControl control = new ScriptControlClass();
                        control.Language = "javascript";
                        if (!((bool) control.Eval(str15.Trim())))
                        {
                            this.ViewState["UpNodeNumKey"] = this.ViewState["UpNodeNumKey"].ToString().Replace("" + strArray[i] + ",", "");
                            this.GqUpNodeNumKey.Text = this.GqUpNodeNumKey.Text.Replace("" + strArray[i] + ",", "");
                        }
                    }
                }
                string str19 = "select * from qp_oa_WorkFlowNode where NodeSite='开始' and FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'";
                SqlDataReader reader4 = this.List.GetList(str19);
                if (reader4.Read())
                {
                    string str20 = null;
                    string str21 = null;
                    string str22 = "select * from qp_oa_WorkFlowName where id='" + reader4["FlowId"] + "' ";
                    SqlDataReader reader5 = this.List.GetList(str22);
                    if (reader5.Read())
                    {
                        str20 = reader5["JkUsername"].ToString();
                        str21 = reader5["JkRealname"].ToString();
                    }
                    reader5.Close();
                    string str23 = string.Concat(new object[] { 
                        "insert into qp_oa_AddWorkFlow (JinJiChengDu,GlNum,YJBNodeNum,Ifdel,UpNodeNumber,UpNodeId,UpNodeNum,UpNodeName,Shuxing,JkUsername,JkRealname,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,NodeNumber,NodeNum,NodeName,Number,Sequence,Name,State,FileContent,FqUsername,FqRealname,YJBObjectId,YJBObjecName,ZbObjectId,ZbObjectName,JbObjectId,JbObjectName,LcNameId,Username,Realname,NowTimes,UpTimeSet) values ('", this.JinJiChengDu.SelectedValue, "','", this.GlNum.Text, "','0','0','", reader4["NodeNumber"], "','", this.ViewState["UpNodeId"], "','", reader4["NodeNum"], "','", reader4["NodeName"], "','固定流程','", str20, "','", str21, 
                        "','", reader4["FormId"], "','", reader4["FormNumber"], "','", reader4["FormName"], "','", reader4["FlowId"], "','", reader4["FlowNumber"], "','", reader4["FlowName"], "','", reader4["NodeNumber"], "','", reader4["NodeNum"], 
                        "','", reader4["NodeName"], "','", this.Number.Text, "','", this.ViewState["lshid"], "','", this.whname.Text, "','正在办理','", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "','", this.Session["username"], "','", this.Session["realname"], "','", this.Session["username"], 
                        ",','", this.Session["realname"], ",','", this.Session["username"], "','", this.Session["realname"], "','", this.Session["username"], "','", this.Session["realname"], "','", this.ViewState["LcNameId"], "','", this.Session["Username"], "','", this.Session["Realname"], 
                        "','", DateTime.Now.ToString(), "','", DateTime.Now.ToString(), "')"
                     });
                    this.List.ExeSql(str23);
                    random = new Random();
                    str11 = random.Next(0x2710).ToString();
                    string str24 = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str11 + "";
                    string str25 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPic (GlNum,LcNum,KeyFile,XuHao,Jiedian) values ('", this.GlNum.Text, "','", str24, "','", this.Number.Text, "','", reader4["NodeNum"], "','", reader4["NodeName"], "')" });
                    this.List.ExeSql(str25);
                    string str26 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", this.GlNum.Text, "','", reader4["NodeNum"], "','", str24, "','", this.Number.Text, "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "','','办理中','主办')" });
                    this.List.ExeSql(str26);
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('保存失败，请检查是否存在开始流程！');</script>");
                    return;
                }
                reader4.Close();
                this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), this.ViewState["NodeName"].ToString(), "新建工作" + this.whname.Text + "", "主办");
                string str27 = "select  * from qp_oa_FormFile where KeyFile='" + this.ViewState["FormNumber"] + "' and (type='[常规型]' or type='[数字型]')   order by id asc";
                SqlDataReader reader6 = this.List.GetList(str27);
                while (reader6.Read())
                {
                    string str28 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowFileKey (keyid,AddNumber,KeyFile,Number,Content) values ('", reader6["id"], "','", this.Number.Text, "','", reader6["KeyFile"], "','", reader6["Number"], "','", base.Request.Form["" + reader6["Number"] + ""], "')" });
                    this.List.ExeSql(str28);
                }
                reader6.Close();
                base.Response.Redirect(string.Concat(new object[] { "AddWorkFlow_add_Next.aspx?tmp=", base.Request.QueryString["tmp"], "&UpNodeNum=", this.ViewState["UpNodeNumKey"], "&FlowNumber=", base.Request.QueryString["FlowNumber"], "&FormId=", base.Request.QueryString["FormId"], "&Number=", this.Number.Text, "" }));
            }
            catch
            {
                base.Response.Write("<script language=javascript>alert('保存失败，请检查是否有必填项未填写或字段设置错误！');</script>");
            }
        }

        protected void Button11_Click(object sender, EventArgs e)
        {
            string sql = "select * from qp_oa_AddWorkFlowMb where id='" + this.Muban.SelectedValue + "'";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ContractContent.Text = list["MbContent"].ToString();
                this.TextBox1.Text = list["MbContent"].ToString();
            }
            list.Close();
        }

        protected void Button12_Click(object sender, EventArgs e)
        {
            string sql = "delete from qp_oa_AddWorkFlowMb where id='" + this.Muban.SelectedValue + "'";
            this.List.ExeSql(sql);
            string sQL = string.Concat(new object[] { "select id,MbShijian  from qp_oa_AddWorkFlowMb where Username='", this.Session["Username"], "' and  FlowNumber='", base.Request.QueryString["FlowNumber"], "' " });
            this.list.Bind_DropDownList(this.Muban, sQL, "id", "MbShijian");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("file/");
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
                    string filetype = this.pulicss.Getfiletype(extension);
                    Random random = new Random();
                    string str8 = random.Next(0x2710).ToString();
                    str3 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str8;
                    this.uploadFile.PostedFile.SaveAs(str + str3 + extension);
                    this.pulicss.Insertfile(fileName, "WorkFlow/file/" + (str3 + extension) + "", this.Number.Text, filetype);
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

        protected void Button8_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowMb (FlowNumber,MbContent,MbShijian,Username,Realname,BuMenId) values ('", base.Request.QueryString["FlowNumber"], "','", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "','", this.whname.Text, "','", this.Session["username"], "','", this.Session["realname"], "','", this.Session["BuMenId"], "')" });
            this.List.ExeSql(sql);
            string sQL = string.Concat(new object[] { "select id,MbShijian  from qp_oa_AddWorkFlowMb where Username='", this.Session["Username"], "' and  FlowNumber='", base.Request.QueryString["FlowNumber"], "' " });
            this.list.Bind_DropDownList(this.Muban, sQL, "id", "MbShijian");
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
                    this.BindAttribute();
                    string sQL = string.Concat(new object[] { "select id,MbShijian  from qp_oa_AddWorkFlowMb where Username='", this.Session["Username"], "' and  FlowNumber='", base.Request.QueryString["FlowNumber"], "' " });
                    this.list.Bind_DropDownList(this.Muban, sQL, "id", "MbShijian");
                    string sql = "select Guanlian,GlZiduan,Muban from qp_oa_WorkFlowName where FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'";
                    SqlDataReader reader = this.List.GetList(sql);
                    if (reader.Read())
                    {
                        if (reader["Muban"].ToString() == "1")
                        {
                            this.PMuban.Visible = true;
                        }
                        else
                        {
                            this.PMuban.Visible = false;
                        }
                        if (reader["Guanlian"].ToString() == "1")
                        {
                            this.ViewState["GlZiduan"] = "document.getElementById('whname').value=document.getElementById('" + reader["GlZiduan"].ToString() + "').value";
                        }
                    }
                    reader.Close();
                    string str3 = "select * from qp_oa_WorkFlowNode where NodeSite='开始' and FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'";
                    SqlDataReader reader2 = this.List.GetList(str3);
                    if (reader2.Read())
                    {
                        string str9;
                        SqlDataReader reader8;
                        StateBag bag = ViewState;
                        object obj2;
                        this.ViewState["NodeNum"] = reader2["NodeNum"].ToString();
                        this.ViewState["tiaojian"] = reader2["tiaojian"].ToString();
                        this.ViewState["UpNodeId"] = reader2["id"].ToString();
                        this.ViewState["NodeName"] = reader2["NodeName"].ToString();
                        this.ViewState["UpNodeNum"] = reader2["UpNodeNum"].ToString();
                        this.ViewState["UpNodeNumKey"] = reader2["UpNodeNum"].ToString();
                        this.GqUpNodeNumKey.Text = reader2["UpNodeNum"].ToString();
                        this.ViewState["NodeId"] = reader2["id"].ToString();
                        this.ViewState["WriteFileID"] = "" + reader2["WriteFileID"].ToString() + "0";
                        this.ViewState["SecFileID"] = "" + reader2["SecFileID"].ToString() + "0";
                        this.ViewState["HongFileID"] = "" + reader2["HongFileID"].ToString() + "0";
                        this.ViewState["CouFileID"] = "" + reader2["CouFileID"].ToString() + "0";
                        this.ViewState["YzFileID"] = "" + reader2["YzFileID"].ToString() + "0";
                        this.ViewState["YzTiaojian"] = reader2["YzTiaojian"].ToString();
                        if (this.ViewState["YzTiaojian"].ToString() != "0")
                        {
                            string str4;
                            SqlDataReader reader3;
                            if (this.ViewState["YzTiaojian"].ToString() == "1")
                            {
                                (bag = this.ViewState)["YzKongzhi"] = bag["YzKongzhi"] + "if(";
                                str4 = "select YzNumber from qp_oa_WorkFlowNameYz where  id  in (" + this.ViewState["YzFileID"] + ")";
                                reader3 = this.List.GetList(str4);
                                while (reader3.Read())
                                {
                                    obj2 = bag["YzKongzhi"];
                                    (bag = this.ViewState)["YzKongzhi"] = string.Concat(new object[] { obj2, "document.getElementById('", reader3["YzNumber"].ToString(), "').src.indexOf(\"yz.gif\")>0&&" });
                                }
                                reader3.Close();
                                this.ViewState["YzKongzhi"] = this.ViewState["YzKongzhi"].ToString().Remove(this.ViewState["YzKongzhi"].ToString().Length - 2, 2);
                                (bag = this.ViewState)["YzKongzhi"] = bag["YzKongzhi"] + ")";
                                (bag = this.ViewState)["YzKongzhi"] = bag["YzKongzhi"] + "{alert('请选择印章');return false;}";
                            }
                            if (this.ViewState["YzTiaojian"].ToString() == "2")
                            {
                                (bag = this.ViewState)["YzKongzhi"] = bag["YzKongzhi"] + "if(";
                                str4 = "select YzNumber from qp_oa_WorkFlowNameYz where  id  in (" + this.ViewState["YzFileID"] + ")";
                                reader3 = this.List.GetList(str4);
                                while (reader3.Read())
                                {
                                    obj2 = bag["YzKongzhi"];
                                    (bag = this.ViewState)["YzKongzhi"] = string.Concat(new object[] { obj2, "document.getElementById('", reader3["YzNumber"].ToString(), "').src.indexOf(\"yz.gif\")>0||" });
                                }
                                reader3.Close();
                                this.ViewState["YzKongzhi"] = this.ViewState["YzKongzhi"].ToString().Remove(this.ViewState["YzKongzhi"].ToString().Length - 2, 2);
                                (bag = this.ViewState)["YzKongzhi"] = bag["YzKongzhi"] + ")";
                                (bag = this.ViewState)["YzKongzhi"] = bag["YzKongzhi"] + "{alert('请选择印章');return false;}";
                            }
                        }
                        string str5 = "select * from qp_oa_FormFile where  id  in (" + this.ViewState["CouFileID"] + ")";
                        SqlDataReader reader4 = this.List.GetList(str5);
                        while (reader4.Read())
                        {
                            obj2 = bag["bitian"];
                            (bag = this.ViewState)["bitian"] = string.Concat(new object[] { obj2, "try{if(document.getElementById('", reader4["Number"].ToString(), "').value==''){alert('【", reader4["Name"].ToString(), "】不能为空');return false;}}catch(err){}" });
                        }
                        reader4.Close();
                        this.ViewState["GuolvKxFileID"] = "";
                        string str6 = string.Concat(new object[] { "select * from qp_oa_WorkFlowNodeGuolv where CHARINDEX(',", this.Session["username"], ",',','+KxGuoLvUser+',') > 0 and NodeId='", reader2["id"], "'" });
                        SqlDataReader reader5 = this.List.GetList(str6);
                        while (reader5.Read())
                        {
                            this.ViewState["GuolvKxFileID"] = reader5["GuolvFileID"].ToString() + this.ViewState["GuolvKxFileID"].ToString();
                        }
                        reader5.Close();
                        (bag = this.ViewState)["GuolvKxFileID"] = bag["GuolvKxFileID"] + "0";
                        this.ViewState["GuolvBmFileID"] = "";
                        string str7 = string.Concat(new object[] { "select * from qp_oa_WorkFlowNodeGuolv where CHARINDEX(',", this.Session["username"], ",',','+BmGuoLvUser+',') > 0 and NodeId='", reader2["id"], "'" });
                        SqlDataReader reader6 = this.List.GetList(str7);
                        while (reader6.Read())
                        {
                            this.ViewState["GuolvBmFileID"] = reader6["GuolvFileID"].ToString() + this.ViewState["GuolvBmFileID"].ToString();
                        }
                        reader6.Close();
                        (bag = this.ViewState)["GuolvBmFileID"] = bag["GuolvBmFileID"] + "0";
                        string str8 = "select top 1 id,LcNameId from qp_oa_AddWorkFlow where FlowNumber='" + base.Request.QueryString["FlowNumber"] + "' order by id desc";
                        SqlDataReader reader7 = this.List.GetList(str8);
                        if (reader7.Read())
                        {
                            this.ViewState["LcNameId"] = int.Parse(reader7["LcNameId"].ToString()) + 1;
                            str9 = "select Wenhao,BianhaoWs,FlowName from qp_oa_WorkFlowName where FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'";
                            reader8 = this.List.GetList(str9);
                            if (reader8.Read())
                            {
                                this.whname1.Text = this.showform.FormatWh(reader8["Wenhao"].ToString(), this.ViewState["LcNameId"].ToString().PadLeft(int.Parse(reader8["BianhaoWs"].ToString()), '0'), reader8["BianhaoWs"].ToString(), reader8["FlowName"].ToString());
                                this.whname.Text = this.showform.FormatWh(reader8["Wenhao"].ToString(), this.ViewState["LcNameId"].ToString().PadLeft(int.Parse(reader8["BianhaoWs"].ToString()), '0'), reader8["BianhaoWs"].ToString(), reader8["FlowName"].ToString());
                            }
                            reader8.Close();
                        }
                        else
                        {
                            str9 = "select Wenhao,BianhaoWs,FlowName,BianhaoJs,BianhaoWs from qp_oa_WorkFlowName where FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'";
                            reader8 = this.List.GetList(str9);
                            if (reader8.Read())
                            {
                                this.ViewState["LcNameId"] = int.Parse(reader8["BianhaoJs"].ToString());
                                this.whname1.Text = this.showform.FormatWh(reader8["Wenhao"].ToString(), this.ViewState["LcNameId"].ToString().PadLeft(int.Parse(reader8["BianhaoWs"].ToString()), '0'), reader8["BianhaoWs"].ToString(), reader8["FlowName"].ToString());
                                this.whname.Text = this.showform.FormatWh(reader8["Wenhao"].ToString(), this.ViewState["LcNameId"].ToString().PadLeft(int.Parse(reader8["BianhaoWs"].ToString()), '0'), reader8["BianhaoWs"].ToString(), reader8["FlowName"].ToString());
                            }
                            reader8.Close();
                        }
                        reader7.Close();
                        if (reader2["WhZbSet"].ToString() == "1")
                        {
                            this.whname1.Visible = false;
                            this.whname.CssClass = "Twhname2";
                        }
                        else
                        {
                            this.whname.Attributes.Add("readonly", "readonly");
                        }
                    }
                    else
                    {
                        base.Response.Write("<script language=javascript>alert('此流程未找到“启始步骤”，请重新设置此流程！');window.location.href='AddWorkFlow.aspx'</script>");
                        return;
                    }
                    reader2.Close();
                    string str10 = "select top 1 Sequence from qp_oa_AddWorkFlow order by id desc";
                    SqlDataReader reader9 = this.List.GetList(str10);
                    if (reader9.Read())
                    {
                        this.ViewState["lshid"] = int.Parse(reader9["Sequence"].ToString()) + 1;
                    }
                    else
                    {
                        this.ViewState["lshid"] = 1;
                    }
                    reader9.Close();
                    string str11 = "select * from qp_oa_DIYForm where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["FormId"]) + "'";
                    SqlDataReader reader10 = this.List.GetList(str11);
                    if (reader10.Read())
                    {
                        string str25;
                        SqlDataReader reader17;
                        string str26;
                        SqlDataReader reader18;
                        string str30;
                        this.ViewState["BDNumber"] = reader10["Number"].ToString();
                        this.ViewState["FormName"] = reader10["FormName"].ToString();
                        this.ViewState["FormNumber"] = reader10["Number"].ToString();
                        string str12 = null;
                        string str13 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["WriteFileID"], ") and leixing='1' and KeyFile='", this.ViewState["BDNumber"], "'" });
                        SqlDataReader reader11 = this.List.GetList(str13);
                        while (reader11.Read())
                        {
                            str12 = (str12 + "<script>function js" + reader11["Number"].ToString() + "(){myvalue=") + reader11["sqlstr"].ToString();
                            string str14 = null;
                            str14 = "" + reader11["sqlstr"].ToString().Replace("(", "").Replace(")", "").Replace("+", ",").Replace("-", ",").Replace("*", ",").Replace("/", ",") + "";
                            ArrayList list = new ArrayList();
                            string[] strArray = str14.Split(new char[] { ',' });
                            for (int i = 0; i < strArray.Length; i++)
                            {
                                string str15 = string.Concat(new object[] { "select Number,Name from qp_oa_FormFile where  KeyFile='", this.ViewState["BDNumber"], "' and Name='", strArray[i], "'" });
                                SqlDataReader reader12 = this.List.GetList(str15);
                                if (reader12.Read())
                                {
                                    str12 = str12.Replace(reader12["Name"].ToString(), "parseFloat(document.getElementById(\"" + reader12["Number"].ToString() + "\").value)");
                                }
                                reader12.Close();
                            }
                            str30 = str12;
                            str12 = str30 + ";if(!isNaN(myvalue))document.getElementById(\"" + reader11["Number"].ToString() + "\").value=Math.round(myvalue * 100)/100;else document.getElementById(\"" + reader11["Number"].ToString() + "\").value=\"\";}</script>";
                        }
                        reader11.Close();
                        this.ViewState["jisuan"] = str12;
                        string str16 = null;
                        string str17 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["WriteFileID"], ") and leixing='2' and KeyFile='", this.ViewState["BDNumber"], "'" });
                        SqlDataReader reader13 = this.List.GetList(str17);
                        while (reader13.Read())
                        {
                            str30 = str16;
                            str16 = str30 + "<SCRIPT>setInterval(\"sum('" + reader13["sqlstr"].ToString() + "','" + reader13["Number"].ToString() + "')\",1000);</SCRIPT>";
                        }
                        reader13.Close();
                        this.ViewState["liebiaoqh"] = str16;
                        string str18 = null;
                        string str19 = string.Concat(new object[] { "select Number from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ") and Type='[列表]' and KeyFile='", this.ViewState["BDNumber"], "'" });
                        SqlDataReader reader14 = this.List.GetList(str19);
                        while (reader14.Read())
                        {
                            str18 = str18 + "disable('T" + reader14["Number"].ToString() + "T');";
                        }
                        reader14.Close();
                        this.ViewState["liebiaobkx"] = str18;
                        string str20 = null;
                        string str21 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["WriteFileID"], ") and Type='[列表]' and KeyFile='", this.ViewState["BDNumber"], "'" });
                        SqlDataReader reader15 = this.List.GetList(str21);
                        while (reader15.Read())
                        {
                            str30 = str20;
                            str20 = str30 + "<SCRIPT>setInterval(\"tb_cal('T" + reader15["Number"].ToString() + "T','" + reader15["sqlstr"].ToString() + "')\",1000);</SCRIPT>";
                        }
                        reader15.Close();
                        this.ViewState["liebiao"] = str20;
                        string aStr = "";
                        this.ContractContent.Text = this.showform.FormatKjStrZh(reader10["FormContent"].ToString());
                        this.TextBox1.Text = this.showform.FormatKjStrZh(reader10["FormContent"].ToString());
                        string str23 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["HongFileID"], ") and KeyFile='", this.ViewState["BDNumber"], "'" });
                        SqlDataReader reader16 = this.List.GetList(str23);
                        while (reader16.Read())
                        {
                            string str24 = "";
                            aStr = this.ContractContent.Text;
                            str24 = this.pulicss.GetFormatStrbjq_show(this.showform.FormatKjStrH(reader16["Number"].ToString(), "0", aStr, this.ViewState["FormName"].ToString(), "" + this.whname1.Text + "", DateTime.Now.ToShortDateString(), DateTime.Now.ToString(), int.Parse(this.ViewState["lshid"].ToString())));
                            this.ContractContent.Text = str24;
                            this.TextBox1.Text = str24;
                        }
                        reader16.Close();
                        if (this.ViewState["GuolvKxFileID"].ToString().Length < 2)
                        {
                            str25 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ") and Type!='[印章域]' and KeyFile='", this.ViewState["BDNumber"], "'" });
                            reader17 = this.List.GetList(str25);
                            while (reader17.Read())
                            {
                                this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader17["Number"].ToString() + "", "name=" + reader17["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader17["Number"].ToString() + "\"", "name=" + reader17["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                                this.TextBox1.Text = this.ContractContent.Text;
                            }
                            reader17.Close();
                        }
                        else
                        {
                            str25 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id not in (", this.ViewState["WriteFileID"], ") and id not in (", this.ViewState["GuolvKxFileID"], ") and Type!='[印章域]' and KeyFile='", this.ViewState["BDNumber"], "'" });
                            reader17 = this.List.GetList(str25);
                            while (reader17.Read())
                            {
                                this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader17["Number"].ToString() + "", "name=" + reader17["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled").Replace("name=\"" + reader17["Number"].ToString() + "\"", "name=" + reader17["Number"].ToString() + "  style=\"BACKGROUND-COLOR: #F9F9F9\"  disabled");
                                this.TextBox1.Text = this.ContractContent.Text;
                            }
                            reader17.Close();
                        }
                        if (this.ViewState["GuolvBmFileID"].ToString().Length < 2)
                        {
                            str26 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["SecFileID"], ")  and Type!='[印章域]' and KeyFile='", this.ViewState["BDNumber"], "'" });
                            reader18 = this.List.GetList(str26);
                            while (reader18.Read())
                            {
                                this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader18["Number"].ToString() + "", "name=" + reader18["Number"].ToString() + "  style=\"display:none\"").Replace("name=\"" + reader18["Number"].ToString() + "\"", "name=" + reader18["Number"].ToString() + "  style=\"display:none\"");
                                this.TextBox1.Text = this.ContractContent.Text;
                            }
                            reader18.Close();
                        }
                        else
                        {
                            str26 = string.Concat(new object[] { "select * from qp_oa_FormFile where  id  in (", this.ViewState["SecFileID"], ") and id not in (", this.ViewState["GuolvBmFileID"], ")  and Type!='[印章域]' and KeyFile='", this.ViewState["BDNumber"], "'" });
                            reader18 = this.List.GetList(str26);
                            while (reader18.Read())
                            {
                                this.ContractContent.Text = this.ContractContent.Text.Replace("name=" + reader18["Number"].ToString() + "", "name=" + reader18["Number"].ToString() + "  style=\"display:none\"").Replace("name=\"" + reader18["Number"].ToString() + "\"", "name=" + reader18["Number"].ToString() + "  style=\"display:none\"");
                                this.TextBox1.Text = this.ContractContent.Text;
                            }
                            reader18.Close();
                        }
                    }
                    reader10.Close();
                    Random random = new Random();
                    string str27 = random.Next(0x2710).ToString();
                    this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str27 + "";
                    this.GlNum.Text = "" + DateTime.Now.Millisecond.ToString() + "" + str27 + "";
                    this.ViewState["YzSealNumber"] = this.Number.Text;
                    string str28 = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id asc";
                    this.list.Bind_DropDownList(this.normalcontent, str28, "Content", "Content");
                    string str29 = "select Newname,Name+'('+YxType+')' as Name  from qp_oa_YinZhang where Username='" + this.Session["Username"] + "' and  State='正常' ";
                    this.list.Bind_DropDownList(this.Yinzhang, str29, "Newname", "Name");
                }
                this.BindFjlbList();
            }
        }
    }
}

