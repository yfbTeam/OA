﻿namespace xyoa.HumanResources.ZhaoPin.QuDao
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class QuDao_update : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected TextBox Chengshi;
        protected TextBox Dianhua;
        protected TextBox Dizhi;
        protected TextBox Email;
        protected HtmlForm form1;
        protected TextBox Fuzeren;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Mingcheng;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Youbian;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_hr_QuDao   Set Mingcheng='", this.pulicss.GetFormatStr(this.Mingcheng.Text), "',Fuzeren='", this.pulicss.GetFormatStr(this.Fuzeren.Text), "',Dianhua='", this.pulicss.GetFormatStr(this.Dianhua.Text), "',Email='", this.pulicss.GetFormatStr(this.Email.Text), "',Chengshi='", this.pulicss.GetFormatStr(this.Chengshi.Text), "',Youbian='", this.pulicss.GetFormatStr(this.Youbian.Text), "',Dizhi='", this.pulicss.GetFormatStr(this.Dizhi.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), 
                "'  where id='", int.Parse(base.Request.QueryString["id"]), "'"
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改招聘渠道", "招聘渠道");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='QuDao.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_hr_QuDao where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Mingcheng.Text = list["Mingcheng"].ToString();
                    this.Fuzeren.Text = list["Fuzeren"].ToString();
                    this.Dianhua.Text = list["Dianhua"].ToString();
                    this.Email.Text = list["Email"].ToString();
                    this.Chengshi.Text = list["Chengshi"].ToString();
                    this.Youbian.Text = list["Youbian"].ToString();
                    this.Dizhi.Text = list["Dizhi"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}
