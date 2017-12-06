namespace xyoa.InfoManage.wbemail
{
    using qiupeng.publiccs;
    using qiupeng.sql;
    using System;
    using System.Data.SqlClient;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class Email_show : Page
    {
        protected Label Content;
        protected HtmlForm form1;
        protected HtmlHead Head1;
        private Db List = new Db();
        protected Label Number;
        private publics pulicss = new publics();
        protected Label Settimes;
        protected Label Title;
        protected Label toemail;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["username"] == null)
            {
                base.Response.Write("<script language=javascript>alert('登陆超时！');window.parent.location = '/main_d.aspx'</script>");
            }
            else if (!this.Page.IsPostBack)
            {
                string sql = string.Concat(new object[] { "select * from qp_crm_CustomerLx where  id='", this.pulicss.GetFormatStr(base.Request.QueryString["id"]), "' and Username='", this.Session["username"], "'" });
                SqlDataReader list = this.List.GetList(sql);
                if (list.Read())
                {
                    this.Title.Text = list["Title"].ToString();
                    this.Content.Text = this.pulicss.GetFormatStrbjq_show(list["Content"].ToString());
                    this.toemail.Text = list["toemail"].ToString();
                    this.Settimes.Text = list["Settimes"].ToString();
                }
                list.Close();
                this.pulicss.InsertLog("查看邮件", "外部邮件");
            }
        }
    }
}

