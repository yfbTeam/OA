namespace xyoa.SystemManage.login
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class login : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected DropDownList Uses;
        protected DropDownList Yzm;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_LoginMade  Set Yzm='" + this.Yzm.SelectedValue + "',Uses='" + this.Uses.SelectedValue + "'";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改登陆设置", "登陆设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='login.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.pulicss.QuanXianBack("iiiia4", this.Session["perstr"].ToString());
                string sql = "select * from qp_oa_LoginMade";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Yzm.SelectedValue = list["Yzm"].ToString();
                    this.Uses.SelectedValue = list["Uses"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

