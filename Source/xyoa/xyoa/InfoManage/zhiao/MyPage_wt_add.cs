﻿namespace xyoa.InfoManage.zhiao
{
    using qiupeng.form;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyPage_wt_add : Page
    {
        protected Button Button1;
        protected Button Button12;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected TextBox Content;
        public string fjkey;
        protected DropDownList fjlb;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Leibie;
        protected TextBox LeibieName;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        private divform showform = new divform();
        protected HtmlInputFile uploadFile;
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.LeibieName.Attributes.Add("readonly", "readonly");
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button4.Attributes["onclick"] = "javascript:return checkForm();";
            this.Button3.Attributes["onclick"] = "javascript:return delfj();";
            this.Button12.Attributes["onclick"] = "javascript:return openfile();";
        }

        public void BindFjlbList()
        {
            string sQL = "select * from qp_oa_fileupload where KeyField='" + this.Number.Text + "'";
            this.list.Bind_DropDownList_nothing(this.fjlb, sQL, "NewName", "Name");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_Zst_wenti  (tuijian,Number,Leibie,Zhuti,Neirong,Username,Realname,Settimes,UsernameHd,RealnameHd,Dianji,Huida,jiejue) values ('2','" + this.pulicss.GetFormatStr(this.Number.Text) + "','" + this.pulicss.GetFormatStr(this.Leibie.Text) + "','" + this.pulicss.GetFormatStr(this.Zhuti.Text) + "','" + this.pulicss.GetFormatStr(this.Content.Text) + "','" + this.Session["Username"].ToString() + "','" + this.Session["Realname"].ToString() + "','" + DateTime.Now.ToString() + "','','','0','0','2')";
            this.List.ExeSql(sql);
            string str2 = string.Concat(new object[] { "Update qp_oa_username  Set jifen=jifen", this.pulicss.JifenGuize("新增问题"), "  where username='", this.Session["username"], "'" });
            this.List.ExeSql(str2);
            this.pulicss.InsertLog("新增知识堂问题", "知识堂问题");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyPage_wt.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyPage_wt.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("wenti/");
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
                    this.pulicss.Insertfile(fileName, "InfoManage/zhiao/wenti/" + str2 + "", this.Number.Text, filetype);
                    this.BindFjlbList();
                }
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
                    Random random = new Random();
                    string str = random.Next(0x2710).ToString();
                    this.Number.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Day.ToString() + "" + DateTime.Now.Hour.ToString() + "" + DateTime.Now.Minute.ToString() + "" + DateTime.Now.Second.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str + "";
                    this.BindAttribute();
                }
                this.BindFjlbList();
            }
        }
    }
}

