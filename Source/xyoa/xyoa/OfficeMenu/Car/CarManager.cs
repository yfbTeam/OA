namespace xyoa.OfficeMenu.Car
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class CarManager : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected TextBox Realname;
        protected TextBox Username;

        public void BindAttribute()
        {
            this.Realname.Attributes.Add("readonly", "readonly");
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_oa_CarManager  Set Username='" + this.Username.Text + "' ,Realname='" + this.Realname.Text + "'";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("更新调度员", "调度员设置");
            base.Response.Write("<script language=javascript>alert('提交成功！');</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_oa_CarManager ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Username.Text = list["Username"].ToString();
                    this.Realname.Text = list["Realname"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

