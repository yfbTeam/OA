﻿namespace xyoa.HumanResources.Employee.YuangongTJ
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class YuangongTJ_update : Page
    {
        protected TextBox Beizhu;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected DropDownList Jieguo;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Miaoshu;
        private publics pulicss = new publics();
        protected TextBox RealnameYG;
        protected TextBox Shijian;
        protected TextBox UsernameYG;
        protected TextBox Zhuti;

        public void BindAttribute()
        {
            this.RealnameYG.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { 
                "Update qp_hr_YuangongTJ  Set UsernameYG='", this.UsernameYG.Text, "',RealnameYG='", this.pulicss.GetFormatStr(this.RealnameYG.Text), "',Zhuti='", this.pulicss.GetFormatStr(this.Zhuti.Text), "',Jieguo='", this.Jieguo.SelectedValue, "',Shijian='", this.pulicss.GetFormatStr(this.Shijian.Text), "',Miaoshu='", this.pulicss.GetFormatStr(this.Miaoshu.Text), "',Beizhu='", this.pulicss.GetFormatStr(this.Beizhu.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), 
                "'  "
             });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改技能信息", "技能信息");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='YuangongTJ.aspx'</script>");
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
                string sQL = "select id,Name from qp_hr_YuangongLx where Type=14 order by id asc";
                this.list.Bind_DropDownList_kong(this.Jieguo, sQL, "id", "Name");
                string sql = "select * from qp_hr_YuangongTJ  where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'  ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.UsernameYG.Text = list["UsernameYG"].ToString();
                    this.RealnameYG.Text = list["RealnameYG"].ToString();
                    this.Jieguo.SelectedValue = list["Jieguo"].ToString();
                    this.Zhuti.Text = list["Zhuti"].ToString();
                    this.Shijian.Text = list["Shijian"].ToString().Replace("00:00:00", "").Replace("1900-01-01", "").Replace("0:00:00", "").Replace("1900-1-1", "");
                    this.Miaoshu.Text = list["Miaoshu"].ToString();
                    this.Beizhu.Text = list["Beizhu"].ToString();
                }
                list.Close();
            }
        }
    }
}
