namespace xyoa.HumanResources
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkTimeQy : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected DropDownList qiyong;

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return showwait();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_WorkTimeQy   Set qiyong='" + this.qiyong.SelectedValue + "'";
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.location.href='WorkTimeQy.aspx'</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '../main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_WorkTimeQy ";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.qiyong.SelectedValue = list["qiyong"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

