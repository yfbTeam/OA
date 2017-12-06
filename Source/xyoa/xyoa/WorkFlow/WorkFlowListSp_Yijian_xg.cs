namespace xyoa.WorkFlow
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class WorkFlowListSp_Yijian_xg : Page
    {
        protected Button Button1;
        protected TextBox Content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        protected TextBox KhId;
        private Db List = new Db();
        private publics pulicss = new publics();

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_AddWorkFlowMessage  Set Content='", this.pulicss.GetFormatStr(this.Content.Text), "' where id='", int.Parse(base.Request.QueryString["id"]), "' and username='", this.Session["Username"], "'" });
            this.List.ExeSql(sql);
            base.Response.Write("<script language=javascript>alert('提交成功！');window.close()</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                this.Button1.Attributes["onclick"] = "javascript:return chknull();";
                string sql = string.Concat(new object[] { "select * from qp_oa_AddWorkFlowMessage where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and username='", this.Session["Username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Content.Text = list["Content"].ToString();
                }
                else
                {
                    base.Response.Write("<script language=javascript>alert('无数据！');window.close()</script>");
                }
                list.Close();
            }
        }
    }
}

