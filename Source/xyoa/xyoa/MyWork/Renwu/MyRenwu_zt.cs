namespace xyoa.MyWork.Renwu
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class MyRenwu_zt : Page
    {
        protected Button Button1;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected TextBox Number;
        private publics pulicss = new publics();
        protected DropDownList State;

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sql = string.Concat(new object[] { "Update qp_oa_Renwu  Set  State='", this.State.SelectedValue, "'  where id='", int.Parse(base.Request.QueryString["id"]), "'  and ZbUsername='", this.Session["username"], "'  " });
            this.List.ExeSql(sql);
            this.pulicss.InsertLog("修改状态", "我的任务");
            base.Response.Write("<script language=javascript>alert('提交成功！');window.opener.location.reload();window.close();</script>");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_oa_Renwu  where id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and  ZbUsername='", this.Session["username"], "' " });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.State.SelectedValue = list["State"].ToString();
                }
                list.Close();
                this.Button1.Attributes["onclick"] = "javascript:return chknull();";
            }
        }
    }
}

