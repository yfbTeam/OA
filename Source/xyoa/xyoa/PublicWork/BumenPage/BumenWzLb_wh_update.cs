﻿namespace xyoa.PublicWork.BumenPage
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class BumenWzLb_wh_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox Leixing;
        private Db List = new Db();
        protected TextBox paixun;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_BumenWzLb  Set Leixing='", this.pulicss.GetFormatStr(this.Leixing.Text), "',paixun='", this.pulicss.GetFormatStr(this.paixun.Text), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改文章类别[" + this.pulicss.GetFormatStr(this.Leixing.Text) + "]", "部门主页");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='BumenWzLb_wh.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["LeibieId"]) + "'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("BumenWzLb_wh.aspx?id=" + this.pulicss.GetFormatStr(base.Request.QueryString["LeibieId"]) + "");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_BumenWzLb where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Leixing.Text = list["Leixing"].ToString();
                    this.paixun.Text = list["paixun"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

