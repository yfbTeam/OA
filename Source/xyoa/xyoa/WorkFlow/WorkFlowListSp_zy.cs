namespace xyoa.WorkFlow
{
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

    public class WorkFlowListSp_zy : Page
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
                    "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','自由流程','", str, "", this.SpContent.Text, "','", fileName, "','", str5, "','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if ((this.SpContent.Text != "") || (this.Yinzhang.SelectedValue != "请选择"))
            {
                str11 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','自由流程','", str, "", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')" });
                this.List.ExeSql(str11);
            }
            string sql = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  Name='", this.whname.Text, "',State='正在办理', FileContent='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            string str13 = "select  * from qp_oa_FormFile where KeyFile='" + this.ViewState["FormNumber"] + "' and  (type='[常规型]' or type='[数字型]')   order by id asc";
            SqlDataReader list = this.List.GetList(str13);
            while (list.Read())
            {
                string str14 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowFileKey  Set  Content='", base.Request.Form["" + list["Number"] + ""], "'  where AddNumber='", this.Number.Text, "' and Number='", list["Number"], "'" });
                this.List.ExeSql(str14);
            }
            list.Close();
            string str15 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='办理中' ,EndTime=''  where KeyFile='", this.Number.Text, "' and XuHao='", this.ViewState["UpNodeNums"], "' and BLusername='", this.Session["username"], "'  and GlNum='", this.GlNum.Text, "' and  States!='已委托'" });
            this.List.ExeSql(str15);
            this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), "自由流程", "保存工作" + this.whname.Text + "", this.ViewState["IfZb"].ToString());
            base.Response.Write("<script language=javascript>alert('保存成功！');window.opener.location.href='WorkFlowList.aspx';window.close();</script>");
        }

        public void BindAttribute()
        {
            this.Button6.Attributes["onclick"] = "javascript:return AddFile();";
            this.BaoCun.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return showwait();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button17.Attributes["onclick"] = "javascript:return openfile();";
            this.Wanbi.Attributes["onclick"] = "javascript:return showwait();";
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
                    "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','自由流程','", str, "", this.SpContent.Text, "','", fileName, "','", str5, "','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if ((this.SpContent.Text != "") || (this.Yinzhang.SelectedValue != "请选择"))
            {
                str11 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','自由流程','", str, "", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')" });
                this.List.ExeSql(str11);
            }
            string sql = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  Name='", this.whname.Text, "',State='正在办理', FileContent='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), "自由流程", "办理工作" + this.whname.Text + "", this.ViewState["IfZb"].ToString());
            string str13 = "select  * from qp_oa_FormFile where KeyFile='" + this.ViewState["FormNumber"] + "' and  (type='[常规型]' or type='[数字型]')   order by id asc";
            SqlDataReader list = this.List.GetList(str13);
            while (list.Read())
            {
                string str14 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowFileKey  Set  Content='", base.Request.Form["" + list["Number"] + ""], "'  where AddNumber='", this.Number.Text, "' and Number='", list["Number"], "'" });
                this.List.ExeSql(str14);
            }
            list.Close();
            base.Response.Redirect("WorkFlowListSp_Next_zy.aspx?UpNodeNum=" + this.GqUpNodeNumKey.Text + "&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&UpNodeId=" + base.Request.QueryString["UpNodeId"] + "&id=" + base.Request.QueryString["id"] + "&Number=" + this.Number.Text + "");
        }

        protected void Button15_Click(object sender, EventArgs e)
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
                    "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','自由流程','", str, "", this.SpContent.Text, "','", fileName, "','", str5, "','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str11);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if ((this.SpContent.Text != "") || (this.Yinzhang.SelectedValue != "请选择"))
            {
                str11 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('", this.ViewState["IfZb"].ToString(), "','", this.Number.Text, "','自由流程','", str, "", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')" });
                this.List.ExeSql(str11);
            }
            string sql = string.Concat(new object[] { "Update qp_oa_AddWorkFlow  Set  Name='", this.whname.Text, "',State='正在办理', FileContent='", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "',UpTimeSet='", DateTime.Now.ToString(), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), "自由流程", "办理工作" + this.whname.Text + "", this.ViewState["IfZb"].ToString());
            string str13 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='已办结' ,EndTime='", DateTime.Now.ToString(), "'  where KeyFile='", this.Number.Text, "' and BLusername='", this.Session["username"], "' and XuHao='", this.ViewState["UpNodeNums"], "' and GlNum='", this.GlNum.Text, "' and States!='已委托'" });
            this.List.ExeSql(str13);
            string str14 = "select  * from qp_oa_FormFile where KeyFile='" + this.ViewState["FormNumber"] + "' and  (type='[常规型]' or type='[数字型]')   order by id asc";
            SqlDataReader list = this.List.GetList(str14);
            while (list.Read())
            {
                string str15 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowFileKey  Set  Content='", base.Request.Form["" + list["Number"] + ""], "'  where AddNumber='", this.Number.Text, "' and Number='", list["Number"], "'" });
                this.List.ExeSql(str15);
            }
            list.Close();
            base.Response.Write("<script language=javascript>alert('办理完毕！');window.opener.location.href='WorkFlowList_ybj.aspx';window.close();</script>");
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
            string sql = "select * from qp_oa_AddWorkFlowMessage  where Number='" + this.Number.Text + "' order by id asc";
            this.GridView1.DataSource = this.List.GetGrid_Pages_not(sql);
            this.GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            DataControlRowType rowType = e.Row.RowType;
            if ((e.Row.RowType == DataControlRowType.Header) || (e.Row.RowType == DataControlRowType.DataRow))
            {
                e.Row.Attributes["onmouseover"] = "javascript:setMouseOverColor(this);";
                e.Row.Attributes["onmouseout"] = "javascript:setMouseOutColor(this);";
            }
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
                    string sQL = "select Newname,Name+'('+YxType+')' as Name  from qp_oa_YinZhang where Username='" + this.Session["Username"] + "' and  State='正常' ";
                    this.list.Bind_DropDownList(this.Yinzhang, sQL, "Newname", "Name");
                    this.BindAttribute();
                    string sql = "select * from qp_oa_AddWorkFlow where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                    SqlDataReader reader = this.List.GetList(sql);
                    if (reader.Read())
                    {
                        string str13;
                        SqlDataReader reader7;
                        string str15;
                        this.GlNum.Text = reader["GlNum"].ToString();
                        string str3 = string.Concat(new object[] { "Update qp_oa_AddWorkFlowPicRy  Set States='办理中'   where KeyFile='", reader["Number"].ToString(), "' and BLusername='", this.Session["username"], "' and XuHao='", reader["UpNodeNum"], "' and GlNum='", reader["GlNum"].ToString(), "'" });
                        this.List.ExeSql(str3);
                        string str4 = string.Concat(new object[] { "select IfZb from qp_oa_AddWorkFlowPicRy where KeyFile='", reader["Number"].ToString(), "' and BLusername='", this.Session["username"], "'  and XuHao='", reader["UpNodeNum"], "' and GlNum='", reader["GlNum"].ToString(), "'" });
                        SqlDataReader reader2 = this.List.GetList(str4);
                        if (reader2.Read())
                        {
                            this.ViewState["IfZb"] = reader2["IfZb"].ToString();
                        }
                        else
                        {
                            base.Response.Write("<script language=javascript>alert('没有操作权限！');window.location = '/main_d.aspx'</script>");
                            return;
                        }
                        reader2.Close();
                        this.JinJiChengDu.Text = this.pulicss.SystemCode("10", reader["JinJiChengDu"].ToString());
                        this.whname.Text = reader["Name"].ToString();
                        this.ViewState["ShuXing"] = reader["ShuXing"].ToString();
                        this.ViewState["lshid"] = int.Parse(reader["Sequence"].ToString());
                        this.Number.Text = reader["Number"].ToString();
                        this.ViewState["Numbers"] = reader["Number"].ToString();
                        this.ViewState["UpNodeNums"] = reader["UpNodeNum"].ToString();
                        this.ViewState["FormName"] = reader["FormName"].ToString();
                        this.ViewState["FormNumber"] = reader["FormNumber"].ToString();
                        this.ContractContent.Text = this.pulicss.GetFormatStrbjq_show(this.showform.FormatKjStrZh(reader["FileContent"].ToString()));
                        this.TextBox1.Text = this.pulicss.GetFormatStrbjq_show(this.showform.FormatKjStrZh(reader["FileContent"].ToString()));
                        this.GqUpNodeNumKey.Text = reader["UpNodeNum"].ToString();
                        this.ViewState["NodeSite"] = reader["NodeSite"].ToString();
                        this.ViewState["UpNodeName"] = reader["UpNodeName"].ToString();
                        string str5 = null;
                        string str6 = "select * from qp_oa_FormFile where  leixing='1' and KeyFile='" + this.ViewState["FormNumber"] + "'";
                        SqlDataReader reader3 = this.List.GetList(str6);
                        while (reader3.Read())
                        {
                            str5 = (str5 + "<script>function js" + reader3["Number"].ToString() + "(){myvalue=") + reader3["sqlstr"].ToString();
                            string str7 = null;
                            str7 = "" + reader3["sqlstr"].ToString().Replace("(", "").Replace(")", "").Replace("+", ",").Replace("-", ",").Replace("*", ",").Replace("/", ",") + "";
                            ArrayList list = new ArrayList();
                            string[] strArray = str7.Split(new char[] { ',' });
                            for (int i = 0; i < strArray.Length; i++)
                            {
                                string str8 = string.Concat(new object[] { "select Number,Name from qp_oa_FormFile where  KeyFile='", this.ViewState["FormNumber"], "' and Name='", strArray[i], "'" });
                                SqlDataReader reader4 = this.List.GetList(str8);
                                if (reader4.Read())
                                {
                                    str5 = str5.Replace(reader4["Name"].ToString(), "parseFloat(document.getElementById(\"" + reader4["Number"].ToString() + "\").value)");
                                }
                                reader4.Close();
                            }
                            str15 = str5;
                            str5 = str15 + ";if(!isNaN(myvalue))document.getElementById(\"" + reader3["Number"].ToString() + "\").value=Math.round(myvalue * 100)/100;else document.getElementById(\"" + reader3["Number"].ToString() + "\").value=\"\";}</script>";
                        }
                        reader3.Close();
                        this.ViewState["jisuan"] = str5;
                        string str9 = null;
                        string str10 = "select * from qp_oa_FormFile where  leixing='2' and KeyFile='" + this.ViewState["FormNumber"] + "'";
                        SqlDataReader reader5 = this.List.GetList(str10);
                        while (reader5.Read())
                        {
                            str15 = str9;
                            str9 = str15 + "<SCRIPT>setInterval(\"sum('" + reader5["sqlstr"].ToString() + "','" + reader5["Number"].ToString() + "')\",1000);</SCRIPT>";
                        }
                        reader5.Close();
                        this.ViewState["liebiaoqh"] = str9;
                        string str11 = null;
                        string str12 = "select * from qp_oa_FormFile where  Type='[列表]' and KeyFile='" + this.ViewState["BDNumber"] + "'";
                        SqlDataReader reader6 = this.List.GetList(str12);
                        while (reader6.Read())
                        {
                            str15 = str11;
                            str11 = str15 + "<SCRIPT>setInterval(\"tb_cal('T" + reader6["Number"].ToString() + "T','" + reader6["sqlstr"].ToString() + "')\",1000);</SCRIPT>";
                        }
                        reader6.Close();
                        this.ViewState["liebiao"] = str11;
                        if (this.ViewState["IfZb"].ToString() == "主办")
                        {
                            str13 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowPicRy where KeyFile='", reader["Number"].ToString(), "' and BLusername!='", this.Session["username"], "' and XuHao='", reader["UpNodeNum"], "' and  (States!='已办结' and States!='已委托') and GlNum='", this.GlNum.Text, "'" });
                            reader7 = this.List.GetList(str13);
                            if (reader7.Read())
                            {
                                if (this.ViewState["UpNodeName"].ToString() == "1")
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
                            reader7.Close();
                        }
                        else if (this.ViewState["NodeSite"].ToString() == "1")
                        {
                            this.Button1.Visible = true;
                        }
                        else if (this.ViewState["NodeSite"].ToString() == "2")
                        {
                            str13 = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowPicRy where KeyFile='", reader["Number"].ToString(), "' and BLusername!='", this.Session["username"], "' and XuHao='", reader["UpNodeNum"], "' and  (States!='已办结' and States!='已委托') and GlNum='", this.GlNum.Text, "'" });
                            reader7 = this.List.GetList(str13);
                            if (reader7.Read())
                            {
                                this.Button1.Visible = false;
                            }
                            else
                            {
                                this.Button1.Visible = true;
                                this.Wanbi.Visible = false;
                            }
                            reader7.Close();
                        }
                        else
                        {
                            this.Button1.Visible = false;
                        }
                    }
                    reader.Close();
                    this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), "自由流程", "查看工作" + this.whname.Text + "", this.ViewState["IfZb"].ToString());
                    this.ViewState["YzSealNumber"] = this.Number.Text;
                    string str14 = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id asc";
                    this.list.Bind_DropDownList(this.normalcontent, str14, "Content", "Content");
                    this.DataBindToGridview();
                }
                this.BindFjlbList();
            }
        }
    }
}

