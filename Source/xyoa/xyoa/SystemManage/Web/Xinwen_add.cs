﻿namespace xyoa.SystemManage.Web
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Xinwen_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlTextArea d_content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Titles;

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_web_Xinwen (Titles,Content,Shijian) values ('" + this.pulicss.GetFormatStr(this.Titles.Text) + "','" + this.pulicss.GetFormatStrbjq(this.d_content.Value) + "','" + DateTime.Now.ToString() + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增单位新闻", "门户网站设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Xinwen.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Xinwen.aspx");
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
