﻿namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class DriverManager_update : Page
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
            string sql = string.Concat(new object[] { "Update qp_oa_DriverManager  Set Realname='", this.pulicss.GetFormatStr(this.Realname.Text), "',  MoveTel='", this.pulicss.GetFormatStr(this.MoveTel.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改驾驶员[" + this.Realname.Text + "]", "驾驶员管理");
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
                string sql = "select * from qp_oa_DriverManager  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Realname.Text = list["Realname"].ToString();
                    this.MoveTel.Text = list["MoveTel"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

