﻿namespace xyoa.HumanResources.ZhaoPin.LuYong
{
    using FredCK.FCKeditorV2;
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class LuYong_update : Page
    {
        protected DropDownList Bumen;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected FCKeditor Neirong;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox SetTimes;
        protected TextBox Xingming;
        protected DropDownList Zhiwei;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_hr_LuYong   Set Xingming='", this.pulicss.GetFormatStr(this.Xingming.Text), "',Bumen='", this.Bumen.SelectedValue, "',Zhiwei='", this.Zhiwei.SelectedValue, "',SetTimes='", this.pulicss.GetFormatStr(this.SetTimes.Text), "',Neirong='", this.pulicss.GetFormatStrbjq(this.Neirong.Value), "'  where id='", int.Parse(base.Request.QueryString["id"]), "'" });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改正式录用", "正式录用");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='LuYong.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.BindListkong("qp_oa_Bumen", this.Bumen, "", "order by Bianhao asc");
                string sQL = "select id,name  from qp_oa_Zhiwei order by id asc";
                this.list.Bind_DropDownList_kong(this.Zhiwei, sQL, "id", "name");
                string sql = "select * from qp_hr_LuYong where id='" + this.pulicss.GetFormatStr(base.Request.QueryString["id"]) + "'";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Xingming.Text = list["Xingming"].ToString();
                    this.Bumen.SelectedValue = list["Bumen"].ToString();
                    this.Zhiwei.SelectedValue = list["Zhiwei"].ToString();
                    this.SetTimes.Text = DateTime.Parse(list["SetTimes"].ToString()).ToShortDateString();
                    this.Neirong.Value = this.pulicss.GetFormatStrbjq_show(list["Neirong"].ToString());
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

