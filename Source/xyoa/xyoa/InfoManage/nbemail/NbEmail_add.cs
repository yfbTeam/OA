﻿namespace xyoa.InfoManage.nbemail
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Collections;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class NbEmail_add : Page
    {
        protected Button Button1;
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected Button Button6;
        protected FCKeditor Content;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox JsRealname;
        protected TextBox JsUsername;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox SeadTime;
        protected TextBox SendName;
        protected TextBox titles;
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.SendName.Attributes.Add("readonly", "readonly");
            this.SeadTime.Attributes.Add("readonly", "readonly");
            this.JsRealname.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button6.Attributes["onclick"] = "javascript:return zcchknull();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button12.Attributes["onclick"] = "javascript:return openfile();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = null;
            string str2 = null;
            str2 = "" + this.JsUsername.Text + "";
            ArrayList list = new ArrayList();
            string[] strArray = str2.Split(new char[] { ',' });
            for (int i = 0; i < strArray.Length; i++)
            {
                str = str + "'" + strArray[i] + "',";
            }
            str = str + "'0'";
            string sql = "select username,realname from qp_oa_Username where  username in (" + str + ") ";
            SqlDataReader reader = this.List.GetList(sql);
            while (reader.Read())
            {
                string str4 = string.Concat(new object[] { 
                    "insert into qp_oa_NbEmail_sj  (Number,Titles,Content,JsUsername,JsRealname,IfRead,IfDel,FsUsername,FsRealname,FsTime) values ('", this.Number.Text, "','", this.pulicss.GetFormatStr(this.titles.Text), "','", this.pulicss.GetFormatStrbjq(this.Content.Value), "','", reader["username"], "','", reader["realname"], "','0','0','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                    "')"
                 });
                this.List.ExeSql(str4);
                this.pulicss.InsertMessage(string.Concat(new object[] { "您有内部邮件需要接收：", this.pulicss.GetFormatStr(this.titles.Text), "，发送人：", this.Session["realname"], "" }), reader["username"].ToString(), reader["realname"].ToString(), "/InfoManage/nbemail/NbEmail_sj.aspx");
            }
            reader.Close();
            string str5 = string.Concat(new object[] { 
                "insert into qp_oa_NbEmail_fj  (Number,Titles,Content,JsUsername,JsRealname,FsUsername,FsRealname,FsTime) values ('", this.Number.Text, "','", this.pulicss.GetFormatStr(this.titles.Text), "','", this.pulicss.GetFormatStrbjq(this.Content.Value), "','", this.JsUsername.Text, "','", this.JsRealname.Text, "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                "')"
             });
            this.List.ExeSql(str5);
            this.pulicss.InsertLog("发送内部邮件", "内部邮件");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='NbEmail_fj.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("NbEmail_sj.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("email/");
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
                    this.pulicss.Insertfile(fileName, "InfoManage/nbemail/email/" + str2 + "", this.Number.Text, filetype);
                    this.pulicss.InsertLog("上传附件[" + fileName + "]", "内部邮件");
                    this.BindFjlbList();
                }
            }
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "insert into qp_oa_NbEmail_cg  (Number,Titles,Content,JsUsername,JsRealname,FsUsername,FsRealname,FsTime) values ('", this.Number.Text, "','", this.pulicss.GetFormatStr(this.titles.Text), "','", this.pulicss.GetFormatStrbjq(this.Content.Value), "','", this.JsUsername.Text, "','", this.JsRealname.Text, "','", this.Session["username"], "','", this.Session["realname"], "','", DateTime.Now.ToString(), 
                "')"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("暂存内部邮件", "内部邮件");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='NbEmail_cg.aspx'</script>");
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
                    SqlDataReader list;
                    string str3;
                    SqlDataReader reader2;
                    Random random = new Random();
                    string str = random.Next(0x2710).ToString();
                    this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                    this.SendName.Text = this.Session["realname"].ToString();
                    this.SeadTime.Text = DateTime.Now.ToString();
                    if ((base.Request.QueryString["user"] != null) && (base.Request.QueryString["backid"] != null))
                    {
                        str2 = "select username,realname from qp_oa_username where username='" + this.pulicss.GetFormatStr(base.Request.QueryString["user"]) + "'";
                        list = this.List.GetList(str2);
                        if (list.Read())
                        {
                            this.JsUsername.Text = "" + list["username"].ToString() + ",";
                            this.JsRealname.Text = "" + list["realname"].ToString() + ",";
                        }
                        list.Close();
                        str3 = string.Concat(new object[] { "select * from qp_oa_NbEmail_sj where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["backid"]), "' and (JsUsername='", this.Session["username"], "')" });
                        reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            this.titles.Text = "回复：" + reader2["Titles"] + "";
                            this.Content.Value = "<DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV>------------------ 来文信息 ------------------</DIV>" + reader2["Content"].ToString() + "";
                        }
                        reader2.Close();
                    }
                    if ((base.Request.QueryString["user"] != null) && (base.Request.QueryString["tyid"] != null))
                    {
                        str2 = "select username,realname from qp_oa_username where username='" + this.pulicss.GetFormatStr(base.Request.QueryString["user"]) + "'";
                        list = this.List.GetList(str2);
                        if (list.Read())
                        {
                            this.JsUsername.Text = "" + list["username"].ToString() + ",";
                            this.JsRealname.Text = "" + list["realname"].ToString() + ",";
                        }
                        list.Close();
                        str3 = string.Concat(new object[] { "select * from qp_oa_NbEmail_sj where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["tyid"]), "' and (JsUsername='", this.Session["username"], "')" });
                        reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            this.titles.Text = "" + reader2["Titles"] + "";
                            this.Content.Value = "<DIV>&nbsp;</DIV><DIV><font color=red>--------同意！---------</font></DIV><DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV>------------------ 来文信息 ------------------</DIV>" + reader2["Content"].ToString() + "";
                        }
                        reader2.Close();
                    }
                    if ((base.Request.QueryString["user"] != null) && (base.Request.QueryString["btyid"] != null))
                    {
                        str2 = "select username,realname from qp_oa_username where username='" + this.pulicss.GetFormatStr(base.Request.QueryString["user"]) + "'";
                        list = this.List.GetList(str2);
                        if (list.Read())
                        {
                            this.JsUsername.Text = "" + list["username"].ToString() + ",";
                            this.JsRealname.Text = "" + list["realname"].ToString() + ",";
                        }
                        list.Close();
                        str3 = string.Concat(new object[] { "select * from qp_oa_NbEmail_sj where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["btyid"]), "' and (JsUsername='", this.Session["username"], "')" });
                        reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            this.titles.Text = "" + reader2["Titles"] + "";
                            this.Content.Value = "<DIV>&nbsp;</DIV><DIV><font color=red>--------不同意！---------</font></DIV><DIV><font color=blue>原因：</font></DIV><DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV>------------------ 来文信息 ------------------</DIV>" + reader2["Content"].ToString() + "";
                        }
                        reader2.Close();
                    }
                    if (base.Request.QueryString["zfid"] != null)
                    {
                        str3 = string.Concat(new object[] { "select * from qp_oa_NbEmail_sj where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["zfid"]), "' and (JsUsername='", this.Session["username"], "')" });
                        reader2 = this.List.GetList(str3);
                        if (reader2.Read())
                        {
                            string sql = "select * from qp_oa_fileupload where  KeyField='" + reader2["Number"].ToString() + "'";
                            SqlDataReader reader3 = this.List.GetList(sql);
                            while (reader3.Read())
                            {
                                this.pulicss.Insertfile(reader3["Name"].ToString(), reader3["NewName"].ToString(), this.Number.Text, reader3["filetype"].ToString());
                            }
                            reader3.Close();
                            this.titles.Text = "转发：" + reader2["Titles"] + "";
                            this.Content.Value = "<DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV>&nbsp;</DIV><DIV>------------------ 原始邮件 ------------------</DIV>" + reader2["Content"].ToString() + "";
                        }
                        reader2.Close();
                    }
                    this.BindAttribute();
                }
                this.BindFjlbList();
            }
        }
    }
}

