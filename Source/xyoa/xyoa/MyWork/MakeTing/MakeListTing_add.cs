﻿namespace xyoa.MyWork.MakeTing
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MakeListTing_add : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected CheckBox CheckBox1;
        protected TextBox Content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();
        protected TextBox txtime;
        protected DropDownList Types;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "insert into qp_oa_MakeListTing (content,Username) values ('", this.pulicss.GetFormatStr(this.Content.Text), "','", this.Session["username"], "')" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增记事便签", "便签管理");
            if (this.CheckBox1.Checked)
            {
                this.pulicss.InsertNaoZhong("" + this.pulicss.GetFormatStr(this.Content.Text) + "", this.txtime.Text, this.Types.SelectedValue, "1", "0", "/MyWork/MakeTing/MakeListTing.aspx");
            }
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='MakeListTing.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("MakeListTing.aspx");
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

