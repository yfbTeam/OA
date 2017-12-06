﻿namespace xyoa.SchTable.Chengji.Dengdi
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Dengdi_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Jieshu;
        protected TextBox Kaishi;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Number;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_sch_Dengdi     Set Name='", this.pulicss.GetFormatStr(this.Name.Text), "',Kaishi='", this.pulicss.GetFormatStr(this.Kaishi.Text), "',Jieshu='", this.pulicss.GetFormatStr(this.Jieshu.Text), "' where   id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改分数等第转换[" + this.Name.Text + "]", "分数等第转换");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='Dengdi.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Dengdi.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_sch_Dengdi where  id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                    this.Kaishi.Text = list["Kaishi"].ToString();
                    this.Jieshu.Text = list["Jieshu"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}
