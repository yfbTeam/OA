﻿namespace xyoa.SystemManage.login
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class face : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected Button Button4;
        protected CheckBox CheckBox1;
        protected CheckBox CheckBox2;
        protected CheckBox CheckBox3;
        protected HtmlInputFile File1;
        protected HtmlInputFile File2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected Image JmBg;
        protected Image JmText;
        private Db List = new Db();
        protected Image Logos;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Titles;
        protected HtmlInputFile uploadFile;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_FaceMade  Set Titles='" + this.Titles.Text + "'";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("更新界面设置", "界面设置");
            base.Response.Write("<script language=javascript>alert('更新成功！');</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/LoginBg/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.File1.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.File1.PostedFile.FileName));
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
                    this.File1.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string sql = "Update qp_oa_FaceMade  Set JmText='" + str2 + "'";
                    this.List.ExeSql(sql);
                    this.pulicss.InsertLog("更新界面设置", "界面设置");
                    base.Response.Write("<script language=javascript>alert('更新成功！');window.location.href='face.aspx'</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请浏览更新图片！');</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/LoginBg/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.File2.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.File2.PostedFile.FileName));
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
                    this.File2.PostedFile.SaveAs(str + str3 + extension);
                    str2 = str3 + extension;
                    string sql = "Update qp_oa_FaceMade  Set Logos='" + str2 + "'";
                    this.List.ExeSql(sql);
                    this.pulicss.InsertLog("更新界面设置", "界面设置");
                    base.Response.Write("<script language=javascript>alert('更新成功！');window.location.href='face.aspx'</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请浏览更新图片！');</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string str = base.Server.MapPath("/LoginBg/");
            string str2 = string.Empty;
            string str3 = string.Empty;
            if (this.uploadFile.PostedFile.ContentLength != 0)
            {
                string extension = Path.GetExtension(Path.GetFileName(this.uploadFile.PostedFile.FileName));
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
                    string sql = "Update qp_oa_FaceMade  Set JmBg='" + str2 + "'";
                    this.List.ExeSql(sql);
                    this.pulicss.InsertLog("更新界面设置", "界面设置");
                    base.Response.Write("<script language=javascript>alert('更新成功！');window.location.href='face.aspx'</script>");
                }
            }
            else
            {
                base.Response.Write("<script language=javascript>alert('请浏览更新图片！');</script>");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("iiiia5", this.Session["perstr"].ToString());
                string sql = "select * from qp_oa_FaceMade";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Titles.Text = list["Titles"].ToString();
                    this.JmBg.ImageUrl = "/LoginBg/" + list["JmBg"].ToString() + "";
                    this.JmText.ImageUrl = "/LoginBg/" + list["JmText"].ToString() + "";
                    this.Logos.ImageUrl = "/LoginBg/" + list["Logos"].ToString() + "";
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

