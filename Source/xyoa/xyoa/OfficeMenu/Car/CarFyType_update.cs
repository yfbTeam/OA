﻿namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarFyType_update : Page
    {
        protected Button Button1;
        protected Button Button2;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Name;
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            this.Button2.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_CarFyType  Set Name='", this.pulicss.GetFormatStr(this.Name.Text), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改费用类型", "费用类型");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='CarFyType.aspx'</script>");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CarFyType.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_CarFyType where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Name.Text = list["Name"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

