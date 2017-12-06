﻿namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class DriverManager_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox MoveTel;
        private publics pulicss = new publics();
        protected TextBox Realname;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_DriverManager (Realname,MoveTel) values ('" + this.pulicss.GetFormatStr(this.Realname.Text) + "','" + this.pulicss.GetFormatStr(this.MoveTel.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增驾驶员[" + this.Realname.Text + "]", "驾驶员管理");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='DriverManager.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("DriverManager.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
            }
        }
    }
}

