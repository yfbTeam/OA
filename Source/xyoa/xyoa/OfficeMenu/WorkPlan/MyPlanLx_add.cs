﻿namespace xyoa.OfficeMenu.WorkPlan
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyPlanLx_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Leixing;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_MyPlanLx (Leixing) values ('" + this.pulicss.GetFormatStr(this.Leixing.Text) + "')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增工作计划类型[" + this.pulicss.GetFormatStr(this.Leixing.Text) + "]", "工作计划类型");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MyPlanLx.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MyPlanLx.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.BindAttribute();
            }
        }
    }
}

