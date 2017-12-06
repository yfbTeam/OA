namespace xyoa.SystemManage.Web
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Zhuangtai : Page
    {
        protected Button Button1;
        protected RadioButtonList Content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        private publics pulicss = new publics();

        public void BindAttribute()
        {
            this.Button1.Attributes["onclick"] = "javascript:return chknull();";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = "Update qp_web_Zhuangtai  Set Content='" + this.Content.SelectedValue + "'";
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("设置门户网站状态", "门户网站状态");
            base.Response.Write("<script language=javascript>alert('提交成功');</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = "select * from qp_web_Zhuangtai";
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Content.SelectedValue = list["Content"].ToString();
                }
                list.Close();
                this.BindAttribute();
            }
        }
    }
}

