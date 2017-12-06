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

    public class AddWorkFlow_add_zy : Page
    {
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button6;
        protected Button Button8;
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
        protected DropDownList JinJiChengDu;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected DropDownList normalcontent;
        protected TextBox Number;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected TextBox SpContent;
        protected TextBox TextBox1;
        protected HtmlInputFile uploadFile;
        protected TextBox wdname;
        protected TextBox whname;
        protected DropDownList Yinzhang;

        public void BindAttribute()
        {
            this.Button6.Attributes["onclick"] = "javascript:return AddFile();";
            this.Button8.Attributes["onclick"] = "javascript:return showwait();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button2.Attributes["onclick"] = "javascript:return openfile();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
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

        protected void Button8_Click(object sender, EventArgs e)
        {
            string str12;
            string sql = "select top 1 id from qp_oa_AddWorkFlow order by id desc";
            SqlDataReader list = this.List.GetList(sql);
            if (list.Read())
            {
                this.ViewState["lshid"] = int.Parse(list["id"].ToString()) + 1;
            }
            else
            {
                this.ViewState["lshid"] = 1;
            }
            list.Close();
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
                Random random = new Random();
                string str11 = random.Next(0x2710).ToString();
                str7 = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString() + str11;
                this.File1.PostedFile.SaveAs(str5 + str7 + extension);
                str6 = str7 + extension;
                str12 = string.Concat(new object[] { 
                    "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('主办','", this.Number.Text, "','", this.ViewState["NodeName"], "','", str2, "", this.SpContent.Text, "','", fileName, "','", str6, "','", this.Session["Username"], "','", this.Session["Realname"], 
                    "','", DateTime.Now.ToString(), "')"
                 });
                this.List.ExeSql(str12);
                this.pulicss.InsertLog("上传审批文件[" + fileName + "]", "工作管理");
            }
            else if ((this.SpContent.Text != "") || (this.Yinzhang.SelectedValue != "请选择"))
            {
                str12 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowMessage (ZbOrJb,Number,Buzhou,Content,OldName,NewName,Username,Realname,Settime) values ('主办','", this.Number.Text, "','", this.ViewState["NodeName"], "','", str2, "", this.SpContent.Text, "','','','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), "')" });
                this.List.ExeSql(str12);
            }
            string str13 = null;
            string str14 = null;
            string str15 = "select * from qp_oa_WorkFlowName where  FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'";
            SqlDataReader reader2 = this.List.GetList(str15);
            if (reader2.Read())
            {
                str13 = reader2["JkUsername"].ToString();
                str14 = reader2["JkRealname"].ToString();
                string str16 = "select * from qp_oa_DIYForm where Id='" + reader2["FormId"].ToString() + "'";
                SqlDataReader reader3 = this.List.GetList(str16);
                if (reader3.Read())
                {
                    string str17 = string.Concat(new object[] { 
                        "insert into qp_oa_AddWorkFlow (JinJiChengDu,GlNum,Ifdel,UpNodeNum,Shuxing,JkUsername,JkRealname,FormId,FormNumber,FormName,FlowId,FlowNumber,FlowName,Number,Sequence,Name,State,FileContent,FqUsername,FqRealname,YJBObjectId,YJBObjecName,ZbObjectId,ZbObjectName,LcNameId,Username,Realname,NowTimes,UpTimeSet) values ('", this.JinJiChengDu.SelectedValue, "','", this.GlNum.Text, "','0','1','自由流程','", str13, "','", str14, "','", reader3["id"], "','", reader3["Number"], "','", reader3["FormName"], "','", reader2["id"], 
                        "','", reader2["FlowNumber"], "','", reader2["FlowName"], "','", this.Number.Text, "','", this.ViewState["lshid"], "','", this.whname.Text, "','正在办理','", this.pulicss.GetFormatStrbjq(this.ContractContent.Text), "','", this.Session["username"], "','", this.Session["realname"], 
                        "','", this.Session["username"], ",','", this.Session["realname"], ",','", this.Session["username"], "','", this.Session["realname"], "','", this.ViewState["LcNameId"], "','", this.Session["Username"], "','", this.Session["Realname"], "','", DateTime.Now.ToString(), 
                        "','", DateTime.Now.ToString(), "')"
                     });
                    this.List.ExeSql(str17);
                }
                reader3.Close();
            }
            reader2.Close();
            Random random2 = new Random();
            string str18 = random2.Next(0x2710).ToString();
            string str19 = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str18 + "";
            string str20 = "insert into qp_oa_AddWorkFlowPic (GlNum,LcNum,KeyFile,XuHao,Jiedian) values ('" + this.GlNum.Text + "','" + str19 + "','" + this.Number.Text + "','1','')";
            this.List.ExeSql(str20);
            string str21 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowPicRy (GlNum,XuHao,LcNum,KeyFile,BLusername,BLrealname,StartTime,EndTime,States,IfZb) values ('", this.GlNum.Text, "','1','", str19, "','", this.Number.Text, "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), "','','办理中','主办')" });
            this.List.ExeSql(str21);
            this.showform.AddWorkFlowLog("110", this.Number.Text, this.ViewState["FormName"].ToString(), this.ViewState["NodeName"].ToString(), "新建工作" + this.whname.Text + "", "主办");
            string str22 = "select  * from qp_oa_FormFile where KeyFile='" + this.ViewState["FormNumber"] + "' and (type='[常规型]' or type='[数字型]')   order by id asc";
            SqlDataReader reader4 = this.List.GetList(str22);
            while (reader4.Read())
            {
                string str23 = string.Concat(new object[] { "insert into qp_oa_AddWorkFlowFileKey (keyid,AddNumber,KeyFile,Number,Content) values ('", reader4["id"], "','", this.Number.Text, "','", reader4["KeyFile"], "','", reader4["Number"], "','", base.Request.Form["" + reader4["Number"] + ""], "')" });
                this.List.ExeSql(str23);
            }
            reader4.Close();
            base.Response.Redirect("AddWorkFlow_add_Next_Zy.aspx?UpNodeNum=&FlowNumber=" + base.Request.QueryString["FlowNumber"] + "&FormId=" + base.Request.QueryString["FormId"] + "&Number=" + this.Number.Text + "");
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
                    string str2;
                    SqlDataReader reader2;
                    this.ViewState["NodeName"] = "";
                    this.BindAttribute();
                    string sql = "select top 1 id,LcNameId from qp_oa_AddWorkFlow where FlowNumber='" + base.Request.QueryString["FlowNumber"] + "' order by id desc";
                    SqlDataReader reader = this.List.GetList(sql);
                    if (reader.Read())
                    {
                        this.ViewState["LcNameId"] = int.Parse(reader["LcNameId"].ToString()) + 1;
                        str2 = "select Wenhao,BianhaoWs,FlowName,ShuXing,id from qp_oa_WorkFlowName where FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'";
                        reader2 = this.List.GetList(str2);
                        if (reader2.Read())
                        {
                            this.whname.Text = this.showform.FormatWh(reader2["Wenhao"].ToString(), this.ViewState["LcNameId"].ToString().PadLeft(int.Parse(reader2["BianhaoWs"].ToString()), '0'), reader2["BianhaoWs"].ToString(), reader2["FlowName"].ToString());
                        }
                        reader2.Close();
                    }
                    else
                    {
                        str2 = "select Wenhao,BianhaoWs,FlowName,BianhaoJs,BianhaoWs,ShuXing from qp_oa_WorkFlowName where FlowNumber='" + base.Request.QueryString["FlowNumber"] + "'";
                        reader2 = this.List.GetList(str2);
                        if (reader2.Read())
                        {
                            this.ViewState["LcNameId"] = int.Parse(reader2["BianhaoJs"].ToString());
                            this.whname.Text = this.showform.FormatWh(reader2["Wenhao"].ToString(), this.ViewState["LcNameId"].ToString().PadLeft(int.Parse(reader2["BianhaoWs"].ToString()), '0'), reader2["BianhaoWs"].ToString(), reader2["FlowName"].ToString());
                        }
                        reader2.Close();
                    }
                    reader.Close();
                    string str3 = "select top 1 id from qp_oa_AddWorkFlow order by id desc";
                    SqlDataReader reader3 = this.List.GetList(str3);
                    if (reader3.Read())
                    {
                        this.ViewState["lshid"] = int.Parse(reader3["id"].ToString()) + 1;
                    }
                    else
                    {
                        this.ViewState["lshid"] = 1;
                    }
                    reader3.Close();
                    string str4 = "select * from qp_oa_DIYForm where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["FormId"]) + "'";
                    SqlDataReader reader4 = this.List.GetList(str4);
                    if (reader4.Read())
                    {
                        string str19;
                        this.ViewState["FormName"] = reader4["FormName"].ToString();
                        this.ViewState["FormNumber"] = reader4["Number"].ToString();
                        string str5 = null;
                        string str6 = "select * from qp_oa_FormFile where  leixing='1' and KeyFile='" + this.ViewState["FormNumber"] + "'";
                        SqlDataReader reader5 = this.List.GetList(str6);
                        while (reader5.Read())
                        {
                            str5 = (str5 + "<script>function js" + reader5["Number"].ToString() + "(){myvalue=") + reader5["sqlstr"].ToString();
                            string str7 = null;
                            str7 = "" + reader5["sqlstr"].ToString().Replace("(", "").Replace(")", "").Replace("+", ",").Replace("-", ",").Replace("*", ",").Replace("/", ",") + "";
                            ArrayList list = new ArrayList();
                            string[] strArray = str7.Split(new char[] { ',' });
                            for (int i = 0; i < strArray.Length; i++)
                            {
                                string str8 = string.Concat(new object[] { "select Number,Name from qp_oa_FormFile where  KeyFile='", this.ViewState["FormNumber"], "' and Name='", strArray[i], "'" });
                                SqlDataReader reader6 = this.List.GetList(str8);
                                if (reader6.Read())
                                {
                                    str5 = str5.Replace(reader6["Name"].ToString(), "parseFloat(document.getElementById(\"" + reader6["Number"].ToString() + "\").value)");
                                }
                                reader6.Close();
                            }
                            str19 = str5;
                            str5 = str19 + ";if(!isNaN(myvalue))document.getElementById(\"" + reader5["Number"].ToString() + "\").value=Math.round(myvalue * 100)/100;else document.getElementById(\"" + reader5["Number"].ToString() + "\").value=\"\";}</script>";
                        }
                        reader5.Close();
                        this.ViewState["jisuan"] = str5;
                        string str9 = null;
                        string str10 = "select * from qp_oa_FormFile where  leixing='2' and KeyFile='" + this.ViewState["FormNumber"] + "'";
                        SqlDataReader reader7 = this.List.GetList(str10);
                        while (reader7.Read())
                        {
                            str19 = str9;
                            str9 = str19 + "<SCRIPT>setInterval(\"sum('" + reader7["sqlstr"].ToString() + "','" + reader7["Number"].ToString() + "')\",1000);</SCRIPT>";
                        }
                        reader7.Close();
                        this.ViewState["liebiaoqh"] = str9;
                        string str11 = null;
                        string str12 = "select * from qp_oa_FormFile where  Type='[列表]' and KeyFile='" + this.ViewState["FormNumber"] + "'";
                        SqlDataReader reader8 = this.List.GetList(str12);
                        while (reader8.Read())
                        {
                            str19 = str11;
                            str11 = str19 + "<SCRIPT>setInterval(\"tb_cal('T" + reader8["Number"].ToString() + "T','" + reader8["sqlstr"].ToString() + "')\",1000);</SCRIPT>";
                        }
                        reader8.Close();
                        this.ViewState["liebiao"] = str11;
                        string aStr = "";
                        this.ContractContent.Text = this.showform.FormatKjStrZh(reader4["FormContent"].ToString());
                        this.TextBox1.Text = this.showform.FormatKjStrZh(reader4["FormContent"].ToString());
                        string str14 = "select * from qp_oa_FormFile where  KeyFile='" + reader4["Number"].ToString() + "'";
                        SqlDataReader reader9 = this.List.GetList(str14);
                        while (reader9.Read())
                        {
                            string str15 = "";
                            aStr = this.ContractContent.Text;
                            str15 = this.pulicss.GetFormatStrbjq_show(this.showform.FormatKjStrH(reader9["Number"].ToString(), "0", aStr, this.ViewState["FormName"].ToString(), "" + this.whname.Text + "", DateTime.Now.ToShortDateString(), DateTime.Now.ToString(), int.Parse(this.ViewState["lshid"].ToString())));
                            this.ContractContent.Text = str15;
                            this.TextBox1.Text = str15;
                        }
                        reader9.Close();
                    }
                    reader4.Close();
                    Random random = new Random();
                    string str16 = random.Next(0x2710).ToString();
                    this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str16 + "";
                    this.GlNum.Text = "" + DateTime.Now.Millisecond.ToString() + "" + str16 + "";
                    this.ViewState["YzSealNumber"] = this.Number.Text;
                    string sQL = "select Content from qp_oa_SpBeiZhu where Username='" + this.Session["username"].ToString() + "' order by id asc";
                    this.list.Bind_DropDownList(this.normalcontent, sQL, "Content", "Content");
                    string str18 = "select Newname,Name+'('+YxType+')' as Name  from qp_oa_YinZhang where Username='" + this.Session["Username"] + "' and  State='正常' ";
                    this.list.Bind_DropDownList(this.Yinzhang, str18, "Newname", "Name");
                }
                this.BindFjlbList();
            }
        }
    }
}

