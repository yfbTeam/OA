﻿namespace xyoa.SystemManage.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class DIYForm_add_dx : Page
    {
        protected DropDownList Biankuan;
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox ITEM_SIZE;
        protected DropDownList Kongjian;
        private BindDrowDownList list = new BindDrowDownList();
        private Db List = new Db();
        protected TextBox Name;
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox TextBox2;
        protected DropDownList Type;
        protected TextBox Vaules;
        protected TextBox Windnum;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "insert into qp_oa_FormFile (KeyFile,Number,Name,Type,KxGuoLvUser,KxGuoLvName,BmGuoLvUser,BmGuoLvName) values ('" + this.Number.Text + "','" + this.TextBox2.Text + "','" + this.pulicss.GetFormatStr(this.Name.Text) + "','" + this.Type.SelectedValue + "','','','','')";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("新增表单字段[" + this.Name.Text + "]", "表单字段");
            base.Response.Write("<script language=javascript>window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Number.Text = base.Request.QueryString["Number"].ToString();
                string sQL = "select Number,Name+Type as aaa from qp_oa_FormFile where KeyFile='" + this.Number.Text + "' and Type='[常规型]' order by id asc";
                this.list.Bind_DropDownList_nothing(this.Kongjian, sQL, "Number", "aaa");
                if (!base.IsPostBack)
                {
                    Random random = new Random();
                    string str2 = random.Next(0x2710).ToString();
                    this.TextBox2.Text = "" + DateTime.Now.Year.ToString() + "" + DateTime.Now.Month.ToString() + "" + DateTime.Now.Millisecond.ToString() + "" + str2 + "";
                }
                this.BindAttribute();
            }
        }
    }
}

